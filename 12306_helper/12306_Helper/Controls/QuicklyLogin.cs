using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using aNyoNe.GetInfoFrom12306;
using PopupControl;

namespace _12306_Helper.Controls
{
    public partial class QuicklyLogin : UserControl
    {
        private string[] _username;
        private string _user="";
        private System.Net.CookieContainer _cookie=new CookieContainer();
        public string[] Buttons
        {
            set
            {
                _username = value;
                InitializeButton(_username);
            }
            get { return _username; }
        }

        public string User
        {

            get { return _user; }
        }

        public CookieContainer Cookie
        {
            get { return _cookie; }
        }

        public QuicklyLogin()
        {
            InitializeComponent();

            flowLayoutPanel1.VerticalScroll.Enabled = true;
            flowLayoutPanel1.VerticalScroll.Visible = false;
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.VerticalScroll.Minimum = 0;
            flowLayoutPanel1.VerticalScroll.Maximum = 100;
        }

        private void InitializeButton(string[] username)
        {
            if (username[0] !=null)
            {
                for (int i = 0; i < username.Length; i++)
                {
                    if (username[i] != null)
                    {
                        var btn = new Button()
                        {
                            FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                            //Location = new System.Drawing.Point(3, 3),
                            Name = "btn" + username[i],
                            Size = new System.Drawing.Size(303, 27),
                            TabIndex = 0,
                            Text = username[i],
                            UseVisualStyleBackColor = true
                        };
                    
                        btn.Click += btn_Click;
                        flowLayoutPanel1.Controls.Add(btn);
                    }
                }
            
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            string username = ((Button) sender).Text;
            string path = AppDomain.CurrentDomain.BaseDirectory + "data\\"+username+"\\" + "usrCookie.cfg";
            DateTime time = DateTime.Now.AddDays(-1);
            if (System.IO.File.Exists(path))
            {
                time = System.IO.File.GetLastWriteTime(path);
                if (DateTime.Now.Subtract(time).TotalMinutes > 20)
                    System.IO.File.Delete(path);
            }
            LoginAction.cookieContainer = LocalCookie.ReadCookiesFromDisk(path);
            if (LoginAction.cookieContainer.Count != 0)
            {
                _cookie = LoginAction.cookieContainer;
                _user = username;
            }
            ((Popup)this.Parent).Close();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.VerticalScroll.Value - 10 >= flowLayoutPanel1.VerticalScroll.Minimum)
                flowLayoutPanel1.VerticalScroll.Value -= 10;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.VerticalScroll.Value + 10 <= flowLayoutPanel1.VerticalScroll.Maximum)
                flowLayoutPanel1.VerticalScroll.Value = flowLayoutPanel1.VerticalScroll.Value + 10;
        }
    }
}