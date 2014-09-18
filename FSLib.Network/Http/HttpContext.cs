using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.IO.Compression;

namespace FSLib.Network.Http
{
	using System.Threading.Tasks;

	/// <summary>
	/// 封装了一个请求的上下文环境
	/// </summary>
	public class HttpContext
	{
		/// <summary>
		/// 获得或设置状态对象
		/// </summary>
		public object State { get; set; }

		/// <summary>
		/// 获得当前的客户端
		/// </summary>
		public HttpClient Client { get; private set; }

		/// <summary>
		/// 获得请求信息
		/// </summary>
		public HttpRequestMessage Request { get; private set; }

		/// <summary>
		/// 获得请求内容
		/// </summary>
		public HttpRequestContent RequestContent
		{
			get { return Request.SelectValue(s => s.RequestData); }
		}

		/// <summary>
		/// 获得请求
		/// </summary>
		public HttpWebRequest WebRequest { get; private set; }

		/// <summary>
		/// 获得响应
		/// </summary>
		public HttpWebResponse WebResponse { get; private set; }

		/// <summary>
		/// 获得响应信息
		/// </summary>
		public HttpResponseMessage Response { get; private set; }

		/// <summary>
		/// 获得实际响应内容
		/// </summary>
		public HttpResponseContent ResponseContent
		{
			get { return Response.SelectValue(s => s.Content); }
		}

		/// <summary>
		/// 创建 <see cref="HttpContext" />  的新实例(HttpContext)
		/// </summary>
		internal HttpContext(HttpClient client, HttpRequestMessage request)
		{
			if (client == null)
				throw new ArgumentNullException("client", "client is null.");
			if (request == null)
				throw new ArgumentNullException("request", "request is null.");

			Client = client;
			Request = request;
		}

		AsyncOperation _operation;

		public Task<HttpResponseContent> SendTask()
		{
			var tlc = new TaskCompletionSource<HttpResponseContent>();
			RequestFinished += (s, e) => tlc.SetResult(ResponseContent);
			RequestFailed += (s, e) => tlc.SetException(Exception);
			Request.Async = true;
			Send();
			return tlc.Task;
		}

		/// <summary>
		/// 发送请求并做响应
		/// </summary>
		public void Send()
		{
			_operation = AsyncOperationManager.CreateOperation(null);

			Request.Normalize(Client, this);
			WebRequest = Client.HttpHandler.GetRequest(Request.Uri, Request.Method);
			Client.CopyDefaultSettings(this);
			Request.InitializeWebRequest(this);

			OnRequestSending();

			//如果有数据，则请求并写入
			if (Request.RequestData != null && Request.Method == HttpMethod.POST)
			{
				Request.RequestData.Prepare(WebRequest);

				if (Request.Async)
				{
					WebRequest.BeginGetRequestStream(_ =>
					{
						var stream = WebRequest.EndGetRequestStream(_);
						var embedStream = new HttpStreamWrapper(stream, WebRequest.ContentLength);
						embedStream.ProgressChanged += (s, e) =>
							Operation.Post(_1 => OnRequestDataSendProgressChanged(e), null);

						Operation.Post(s => OnRequestStreamFetched(), null);
						Operation.Post(s => OnRequestDataSending(), null);

						Request.RequestData.WriteTo(embedStream);
						stream.Close();

						Operation.Post(s => OnRequestDataSended(), null);
						Operation.Post(s => OnRequestSended(), null);

						WebRequest.BeginGetResponse(s => GetResponseCallback(() => { WebResponse = WebRequest.EndGetResponse(s) as HttpWebResponse; }), this);

					}, this);

					return;
				}
				else
				{
					var stream = WebRequest.GetRequestStream();
					var embedStream = new HttpStreamWrapper(stream, WebRequest.ContentLength);
					embedStream.ProgressChanged += (s, e) =>
						Operation.Post(_1 => OnRequestDataSendProgressChanged(e), null);

					OnRequestStreamFetched();
					OnRequestDataSending();
					Request.RequestData.WriteTo(embedStream);
					stream.Close();
					OnRequestDataSended();
				}
			}
			OnRequestSended();
			if (Request.Async)
			{
				WebRequest.BeginGetResponse(s => GetResponseCallback(() => { WebResponse = WebRequest.EndGetResponse(s) as HttpWebResponse; }), this);
			}
			else
			{
				GetResponseCallback(() => { WebResponse = WebRequest.GetResponse() as HttpWebResponse; });
			}
		}

