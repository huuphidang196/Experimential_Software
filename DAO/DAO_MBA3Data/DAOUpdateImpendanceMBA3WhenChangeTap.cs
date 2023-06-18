using Experimential_Software.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.DAO.DAO_MBA3Data
{
   public  class DAOUpdateImpendanceMBA3WhenChangeTap
    {
        private static DAOUpdateImpendanceMBA3WhenChangeTap _instance;

        public static DAOUpdateImpendanceMBA3WhenChangeTap Instance
        {
            get { if (_instance == null) _instance = new DAOUpdateImpendanceMBA3WhenChangeTap(); return _instance; }
            private set { _instance = value; }
        }

        private DAOUpdateImpendanceMBA3WhenChangeTap() { }

    
        public virtual void SetZoneBasicData(DTOTransThreeEPower dtoMBA3P, int ObjNumber, string ObjName, int index_InService)
        {
            //this MBA3P
            //Object Number
            dtoMBA3P.ObjectNumber = ObjNumber;
            //Object Name
            dtoMBA3P.ObjectName = ObjName;
            //Set index  InService
            dtoMBA3P.Index_InService = index_InService;
        }

        public virtual void SetZoneImpedanceData(DTOTransThreeEPower dtoMBA3P, double SpecR_Prim, double SpecX_Prim, double SpecR_Ter, double SpecX_Ter, double SpecR_Sec, double SpecX_Sec, double MagG, double MagB)
        {
            //SpecRX Prim
            SpecImpedanceMBA3RX SpecPrim = DAOGeneMBA3Record.Instance.GenerateSpecRX(SpecR_Prim, SpecX_Prim);
            dtoMBA3P.Impedance_MBA3.SpecRX_Prim = SpecPrim;

            //SpecRX Tertiary
            SpecImpedanceMBA3RX SpecTer = DAOGeneMBA3Record.Instance.GenerateSpecRX(SpecR_Ter, SpecX_Ter);
            dtoMBA3P.Impedance_MBA3.SpecRX_Ter = SpecTer;

            //SpecRX Sec
            SpecImpedanceMBA3RX SpecSec = DAOGeneMBA3Record.Instance.GenerateSpecRX(SpecR_Sec, SpecX_Sec);
            dtoMBA3P.Impedance_MBA3.SpecRX_Sec = SpecSec;

            //Mag G,B
            dtoMBA3P.Impedance_MBA3.MagG_pu = MagG;
            dtoMBA3P.Impedance_MBA3.MagB_pu = MagB;

        }

        public virtual void SetZoneTransformerData(DTOTransThreeEPower dtoMBA3P, double BaseMVA_Prim, double BaseMVA_Ter, double BaseMVA_Sec, double vol_ratedPrim, double vol_ratedTer, double vol_ratedSec)
        {
            //MVA base Prim
            dtoMBA3P.Trans3Winding_MVABase.BaseMVA_Prim = BaseMVA_Prim;
            //MVA base Ter
            dtoMBA3P.Trans3Winding_MVABase.BaseMVA_Ter = BaseMVA_Ter;
            //MVA base Sec 
            dtoMBA3P.Trans3Winding_MVABase.BaseMVA_Sec = BaseMVA_Sec;

            //Volatage Rated
            dtoMBA3P.VoltageEnds_kV_Rated = DAOGeneMBA3Record.Instance.GenerateVoltageEndsByNumber(vol_ratedPrim, vol_ratedTer, vol_ratedSec);

        }

        public virtual void SetZoneFixedTap(DTOTransThreeEPower dtoMBA3P, double Percent_PrimFixed, double Percent_TerFixed, double Percent_SecFixed)
        {
            //Only Save Per for Fixed Tap
            dtoMBA3P.Percent_PrimFixed = Percent_PrimFixed;
            dtoMBA3P.Percent_TerFixed = Percent_TerFixed;
            dtoMBA3P.Percent_SecFixed = Percent_SecFixed;
        }
    }
}
