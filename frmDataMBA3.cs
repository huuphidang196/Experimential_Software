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
using Experimential_Software.DAO.DAO_MBA3Data;

namespace Experimential_Software
{
    public partial class frmDataMBA3 : Form
    {
        protected ConnectableE _mba3PEPower;
        public ConnectableE MBA3EPowerFixed { get => _mba3PEPower; set => _mba3PEPower = value; }

        protected DTOTransThreeEPower _dtoMBA3P;

        //temp
        protected UnitTapMode _unitModeMain = UnitTapMode.Percent;

        //percent Fixed temp
        protected double _perFixedPrimTemp_100 = 1;
        protected double _perFixedTerTemp_100 = 0;
        protected double _perFixedSecTemp_100 = 0;

        public frmDataMBA3()
        {
            InitializeComponent();
        }

        private void frmDataMBA3_Load(object sender, EventArgs e)
        {
            if (this._mba3PEPower != null)
            {
                this._dtoMBA3P = this._mba3PEPower.DatabaseE.DataRecordE.DTOTransThreeEPower;
                this._unitModeMain = this._dtoMBA3P.UnitTap_Main;

                this._perFixedPrimTemp_100 = Math.Round((this._dtoMBA3P.Percent_PrimFixed - 1) * 100, 4);
                this._perFixedTerTemp_100 = Math.Round((this._dtoMBA3P.Percent_TerFixed - 1) * 100, 4);
                this._perFixedSecTemp_100 = Math.Round((this._dtoMBA3P.Percent_SecFixed - 1) * 100, 4);
                //Show Zone Basic Data
                this.ShowZoneBasicDataTransformer3P();

                //Transformer Impedance Data
                this.ShowTransformerImpedanceData();

                //Transformer Data
                this.ShowTransformerData();

                //Fixed Tap
                this.ShowFixedTapWheOpenForm();
            }
        }


        #region Show_Data

        //Basic Data
        protected virtual void ShowZoneBasicDataTransformer3P()
        {
            //Bus Priom
            DTOBusEPower dtoBusPrim = this._dtoMBA3P.DTOBus_From;
            lblBusNumberW1.Text = (dtoBusPrim == null) ? "NULL" : dtoBusPrim.ObjectNumber + "";
            lblBusNameW1.Text = (dtoBusPrim == null) ? "NULL" : dtoBusPrim.ObjectName;

            //Bus Tertiary
            DTOBusEPower dtoBusTer = this._dtoMBA3P.DTOBus_Ter;
            lblBusNumberW2.Text = (dtoBusTer == null) ? "NULL" : dtoBusTer.ObjectNumber + "";
            lblBusNameW2.Text = (dtoBusTer == null) ? "NULL" : dtoBusTer.ObjectName;

            //Bus Sec
            DTOBusEPower dtoBusSec = this._dtoMBA3P.DTOBus_To;
            lblBusNumberW3.Text = (dtoBusSec == null) ? "NULL" : dtoBusSec.ObjectNumber + "";
            lblBusNameW3.Text = (dtoBusSec == null) ? "NULL" : dtoBusSec.ObjectName;

            //MBA3
            this.txtTrans3PNumber.Text = this._dtoMBA3P.ObjectNumber + "";
            this.txtTrans3PName.Text = this._dtoMBA3P.ObjectName;

            //Cbo InService
            this.cboInService.SelectedIndex = this._dtoMBA3P.Index_InService;

            //ShowTransforemer Data BusConnect With Transformer3P
            this.lblNormalkV_Prim.Text = (dtoBusPrim == null) ? "NULL" : dtoBusPrim.U_NormalkV + "";
            this.lblNormalkV_Ter.Text = (dtoBusTer == null) ? "NULL" : dtoBusTer.U_NormalkV + "";
            this.lblNormalkV_Sec.Text = (dtoBusSec == null) ? "NULL" : dtoBusSec.U_NormalkV + "";
        }

