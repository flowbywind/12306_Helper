#define CHECK
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Linq;
using aNyoNe.AutoServerSwitch;
using aNyoNe.GetInfoFrom12306;
using System.Threading;
using System;
using System.Text;
using PopupControl;
using System.Drawing.Drawing2D;
using _12306_Helper.Forms;

namespace _12306_Helper
{
    public partial class formSelectTicket : Form
    {
        #region       框架字段
        HostAction hostAction;
        public static bool hostEnable = true;
        public static bool switchisalive = true;
        public static int SafeTime = 1;
        public static formSelectTicket FormThis;
        bool isGetServerTime = false;
        TimeSpan ts = new TimeSpan();
        int tmpTimeCount = 0;
        SelectTicketAction selectAction = new SelectTicketAction();
        #endregion

        private string _userName = "";
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private CookieContainer cookieContainer;
        public CookieContainer ThisCookie
        { set { cookieContainer = value; } }

        ~formSelectTicket()
        {
            GC.Collect();
            GC.Collect();
        }
        public formSelectTicket(CookieContainer cookie)
        {
            InitializeComponent();
            cookieContainer = cookie;
            InitHostPath();
          
            FormThis = this;

            SafeTime = 1;//默认的订单提交安全期
            switchisalive = FormLogin.SwitchOpen;
          
        }

        private void InitHostPath()
        {
            try
            {
                hostAction = new HostAction(Environment.SystemDirectory + "\\drivers\\etc\\hosts");
            }
            catch
            {
                hostEnable = false;
            }
        }
       
        //初始化窗体
        private void formSelectTicket_Load(object sender, EventArgs e)
        {
            if (!hostEnable)
                tsbtnServerSwitch.Enabled = false;

            var ticketFrame = new TicketFrame();
            ticketFrame.Dock = DockStyle.Fill;
            ticketFrame.UserName = _userName;
            ticketFrame.Cookies = cookieContainer;
            ticketFrame.GetPassengersFromServer();

            var tp = new TabPage();
            tp.Text = "默认的查询页面";
            tp.Controls.Add(new TicketMain(cookieContainer, null,null,ticketFrame) { Dock = DockStyle.Fill, UserName = _userName});

            ticketFrame.AddNewTabPage(tp);
            ticketFrame.InitConfig();

            var tpp = new TabPage();
            tpp.Text=_userName;
            tpp.Controls.Add(ticketFrame);          
            tabAccount.TabPages.Add(tpp);
            tabAccount.SelectedTab = tpp;

            lb_From_To.Text = DateTime.Now.ToString("yyyy年MM月dd") + "~" + DateTime.Now.AddDays(19).ToString("yyyy年MM月dd");
            notice.Text = "12306 订票小助手 C# 版\r\n登录账号：" + _userName;
            lblVersion.Text = "Version:" + Assembly.GetExecutingAssembly().GetName().Version;;
            tmUpdateServerTime.Start();
        }

        //获取服务器时间，并与本地时间做对比
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (!isGetServerTime)
            {
                isGetServerTime = true;
                selectAction.GetServerTime((ss) =>
                {
                    if (ss != null)
                    {
                        ConfigLocalDateTime.tmpTime = Convert.ToDateTime(ss);
                        ts = ConfigLocalDateTime.tmpTime.Subtract(DateTime.Now);
                    }
                    else
                    {
                        if (tmpTimeCount >= 0)
                        {
                            tmpTimeCount = -1;
                            MessageBox.Show("获取服务器时间失败，将使用本地时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //new MessageBoxEx("获取服务器时间失败，将使用本地时间！", MessageboxExIcon.ERROR) { NewPrivateInterval = 1000 }.Show();
                        }
                        ConfigLocalDateTime.tmpTime = DateTime.Now;
                    }
                }, cookieContainer);
            }
            else
            {
                ConfigLocalDateTime.tmpTime = DateTime.Now.AddTicks(ts.Ticks);
                if (tmpTimeCount > 120)
                {
                    tmpTimeCount = 0;
                    isGetServerTime = false;
                }
                tmpTimeCount++;
            }
            DeterMineCall(() =>
            {
                if (ts.TotalSeconds > 0)
                {
                    lblServerTime.Text = String.Format("{0:yyyy-MM-dd HH:mm:ss} 本地比服务器慢约 {1:#0.000} 秒", ConfigLocalDateTime.tmpTime, ts.TotalSeconds);
                }
                else
                {
                    lblServerTime.Text = String.Format("{0:yyyy-MM-dd HH:mm:ss} 本地比服务器快约 {1:#0.000} 秒", ConfigLocalDateTime.tmpTime, ts.TotalSeconds.ToString("#0.000").Replace("-", ""));
                }
            });
        }

