using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FSLib.Network.Http
{
	using System.IO;

	/// <summary>
	/// HTTP请求信息
	/// </summary>
	public class HttpRequestMessage
	{
		/// <summary>
		/// 获得客户端
		/// </summary>
		public HttpClient Client { get; private set; }

		/// <summary>
		/// 获得上下文环境
		/// </summary>
		protected internal HttpContext Context
		{
			get;
			set;
		}


		public HttpRequestMessage()
			: this(null, HttpMethod.GET)
		{
		}

		/// <summary>
		/// 创建 <see cref="HttpRequestMessage" />  的新实例(HttpRequestMessage)
		/// </summary>
		public HttpRequestMessage(Uri uri, HttpMethod method)
		{
			Uri = uri;
			Method = method;
			AllowAutoRedirect = true;
			AutoDecompressGzip = true;
		}

		/// <summary>
		/// 获得或设置是否自动解压缩GZIP的响应数据-仅HTTP请求有效
		/// </summary>
		public bool AutoDecompressGzip { get; set; }

		/// <summary>
		/// 获得或设置是否允许自动重定向请求(HTTP 302-Found)
		/// </summary>
		public bool AllowAutoRedirect { get; set; }

		/// <summary>
		/// 获得或设置请求的地址
		/// </summary>
		public Uri Uri { get; set; }

		/// <summary>
		/// 获得或设置操作的方法
		/// </summary>
		public HttpMethod Method { get; set; }

		/// <summary>
		/// 获得或设置是否在请求中添加Ajax的标记
		/// </summary>
		public bool AppendAjaxHeader { get; set; }

		/// <summary>
		/// 获得或设置引用页地址
		/// </summary>
		public Uri ReferUri { get; set; }

#if NET4

		/// <summary>
		/// 获得或设置主机头
		/// </summary>
		public string Host { get; set; }

#endif

		/// <summary>
		/// 获得或设置超时时间
		/// </summary>
		public int? Timeout { get; set; }

		/// <summary>
		/// 获得或设置是否保持活动连接
		/// </summary>
		public bool KeepAlive { get; set; }

		/// <summary>
		/// 获得或设置请求数据
		/// </summary>
		public HttpRequestContent RequestData { get; set; }

		/// <summary>
		/// 获得或设置UserAgent
		/// </summary>
		public string UserAgent { get; set; }

		/// <summary>
		/// 获得或设置接受类型
		/// </summary>
		public string Accept { get; set; }

		/// <summary>
		/// 获得或设置内容类型
		/// </summary>
		public string ContentType { get; set; }

		/// <summary>
		/// 获得或设置编码
		/// </summary>
		public Encoding Encoding { get; set; }

		/// <summary>
		/// 获得或设置请求的分界
		/// </summary>
		public string RequestBoundary { get; set; }

		/// <summary>
		/// 获得或设置是否是异步请求
		/// </summary>
		public bool Async { get; set; }

		/// <summary>
		/// 获得或设置期望的结果类型。如果没有设置，将会根据响应类型返回默认的类型
		/// </summary>
		public HttpResponseContent ExceptType { get; set; }

		/// <summary>
		/// 获得或设置当前请求的日期判断
		/// </summary>
		public DateTime? IfModifiedSince { get; set; }

		/// <summary>
		/// 获得或设置当前请求的范围
		/// </summary>
		public KeyValuePair<int, int>? Range { get; set; }

		/// <summary>
		/// 对应HTTP请求的请求标头
		/// </summary>
		public WebHeaderCollection Headers { get; set; }

		/// <summary>
		/// 格式化信息
		/// </summary>
		internal void Normalize(HttpClient client, HttpContext context)
		{
			Client = client;
			Context = context;

			if (RequestData != null)
			{
				RequestData.BindContext(client, context, this);

				if (Method == HttpMethod.GET)
				{
					//内容转移到查询中
					var str = RequestData.SerializeAsQueryString();
					if (!str.IsNullOrEmpty())
					{
						var query = Uri.Query;
						if (query.IsNullOrEmpty() || query == "?") Uri = new Uri(Uri, "?" + str);
						else Uri = new Uri(Uri, query + "&" + str);
					}
				}
			}

		}

		/// <summary>
		/// 初始化请求
		/// </summary>
		/// <param name="context"></param>
		internal void InitializeWebRequest(HttpContext context)
		{
			var request = context.WebRequest;
			if (!Accept.IsNullOrEmpty()) request.Accept = Accept;
			if (!ContentType.IsNullOrEmpty()) request.ContentType = ContentType;
			else if (Method == HttpMethod.POST)
			{
				request.ContentType = "application/x-www-form-urlencoded";
			}
			if (IfModifiedSince != null) request.IfModifiedSince = this.IfModifiedSince.Value;
			if (Range != null) request.AddRange(this.Range.Value.Key, this.Range.Value.Value);
			if (AppendAjaxHeader)
			{
				request.Headers.Add("X-Requested-With", "XMLHttpRequest");
			}
			request.KeepAlive = KeepAlive;
			if (Timeout > 0) request.Timeout = request.ReadWriteTimeout = Timeout.Value;
#if NET4
			if (!string.IsNullOrEmpty(Host))
			{
				request.Host = Host;
				Host = null;
			}
#endif
			request.AllowAutoRedirect = AllowAutoRedirect;
			request.AutomaticDecompression = DecompressionMethods.None;
			if (ReferUri != null)
				request.Referer = ReferUri.ToString();
		}
	}
}
