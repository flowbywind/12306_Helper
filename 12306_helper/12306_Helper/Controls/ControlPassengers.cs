using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aNyoNe.GetInfoFrom12306;
using System.Collections;
using PopupControl;

namespace _12306_Helper
{
    public partial class ControlPassengers : UserControl
    {
        private BindingList<Nomal_Passengers> dataSource;
        private List<Nomal_Passengers> _autoPassengers = new List<Nomal_Passengers>();
        private Hashtable _autoQuickPassengers = new Hashtable();
        public List<Nomal_Passengers> AutoPassengers
        {
            set { _autoPassengers = value; }
            get { return _autoPassengers; }
        }

        ~ControlPassengers()
        {
            GC.Collect();
            GC.Collect();
        }

        public ControlPassengers(List<Nomal_Passengers> passengers,Hashtable quickPassengers)
        {
            InitializeComponent();
            dgvPassenger.AutoGenerateColumns = false;
            _autoPassengers = passengers;
            _autoQuickPassengers = quickPassengers;
            dataSource = new BindingList<Nomal_Passengers>(_autoPassengers);
        }

        private void ControlPassengers_Load(object sender, EventArgs e)
        {
            DetermineCall(() => { dgvPassenger.DataSource = dataSource; });
        }

        
        void DetermineCall(MethodInvoker method)
        {
            if (!this.IsDisposed && this.InvokeRequired)
                Invoke(method);
            else
                method();
        }

        private void dgvPassenger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1&&e.ColumnIndex<=1)
            {
                var passenger = dgvPassenger.Rows[e.RowIndex].DataBoundItem as Nomal_Passengers;
                passenger.IsCheck = !passenger.IsCheck;
                if (_autoPassengers.Where(x => x.IsCheck).Select(x => x).ToList<Nomal_Passengers>().Count > 5)
                {
                    passenger.IsCheck = false;
                }
                if (passenger.IsCheck)
                {
                    if (!_autoQuickPassengers.ContainsKey(String.Format("{0}|{1}", passenger.Passenger_name, passenger.Passenger_id_no)))
                        _autoQuickPassengers.Add(String.Format("{0}|{1}", passenger.Passenger_name, passenger.Passenger_id_no), passenger);
                }
                else
                {
                    if (_autoQuickPassengers.ContainsKey(String.Format("{0}|{1}", passenger.Passenger_name, passenger.Passenger_id_no)))
                        _autoQuickPassengers.Remove(String.Format("{0}|{1}", passenger.Passenger_name, passenger.Passenger_id_no));
                }
                dgvPassenger.Refresh();
            }
        }

        private void dgvPassenger_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvPassenger.BeginEdit(false);
                var passenger = dgvPassenger.Rows[e.RowIndex].DataBoundItem as Nomal_Passengers;
                passenger.IsCheck = !passenger.IsCheck;
                if (_autoPassengers.Where(x => x.IsCheck).Select(x => x).ToList<Nomal_Passengers>().Count > 5)
                {
                    passenger.IsCheck = false;
                    dgvPassenger.RefreshEdit();
                }
                if (passenger.IsCheck)
                {
                    if (!_autoQuickPassengers.ContainsKey(String.Format("{0}|{1}", passenger.Passenger_name, Passenger_id_no)))
                        _autoQuickPassengers.Add(String.Format("{0}|{1}", passenger.Passenger_name, Passenger_id_no), passenger);
                }
                else
                {
                    if (_autoQuickPassengers.ContainsKey(String.Format("{0}|{1}", passenger.Passenger_name, Passenger_id_no)))
                        _autoQuickPassengers.Remove(String.Format("{0}|{1}", passenger.Passenger_name, Passenger_id_no));
                }
                dgvPassenger.EndEdit();
                dgvPassenger.Refresh();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((Popup)this.Parent).Close();
        }

        private void dgvPassenger_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var passenger = dgvPassenger.Rows[e.RowIndex].DataBoundItem as Nomal_Passengers;
                if (passenger.Information != "")
                    dgvPassenger.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
