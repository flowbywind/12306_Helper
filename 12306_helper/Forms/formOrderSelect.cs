using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using aNyoNe.GetInfoFrom12306;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace _12306_Helper
{
    public partial class formOrderSelect : Form
    {
        CookieContainer _cookieContainer = new CookieContainer();
        OrderSelectAction orderSelectAction = new OrderSelectAction();
        static List<MyOrderData> _orderData;
        BindingList<MyOrderData> _BindingData;
        static List<MyOrderData> _orderResult;
       
        string queryDataFlag = "1";
        
        HTML_Translation translation = new HTML_Translation();
        public formOrderSelect(CookieContainer cookie)
        {
            InitializeComponent();
            _cookieContainer = cookie;
            dgvUnfinisedOrder.AutoGenerateColumns = false;
            _orderData = new List<MyOrderData>();
            _orderResult = new List<MyOrderData>();
            //_cookieContainer = formSelectTicket.cookieContainer;
            flCompletedOrder.VerticalScroll.Enabled = true;
            flCompletedOrder.VerticalScroll.Visible = true;
            flCompletedOrder.VerticalScroll.Minimum = 0;
            flCompletedOrder.VerticalScroll.Maximum = 100;
            FailedOrderDetail.Flag = false;
        }

        //加载未完成订单
        private void formOrderSelect_Load(object sender, EventArgs e)
        {
            _orderData.Clear();
            txtQueryParam.LostFocus += new EventHandler(txtQueryParam_LostFocus);
            oc.ShowOpaqueLayer(dgvUnfinisedOrder, 90, true);
            BeginGetUncompeleteOrder();
        }

        OpaqueCommand oc = new OpaqueCommand();
        private void BeginGetUncompeleteOrder()
        {
            orderSelectAction.QueryMyOrderNoComplete((str) =>
            {
                try
                {
                    System.Threading.Thread.Sleep(3333);
                    var returnString = translation.TranslationHtmlEx(str);
                    if (str.IndexOf("data") > -1)
                    {
                        _orderData = GetOrderItems(returnString);
                        DeterMineCall(() =>
                        {
                            _BindingData = new BindingList<MyOrderData>(_orderData);
                            dgvUnfinisedOrder.DataSource = _BindingData;
                            lblInfo.Text = "加载完成";
                        });
                    }
                    else
                    {
                        DeterMineCall(() =>
                        {
                            lblInfo.Text = "加载完成,您没有未完成的订单";
                        });
                    }
                }
                finally
                {
                    DeterMineCall(()=>{oc.HideOpaqueLayer();});
                }
            }, _cookieContainer);
        }

        //获取未完成订单的列表
        private List<MyOrderData> GetOrderItems(JObject obj)//object[] ticket, JavaScriptObject order)
        {
            var orderData = new List<MyOrderData>();//<div class="jdan_tfont">
            for (int i = 0; i < obj["data"]["orderDBList"][0]["tickets"].Count(); i++)
            {
                var oData = new MyOrderData(obj,i);
                orderData.Add(oData);
            }
            return orderData;
        }

        private void DeterMineCall(MethodInvoker method)
        {
            if (InvokeRequired && !this.IsDisposed)
                Invoke(method);
            else
                method();
        }
        //取消订单
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvUnfinisedOrder.Rows.Count <= 0) return;
            string orderid = string.Empty;//订单ID
            if (_orderData!=null)
            {
                orderid = _orderData[0].OrderID;
            }
            else
            {
                DeterMineCall(() =>
                { MessageBox.Show(this, "信息获取失败，请重试", "取消订单", MessageBoxButtons.OK, MessageBoxIcon.Information); return; });
            }
            oc.ShowOpaqueLayer(this, 90, true,false);
            orderSelectAction.PostData = string.Format("sequence_no={0}&cancel_flag=cancel_order&_json_att=", orderid);
            orderSelectAction.CancelNotCompleteOrder((str) => {
                try
                {
                    var returnString = translation.TranslationHtmlEx(str);
                    if (returnString["messages"].Any())
                    {
                        //取消失败
                        MessageBox.Show(this, "取消订单失败！请关闭本窗口重新来过。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }
                    else
                    {
                        DeterMineCall(() =>
                        {
                            dgvUnfinisedOrder.DataSource = null;
                            MessageBox.Show(this, "取消订单成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                    }
                }
                finally { DeterMineCall(() => { oc.HideOpaqueLayer(); }); }
            }, _cookieContainer);
        }   

        //查询订单
        private void btnSelectOrder_Click(object sender, EventArgs e)
        {
            orderSelectAction.PostData = GetPostData();
            orderSelectAction.SelectOrder((str) => {
                var returnString = translation.TranslationHtmlEx(str);
                if (returnString["messages"].Any())
                {
                    DeterMineCall(() =>
                    {
                        MessageBox.Show(this, returnString["messages"][0].ToString(), "提示", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    });
                    return;
                }
                else if (returnString["data"]["OrderDTODataList"] == null || !returnString["data"]["OrderDTODataList"].Any())
                {
                    DeterMineCall(() =>
                    {
                        MessageBox.Show(this, "没有查到有效的订单记录", "提示", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    });
                    return;
                }
                if (returnString["data"]["OrderDTODataList"] != null && returnString["data"]["OrderDTODataList"].Any())
                {
                    SetOrderSource(returnString);
                }
                else
                    DeterMineCall(() =>
                    {
                        MessageBox.Show(this, "查询失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
            }, _cookieContainer);
        }

        private void SetOrderSource(JObject returnString)
        {
            DeterMineCall(() =>
            {
                flCompletedOrder.Controls.Clear();
                for (int i = 0; i < returnString["data"]["OrderDTODataList"].Count(); i++)
                {
                    var orderData = new List<MyOrderData>();
                    var orderControl = new OrderControl();
                    orderControl.MyOrderNo = returnString["data"]["OrderDTODataList"][i]["sequence_no"].ToString();
                    orderControl.MyOrderNo += "  " + returnString["data"]["OrderDTODataList"][i]["from_station_name_page"].ToString().Replace(" ","");
                    orderControl.MyOrderNo += "-" + returnString["data"]["OrderDTODataList"][i]["to_station_name_page"].ToString().Replace(" ", "");
                    orderControl.MyOrderNo += "  " + returnString["data"]["OrderDTODataList"][i]["train_code_page"].ToString();
                    orderControl.MyOrderNo += "  " + returnString["data"]["OrderDTODataList"][i]["array_passser_name_page"].ToString().Replace(" ", "");
                    orderControl.MyOrderNo += "  " + returnString["data"]["OrderDTODataList"][i]["ticket_totalnum"].ToString() + "张";
                    orderControl.MyOrderNo += "  " + returnString["data"]["OrderDTODataList"][i]["ticket_total_price_page"].ToString() + "元";
                    orderControl.MyOrderNo = orderControl.MyOrderNo.Replace("\r\n","").Replace("\"","");
                    for (int j = 0; j < returnString["data"]["OrderDTODataList"][i]["tickets"].Count(); j++)
                    {
                        var oData = new MyOrderData(returnString, j,i,true);
                        orderData.Add(oData);
                    }
                    //orderControl.Width = 800;
                    //orderControl.Height = 500;
                    //Popup p = new Popup(orderControl);
                    //p.Show(this);
                    var bindingData = new BindingList<MyOrderData>(orderData);
                    orderControl.MyDataSource = bindingData;
                    orderControl.AutoSize = false;
                    flCompletedOrder.Controls.Add(orderControl);
                }
            });
        }

        private string GetPostData()
        {
            return string.Format("queryType={0}&queryStartDate={1}&queryEndDate={2}&come_from_flag={3}&pageSize={4}&pageIndex={5}&sequeue_train_name={6}",
                queryDataFlag, dtStartDate.Value.ToString("yyyy-MM-dd"), dtEndDate.Value.ToString("yyyy-MM-dd"), "my_order", 20, 0, txtQueryParam.Text == "订单号/车次/乘车人"?"":System.Web.HttpUtility.UrlEncode(txtQueryParam.Text));
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

        private void formOrderSelect_Shown(object sender, EventArgs e)
        {
            //ShowMessages(this, "正在加载未完成订单,请稍等...");
            lblInfo.Text = "正在加载未完成订单,请稍等...";
        }

        private void txtQueryParam_Enter(object sender, EventArgs e)
        {
            if (txtQueryParam.Text == "订单号/车次/乘车人")
            {
                txtQueryParam.Text = "";
                txtQueryParam.ForeColor = Color.Black;
            }
        }

        
        void txtQueryParam_LostFocus(object sender, EventArgs e)
        {
            if (txtQueryParam.Text == "")
            {
                txtQueryParam.Text = "订单号/车次/乘车人";
                txtQueryParam.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }
       
    }
}
