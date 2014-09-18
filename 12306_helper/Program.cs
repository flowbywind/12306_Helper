using System;
using System.Windows.Forms;
using FSLib.App.SimpleUpdater;
using aNyoNe.GetInfoFrom12306;

namespace _12306_Helper
{
    static class Program
    {
        public static FSLib.Windows.Studio.StudioPackage studio = new FSLib.Windows.Studio.StudioPackage(51)
        {
            SoftwareWebKey = "12306",
            TencentMicroBlogUrl = "",
            SinaMicroBlockUrl = "",
            DonateUrl = "",
            AuthorName = "",
            FormImage = Properties.Resources._0,
            VersionLocation = new System.Drawing.Point(40, 150),
            VersionColor = System.Drawing.Color.White,
        };
        public static bool exceptionFlag=false;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Updater.CheckUpdateSimple();
            Application.ThreadException += (ss,ee) => {
                new LogInfo().WriteLine(String.Format("UnhandledException Catch:{0}\r\nSource:{1}\r\nException:{2}", ee.Exception.Message, ee.Exception.Source, ee.Exception));
            };
            studio.InitializeUrl();
            if (!System.Reflection.Assembly.GetExecutingAssembly().IsDebugAssembly())
            {
                studio.InitializeErrorReport();
            }

            DatasList.Init();
            Application.Run(new FormLogin());

        }
    }
}
