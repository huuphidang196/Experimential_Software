using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.DAO.DAO_MBA2Data;
using Experimential_Software.DTO;

namespace Experimential_Software.BLL.BLL_ProcessMBA2P
{
    public class BLLProcessMBA2PForm
    {
        private static BLLProcessMBA2PForm _instance;

        public static BLLProcessMBA2PForm Instance
        {
            get { if (_instance == null) _instance = new BLLProcessMBA2PForm(); return BLLProcessMBA2PForm._instance; }
            private set { _instance = value; }
        }

        private BLLProcessMBA2PForm() { }

        #region Event_Text_Changed_Leave
        public void CheckTextBoxValidEventTextBoxLeave(object sender, frmDataMBA2 frmDataMBA2, ImpedanceMBA2 _impendanceTemp, DTOTransTwoEPower _dtoMBA2EPowerRecord)
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
            //Set value impendance temp 
            if ((GroupBox)txtDataChanged.Parent == frmDataMBA2.grbImpendanceMBA2) this.SetValueForImpendanceTemp(frmDataMBA2, _impendanceTemp);

            //If Zone Power Rated => Set value immediately
            if (!txtDataChanged.Parent.Text.Contains("Voltage Rating")) return;

            //********Voltage Rating => set in order to Fixed tap Zone use*****
            this.SetValueVoltageRating(_dtoMBA2EPowerRecord, frmDataMBA2);
            // MessageBox.Show(txtDataChanged.Text);

            //When set rated => Fixed Zone is affeected by Rated. 
            frmDataMBA2.ShowFixedTapDataOnFixedZone();


        }

        //ImpendanceTemp
        protected virtual void SetValueForImpendanceTemp(frmDataMBA2 frmDataMBA2, ImpedanceMBA2 _impendanceTemp)
        {
            //SpecR_pu
            double SpecR_pu = double.Parse(frmDataMBA2.txtSpecRpu.Text);
            //SpecX_pu
            double SpecX_pu = double.Parse(frmDataMBA2.txtSpecXpu.Text);

            //MagG_pu
            double MagG_pu = double.Parse(frmDataMBA2.txtMagGpu.Text);
            //MagB_pu
            double MagB_pu = double.Parse(frmDataMBA2.txtMagBpu.Text);

            _impendanceTemp.SpecR_pu = SpecR_pu;
            _impendanceTemp.SpecX_pu = SpecX_pu;
            _impendanceTemp.MagG_pu = MagG_pu;
            _impendanceTemp.MagB_pu = MagB_pu;
        }

        #endregion Event_Text_Changed_Leave

        #region Cancel_Event
        public void EventCancelMBA2_Click(DTOTransTwoEPower _dtoMBA2EPowerRecord, VoltageEnds2P _vol_Rated_Old, double _perFixed_Prim_Old, double _perFixed_Sec_Old)
        {
            DAOProcessMBA2Form.Instance.EventCancelMBA2_Click(_dtoMBA2EPowerRecord, _vol_Rated_Old, _perFixed_Prim_Old, _perFixed_Sec_Old);
        }

        #endregion Cancel_Event

        #region Function_OK_Event
        public virtual void EventOkMBA2_Click(DTOTransTwoEPower _dtoMBA2EPowerRecord, frmDataMBA2 frmDataMBA2)
        {
            ///****Basic Data***************
            this.ProcessBasicDataForm(_dtoMBA2EPowerRecord, frmDataMBA2);

            //********Voltage Rating*****
            this.SetValueVoltageRating(_dtoMBA2EPowerRecord, frmDataMBA2);

            //********Fixed Tap*****
            this.SetValueFixedTapAfterOKEvent(_dtoMBA2EPowerRecord, frmDataMBA2);

            //********Power Rating And Impendance Zone***** Below rating and fixed use for set impendance by k, k'
            this.SetValuePowerRatingAndImpendance(_dtoMBA2EPowerRecord, frmDataMBA2);

        }
        protected virtual void ProcessBasicDataForm(DTOTransTwoEPower dtoMBA2EPowerRecord, frmDataMBA2 frmDataMBA2)
        {
            //Set Object Name
            string ObjName = frmDataMBA2.txtTransName.Text;
            //Set Objet Number 
            int ObjNumber = int.Parse(frmDataMBA2.txtTransID.Text);
            //Set isInservice
            bool isChecked = frmDataMBA2.chkinService.Checked;
            //Power Rated
            double powerRated = double.Parse(frmDataMBA2.txtPowerRated.Text);
            DAOProcessMBA2Form.Instance.SetBasicDataMBA2P(dtoMBA2EPowerRecord, ObjName, ObjNumber, isChecked, powerRated);
        }

