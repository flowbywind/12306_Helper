using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	/// <summary>
	/// 表示一个内存数据的虚拟上传文件
	/// </summary>
	public class HttpVirtualBytePostFile : HttpPostFile
	{
		/// <summary>
		/// 获得或设置文件内容
		/// </summary>
		public virtual byte[] Data { get; set; }

		/// <summary>
		/// 创建 <see cref="HttpPostFile" />  的新实例(HttpPostFile)
		/// </summary>
		public HttpVirtualBytePostFile(string fieldName, string filePath, byte[] data)
			: base(fieldName, filePath)
		{
			Data = data;
		}

		/// <summary>
		/// 计算数据区长度
		/// </summary>
		/// <returns></returns>
		protected override long ComputeBodyLength()
		{
			return Data.Length + 2;
		}

		/// <summary>
		/// 写入数据区
		/// </summary>
		/// <param name="stream"></param>
		protected override void WriteBody(System.IO.Stream stream)
		{
			using (var ms = new System.IO.MemoryStream(Data))
			{
				CopyStream(ms, stream, Data.Length);
				ms.Close();
			}
		}

	}
}
