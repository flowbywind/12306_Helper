using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	using System.Xml;

	/// <summary>
	/// 
	/// </summary>
	public class ResponseXmlContent : ResponseStringContent
	{
		/// <summary>
		/// 创建 <see cref="ResponseXmlContent"/>  的新实例(HttpXmlResponse)
		/// </summary>
		public ResponseXmlContent(HttpContext context, HttpClient client)
			: base(context, client)
		{
			
		}

		/// <summary>
		/// 获得处理中发生的异常
		/// </summary>
		public Exception Exception { get; set; }

		/// <summary>
		/// 获得XML文档
		/// </summary>
		public XmlDocument XmlDocument { get; private set; }

		#region Overrides of HttpResponseContent

		/// <summary>
		/// 处理响应
		/// </summary>
		/// <param name="stream"></param>
		protected override void ProcessResponse(Stream stream)
		{
			base.ProcessResponse(stream);
			XmlDocument = new XmlDocument();
			try
			{
				XmlDocument.LoadXml(StringResult);
			}
			catch (Exception ex)
			{
				Exception = ex;
				XmlDocument = null;
			}
		}

		#endregion
	}
}
