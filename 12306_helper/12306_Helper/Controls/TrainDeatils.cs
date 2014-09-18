using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aNyoNe.GetInfoFrom12306;

namespace _12306_Helper
{
    
    public partial class TrainDeatils : UserControl
    {
        SelectTicketAction selectAction = new SelectTicketAction();
        HTML_Translation translation = new HTML_Translation();
        private List<QuickTrainData> quickTrainData = new List<QuickTrainData>();

        string _from = "";
        string _to = "";
        string _trainNo="";
        string _fromStationTelcode = "";
        string _toStationTelcode = "";
        string _departDate = "";
        System.Net.CookieContainer _cookie;

        ~TrainDeatils()
        {
            GC.Collect();
            GC.Collect();
        }

        public TrainDeatils(System.Net.CookieContainer cookieContainer,string title, string from, string to, string train_no, string from_station_telecode, string to_station_telecode, string depart_date)
        {
            InitializeComponent();
            lblQuickTrainInfo.Text = title;
            _cookie = cookieContainer;
            _from = from;
            _to = to;
            _trainNo = train_no;
            _fromStationTelcode = from_station_telecode;
            _toStationTelcode = to_station_telecode;
            _departDate=depart_date;
            BindQuickTrainInfo();
        }
        private void BindQuickTrainInfo()
        {
            dgvQuickTrainInfo.DataSource = null;
            selectAction.QueryString = string.Format("train_no={0}&from_station_telecode={1}&to_station_telecode={2}&depart_date={3}",
                                                    _trainNo, _fromStationTelcode, _toStationTelcode, _departDate);
            selectAction.GetArriveStationInfo((str) =>
            {
                if (str == string.Empty || str == "")
                {
                    MessageBox.Show("加载信息失败", "加载过站信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //new MessageBoxEx("加载过站信息失败！", MessageboxExIcon.ERROR) { NewPrivateInterval = 1000 }.Show();
                    return;
                }
                translation.TranslationHtml(str, (traininfo) =>
                {
                    if (traininfo != null)
                    {
                        DeterMineCall(() =>
                        {
                            quickTrainData = traininfo;
                            dgvQuickTrainInfo.DataSource = quickTrainData;
                            DeterMineCall(() =>
                            {
                                foreach (DataGridViewRow row in dgvQuickTrainInfo.Rows)
                                {
                                    if (row.Cells[1].Value.ToString() == _from || row.Cells[1].Value.ToString() == _to)
                                    {
                                        row.DefaultCellStyle.ForeColor = Color.Blue;
                                    }
                                }
                            });
                        });
                    }
                });
            }, _cookie);
        }
        
        private void DeterMineCall(MethodInvoker method)
        {
            if (!this.IsDisposed && this.InvokeRequired)
            {
                Invoke(method);
            }
            else
                method();
        }
    }

    
}
