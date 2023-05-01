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
using Experimential_Software.DAO.DAO_MBA2Data;

namespace Experimential_Software
{
    public partial class frmDataMBA2 : Form
    {
        // Require have before Initialize =>   MBA2 = 3
        protected ConnectableE _mba2_EFixedData;
        public ConnectableE MBA2EPowerFixed { set => _mba2_EFixedData = value; }

        //Database MBA2 Record
        protected DTOTransTwoEPower _dtoMBA2EPowerRecord;

        public frmDataMBA2()
        {
            InitializeComponent();
        }

        private void frmDataMBA2_Load(object sender, EventArgs e)
        {
            if (this._mba2_EFixedData != null)
            {
                this.ShowDataOnFormMBA2EPowerOrigin();
            }
        }

        protected virtual void ShowDataOnFormMBA2EPowerOrigin()
        {
            //get dto in Epower
            this._dtoMBA2EPowerRecord = this._mba2_EFixedData.DatabaseE.DataRecordE.DTOTransTwoEPower;

            //DataLine BusConnect
            this.ShowDataOnFormLineDataZone();

            //Show Power Rating and Inpendance Data
            this.ShowTransformerImpendanceData();

            //Show Voltage 
            this.ShowVoltageRatingTransfomer();

            //Show  Fixed tap and Add event for button prim and sec
            this.ShowFixedTanAndAddEventButtonEnds();

        }


        //Line Bus Connected
        protected void ShowDataOnFormLineDataZone()
        {
            //Bus From And To
            DTOBusEPower dtoBus_From = this._dtoMBA2EPowerRecord.DTOBus_From;
            DTOBusEPower dtoBus_To = this._dtoMBA2EPowerRecord.DTOBus_To;

            this.lblFromBusNum.Text = (dtoBus_From == null) ? "NULL" : dtoBus_From.ObjectNumber + "";
            this.lblFromBusName.Text = (dtoBus_From == null) ? "NULL" : dtoBus_From.ObjectName;

            this.lblToBusNum.Text = (dtoBus_To == null) ? "NULL" : dtoBus_To.ObjectNumber + "";
            this.lblToBusName.Text = (dtoBus_To == null) ? "NULL" : dtoBus_To.ObjectName;

            this.lblTransID.Text = this._dtoMBA2EPowerRecord.ObjectNumber + "";
            this.txtTransName.Text = this._dtoMBA2EPowerRecord.ObjectName;
        }

        //Power Rating and Impendance Data
        protected virtual void ShowTransformerImpendanceData()
        {
            //Power Rating
            this.txtPowerRated.Text = this._dtoMBA2EPowerRecord.PowerRated_MVA + "";

            //***********Impendance Zone**********
            ImpendanceMBA2 impenMBA2 = this._dtoMBA2EPowerRecord.Impendace_MBA2;
            //Spec R_pu
            this.txtSpecRpu.Text = (impenMBA2.SpecR_pu == 0) ? "0.000000" : impenMBA2.SpecR_pu.ToString("F6");
            //SpecX_pu
            this.txtSpecXpu.Text = (impenMBA2.SpecX_pu == 0) ? "0.000000" : impenMBA2.SpecX_pu.ToString("F6");

            //Mag_G_pu
            this.txtMagGpu.Text = (impenMBA2.MagG_pu == 0) ? "0.000000" : impenMBA2.MagG_pu.ToString("F6");

            //Mag_B_pu
            this.txtMagBpu.Text = (impenMBA2.MagB_pu == 0) ? "0.000000" : impenMBA2.MagB_pu.ToString("F6");
        }

        //Show voltage Rangting Transfomer
        protected virtual void ShowVoltageRatingTransfomer()
        {
            //Voltage data on Manual of MBA
            VoltageEnds voltageRated = this._dtoMBA2EPowerRecord.VoltageEnds_Rated;

            //Set Prim Volatage
            this.txtRatedPrimkV.Text = voltageRated.VolPrim_kV.ToString();
            //Set Sec Voltage
            this.txtRatedSeckV.Text = voltageRated.VolSec_kV.ToString();

            //Bus From And To
            DTOBusEPower dtoBus_From = this._dtoMBA2EPowerRecord.DTOBus_From;
            DTOBusEPower dtoBus_To = this._dtoMBA2EPowerRecord.DTOBus_To;
            //Set label Normal Volatage of Bus Connect
            this.lblNorBusPrimkV.Text = (dtoBus_From == null) ? "NULL" : dtoBus_From.NormalkV + "";
            this.lblNorBusSeckV.Text = (dtoBus_To == null) ? "NULL" : dtoBus_To.NormalkV + "";
        }

