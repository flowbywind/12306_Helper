using System;
using System.Windows.Forms;
using PingMock;
using System.Drawing;

namespace _12306_Helper
{
    public partial class formLogin : Form
    {
        public static bool switchOpen = false;
        FormShowStyle formStyle = new FormShowStyle();
        LoginAction la = new LoginAction();
        public formLogin()
        {
            InitializeComponent();
            formStyle.MakeShadow(this.Handle);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            formStyle.HideForm(this.Handle, 500);
            Application.Exit();
        }
        
        private void formLogin_Load(object sender, EventArgs e)
        {
            try
            {
                string path=Environment.SystemDirectory + "\\drivers\\etc\\hosts";
                if (System.IO.File.Exists(path))
                {
                    HostAction hostAction = new HostAction(path);
                    hostAction.RestoreHosts();
                }
                else
                {
                    formSelectTicket.hostEnable = false;
                    MessageBox.Show("没有找到hosts文件,请新建后重新启动本程序以恢复自动切换功能,否则切换功能将不可用.", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex) {
                formSelectTicket.hostEnable = false;
                MessageBox.Show(string.Format("由于加载Hosts文件失败，失败原因：{0}\r\n可能导致软件的IP切换功能无效，如果想启用，请允许程序访问Hosts文件或者去除Hosts文件的保护,然后重新启动本程序", ex.Message), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ConfigInfo.readfromfile();
            txtName.Text =EncodeAndDecode.DecodeBase64(EncodeAndDecode.DecodeBase64(ConfigInfo.conf.username));
            txtPwd.Text = EncodeAndDecode.DecodeBase64(EncodeAndDecode.DecodeBase64(ConfigInfo.conf.password));
            IntPtr o = this.Handle;
            GetRandCodeImg();
            formStyle.ShowForm(this.Handle, 500);
        }

        //获取验证码
        private void GetRandCodeImg()
        {
            la.cookieContainer = new System.Net.CookieContainer();
            la.GetLoginRandCodeImg((bit) =>
            {
                Action ac = () =>
                {
                    randCode.Image = bit;
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
            DeterMineCall(()=>
            {
                if (txtName.Text.Length < 4) return;
                if (txtPwd.Text.Length < 4) return;
                if (txtRandCode.TextLength < 4) return;
                btnLogin.Enabled = false;
                btnLogin.Text = "正在登录";
                Application.DoEvents();
                //获取随机码
                string loginRand="";
                HTML_Translation htmlTran = new HTML_Translation();
                la.GetLoginRand((strrand) => {
                    if (strrand == "获取信息失败")
                    { MessageBox.Show("信息获取失败，请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    loginRand = htmlTran.TranslationHtml(strrand, "loginRand");
                
                    //登录
                    string result="";
                    la.PostData = string.Format(@"loginRand={0}&loginUser.user_name={1}&nameErrorFocus=&passwordErrorFocus=&randCode={2}&randErrorFocus=&refundFlag=Y&refundLogin=N&user.password={3}",
                                loginRand, txtName.Text, txtRandCode.Text, txtPwd.Text);
                    la.BeginLogin((str) => {
                        result = str;
                        DeterMineCall(() =>
                        {
                            //登录返回结果
                            if (result.IndexOf("请输入正确的验证码") > -1)
                            {
                                lblInfomation.Text = "验证码不正确"; GetRandCodeImg();
                                txtRandCode.Text = "";
                                btnLogin.Enabled = true;
                                btnLogin.Text = "登录";
                                txtRandCode.Focus();
                                return;
                            }
                            if (result.IndexOf("系统维护") > -1)
                            {
                                lblInfomation.Text = "系统维护中....."; GetRandCodeImg();
                                txtRandCode.Text = "";
                                btnLogin.Enabled = true;
                                btnLogin.Text = "登录";
                                txtRandCode.Focus();
                                return;
                            }
                            if (result.IndexOf("登录名不存在") > -1)
                            {
                                lblInfomation.Text = "登录名不存在"; GetRandCodeImg();
                                txtRandCode.Text = "";
                                btnLogin.Enabled = true;
                                btnLogin.Text = "登录";
                                txtRandCode.Focus();
                                return;
                            }
                            else if (result.IndexOf("密码输入错误") > -1)
                            {
                                lblInfomation.Text = "密码输入错误"; GetRandCodeImg();
                                txtPwd.Text = "";
                                btnLogin.Enabled = true;
                                btnLogin.Text = "登录";
                                txtPwd.Focus();
                                return;
                            }
                            else if (result.IndexOf("锁定") > -1)
                            {
                                lblInfomation.Text = "帐号被锁定"; GetRandCodeImg();
                                btnLogin.Enabled = true;
                                btnLogin.Text = "登录";
                                return;
                            }
                            else if (result.IndexOf("网络") > -1)
                            {
                                lblInfomation.Text = "网站又挂了"; GetRandCodeImg();
                                btnLogin.Enabled = true;
                                btnLogin.Text = "登录";
                                return;
                            }
                            else if (result.IndexOf("欢迎您登录") != -1)
                            {
                                if (chkUserInfo.Checked)
                                {
                                    ConfigInfo.conf.username = EncodeAndDecode.EncodeBase64(EncodeAndDecode.EncodeBase64(txtName.Text));
                                    ConfigInfo.conf.password = EncodeAndDecode.EncodeBase64(EncodeAndDecode.EncodeBase64(txtPwd.Text));
                                    ConfigInfo.savetofile();
                                    LocalCookie.WriteCookiesToDisk(AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg", la.cookieContainer);
                                }
                                btnLogin.Enabled = true;
                                btnLogin.Text = "登录";
                                this.Hide();
                                formSelectTicket selectForm = new formSelectTicket();
                                selectForm.user = txtName.Text;
                                selectForm.Show();
                            }
                            else
                            {
                                lblInfomation.Text = "登录失败"; GetRandCodeImg();
                                txtRandCode.Text = "";
                                btnLogin.Enabled = true;
                                btnLogin.Text = "登录";
                                txtRandCode.Focus();
                                return;
                            }
                        });
                    });
                });
            });
        }

        private void lblTop_MouseDown(object sender, MouseEventArgs e)
        {
            formStyle.MoveForm(this.Handle);
        }

        private void randCode_Click(object sender, EventArgs e)
        {
            GetRandCodeImg();
        }
        private void txtRandCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnLogin_Click(sender, e);
        }

        private void formLogin_Shown(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg";
            DateTime time=DateTime.Now.AddDays(-1);
            if (System.IO.File.Exists(path))
            {
                time = System.IO.File.GetLastWriteTime(path);
                if (DateTime.Now.Subtract(time).TotalMinutes > 20)
                    System.IO.File.Delete(path);
            }
            la.cookieContainer = LocalCookie.ReadCookiesFromDisk(path);
            if (la.cookieContainer.Count != 0)
            {
                formSelectTicket.cookieContainer = la.cookieContainer;
                if (chkUserInfo.Checked)
                {
                    ConfigInfo.conf.username =EncodeAndDecode.EncodeBase64(EncodeAndDecode.EncodeBase64(txtName.Text));
                    ConfigInfo.conf.password = EncodeAndDecode.EncodeBase64(EncodeAndDecode.EncodeBase64(txtPwd.Text));
                    ConfigInfo.savetofile();
                    LocalCookie.WriteCookiesToDisk(path, la.cookieContainer);
                }
                this.Hide();
                formSelectTicket selectForm = new formSelectTicket();
                selectForm.user = txtName.Text;
                selectForm.Show();
            }
            GetRandCodeImg();
        }

        private void btnSwitchServer_Click(object sender, EventArgs e)
        {
            if (!switchOpen&&formSelectTicket.hostEnable)
            {
                switchOpen = true;
                formSwitchServer fss = new formSwitchServer();
                fss.Show();
            }
        }

        #region 调整窗体大小
        const int WM_NCHITTEST = 0x0084;
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
            }
        }
        #endregion
    }
}
