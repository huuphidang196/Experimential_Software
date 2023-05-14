using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.Class_Database
{
    [Serializable]
    public class SpecImpedanceMBA3RX
    {
        //R
        protected double _specR_pu;
        public double SpecR_pu
        {
            get { return _specR_pu; }
            set { _specR_pu = Math.Round(value, 6); }
        }

        //X
        protected double _specX_pu;
        public double SpecX_pu
        {
            get { return _specX_pu; }
            set { _specX_pu = Math.Round(value, 6); }
        }
    }

    [Serializable]
    public class ImpedanceMBA3
    {
        //C
        public SpecImpedanceMBA3RX SpecRX_Prim { get; set; }
        //T
        public SpecImpedanceMBA3RX SpecRX_Ter { get; set; }
        //H
        public SpecImpedanceMBA3RX SpecRX_Sec { get; set; }

        //G
        protected double _magG_pu;
        public double MagG_pu
        {
            get { return _magG_pu; }
            set { _magG_pu = Math.Round(value, 6); }
        }

        //B
        protected double _magB_pu;
        public double MagB_pu
        {
            get { return _magB_pu; }
            set
            {
                _magB_pu = Math.Round(value, 6);
            }
        }

        #region Res_Start

        //Zij_Y_Start C PRim
        public Complex Res_pu_Prim_Start => new Complex(this.SpecRX_Prim.SpecR_pu, this.SpecRX_Prim.SpecX_pu);

        //Zij_Y_Start T ter
        public Complex Res_pu_Ter_Start => new Complex(this.SpecRX_Ter.SpecR_pu, this.SpecRX_Ter.SpecX_pu);

        //Zij_Y_Start H Sec
        public Complex Res_pu_Sec_Start => new Complex(this.SpecRX_Sec.SpecR_pu, this.SpecRX_Sec.SpecX_pu);

        #endregion Res_Start

        #region Res_Triangle

        //Zij_Y_Triangle C_T PRim_Ter
        public Complex Res_pu_CT_Triangle
        {
            get
            {
                return this.Res_pu_Prim_Start + this.Res_pu_Ter_Start + ((this.Res_pu_Prim_Start * this.Res_pu_Ter_Start) / this.Res_pu_Sec_Start);
            }

        }

        //Zij_Y_Triangle C_H PRim_Sec
        public Complex Res_pu_CH_Triangle
        {
            get
            {
                return this.Res_pu_Prim_Start + this.Res_pu_Sec_Start + ((this.Res_pu_Prim_Start * this.Res_pu_Sec_Start) / this.Res_pu_Ter_Start);
            }

        }

        //Zij_Y_Triangle T_H Ter_Sec
        public Complex Res_pu_TH_Triangle
        {
            get
            {
                return this.Res_pu_Ter_Start + this.Res_pu_Sec_Start + ((this.Res_pu_Ter_Start * this.Res_pu_Sec_Start) / this.Res_pu_Prim_Start);
            }

        }

        #endregion Res_Triangle

        #region Conductance_Relative_Y1Ends_Yij
        //Yij_CT
        public Complex Yij_Con_Relative_Prim_Ter => (1 / this.Res_pu_CT_Triangle);
        //Yij_CH
        public Complex Yij_Con_Relative_Prim_Sec => (1 / this.Res_pu_CH_Triangle);
        //Yij_TH
        public Complex Yij_Con_Relative_Ter_Sec => (1 / this.Res_pu_TH_Triangle);

        #endregion Conductance_Relative_Y1Ends_Yij

        #region Conductance_Relative_Y2Ends
        //sum of Y_CT and Y_CH => Bus Prim
        public Complex Yb_Sum_Con_Relative_Prim
        {
            get { return this.Yij_Con_Relative_Prim_Ter + this.Yij_Con_Relative_Prim_Sec; }
        }

        //sum of Y_CT and Y_TH => Bus Ter
        public Complex Yb_Sum_Con_Relative_Ter
        {
            get { return this.Yij_Con_Relative_Prim_Ter + this.Yij_Con_Relative_Ter_Sec; }
        }

        //sum of Y_CH and Y_TH => Bus Sec
        public Complex Yb_Sum_Con_Relative_Sec
        {
            get { return this.Yij_Con_Relative_Prim_Sec + this.Yij_Con_Relative_Ter_Sec; }
        }
        #endregion Conductance_Relative_Y2Ends


        //Y0B = G + jB
        public Complex Y0b_Con_MBA3_pu => new Complex(this._magG_pu, this._magB_pu);

        public ImpedanceMBA3()
        {
            this.SpecRX_Prim.SpecX_pu = 0.0002;
            this.SpecRX_Ter.SpecX_pu = 0.0002;
            this.SpecRX_Sec.SpecX_pu = 0.0002;
        }

        public ImpedanceMBA3(SpecImpedanceMBA3RX SpecRX_Prim, SpecImpedanceMBA3RX SpecRX_Ter, SpecImpedanceMBA3RX SpecRX_Sec, double MagG, double MagB)
        {
            this.SpecRX_Prim.SpecR_pu = SpecRX_Prim.SpecR_pu;
            this.SpecRX_Prim.SpecX_pu = SpecRX_Prim.SpecX_pu;

            this.SpecRX_Ter.SpecR_pu = SpecRX_Ter.SpecR_pu;
            this.SpecRX_Ter.SpecX_pu = SpecRX_Ter.SpecX_pu;

            this.SpecRX_Sec.SpecR_pu = SpecRX_Sec.SpecR_pu;
            this.SpecRX_Sec.SpecX_pu = SpecRX_Sec.SpecX_pu;

            this._magG_pu = MagG;
            this._magB_pu = MagB;
        }
    }

    [Serializable]
    public class VoltageEnds3P : VoltageEnds2P
    {
        //Tertiary - cuộn trung áp
        protected double _volTer_kV;
        public double VolTer_kV
        {
            get { return _volTer_kV; }
            set { _volTer_kV = Math.Round(value, 3); }
        }

        public double K_Ratio_Vol_Prim_Ter { get { if (this._volPrim_kV != 0 && this._volTer_kV != 0) return this._volPrim_kV / this._volTer_kV; return 1; } } //Uprim/Utertiary
        public double K_Ratio_Vol_Ter_Sec { get { if (this._volTer_kV != 0 && this._volSec_kV != 0) return this._volTer_kV / this._volSec_kV; return 1; } } //Utertiary/Usec

    }

    [Serializable]
    public class DTOTransThreeEPower : DataRecordEPower
    {
        //Line Data MBA2
        public DTOBusEPower DTOBus_From { get; set; }
        public DTOBusEPower DTOBus_To { get; set; }
        public DTOBusEPower DTOBus_Ter { get; set; }

        public bool IsInService { get; set; }

        //Power Rating
        protected double _powerRated_MVA;

        public double PowerRated_MVA
        {
            get { return _powerRated_MVA; }
            set { _powerRated_MVA = Math.Round(value, 3); }
        }


        //Voltage Rating MBA . U Ends
        public VoltageEnds3P VoltageEnds_Rated { get; set; }


        //Unit Mode of Changer Form Main
        public UnitTapMode UnitTap_Main { get; set; }

        //percent Voltage Fixed compare to Rated
        public double Percent_PrimFixed { get; set; }
        public double Percent_SecFixed { get; set; }
        public double Percent_TerFixed { get; set; }


        //Fixed Voltage After Adjust Tap Changer
        protected VoltageEnds3P _voltageEnds_Fixed;
        public VoltageEnds3P VoltageEnds_Fixed
        {
            get
            {
                _voltageEnds_Fixed.VolPrim_kV = this.Percent_PrimFixed * this.VoltageEnds_Rated.VolPrim_kV;
                _voltageEnds_Fixed.VolSec_kV = this.Percent_SecFixed * this.VoltageEnds_Rated.VolSec_kV;

                //Tertiary 
                _voltageEnds_Fixed.VolTer_kV = this.Percent_TerFixed * this.VoltageEnds_Rated.VolTer_kV;
                return _voltageEnds_Fixed;
            }
        }

        //Transfomer Impendance Data

        public ImpedanceMBA3 Impendace_MBA3 { get; set; }


    }
}
