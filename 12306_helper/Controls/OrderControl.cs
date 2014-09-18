using System;
using System.Windows.Forms;

namespace _12306_Helper
{
    public partial class OrderControl : UserControl
    {
        public string MyOrderNo { get; set; }
        public object MyDataSource { get; set; }

        ~OrderControl()
        {
        GC.Collect();
           GC.Collect();
        }

        public OrderControl()
        {
            InitializeComponent();
            dgvUnfinisedOrder.AutoGenerateColumns = false;
        }

        private void lblTop_Click(object sender, EventArgs e)
        {
            OrderDetail.Visible = !OrderDetail.Visible;
            if (OrderDetail.Visible)
            {
                lblOrderInfo.BorderStyle = BorderStyle.Fixed3D;
                if (dgvUnfinisedOrder.Rows.Count > 0)
                {
                    this.Height = dgvUnfinisedOrder.Rows.Count * 24 + 48;
                }
            }
            else
            { 
                this.Height = 24;
                lblOrderInfo.BorderStyle = BorderStyle.None;
            }
        }

        private void OrderControl_Load(object sender, EventArgs e)
        {
            this.lblOrderInfo.Text = "订单号：" + MyOrderNo;
            dgvUnfinisedOrder.DataSource = MyDataSource;
            dgvUnfinisedOrder.Refresh();
        }
    }
}
