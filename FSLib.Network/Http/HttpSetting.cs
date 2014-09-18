using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	using System.Net;

	public class HttpSetting
	{
		#region 静态变量

		static HttpSetting()
		{
			WebRequestHeaderIDList = new string[] { 
				"Cache-Control", "Connection", "Date", "Keep-Alive", "Pragma", "Trailer", "Transfer-Encoding", "Upgrade", "Via", "Warning", "Allow", "Content-Length", "Content-Type", "Content-Encoding", "Content-Language", "Content-Location", 
				"Content-MD5", "Content-Range", "Expires", "Last-Modified", "Accept", "Accept-Charset", "Accept-Encoding", "Accept-Language", "Authorization", "Cookie", "Expect", "From", "Host", "If-Match", "If-Modified-Since", "If-None-Match", 
				"If-Range", "If-Unmodified-Since", "Max-Forwards", "Proxy-Authorization", "Referer", "Range", "Te", "Translate", "User-Agent"
			 };
			WebRequestHeaderIDMap = new Dictionary<string, HttpRequestHeader>();
			for (int i = 0; i < WebRequestHeaderIDList.Length; i++)
			{
				WebRequestHeaderIDMap.Add(WebRequestHeaderIDList[i], (HttpRequestHeader)i);
			}
		}

		/// <summary>
		/// WebRequest请求标头映射
		/// </summary>
		public static Dictionary<string, HttpRequestHeader> WebRequestHeaderIDMap { get; private set; }

		/// <summary>
		/// WebReqest请求标头列表
		/// </summary>
		public static string[] WebRequestHeaderIDList { get; private set; }

		/// <summary>
		/// 默认的UserAgent
		/// </summary>
		public static string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1;)";

		#endregion

		/// <summary>
		/// 获得或设置字符编码
		/// </summary>
		public Encoding StringEncoding { get; set; }

		/// <summary>
		/// 创建 <see cref="HttpSetting" />  的新实例(HttpSetting)
		/// </summary>
		public HttpSetting()
		{
			Headers = new WebHeaderCollection();
			Accept = "*/*";
			AcceptLanguage = System.Globalization.CultureInfo.CurrentCulture.Name;
			Connection = "Close";
			UserAgent = DefaultUserAgent;
			DecodeForSearchCharsetRange = 0x400;
			KeepAlive = false;
			Timeout = 10000;
			StringEncoding = System.Text.Encoding.UTF8;
		}

		/// <summary>
		/// 获得或设置是否在请求中添加Ajax的标记
		/// </summary>
		public bool AppendAjaxHeader { get; set; }

		/// <summary>
		/// 获得或设置默认超时时间
		/// </summary>
		public int Timeout { get; set; }

		/// <summary>
		/// 对应HTTP请求的请求标头
		/// </summary>
		public WebHeaderCollection Headers { get; set; }

		/// <summary>
		/// 获得或设置当前HTTP协议的保持连接设置
		/// </summary>
		public string Connection { get; set; }

		/// <summary>
		/// 获得或设置当前HTTP协议的内容类型
		/// </summary>
		public string ContentType { get; set; }

		/// <summary>
		/// 获得或设置当前HTTP协议的接受编码类型
		/// </summary>
		public string AcceptEncoding { get { return this.Headers[HttpRequestHeader.AcceptEncoding]; } set { this.Headers[HttpRequestHeader.AcceptEncoding] = value; } }

		/// <summary>
		/// 获得或设置当前HTTP协议的接受内容类型
		/// </summary>
		public string Accept { get; set; }

		/// <summary>
		/// 获得或设置当前HTTP协议的接受编码类型
		/// </summary>
		public string AcceptLanguage { get { return this.Headers[HttpRequestHeader.AcceptLanguage]; } set { this.Headers[HttpRequestHeader.AcceptLanguage] = value; } }

		/// <summary>
		/// 获得或设置当前HTTP协议的用户协议
		/// </summary>
		public string UserAgent
		{
			get;
			set;
		}

		/// <summary>
		/// 获得或设置当前正文的编码类型
		/// </summary>
		public string TransferEncoding { get; set; }

		/// <summary>
		/// 搜索Charset标记的默认最大区域（为了节约内存，默认1KB）
		/// </summary>
		public int DecodeForSearchCharsetRange { get; set; }

		/// <summary>
		/// 获得或设置是否保持活动
		/// </summary>
		public bool KeepAlive { get; set; }

		/// <summary>
		/// 忽略的标头
		/// </summary>
		HttpRequestHeader[] omitHeaders = new HttpRequestHeader[] { 
				HttpRequestHeader.Accept,HttpRequestHeader.ContentLength,HttpRequestHeader.ContentRange,HttpRequestHeader.ContentLength,HttpRequestHeader.Expect,
				HttpRequestHeader.Date,HttpRequestHeader.Host,HttpRequestHeader.IfModifiedSince,HttpRequestHeader.Range,HttpRequestHeader.TransferEncoding
			};

		/// <summary>
		/// 将指定的Header复制到对应的请求中
		/// </summary>
		internal void CopyHeader(HttpWebRequest request)
		{
			foreach (string item in Headers.AllKeys)
			{
				if (this.Headers[item] == null || request.Headers[item] != null) continue;

				var value = this.Headers[item];
				var header = item.ToWebRequestHeader();

				if (!omitHeaders.Contains(header))
				{
					request.Headers[item] = value;
				}
			}

			if (!string.IsNullOrEmpty(Accept)) request.Accept = this.Accept;
			if (!string.IsNullOrEmpty(ContentType)) request.ContentType = this.ContentType;
			if (!string.IsNullOrEmpty(UserAgent)) request.UserAgent = this.UserAgent;
			if (!string.IsNullOrEmpty(TransferEncoding))
			{
				request.TransferEncoding = this.TransferEncoding;
				request.SendChunked = true;
			}
			request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
			request.ServicePoint.Expect100Continue = false;
			request.KeepAlive = KeepAlive;
			request.Timeout = Timeout;
			request.ReadWriteTimeout = Timeout;
		}

		/// <summary>
		/// 设置接受XML类型的响应
		/// </summary>
		public void SetAcceptXml()
		{
			this.Accept = "text/xml";
		}
		/// <summary>
		/// 设置接受JSON类型的响应
		/// </summary>
		public void SetAcceptJson()
		{
			this.Accept = "application/json";
		}
		/// <summary>
		/// 设置不保持连接
		/// </summary>
		public void SetCloseConnection()
		{
			this.Connection = "Close";
		}

		/// <summary>
		/// 获得或设置最后响应的网址
		/// </summary>
		public Uri LastUri { get; set; }
	}
}
