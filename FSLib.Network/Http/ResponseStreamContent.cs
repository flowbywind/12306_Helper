namespace FSLib.Network.Http
{
	using System;
	using System.IO;
	using System.Linq;

	/// <summary>
	/// 一个响应流
	/// </summary>
	public class ResponseStreamContent : HttpResponseContent
	{
		/// <summary>
		/// 创建 <see cref="HttpResponseContent" />  的新实例(HttpResponseContent)
		/// </summary>
		public ResponseStreamContent(HttpContext context, HttpClient client)
			: base(context, client)
		{
		}

		/// <summary>
		/// 包含流处理请求的事件参数
		/// </summary>
		public class RequireProcessStreamEventArgs : EventArgs
		{
			/// <summary>
			/// 请求处理的流
			/// </summary>
			public Stream Stream { get; private set; }

			/// <summary>
			/// 创建 <see cref="RequireProcessStreamEventArgs" />  的新实例(RequireProcessStreamEventArgs)
			/// </summary>
			public RequireProcessStreamEventArgs(Stream stream)
			{
				Stream = stream;
			}
		}

		/// <summary>
		/// 请求处理流
		/// </summary>
		public event EventHandler<RequireProcessStreamEventArgs> RequireProcessStream;

		/// <summary>
		/// 引发 <see cref="RequireProcessStream" /> 事件
		/// </summary>
		/// <param name="ea">包含此事件的参数</param>
		protected virtual void OnRequireProcessStream(RequireProcessStreamEventArgs ea)
		{
			var handler = RequireProcessStream;
			if (handler != null)
				handler(this, ea);
		}

		#region Overrides of HttpResponseContent

		/// <summary>
		/// 处理响应
		/// </summary>
		/// <param name="stream"></param>
		protected override void ProcessResponse(Stream stream)
		{
			OnRequireProcessStream(new RequireProcessStreamEventArgs(stream));
		}

		#endregion
	}
}
