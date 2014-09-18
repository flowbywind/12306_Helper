using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace FSLib.Network.Http
{
	using System.Net;

	/// <summary>
	/// 类型 HttpClient
	/// </summary>
	public class HttpClient
	{
		static HttpClient()
		{
			ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

		}


		/// <summary>
		/// 获得或设置参数
		/// </summary>
		public HttpSetting Setting { get; private set; }

		/// <summary>
		/// 获得或创建HTTP请求句柄
		/// </summary>
		public HttpHandler HttpHandler { get; set; }

		/// <summary>
		/// 获得或设置使用的CookiesContainer
		/// </summary>
		public CookieContainer CookieContainer { get; set; }

		/// <summary>
		/// 创建 <see cref="HttpClient" />  的新实例(HttpClient)
		/// </summary>
		public HttpClient(HttpSetting setting, HttpHandler handler = null, CookieContainer cookieContainer = null)
		{
			Setting = setting;
			CookieContainer = cookieContainer ?? new CookieContainer();
			HttpHandler = handler ?? new HttpHandler();
		}

		/// <summary>
		/// 创建 <see cref="HttpClient" />  的新实例(HttpClient)
		/// </summary>

		public HttpClient()
			: this(new HttpSetting())
		{
		}

		#region 核心逻辑

		/// <summary>
		/// 创建一个GET请求
		/// </summary>
		/// <param name="uri"></param>
		/// <param name="refer"></param>
		/// <returns></returns>
		public HttpContext Get(Uri uri, Uri refer = null)
		{
			var message = new HttpRequestMessage
			{
				Method = HttpMethod.GET,
				Uri = uri,
				ReferUri = refer,
				Encoding = Setting.StringEncoding
			};
			return Create(message);
		}

		/// <summary>
		/// 创建一个WEB请求
		/// </summary>
		/// <param name="uri"></param>
		/// <param name="content"></param>
		/// <param name="refer"></param>
		/// <returns></returns>
		public HttpContext Post(Uri uri, HttpRequestContent content, Uri refer = null)
		{
			var message = new HttpRequestMessage
			{
				Method = HttpMethod.POST,
				Uri = uri,
				ReferUri = refer,
				RequestData = content,
				Encoding = Setting.StringEncoding
			};
			return Create(message);
		}

		/// <summary>
		/// 创建请求
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public HttpContext Create(HttpRequestMessage message)
		{
			if (message.Encoding == null) message.Encoding = Setting.StringEncoding;
			var context = HttpHandler.GetContext(this, message);
			message.ReferUri = Setting.LastUri;

			return context;
		}

		/// <summary>
		/// 创建网络请求
		/// </summary>
		/// <param name="uri">请求地址</param>
		/// <param name="method">方法</param>
		/// <param name="requestData">写入的数据</param>
		/// <param name="refer">引用页</param>
		/// <param name="messageCallback">消息处理句柄</param>
		/// <param name="saveToFile">保存文件地址</param>
		/// <param name="streamInvoker">流读取对象，仅当返回结果为流时可用</param>
		/// <typeparam name="TResult">结果类型</typeparam>
		/// <returns></returns>
		public HttpContext<TResult> Create<TResult>(Uri uri, HttpMethod? method = null, object requestData = null, Uri refer = null,
			Action<HttpRequestMessage> messageCallback = null, string saveToFile = null, Action<Stream> streamInvoker = null, bool async = false)
		{
			var resultType = typeof(TResult);
			if (method == null)
			{
				method = HttpMethod.GET;
				if (requestData != null) method = HttpMethod.POST;
			}
			if (streamInvoker != null && typeof(Stream) == resultType) throw new InvalidOperationException("非流结果时不可设置流操作");


			var request = new HttpRequestMessage(uri, method.Value)
			{
				ReferUri = refer,
				Encoding = Setting.StringEncoding
			};
			if (requestData != null)
			{
				if (requestData is HttpRequestContent) request.RequestData = requestData as HttpRequestContent;
				else if (requestData is string) request.RequestData = new RequestStringContent(requestData as string);
				else if (requestData is Stream) request.RequestData = new RequestCopyStreamContent(requestData as Stream);
				else if (requestData is byte[]) request.RequestData = new RequestByteBufferContent(requestData as byte[]);
				else if (requestData is IDictionary<string, string>)
				{
					request.RequestData = new RequestFormDataContent(requestData as IDictionary<string, string>);
				}
				else
				{
					request.RequestData = new RequestObjectContent<object>(requestData);
				}
			}
			else if (method == HttpMethod.POST)
			{
				request.RequestData = new RequestByteBufferContent(new byte[0]);
			}
			request.Async = async;

			if (messageCallback != null) messageCallback(request);

			var ctx = HttpHandler.GetContext<TResult>(this, request);

			//自动设置格式
			if (request.ExceptType == null)
			{
				if (!saveToFile.IsNullOrEmpty())
				{
					request.ExceptType = new ResponseFileContent(ctx, this, saveToFile);
				}
				else
				{
					if (resultType != typeof(object))
					{
						if (resultType == typeof(string)) request.ExceptType = new ResponseStringContent(ctx, this);
						else if (resultType == typeof(byte[])) request.ExceptType = new ResponseBinaryContent(ctx, this);
						else if (resultType == typeof(Image)) request.ExceptType = new ResponseImageContent(ctx, this);
						else if (resultType == typeof(XmlDocument)) request.ExceptType = new ResponseXmlContent(ctx, this);
						else if (resultType == typeof(Stream))
						{
							var r = new ResponseStreamContent(ctx, this);
							request.ExceptType = r;
							if (streamInvoker != null)
							{
								r.RequireProcessStream += (s, e) => streamInvoker(e.Stream);
							}
						}
						else
						{
							request.ExceptType = new ResponseObjectContent<TResult>(ctx, this);
						}
					}
				}
			}

			return ctx;
		}

		internal void CopyDefaultSettings(HttpContext context)
		{
			context.WebRequest.CookieContainer = CookieContainer;
			Setting.CopyHeader(context.WebRequest);
		}

		#endregion

	}
}
