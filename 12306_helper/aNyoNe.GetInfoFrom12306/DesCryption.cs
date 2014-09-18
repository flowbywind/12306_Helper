using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace aNyoNe.GetInfoFrom12306
{
    public class DesCryption
    {
        public DesCryption() { }
        /// <summary>
        ///  创建Key  
        /// </summary>
        /// <returns></returns>
        public string GenerateKey()
        {
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
            return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        }

        /// <summary>
        /// 处理自定义key
        /// </summary>
        /// <param name="skey">用户自定义key</param>
        /// <returns></returns>
        private string GenerateKey(string sKey)
        {
            string key = sKey;
            if (sKey.Length > 8)
                key = sKey.Substring(0, 8);
            else
            {
                for (int i = sKey.Length; i < 8; i++)
                {
                    key = key + "0";
                }
            }
            return key;
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="sInputString">需要加密的字符串</param>
        /// <param name="sKey">加密秘钥</param>
        /// <returns></returns>
        public string EncryptString(string sInputString, string sKey)
        {
            try
            {
                string key = GenerateKey(sKey);
                
                byte[] data = Encoding.UTF8.GetBytes(sInputString);
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(key);
                ICryptoTransform desencrypt = DES.CreateEncryptor();

                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                return BitConverter.ToString(result).Replace("-", "");
            }
            catch { return ""; }
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="sInputString">需要解密的key</param>
        /// <param name="sKey">解密秘钥</param>
        /// <returns></returns>
        public string DecryptString(string sInputString, string sKey)
        {
            //string[] sInput = sInputString.Split("-".ToCharArray());
            try
            {
                string key = GenerateKey(sKey);
                string[] sInput = new string[sInputString.Length >> 1];
                for (int i = 0; i < sInputString.Length; i = i + 2)
                {
                    sInput[i >> 1] = sInputString.Substring(i, 2);
                }
                byte[] data = new byte[sInput.Length];
                for (int i = 0; i < sInput.Length; i++)
                {
                    data[i] = byte.Parse(sInput[i], NumberStyles.HexNumber);
                }
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(key);
                ICryptoTransform desencrypt = DES.CreateDecryptor();
                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                return Encoding.UTF8.GetString(result);
            }
            catch { return ""; }
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="inputFileName">需要加密的文件</param>
        /// <param name="outFileName">加密后的文件</param>
        /// <param name="sKey">加密秘钥</param>
        /// <returns></returns>
        public bool EncryptFile(string inputFileName,string outFileName, string sKey)
        {
            try
            {
                string key = GenerateKey(sKey);
                FileStream fsInput = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
                FileStream fsEncrypted = new FileStream(outFileName, FileMode.Create, FileAccess.Write);
                
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(key);
                ICryptoTransform desencrypt = DES.CreateEncryptor();
                CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
                byte[] bytearrayinput = new byte[fsInput.Length];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Close();
                //cryptostream.Dispose();
                fsInput.Close();
                fsEncrypted.Close();
                fsEncrypted.Dispose();
                //fsInput.Dispose();
                return true;
            }
            catch { return false; }
        }
 
        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="sInputFilename">需要解密的文件</param>
        /// <param name="sOutputFilename">解密后的文件</param>
        /// <param name="sKey">解密秘钥</param>
        /// <returns></returns>
        public bool DecryptFile(string sInputFilename, string sOutputFilename, string sKey)
        {
            try
            {
                string key = GenerateKey(sKey);
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                //A 64 bit key and IV is required for this provider.
                //Set secret key For DES algorithm.
                DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                //Set initialization vector.
                DES.IV = ASCIIEncoding.ASCII.GetBytes(key);

                //Create a file stream to read the encrypted file back.
                FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
                //Create a DES decryptor from the DES instance.
                ICryptoTransform desdecrypt = DES.CreateDecryptor();
                //Create crypto stream set to read and do a 
                //DES decryption transform on incoming bytes.
                CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);
                //Print the contents of the decrypted file.
                StreamWriter fsDecrypted = new StreamWriter(sOutputFilename,false,Encoding.UTF8);
                fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
                cryptostreamDecr.Close();
                //cryptostreamDecr.Dispose();
                fsDecrypted.Flush();
                fsDecrypted.Close();
                fsread.Close();
                //fsDecrypted.Dispose();
                fsread.Dispose();
                return true;
            }
            catch { return false; }
        }
    }
}
