using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	using System.Net;
	using System.Text.RegularExpressions;

	/// <summary>
	/// 
	/// </summary>
	public class ResponseBinaryContent : HttpResponseContent
	{
		/// <summary>
		/// 创建 <see cref="ResponseBinaryContent"/>  的新实例(HttpBinaryResponse)
		/// </summary>
		public ResponseBinaryContent(HttpContext context, HttpClient client)
			: base(context, client)
		{

		}

		/// <summary>
		/// 获得结果
		/// </summary>
		public byte[] Result { get; private set; }

		#region Overrides of HttpResponseContent

		/// <summary>
		/// 处理响应
		/// </summary>
		/// <param name="stream"></param>
		protected override void ProcessResponse(Stream stream)
		{
			using (var ms = new System.IO.MemoryStream())
			{
				var buffer = new byte[4 * 0x400];
				var count = 0;
				while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
				{
					ms.Write(buffer, 0, count);
				}
				ms.Close();
				Result = ms.ToArray();
			}
		}

		#endregion

		static Regex _charsetSearch = new Regex("charset=([a-zA-Z0-9-]+)", RegexOptions.IgnoreCase);

		private string _stringResult;

		/// <summary>
		/// 获得字符串结果
		/// </summary>
		public string StringResult
		{
			get
			{
				if (_stringResult == null) _stringResult = GetDataString();
				return _stringResult;
			}
		}

		/// <summary>
		/// 获得结果的字符串表现形式
		/// </summary>
		/// <returns></returns>
		protected virtual string GetDataString()
		{
			Encoding defaultEncoding = null;
			var contentType = Context.Response.Headers[HttpResponseHeader.ContentType];
			var charset = contentType == null ? null : _charsetSearch.Match(contentType);
			if (charset != null && charset.Success)
			{
				defaultEncoding = System.Text.Encoding.GetEncoding(charset.Groups[1].Value);
			}
			else
			{
				var dataAsAscii = Encoding.ASCII.GetString(Result, 0, Math.Min(Result.Length, Context.Client.Setting.DecodeForSearchCharsetRange));
				//查找可能的编码
				charset = _charsetSearch.Match(dataAsAscii);
				if (charset.Success)
				{
					defaultEncoding = System.Text.Encoding.GetEncoding(charset.Groups[1].Value);
				}
			}

			defaultEncoding = defaultEncoding ?? Context.Request.Encoding ?? System.Text.Encoding.UTF8;
			return defaultEncoding.GetString(Result);
		}
	}
}
