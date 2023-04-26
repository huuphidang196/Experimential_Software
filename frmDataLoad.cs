﻿using System;
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
            this.txtLoadID.MaxLength = 2;

            if (this._loadEPowerFixed != null)
            {
                this.SetDataFormLoadEPowerOrigin();
            }
        }

        protected virtual void SetDataFormLoadEPowerOrigin()
        {
            this._dtoLoadRecord = this._loadEPowerFixed.DatabaseE.DataRecordE.DTOLoadEPower;

            DTOBusEPower dtoBusConnected = this._dtoLoadRecord.DTOBusConnected;

            //Name bus that Load is connected
            this.lblBusNameConn.Text = (dtoBusConnected != null) ? dtoBusConnected.ObjectName : "NULL";
            //Number bus that Load is connected
            this.lblBusNumberConn.Text = (dtoBusConnected != null) ? dtoBusConnected.ObjectNumber + "" : "NULLL";

            //Load ID text
            this.txtLoadID.Text = this._dtoLoadRecord.ObjectName;

            //PLoad
            this.txtPLoad.Text = this._dtoLoadRecord.PLoad + "";
            //QlOad
            this.txtQLoad.Text = this._dtoLoadRecord.QLoad + "";
        }

        private void btnOKLoad_Click(object sender, EventArgs e)
        {
            //load ID
            this._dtoLoadRecord.ObjectName = this.txtLoadID.Text;
            //PLoad
            this._dtoLoadRecord.PLoad = double.Parse(this.txtPLoad.Text);
            //QLoad 
            this._dtoLoadRecord.QLoad = double.Parse(this.txtQLoad.Text);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelLoad_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
