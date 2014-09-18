using System;
using System.Drawing;
using System.Windows.Forms;

namespace _12306_Helper
{
    public partial class formSupport : Form
    {
        public formSupport()
        {
            InitializeComponent();
        }

        private void picSupport_Click(object sender, EventArgs e)
        {
            OpenIE_API.OpenUrl("https://me.alipay.com/stupidscat");
        }

        private void picSupport_MouseDown(object sender, MouseEventArgs e)
        {
            picSupport.Location = new Point(picSupport.Location.X + 1, picSupport.Location.Y + 1);
        }

        private void picSupport_MouseUp(object sender, MouseEventArgs e)
        {
            picSupport.Location = new Point(picSupport.Location.X - 1, picSupport.Location.Y - 1);
        }

        private void lnkSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetDataObject("pengyouak@163.com");
            if (Clipboard.GetDataObject().GetData(DataFormats.Text).ToString() == "pengyouak@163.com")
                MessageBox.Show("已经成功复制到剪切板,感谢您的支持!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
