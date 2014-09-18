using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

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
        //public static Hashtable usrConfig = new Hashtable();
        /// <summary>
        /// 保存到配置文件
        /// </summary>
        /// <returns>返回是否成功</returns>
        public static bool savetofile(string username)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "data\\"+username+"\\";
                using (Stream fs = new FileStream(path + "usr.cfg", FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(fs, conf);
                }
                //using (Stream fs = new FileStream(path + "usrList.cfg", FileMode.OpenOrCreate))
                //{
                //    BinaryFormatter formatter = new BinaryFormatter();
                //    formatter.Serialize(fs, usrConfig);
                //}
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
        public static bool readfromfile(string username)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "data\\" + username + "\\";
                using (Stream fs = new FileStream(path + "usr.cfg", FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    conf = (ConfigInfoData)formatter.Deserialize(fs);
                }
                //using (Stream fs = new FileStream(path + "usrList.cfg", FileMode.OpenOrCreate))
                //{
                //    BinaryFormatter formatter = new BinaryFormatter();
                //    usrConfig = (Hashtable)formatter.Deserialize(fs);
                //}
            }
            catch
            {
            }
            return true;
        }
    }
}
