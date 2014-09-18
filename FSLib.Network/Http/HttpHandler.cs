using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	using System.Net;

	/// <summary>
	/// 创建指定类型对象实例的工厂类
	/// </summary>
	public class HttpHandler
	{
		/// <summary>
		/// 获得用于发送请求的Request对象
		/// </summary>
		/// <param name="uri"></param>
		/// <param name="method"></param>
		/// <returns></returns>
		public virtual HttpWebRequest GetRequest(Uri uri, HttpMethod method)
		{
			var req = HttpWebRequest.Create(uri);
			req.Method = method.ToString();

			return req as HttpWebRequest;
		}

		/// <summary>
		/// 创建上下文环境
		/// </summary>
		/// <param name="client"></param>
		/// <param name="request"></param>
		/// <returns></returns>
		public virtual HttpContext GetContext(HttpClient client, HttpRequestMessage request)
		{
			return new HttpContext(client, request);
		}

		/// <summary>
		/// 创建上下文环境
		/// </summary>
		/// <param name="client"></param>
		/// <param name="request"></param>
		/// <returns></returns>
		public virtual HttpContext<T> GetContext<T>(HttpClient client, HttpRequestMessage request)
		{
			return new HttpContext<T>(client, request);
		}
	}
}
