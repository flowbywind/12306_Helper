using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	using System.Drawing;

	/// <summary>
	/// 
	/// </summary>
	public class ResponseImageContent : ResponseBinaryContent
	{
		/// <summary>
		/// 创建 <see cref="ResponseImageContent"/>  的新实例(HttpImageResponse)
		/// </summary>
		public ResponseImageContent(HttpContext context, HttpClient client)
			: base(context, client)
		{

		}

		/// <summary>
		/// 获得创建的图像
		/// </summary>
		public Image Image { get; private set; }

		/// <summary>
		/// 获得处理中发生的异常
		/// </summary>
		public Exception Exception { get; set; }

		#region Overrides of HttpResponseContent

		/// <summary>
		/// 处理响应
		/// </summary>
		/// <param name="stream"></param>
		protected override void ProcessResponse(Stream stream)
		{
			base.ProcessResponse(stream);
			using (var ms = new MemoryStream(Result))
			{
				try
				{
					Image = Image.FromStream(ms);
				}
				catch (Exception ex)
				{
					Exception = ex;
					Image = null;
				}
			}
		}

		#endregion
	}
}
