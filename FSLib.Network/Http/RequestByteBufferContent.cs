using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	public class RequestByteBufferContent : HttpRequestContent
	{
		public override void WriteTo(System.IO.Stream stream)
		{
			stream.Write(Buffer, 0, Length);
		}

		/// <summary>
		/// 计算长度
		/// </summary>
		/// <returns></returns>
		public override long ComputeLength()
		{
			return Length;
		}

		/// <summary>
		/// 获得或设置缓冲内容
		/// </summary>
		public byte[] Buffer { get; set; }

		/// <summary>
		/// 获得或设置索引
		/// </summary>
		public int Offset { get; set; }

		/// <summary>
		/// 获得或设置长度
		/// </summary>
		public int Length { get; set; }

		/// <summary>
		/// 创建 <see cref="ByteBufferContent" />  的新实例(ByteBufferContent)
		/// </summary>
		public RequestByteBufferContent(byte[] buffer, int? offset = null, int? length = null)
		{
			if (buffer == null)
				throw new ArgumentException("buffer is null or empty.", "buffer");

			Buffer = buffer;
			Offset = offset ?? 0;
			Length = length ?? buffer.Length;
		}

		public static implicit operator byte[](RequestByteBufferContent content)
		{
			return content.Buffer;
		}

		public static implicit operator RequestByteBufferContent(byte[] buffer)
		{
			return new RequestByteBufferContent(buffer);
		}
	}
}
