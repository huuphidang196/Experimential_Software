using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.BLL.BLL_ProcessGenerator;
using Experimential_Software.DTO;

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
                this.ShowDataOnFormMFEPowerOrigin();
            }
        }

        #region Show_Data_To_Show
        protected virtual void ShowDataOnFormMFEPowerOrigin()
        {
            //Get DataDTO from EPOwer
            this._dtoMFRecord = this._MF_EFixedData.DatabaseE.DataRecordE.DTOGeneEPower;

            //Set Info on group box Basic Data
            this.ShowtValueShowOnGroupBasicData();

            // Set Info Machine Data
            this.ShowValueShowOnGroupMachineData();

            //Set Transfomer Data
            this.ShowValueShowOnGroupTransformerData();

            //Set Wind Data
            this.ShowValueShowOnGroupWindData();

            //Set Plant Data
            this.ShowValueShowOnPlantData();
        }

        protected virtual void ShowtValueShowOnGroupBasicData()
        {
            DTOBusEPower dtoBusConnected = this._dtoMFRecord.DTOBusConnected;
            //Set Bus Number
            this.lblBusNumConnMF.Text = (dtoBusConnected == null) ? "NULL" : dtoBusConnected.ObjectNumber + "";
            //Set bus Name
            this.lblBusNameConnMF.Text = (dtoBusConnected == null) ? "NULL" : dtoBusConnected.ObjectName;
            //Set bus Type code 
            this.lblBusConnTypeCode.Text = (dtoBusConnected == null) ? "NULL" : ((int)dtoBusConnected.TypeCodeBus + 1) + "";
            //Set machine ID 
            this.txtMachineID.Text = this._dtoMFRecord.ObjectNumber + "";
            //Show Object Name
            this.txtMachineName.Text = this._dtoMFRecord.ObjectName;
            //Set In Service
            this.chkInService.Checked = this._dtoMFRecord.IsInService;
        }

        protected virtual void ShowValueShowOnGroupMachineData()
        {
            PowerMachineDataMF powerMachine = this._dtoMFRecord.PowerMachineMF;
            //Set Pgen
            this.txtPgen_MW.Text = powerMachine.Pgen_MW.ToString("F4");
            //Set Pmax
            this.txtPmax_MW.Text = powerMachine.Pmax_MW.ToString("F4");
            //Set Pmin
            this.txtPmin_MW.Text = powerMachine.Pmin_MW.ToString("F4");

            //Set Qgen
            this.txtQgen_Mvar.Text = powerMachine.Qgen_Mvar.ToString("F4");
            //SetQmax
            this.txtQmax_Mvar.Text = powerMachine.Qmax_Mvar.ToString("F4");
            //Set Qmin
            this.txtQmin_Mvar.Text = powerMachine.Qmin_Mvar.ToString("F4");

            //Set Mbase => Công Suất ĐM
            this.txtMbase_MVA.Text = powerMachine.MBase.ToString("F2");

            //RSource
            this.txtRSource_pu.Text = powerMachine.RSource_pu.ToString("F5");
            //XSource
            this.txtXSource_pu.Text = powerMachine.XSource_pu.ToString("F5");
        }

        protected virtual void ShowValueShowOnGroupTransformerData()
        {
            ImpedanceMBAConnected impendanceMF = this._dtoMFRecord.ImpedanceMF;
            //Set R Trans
            this.txtRTran_pu.Text = impendanceMF.RTran_pu.ToString("F5");
            //Set X Trans
            this.txtXTran_pu.Text = impendanceMF.XTran_pu.ToString("F5");
            //Set Gentap
            this.txtGentapMF.Text = impendanceMF.Gentap.ToString("F5");
        }

        protected virtual void ShowValueShowOnGroupWindData()
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

        protected virtual void ShowValueShowOnPlantData()
        {
            //Set Sched Voltage
            this.txtSchedVoltage.Text = this._dtoMFRecord.SchedVoltage.ToString("F4");
            //set Remote Bus
            this.txtRemoteBus.Text = this._dtoMFRecord.Remote_Bus.ToString();
        }

        #endregion Show_Data_To_Show

        #region Event_TextBox_Leave
        private void CheckNumberValidTextBoxEventLeave(object sender, EventArgs e)
        {
            BLLProcessGeneratorForm.Instance.CheckNumberValidTextBoxEventLeave(sender);
        }
        #endregion Event_TextBox_Leave

        #region Ok_Set_Data
        private void btnOKGene_Click(object sender, EventArgs e)
        {
            BLLProcessGeneratorForm.Instance.OK_Event_Click(this, _dtoMFRecord);
            this.DialogResult = DialogResult.OK;
        }

        #endregion Ok_Set_Data

        private void btnCancelGene_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
