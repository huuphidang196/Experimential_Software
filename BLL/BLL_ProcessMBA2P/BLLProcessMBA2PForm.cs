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
            this.ProcessBasicDataForm( _dtoMBA2EPowerRecord,  frmDataMBA2);

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
            DAOProcessMBA2Form.Instance.SetBasicDataMBA2P(dtoMBA2EPowerRecord, ObjName, ObjNumber, isChecked);
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
    }
}
