using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	using System.IO;

	/// <summary>
	/// 表示一个上传文件
	/// </summary>
	public class HttpPostFile
	{
		/// <summary>
		/// 创建 <see cref="HttpPostFile" />  的新实例(HttpPostFile)
		/// </summary>
		public HttpPostFile(string fieldName, string filePath)
		{
			FieldName = fieldName;
			FilePath = filePath;
		}

		/// <summary>
		/// 获得或设置表单名
		/// </summary>

		public string FieldName { get; set; }

		/// <summary>
		/// 文件信息
		/// </summary>
		public string FilePath { get; set; }

		/// <summary>
		/// 获得上下文环境
		/// </summary>
		public HttpContext Context { get; private set; }

		/// <summary>
		/// 绑定上下文
		/// </summary>
		/// <param name="context"></param>
		public virtual void AttachContext(HttpContext context)
		{
			Context = context;
		}

		/// <summary>
		/// 写入指定的流
		/// </summary>
		/// <param name="stream"></param>
		public virtual void WriteTo(System.IO.Stream stream)
		{
			WriteHeader(stream);
			WriteBody(stream);
		}

		/// <summary>
		/// 写入头信息
		/// </summary>
		/// <param name="stream"></param>
		protected virtual void WriteHeader(System.IO.Stream stream)
		{
			var str = "--" + Context.Request.RequestBoundary + "\r\nContent-Disposition: form-data; name=\"" + FieldName + "\"; filename=\"" + FilePath + "\"\r\nContent-Type: application/octet-stream\r\n\r\n";
			stream.Write(Context.Request.Encoding.GetBytes(str));
			stream.Write(System.Text.Encoding.ASCII.GetBytes("\r\n"));
		}

		/// <summary>
		/// 写入数据区
		/// </summary>
		/// <param name="stream"></param>
		protected virtual void WriteBody(System.IO.Stream stream)
		{
			using (var fs = FileInfo.OpenRead())
			{
				CopyStream(fs, stream);
				fs.Close();
			}
		}

		/// <summary>
		/// 复制流
		/// </summary>
		/// <param name="src"></param>
		/// <param name="dest"></param>
		/// <param name="length"></param>
		protected virtual void CopyStream(System.IO.Stream src, System.IO.Stream dest, long length = 0)
		{
			var buffer = new byte[0x400 * 4];
			var count = 0;
			var pos = 0L;

			if (src.CanSeek) src.Seek(0L, SeekOrigin.Begin);
			if (length == 0)
			{
				if (!src.CanSeek) throw new InvalidOperationException("不支持检索长度的流，请设置长度参数");
				else length = src.Length;
			}

			var ee = new DataProgressEventArgs(length, 0L);
			Context.Operation.Post(_ => OnProgressChanged(ee), null);

			while ((count = src.Read(buffer, 0, buffer.Length)) > 0)
			{
				dest.Write(buffer, 0, count);
				pos += count;
				ee = new DataProgressEventArgs(length, pos);
				Context.Operation.Post(_ => OnProgressChanged(ee), null);
			}
		}


		/// <summary>
		/// 获得或设置文件信息
		/// </summary>
		public FileInfo FileInfo { get; set; }

		/// <summary>
		/// 计算长度(含开始信息)
		/// </summary>
		/// <returns></returns>
		public virtual long ComputeLength()
		{
			return ComputeHeaderLength() + ComputeBodyLength();
		}

		/// <summary>
		/// 计算开始信息长度
		/// </summary>
		/// <returns></returns>
		protected virtual long ComputeHeaderLength()
		{
			//计算头
			return (long)2	//--
						+ Context.Request.RequestBoundary.Length	//boundary
						+ 2	//\r\n
						+ 54	// content-disposition
						+ FieldName.Length	//key
						+ Context.Request.Encoding.GetByteCount(FilePath)	//file name
						+ 42	//content-type \r\n \r\n
						;
		}

		/// <summary>
		/// 计算数据区长度
		/// </summary>
		/// <returns></returns>
		protected virtual long ComputeBodyLength()
		{
			FileInfo = new FileInfo(FilePath);
			return FileInfo.Length + 2;
		}

		/// <summary>
		/// 数据写入进度变化
		/// </summary>
		public event EventHandler<DataProgressEventArgs> ProgressChanged;


		/// <summary>
		/// 引发 <see cref="ProgressChanged" /> 事件
		/// </summary>
		/// <param name="ea">包含此事件的参数</param>
		protected virtual void OnProgressChanged(DataProgressEventArgs ea)
		{
			var handler = ProgressChanged;
			if (handler != null)
				handler(this, ea);
		}
	}
}
