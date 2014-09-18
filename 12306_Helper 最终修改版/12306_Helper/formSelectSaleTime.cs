using System;
using System.Drawing;
using System.Windows.Forms;

namespace _12306_Helper
{
    public partial class formSelectSaleTime : Form
    {
        FormShowStyle formShowStyle = new FormShowStyle();
        public formSelectSaleTime()
        {
            InitializeComponent();
            formShowStyle.MakeShadow(this.Handle);
            txtStationName.AutoCompleteCustomSource = InitCompleteSource();
            formShowStyle.ShowForm(this.Handle, 500);
        }
        private AutoCompleteStringCollection InitCompleteSource()
        {
            AutoCompleteStringCollection acCollenction = new AutoCompleteStringCollection();
            acCollenction.AddRange(DatasList.StationNames.ToArray());
            return acCollenction;
        }
        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(128, 128, 255);
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModel.Text == "按发站站名查")
            {
                cboTicketTime.Enabled = false;
                txtStationName.Enabled = true;
                return;
            }
            if (cboModel.Text == "按发票时间查")
            {
                cboTicketTime.Enabled = true;
                txtStationName.Enabled = false;
                return;
            }
            MessageBox.Show("请正确选择查询模式","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cboModel.Text == "按发站站名查")
            {
                rtxtStationNames.Visible = false;
                foreach (var v in DatasList.TrainStartList.Keys)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(DatasList.TrainStartList[v],txtStationName.Text+"[^\\u4e00-\\u9fff]、?"))
                    {
                        lblTicketTime.Text = v.ToString();
                        lblStationNames.Text =txtStationName.Text;
                        break;
                    }
                }
            }
            else
            {
                rtxtStationNames.Visible = true;
                lblStationNames.Text = "";
                foreach (var v in DatasList.TrainStartList.Keys)
                {
                    if (v.ToString()==cboTicketTime.Text)
                    {
                        lblTicketTime.Text = v.ToString();
                        rtxtStationNames.Text = DatasList.TrainStartList[v];
                        break;
                    }
                }
            } 
        }

        private void lblTop_MouseDown(object sender, MouseEventArgs e)
        {
            formShowStyle.MoveForm(this.Handle);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            formShowStyle.HideForm(this.Handle, 500);
            this.Close();
        }

        private void txtStationName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSelect_Click(sender, e);
        }
    }
}
