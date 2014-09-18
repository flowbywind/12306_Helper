using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	/// <summary>
	/// 响应内容
	/// </summary>
	public abstract class HttpResponseContent
	{
		/// <summary>
		/// 获得当前的上下文环境
		/// </summary>
		public HttpContext Context { get; private set; }

		/// <summary>
		/// 获得当前的请求客户端
		/// </summary>
		public HttpClient Client { get; private set; }

		/// <summary>
		/// 创建 <see cref="HttpResponseContent" />  的新实例(HttpResponseContent)
		/// </summary>
		protected HttpResponseContent(HttpContext context, HttpClient client)
		{
			Context = context;
			Client = client;
		}

		/// <summary>
		/// 处理响应
		/// </summary>
		/// <param name="stream"></param>
		protected abstract void ProcessResponse(System.IO.Stream stream);

		/// <summary>
		/// 处理响应
		/// </summary>
		/// <param name="stream"></param>
		internal void BeginProcessResponse(System.IO.Stream stream)
		{
			ProcessResponse(stream);
		}
	}
}
