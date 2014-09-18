using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;

namespace FSLib.Network.Http
{
	/// <summary>
	/// 表单数据
	/// </summary>
	public class RequestFormDataContent : HttpRequestContent
	{
		/// <summary>
		/// 创建 <see cref="RequestFormDataContent" />  的新实例(RequestFormDataContent)
		/// </summary>
		public RequestFormDataContent()
		{
			StringField = new Dictionary<string, string>();
			PostedFile = new List<HttpPostFile>();
		}

		/// <summary>
		/// 创建 <see cref="RequestFormDataContent" />  的新实例(RequestFormDataContent)
		/// </summary>
		public RequestFormDataContent(IDictionary<string, string> stringField)
		{
			StringField = stringField;
			PostedFile = new List<HttpPostFile>();
		}

		/// <summary>
		/// 获得文本域
		/// </summary>
		public IDictionary<string, string> StringField { get; private set; }

		Dictionary<string, string> _processedData;

		/// <summary>
		/// 预处理数据
		/// </summary>
		protected virtual void PreProcessData()
		{
			_processedData = _processedData ?? StringField.ToDictionary(s => s.Key, s => System.Web.HttpUtility.UrlEncode(s.Value, Message.Encoding));
		}

		/// <summary>
		/// 获得附加的文件列表
		/// </summary>
		public List<HttpPostFile> PostedFile { get; private set; }

		#region Overrides of HttpRequestContent

		/// <summary>
		/// 将当前的内容序列化到查询中
		/// </summary>
		public override string SerializeAsQueryString()
		{
			if (PostedFile.Count > 0)
			{
				throw new InvalidOperationException("有文件附件时，不可以作为查询字符串，请使用POST查询。");
			}
			PreProcessData();
			return _processedData.Select(s => s.Key + "=" + s.Value).Join("&");
		}

		/// <summary>
		/// 写入内容到流中
		/// </summary>
		/// <param name="stream"></param>
		public override void WriteTo(Stream stream)
		{
			if (PostedFile.Count > 0)
			{
				//写入普通区域
				foreach (var v in _processedData)
				{
					var str = "--" + Context.Request.RequestBoundary + "\r\nContent-Disposition: form-data; name=\"" + v.Key + "\"\r\n\r\n";
					stream.Write(Context.Request.Encoding.GetBytes(str));
					stream.Write(Context.Request.Encoding.GetBytes(v.Value));
					stream.Write(Context.Request.Encoding.GetBytes("\r\n"));
				}

				//写入文件
				PostedFile.ForEach(s => s.WriteTo(stream));
				var endingstr = "--" + Context.Request.RequestBoundary + "--";
				stream.Write(Context.Request.Encoding.GetBytes(endingstr));
			}
			else
			{
				PreProcessData();
				stream.Write(System.Text.Encoding.ASCII.GetBytes(_processedData.Select(s=>s.Key+"="+s.Value).Join("&")));
			}
		}

		/// <summary>
		/// 计算长度
		/// </summary>
		/// <returns></returns>
		public override long ComputeLength()
		{
			if (PostedFile.Count != 0)
			{
				var boundary = "ifish_network_client_" + base.Message.RequestBoundary.DefaultForEmpty(Guid.NewGuid().ToString().Replace("-", ""));
				WebRequset.ContentType = "multipart/form-data; boundary=" + boundary;

				var size = StringField.Select(
					s =>
						(long)2	//--
						+ boundary.Length	//boundary
						+ 2	//\r\n
						+ 45	// content-disposition
						+ s.Key.Length	//key
						+ Message.Encoding.GetByteCount(s.Value)	//value
						+ 2	//\r\n
					).Sum();

				//attach file
				size += PostedFile.Sum(s => s.ComputeLength());
				size += 4 + boundary.Length;	//结束标记
				return size;
			}
			PreProcessData();
			return _processedData.Select(s => s.Key.Length + 1 + s.Value.Length).Sum() + _processedData.Count - 1;
		}

		#endregion
	}
}
