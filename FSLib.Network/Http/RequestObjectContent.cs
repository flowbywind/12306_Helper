using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	using System.ComponentModel;
	using System.Reflection;

	/// <summary>
	/// 表示一个对象
	/// </summary>
	public class RequestObjectContent<T> : RequestFormDataContent where T : class
	{
		/// <summary>
		/// 获得要上传的对象
		/// </summary>
		public T Object { get; private set; }

		/// <summary>
		/// 创建 <see>
		///     <cref>RequestObjectContent</cref>
		/// </see>
		///     的新实例(RequestObjectContent)
		/// </summary>
		public RequestObjectContent(T objectVar)
		{
			Object = objectVar;
		}

		bool _dataBinded;

		protected override void PreProcessData()
		{
			if (!_dataBinded)
			{
				_dataBinded = true;
				BindObject(Object);
			}
			base.PreProcessData();
		}

		/// <summary>
		/// 绑定对象数据
		/// </summary>
		protected void BindObject(Object obj, string prefix = "")
		{
			if (obj is IFormData)
			{
				((IFormData)obj).GetAllFields().ForEach(s => StringField.Add(s.Key, s.Value));
			}
			else if (obj is System.Collections.Specialized.NameValueCollection)
			{
				var nvc = (System.Collections.Specialized.NameValueCollection)obj;
				nvc.AllKeys.ForEach(s => StringField.Add(s, nvc[s]));
			}
			else if (obj is Dictionary<string, string>)
			{
				var nvc = (Dictionary<string, string>)obj;
				nvc.ForEach(s => StringField.Add(s.Key, s.Value));
			}
			else if (obj is string[][])
			{
				var zigzagArray = (string[][])obj;
				foreach (var item in zigzagArray)
				{
					StringField.Add(item[0], item[1]);
				}
			}
			else if (obj is string[,])
			{
				var multiArray = (string[,])obj;
				for (int i = 0; i <= multiArray.GetUpperBound(0); i++)
				{
					StringField.Add(multiArray[i, 0], multiArray[i, 1]);
				}
			}
			else
			{
				var props = TypeDescriptor.GetProperties(obj).Cast<PropertyDescriptor>();
				foreach (var pd in props)
				{
					if (pd.Attributes.OfType<IgnoreFieldAttribute>().Any()) continue;

					var fn = pd.Attributes.OfType<FormNameAttribute>().FirstOrDefault();
					var fp = pd.Attributes.OfType<AttachedFileAttribute>().FirstOrDefault();

					var key = prefix + (fn == null ? pd.Name : fn.Name);
					if (fp != null)
					{
						if (pd.PropertyType == typeof(string))
						{
							var path = (pd.GetValue(obj) ?? "").ToString();
							if (path.IsNullOrEmpty()) continue;

							PostedFile.Add(new HttpPostFile(key, path));
						}
						else
							throw new InvalidOperationException("附加上传文件的属性属性只能是字符串");
						continue;
					}
					var v = pd.GetValue(obj);
					if (v == null) continue;

					//序列化
					var satt = pd.Attributes.OfType<ObjectSerializeAttribute>().FirstOrDefault();
					if (satt != null)
					{
						switch (satt.SerializeType)
						{
							case ObjectSerializationType.Xml:
								StringField.Add(key, v.XmlSerializeToString());
								break;
							case ObjectSerializationType.Json:
								StringField.Add(key, Newtonsoft.Json.JsonConvert.SerializeObject(v));
								break;
						}
						continue;
					}

					if (pd.PropertyType == typeof(string) || pd.PropertyType.IsValueType)
					{
						StringField.Add(key, v.ToString());
					}
					else
					{
						BindObject(v, key + ".");
					}
				}
			}
		}
	}
}
