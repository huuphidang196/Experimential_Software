using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.Class_Database;


namespace Experimential_Software
{
    public partial class frmDataBus : Form
    {
        // Require have before Initialize
        protected ConnectableE _busEFixedData;
        public ConnectableE BusEPowerFixed { set => _busEFixedData = value; }

        //Database Bus Record
        protected DTOBusEPower _dtoBusRecord;

        public frmDataBus()
        {
            InitializeComponent();

        }

        private void frmDataBus_Load(object sender, EventArgs e)
        {
            if (this._busEFixedData != null)
            {
                this.SetDataFormBusEPowerOrigin();
            }
        }

        #region Show_Data_Origin
        protected virtual void SetDataFormBusEPowerOrigin()
        {
            this._dtoBusRecord = this._busEFixedData.DatabaseE.DataRecordE.DTOBusEPower;

            //Show Data On Form, Data Default set at frmCapston

            //BasicData
            this.txtBusName.Text = this._dtoBusRecord.ObjectName;
            this.txtBusNumber.Text = this._dtoBusRecord.ObjectNumber + "";

            //loadCBo typeBus
            foreach (TypeCodeBus type in Enum.GetValues(typeof(TypeCodeBus)))
            {
                string typeBus = type.ToString();
                int numberType = (int)type + 1;
                this.cboTypeBus.Items.Add(numberType + " -" + typeBus);
            }
            this.cboTypeBus.SelectedIndex = (int)this._dtoBusRecord.TypeCodeBus;

            this.txtBasekV.Text = this._dtoBusRecord.BasekV + "";
            this.txtVoltageBus.Text = this._dtoBusRecord.Voltage_pu + "";
            this.txtAngleBus.Text = this._dtoBusRecord.Angle_rad + "";

            //limit Data
            this.txtNorVmax.Text = this._dtoBusRecord.Normal_Vmax_pu + "";
            this.txtNorVmin.Text = this._dtoBusRecord.Normal_Vmin_pu + "";

            this.txtEmerVmax.Text = this._dtoBusRecord.Emer_Vmax_pu + "";
            this.txtEmerVmin.Text = this._dtoBusRecord.Emer_Vmin_pu + "";
        }

        #endregion Show_Data_Origin

        #region Update_DataBase

        private void btnOKSet_Click(object sender, EventArgs e)
        {
            //set Object name
            bool isValid = this.SetObjectRecordInDataBase();
            if (!isValid) return;

            this.DialogResult = DialogResult.OK;
        }

        protected virtual bool SetObjectRecordInDataBase()
        {
            //Update database into DTO

            //------------------------------------------------------------------------------------------
            //**BasicData Zone**
            // Case txtBusNumber => if contain char diffrence number => MessageBox => Require type again.
            //------------------------------------------------------------------------------------------

            // txtBusNumber
            string strBusNumber = this.txtBusNumber.Text;
            bool isContainChar = strBusNumber.Any(c => !char.IsDigit(c));

            if (!isContainChar) this._dtoBusRecord.ObjectNumber = int.Parse(strBusNumber);
            else
            {
                MessageBox.Show("Bus Number must be an Integer!", "Request to Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //txt BusName => Busname
            this._dtoBusRecord.ObjectName = this.txtBusName.Text;

            //cbo TypeCodeBus -> typeCodebus DTO
            string enumTypeBus = this.cboTypeBus.SelectedItem.ToString().Split('-')[1];

            this._dtoBusRecord.TypeCodeBus = (TypeCodeBus)Enum.Parse(typeof(TypeCodeBus), enumTypeBus);

            //txtBaseKV => 
            this._dtoBusRecord.BasekV = double.Parse(this.txtBasekV.Text);

            //txtVoltage
            this._dtoBusRecord.Voltage_pu = double.Parse(this.txtVoltageBus.Text);

            //txtAngle
            this._dtoBusRecord.Angle_rad = double.Parse(this.txtAngleBus.Text);

            ////////////////////////////////////////////////////////////////////////////////////////

            //------------------------------------------------------------------------------------------
            //**LimitDta Zone**
            //------------------------------------------------------------------------------------------

            //txtNormal_Vmax
            double Normal_Vmax_pu = double.Parse(this.txtNorVmax.Text);
            //txtEmer Max
            double Emer_Vmax_pu = double.Parse(this.txtEmerVmax.Text);

            //txtNormal_Vmin
            double Normal_Vmin_pu = double.Parse(this.txtNorVmin.Text);
            //txtEmer Min
            double Emer_Vmin_pu = double.Parse(this.txtEmerVmin.Text);

            //Check NormalV and Emer
            if (!this.EventLeaveTextBoxLimitDataZone()) return false;

            this._dtoBusRecord.Normal_Vmax_pu = Normal_Vmax_pu;
            this._dtoBusRecord.Emer_Vmax_pu = Emer_Vmax_pu;

            this._dtoBusRecord.Normal_Vmin_pu = Normal_Vmin_pu;
            this._dtoBusRecord.Emer_Vmin_pu = Emer_Vmin_pu;

            //Set Datarecord Bus 
            this._busEFixedData.DatabaseE.DataRecordE.DTOBusEPower = this._dtoBusRecord;

            return true;
        }


        private void htnCancelBus_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Update_DataBase

        #region TextBox_LimitDataZone
        private void txtNorVmax_Leave(object sender, EventArgs e)
        {
            this.EventLeaveTextBoxLimitDataZone();
        }

        private void txtNorVmin_Leave(object sender, EventArgs e)
        {
            this.EventLeaveTextBoxLimitDataZone();
        }

        private void txtEmerVmax_Leave(object sender, EventArgs e)
        {
            this.EventLeaveTextBoxLimitDataZone();
        }
        private void txtEmerVmin_Leave(object sender, EventArgs e)
        {
            this.EventLeaveTextBoxLimitDataZone();
        }

        #endregion TextBox_LimitDataZone

        #region Func_Overrall
        protected virtual bool EventLeaveTextBoxLimitDataZone()
        {
            //txtNormal_Vmax
            double Normal_Vmax_pu = double.Parse(this.txtNorVmax.Text);
            //txtEmer Max
            double Emer_Vmax_pu = double.Parse(this.txtEmerVmax.Text);

            if (Emer_Vmax_pu < Normal_Vmax_pu)
            {
                MessageBox.Show("NormalVmax(pu) must be less EmerVmax(pu)!", "Request To Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNorVmax.BackColor = this.txtEmerVmax.BackColor = Color.Yellow;
                return false;
            }

            this.txtNorVmax.BackColor = this.txtEmerVmax.BackColor = Color.WhiteSmoke;

            //txtNormal_Vmin
            double Normal_Vmin_pu = double.Parse(this.txtNorVmin.Text);
            //txtEmer Min
            double Emer_Vmin_pu = double.Parse(this.txtEmerVmin.Text);

            if (Emer_Vmin_pu > Normal_Vmin_pu)
            {
                MessageBox.Show("NormalVmin(pu) must be Greater EmerVmin(pu)!", "Request To Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNorVmin.BackColor = this.txtEmerVmin.BackColor = Color.Yellow;
                return false;
            }
            this.txtNorVmin.BackColor = this.txtEmerVmin.BackColor = Color.WhiteSmoke;
            return true;
        }

        #endregion Func_Overrall

    }
}