        //FixedTap Zone
        protected virtual void ShowFixedTanAndAddEventButtonEnds()
        {
            //Set text button Change Unit
            bool isPecentUnit = this._dtoMBA2EPowerRecord.UnitTap_Main == UnitTapMode.Percent;
            this.btnTCUnitMain.Text = (isPecentUnit) ? "% Tap" : "kV Tap";
            VoltageEnds vol_Fixed = this._dtoMBA2EPowerRecord.VoltageEnds_Fixed;
            double percentPrim = 100;
            double percentSec = 100;

            //kV Mode
            if (!isPecentUnit)
            {
                this.txtFixedPrimkV.Text = vol_Fixed.VolPrim_kV + "";
                this.txtFixedSeckV.Text = vol_Fixed.VolSec_kV + "";

                //label transfer unit have name
                this.lblTransUnit.Text = "% Tap";

                percentPrim = Math.Round(this._dtoMBA2EPowerRecord.Percent_PrimFixed - 100, 1);
                this.lblTapTransPrimFixed.Text = percentPrim + "";

                percentSec = Math.Round(this._dtoMBA2EPowerRecord.Percent_SecFixed - 100, 1);
                this.lblTapTransSecFixed.Text = percentSec + "";
                return;
            }

            //Percent Mode
            percentPrim = Math.Round(this._dtoMBA2EPowerRecord.Percent_PrimFixed - 100, 1);
            this.txtFixedPrimkV.Text = percentPrim + "";

            percentSec = Math.Round(this._dtoMBA2EPowerRecord.Percent_SecFixed - 100, 1);
            this.txtFixedSeckV.Text = percentSec + "";
          
            //label transfer unit have name
            this.lblTransUnit.Text = "kV Tap";
            this.lblTapTransPrimFixed.Text = vol_Fixed.VolPrim_kV + "";
            this.lblTapTransSecFixed.Text = vol_Fixed.VolSec_kV + "";

        }

        //AddEvent button Main Tap 
        private void btnTCUnitMain_MouseDown(object sender, MouseEventArgs e)
        {
            //Get ModeUnit Main
            UnitTapMode mode = this._dtoMBA2EPowerRecord.UnitTap_Main;
            //Set ModeUnit Main
            this._dtoMBA2EPowerRecord.UnitTap_Main = (mode == UnitTapMode.Percent) ? UnitTapMode.KV_Number : UnitTapMode.Percent;

            //Show FixedTapzone Again
            this.ShowFixedTanAndAddEventButtonEnds();
        }

        //Add Event For button Prim and Sec
        private void btnTapChangerPrimAndSecZoneFixed_MouseDown(object sender, MouseEventArgs e)
        {

        }

        #region Function_OK_Event
        private void btnOkMBA2_Click(object sender, EventArgs e)
        {
            //Set Object Name
            this._dtoMBA2EPowerRecord.ObjectName = this.txtTransName.Text;
            //Set isInservice
            this._dtoMBA2EPowerRecord.IsInService = this.chkinService.Checked;

            //********Power Rating And Impendance Zone*****
            this.SetValuePowerRatingAndImpendance();

            //********Voltage Rating*****
            this.SetValueVoltageRating();

            //********Fixed Tap*****
            this.SetValueFixedTapAfterOKEvent();

            DialogResult = DialogResult.OK;
        }

        //********Power Rating And Impendance Zone*****
        protected virtual void SetValuePowerRatingAndImpendance()
        {
            //Set Power Rated
            this._dtoMBA2EPowerRecord.PowerRated_MVA = double.Parse(this.txtPowerRated.Text);

            //Impendance
            //SpecR_pu
            double SpecR_pu = double.Parse(this.txtSpecRpu.Text);
            //SpecX_pu
            double SpecX_pu = double.Parse(this.txtSpecXpu.Text);

            //MagG_pu
            double MagG_pu = double.Parse(this.txtMagGpu.Text);
            //MagB_pu
            double MagB_pu = double.Parse(this.txtMagBpu.Text);

            ImpendanceMBA2 impenMBA2 = new ImpendanceMBA2() { SpecR_pu = SpecR_pu, SpecX_pu = SpecX_pu, MagG_pu = MagG_pu, MagB_pu = MagB_pu };
            this._dtoMBA2EPowerRecord.Impendace_MBA2 = impenMBA2;
        }

        //********Voltage Rating*****
        protected virtual void SetValueVoltageRating()
        {
            //Rated Voltage Prim
            double VolRated_Prim = double.Parse(this.txtRatedPrimkV.Text);
            //Rated Voltage Sec
            double VoltRated_Sec = double.Parse(this.txtRatedSeckV.Text);

            VoltageEnds vol_Rated = new VoltageEnds() { VolPrim_kV = VolRated_Prim, VolSec_kV = VoltRated_Sec };

            //Set Voltage Ends
            this._dtoMBA2EPowerRecord.VoltageEnds_Rated = vol_Rated;
        }

        //********Fixed Tap*****
        protected virtual void SetValueFixedTapAfterOKEvent()
        {
            
        }

        #endregion Function_OK_Event

        #region Event_Text_Changed
        private void CheckTextBoxValid(object sender, EventArgs e)
        {
            TextBox txtDataChanged = sender as TextBox;

            // bool isAllValid = txtDataChanged.Text.Replace(".", "").Replace("-", "").All(c => char.IsDigit(c));
            bool isAllValid = double.TryParse(txtDataChanged.Text, out double result);
            if (!isAllValid)
            {
                MessageBox.Show(txtDataChanged.Text + " Invalid decimal number detected!", "Request To Re-Enter Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataChanged.BackColor = Color.Yellow;
                txtDataChanged.Focus();
                return;
            }
            txtDataChanged.BackColor = Color.White;

            //If Zone Power Rated => Set value immediately
            if (!txtDataChanged.Parent.Text.Contains("Voltage Rating")) return;

            //********Voltage Rating => set in order to Fixed tap Zone use*****
            this.SetValueVoltageRating();
            // MessageBox.Show(txtDataChanged.Text);

            //When set rated => Fixed Zone is affeected by Rated. 
            this.ShowFixedTanAndAddEventButtonEnds();
        }


        #endregion Event_Text_Changed
    }

}
