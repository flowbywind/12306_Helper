using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	using System.IO;

	public class HttpVirtualStreamPostFile : HttpPostFile
	{
		/// <summary>
		/// 获得或设置文件内容
		/// </summary>
		public virtual Stream Stream { get; set; }

		/// <summary>
		/// 创建 <see cref="HttpPostFile" />  的新实例(HttpPostFile)
		/// </summary>
		public HttpVirtualStreamPostFile(string fieldName, string filePath, Stream stream)
			: base(fieldName, filePath)
		{
			if (String.IsNullOrEmpty(fieldName))
				throw new ArgumentException("fieldName is null or empty.", "fieldName");
			if (String.IsNullOrEmpty(filePath))
				throw new ArgumentException("filePath is null or empty.", "filePath");
			if (stream == null)
				throw new ArgumentNullException("stream", "stream is null.");
			if (!stream.CanSeek || !stream.CanRead) throw new InvalidOperationException();

			Stream = stream;
		}

		/// <summary>
		/// 计算数据区长度
		/// </summary>
		/// <returns></returns>
		protected override long ComputeBodyLength()
		{
			return Stream.Length + 2;
		}

		/// <summary>
		/// 写入数据区
		/// </summary>
		/// <param name="stream"></param>
		protected override void WriteBody(System.IO.Stream stream)
		{
			CopyStream(Stream, stream);
		}
	}
}
