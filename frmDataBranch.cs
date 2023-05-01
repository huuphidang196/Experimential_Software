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
using Experimential_Software.DAO.DAO_LineData;

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

        protected virtual void ShowDataOnFormLineEPowerOrigin()
        {
            //get dto in Epower
            this._dtoLineEPowerRecord = this._lineEFixedData.DatabaseE.DataRecordE.DTOLineEPower;
            //Bus From And To
            DTOBusEPower dtoBusFrom = this._dtoLineEPowerRecord.DTOBusFrom;
            DTOBusEPower dtoBusTo = this._dtoLineEPowerRecord.DTOBusTo;

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
            //line R pu
            this.txtLineRPu.Text = (this._dtoLineEPowerRecord.LineR_Pu == 0) ? "0.000000" : this._dtoLineEPowerRecord.LineR_Pu + "";
            //line X pu
            this.txtLineXPu.Text = (this._dtoLineEPowerRecord.LineX_Pu == 0) ? "0.000000" : this._dtoLineEPowerRecord.LineX_Pu + "";
            //Length
            this.txtLengthBr.Text = (this._dtoLineEPowerRecord.LengthBr_KM == 0) ? "0.000" : this._dtoLineEPowerRecord.LengthBr_KM + "";
        }


        private void btnOkBr_Click(object sender, EventArgs e)
        {
            //set Data name
            this.SetBranchRecordInDataBase();

            this.DialogResult = DialogResult.OK;
        }

        protected virtual void SetBranchRecordInDataBase()
        {
            string Branch_ID = this.txtBranchID.Text;
            string Branch_Name = this.txtBranchName.Text;

            string LineR_pu = this.txtLineRPu.Text;
            string LineX_pu = this.txtLineXPu.Text;
            string Length_KM = this.txtLengthBr.Text;

            //set Branch ID         
            this._dtoLineEPowerRecord.ObjectNumber = int.Parse(Branch_ID);
            //Set Branch Name
            this._dtoLineEPowerRecord.ObjectName = Branch_Name;
            //InService
            this._dtoLineEPowerRecord.IsInService = this.chkInServiceBr.Checked;

            //*************Branch Data*************
            //txtLine R (pu)
            this._dtoLineEPowerRecord.LineR_Pu = double.Parse(LineR_pu);
            // txt Line X (pu)
            this._dtoLineEPowerRecord.LineX_Pu = double.Parse(LineX_pu);
            //txt length_Km
            this._dtoLineEPowerRecord.LengthBr_KM = double.Parse(Length_KM);

        }

        private void btnCancelbr_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EventDataIputIsNotNumber(object sender, EventArgs e)
        {
            //Get text box is Changging
            TextBox txtDataChanged = sender as TextBox;

            bool isAllValid = double.TryParse(txtDataChanged.Text, out double result);
            if (!isAllValid)
            {
                MessageBox.Show(txtDataChanged.Text + "Invalid decimal number detected!", "Request To Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataChanged.BackColor = Color.Yellow;
                txtDataChanged.Focus();
                return;
            }
            txtDataChanged.BackColor = Color.White;
        }
    }
}
