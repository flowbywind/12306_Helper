using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	using System.IO;

	/// <summary>
	/// 表示提交一个字符串的请求内容
	/// </summary>
	public class RequestStringContent : HttpRequestContent
	{
		#region Overrides of HttpRequestContent

		/// <summary>
		/// 写入内容到流中
		/// </summary>
		/// <param name="stream"></param>
		public override void WriteTo(Stream stream)
		{
			var buffer = (Message.Encoding ?? Encoding.UTF8).GetBytes(Content ?? "");
			stream.Write(buffer, 0, buffer.Length);
		}

		/// <summary>
		/// 计算长度
		/// </summary>
		/// <returns></returns>
		public override long ComputeLength()
		{
			return (Message.Encoding ?? Encoding.UTF8).GetByteCount(Content);
		}

		#endregion

		/// <summary>
		/// 获得或设置要写入的内容
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// 创建 <see cref="RequestStringContent" />  的新实例(StringContent)
		/// </summary>
		public RequestStringContent(string content)
		{
			Content = content;
		}

		public static implicit operator string(RequestStringContent content)
		{
			return content.Content;
		}

		public static implicit operator RequestStringContent(string content)
		{
			return new RequestStringContent(content);
		}

	}
}