        //Impedance Data
        protected virtual void ShowTransformerImpedanceData()
        {
            //Prim RX
            SpecImpedanceMBA3RX SpecRX_Prim = this._dtoMBA3P.Impendance_MBA3.SpecRX_Prim;
            this.txtSpecR_Prim.Text = SpecRX_Prim.SpecR_pu.ToString("F6");
            this.txtSpecX_Prim.Text = SpecRX_Prim.SpecX_pu.ToString("F6");

            //Tertiary RX
            SpecImpedanceMBA3RX SpecRX_Ter = this._dtoMBA3P.Impendance_MBA3.SpecRX_Ter;
            this.txtSpecR_Ter.Text = SpecRX_Ter.SpecR_pu.ToString("F6");
            this.txtSpecX_Ter.Text = SpecRX_Ter.SpecX_pu.ToString("F6");

            //Sec RX
            SpecImpedanceMBA3RX SpecRX_Sec = this._dtoMBA3P.Impendance_MBA3.SpecRX_Sec;
            this.txtSpecR_Sec.Text = SpecRX_Sec.SpecR_pu.ToString("F6");
            this.txtSpecX_Sec.Text = SpecRX_Sec.SpecX_pu.ToString("F6");

            //Go, Bo
            this.txtMagG.Text = this._dtoMBA3P.Impendance_MBA3.MagG_pu.ToString("F6");
            this.txtMagB.Text = this._dtoMBA3P.Impendance_MBA3.MagB_pu.ToString("F6");
        }

        //Transformer Data
        protected virtual void ShowTransformerData()
        {
            // Get BaseMVA 3 Winding
            Transformer3PBaseMVA Base_MVA = this._dtoMBA3P.Trans3Winding_MVABase;

            //Winding Prim 
            this.txtBaseMVA_Prim.Text = Base_MVA.BaseMVA_Prim.ToString("F2");
            //Winding Tertiary 
            this.txtBaseMVA_Ter.Text = Base_MVA.BaseMVA_Ter.ToString("F2");
            //Winding Sec
            this.txtBaseMVA_Sec.Text = Base_MVA.BaseMVA_Sec.ToString("F2");

            //Get Volatage Rated kV
            VoltageEnds3P Vol_Rated = this._dtoMBA3P.VoltageEnds_kV_Rated;
            //kV_ Norminal
            this.txtRatedkV_Prim.Text = Vol_Rated.VolPrim_kV.ToString("F3");
            this.txtRatedkV_Ter.Text = Vol_Rated.VolTer_kV.ToString("F3");
            this.txtRatedkV_Sec.Text = Vol_Rated.VolSec_kV.ToString("F4");

        }

        //Fixed Tap
        protected virtual void ShowFixedTapWheOpenForm()
        {
            //Separate in order to txtLeave use
            this.ShowFixedVolatgeKVBySpecVoltage(this._dtoMBA3P.VoltageEnds_kV_Fixed);

            //Description
            this.rtbDescription.Text = this._dtoMBA3P.Description;
        }

        protected virtual void ShowFixedVolatgeKVBySpecVoltage(VoltageEnds3P voltageFixed3P)
        {
            //btnTransTap
            this.btnTransUnit.Text = (this._unitModeMain == UnitTapMode.Percent) ? "% Tap" : "kV Tap";

            //lblTransUnit
            this.lblTransUnit.Text = (this._unitModeMain == UnitTapMode.Percent) ? "kV Tap" : "% Tap";

            //Voltage Fixed Prim

            this.txtVolFixedPrim.Text = (this._unitModeMain == UnitTapMode.Percent) ? this._perFixedPrimTemp_100.ToString("F4") : voltageFixed3P.VolPrim_kV.ToString("F3");
            //Tertiary

            this.txtVolFixedTer.Text = (this._unitModeMain == UnitTapMode.Percent) ? this._perFixedTerTemp_100.ToString("F4") : voltageFixed3P.VolTer_kV.ToString("F3");
            //Sec

            this.txtVolFixedSec.Text = (this._unitModeMain == UnitTapMode.Percent) ? this._perFixedSecTemp_100.ToString("F4") : voltageFixed3P.VolSec_kV.ToString("F3");

            //lblTrans Fixed
            this.lblTransPrim.Text = (this._unitModeMain == UnitTapMode.Percent) ? voltageFixed3P.VolPrim_kV.ToString("F3") : this._perFixedPrimTemp_100.ToString("F4");
            //Tertiary
            this.lblTransTer.Text = (this._unitModeMain == UnitTapMode.Percent) ? voltageFixed3P.VolTer_kV.ToString("F3") : this._perFixedTerTemp_100.ToString("F4");
            //Sec
            this.lblTransSec.Text = (this._unitModeMain == UnitTapMode.Percent) ? voltageFixed3P.VolSec_kV.ToString("F3") : this._perFixedSecTemp_100.ToString("F4");

            //Per unit
            //Prim
            this.lblPerUnitPrim.Text = (1 + this._perFixedPrimTemp_100 / 100).ToString("F3");
            //Ter
            this.lblPerUnitTer.Text = (1 + this._perFixedTerTemp_100 / 100).ToString("F3");
            //Sec
            this.lblPerUnitSec.Text = (1 + this._perFixedSecTemp_100 / 100).ToString("F3");
        }

