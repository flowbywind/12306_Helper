using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	using System.IO;
	using System.Net;

	/// <summary>
	/// HTTP请求内容
	/// </summary>
	public abstract class HttpRequestContent
	{
		/// <summary>
		/// 获得客户端
		/// </summary>
		public HttpClient Client { get; private set; }

		/// <summary>
		/// 获得请求消息
		/// </summary>
		protected internal HttpRequestMessage Message { get; private set; }

		/// <summary>
		/// 获得上下文环境
		/// </summary>
		protected internal HttpContext Context
		{
			get;
			set;
		}

		/// <summary>
		/// 获得上下文请求
		/// </summary>
		protected internal HttpWebRequest WebRequset { get; private set; }

		/// <summary>
		/// 写入内容到流中
		/// </summary>
		/// <param name="stream"></param>
		public abstract void WriteTo(Stream stream);

		/// <summary>
		/// 绑定上下文环境
		/// </summary>
		/// <param name="message"></param>
		public virtual void BindContext(HttpClient client, HttpContext context, HttpRequestMessage message)
		{
			Client = client;
			Context = context;
			Message = message;
		}

		/// <summary>
		/// 准备发出请求
		/// </summary>
		/// <param name="request"></param>
		public virtual void Prepare(HttpWebRequest request)
		{
			WebRequset = request;

			if (Message.Method == HttpMethod.POST)
				request.ContentLength = ComputeLength();
		}

		/// <summary>
		/// 计算长度
		/// </summary>
		/// <returns></returns>
		public abstract long ComputeLength();

		/// <summary>
		/// 将当前的内容序列化到查询中
		/// </summary>
		public virtual string SerializeAsQueryString()
		{
			throw new NotSupportedException("当前的查询内容无法转换为查询字符串");
		}

		/// <summary>
		/// 将字符串隐式转换为内容
		/// </summary>
		/// <param name="content"></param>
		/// <returns></returns>
		public static implicit operator HttpRequestContent(string content)
		{
			return (RequestStringContent)content;
		}

		/// <summary>
		/// 将字符串隐式转换为内容
		/// </summary>
		/// <param name="content"></param>
		/// <returns></returns>
		public static implicit operator HttpRequestContent(byte[] content)
		{
			return (RequestByteBufferContent)content;
		}

		/// <summary>
		/// 将流转换为请求内容
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		public static implicit operator HttpRequestContent(Stream stream)
		{
			return (RequestCopyStreamContent)stream;
		}
	}
}
