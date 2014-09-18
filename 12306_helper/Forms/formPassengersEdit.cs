using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using aNyoNe.GetInfoFrom12306;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace _12306_Helper
{
    public partial class formPassengersEdit : Form
    {
        ToolTip tt = new ToolTip() { IsBalloon = true, UseFading = true, UseAnimation = true };
        CookieContainer _cookieContainer = new CookieContainer();
        HTML_Translation translation = new HTML_Translation();
        ModifyPassengerAction modifyAction = new ModifyPassengerAction();

        private delegate void delGetpassenger();//获取联系人委托
        OpaqueCommand opcmd = new OpaqueCommand(); //调用遮挡层实例化
        delGetpassenger _delGetpassenger;

        public formPassengersEdit(CookieContainer cookie)
        {
            InitializeComponent();
            _cookieContainer = cookie;
            dgvPassenger.AutoGenerateColumns = false;
        }
        //获取联系人信息(编辑)
        private void formPassengersEdit_Load(object sender, EventArgs e)
        {
            //_cookieContainer = formSelectTicket.cookieContainer;
            BeginGetPassengers();
        }

        private void BeginGetPassengers()
        {
            _delGetpassenger = new delGetpassenger(GetAllPassenger);   
            DeterMineCall(() =>
            {
                opcmd.ShowOpaqueLayer(panel1, 90, true);
            }); //遮挡层显示,要遮挡的区域，透明度，是否显示图片
            _delGetpassenger.BeginInvoke(asyGetPassengerback, null);//异步执行开始
        }

        private void asyGetPassengerback(IAsyncResult ar)
        {
            DeterMineCall(() =>
            {
                _delGetpassenger.EndInvoke(ar); //异步结束
                opcmd.HideOpaqueLayer();  //隐藏遮挡层
            });
        }
        /// <summary>
        /// 获取联系人列表
        /// </summary>
        private void GetAllPassenger()
        {    
            //System.Threading.Thread.Sleep(5000);
            /********************************更新***************************************/
            #region 获取联系人
            modifyAction.GetPassenger((str) =>
            {
                var returnString = translation.TranslationHtmlEx(str);
                if (returnString["data"]["normal_passengers"] == null)
                {
                    MessageBox.Show("获取联系人失败!\r\n" + returnString["data"]["exMsg"].ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //opcmd.HideOpaqueLayer();  //隐藏遮挡层
                    return;
                }
                var htmlTrans = new HTML_Translation();
                htmlTrans.TranslationPassengerJson(str, (passengerList) =>
                {
                    DeterMineCall(() =>
                    {
                        if (passengerList != null)
                        {
                            dgvPassenger.DataSource = passengerList;
                            //opcmd.HideOpaqueLayer();  //隐藏遮挡层
                        }
                    });

                });


            }, _cookieContainer);
            #endregion
        }


        private void DeterMineCall(MethodInvoker method)
        {
            if (InvokeRequired && !this.IsDisposed)
                Invoke(method);
            else
                method();
        }

        /// <summary>
        /// 绑定到文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPassenger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtPassengerName.Text = dgvPassenger.Rows[e.RowIndex].Cells[0].Value.ToString();
                cboTicketType.Text = dgvPassenger.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboIDType.Text = dgvPassenger.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtIDCode.Text = dgvPassenger.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMobileNO.Text = dgvPassenger.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPassengerName.Tag = dgvPassenger.Rows[e.RowIndex].DataBoundItem as Nomal_Passengers;
            }
        }
        /// <summary>
        /// 初始化编辑
        /// </summary>
        /// <param name="data">乘客信息</param>
        private void InitEditPassengerInfo(Nomal_Passengers oldPas, Nomal_Passengers newPas)
        {
            modifyAction.PostData = String.Format("passenger_name={0}&old_passenger_name={1}&passenger_id_type_code={2}&old_passenger_id_type_code={3}&passenger_id_no={4}&old_passenger_id_no={5}&mobile_no={6}&passenger_type={7}&sex_code={8}&_birthDate={9}&country_code={10}",
                System.Web.HttpUtility.UrlEncode(newPas.Passenger_name), System.Web.HttpUtility.UrlEncode(oldPas.Passenger_name), newPas.Passenger_id_type_code, oldPas.Passenger_id_type_code, newPas.Passenger_id_no, oldPas.Passenger_id_no, newPas.Mobile_no, newPas.Passenger_type, newPas.Sex_code, newPas.Born_date, newPas.Country_code);
            modifyAction.InitModifyPassenger((str) =>
            {
                var returnString = translation.TranslationHtmlEx(str);
                if (returnString["messages"].Any())
                    MessageBox.Show(returnString["messages"][0].ToString(), "更新失败", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                else if (returnString["data"]["message"] != null && returnString["data"]["message"].ToString() != "")
                {
                    MessageBox.Show(returnString["data"]["message"].ToString(), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BeginGetPassengers();
                    //GetAllPassenger();
                }

            }, _cookieContainer);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsaName(txtPassengerName.Text) && txtPassengerName.Text != "")
            {
                //MessageBox.Show("请确认乘车人姓名是否合法（姓名应为中文汉字）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tt.SetToolTip(txtPassengerName, "请确认乘车人姓名是否合法（姓名应为中文汉字）");
                tt.Show("请确认乘车人姓名是否合法（姓名应为中文汉字）", txtPassengerName, 2500);
                return;
            }
            if (!IsIDCardNo(txtIDCode.Text) && txtIDCode.Text != "")
            {
                //MessageBox.Show("请确认身份证号填写正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tt.SetToolTip(txtIDCode, "请确认身份证号填写正确");
                tt.Show("请确认身份证号填写正确", txtIDCode, 2500);
                return;
            }
            if (txtMobileNO.Text != "" && !IsPhoneNum(txtMobileNO.Text))
            {
                //MessageBox.Show("请确认手机号码格式正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tt.SetToolTip(txtMobileNO, "请确认手机号码格式正确");
                tt.Show("请确认手机号码格式正确", txtMobileNO, 2500);
                return;
            }

            if (txtPassengerName.Tag != null)
            {
                var oldPassenger = (Nomal_Passengers)txtPassengerName.Tag;
                var passenger = oldPassenger.CloneNomalPassengers();
                passenger.Passenger_name = txtPassengerName.Text.Trim();//姓名
                passenger.Passenger_id_type_code = DatasList.TicketType[string.Format("{0}票", cboTicketType.Text)].ToString();//票种
                passenger.Passenger_id_no = txtIDCode.Text.Trim(); //证件号
                passenger.Passenger_type = DatasList.CardType[cboIDType.Text].ToString(); //证件类型
                passenger.Mobile_no = txtMobileNO.Text.Trim(); //手机
                passenger.Born_date = txtIDCode.Text.Length > 14 ? string.Format("{0}-{1}-{2}", txtIDCode.Text.Substring(6, 4), txtIDCode.Text.Substring(10, 2), txtIDCode.Text.Substring(12, 2)) : passenger.Born_date;//生日
                InitEditPassengerInfo(oldPassenger, passenger);
            }
        }

        private bool IsPhoneNum(string str)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(str, "1[3458]\\d{9}"))
                return true;
            return false;
        }

        private bool IsaName(string str)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(str, "[\\u4E00-\\u9FFF\\SA-Za-z]{2,30}"))
                return true;
            return false;
        }

        private bool IsIDCardNo(string str)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(str, "\\d{18}|\\d{14}[Xx]|\\d{16}"))
                return true;
            return false;
        }

        /// <summary>
        /// 添加联系人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPassengerName.Text == "" && txtIDCode.Text == "") return;
            if (!IsaName(txtPassengerName.Text) && txtPassengerName.Text != "")
            {
                //MessageBox.Show("请确认乘车人姓名是否合法（姓名应为中文汉字）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tt.SetToolTip(txtPassengerName, "请确认乘车人姓名是否合法（姓名应为中文汉字）");
                tt.Show("请确认乘车人姓名是否合法（姓名应为中文汉字）", txtPassengerName, 2500);
                return;
            }
            if (!IsIDCardNo(txtIDCode.Text) && txtIDCode.Text != "")
            {
                //MessageBox.Show("请确认身份证号填写正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tt.SetToolTip(txtIDCode, "请确认身份证号填写正确");
                tt.Show("请确认身份证号填写正确", txtIDCode, 2500);
                return;
            }
            if (txtMobileNO.Text != "" && !IsPhoneNum(txtMobileNO.Text))
            {
                //MessageBox.Show("请确认手机号码格式正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tt.SetToolTip(txtMobileNO, "请确认手机号码格式正确");
                tt.Show("请确认手机号码格式正确", txtMobileNO, 2500);
                return;
            }
            var passenger = new Nomal_Passengers();
            passenger.Passenger_name = txtPassengerName.Text.Trim();//姓名
            passenger.Born_date = txtIDCode.Text.Length > 14 ? string.Format("{0}-{1}-{2}", txtIDCode.Text.Substring(6, 4), txtIDCode.Text.Substring(10, 2), txtIDCode.Text.Substring(12, 2)) : passenger.Born_date;//生日
            passenger.Country_code = "CN";
            passenger.Passenger_id_type_code = DatasList.TicketType[string.Format("{0}票", cboTicketType.Text)].ToString();//票种
            passenger.Passenger_type = DatasList.CardType[cboIDType.Text].ToString(); //证件类型
            passenger.Passenger_id_no = txtIDCode.Text.Trim(); //证件号
            passenger.Sex_code = int.Parse(passenger.Passenger_id_no.Substring(passenger.Passenger_id_no.Length - 2, 1)) / 2 == 0 ? "F" : "M";
            passenger.Mobile_no = txtMobileNO.Text.Trim(); //手机
            AddPassengerInfo(passenger);
        }
        /// <summary>
        /// 添加联系人
        /// </summary>
        /// <param name="data">联系人信息</param>
        private void AddPassengerInfo(Nomal_Passengers data)
        {
            modifyAction.PostData = String.Format("passenger_name={0}&sex_code={1}&_birthDate={2}&country_code={3}&passenger_id_type_code={4}&passenger_id_no={5}&mobile_no={6}&passenger_type={7}",
                            System.Web.HttpUtility.UrlEncode(data.Passenger_name), data.Sex_code, data.Born_date, data.Country_code, data.Passenger_id_type_code, data.Passenger_id_no, data.Mobile_no, data.Passenger_type);
            modifyAction.InitAddPassenger((str) =>
            {
                var returnString = translation.TranslationHtmlEx(str);
                if (returnString["messages"].Any())
                {
                    MessageBox.Show(returnString["messages"][0].ToString(), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (returnString["data"]["message"] != null && returnString["data"]["message"].ToString() != "")
                {
                    MessageBox.Show(returnString["data"]["message"].ToString(), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("添加联系人成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //GetAllPassenger();
                    BeginGetPassengers();
                }

            }, _cookieContainer);
        }

        private void AddCustomCellStyle(DataGridViewCellPaintingEventArgs e)
        {
            // 绘制背景色
            using (LinearGradientBrush backbrush =
                new LinearGradientBrush(e.CellBounds,
                    ProfessionalColors.MenuItemPressedGradientBegin,
                    ProfessionalColors.MenuItemPressedGradientMiddle
                    , LinearGradientMode.Vertical))
            {

                Rectangle border = e.CellBounds;
                border.Width += 2;
                border.X -= 1;
                //填充绘制效果
                e.Graphics.FillRectangle(backbrush, border);
                //绘制Column、Row的Text信息
                e.PaintContent(e.CellBounds);
                //绘制边框
                ControlPaint.DrawBorder3D(e.Graphics, border, Border3DStyle.Etched);
            }
        }


        private void dgvPassenger_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //如果是Column
            if (e.RowIndex == -1)
            {
                AddCustomCellStyle(e);
                e.Handled = true;
                //如果是Rowheader
            }
            else if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                AddCustomCellStyle(e);
                e.Handled = true;
            }
            else
            {
                string text=dgvPassenger.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (text == "已通过" || text == "预通过")
                {
                    dgvPassenger.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.ForestGreen;
                }
                else if(text=="未通过")
                    dgvPassenger.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.DarkRed;
                else if(text=="待核验")
                    dgvPassenger.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.DarkOrange;
            }
        }

        private void dgvPassenger_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //是否是选中状态
            if ((e.State & DataGridViewElementStates.Selected) ==
                        DataGridViewElementStates.Selected)
            {
                // 计算选中区域Size
                int width = dgvPassenger.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);// +dgvPassenger.Width - 2;

                Rectangle rowBounds = new Rectangle(
                  0, e.RowBounds.Top, width,
                    e.RowBounds.Height - 1);

                // 绘制选中背景色
                using (LinearGradientBrush backbrush =
                    new LinearGradientBrush(rowBounds,
                        Color.Wheat,
                        Color.BurlyWood, 90.0f))
                {
                    e.Graphics.FillRectangle(backbrush, rowBounds);
                    e.PaintCellsContent(rowBounds);
                    e.Handled = true;
                }
            }
            
        }

        private void dgvPassenger_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int width = dgvPassenger.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);// +dgvPassenger.Width - 2;
            Rectangle rowBounds = new Rectangle(
                   0, e.RowBounds.Top, width, e.RowBounds.Height - 1);

            if (dgvPassenger.CurrentCellAddress.Y == e.RowIndex)
            {
                //设置选中边框
                e.DrawFocus(rowBounds, true);
            }
        }

        private void dgvPassenger_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dgvPassenger_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1 && dgvPassenger.Rows.Count > 0)
            {
                var passenger = dgvPassenger.Rows[e.RowIndex].DataBoundItem as Nomal_Passengers;
                dgvPassenger.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = passenger.Information;
            }
        }

    }
}
