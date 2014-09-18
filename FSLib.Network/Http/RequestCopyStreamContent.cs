using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	using System.IO;

	/// <summary>
	/// 表示向当前HTTP请求的一个写入流内容
	/// </summary>
	public class RequestCopyStreamContent:HttpRequestContent
	{
		/// <summary>
		/// 获得或设置文件内容
		/// </summary>
		public virtual Stream Stream { get; set; }

		/// <summary>
		/// 创建 <see cref="HttpPostFile" />  的新实例(HttpPostFile)
		/// </summary>
		public RequestCopyStreamContent(Stream stream)
		{
			if (stream == null)
				throw new ArgumentNullException("stream", "stream is null.");
			if (!stream.CanSeek || !stream.CanRead) throw new InvalidOperationException();

			Stream = stream;
		}
		#region Overrides of HttpRequestContent

		/// <summary>
		/// 写入内容到流中
		/// </summary>
		/// <param name="stream"></param>
		public override void WriteTo(Stream stream)
		{
			var buffer = new byte[0x400 * 4];
			var count = 0;
			while ((count = Stream.Read(buffer, 0, buffer.Length)) > 0)
			{
				stream.Write(buffer, 0, count);
			}
		}

		/// <summary>
		/// 计算长度
		/// </summary>
		/// <returns></returns>
		public override long ComputeLength()
		{
			return Stream.Length;
		}

		#endregion

		/// <summary>
		/// 允许隐式转换为流
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static implicit operator System.IO.Stream(RequestCopyStreamContent obj)
		{
			return obj.Stream;
		}

		/// <summary>
		/// 允许隐式转换为流
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static implicit operator RequestCopyStreamContent(System.IO.Stream obj)
		{
			return new RequestCopyStreamContent(obj);
		}
	}
}