		private void GetResponseCallback(Action getResponseAction)
		{
			try
			{
				getResponseAction();
				Operation.Post(_ => OnResponseHeaderReceived(), null);
			}
			catch (WebException webex)
			{
				Exception = webex;
				if (webex.Status == WebExceptionStatus.ProtocolError)
				{
					WebResponse = webex.Response as HttpWebResponse;
					//发生错误，清掉期待类型以便于猜测
					Request.ExceptType = null;
				}
			}
			catch (Exception ex)
			{
				Exception = ex;
			}

			if (Exception != null)
			{
				Operation.PostOperationCompleted(_ => OnRequestFailed(), null);
				return;
			}

			//保持环境
			Response = new HttpResponseMessage(WebResponse);
			Client.Setting.LastUri = WebResponse.ResponseUri;
			if (WebResponse.ResponseUri != WebRequest.Address)
			{
				Response.Redirection = new HttpRedirection(WebRequest.Address, WebResponse.ResponseUri);
			}
			else if (WebResponse.IsRedirectHttpWebResponse())
			{
				var location = Response.Location;
				if (location.IsNullOrEmpty())
				{
					throw new ProtocolViolationException("是重定向的请求, 但是未提供新地址");
				}
				Response.Redirection = new HttpRedirection(WebRequest.Address, new Uri(WebRequest.Address, location));
			}
			if (Response.Cookies != null)
				Client.CookieContainer.Add(Response.Cookies);

			//处理响应
			if (Request.ExceptType == null)
			{
				//没有设置优选，先确定内容
				Response.Content = GetPreferedResponseContent();
			}
			else
			{
				Response.Content = Request.ExceptType;
			}
			//获得响应流
			Stream responseStream;
			try
			{
				responseStream = WebResponse.GetResponseStream();
			}
			catch (Exception ex)
			{
				WebResponse.Close();
				Exception = ex;
				_operation.PostOperationCompleted(_ => OnRequestFailed(), null);
				return;
			}

			//创建wrapper
			responseStream = new HttpStreamWrapper(responseStream, Response.ContentLength);
			(responseStream as HttpStreamWrapper).ProgressChanged += (s, e) => Operation.Post(_ => OnResponseReadProgressChanged(e), null);
			Operation.Post(_ => OnResponseStreamFetched(), null);

			//解压缩
			if (Request.AutoDecompressGzip)
			{
				if (Response.ContentEncoding.IndexOf("gzip", StringComparison.OrdinalIgnoreCase) != -1)
				{
					responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
				}
				else if (Response.ContentEncoding.IndexOf("deflate", StringComparison.OrdinalIgnoreCase) != -1)
				{
					responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);
				}
			}

			//读取响应
			try
			{
				ResponseContent.BeginProcessResponse(responseStream);
				OnRequestValidateResponse();
			}
			catch (Exception ex)
			{
				Exception = ex;
			}

			//跳转?
			if (Response.Redirection != null)
			{
				Operation.Post(_ => OnRequestRedirect(), null);
			}

			//完成
			WebResponse.Close();

			if (!IsSuccess)
			{
				Operation.PostOperationCompleted(_ => OnRequestFailed(), null);
			}
			else
			{
				Operation.PostOperationCompleted(_ => OnRequestFinished(), null);
			}
		}

		protected virtual HttpResponseContent GetPreferedResponseContent()
		{
			var contentType = WebResponse.ContentType;
			var index = contentType.IndexOf(";");
			if (index != -1) contentType = contentType.Substring(0, index);	//分解带字符串的

			if (contentType == "text/xml") return new ResponseXmlContent(this, Client);	//XML
			if (contentType.StartsWith("image")) return new ResponseImageContent(this, Client);	//图片
			if (contentType.StartsWith("text") || contentType == "application/json" || contentType == "application/x-javascript") return new ResponseStringContent(this, Client);

			return new ResponseBinaryContent(this, Client);
		}

