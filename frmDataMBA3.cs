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
    public partial class frmDataMBA3 : Form
    {
        protected ConnectableE _mba3PEPower;
        public ConnectableE MBA3EPowerFixed { get => _mba3PEPower; set => _mba3PEPower = value; }

        protected DTOTransThreeEPower _dtoMBA3P;

        public frmDataMBA3()
        {
            InitializeComponent();
        }

        private void frmDataMBA3_Load(object sender, EventArgs e)
        {
            if (this._mba3PEPower != null)
            {
                this._dtoMBA3P = this._mba3PEPower.DatabaseE.DataRecordE.DTOTransThreeEPower;

                //Show Zone Basic Data
                this.ShowZoneBasicDataTransformer3P();

                //Transformer Impedance Data
                this.ShowTransformerImpedanceData();

                //Transformer Data
                this.ShowTransformerData();

                //Fixed Tap
                this.ShowFixedTap();
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
        protected virtual void ShowFixedTap()
        {
            //Unit Mode for btnUnit and lblTransUnit
            UnitTapMode unitMode = this._dtoMBA3P.UnitTap_Main;

            //btnTransTap
            this.btnTransUnit.Text = (unitMode == UnitTapMode.Percent) ? "% Tap" : "kV Tap";

            //lblTransUnit
            this.lblTransUnit.Text = (unitMode == UnitTapMode.Percent) ? "kV Tap" : "% Tap";

            //Voltage Fixed Prim
            double Per_Prim = Math.Round((this._dtoMBA3P.Percent_PrimFixed - 1) * 100, 4);
            this.txtVolFixedPrim.Text = (unitMode == UnitTapMode.Percent) ? Per_Prim + "" : this._dtoMBA3P.VoltageEnds_kV_Fixed.VolPrim_kV + "";
            //Tertiary
            double Per_Ter = Math.Round((this._dtoMBA3P.Percent_TerFixed - 1) * 100, 4);
            this.txtVolFixedTer.Text = (unitMode == UnitTapMode.Percent) ? Per_Ter + "" : this._dtoMBA3P.VoltageEnds_kV_Fixed.VolTer_kV + "";
            //Sec
            double Per_Sec = Math.Round((this._dtoMBA3P.Percent_SecFixed - 1) * 100, 4);
            this.txtVolFixedSec.Text = (unitMode == UnitTapMode.Percent) ? Per_Sec + "" : this._dtoMBA3P.VoltageEnds_kV_Fixed.VolSec_kV + "";

            //lblTrans Fixed
            this.lblTransPrim.Text = (unitMode == UnitTapMode.Percent) ? this._dtoMBA3P.VoltageEnds_kV_Fixed.VolPrim_kV + "" : this._dtoMBA3P.Percent_PrimFixed + "";
            //Tertiary
            this.lblTransTer.Text = (unitMode == UnitTapMode.Percent) ? this._dtoMBA3P.VoltageEnds_kV_Fixed.VolTer_kV + "" : this._dtoMBA3P.Percent_TerFixed + "";
            //Sec
            this.lblTransSec.Text = (unitMode == UnitTapMode.Percent) ? this._dtoMBA3P.VoltageEnds_kV_Fixed.VolSec_kV + "" : this._dtoMBA3P.Percent_SecFixed + "";

            //Per unit
            //Prim
            this.lblPerUnitPrim.Text = Per_Prim + "";
            //Ter
            this.lblPerUnitTer.Text = Per_Ter + "";
            //Sec
            this.lblPerUnitSec.Text = Per_Sec + "";

            //Description
            this.rtbDescription.Text = this._dtoMBA3P.Description;
        }

        #endregion Show_Data
    }
}
