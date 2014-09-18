using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace _12306_Helper
{
    public static class LocalCookie
    {
        public static void WriteCookiesToDisk(string file, CookieContainer cookieJar)
        {
            using (Stream stream = File.Create(file))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, cookieJar);
                }
                catch
                {
                }
            }
        }

        public static CookieContainer ReadCookiesFromDisk(string file)
        {
            try
            {
                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    return (CookieContainer)formatter.Deserialize(stream);
                }
            }
            catch
            {
                return new CookieContainer();
            }
        }
        public static void WriteConfigToDisk(string file, Dictionary<string,object> cookieJar)
        {
            using (Stream stream = File.Create(file))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, cookieJar);
                }
                catch
                {
                }
            }
        }

        public static Dictionary<string, object> ReadConfigFromDisk(string file)
        {
            try
            {
                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (Dictionary<string, object>)formatter.Deserialize(stream);
                }
            }
            catch 
            {
                return new Dictionary<string, object>();
            }
        }
        public static void WriteConfigToDisk(string file, ConfigList cookieJar)
        {
            using (Stream stream = File.Create(file))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, cookieJar);
                }
                catch
                {
                }
            }
        }

        public static ConfigList ReadConfigFromDisk_Config(string file)
        {
            try
            {
                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(stream) as ConfigList;
                }
            }
            catch
            {
                return new ConfigList();
            }
        }

        public static void WriteConfigToDisk(string file, List<ConfigList> cookieJar)
        {
            DesCryption dc=new DesCryption();
            
            List<ConfigList> tmpList = new List<ConfigList>();
            foreach (ConfigList v in cookieJar)
            {
                ConfigList cl = v;
                System.Collections.Hashtable ht = new System.Collections.Hashtable();
                foreach (var x in v.Passengers.Keys)
                {
                    string tmp=x.ToString();
                    tmp = dc.EncryptString(x.ToString(), "A1B3C5D7");
                    aNyoNe.GetInfoFrom12306.Nomal_Passengers pd = new aNyoNe.GetInfoFrom12306.Nomal_Passengers();
                    pd = (aNyoNe.GetInfoFrom12306.Nomal_Passengers)(v.Passengers[x]);
                    pd.Passenger_id_no = dc.EncryptString(pd.Passenger_id_no, "A1B3C5D7");
                    pd.Passenger_name = dc.EncryptString(pd.Passenger_name, "A1B3C5D7");
                    ht.Add(tmp, pd);
                }
                cl.Passengers = ht;
                tmpList.Add(cl);
            }
            using (Stream stream = File.Create(file))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, tmpList);
                }
                catch
                {
                }
            }
        }

        public static List<ConfigList> ReadConfigFromDisk_ConfigList(string file)
        {
            try
            {
                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<ConfigList> lst=formatter.Deserialize(stream) as List<ConfigList>;

                    DesCryption dc = new DesCryption();

                    List<ConfigList> tmpList = new List<ConfigList>();
                    foreach (ConfigList v in lst)
                    {
                        ConfigList cl = v;
                        System.Collections.Hashtable ht = new System.Collections.Hashtable();
                        foreach (var x in v.Passengers.Keys)
                        {
                            string tmp = x.ToString();
                            tmp = dc.DecryptString(x.ToString(), "A1B3C5D7");
                            aNyoNe.GetInfoFrom12306.Nomal_Passengers pd = new aNyoNe.GetInfoFrom12306.Nomal_Passengers();
                            pd = (aNyoNe.GetInfoFrom12306.Nomal_Passengers)(v.Passengers[x]);
                            pd.Passenger_id_no = dc.DecryptString(pd.Passenger_id_no, "A1B3C5D7");
                            pd.Passenger_name = dc.DecryptString(pd.Passenger_name, "A1B3C5D7");
                            ht.Add(tmp, pd);
                        }
                        cl.Passengers = ht;
                        tmpList.Add(cl);
                    }

                    return tmpList;
                }
            }
            catch
            {
                return new List<ConfigList>();
            }
        }
    }
}