		/// <summary>
		/// 设置保存响应到文件
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public ResponseFileContent AcquireResponseToFile(string filePath)
		{
			return (ResponseContent ?? (Request.ExceptType = new ResponseFileContent(this, Client, filePath))) as ResponseFileContent;
		}

		/// <summary>
		/// 设置保存响应到流
		/// </summary>
		/// <returns></returns>
		public ResponseStreamContent AcquireResponseToStream()
		{
			return (ResponseContent ?? (Request.ExceptType = new ResponseStreamContent(this, Client))) as ResponseStreamContent;
		}

		/// <summary>
		/// 设置保存响应到图片
		/// </summary>
		/// <returns></returns>
		public ResponseImageContent AcquireResponseToImage()
		{
			return (ResponseContent ?? (Request.ExceptType = new ResponseImageContent(this, Client))) as ResponseImageContent;
		}

		/// <summary>
		/// 设置保存响应到XML文档
		/// </summary>
		/// <returns></returns>
		public ResponseXmlContent AcquireResponseToXml()
		{
			return (ResponseContent ?? (Request.ExceptType = new ResponseXmlContent(this, Client))) as ResponseXmlContent;
		}

		/// <summary>
		/// 设置保存响应到对象
		/// </summary>
		/// <returns></returns>
		public ResponseObjectContent<T> AcquireResponseToObject<T>()
		{
			return (ResponseContent ?? (Request.ExceptType = new ResponseObjectContent<T>(this, Client))) as ResponseObjectContent<T>;
		}

		/// <summary>
		/// 设置保存响应到字符串
		/// </summary>
		/// <returns></returns>
		public ResponseStringContent AcquireResponseToString()
		{
			return (ResponseContent ?? (Request.ExceptType = new ResponseStringContent(this, Client))) as ResponseStringContent;
		}

		/// <summary>
		/// 设置保存响应到二进制数组
		/// </summary>
		/// <returns></returns>
		public ResponseBinaryContent AcquireResponseToBinaryData()
		{
			return (ResponseContent ?? (Request.ExceptType = new ResponseStreamContent(this, Client))) as ResponseBinaryContent;
		}

		#region 事件

		/// <summary>
		/// 正在准备发送
		/// </summary>
		public event EventHandler RequestSending;

		/// <summary>
		/// 触发 <see cref="RequestSending"/> 事件
		/// </summary>
		protected virtual void OnRequestSending()
		{
			EventHandler handler = RequestSending;
			if (handler != null) handler(this, EventArgs.Empty);
		}

		/// <summary>
		/// 请求已经发送，正在等待写入请求数据或等待响应流
		/// </summary>
		public event EventHandler RequestSended;