        #endregion Show_Data

        #region Leave_TextBox
        //OVerall for Impedance, objectMBA3P, Volatage
        private void TextBoxLeaveValidNumber(object sender, EventArgs e)
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
        }
        //Voltage Rated
        private void TextBoxRatedLeave(object sender, EventArgs e)
        {
            //Check Valid number
            this.TextBoxLeaveValidNumber(sender, e);

            //Show Again Fixed Zone when voltage rated changed
            this.ProcessEventVoltageFixedChange();
        }

        //Apply for VoltageFixed
        private void TextBoxVolFixed_Leave(object sender, EventArgs e)
        {
            //Check Valid number
            this.TextBoxLeaveValidNumber(sender, e);

            // Valid => Show Again Voltage Fixed
            this.ProcessEventVoltageFixedChange();

        }

        protected virtual void ProcessEventVoltageFixedChange()
        {
            this.SetPercentTemp();

            this.SetVoltageFixed();           
         //   MessageBox.Show("Fixed Prim = " + voltageFixed3P.VolPrim_kV + ", Ter = " + voltageFixed3P.VolTer_kV + ", Sec = " + voltageFixed3P.VolSec_kV);s          
        }

        protected virtual void SetVoltageFixed()
        {
            //Show Again Fixed Zone when voltage rated changed
            VoltageEnds3P voltageRated3P = DAOGeneMBA3Record.Instance.GenerateVoltageEndsByText(txtRatedkV_Prim.Text, txtRatedkV_Ter.Text, txtRatedkV_Sec.Text);
            VoltageEnds3P voltageFixed3P = DAOGeneMBA3Record.Instance.GenerateVoltageEndsFixedByUnitMode(this._perFixedPrimTemp_100, this._perFixedTerTemp_100, this._perFixedSecTemp_100, voltageRated3P);
            this.ShowFixedVolatgeKVBySpecVoltage(voltageFixed3P);
        }

        protected virtual void SetPercentTemp()
        {
            //Set Per temp in order to Show VoltageFixed Use
            this._perFixedPrimTemp_100 = DAOGeneMBA3Record.Instance.GetPercentVoltageFixedDisplayOneHundredPercent(this.txtVolFixedPrim.Text, this.txtRatedkV_Prim.Text, this._unitModeMain);
            this._perFixedTerTemp_100 = DAOGeneMBA3Record.Instance.GetPercentVoltageFixedDisplayOneHundredPercent(this.txtVolFixedTer.Text, this.txtRatedkV_Ter.Text, this._unitModeMain);
            this._perFixedSecTemp_100 = DAOGeneMBA3Record.Instance.GetPercentVoltageFixedDisplayOneHundredPercent(this.txtVolFixedSec.Text, this.txtRatedkV_Sec.Text, this._unitModeMain);
        }

        #endregion Leave_TextBox

        #region OK_Event_Set_Data
        private void btnOK_Click(object sender, EventArgs e)
        {
            //Set Zone Basic Data
            this.SetZoneBasicData();
            //Transformer Impedance Data
            this.SetZoneImpedanceData();
            //Set Zone Transformer Data
            this.SetZoneTransformerData();
            //SetZone Fixed Tap
            this.SetZoneFixedTap();
            //Descreiption
            this._dtoMBA3P.Description = this.rtbDescription.Text;

            DialogResult = DialogResult.OK;
        }


        protected virtual void SetZoneBasicData()
        {
            //this MBA3P
            //Object Number
            this._dtoMBA3P.ObjectNumber = int.Parse(this.txtTrans3PNumber.Text);
            //Object Name
            this._dtoMBA3P.ObjectName = this.txtTrans3PName.Text;
            //Set index  InService
            this._dtoMBA3P.Index_InService = this.cboInService.SelectedIndex;
        }

