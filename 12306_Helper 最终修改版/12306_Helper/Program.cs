using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Security.Policy;
using System.Reflection;
using System.IO;
using FSLib.App.SimpleUpdater;
using PingMock;

namespace _12306_Helper
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Updater.CheckUpdateSimple();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (ss,ee) => {
                LogClass.WriteLogFile("UnhandledException Catch:" + ee.Exception.Message + "\r\nSource:" + ee.Exception.Source + "\r\nException:" + ee.Exception.ToString());
            };
            DatasList.Init();
            Application.Run(new formLogin());
        }
    }
}
