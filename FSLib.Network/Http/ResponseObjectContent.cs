using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	/// <summary>
	/// 反序列化结果
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ResponseObjectContent<T> : ResponseBinaryContent
	{
		/// <summary>
		/// 创建 <see cref="ResponseObjectContent{T}"/>  的新实例(HttpObjectResponseContent)
		/// </summary>
		public ResponseObjectContent(HttpContext context, HttpClient client)
			: base(context, client)
		{

		}

		/// <summary>
		/// 获得反序列化的结果
		/// </summary>
		public T Object { get; private set; }

		/// <summary>
		/// 获得处理过程中的异常
		/// </summary>
		public Exception Exception { get; private set; }

		#region Overrides of HttpResponseContent

		/// <summary>
		/// 处理响应
		/// </summary>
		/// <param name="stream"></param>
		protected override void ProcessResponse(Stream stream)
		{
			base.ProcessResponse(stream);

			//查找开始标记
			var index = 0;
			while ((index < Result.Length && (Result[index] == ' ' || Result[index] == '\t')))
			{
				index++;
			}

			try
			{
				if (Result[index] == '<')
				{
					//XML反序列化
					Object = (T)typeof(T).XmlDeserialize(StringResult);
				}
				else if (Result[index] == '{' || Result[index] == '[')
				{
					//JSON反序列化
					Object = (T)Newtonsoft.Json.JsonConvert.DeserializeObject<T>(StringResult);
				}
				else
				{
					//二进制序列化
					Object = (T)System.FSLib_Net_GeneralExtensionMethods.DeserialzieFromBytes(Result);
				}
			}
			catch (Exception ex)
			{
				Exception = ex;
				Object = default(T);
			}
		}

		#endregion
	}
}