		/// <summary>
		/// 引发 <see cref="RequestSended" /> 事件
		/// </summary>
		protected virtual void OnRequestSended()
		{
			var handler = RequestSended;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		/// <summary>
		/// 已经获得请求流
		/// </summary>
		public event EventHandler RequestStreamFetched;

		/// <summary>
		/// 引发 <see cref="RequestStreamFetched" /> 事件
		/// </summary>
		protected virtual void OnRequestStreamFetched()
		{
			var handler = RequestStreamFetched;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		/// <summary>
		/// 正在发送请求数据
		/// </summary>
		public event EventHandler RequestDataSending;

		/// <summary>
		/// 引发 <see cref="RequestDataSending" /> 事件
		/// </summary>
		protected virtual void OnRequestDataSending()
		{
			var handler = RequestDataSending;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		/// <summary>
		/// 请求数据发送进度变化
		/// </summary>
		public event EventHandler<DataProgressEventArgs> RequestDataSendProgressChanged;

		/// <summary>
		/// 引发 <see cref="RequestDataSendProgressChanged" /> 事件
		/// </summary>
		/// <param name="ea">包含此事件的参数</param>
		protected virtual void OnRequestDataSendProgressChanged(DataProgressEventArgs ea)
		{
			var handler = RequestDataSendProgressChanged;
			if (handler != null)
				handler(this, ea);
		}

		/// <summary>
		/// 请求数据已经发送
		/// </summary>

		public event EventHandler RequestDataSended;

		/// <summary>
		/// 引发 <see cref="RequestDataSended" /> 事件
		/// </summary>
		protected virtual void OnRequestDataSended()
		{
			var handler = RequestDataSended;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		/// <summary>
		/// 已经收到响应
		/// </summary>
		public event EventHandler ResponseHeaderReceived;

		/// <summary>
		/// 引发 <see cref="ResponseHeaderReceived" /> 事件
		/// </summary>
		protected virtual void OnResponseHeaderReceived()
		{
			var handler = ResponseHeaderReceived;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		/// <summary>
		/// 已经获得响应流
		/// </summary>
		public event EventHandler ResponseStreamFetched;

		/// <summary>
		/// 引发 <see cref="ResponseStreamFetched" /> 事件
		/// </summary>
		protected virtual void OnResponseStreamFetched()
		{
			var handler = ResponseStreamFetched;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		/// <summary>
		/// 响应读取进度变更
		/// </summary>
		public event EventHandler<DataProgressEventArgs> ResponseReadProgressChanged;

		/// <summary>
		/// 引发 <see cref="ResponseReadProgressChanged" /> 事件
		/// </summary>
		/// <param name="ea">包含此事件的参数</param>
		protected virtual void OnResponseReadProgressChanged(DataProgressEventArgs ea)
		{
			var handler = ResponseReadProgressChanged;
			if (handler != null)
				handler(this, ea);
		}

		/// <summary>
		/// 请求已经完成
		/// </summary>

		public event EventHandler RequestFinished;

		/// <summary>
		/// 引发 <see cref="RequestFinished" /> 事件
		/// </summary>
		protected virtual void OnRequestFinished()
		{
			var handler = RequestFinished;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		/// <summary>
		/// 请求失败
		/// </summary>
		public event EventHandler RequestFailed;

		/// <summary>
		/// 引发 <see cref="RequestFailed" /> 事件
		/// </summary>
		protected virtual void OnRequestFailed()
		{
			var handler = RequestFailed;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		/// <summary>
		/// 检测到重定向
		/// </summary>
		public event EventHandler RequestRedirect;

		/// <summary>
		/// 引发 <see cref="RequestRedirect" /> 事件
		/// </summary>
		protected virtual void OnRequestRedirect()
		{
			var handler = RequestRedirect;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		/// <summary>
		/// 请求验证内容
		/// </summary>
		public event EventHandler RequestValidateResponse;

		/// <summary>
		/// 引发 <see cref="RequestValidateResponse" /> 事件
		/// </summary>
		protected virtual void OnRequestValidateResponse()
		{
			var handler = RequestValidateResponse;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}



		#endregion

		/// <summary>
		/// 获得或设置关联的异常
		/// </summary>
		public Exception Exception { get; private set; }

		/// <summary>
		/// 获得是否成功
		/// </summary>
		public bool IsSuccess
		{
			get
			{
				return ResponseContent != null && Exception == null && (int)Response.Status < 400;
			}
		}

		/// <summary>
		/// 获得异步操作的引用
		/// </summary>
		public AsyncOperation Operation
		{
			get { return _operation; }
		}
	}

	/// <summary>
	/// 强类型的结果
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class HttpContext<T> : HttpContext
	{
		/// <summary>
		/// 创建 <see cref="HttpContext" />  的新实例(HttpContext)
		/// </summary>
		internal HttpContext(HttpClient client, HttpRequestMessage request)
			: base(client, request)
		{
		}

		/// <summary>
		/// 获得响应的结果
		/// </summary>
		public T Result
		{
			get
			{
				var t = typeof(T);
				if (t == typeof(string)) return (T)(object)AcquireResponseToString().StringResult;
				if (t == typeof(byte[])) return (T)(object)AcquireResponseToBinaryData().Result;
				if (t == typeof(Image)) return (T)(object)AcquireResponseToImage().Image;
				if (t == typeof(XmlDocument)) return (T)(object)AcquireResponseToXml().XmlDocument;
				if (t == typeof(Stream))
					throw new InvalidOperationException("不可通过此方式操作流结果");

				return (T)(object)AcquireResponseToObject<T>().Object;
			}
		}
	}
}
