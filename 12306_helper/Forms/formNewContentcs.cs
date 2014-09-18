using System;
using System.Windows.Forms;

namespace _12306_Helper
{
    public partial class formNewContentcs : Form
    {
        WebBrowser wb = new WebBrowser();
        public formNewContentcs()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formNewContentcs_Load(object sender, EventArgs e)
        {
            wb.Navigate("http://www.12306.cn/mormhweb/zxdt/index_zxdt.html");
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
        }

        public void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement s = wb.Document.GetElementById("newList");
            string document = s.OuterHtml.Replace("../", "http://www.12306.cn/mormhweb/").Replace("./", "http://www.12306.cn/mormhweb/zxdt/").Replace("src=\"/mormhwe", "src=\"http://dynamic.12306.cn/mormhwe");
            wbNewContent.DocumentText = String.Format(@"<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" /><style>
                                                                                div {{
                                                                                display: block;
                                                                                }}
                                                                                li{{
                                                                                Line-height:22px;
                                                                                background-color:#ffffff;
                                                                                font: 12px tahoma, arial, 宋体;
                                                                                }}
                                                                                .red a{{
                                                                                color: #ff0000;
                                                                                }}
                                                                                </style>{0}", document);
            wbNewContent.Visible = true;
            lblTop.Text = "";
        }

        private void formNewContentcs_FormClosing(object sender, FormClosingEventArgs e)
        {
            wb.Dispose();
        }
    }
}
