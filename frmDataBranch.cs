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
using Experimential_Software.DAO.DAO_LineData;
using Experimential_Software.BLL.BLL_ProcessBranch;

namespace Experimential_Software
{
    public partial class frmDataBranch : Form
    {
        // Require have before Initialize =>     LineEPower = 5
        protected ConnectableE _lineEFixedData;
        public ConnectableE LineEPowerFixed { set => _lineEFixedData = value; }

        //Database LineEPower Record
        protected DTOLineEPower _dtoLineEPowerRecord;

        public frmDataBranch()
        {
            InitializeComponent();
        }

        private void frmDataBranch_Load(object sender, EventArgs e)
        {
            //Set txtBranchID only allow press 3 digit => 
            this.txtBranchID.MaxLength = 3;

            if (this._lineEFixedData != null)
            {
                this.ShowDataOnFormLineEPowerOrigin();
            }
        }

        #region ShowData
        protected virtual void ShowDataOnFormLineEPowerOrigin()
        {
            //get dto in Epower
            this._dtoLineEPowerRecord = this._lineEFixedData.DatabaseE.DataRecordE.DTOLineEPower;
            //Bus From And To
            DTOBusEPower dtoBusFrom = this._dtoLineEPowerRecord.DTOBus_From;
            DTOBusEPower dtoBusTo = this._dtoLineEPowerRecord.DTOBus_To;

            this.lblBusFromNumber.Text = (dtoBusFrom == null) ? "NULL" : dtoBusFrom.ObjectNumber + "";
            this.lblBusFromName.Text = (dtoBusFrom == null) ? "NULL" : dtoBusFrom.ObjectName;

            this.lblBusToNumber.Text = (dtoBusTo == null) ? "NULL" : dtoBusTo.ObjectNumber + "";
            this.lblBusToName.Text = (dtoBusTo == null) ? "NULL" : dtoBusTo.ObjectName;

            //branch ID
            this.txtBranchID.Text = this._dtoLineEPowerRecord.ObjectNumber + "";
            //branch Name
            this.txtBranchName.Text = this._dtoLineEPowerRecord.ObjectName;

            //Check in Service
            this.chkInServiceBr.Checked = this._dtoLineEPowerRecord.IsInService;

            //************Zone Branch Data**********
            this.ShowDataImpendanceLineE();
           
        }

        protected virtual void ShowDataImpendanceLineE()
        {
            ImpedanceLineEPower impendanceLineE = this._dtoLineEPowerRecord.ImpedanceLineE;
            //line R pu
            this.txtLineRPu.Text = (impendanceLineE.LineR_Pu == 0) ? "0.000000" : impendanceLineE.LineR_Pu + "";
            //line X pu
            this.txtLineXPu.Text = (impendanceLineE.LineX_Pu == 0) ? "0.000000" : impendanceLineE.LineX_Pu + "";

            //B origin 
            this.txtChargingBPu.Text = (impendanceLineE.ChargingB_Pu == 0) ? "0.000000" : impendanceLineE.ChargingB_Pu + "";
            //line G From
            this.txtLineGFromPu.Text = (impendanceLineE.LineGFrom_Pu == 0) ? "0.000000" : impendanceLineE.LineGFrom_Pu + "";
            //line B From
            this.txtLineBFromPu.Text = (impendanceLineE.LineBFrom_Pu == 0) ? "0.000000" : impendanceLineE.LineBFrom_Pu + "";

            //line G To
            this.txtLineGToPu.Text = (impendanceLineE.LineGTo_Pu == 0) ? "0.000000" : impendanceLineE.LineGTo_Pu + "";
            //line B To
            this.txtLineBToPu.Text = (impendanceLineE.LineBTo_Pu == 0) ? "0.000000" : impendanceLineE.LineBTo_Pu + "";


            //Length
            this.txtLengthBr.Text = (impendanceLineE.LengthBr_KM == 0) ? "0.000" : impendanceLineE.LengthBr_KM + "";
        }

        #endregion ShowData

        private void btnOkBr_Click(object sender, EventArgs e)
        {
            //set Data name
            BLLProcessBranchForm.Instance.ProcessOkEvent(this, this._dtoLineEPowerRecord);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelbr_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EventDataIputIsNotNumber(object sender, EventArgs e)
        {
            BLLProcessBranchForm.Instance.EventDataIputIsNotNumber(sender, this);
        }
    }
}
