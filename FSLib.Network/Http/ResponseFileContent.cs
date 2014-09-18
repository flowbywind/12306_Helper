using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	/// <summary>
	/// 保存为文件的响应
	/// </summary>
	public class ResponseFileContent : HttpResponseContent
	{
		/// <summary>
		/// 获得或设置要保存到的文件
		/// </summary>
		public string FilePath { get; set; }

		/// <summary>
		/// 创建 <see cref="HttpResponseContent" />  的新实例(HttpResponseContent)
		/// </summary>
		internal ResponseFileContent(HttpContext context, HttpClient client, string filePath)
			: base(context, client)
		{
			FilePath = filePath;
		}

		#region Overrides of HttpResponseContent

		/// <summary>
		/// 处理响应
		/// </summary>
		/// <param name="stream"></param>
		protected override void ProcessResponse(Stream stream)
		{
			System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(FilePath));
			using (var fs = new System.IO.FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				var buffer = new byte[0x400 * 4];
				var count = 0;
				while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
				{
					fs.Write(buffer, 0, count);
				}
				fs.Close();
			}
		}

		#endregion
	}
}
