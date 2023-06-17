using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.DTO;
using Experimential_Software.DAO.DAO_BusData;
using Experimential_Software.BLL.BLL_ProcessBus;

namespace Experimential_Software
{
    public partial class frmDataBus : Form
    {
        // Require have before Initialize
        protected ConnectableE _busEFixedData;
        public ConnectableE BusEPowerFixed { get => _busEFixedData; set => _busEFixedData = value; }

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
                this.ShowDataOnFormBusEPowerOrigin();
            }
        }

        #region Show_Data_Origin
        protected virtual void ShowDataOnFormBusEPowerOrigin()
        {
            this._dtoBusRecord = this._busEFixedData.DatabaseE.DataRecordE.DTOBusEPower;

            //Show Data On Form, Data Default set at frmCapston

            //BasicData
            this.txtBusName.Text = this._dtoBusRecord.ObjectName;
            this.txtBusNumber.Text = this._dtoBusRecord.ObjectNumber + "";

            //loadCBo typeBus
            BLLProcessBusForm.Instance.AddItemForComboboxCBOTypeBus(this.cboTypeBus);
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
            BLLProcessBusForm.Instance.OK_ClickEvent(this, this._dtoBusRecord);
            this.DialogResult = DialogResult.OK;
        }

       
        private void htnCancelBus_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Update_DataBase

      

        private void EventInputTextDataIsNotNumber(object sender, EventArgs e)
        {
            BLLProcessBusForm.Instance.EventInputTextDataIsNotNumber(sender, e, this);
           
        }
    }
}
