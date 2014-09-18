using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace _12306_Helper
{
    [Serializable]
    public class ConfigInfoData//配置结构
    {
        public string
                username = "",
                password = "";
        public ConfigInfoData()
        {
            username = "";
            password = "";
        }
    }

    public static class ConfigInfo
    {
        public static ConfigInfoData conf = new ConfigInfoData();

        /// <summary>
        /// 保存到配置文件
        /// </summary>
        /// <returns>返回是否成功</returns>
        public static bool savetofile()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                using (Stream fs = new FileStream(path + "usr.cfg", FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, conf);
                }
            }
            catch
            {
            }
            return true;
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns>返回是否成功</returns>
        public static bool readfromfile()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                using (Stream fs = new FileStream(path + "usr.cfg", FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    conf = (ConfigInfoData)formatter.Deserialize(fs);
                }
            }
            catch
            {
            }
            return true;
        }
    }
}
