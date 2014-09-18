using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FSLib.Network.Http
{
	/// <summary>
	/// HTTP响应信息
	/// </summary>
	public class HttpResponseMessage
	{
		/// <summary>
		/// 获得响应内容
		/// </summary>
		public HttpWebResponse WebResponse { get; private set; }

		/// <summary>
		/// 创建 <see cref="HttpResponseMessage" />  的新实例(HttpResponseMessage)
		/// </summary>
		public HttpResponseMessage(HttpWebResponse webResponse)
		{
			WebResponse = webResponse;
			Cookies = WebResponse.Cookies;
			Status = WebResponse.StatusCode;
			StatusDescription = WebResponse.StatusDescription;
			ContentLength = WebResponse.ContentLength;
			ContentType = WebResponse.ContentType;
			ContentEncoding = WebResponse.ContentEncoding;
			Headers = WebResponse.Headers;
			CharacterSet = WebResponse.CharacterSet;
			LastModified = WebResponse.LastModified;
			HttpVersion = WebResponse.ProtocolVersion;
			Server = WebResponse.Server;
			Method = (HttpMethod)Enum.Parse(typeof (HttpMethod), webResponse.Method);
			ResponseUri = webResponse.ResponseUri;

			if (IsPartialContent)
			{
				ContentRange = new Range(Headers["Content-Range"]);
			}
		}

		/// <summary>
		/// 获得最后修改
		/// </summary>
		public DateTime LastModified { get; set; }

		/// <summary>
		/// 获得HTTP版本
		/// </summary>
		public Version HttpVersion { get; set; }

		/// <summary>
		/// 获得服务器标头
		/// </summary>
		public string Server { get; set; }

		/// <summary>
		/// 获得响应的方法
		/// </summary>
		public HttpMethod Method { get; set; }

		/// <summary>
		/// 获得响应的最终地址
		/// </summary>
		public Uri ResponseUri { get; set; }

		/// <summary>
		/// 获得响应的字符集
		/// </summary>
		public string CharacterSet { get; private set; }

		/// <summary>
		/// 获得响应头
		/// </summary>
		public WebHeaderCollection Headers { get; private set; }

		/// <summary>
		/// 获得响应的Cookies
		/// </summary>
		public CookieCollection Cookies
		{
			get;
			private set;
		}

		/// <summary>
		/// 获得状态码
		/// </summary>
		public HttpStatusCode Status
		{
			get;
			private set;
		}

		/// <summary>
		/// 获得状态码
		/// </summary>
		public string StatusDescription
		{
			get;
			private set;
		}

		/// <summary>
		/// 获得响应的内容
		/// </summary>
		public long ContentLength
		{
			get;
			private set;
		}

		/// <summary>
		/// 获得响应类型
		/// </summary>
		public string ContentType
		{
			get;
			private set;
		}

		/// <summary>
		/// 获得当前的重定向信息
		/// </summary>
		public HttpRedirection Redirection { get; internal set; }

		/// <summary>
		/// 获得响应编码
		/// </summary>
		public string ContentEncoding
		{
			get;
			private set;
		}

		/// <summary>
		/// 获得接受的域
		/// </summary>
		public string AcceptRange
		{
			get { return Headers[HttpResponseHeader.AcceptRanges]; }
		}

		/// <summary>
		/// 获得当前包含的响应区域
		/// </summary>
		public Range ContentRange { get; private set; }

		/// <summary>
		/// 获得是否是部分响应
		/// </summary>
		public bool IsPartialContent
		{
			get { return Status == HttpStatusCode.PartialContent; }
		}

		/// <summary>
		/// 获得响应标头中的地址
		/// </summary>
		public string Location
		{
			get { return Headers[HttpResponseHeader.Location]; }
		}


		public static implicit operator HttpWebResponse(HttpResponseMessage message)
		{
			return message.WebResponse;
		}

		/// <summary>
		/// 获得实际的内容
		/// </summary>
		public HttpResponseContent Content { get; internal set; }
	}
}
