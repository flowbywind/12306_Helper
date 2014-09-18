using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aNyoNe.GetInfoFrom12306;
using aNyoNe.AutoServerSwitch;
using System.Net;
using PopupControl;

namespace _12306_Helper.Controls
{
    public partial class LoginMain : UserControl
    {
        public static bool SwitchOpen = false;
        readonly LoginAction _la = new LoginAction();
        private object[] _nameSource;

        ~LoginMain()
        {
            GC.Collect();
            GC.Collect();
        }

        public LoginMain()
        {
            InitializeComponent();
            txtRandCode.GotFocus += new System.EventHandler(txtRandCode_Focused);
            btnLogin.Click += new EventHandler(btnLogin_Click);
            randCode.Click += new EventHandler(randCode_Click);
            txtRandCode.KeyPress += new KeyPressEventHandler(txtRandCode_KeyPress);
            
        }

        private void txtRandCode_Focused(object sender, EventArgs e)
        {
            txtRandCode.SelectAll();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ((PopupControl.Popup)this.Parent).Close();
        }

        private void LoginMain_Load(object sender, EventArgs e)
        {
            GetAutoCompleteSource();
            if (_nameSource != null)
            { cboName.Items.AddRange(_nameSource); }


            var dc = new DesCryption();
            cboName.Text = ConfigInfo.conf.username;
            if (cboName.Text != string.Empty)
                txtPwd.Text = dc.DecryptString(ConfigInfo.conf.password, ConfigInfo.conf.username);

            formLogin_Shown();
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
            DeterMineCall(() =>
            {
                randCode.Image = _12306_Helper.Properties.Resources.loading;
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
                MessageBox.Show("难道12306又挂了?", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            foreach (var v in strHash.Keys)
            {
                cookie = (CookieContainer)v;
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

                MessageBox.Show("23：00至07：00为系统维护时间！", "温馨提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void formLogin_Shown()
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
            var ql = (QuicklyLogin)((Popup)sender).Controls[0];
            if (ql.User != "")
            {
                var selectForm = new formSelectTicket(ql.Cookie) { UserName = ql.User };
                selectForm.Show();
                this.Hide();
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

            MessageBox.Show("历史登录信息已经清除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
