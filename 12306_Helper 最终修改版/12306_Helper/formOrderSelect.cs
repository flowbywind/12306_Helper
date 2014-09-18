using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;

namespace _12306_Helper
{
    public partial class formOrderSelect : Form
    {
        FormShowStyle formStyle = new FormShowStyle();
        CookieContainer _cookieContainer = new CookieContainer();
        OrderSelectAction orderSelectAction = new OrderSelectAction();
        SubmitOrderAction submitAction = new SubmitOrderAction();
        static List<MyOrderData> _orderData;
        BindingList<MyOrderData> _BindingData;
        static List<MyOrderData> _orderResult;
        string strToken = "";
        string strSelectToken = "";
        string notCompleteOrderNO = "";
        string queryDataFlag = "1";
        string table = "";
        public formOrderSelect()
        {
            InitializeComponent();
            formStyle.MakeShadow(this.Handle);
            dgvUnfinisedOrder.AutoGenerateColumns = false;
            _orderData = new List<MyOrderData>();
            _orderResult = new List<MyOrderData>();
            _cookieContainer = formSelectTicket.cookieContainer;
            flCompletedOrder.VerticalScroll.Enabled = true;
            flCompletedOrder.VerticalScroll.Visible = true;
            flCompletedOrder.VerticalScroll.Minimum = 0;
            flCompletedOrder.VerticalScroll.Maximum = 100;
            FailedOrderDetail.Flag = false;
        }
        //加载未完成订单
        private void formOrderSelect_Load(object sender, EventArgs e)
        {
            formStyle.ShowForm(this.Handle, 500);
            _orderData.Clear();
            orderSelectAction.GetUnfinishedOrder((str) => {
                if (str == "获取信息失败" || str == string.Empty)
                { MessageBox.Show("信息获取失败，请重试", "加载未完成订单", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (str.IndexOf("总张数") ==-1)
                    MessageBox.Show("您没有未完成的订单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    strToken  = System.Text.RegularExpressions.Regex.Match(str, "[0-9abcdefABCDEF]{32}").ToString();
                    notCompleteOrderNO = Regex.Match(str, "E\\d{9}").ToString();
                    DeterMineCall(() =>
                    {
                        _orderData = GetOrderItems(str.Replace(" ", "").Replace("\r\n", "").Replace("\t", ""));
                        _BindingData = new BindingList<MyOrderData>(_orderData);
                        dgvUnfinisedOrder.DataSource = _BindingData;
                    });
                }
            }, _cookieContainer);

            GetOrderToken();
        }
        //获取未完成订单页面的Token
        private void GetOrderToken()
        {
            orderSelectAction.GetOrderSelectToken((str) =>
            {
                if (str == "获取信息失败" || str == string.Empty)
                { MessageBox.Show("信息获取失败，请重试", "获取未完成订单页面的Token", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                strSelectToken = System.Text.RegularExpressions.Regex.Match(str, "[0-9abcdefABCDEF]{32}").ToString();
            }, _cookieContainer);
        }
        //获取未完成订单的列表
        private List<MyOrderData> GetOrderItems(string html)
        {
            List<MyOrderData> orderData = new List<MyOrderData>();//<div class="jdan_tfont">
            int length=0;

            table = StringHelper.FindString(ref html, "<divclass=\"jdan_tfont\">", "</table>");
            string tmpTable=StringHelper.FindString(ref html, "<divclass=\"jdan_tfont\">", "</table>");
            length = Convert.ToInt16(Regex.Match(html, "(?<=总张数：)\\d+").ToString());

            string[] trCollection = new string[length + 2];
            int i = 0;
            while (tmpTable.IndexOf("<tr") > -1)
            {
                trCollection[i] = StringHelper.FindString(ref tmpTable, "<tr", "</tr>");
                tmpTable = tmpTable.Replace(trCollection[i], "");
                i++;
            }
            for (int a = 1; a < trCollection.Length - 1; a++)
            {
                var myData = new MyOrderData(trCollection[a]);
                if (table.IndexOf("订单号") > -1)
                {
                    myData.OrderID = Regex.Match(table, "E\\d{9}").ToString();
                    myData.OrderDate = Regex.Match(table, "订单时间[：:0-9\\-]+").ToString();
                    myData.OrderTotalPrice = Regex.Match(table, "总票价[：:0-9\\.]+\\(元\\)").ToString();
                    myData.TicketCount = Regex.Match(table, "总张数[：:0-9]+").ToString();
                }
                orderData.Add(myData);
                if (myData.StatusInfo!="订票成功"&&FailedOrderDetail.Flag == false)
                {
                    FailedOrderDetail.Flag = true;
                    FailedOrderDetail._Status = myData.Status;
                    FailedOrderDetail._StatusInfo = myData.StatusInfo;
                    FailedOrderDetail._TrainCode = myData.TrainCode;
                    FailedOrderDetail._TrainDate = myData.TrainDate;
                    FailedOrderDetail._TrainNo = myData.TrainNo;
                    FailedOrderDetail._TrainStationInfo = myData.TrainStationInfo;
                }
            }

            return orderData;
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void lblTop_MouseDown(object sender, MouseEventArgs e)
        {
            formStyle.MoveForm(this.Handle);
        }

        private void lblMini_MouseEnter(object sender, EventArgs e)
        {
            lblMini.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void lblMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(128, 128, 255);
        }

        private void lblMini_MouseLeave(object sender, EventArgs e)
        {
            lblMini.BackColor = Color.FromArgb(128, 128, 255);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            formStyle.HideForm(this.Handle,500);
            this.Close();
        }

        private void DeterMineCall(MethodInvoker method)
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }
        //取消订单
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvUnfinisedOrder.Rows.Count <= 0) return;
            orderSelectAction.PostData = string.Format("org.apache.struts.taglib.html.TOKEN={0}&sequence_no={1}&orderRequest.tour_flag=", strToken, notCompleteOrderNO);
            orderSelectAction.CancelNotCompleteOrder((str) => {
                if (str == "获取信息失败" || str == string.Empty)
                { MessageBox.Show("信息获取失败，请重试", "取消订单", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (str.IndexOf("取消订单成功") > -1)
                {
                    MessageBox.Show("取消订单成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DeterMineCall(() =>
                    {
                        dgvUnfinisedOrder.DataSource = null;
                    });
                }
                else
                {
                    //取消失败
                    MessageBox.Show("取消订单失败！请关闭本窗口重新来过。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }, _cookieContainer);
        }
        //查询订单
        private void btnSelectOrder_Click(object sender, EventArgs e)
        {
            TokenSelect();
            flCompletedOrder.Controls.Clear();
            orderSelectAction.SelectOrder((str) => {
                if (str == "获取信息失败" || str == string.Empty)
                { MessageBox.Show("信息获取失败，请重试", "查询订单", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (str.IndexOf("总张数") <= -1)
                    MessageBox.Show("没有符合查询条件的订单信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    int listCount = Regex.Matches(str, "table_clist").Count;
                    string tmpStr = str.Replace(" ", "").Replace("\r\n", "").Replace("\t","");
                    for (int i = 0; i < listCount; i++)
                    {
                        List<MyOrderData> newData=new List<MyOrderData>(GetOrderItems(tmpStr));
                        BindingList<MyOrderData> BindingResult = new BindingList<MyOrderData>(newData);
                        //_orderResult = GetOrderItems(tmpStr);
                        tmpStr = tmpStr.Replace(table, "");
                        DeterMineCall(() =>
                        {            
                            OrderControl oc = new OrderControl();
                            oc.MyOrderNo = newData[0].OrderID+" "+newData[0].OrderDate+" "+newData[0].OrderTotalPrice+" "+newData[0].TicketCount;
                            oc.MyDataSource = BindingResult;
                            oc.AutoSize = false;
                            flCompletedOrder.Controls.Add(oc);
                        });
                    }
                }
            },_cookieContainer);
        }
        //生成查询订单的POSTDATA
        private void TokenSelect()
        {
             orderSelectAction.PostData=string.Format("org.apache.struts.taglib.html.TOKEN={0}&queryOrderDTO.location_code=_1&leftmenu=Y&queryDataFlag={1}&queryOrderDTO.from_order_date={2}&queryOrderDTO.to_order_date={3}&queryOrderDTO.sequence_no={4}&queryOrderDTO.train_code={5}&queryOrderDTO.name={6}"
                                                      ,strSelectToken,queryDataFlag,dtStartDate.Value.ToString("yyyy-MM-dd"),dtEndDate.Value.ToString("yyyy-MM-dd"),txtOrderID.Text,txtTrainCode.Text,txtPassengerName.Text);
        }

        private void cboSelectMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectMode.SelectedIndex == 0)
                queryDataFlag = "1";
            else
                queryDataFlag = "2";
        }

        private void btnGoIE_Click(object sender, EventArgs e)
        {
            OpenIE_API.OpenIE(_cookieContainer);
        }
    }
}
