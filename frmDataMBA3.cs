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
using Experimential_Software.DAO.DAO_MBA3Data;
using Experimential_Software.BLL.BLL_ProcessMBA3P;

namespace Experimential_Software
{
    public partial class frmDataMBA3 : Form
    {
        protected ConnectableE _mba3PEPower;
        public ConnectableE MBA3EPowerFixed { get => _mba3PEPower; set => _mba3PEPower = value; }

        protected DTOTransThreeEPower _dtoMBA3P;
        public virtual DTOTransThreeEPower DTOMBA3P => _dtoMBA3P;

        //temp
        protected UnitTapMode _unitModeMain = UnitTapMode.Percent;
        public UnitTapMode UnitModeMain { get => _unitModeMain; set => _unitModeMain = value; }


        //percent Fixed temp
        protected double _perFixedPrimTemp_100 = 0;
        public double PerFixedPrimTemp_100 { get => _perFixedPrimTemp_100; set => _perFixedPrimTemp_100 = value; }

        protected double _perFixedTerTemp_100 = 0;
        public double PerFixedTerTemp_100 { get => _perFixedTerTemp_100; set => _perFixedTerTemp_100 = value; }

        protected double _perFixedSecTemp_100 = 0;
        public double PerFixedSecTemp_100 { get => _perFixedSecTemp_100; set => _perFixedSecTemp_100 = value; }

        //Impendance Tap Zero 
        protected ImpedanceMBA3 _impedanceMBA3_TapZero;

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

                this._impedanceMBA3_TapZero = DAOGeneMBA3Record.Instance.GetImpedanceMBA3PTapZeroWhenStart(this._dtoMBA3P);
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
            SpecImpedanceMBA3RX SpecRX_Prim = this._dtoMBA3P.Impedance_MBA3.SpecRX_Prim;
            this.txtSpecR_Prim.Text = SpecRX_Prim.SpecR_pu.ToString("F6");
            this.txtSpecX_Prim.Text = SpecRX_Prim.SpecX_pu.ToString("F6");

            //Tertiary RX
            SpecImpedanceMBA3RX SpecRX_Ter = this._dtoMBA3P.Impedance_MBA3.SpecRX_Ter;
            this.txtSpecR_Ter.Text = SpecRX_Ter.SpecR_pu.ToString("F6");
            this.txtSpecX_Ter.Text = SpecRX_Ter.SpecX_pu.ToString("F6");

            //Sec RX
            SpecImpedanceMBA3RX SpecRX_Sec = this._dtoMBA3P.Impedance_MBA3.SpecRX_Sec;
            this.txtSpecR_Sec.Text = SpecRX_Sec.SpecR_pu.ToString("F6");
            this.txtSpecX_Sec.Text = SpecRX_Sec.SpecX_pu.ToString("F6");

            //Go, Bo
            this.txtMagG.Text = this._dtoMBA3P.Impedance_MBA3.MagG_pu.ToString("F6");
            this.txtMagB.Text = this._dtoMBA3P.Impedance_MBA3.MagB_pu.ToString("F6");
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

        public virtual void ShowFixedVolatgeKVBySpecVoltage(VoltageEnds3P voltageFixed3P)
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
            BLLProcessMBA3PForm.Instance.TextBoxLeaveValidNumber(sender);
        }
        //Voltage Rated
        private void TextBoxRatedLeave(object sender, EventArgs e)
        {
            BLLProcessMBA3PForm.Instance.TextBoxRatedLeave(sender, this);
        }

        //Apply for VoltageFixed
        private void TextBoxVolFixed_Leave(object sender, EventArgs e)
        {
            BLLProcessMBA3PForm.Instance.TextBoxVolFixed_Leave(sender, this);
        }

        #endregion Leave_TextBox

        #region OK_Event_Set_Data
        private void btnOK_Click(object sender, EventArgs e)
        {
            BLLProcessMBA3PForm.Instance.EventOK_Click(this);

            DialogResult = DialogResult.OK;
        }

        #endregion OK_Event_Set_Data

        //Change Unit Tap Main
        private void btnTransUnit_Click(object sender, EventArgs e)
        {
            BLLProcessMBA3PForm.Instance.EventTransUnit_Click(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
