using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.BLL.BLL_ProcessLoad;
using Experimential_Software.DTO;

namespace Experimential_Software
{
    public partial class frmDataLoad : Form
    {
        // Require have before Initialize
        protected ConnectableE _loadEPowerFixed;
        public ConnectableE LoadEPowerFixed { set => _loadEPowerFixed = value; }

        //Database Load Record
        protected DTOLoadEPower _dtoLoadRecord;

        public frmDataLoad()
        {
            InitializeComponent();
        }

        private void frmDataLoad_Load(object sender, EventArgs e)
        {
            //Limit char count in Load ID
            this.txtLoadID.MaxLength = 3;

            if (this._loadEPowerFixed != null)
            {
                this.ShowDataOnFormLoadEPowerOrigin();
            }
        }

        protected virtual void ShowDataOnFormLoadEPowerOrigin()
        {
            this._dtoLoadRecord = this._loadEPowerFixed.DatabaseE.DataRecordE.DTOLoadEPower;

            DTOBusEPower dtoBusConnected = this._dtoLoadRecord.DTOBusConnected;

            //Name bus that Load is connected
            this.lblBusNameConn.Text = (dtoBusConnected != null) ? dtoBusConnected.ObjectName : "NULL";
            //Number bus that Load is connected
            this.lblBusNumberConn.Text = (dtoBusConnected != null) ? dtoBusConnected.ObjectNumber + "" : "NULLL";

            //Load ID text
            this.txtLoadID.Text = this._dtoLoadRecord.ObjectName;

            //In Service
            this.chkInService.Checked = this._dtoLoadRecord.IsInService;

            //PLoad
            this.txtPLoad.Text = (this._dtoLoadRecord.PLoad == 0) ? "0.0000" : this._dtoLoadRecord.PLoad + "";
            //QlOad
            this.txtQLoad.Text = (this._dtoLoadRecord.QLoad == 0) ? "0.0000" : this._dtoLoadRecord.QLoad + "";
        }

        private void btnOKLoad_Click(object sender, EventArgs e)
        {
            BLLProcessLoadForm.Instance.EventOKLoad_Click(this, this._dtoLoadRecord);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelLoad_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //textBox data is number
        private void EventTextDataInputIsNotNumber(object sender, EventArgs e)
        {
            BLLProcessLoadForm.Instance.EventTextDataInputIsNotNumber(sender, e);
        }
    }
}
