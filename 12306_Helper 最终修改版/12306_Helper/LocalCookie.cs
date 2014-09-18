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
                catch (Exception e)
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
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (CookieContainer)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
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
                catch (Exception e)
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
            catch (Exception e)
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
                catch (Exception e)
                {
                }
            }
        }

        public static ConfigList ReadConfigFromDisk_ConfigList(string file)
        {
            try
            {
                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(stream) as ConfigList;
                }
            }
            catch (Exception e)
            {
                return new ConfigList();
            }
        }
    }
}