        //********Voltage Rating*****
        public virtual void SetValueVoltageRating(DTOTransTwoEPower _dtoMBA2EPowerRecord, frmDataMBA2 frmDataMBA2)
        {
            //Rated Voltage Prim
            double VolRated_Prim = double.Parse(frmDataMBA2.txtRatedPrimkV.Text);
            //Rated Voltage Sec
            double VoltRated_Sec = double.Parse(frmDataMBA2.txtRatedSeckV.Text);

            DAOProcessMBA2Form.Instance.SetValueVoltageRating(_dtoMBA2EPowerRecord, VolRated_Prim, VoltRated_Sec);
        }

        //********Fixed Tap*****
        protected virtual void SetValueFixedTapAfterOKEvent(DTOTransTwoEPower _dtoMBA2EPowerRecord, frmDataMBA2 frmDataMBA2)
        {
            //Voltage Rated => recify directly so not set. simaliar with percent prim and second
            //Set Unit Mode
            UnitTapMode unitTapMode = frmDataMBA2.UnitModeMain;
            //Set DToRange
            DTOTransTwoTapRanger Prim_RangerTap = frmDataMBA2.DTORangerPrim_Temp;
            DTOTransTwoTapRanger Sec_RangerTap = frmDataMBA2.DTORangerSec_Temp;

            //Save Number FixedTap prim and Sec
            double NumberTapFixed_Prim = frmDataMBA2.NumberTapFixed_Prim;
            double NumberTapFixed_Sec = frmDataMBA2.NumberTapFixed_Sec;

            //Set Percent if user not change Tap by Button
            double perFixed_Prim = BLLCalculateVoltageFixed.Instance.GetPercentVoltageFixedByVoltageRated(frmDataMBA2.txtRatedPrimkV.Text, frmDataMBA2.txtFixedPrimkV.Text, frmDataMBA2.UnitModeMain);
            double perFixed_Sec = BLLCalculateVoltageFixed.Instance.GetPercentVoltageFixedByVoltageRated(frmDataMBA2.txtRatedSeckV.Text, frmDataMBA2.txtFixedSeckV.Text, frmDataMBA2.UnitModeMain);

            DAOProcessMBA2Form.Instance.SetValueFixedTapAfterOKEvent(_dtoMBA2EPowerRecord, unitTapMode, Prim_RangerTap, Sec_RangerTap, NumberTapFixed_Prim, NumberTapFixed_Sec, perFixed_Prim, perFixed_Sec);

        }
        //********Power Rating And Impendance Zone*****
        protected virtual void SetValuePowerRatingAndImpendance(DTOTransTwoEPower _dtoMBA2EPowerRecord, frmDataMBA2 frmDataMBA2)
        {
            //Set Power Rated
            double PowerRated_MVA = double.Parse(frmDataMBA2.txtPowerRated.Text);

            //Impendance
            //SpecR_pu
            double SpecR_pu = double.Parse(frmDataMBA2.txtSpecRpu.Text);
            //SpecX_pu
            double SpecX_pu = double.Parse(frmDataMBA2.txtSpecXpu.Text);

            //MagG_pu
            double MagG_pu = double.Parse(frmDataMBA2.txtMagGpu.Text);
            //MagB_pu
            double MagB_pu = double.Parse(frmDataMBA2.txtMagBpu.Text);

            DAOProcessMBA2Form.Instance.SetValuePowerRatingAndImpendance(_dtoMBA2EPowerRecord, PowerRated_MVA, SpecR_pu, SpecX_pu, MagG_pu, MagB_pu);

        }

