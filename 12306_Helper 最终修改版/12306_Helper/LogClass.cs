using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _12306_Helper
{
    public static class LogClass
    {

         /**//// <summary>
         /// 写入日志文件
         /// </summary>
         /// <param name="input"></param>
        public static void WriteLogFile(string input)
         {
             try
             {
                 /**/
                 ///指定日志文件的目录
                 string fname = Directory.GetCurrentDirectory() + "\\logfile.txt";
                 /**/
                 ///定义文件信息对象

                 FileInfo finfo = new FileInfo(fname);

                 if (!finfo.Exists)
                 {
                     FileStream fs;
                     fs = File.Create(fname);
                     fs.Close();
                     finfo = new FileInfo(fname);
                 }

                 /**/
                 ///判断文件是否存在以及是否大于2K
                 if (finfo.Length > 2048)
                 {
                     /**/
                     ///删除该文件
                     finfo.Delete();
                 }
                 //finfo.AppendText();
                 /**/
                 ///创建只写文件流
                 using (FileStream fs = finfo.OpenWrite())
                 {
                     /**/
                     ///根据上面创建的文件流创建写数据流
                     StreamWriter w = new StreamWriter(fs);

                     /**/
                     ///设置写数据流的起始位置为文件流的末尾
                     w.BaseStream.Seek(0, SeekOrigin.End);

                     /**/
                     ///写入“Log Entry : ”
                     w.Write("\r\nLog Entry : ");

                     /**/
                     ///写入当前系统时间并换行
                     w.Write("{0} {1} \r\n", DateTime.Now.ToLongTimeString(),
                         DateTime.Now.ToLongDateString());

                     /**/
                     ///写入日志内容并换行
                     w.Write(input + "\r\n");

                     /**/
                     ///写入“并换行
                     w.Write("\r\n\r\n");

                     /**/
                     ///清空缓冲区内容，并把缓冲区内容写入基础流
                     w.Flush();

                     /**/
                     ///关闭写数据流
                     w.Close();
                 }
             }
             catch { }
        }
    }
}
