using System;
using System.Drawing;
using System.Windows.Forms;

namespace _12306_Helper
{
    public partial class formNewContentcs : Form
    {
        FormShowStyle formStyle = new FormShowStyle();
        WebBrowser wb = new WebBrowser();
        public formNewContentcs()
        {
            InitializeComponent();
            formStyle.MakeShadow(this.Handle);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            formStyle.HideForm(this.Handle,500);
            this.Close();
        }

        private void formNewContentcs_Load(object sender, EventArgs e)
        {
            formStyle.ShowForm(this.Handle,500);
            wb.Navigate("http://www.12306.cn/mormhweb/zxdt/tlxw_tip.html");
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
        }

        public void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string document = wb.DocumentText;
            document = document.Replace("href=\"/mormhwe", "href=\"http://dynamic.12306.cn/mormhwe");
            wbNewContent.DocumentText = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />" + @"<style>#zxdt {
                                        padding: 0px 10px;
                                        }
                                        ul, ol, li, table, td, th, img, div, h1, h2, h3, h4, h5, h6, dl, dt, dd, form {
                                        padding: 0px;
                                        margin: 0px;
                                        }
                                        div {
                                        display: block;
                                        }

                                        #page {
                                        text-align: left;
                                        }

                                        body {
                                        background-color:#c0c0ff;
                                        font: 12px tahoma, arial, 宋体;
                                        }</style>"+document;
            wbNewContent.Visible = true;
            lblTop.Text = "最新动态";
        }
        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(128, 128, 255);
        }
        private void lblTop_MouseDown(object sender, MouseEventArgs e)
        {
            formStyle.MoveForm(this.Handle);
        }
    }
}