        #endregion Function_OK_Event

        #region Func_Evnet_Down_FixedTap_Zone

        //Add Event For button Prim and Sec
        public virtual void btnTapChangerPrimAndSecZoneFixed_MouseDown(object sender, frmDataMBA2 frmDataMBA2, DTOTransTwoEPower _dtoMBA2EPowerRecord, DTOTransTwoTapRanger _dtoRanger_Prim_Temp, DTOTransTwoTapRanger _dtoRanger_Sec_Temp)
        {
            Button btnEnds = sender as Button;
            //Get DTOTapRanger in DTOTrans => Reference form Ranger => Set
            //Open Form TapRanger
            frmFixedTapChanger frmTapRanger = new frmFixedTapChanger();

            //set Volatage Rated if Rated Change
            DAOProcessMBA2Form.Instance.btnTapChangerPrimAndSecZoneFixed_MouseDown(_dtoMBA2EPowerRecord, _dtoRanger_Prim_Temp, _dtoRanger_Sec_Temp);

            //Reference In Form Value Temp
            frmTapRanger.DTOTapRanger = (btnEnds == frmDataMBA2.btnTCPrim) ? _dtoRanger_Prim_Temp : _dtoRanger_Sec_Temp;
            //Set name Form Tap Changer 
            frmTapRanger.Text = (btnEnds == frmDataMBA2.btnTCPrim) ? "Primary Fixed Tap Range" : "Secondary Fixed Tap Range";

            //if Set Data Ranger then show Again Fixed Zone
            if (frmTapRanger.ShowDialog() != DialogResult.OK) return;


            frmDataMBA2.ShowFixedTapDataOnFixedZone();
        }

        #endregion Func_Evnet_Down_FixedTap_Zone