        private void formSelectTicket_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                notice.Visible = false;
                hostAction.RestoreHosts();
            }
            finally{ }

            foreach (TabPage page in this.tabAccount.TabPages)                   
            {
                var tm = (TicketFrame)page.Controls[0];
                SaveUsersConfigList(tm.UserName, tm.ConfigList);
            }
        }

        /// <summary>
        /// 保存每个账号配置信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="usrList"></param>
        private void SaveUsersConfigList(string user, List<ConfigList> usrList)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "data\\" + user;
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);
                LocalCookie.WriteCookiesToDisk(path + "\\usrCookie.cfg", LoginAction.cookieContainer);
            }
            catch { }
            var paths = System.IO.Directory.GetCurrentDirectory() + "\\data\\" + user;
            if (!System.IO.Directory.Exists(paths))
                System.IO.Directory.CreateDirectory(paths);
            LocalCookie.WriteConfigToDisk(paths + "\\config.cfg", usrList);
        }

        //委托
        private void DeterMineCall(MethodInvoker method)
        {
            if (!IsDisposed && InvokeRequired)
                Invoke(method);
            else
                method();
        }      

        private void notice_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            notice.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void tsbtnSaleTime_Click(object sender, EventArgs e)
        {
            var SelectSaleTime = new formSelectSaleTime();
            SelectSaleTime.ShowDialog();
        }

        private void tsbtnNews_Click(object sender, EventArgs e)
        {
            var newConetent = new formNewContentcs();
            newConetent.Show();
        }

        private void tsbtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出本帐号吗？", "更改帐号", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //DeleteUserInfo();
                cookieContainer = new CookieContainer();
                Application.Restart();
            }
        }

        private void tsbtnSupport_Click(object sender, EventArgs e)
        {
            var support = new formSupport();
            support.Show();
        }

        private void tsbtnDiscus_Click(object sender, EventArgs e)
        {
            OpenIE_API.OpenUrl(Properties.Resources.Common);
        }

        private void tsbtnBug_Click(object sender, EventArgs e)
        {
            OpenIE_API.OpenUrl(Properties.Resources.Bug);
        }

        private void tsbtnAdvice_Click(object sender, EventArgs e)
        {
            OpenIE_API.OpenUrl(Properties.Resources.Advice);
        }

        private void tsbtnDeveloper_Click(object sender, EventArgs e)
        {
            OpenIE_API.OpenUrl(Properties.Resources.Developer);
        }

        private void tsbtnHome_Click(object sender, EventArgs e)
        {
            OpenIE_API.OpenUrl(Properties.Resources.AuthorHomePage);
        }

        private void formSelectTicket_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void formSelectTicket_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notice.Visible = true;
                this.Visible = false;
                notice.ShowBalloonTip(4000, "提示 " + lblVersion.Text, "如果您开启了抢票，抢到票后会自动弹出窗口.", ToolTipIcon.Info);
            }
        }

        private void lblSetSystemTime_DoubleClick(object sender, EventArgs e)
        {
            ConfigLocalDateTime.SYSTEMTIME systemTime = new ConfigLocalDateTime.SYSTEMTIME();
            systemTime.InitSystemTimeValue(DateTime.Now.AddTicks(ts.Ticks));
            ConfigLocalDateTime.SetLocalTime(ref systemTime);
            ts = new TimeSpan();
            MessageBox.Show("系统时间已经校正完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //new MessageBoxEx("系统时间已经校正完成！", MessageboxExIcon.OK) { NewPrivateInterval = 1000 }.Show();
        }

        /// <summary>
        /// 在datagridview上画字符串
        /// </summary>
        /// <param name="dgv"></param>
        private void DrawNullDataString(Control dgv)
        {
            Font font = new Font("微软雅黑", 30f);
            Brush brush = Brushes.AntiqueWhite;
            PointF point = new PointF((dgv.Width / 2 - 300), dgv.Height / 2 - 15);
            dgv.CreateGraphics().DrawString("当前设置的条件下没有查询到车次", font, brush, point);
        }

        private void tsbtnServerSwitch_Click(object sender, EventArgs e)
        {
            if (!switchisalive && hostEnable && !FormLogin.SwitchOpen)
            {
                switchisalive = true;
                var ff = new formSwitchServer();
                ff.FormClosed += (ss, ee) => { switchisalive = false; };
                ff.Show();
            }
        }
    }
}
