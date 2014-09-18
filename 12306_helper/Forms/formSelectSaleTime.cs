using System;
using System.Windows.Forms;
using aNyoNe.GetInfoFrom12306;

namespace _12306_Helper
{
    public partial class formSelectSaleTime : Form
    {
        public formSelectSaleTime()
        {
            InitializeComponent();
            txtStationName.AutoCompleteCustomSource = InitCompleteSource();
        }
        private AutoCompleteStringCollection InitCompleteSource()
        {
            AutoCompleteStringCollection acCollenction = new AutoCompleteStringCollection();
            acCollenction.AddRange(DatasList.StationNames.ToArray());
            return acCollenction;
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
                        lblTicketTime.Text = v;
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
                    if (v==cboTicketTime.Text)
                    {
                        lblTicketTime.Text = v;
                        rtxtStationNames.Text = DatasList.TrainStartList[v];
                        break;
                    }
                }
            } 
        }

        private void txtStationName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSelect_Click(sender, e);
        }
    }
}