        #region Event_Button_Up_Down
        //Button Up
        public virtual void EventButtonUpFixedTapZone(object sender, frmDataMBA2 frmDataMBA2, DTOTransTwoEPower _dtoMBA2EPowerRecord)
        {
            Button btnEndsUp = sender as Button;
            bool isPrim = (btnEndsUp == frmDataMBA2.btnPrimUp);

            //get Inter Fixed per Prim => Per Prim if not per Sec
            double Inter_Fixed_Per = isPrim ? _dtoMBA2EPowerRecord.Percent_PrimFixed : _dtoMBA2EPowerRecord.Percent_SecFixed;
            //get number Tap 
            double Inter_numberTap = isPrim ? frmDataMBA2.NumberTapFixed_Prim : frmDataMBA2.NumberTapFixed_Sec;
            //Get Intern Max Limit => Up only work with max value => Work with Temp because it is edited , main is not set
            double Inter_maxPer = isPrim ? frmDataMBA2.DTORangerPrim_Temp.MaxRanger_Per : frmDataMBA2.DTORangerSec_Temp.MaxRanger_Per;
            //Get Intern Step
            double Inter_Step_Per = isPrim ? frmDataMBA2.DTORangerPrim_Temp.Step_Per : frmDataMBA2.DTORangerSec_Temp.Step_Per;


            //Check Is Step have Change
            double K_remainder = Inter_Fixed_Per - 1 - Inter_numberTap * Inter_Step_Per;

            if (Math.Abs(K_remainder) > 0.001)
            {
                this.SetPercentEndsAndNumberTapWhenChangeStep(isPrim, frmDataMBA2, _dtoMBA2EPowerRecord);
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
            this.SetPercentEndsAndNumberTap(isPrim, Inter_Fixed_Per, Inter_numberTap, frmDataMBA2, _dtoMBA2EPowerRecord);

            //Show Impendance because Impendance depend (k'/k)^2
            this.ProcessUpdateImpendanceByTransformerRatio(frmDataMBA2, _dtoMBA2EPowerRecord);
        }

        //Button Down
        public virtual void EventButtonDownFixedTapZone(object sender, frmDataMBA2 frmDataMBA2, DTOTransTwoEPower _dtoMBA2EPowerRecord)
        {
            Button btnEndsDown = sender as Button;
            bool isPrim = (btnEndsDown == frmDataMBA2.btnPrimDown);

            //get Inter Fixed per Prim => Per Prim if not per Sec
            double Inter_Fixed_Per = isPrim ? _dtoMBA2EPowerRecord.Percent_PrimFixed : _dtoMBA2EPowerRecord.Percent_SecFixed;
            //get number Tap 
            double Inter_numberTap = isPrim ? frmDataMBA2.NumberTapFixed_Prim : frmDataMBA2.NumberTapFixed_Sec;
            //Get Intern min Limit => Up only work with min value => Work with Temp because it is edited , main is not set
            double Inter_minPer = isPrim ? frmDataMBA2.DTORangerPrim_Temp.MinRanger_Per : frmDataMBA2.DTORangerSec_Temp.MinRanger_Per;
            //Get Intern Step
            double Inter_Step_Per = isPrim ? frmDataMBA2.DTORangerPrim_Temp.Step_Per : frmDataMBA2.DTORangerSec_Temp.Step_Per;


            //Check Is Step have Change
            double K_remainder = Inter_Fixed_Per - 1 - Inter_numberTap * Inter_Step_Per; //Intern = Old + step * tap//2 case same +

            if (Math.Abs(K_remainder) > 0.001)
            {
                //Apply value for Per In DTO Trans . Directly
                this.SetPercentEndsAndNumberTapWhenChangeStep(isPrim, frmDataMBA2, _dtoMBA2EPowerRecord);
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
            this.SetPercentEndsAndNumberTap(isPrim, Inter_Fixed_Per, Inter_numberTap, frmDataMBA2, _dtoMBA2EPowerRecord);

            //Show Impendance because Impendance depend (k'/k)^2
            this.ProcessUpdateImpendanceByTransformerRatio(frmDataMBA2, _dtoMBA2EPowerRecord);
        }

        protected virtual void SetPercentEndsAndNumberTap(bool isPrim, double percentEnds, double numberTap, frmDataMBA2 frmDataMBA2, DTOTransTwoEPower _dtoMBA2EPowerRecord)
        {
            DAOProcessMBA2Form.Instance.SetPercentEndsAndNumberTap(isPrim, percentEnds, numberTap, frmDataMBA2, _dtoMBA2EPowerRecord);
            //Show Again Fixed Zone
            frmDataMBA2.ShowFixedTapDataOnFixedZone();
        }
        protected virtual void SetPercentEndsAndNumberTapWhenChangeStep(bool isPrim, frmDataMBA2 frmDataMBA2, DTOTransTwoEPower _dtoMBA2EPowerRecord)
        {
            double percentEnds = 1;
            double numberTap = 0;
            DAOProcessMBA2Form.Instance.SetPercentEndsAndNumberTap(isPrim, percentEnds, numberTap, frmDataMBA2, _dtoMBA2EPowerRecord);
            //Show Again Fixed Zone
            frmDataMBA2.ShowFixedTapDataOnFixedZone();
        }

        protected virtual void ProcessUpdateImpendanceByTransformerRatio(frmDataMBA2 frmDataMBA2, DTOTransTwoEPower _dtoMBA2EPowerRecord)
        {
            //Clone ImpendancemBA temp 
            ImpedanceMBA2 impendanceMBA2Tem = DAOUpdateImpendanceWhenChangeTap.Instance.ProcessUpdateImpendanceByTransformerRatio(_dtoMBA2EPowerRecord, frmDataMBA2.ImpedanceMBA2Temp);

            //Show textbox again. if ok => change.if Not not change
            frmDataMBA2.ShowTransformerImpendanceData(impendanceMBA2Tem);
        }
        #endregion Event_Button_Up_Down
    }
}
