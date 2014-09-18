using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLib.Network.Http
{
	/// <summary>
	/// 表示对象是表单对象
	/// </summary>
	public interface IFormData
	{
		/// <summary>
		/// 获得所有的域
		/// </summary>
		/// <returns></returns>
		IEnumerable<KeyValuePair<string, string>> GetAllFields();
	}
}
