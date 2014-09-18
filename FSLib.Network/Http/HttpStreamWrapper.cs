using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	/// <summary>
	/// HTTP数据流的封装
	/// </summary>
	internal class HttpStreamWrapper : System.IO.Stream
	{
		/// <summary>
		/// 获得原始流
		/// </summary>
		public Stream BaseStream { get; private set; }

		private long _position, _streamLength;

		/// <summary>
		/// 创建 <see cref="HttpResponseStreamWrapper" />  的新实例(HttpReponseStreamWrapper)
		/// </summary>
		public HttpStreamWrapper(Stream baseStream, long streamLength)
		{
			if (baseStream == null)
				throw new ArgumentNullException("baseStream", "baseStream is null.");

			BaseStream = baseStream;
			_streamLength = streamLength;
			_position = 0L;
		}

		#region Overrides of Stream

		public override void Flush()
		{
			throw new InvalidOperationException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new InvalidOperationException();
		}

		public override void SetLength(long value)
		{
			throw new InvalidOperationException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			var readCount = BaseStream.Read(buffer, 0, count);
			_position += readCount;
			OnProgressChanged(new DataProgressEventArgs(_position, _streamLength));
			return readCount;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			BaseStream.Write(buffer, 0, count);
			_position += count;
			OnProgressChanged(new DataProgressEventArgs(_position, _streamLength));
		}

		public override bool CanRead
		{
			get { return BaseStream.CanRead; }
		}

		public override bool CanSeek
		{
			get { return false; }
		}

		public override bool CanWrite
		{
			get { return BaseStream.CanWrite; }
		}

		public override long Length
		{
			get { return Length; }
		}

		public override long Position {
			get { return _position; }
			set { throw new InvalidOperationException(); }
		}

		#endregion

		/// <summary>
		/// 读取进度发生变化
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
