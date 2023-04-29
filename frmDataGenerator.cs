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
    public partial class frmDataGenerator : Form
    {
        // Require have before Initialize
        protected ConnectableE _MF_EFixedData;
        public ConnectableE MF_EPowerFixed { set => _MF_EFixedData = value; }

        //Database Bus Record
        protected DTOGeneEPower _dtoMFRecord;

        public frmDataGenerator()
        {
            InitializeComponent();
        }

        private void frmDataGenerator_Load(object sender, EventArgs e)
        {
            if (this._MF_EFixedData != null)
            {
                this.SetDataFormMFEPowerOrigin();
            }
        }

        #region Set_Data_To_Show
        protected virtual void SetDataFormMFEPowerOrigin()
        {
            //Get DataDTO from EPOwer
            this._dtoMFRecord = this._MF_EFixedData.DatabaseE.DataRecordE.DTOGeneEPower;

            //Set Info on group box Basic Data
            this.SetValueShowOnGroupBasicData();

            // Set Info Machine Data
            this.SetValueShowOnGroupMachineData();

            //Set Transfomer Data
            this.SetValueShowOnGroupTransformerData();

            //Set Wind Data
            this.SetValueShowOnGroupWindData();

            //Set Plant Data
            this.SetValueShowOnPlantData();
        }

        protected virtual void SetValueShowOnGroupBasicData()
        {
            DTOBusEPower dtoBusConnected = this._dtoMFRecord.DTOBusConnected;
            //Set Bus Number
            this.lblBusNumConnMF.Text = (dtoBusConnected == null) ? "NULL" : dtoBusConnected.ObjectNumber + "";
            //Set bus Name
            this.lblBusNameConnMF.Text = (dtoBusConnected == null) ? "NULL" : dtoBusConnected.ObjectName;
            //Set bus Type code 
            this.lblBusConnTypeCode.Text = (dtoBusConnected == null) ? "NULL" : ((int)dtoBusConnected.TypeCodeBus + 1) + "";
            //Set machine ID <=> Object Name
            this.txtMachineID.Text = this._dtoMFRecord.ObjectName;
            //Set In Service
            this.chkInService.Checked = this._dtoMFRecord.IsInService;
        }

        protected virtual void SetValueShowOnGroupMachineData()
        {
            //Set Pgen
            this.txtPgen_MW.Text = this._dtoMFRecord.Pgen_MW.ToString("F4");
            //Set Pmax
            this.txtPmax_MW.Text = this._dtoMFRecord.Pmax_MW.ToString("F4");
            //Set Pmin
            this.txtPmin_MW.Text = this._dtoMFRecord.Pmin_MW.ToString("F4");

            //Set Qgen
            this.txtQgen_Mvar.Text = this._dtoMFRecord.Qgen_MW.ToString("F4");
            //SetQmax
            this.txtQmax_Mvar.Text = this._dtoMFRecord.Qmax_MW.ToString("F4");
            //Set Qmin
            this.txtQmin_Mvar.Text = this._dtoMFRecord.Qmin_MW.ToString("F4");

            //Set Mbase => Công Suất ĐM
            this.txtMbase_MVA.Text = this._dtoMFRecord.MBase.ToString("F2");
        }

        protected virtual void SetValueShowOnGroupTransformerData()
        {
            //Set R Trans
            this.txtRTran_pu.Text = this._dtoMFRecord.RTran_pu.ToString("F5");
            //Set X Trans
            this.txtXTran_pu.Text = this._dtoMFRecord.XTran_pu.ToString("F5");
            //Set Gentap
            this.txtGentapMF.Text = this._dtoMFRecord.Gentap.ToString("F5");
        }

        protected virtual void SetValueShowOnGroupWindData()
        {
            //Set Control Mode
            foreach (WindMFControlMode ctrlMode in Enum.GetValues(typeof(WindMFControlMode)))
            {
                string mode = (int)ctrlMode + "-" + ctrlMode.ToString();
                this.cboControlMode.Items.Add(mode);
            }
            this.cboControlMode.SelectedIndex = (int)this._dtoMFRecord.WindCtrlMode;

            //Powwer Factor => Default is 1.000
            this.lblValuePowerFactor.Text = this._dtoMFRecord.PowerFactor.ToString("F3");
        }

        protected virtual void SetValueShowOnPlantData()
        {
            //Set Sched Voltage
            this.txtSchedVoltage.Text = this._dtoMFRecord.SchedVoltage.ToString("F4");
            //set Remote Bus
            this.txtRemoteBus.Text = this._dtoMFRecord.Remote_Bus.ToString();
        }

        #endregion Set_Data_To_Show

        private void txtDataMF_Leave(object sender, EventArgs e)
        {
            //Get text box is Changging
            TextBox txtDataChanged = sender as TextBox;

            // bool isAllValid = txtDataChanged.Text.Replace(".", "").Replace("-", "").All(c => char.IsDigit(c));
            bool isAllValid = double.TryParse(txtDataChanged.Text, out double result);
            if (!isAllValid)
            {
                MessageBox.Show(txtDataChanged.Text + " Invalid decimal number detected!!", "Request To Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataChanged.BackColor = Color.Yellow;
                txtDataChanged.Focus();
                return;
            }
            txtDataChanged.BackColor = Color.White;
        }

        #region Ok_Set_Data
        private void btnOKGene_Click(object sender, EventArgs e)
        {
            //***********Basic Data And Machine***********
            //Bus Connected is set when lineconnected Success
            this.UpdateBasicAndMachineDataForDatabaseMF();

            //***********Transformer Data************
            this.UpdateTranDataForDatabaseMF();

            //***********Wind Data And PlantData***********
            this.UpdateWindAndPlantDataForDatabaseMF();
            this.DialogResult = DialogResult.OK;
        }

        private void UpdateBasicAndMachineDataForDatabaseMF()
        {
            //Set Machine ID => Object name. DataBusConnect Set when Connect success in order to generate Line =? Peocess Mouse
            this._dtoMFRecord.ObjectName = this.txtMachineID.Text;

            // Machine Data

            //Pgen
            this._dtoMFRecord.Pgen_MW = double.Parse(this.txtPgen_MW.Text);
            //Pmax
            this._dtoMFRecord.Pmax_MW = double.Parse(this.txtPmax_MW.Text);
            //Pmin
            this._dtoMFRecord.Pmin_MW = double.Parse(this.txtPmin_MW.Text);

            //Qgen
            this._dtoMFRecord.Qgen_MW = double.Parse(this.txtQgen_Mvar.Text);
            //Qmax
            this._dtoMFRecord.Qmax_MW = double.Parse(this.txtQmax_Mvar.Text);
            //Qmin
            this._dtoMFRecord.Qmin_MW = double.Parse(this.txtQmin_Mvar.Text);

            //Mbase
            this._dtoMFRecord.MBase = double.Parse(this.txtMbase_MVA.Text);
        }

        protected virtual void UpdateTranDataForDatabaseMF()
        {
            //RTran
            this._dtoMFRecord.RTran_pu = double.Parse(this.txtRTran_pu.Text);
            //XTran
            this._dtoMFRecord.XTran_pu = double.Parse(this.txtXTran_pu.Text);
            //genTap
            this._dtoMFRecord.Gentap = double.Parse(this.txtGentapMF.Text);
        }


        protected virtual void UpdateWindAndPlantDataForDatabaseMF()
        {
            //ControlMode
            int indexCtrlMode = this.cboControlMode.SelectedIndex;
            foreach (WindMFControlMode item in Enum.GetValues(typeof(WindMFControlMode)))
            {
                if ((int)item == indexCtrlMode) this._dtoMFRecord.WindCtrlMode = item;
            }
            //Set Sched Voltage
            this._dtoMFRecord.SchedVoltage = double.Parse(this.txtSchedVoltage.Text);
            //Remote Bus
            this._dtoMFRecord.Remote_Bus = int.Parse(this.txtRemoteBus.Text);
        }
        #endregion Ok_Set_Data

        private void btnCancelGene_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