        protected virtual void SetZoneImpedanceData()
        {
            //SpecRX Prim
            double SpecR_Prim = double.Parse(this.txtSpecR_Prim.Text);
            double SpecX_Prim = double.Parse(this.txtSpecX_Prim.Text);
            SpecImpedanceMBA3RX SpecPrim = DAOGeneMBA3Record.Instance.GenerateSpecRX(SpecR_Prim, SpecX_Prim);
            this._dtoMBA3P.Impendance_MBA3.SpecRX_Prim = SpecPrim;

            //SpecRX Tertiary
            double SpecR_Ter = double.Parse(this.txtSpecR_Ter.Text);
            double SpecX_Ter = double.Parse(this.txtSpecX_Ter.Text);
            SpecImpedanceMBA3RX SpecTer = DAOGeneMBA3Record.Instance.GenerateSpecRX(SpecR_Ter, SpecX_Ter);
            this._dtoMBA3P.Impendance_MBA3.SpecRX_Ter = SpecTer;

            //SpecRX Sec
            double SpecR_Sec = double.Parse(this.txtSpecR_Sec.Text);
            double SpecX_Sec = double.Parse(this.txtSpecX_Sec.Text);
            SpecImpedanceMBA3RX SpecSec = DAOGeneMBA3Record.Instance.GenerateSpecRX(SpecR_Sec, SpecX_Sec);
            this._dtoMBA3P.Impendance_MBA3.SpecRX_Sec = SpecSec;

            //Mag G,B
            double MagG = double.Parse(this.txtMagG.Text);
            double MagB = double.Parse(this.txtMagB.Text);
            this._dtoMBA3P.Impendance_MBA3.MagG_pu = MagG;
            this._dtoMBA3P.Impendance_MBA3.MagB_pu = MagB;

        }

        protected virtual void SetZoneTransformerData()
        {
            //MVA base Prim
            this._dtoMBA3P.Trans3Winding_MVABase.BaseMVA_Prim = double.Parse(this.txtBaseMVA_Prim.Text);
            //MVA base Ter
            this._dtoMBA3P.Trans3Winding_MVABase.BaseMVA_Ter = double.Parse(this.txtBaseMVA_Ter.Text);
            //MVA base Sec 
            this._dtoMBA3P.Trans3Winding_MVABase.BaseMVA_Sec = double.Parse(this.txtBaseMVA_Sec.Text);

            //Volatage Rated
            double vol_ratedPrim = double.Parse(this.txtRatedkV_Prim.Text);
            double vol_ratedTer = double.Parse(this.txtRatedkV_Ter.Text);
            double vol_ratedSec = double.Parse(this.txtRatedkV_Sec.Text);
            this._dtoMBA3P.VoltageEnds_kV_Rated = DAOGeneMBA3Record.Instance.GenerateVoltageEndsByNumber(vol_ratedPrim, vol_ratedTer, vol_ratedSec);

        }

        protected virtual void SetZoneFixedTap()
        {
            this._dtoMBA3P.UnitTap_Main = this._unitModeMain;
            //Only Save Per for Fixed Tap
            if (this._unitModeMain == UnitTapMode.Percent)
            {
                this._dtoMBA3P.Percent_PrimFixed = 1 + double.Parse(this.txtVolFixedPrim.Text) / 100;
                this._dtoMBA3P.Percent_TerFixed = 1 + double.Parse(this.txtVolFixedTer.Text) / 100;
                this._dtoMBA3P.Percent_SecFixed = 1 + double.Parse(this.txtVolFixedSec.Text) / 100;

                return;
            }

            //kV Mode
            this._dtoMBA3P.Percent_PrimFixed = 1 + this._perFixedPrimTemp_100 / 100;
            this._dtoMBA3P.Percent_TerFixed = 1 + this._perFixedTerTemp_100 / 100;
            this._dtoMBA3P.Percent_SecFixed = 1 + this._perFixedSecTemp_100 / 100;
        }


        #endregion OK_Event_Set_Data

        //Change Unit Tap Main
        private void btnTransUnit_Click(object sender, EventArgs e)
        {
            this._unitModeMain = (this._unitModeMain == UnitTapMode.Percent) ? UnitTapMode.KV_Number : UnitTapMode.Percent;

            this.SetVoltageFixed();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
