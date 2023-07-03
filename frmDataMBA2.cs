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
using Experimential_Software.DAO.DAO_MBA2Data;
using Experimential_Software.BLL.BLL_ProcessMBA2P;

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
        protected VoltageEnds2P _vol_Rated_Old = new VoltageEnds2P();

        //Fixed . same DTO Voltage Rated
        protected double _perFixed_Prim_Old = 0;
        protected double _perFixed_Sec_Old = 0;

        //temp
        protected UnitTapMode _unitModeMain = UnitTapMode.Percent;
        public UnitTapMode UnitModeMain => _unitModeMain;

        protected DTOTransTwoTapRanger _dtoRanger_Prim_Temp;
        public DTOTransTwoTapRanger DTORangerPrim_Temp => _dtoRanger_Prim_Temp;

        protected DTOTransTwoTapRanger _dtoRanger_Sec_Temp;
        public DTOTransTwoTapRanger DTORangerSec_Temp => _dtoRanger_Sec_Temp;

        protected double _numberTapFixed_Prim = 0;
        public double NumberTapFixed_Prim { get => _numberTapFixed_Prim; set => _numberTapFixed_Prim = value; }

        protected double _numberTapFixed_Sec = 0;
        public double NumberTapFixed_Sec { get => _numberTapFixed_Sec; set => _numberTapFixed_Sec = value; } 

        //ImpendanceTemp use recify temp zone impendance value 
        protected ImpedanceMBA2 _impendanceTemp;
        public ImpedanceMBA2 ImpedanceMBA2Temp => _impendanceTemp;
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
                this._vol_Rated_Old = this._dtoMBA2EPowerRecord.VoltageEnds_kV_Rated;

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

                //If Save then set origin
                this._impendanceTemp = DAOUpdateImpendanceWhenChangeTap.Instance.ProcessUpdateImpendanceTempWhenStart(this._dtoMBA2EPowerRecord);
            }
        }


        #region Show_Data_Form_Main
        protected virtual void ShowDataOnFormMBA2EPowerOrigin()
        {
            //DataLine BusConnect
            this.ShowDataOnFormLineDataZone();

            //Show Power Rating and Inpendance Data
            this.ShowTransformerImpendanceData(this._dtoMBA2EPowerRecord.Impendance_MBA2);

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

            this.txtTransID.Text = this._dtoMBA2EPowerRecord.ObjectNumber + "";
            this.txtTransName.Text = this._dtoMBA2EPowerRecord.ObjectName;
        }

        //Power Rating and Impendance Data
        public virtual void ShowTransformerImpendanceData(ImpedanceMBA2 impenMBA2)
        {
            //Power Rating
            this.txtPowerRated.Text = this._dtoMBA2EPowerRecord.PowerRated_MVA + "";

            //***********Impendance Zone**********
            // ImpendanceMBA2 impenMBA2 = this._dtoMBA2EPowerRecord.Impendace_MBA2;
            //Spec R_pu
            this.txtSpecRpu.Text = impenMBA2.SpecR_pu.ToString("F6");
            //SpecX_pu
            this.txtSpecXpu.Text = impenMBA2.SpecX_pu.ToString("F6");

            //Mag_G_pu
            this.txtMagGpu.Text = impenMBA2.MagG_pu.ToString("F6");

            //Mag_B_pu
            this.txtMagBpu.Text = impenMBA2.MagB_pu.ToString("F6");

            // MessageBox.Show("mul = " + mul_K_Transfer);
        }

        //Show voltage Rangting Transfomer
        protected virtual void ShowVoltageRatingTransfomer()
        {
            //Voltage data on Manual of MBA
            VoltageEnds2P voltageRated = this._dtoMBA2EPowerRecord.VoltageEnds_kV_Rated;

            //Set Prim Volatage
            this.txtRatedPrimkV.Text = voltageRated.VolPrim_kV.ToString();
            //Set Sec Voltage
            this.txtRatedSeckV.Text = voltageRated.VolSec_kV.ToString();

            //Bus From And To
            DTOBusEPower dtoBus_From = this._dtoMBA2EPowerRecord.DTOBus_From;
            DTOBusEPower dtoBus_To = this._dtoMBA2EPowerRecord.DTOBus_To;
            //Set label Normal Volatage of Bus Connect
            this.lblNorBusPrimkV.Text = (dtoBus_From == null) ? "NULL" : dtoBus_From.U_NormalkV + "";
            this.lblNorBusSeckV.Text = (dtoBus_To == null) ? "NULL" : dtoBus_To.U_NormalkV + "";
        }

        //FixedTap Zone
        public virtual void ShowFixedTapDataOnFixedZone()
        {
            //Set text button Change Unit
            bool isPecentUnit = this._unitModeMain == UnitTapMode.Percent;
            this.btnTCUnitMain.Text = (isPecentUnit) ? "% Tap" : "kV Tap";

            VoltageEnds2P vol_Fixed = this._dtoMBA2EPowerRecord.VoltageEnds_kV_Fixed;
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
            BLLProcessMBA2PForm.Instance.btnTapChangerPrimAndSecZoneFixed_MouseDown(sender, this, this._dtoMBA2EPowerRecord, this._dtoRanger_Prim_Temp, this._dtoRanger_Sec_Temp);
        }

        #endregion Func_Evnet_Down_FixedTap_Zone

        #region Function_OK_Event
        private void btnOkMBA2_Click(object sender, EventArgs e)
        {
            BLLProcessMBA2PForm.Instance.EventOkMBA2_Click(this._dtoMBA2EPowerRecord, this);
            //this.ChangeVoltageValueOnBusConnectWithMBA2();

            DialogResult = DialogResult.OK;
        }

        #endregion Function_OK_Event

        #region Cancel_Event
        private void btnCancelMBA2_Click(object sender, EventArgs e)
        {
            BLLProcessMBA2PForm.Instance.EventCancelMBA2_Click(this._dtoMBA2EPowerRecord, this._vol_Rated_Old, this._perFixed_Prim_Old, this._perFixed_Sec_Old);

            this.Close();
        }

        #endregion Cancel_Event

        #region Event_Button_Up_Down
        //Button Up
        private void EventButtonUpFixedTapZone(object sender, MouseEventArgs e)
        {
            BLLProcessMBA2PForm.Instance.EventButtonUpFixedTapZone(sender, this, this._dtoMBA2EPowerRecord);
        }

        //Button Down
        private void EventButtonDownFixedTapZone(object sender, MouseEventArgs e)
        {
            BLLProcessMBA2PForm.Instance.EventButtonDownFixedTapZone(sender, this, this._dtoMBA2EPowerRecord);
        }
        #endregion Event_Button_Up_Down

        #region Event_Text_Changed_Leave
        private void CheckTextBoxValidEventTextBoxLeave(object sender, EventArgs e)
        {
            BLLProcessMBA2PForm.Instance.CheckTextBoxValidEventTextBoxLeave(sender, this, this._impendanceTemp, this._dtoMBA2EPowerRecord);

        }
        #endregion Event_Text_Changed_Leave
    }

}
