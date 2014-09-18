#define DEBUG
#define CHECK
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using aNyoNe.AutoServerSwitch;
using aNyoNe.GetInfoFrom12306;
using _12306_Helper.Controls;
using PopupControl;
using _12306_Helper.Properties;

namespace _12306_Helper
{
    public partial class FormLogin : Form
    {
        public static bool SwitchOpen = false;
        readonly LoginAction  _la = new LoginAction();
        private object[] _nameSource;

        ~FormLogin()
        {
            GC.Collect();
            GC.Collect();
        }

        public FormLogin()
        {
            InitializeComponent();
            txtRandCode.GotFocus +=new System.EventHandler(txtRandCode_Focused);
            this.Text = "登录  Version:" + Assembly.GetExecutingAssembly().GetName().Version;
        }
        private void txtRandCode_Focused(object sender, EventArgs e)
        {
            txtRandCode.SelectAll();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void formLogin_Load(object sender, EventArgs e)
        {
            try
            {
                string path=Environment.SystemDirectory + "\\drivers\\etc\\hosts";
                if (System.IO.File.Exists(path))
                {
                    var hostAction = new HostAction(path);
                    hostAction.RestoreHosts();
                }
                else
                {
                    this.btnSwitchServer.Enabled = false;
                    formSelectTicket.hostEnable = false;
                    MessageBox.Show("没有找到hosts文件,请新建后重新启动本程序以恢复自动切换功能,否则切换功能将不可用.", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex) {
                formSelectTicket.hostEnable = false;
                MessageBox.Show(string.Format("由于加载Hosts文件失败，失败原因：{0}\r\n可能导致软件的IP切换功能无效，如果想启用，请允许程序访问Hosts文件或者去除Hosts文件的保护,然后重新启动本程序", ex.Message), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            GetAutoCompleteSource();
            if(_nameSource!=null)
            { cboName.Items.AddRange(_nameSource); }
            

            var dc=new DesCryption();
            cboName.Text = ConfigInfo.conf.username;
            if(cboName.Text !=string.Empty)
                txtPwd.Text = dc.DecryptString(ConfigInfo.conf.password, ConfigInfo.conf.username);
        }
        private void GetAutoCompleteSource()
        {
            try
            {
                string[] direc = System.IO.Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + "data\\");
                _nameSource = new object[direc.Length];
                for (int i = 0; i < direc.Length; i++)
                {
                    _nameSource[i] = direc[i].Substring(direc[i].LastIndexOf("\\")).Replace("\\", "");
                }
            }
            catch (System.IO.DirectoryNotFoundException e) { }
        }

        //获取验证码
        private void GetRandCodeImg()
        {
            DeterMineCall(()=>{
                randCode.Image = Resources.loading;
            });
            LoginAction.cookieContainer = new System.Net.CookieContainer();
            _la.GetLoginRandCodeImg((bit) =>
            {
                Action ac = () =>
                {
                    Image bt = bit;
                    randCode.Image = bt;
                };
                if (InvokeRequired)
                    Invoke(ac);
            });
        }
        private void DeterMineCall(MethodInvoker method)
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblInfomation.Text = "";
            if (cboName.Text.Length < 4) return;
            if (txtPwd.Text.Length < 4) return;
            if (txtRandCode.TextLength < 4) return;
            btnLogin.Enabled = false;
            btnLogin.Text = "正在登录";
            Application.DoEvents();
            string name = cboName.Text;
            string pwd = txtPwd.Text;
            var htmlTran = new HTML_Translation();

            //采用同步方式登录
            _la.PostData = string.Format(@"loginUserDTO.user_name={0}&userDTO.password={1}&randCode={2}",
                name, pwd, txtRandCode.Text);
            var strHash = _la.BeginLogin();
            string strHtml = "";
            var cookie = new CookieContainer();
            if (strHash == null)
            {
                MessageBox.Show("难道12306又挂了?","提示",MessageBoxButtons.OK,MessageBoxIcon.Question);
                return;
            }
            foreach (var v in strHash.Keys)
            {
                cookie = (CookieContainer) v;
                strHtml = strHash[v].ToString();
                break;
            }
            if (strHtml == "")
            {
                lblInfomation.Text = "登录失败!";
                btnLogin.Enabled = true;
                btnLogin.Text = "登录";
                txtRandCode.Focus();
                GetRandCodeImg();
                return;
            }
            try
            {

                var returnString = htmlTran.TranslationHtmlEx(strHtml);
                if (returnString["messages"].Any())
                {
                    GetRandCodeImg();
                    DeterMineCall(() =>
                    {
                        lblInfomation.Text = returnString["messages"][0].ToString();
                        this.BeginInvoke(new Action(FormShake));
                        txtRandCode.Text = "";
                        btnLogin.Enabled = true;
                        btnLogin.Text = "登录";
                        txtRandCode.Focus();
                        Application.DoEvents();
                    });
                    return;
                }
                //var loginCheck = returnString["data"] as JavaScriptObject;
                if (returnString["data"] != null && returnString["data"]["loginCheck"].ToString() == "Y")
                {
                    if (chkUserInfo.Checked)
                    {
                        var dc = new DesCryption();
                        ConfigInfo.conf.username = name;
                        ConfigInfo.conf.password = dc.EncryptString(pwd, name);

                        ConfigInfo.savetofile(ConfigInfo.conf.username);
                        string path = AppDomain.CurrentDomain.BaseDirectory + "data\\" + name;
                        if (!System.IO.Directory.Exists(path))
                            System.IO.Directory.CreateDirectory(path);
                        LocalCookie.WriteCookiesToDisk(path + "\\usrCookie.cfg", LoginAction.cookieContainer);

                    }

                    btnLogin.Enabled = true;
                    btnLogin.Text = "登录";
                    this.Hide();
                    //                MessageBox.Show(@"温馨提示：
                    //
                    //1. 自2013年1月4日起，火车票互联网、电话订票预售期延长至20天(含当日)，代售点和车站部分售票窗口预售期延长至18天(含当日)。
                    //
                    //2. 自2013年1月1日起，通过电话预订车票的旅客可凭订票时乘车人有效身份证件，到全国任一车站窗口或代售点换取已订车票。当日12:00前已订车票于第二日12:00前取有效；当日12：00后已订车票于第二日24:00前取有效。
                    //
                    //
                    //请广大旅客注意电话订票取票时间和范围、互联网和电话订票起售时间、火车票预售期的变化，合理安排好购票计划。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var selectForm = new formSelectTicket(cookie)
                    {
                        ThisCookie = cookie,
                        /*formSelectTicket.cookieContainer = cookie;*/
                        UserName = cboName.Text
                    };
                    selectForm.Show();
                }
                else
                {
                    GetRandCodeImg();
                    lblInfomation.Text = "登录失败";
                    txtRandCode.Text = "";
                    btnLogin.Enabled = true;
                    btnLogin.Text = "登录";
                    txtRandCode.Focus();
                    return;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("23：00至07：00为系统维护时间！","温馨提醒",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            finally { }
        }

        private void randCode_Click(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(GetRandCodeImg));
        }
        private void txtRandCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnLogin_Click(sender, e);
        }

        private void formLogin_Shown(object sender, EventArgs e)
        {
            try
            {
                string[] directorys = System.IO.Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + "data\\");
                string[] rDirectorys = new string[directorys.Length];
                int j = 0;
                for (int i = 0; i < directorys.Length; i++)
                {
                    var time = DateTime.Now.AddDays(-1);
                    var path = directorys[i] + "\\usrCookie.cfg";
                    if (System.IO.File.Exists(path))
                    {
                        time = System.IO.File.GetLastWriteTime(path);
                        if (DateTime.Now.Subtract(time).TotalMinutes > 30)
                        {
                            System.IO.File.Delete(path);
                        }
                        else
                        {
                            rDirectorys[j++] =
                                directorys[i].Substring(directorys[i].LastIndexOf("\\")).Replace("\\", "");
                        }
                    }
                }
                if (rDirectorys[0] != null)
                {
                    var ql = new QuicklyLogin();
                    ql.Buttons = rDirectorys;
                    var popup = new Popup(ql)
                    {
                        AutoClose = true,
                        FocusOnOpen = false,
                        ShowingAnimation = PopupAnimations.Slide | PopupAnimations.LeftToRight,
                        HidingAnimation = PopupAnimations.Slide | PopupAnimations.RightToLeft
                    };
                    popup.Closing += popup_Closing;
                    popup.Show(new Point(this.Location.X + this.Width + 3, this.Location.Y + 3));
                }
            }
            catch (Exception)
            {

               
            }
            finally { }
          

            GetRandCodeImg();    
        }

        void popup_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            var ql = (QuicklyLogin)((Popup) sender).Controls[0];
            if (ql.User != "")
            {
                var selectForm = new formSelectTicket(ql.Cookie) { UserName = ql.User };
                selectForm.Show();
                this.Hide();
            }
        }

        private void btnSwitchServer_Click(object sender, EventArgs e)
        {
            if (!SwitchOpen&&formSelectTicket.hostEnable)
            {
                SwitchOpen = true;
                var ff = new formSwitchServer();
                ff.FormClosed += (ss, ee) => { SwitchOpen = false; };
                ff.Show();
            }
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.Size.Height != this.MinimumSize.Height)
            {
                for (int i = this.Size.Height; i >= this.MinimumSize.Height; i--)
                {
                    this.Height = i;
                    System.Threading.Thread.Sleep(0);
                }
            }
            else
            {
                for (int i = this.Size.Height; i <= this.MaximumSize.Height; i++)
                {
                    this.Height = i;
                    System.Threading.Thread.Sleep(0);
                }
            }
        }

        private void lblClearList_DoubleClick(object sender, EventArgs e)
        {
            //ConfigInfo.usrConfig.Clear();
            cboName.Items.Clear();
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "usrList.cfg"))
                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "usrList.cfg");
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "config.cfg"))
                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "config.cfg");
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "usr.cfg"))
                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "usr.cfg");
            this.cboName.Text = "";
            this.cboName.Focus();
            this.txtPwd.Text = "";

            MessageBox.Show("历史登录信息已经清除","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void lnkMyPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenIE_API.OpenUrl(Properties.Resources.AuthorHomePage);
        }

        //窗体摇动
        private void FormShake()
        {
            int x = this.Location.X;
            int xx = x;
            this.Location = new Point(x-7, this.Location.Y);
            for (int i = 0; i < 5; i++)
            {
                for (int a = 0; a < 14; a++)
                {
                    this.Location = new Point(xx = xx + 1, this.Location.Y);
                    System.Threading.Thread.Sleep(2);
                }
                System.Threading.Thread.Sleep(50);
                for (int b = 0; b < 14; b++)
                {
                    this.Location = new Point(xx = xx - 1, this.Location.Y);
                    System.Threading.Thread.Sleep(2);
                }
                System.Threading.Thread.Sleep(50);
            }
            System.Threading.Thread.Sleep(50);
            this.Location = new Point(x, this.Location.Y);
        }
    }
}
