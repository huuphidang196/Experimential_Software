using Experimential_Software.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.DAO.DAO_MBA2Data
{
    public class DAOProcessMBA2Form
    {
        private static DAOProcessMBA2Form _instance;
        public static DAOProcessMBA2Form Instance
        {
            get { if (DAOProcessMBA2Form._instance == null) DAOProcessMBA2Form._instance = new DAOProcessMBA2Form(); return _instance; }
            private set {; }
        }

        private DAOProcessMBA2Form() {; }

        #region Event_Cancel
        public void EventCancelMBA2_Click(DTOTransTwoEPower _dtoMBA2EPowerRecord, VoltageEnds2P _vol_Rated_Old, double _perFixed_Prim_Old, double _perFixed_Sec_Old)
        {
            // Return value Voltage Rated because it is set when edit in order to tap ranger use 
            _dtoMBA2EPowerRecord.VoltageEnds_kV_Rated = _vol_Rated_Old;
            //Set Old Percent
            _dtoMBA2EPowerRecord.Percent_PrimFixed = _perFixed_Prim_Old;
            _dtoMBA2EPowerRecord.Percent_SecFixed = _perFixed_Sec_Old;

        }

        #endregion Event_Cancel

        #region OK_Event
        public virtual void SetBasicDataMBA2P(DTOTransTwoEPower _dtoMBA2EPowerRecord, string ObjName, int ObjNumber, bool isChecked, double PowerRated)
        {
            //Set Object Name
            _dtoMBA2EPowerRecord.ObjectName = ObjName;
            //Set Objet Number 
            _dtoMBA2EPowerRecord.ObjectNumber = ObjNumber;
            //Set isInservice
            _dtoMBA2EPowerRecord.IsInService = isChecked;

            //Power Rated
            _dtoMBA2EPowerRecord.PowerRated_MVA = PowerRated; 
        }
        public virtual void SetValueVoltageRating(DTOTransTwoEPower _dtoMBA2EPowerRecord, double VolRated_Prim, double VoltRated_Sec)
        {
            VoltageEnds2P vol_Rated = new VoltageEnds2P() { VolPrim_kV = VolRated_Prim, VolSec_kV = VoltRated_Sec };

            //Set Voltage Ends
            _dtoMBA2EPowerRecord.VoltageEnds_kV_Rated = vol_Rated;
        }

        //********Fixed Tap*****
        public virtual void SetValueFixedTapAfterOKEvent(DTOTransTwoEPower _dtoMBA2EPowerRecord, UnitTapMode unitTapMode, DTOTransTwoTapRanger DTORangerPrim_Temp, DTOTransTwoTapRanger DTORangerSec_Temp, double NumberTapFixed_Prim, double NumberTapFixed_Sec, double perFixed_Prim, double perFixed_Sec)
        {
            //Voltage Rated => recify directly so not set. simaliar with percent prim and second
            //Set Unit Mode
            _dtoMBA2EPowerRecord.UnitTap_Main = unitTapMode;
            //Set DToRange
            _dtoMBA2EPowerRecord.Prim_RangerTap = DTORangerPrim_Temp;
            _dtoMBA2EPowerRecord.Sec_RangerTap = DTORangerSec_Temp;

            //Save Number FixedTap prim and Sec
            _dtoMBA2EPowerRecord.NumberTapFixed_Prim = NumberTapFixed_Prim;
            _dtoMBA2EPowerRecord.NumberTapFixed_Sec = NumberTapFixed_Sec;

            //Set Percent if user not change Tap by Button
            _dtoMBA2EPowerRecord.Percent_PrimFixed = perFixed_Prim;
            _dtoMBA2EPowerRecord.Percent_SecFixed = perFixed_Sec;
        }

        public virtual void SetValuePowerRatingAndImpendance(DTOTransTwoEPower _dtoMBA2EPowerRecord, double PowerRated_MVA, double SpecR_pu, double SpecX_pu, double MagG_pu, double MagB_pu)
        {
            //Set Power Rated
            _dtoMBA2EPowerRecord.PowerRated_MVA = PowerRated_MVA;

            //Impendance

            _dtoMBA2EPowerRecord.Impendance_MBA2.SpecR_pu = SpecR_pu;
            _dtoMBA2EPowerRecord.Impendance_MBA2.SpecX_pu = SpecX_pu;
            _dtoMBA2EPowerRecord.Impendance_MBA2.MagB_pu = MagB_pu;
            _dtoMBA2EPowerRecord.Impendance_MBA2.MagG_pu = MagG_pu;

        }

        #endregion OK_Event

        #region Func_Evnet_Down_FixedTap_Zone

        //Add Event For button Prim and Sec
        public virtual void btnTapChangerPrimAndSecZoneFixed_MouseDown(DTOTransTwoEPower _dtoMBA2EPowerRecord, DTOTransTwoTapRanger _dtoRanger_Prim_Temp, DTOTransTwoTapRanger _dtoRanger_Sec_Temp)
        {
            //set Volatage Rated if Rated Change
            _dtoRanger_Prim_Temp.Voltage_TapZero_ByRated = _dtoMBA2EPowerRecord.Prim_RangerTap.Voltage_TapZero_ByRated;
            _dtoRanger_Sec_Temp.Voltage_TapZero_ByRated = _dtoMBA2EPowerRecord.Sec_RangerTap.Voltage_TapZero_ByRated;

        }

        #endregion Func_Evnet_Down_FixedTap_Zone

        #region Event_Button_Up_Down
        public virtual void SetPercentEndsAndNumberTap(bool isPrim, double percentEnds, double numberTap, frmDataMBA2 frmDataMBA2, DTOTransTwoEPower _dtoMBA2EPowerRecord)
        {
            if (isPrim)
            {
                _dtoMBA2EPowerRecord.Percent_PrimFixed = percentEnds;
                frmDataMBA2.NumberTapFixed_Prim = numberTap;
            }
            else
            {
                _dtoMBA2EPowerRecord.Percent_SecFixed = percentEnds;
                frmDataMBA2.NumberTapFixed_Sec = numberTap;
            }

        }
        #endregion Event_Button_Up_Down
    }
}
