using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
	using ComponentModel;

	using IO;

	using Runtime.Serialization.Formatters.Binary;

	using Xml.Serialization;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class FSLib_Net_GeneralExtensionMethods
	{
		public static bool IsNullOrEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}

		public static void Write(this System.IO.Stream stream, byte[] buffer)
		{
			stream.Write(buffer, 0, buffer.Length);
		}

		public static long ToInt64(this string str)
		{
			long value;
			if (long.TryParse(str, out value)) return value;
			return 0L;
		}

		public static void ForEach<T>(this IEnumerable<T> src, Action<T> action)
		{
			foreach (var item in src)
			{
				action(item);
			}
		}
		public static object DeserialzieFromBytes(byte[] array)
		{
			object result = null;
			if (array == null || array.Length == 0)
				return result;

			using (var ms = new System.IO.MemoryStream())
			{
				ms.Write(array, 0, array.Length);
				ms.Seek(0, SeekOrigin.Begin);

				BinaryFormatter xso = new BinaryFormatter();
				result = xso.Deserialize(ms);
				ms.Close();
			}

			return result;
		}

		/// <summary>
		/// 从指定的字符串或文件中反序列化对象
		/// </summary>
		/// <param name="type">目标类型</param>
		/// <param name="content">文件路径或XML文本</param>
		/// <returns>反序列化的结果</returns>
		public static object XmlDeserialize(this Type type, string content)
		{
			content = content.Trim();

			if (String.IsNullOrEmpty(content))
				return null;
			using (var ms = new MemoryStream())
			{
				byte[] buffer = Text.Encoding.Unicode.GetBytes(content);
				ms.Write(buffer, 0, buffer.Length);
				ms.Seek(0, SeekOrigin.Begin);

				return ms.XmlDeserialize(type);
			}
		}
		/// <summary>
		/// 从流中反序列化出指定对象类型的对象
		/// </summary>
		/// <param name="objType">对象类型</param>
		/// <param name="stream">流对象</param>
		/// <returns>反序列结果</returns>
		public static object XmlDeserialize(this Stream stream, System.Type objType)
		{
			var xso = new XmlSerializer(objType);
			object res = xso.Deserialize(stream);

			return res;
		}

		public static string Join(this IEnumerable<string> src, string sep)
		{
			return string.Join(sep, src.ToArray());
		}

		public static TR SelectValue<TS, TR>(this TS obj, Func<TS, TR> selector) where TS : class
		{
			if (obj == null || selector == null) return default(TR);
			return selector(obj);
		}

		public static string DefaultForEmpty(this string org, string dv)
		{
			return org.IsNullOrEmpty() ? dv : org;
		}

		/// <summary>
		/// 序列化对象为文本
		/// </summary>
		/// <param name="objectToSerialize">要序列化的对象</param>
		/// <returns>保存信息的 <see cref="T:System.String"/></returns>
		public static string XmlSerializeToString(this object objectToSerialize)
		{
			if (objectToSerialize == null)
				return null;

			using (var ms = objectToSerialize.XmlSerializeToStream())
			{
				ms.Close();
				return Text.Encoding.UTF8.GetString(ms.ToArray());
			}
		}

		/// <summary>
		/// 序列化指定对象为一个内存流
		/// </summary>
		/// <param name="objectToSerialize">要序列化的对象</param>
		/// <returns>保存序列化信息的 <see cref="T:System.IO.MemoryStream"/></returns>
		public static MemoryStream XmlSerializeToStream(this object objectToSerialize)
		{
			MemoryStream result;
			if (objectToSerialize == null)
				return null;

			result = new MemoryStream();
			objectToSerialize.XmlSerializeToStream(result);

			return result;
		}

		/// <summary>
		/// 序列化指定对象到指定流中
		/// </summary>
		/// <param name="objectToSerialize">要序列化的对象</param>
		/// <param name="stream">目标流</param>
		public static void XmlSerializeToStream(this object objectToSerialize, Stream stream)
		{
			if (objectToSerialize == null || stream == null)
				return;

			var xso = new XmlSerializer(objectToSerialize.GetType());
			xso.Serialize(stream, objectToSerialize);
		}
	}
}

namespace System.Net
{
	using FSLib.Network.Http;

	using IO;

	using Runtime.Serialization.Formatters.Binary;

	using Text.RegularExpressions;

	/// <summary>
	/// 扩展方法
	/// </summary>
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public static class FSLib_Network_ExtensionMethods
	{
		#region WebException 扩展

		/// <summary>
		/// 判断当前的请求是不是 <see cref="HttpWebResponse"/>
		/// </summary>
		/// <param name="e">包含异常的事件数据</param>
		/// <returns>如果是 <see cref="HttpWebResponse"/> ，则返回 true</returns>
		public static bool IsHttpResponse(this WebException e)
		{
			return e.Response != null && e.Response is HttpWebResponse;
		}

		/// <summary>
		/// 获得 <see cref="WebException"/> 所对应的 <see cref="HttpWebResponse"/>
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public static HttpWebResponse AsHttpWebResponse(this WebException e)
		{
			if (!e.IsHttpResponse()) return null;
			else return e.Response as HttpWebResponse;
		}

		#endregion

		#region HttpWebResponse扩展

		/// <summary>
		/// 判断当前的 <see cref="HttpWebResponse"/> 是不是重定向的请求
		/// </summary>
		/// <param name="response"></param>
		/// <returns></returns>
		public static bool IsRedirectHttpWebResponse(this HttpWebResponse response)
		{
			return response.StatusCode == HttpStatusCode.Ambiguous || // 300 
					response.StatusCode == HttpStatusCode.Moved || // 301 
					response.StatusCode == HttpStatusCode.Redirect || // 302
					response.StatusCode == HttpStatusCode.RedirectMethod || // 303 
					response.StatusCode == HttpStatusCode.RedirectKeepVerb;// 307
		}


		#endregion

		#region 标头扩展

		/// <summary>
		/// 将字符串转换为对应的标头
		/// </summary>
		/// <param name="header">HTTP请求标头</param>
		/// <returns>对应的标头枚举</returns>
		public static HttpRequestHeader ToWebRequestHeader(this string header)
		{
			HttpRequestHeader headerID;
			if (!HttpSetting.WebRequestHeaderIDMap.TryGetValue(header, out headerID)) throw new ArgumentOutOfRangeException();
			else return headerID;
		}

		/// <summary>
		/// 将HTTP请求标头转为对应的字符串
		/// </summary>
		/// <param name="header">标头</param>
		/// <returns>对应的字符串</returns>
		public static string ToWebRequestHeaderString(this HttpRequestHeader header)
		{
			var index = (int)header;
			if (index >= HttpSetting.WebRequestHeaderIDList.Length) throw new ArgumentOutOfRangeException();

			return HttpSetting.WebRequestHeaderIDList[index];
		}

		#endregion	}

	}
}