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

        //Zone Voltage Rating and Fixed Tap Zone
        protected VoltageEnds _vol_Rated_Old = new VoltageEnds();

        //Fixed . same DTO Voltage Rated
        protected double _perFixed_Prim_Old = 0;
        protected double _perFixed_Sec_Old = 0;

        //temp
        protected UnitTapMode _unitModeMain = UnitTapMode.Percent;

        protected DTOTransTwoTapRanger _dtoRanger_Prim_Temp;
        protected DTOTransTwoTapRanger _dtoRanger_Sec_Temp;

        protected double _numberTapFixed_Prim = 0;
        protected double _numberTapFixed_Sec = 0;
        public frmDataMBA2()
        {
            InitializeComponent();
        }

        private void frmDataMBA2_Load(object sender, EventArgs e)
        {
            if (this._mba2_EFixedData != null)
            {
                //get dto in Epower
                this._dtoMBA2EPowerRecord = this._mba2_EFixedData.DatabaseE.DataRecordE.DTOTransTwoEPower;

                //get Old Struct => Save When Cancel because Ranger need use Voltage rated on  DTO Trans
                this._vol_Rated_Old = this._dtoMBA2EPowerRecord.VoltageEnds_Rated;

                //Set Unit Mode
                this._unitModeMain = this._dtoMBA2EPowerRecord.UnitTap_Main;

                //Clone Specified DTORanger => If Main Ok => Set
                //Clone Prim
                this._dtoRanger_Prim_Temp = this._dtoMBA2EPowerRecord.Prim_RangerTap.CloneTransTwoTapRanger();
                //Clone Sec
                this._dtoRanger_Sec_Temp = this._dtoMBA2EPowerRecord.Sec_RangerTap.CloneTransTwoTapRanger();

                //Set Prim Fixed and Sec
                this._perFixed_Prim_Old = this._dtoMBA2EPowerRecord.Percent_PrimFixed;
                this._perFixed_Sec_Old = this._dtoMBA2EPowerRecord.Percent_SecFixed;

                //Set Number Tap
                this._numberTapFixed_Prim = this._dtoMBA2EPowerRecord.NumberTapFixed_Prim;
                this._numberTapFixed_Sec = this._dtoMBA2EPowerRecord.NumberTapFixed_Sec;
                this.ShowDataOnFormMBA2EPowerOrigin();
            }
        }

        #region Show_Data_Form_Main
        protected virtual void ShowDataOnFormMBA2EPowerOrigin()
        {
            //DataLine BusConnect
            this.ShowDataOnFormLineDataZone();

            //Show Power Rating and Inpendance Data
            this.ShowTransformerImpendanceData();

            //Show Voltage 
            this.ShowVoltageRatingTransfomer();

            //Show  Fixed tap and Add event for button prim and sec
            this.ShowFixedTapDataOnFixedZone();

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
        protected virtual void ShowFixedTapDataOnFixedZone()
        {
            //Set text button Change Unit
            bool isPecentUnit = this._unitModeMain == UnitTapMode.Percent;
            this.btnTCUnitMain.Text = (isPecentUnit) ? "% Tap" : "kV Tap";

            VoltageEnds vol_Fixed = this._dtoMBA2EPowerRecord.VoltageEnds_Fixed;
            double percentPrim = this._dtoMBA2EPowerRecord.Percent_PrimFixed;
            double percentSec = this._dtoMBA2EPowerRecord.Percent_SecFixed;

            //kV Mode
            if (!isPecentUnit)
            {
                this.txtFixedPrimkV.Text = vol_Fixed.VolPrim_kV + "";
                this.txtFixedSeckV.Text = vol_Fixed.VolSec_kV + "";

                //label transfer unit have name
                this.lblTransUnit.Text = "% Tap";

                this.lblTapTransPrimFixed.Text = Math.Round(percentPrim * 100 - 100, 4) + "";
                this.lblTapTransSecFixed.Text = Math.Round(percentSec * 100 - 100, 4) + "";
                return;
            }

            //Percent Mode
            this.txtFixedPrimkV.Text = Math.Round(percentPrim * 100 - 100, 4) + "";
            this.txtFixedSeckV.Text = Math.Round(percentSec * 100 - 100, 4) + "";

            //label transfer unit have name
            this.lblTransUnit.Text = "kV Tap";
            this.lblTapTransPrimFixed.Text = vol_Fixed.VolPrim_kV + "";
            this.lblTapTransSecFixed.Text = vol_Fixed.VolSec_kV + "";

        }
        #endregion Show_Data_Form_Main

        #region Func_Evnet_Down_FixedTap_Zone
        //AddEvent button Main Tap 
        private void btnTCUnitMain_MouseDown(object sender, MouseEventArgs e)
        {
            //Set ModeUnit Main
            this._unitModeMain = (this._unitModeMain == UnitTapMode.Percent) ? UnitTapMode.KV_Number : UnitTapMode.Percent;

            //Show FixedTapzone Again
            this.ShowFixedTapDataOnFixedZone();
        }

        //Add Event For button Prim and Sec
        private void btnTapChangerPrimAndSecZoneFixed_MouseDown(object sender, MouseEventArgs e)
        {
            Button btnEnds = sender as Button;
            //Get DTOTapRanger in DTOTrans => Reference form Ranger => Set
            //Open Form TapRanger
            frmFixedTapChanger frmTapRanger = new frmFixedTapChanger();

            //set Volatage Rated if Rated Change
            this._dtoRanger_Prim_Temp.Voltage_TapZero_ByRated = this._dtoMBA2EPowerRecord.Prim_RangerTap.Voltage_TapZero_ByRated;
            this._dtoRanger_Sec_Temp.Voltage_TapZero_ByRated = this._dtoMBA2EPowerRecord.Sec_RangerTap.Voltage_TapZero_ByRated;

            //Reference In Form Value Temp
            frmTapRanger.DTOTapRanger = (btnEnds == btnTCPrim) ? this._dtoRanger_Prim_Temp : this._dtoRanger_Sec_Temp;
            //Set name Form Tap Changer 
            frmTapRanger.Text = (btnEnds == btnTCPrim) ? "Primary Fixed Tap Range" : "Secondary Fixed Tap Range";

            //if Set Data Ranger then show Again Fixed Zone
            if (frmTapRanger.ShowDialog() != DialogResult.OK) return;


            this.ShowFixedTapDataOnFixedZone();
        }

        #endregion Func_Evnet_Down_FixedTap_Zone

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
            //Voltage Rated => recify directly so not set. simaliar with percent prim and second
            //Set Unit Mode
            this._dtoMBA2EPowerRecord.UnitTap_Main = this._unitModeMain;
            //Set DToRange
            this._dtoMBA2EPowerRecord.Prim_RangerTap = this._dtoRanger_Prim_Temp;
            this._dtoMBA2EPowerRecord.Sec_RangerTap = this._dtoRanger_Sec_Temp;

            //Save Number FixedTap prim and Sec
            this._dtoMBA2EPowerRecord.NumberTapFixed_Prim = this._numberTapFixed_Prim;
            this._dtoMBA2EPowerRecord.NumberTapFixed_Sec = this._numberTapFixed_Sec;
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
            this.ShowFixedTapDataOnFixedZone();
        }




        #endregion Event_Text_Changed

        #region Cancel_Event
        private void btnCancelMBA2_Click(object sender, EventArgs e)
        {
            // Return value Voltage Rated because it is set when edit in order to tap ranger use 
            this._dtoMBA2EPowerRecord.VoltageEnds_Rated = this._vol_Rated_Old;
            //Set Old Percent
            this._dtoMBA2EPowerRecord.Percent_PrimFixed = this._perFixed_Prim_Old;
            this._dtoMBA2EPowerRecord.Percent_SecFixed = this._perFixed_Sec_Old;

            this.Close();
        }


        #endregion Cancel_Event

        #region Event_Button_Up_Down
        //Button Up
        private void EventButtonUpFixedTapZone(object sender, MouseEventArgs e)
        {
            Button btnEndsUp = sender as Button;
            bool isPrim = (btnEndsUp == this.btnPrimUp);

            //get Inter Fixed per Prim => Per Prim if not per Sec
            double Inter_Fixed_Per = isPrim ? this._dtoMBA2EPowerRecord.Percent_PrimFixed : this._dtoMBA2EPowerRecord.Percent_SecFixed;
            //get number Tap 
            double Inter_numberTap = isPrim ? this._numberTapFixed_Prim : this._numberTapFixed_Sec;
            //Get Intern Max Limit => Up only work with max value => Work with Temp because it is edited , main is not set
            double Inter_maxPer = isPrim ? this._dtoRanger_Prim_Temp.MaxRanger_Per : this._dtoRanger_Sec_Temp.MaxRanger_Per;
            //Get Intern Step
            double Inter_Step_Per = isPrim ? this._dtoRanger_Prim_Temp.Step_Per : this._dtoRanger_Sec_Temp.Step_Per;


            //Check Is Step have Change
            double K_remainder = Inter_Fixed_Per - 1 - Inter_numberTap * Inter_Step_Per;

            if (Math.Abs(K_remainder) > 0.001)
            {
                this.SetPercentEndsAndNumberTapWhenChangeStep(isPrim);
                return;
            }
            //If Current >= MaxLimit (equal) set equal max
            if (Inter_Fixed_Per >= Inter_maxPer) return;

            //add 1 intpo number tap, if not greater limit => +1
            Inter_numberTap += 1;

            //add Percent
            Inter_Fixed_Per = 1 + Inter_numberTap * Inter_Step_Per;
            //If Current >= MaxLimit (equal) set equal max
            if (Inter_Fixed_Per >= Inter_maxPer) Inter_Fixed_Per = Inter_maxPer;


            //Apply value for Per In DTO Trans . Directly
            this.SetPercentEndsAndNumberTap(isPrim, Inter_Fixed_Per, Inter_numberTap);
            // MessageBox.Show("Kup = " + K_remainder + ", num Tab = " + Inter_numberTap);
        }

        //Button Down
        private void EventButtonDownFixedTapZone(object sender, MouseEventArgs e)
        {
            Button btnEndsDown = sender as Button;
            bool isPrim = (btnEndsDown == this.btnPrimDown);

            //get Inter Fixed per Prim => Per Prim if not per Sec
            double Inter_Fixed_Per = isPrim ? this._dtoMBA2EPowerRecord.Percent_PrimFixed : this._dtoMBA2EPowerRecord.Percent_SecFixed;
            //get number Tap 
            double Inter_numberTap = isPrim ? this._numberTapFixed_Prim : this._numberTapFixed_Sec;
            //Get Intern min Limit => Up only work with min value => Work with Temp because it is edited , main is not set
            double Inter_minPer = isPrim ? this._dtoRanger_Prim_Temp.MinRanger_Per : this._dtoRanger_Sec_Temp.MinRanger_Per;
            //Get Intern Step
            double Inter_Step_Per = isPrim ? this._dtoRanger_Prim_Temp.Step_Per : this._dtoRanger_Sec_Temp.Step_Per;


            //Check Is Step have Change
            double K_remainder = Inter_Fixed_Per - 1 - Inter_numberTap * Inter_Step_Per; //Intern = Old + step * tap//2 case same +

            if (Math.Abs(K_remainder) > 0.001)
            {
                //Apply value for Per In DTO Trans . Directly
                this.SetPercentEndsAndNumberTapWhenChangeStep(isPrim);
                return;
            }
            //If Current <= MinLimit (equal) set equal min
            if (Inter_Fixed_Per <= Inter_minPer) return;

            //add 1 intpo number tap, if not greater limit => -1
            Inter_numberTap -= 1;

            //add Percent
            Inter_Fixed_Per = 1 + Inter_numberTap * Inter_Step_Per;//Intern = Old + step * tap//2 case same +. if - <=> tap < 0 => + negative
            //If Current >= MaxLimit (equal) set equal max
            if (Inter_Fixed_Per <= Inter_minPer + 0.0001) Inter_Fixed_Per = Inter_minPer;

            //Apply value for Per In DTO Trans . Directly
            this.SetPercentEndsAndNumberTap(isPrim, Inter_Fixed_Per, Inter_numberTap);
        }

        protected virtual void SetPercentEndsAndNumberTap(bool isPrim, double percentEnds, double numberTap)
        {
            if (isPrim)
            {
                this._dtoMBA2EPowerRecord.Percent_PrimFixed = percentEnds;
                this._numberTapFixed_Prim = numberTap;
            }
            else
            {
                this._dtoMBA2EPowerRecord.Percent_SecFixed = percentEnds;
                this._numberTapFixed_Sec = numberTap;
            }
            //Show Again Fixed Zone
            this.ShowFixedTapDataOnFixedZone();
        }
        protected virtual void SetPercentEndsAndNumberTapWhenChangeStep(bool isPrim)
        {
            if (isPrim)
            {
                this._dtoMBA2EPowerRecord.Percent_PrimFixed = 1;
                this._numberTapFixed_Prim = 0;
            }
            else
            {
                this._dtoMBA2EPowerRecord.Percent_SecFixed = 1;
                this._numberTapFixed_Sec = 0;
            }
            //Show Again Fixed Zone
            this.ShowFixedTapDataOnFixedZone();
        }
        #endregion Event_Button_Up_Down
    }

}
