using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace aNyoNe.GetInfoFrom12306
{
    /// <summary>
    /// 日志记录接口
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 日志文件大小 (LogInfo)
        /// </summary>
        int FileSize { get; set; }

        /// <summary>   
        /// 日志文件的路径 (LogInfo)
        /// </summary> 
        string LogFilePath { get; set; }

        /// <summary>
        /// 日志文件的名称 (LogInfo)
        /// </summary>   
        string LogFileName { get; set; }

        /// <summary>
        /// 记录日志 (LogInfo)
        /// </summary>
        /// <param name="message">日志内容</param>   
        void WriteLine(string message);

        /// <summary>
        /// 记录线程n的日志 (LogInfo)   
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="n">线程ID</param>
        void WriteLine(string message, int n);

        /// <summary>
        /// 记录子线程日志 (LogInfo)
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="mainSn">主线程ID</param>
        /// <param name="subSn">子线程ID</param>
        void WriteLine(string message, int mainSn, int subSn);
    }

    /// <summary>
    ///  日志记录
    /// </summary>
    public class LogInfo : ILog
    {
        //public static FSLib.Windows.Studio.StudioPackage studio;
        /// <summary>
        /// 日志文件大小
        /// </summary>
        private int _fileSize;

        /// <summary>
        /// 日志文件的路径
        /// </summary>
        private string _logFilePath;

        /// <summary>
        /// 日志文件的名称
        /// </summary>
        private string _logFileName;

        /// <summary>
        /// 所在驱动器的名称
        /// </summary>
        private String logDriver;

        /// <summary>
        /// 程序启动目录
        /// </summary>
        private String appDirectory = Application.StartupPath;

        /// <summary>
        /// 默认构造函数,初始化日志文件大小[2M]
        /// </summary>
        public LogInfo()
        {
            //初始化大于2M日志文件将自动删除;
            this._fileSize = 2048 * 1024;//2M
            //默认路径
            this._logFilePath = appDirectory + "\\logs\\";
            this._logFileName = "log";
            this.logDriver = Directory.GetDirectoryRoot(this._logFilePath);
        }

        /// <summary>
        /// 一个参数构造方法。参数用以初始化日志文件（部分）名称
        /// </summary>
        /// <param name="name">日志文件（部分）名称</param>
        public LogInfo(string name)
        {
            this._fileSize = 2048 * 1024;
            this._logFilePath = appDirectory + "\\logs\\";
            this._logFileName = name;
            this.logDriver = Directory.GetDirectoryRoot(this._logFilePath);
        }

        /// <summary>
        /// 两个参数构造方法。分别初始化日志文件（部分）名称和日志路径
        /// </summary>
        /// <param name="name">日志文件（部分）名称</param>
        /// <param name="direct">日志文件相对路径</param>
        public LogInfo(string name, string directory)
        {
            this._fileSize = 2048 * 1024;
            this._logFilePath = appDirectory + "\\logs\\" + directory + "\\";
            this._logFileName = name;
            this.logDriver = Directory.GetDirectoryRoot(this._logFilePath);
        }

        /// <summary>
        /// 获取或设置日志文件的大小
        /// </summary>
        public int FileSize
        {
            set
            {
                _fileSize = value;
            }
            get
            {
                return _fileSize;
            }
        }

        /// <summary>
        /// 获取或设置日志文件的路径
        /// </summary>
        public string LogFilePath
        {
            set
            {
                this._logFilePath = value;
            }
            get
            {
                return this._logFilePath;
            }
        }

        /// <summary>
        /// 获取或设置日志文件的名称
        /// </summary>
        public string LogFileName
        {
            set
            {
                this._logFileName = value;
            }
            get
            {
                return this._logFileName;
            }
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message">日志内容</param>
        public void WriteLine(string message)
        {
            this.WriteLog(this._logFileName, message);

        }

        //public void UploadException()
        //{

        //}

        /// <summary>
        /// 记录并打印日志（用以Console程序）
        /// </summary>
        /// <param name="message">日志内容</param>
        public void WriteConsoleAndLog(string message)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + message);
            this.WriteLog(this._logFileName, message);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="message">记录信息</param>
        private void WriteLog(string fileName, string message)
        {
            bool t = LogInfo.HaveAvailableFreeSpace(logDriver, 100 * this._fileSize);
            if (!t)
            {
                //如果当前驱动器空间不够，删除最早的文件夹
                LogInfo.DeleteFileDirectoryByCreateTime(this._logFilePath, 10);
            }

            //如果日志文件目录不存在,则创建
            DateTime dt = DateTime.Now;
            string sCurDate = dt.ToString("yyyy年MM月dd日");
            string sCurTime = dt.ToString("HH时mm分");
            string trueFilePath = this._logFilePath + sCurDate + "\\";
            if (!Directory.Exists(trueFilePath))
            {
                Directory.CreateDirectory(trueFilePath);
            }
            int i = 1;
            string trueLogFileName = fileName + "_" + sCurTime + "_" + i + ".log";
            FileInfo finfo = new FileInfo(trueFilePath + trueLogFileName);

            while (1 == 1)
            {
                if (!finfo.Exists || finfo.Length < _fileSize)
                {
                    break;
                }
                i++;
                trueLogFileName = fileName + "_" + sCurTime + "_" + i + ".log";
                finfo = new FileInfo(trueFilePath + trueLogFileName);
            }

            try
            {
                using (FileStream fs = new FileStream(trueFilePath + trueLogFileName, FileMode.Append))
                {
                    StreamWriter strwriter = new StreamWriter(fs);

                    if (String.IsNullOrEmpty(this.logDriver))
                    {
                        this.logDriver = Directory.GetDirectoryRoot(this._logFilePath);
                    }

                    try
                    {
                        DateTime d = DateTime.Now;
                        strwriter.WriteLine(d.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + message);
                        strwriter.Flush();
                    }
                    catch (IOException ee)
                    {
                        Console.WriteLine("日志文件写入失败信息:" + ee.ToString());

                        if (!LogInfo.HaveAvailableFreeSpace(this.logDriver, 200 * (long)this._fileSize))
                        {
                            LogInfo.DeleteFileDirectoryByCreateTime(this._logFilePath, 10);
                        }
                    }
                    finally
                    {
                        strwriter.Close();
                        //strwriter = null;
                    }
                }
            }
            catch (IOException ee)
            {
                Console.WriteLine("日志文件没有打开,详细信息如下:" + ee.ToString());
            }
        }

        /// <summary>
        /// 判断日志所在驱动器是否已满
        /// </summary>
        /// <param name="driverName">驱动器名称</param>
        /// <param name="size">文件大小</param>
        /// <returns>是否驱动器driverName有size大小剩余空间</returns>
        private static bool HaveAvailableFreeSpace(String driverName, long size)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.Name.Equals(driverName))
                {
                    if (d.IsReady == true)
                    {
                        if (d.AvailableFreeSpace <= size) return false;
                        else return true;
                    }
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// 按创建日期，删除最早的文件夹
        /// </summary>
        /// <param name="targetDirectory">目标文件夹</param>
        /// <param name="num">删除的文件夹数目</param>
        private static void DeleteFileDirectoryByCreateTime(String targetDirectory, int num)
        {
            if (Directory.Exists(targetDirectory))
            {
                try
                {
                    string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                    DateTime[] subdirectoryCreateTime = new DateTime[subdirectoryEntries.Length];
                    int i = 0;
                    foreach (string subdirectory in subdirectoryEntries)//初始化一个记录文件夹创建时间的数组
                    {
                        subdirectoryCreateTime[i] = Directory.GetCreationTime(subdirectory);
                        i++;
                    }
                    subdirectoryEntries = LogInfo.BubbleSort(subdirectoryEntries, subdirectoryCreateTime);
                    if (num >= subdirectoryEntries.Length) num = subdirectoryEntries.Length - 1;
                    for (i = 0; i < num; i++)
                    {
                        if (Directory.Exists(subdirectoryEntries[i]))
                        {
                            try
                            {
                                Directory.Delete(subdirectoryEntries[i], true);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("删除" + subdirectoryEntries[i] + "子目录出错—错误类型—" + e.GetType());
                                Console.WriteLine("删除" + subdirectoryEntries[i] + "子目录出错—错误信息—" + e.ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("获取" + targetDirectory + "子目录出错—错误类型—" + ex.GetType());
                    Console.WriteLine("获取" + targetDirectory + "子目录出错—错误信息—" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 将文件夹按照创建时间从小到大排序
        /// </summary>
        private static string[] BubbleSort(string[] arr1, DateTime[] arr2)
        {
            int j;
            string temp;
            DateTime tempdate;
            j = 1;
            while ((j < arr2.Length))
            {
                for (int i = 0; i < arr2.Length - j; i++)
                {
                    if (arr2[i].CompareTo(arr2[i + 1]) > 0)
                    {
                        tempdate = arr2[i];
                        arr2[i] = arr2[i + 1];
                        arr2[i + 1] = tempdate;
                        if (!string.IsNullOrEmpty(arr1[i]))
                        {
                            temp = arr1[i];
                            arr1[i] = arr1[i + 1];
                            arr1[i + 1] = temp;
                        }
                    }
                }
                j++;
            }
            return arr1;
        }

        public void WriteStringToTxt(string user, string filename, string json)
        {
            try
            {
                var dc = new DesCryption();
                if (!System.IO.Directory.Exists(System.Environment.CurrentDirectory + "\\data\\" + user + "\\"))
                {
                    System.IO.Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\data\\" + user + "\\");
                }
                System.IO.File.WriteAllText(System.Environment.CurrentDirectory + "\\data\\" + user + "\\" + filename + ".txt", dc.EncryptString(json,"A1B2C3D4"), System.Text.Encoding.UTF8);
            }
            catch { }
        }

        public string ReadStringFromTxt(string user, string filename)
        {
            try
            {
                var dc = new DesCryption();
                if (System.IO.Directory.Exists(System.Environment.CurrentDirectory + "\\data\\" + user + "\\"))
                {
                    string str = System.IO.File.ReadAllText(System.Environment.CurrentDirectory + "\\data\\" + user + "\\" + filename + ".txt", System.Text.Encoding.UTF8);
                    return dc.DecryptString(str,"A1B2C3D4");
                }
                else
                {
                    return "";
                }
            }
            catch { return ""; }
        }

        #region 多线程部分

        /// <summary>
        /// 记录线程n的日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="n">线程ID</param>
        public void WriteLine(string message, int n)
        {
            this.WriteLog(this._logFileName, message, n);
        }

        /// <summary>
        /// 记录子线程日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="mainSn">主线程ID</param>
        /// <param name="subSn">子线程ID</param>
        public void WriteLine(string message, int mainSn, int subSn)
        {
            this.WriteLog(this._logFileName, message, mainSn, subSn);
        }

        /// <summary>
        /// 记录线程n的日志
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="message">记录信息</param>   
        /// <param name="n">线程ID</param>
        private void WriteLog(string fileName, string message, int n)
        {
            bool t = LogInfo.HaveAvailableFreeSpace(logDriver, 100 * this._fileSize);
            if (!t)
            {
                LogInfo.DeleteFileDirectoryByCreateTime(this._logFilePath, 10);
            }
            DateTime dt = DateTime.Now;
            string sCurDate = dt.ToString("yyyy年MM月dd日");
            string sCurTime = dt.ToString("HH时mm分");
            string trueFilePath = this._logFilePath + sCurDate + "\\" + n.ToString() + "\\";
            if (!Directory.Exists(trueFilePath))
            {
                Directory.CreateDirectory(trueFilePath);
            }
            int i = 1;
            string trueLogFileName = fileName + "_" + sCurTime + "_" + i + ".log";
            FileInfo finfo = new FileInfo(trueFilePath + trueLogFileName);
            while (1 == 1)
            {
                if (!finfo.Exists || finfo.Length < _fileSize)
                {
                    break;
                }
                i++;
                trueLogFileName = fileName + "_" + sCurTime + "_" + i + ".log";
                finfo = new FileInfo(trueFilePath + trueLogFileName);
            }
            try
            {
                using (FileStream fs = new FileStream(trueFilePath + trueLogFileName, FileMode.Append))
                {
                    StreamWriter strwriter = new StreamWriter(fs);
                    if (String.IsNullOrEmpty(this.logDriver))
                    {
                        this.logDriver = Directory.GetDirectoryRoot(this._logFilePath);
                    }
                    try
                    {
                        DateTime d = DateTime.Now;
                        strwriter.WriteLine(d.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + message);
                        strwriter.Flush();
                    }
                    catch (IOException ee)
                    {
                        Console.WriteLine("日志文件写入失败信息:" + ee.ToString());
                        if (!LogInfo.HaveAvailableFreeSpace(this.logDriver, 200 * (long)this._fileSize))
                        {
                            LogInfo.DeleteFileDirectoryByCreateTime(this._logFilePath, 10);
                        }
                    }
                    finally
                    {
                        strwriter.Close();
                        //strwriter = null;
                    }
                }
            }
            catch (IOException ee)
            {
                Console.WriteLine("日志文件没有打开,详细信息如下:" + ee.ToString());
            }
        }

        /// <summary>
        /// 记录子线程日志
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="message">记录信息</param>
        /// <param name="mainSn">主线程ID</param>
        /// <param name="subSn">子线程ID</param>
        private void WriteLog(string fileName, string message, int mainSn, int subSn)
        {
            bool t = LogInfo.HaveAvailableFreeSpace(logDriver, 100 * this._fileSize);
            if (!t)
            {
                LogInfo.DeleteFileDirectoryByCreateTime(this._logFilePath, 10);
            }
            DateTime dt = DateTime.Now;
            string sCurDate = dt.ToString("yyyy年MM月dd日");
            string sCurTime = dt.ToString("HH时mm分");
            string trueFilePath = this._logFilePath + "\\" + sCurDate + "\\" + mainSn.ToString() + "\\" + subSn.ToString() + "\\";
            if (!Directory.Exists(trueFilePath))
            {
                Directory.CreateDirectory(trueFilePath);
            }
            int i = 1;
            string trueLogFileName = fileName + "_" + sCurTime + "_" + i + ".log";
            FileInfo finfo = new FileInfo(trueFilePath + trueLogFileName);
            while (1 == 1)
            {
                if (!finfo.Exists || finfo.Length < _fileSize)
                {
                    break;
                }
                i++;
                trueLogFileName = fileName + "_" + sCurTime + "_" + i + ".log";
                finfo = new FileInfo(trueFilePath + trueLogFileName);
            }
            try
            {
                using (FileStream fs = new FileStream(trueFilePath + trueLogFileName, FileMode.Append))
                {
                    StreamWriter strwriter = new StreamWriter(fs);
                    if (String.IsNullOrEmpty(this.logDriver))
                    {
                        this.logDriver = Directory.GetDirectoryRoot(this._logFilePath);
                    }
                    try
                    {
                        DateTime d = DateTime.Now;
                        strwriter.WriteLine(d.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + message);
                        strwriter.Flush();
                    }
                    catch (IOException ee)
                    {
                        Console.WriteLine("日志文件写入失败信息:" + ee.ToString());
                        if (!LogInfo.HaveAvailableFreeSpace(this.logDriver, 200 * (long)this._fileSize))
                        {
                            LogInfo.DeleteFileDirectoryByCreateTime(this._logFilePath, 10);
                        }
                    }
                    finally
                    {
                        strwriter.Close();
                        //strwriter = null;
                    }
                }
            }
            catch (IOException ee)
            {
                Console.WriteLine("日志文件没有打开,详细信息如下:" + ee.ToString());
            }
        }

        #endregion 多线程部分
    }
}