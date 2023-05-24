using Experimential_Software.Class_Database;
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

        public virtual ImpedanceMBA3 GetImpedanceMBA3PTapZeroWhenStart(DTOTransThreeEPower dtoMBA3P)
        {
            VoltageEnds3P voltageRated3P = dtoMBA3P.VoltageEnds_kV_Rated;
            VoltageEnds3P voltageFixed3P = dtoMBA3P.VoltageEnds_kV_Fixed;

            // (k'/k) ^2 prim_Ter
            double mul_Prim_Ter = Math.Pow(voltageFixed3P.K_Ratio_Vol_Prim_Ter / voltageRated3P.K_Ratio_Vol_Prim_Ter, 2);
            double mul_Prim_Sec = Math.Pow(voltageFixed3P.K_Ratio_Vol_Prim_Sec / voltageRated3P.K_Ratio_Vol_Prim_Sec, 2);
            double mul_Ter_Sec = Math.Pow(voltageFixed3P.K_Ratio_Vol_Ter_Sec / voltageRated3P.K_Ratio_Vol_Ter_Sec, 2);

            ImpedanceMBA3 impedanceMBA3 = new ImpedanceMBA3();

            //Temp => Incorrect but when need change Impedance => change. not important
            // R, X  of Prim , Ter, Sec
            SpecImpedanceMBA3RX SpecRX_Prim = dtoMBA3P.Impendance_MBA3.SpecRX_Prim;
            SpecRX_Prim.SpecR_pu = SpecRX_Prim.SpecR_pu / mul_Prim_Sec;
            SpecRX_Prim.SpecX_pu = SpecRX_Prim.SpecX_pu / mul_Prim_Sec;

            SpecImpedanceMBA3RX SpecRX_Ter = dtoMBA3P.Impendance_MBA3.SpecRX_Ter;
            SpecRX_Ter.SpecR_pu = SpecRX_Ter.SpecR_pu / mul_Prim_Ter;
            SpecRX_Ter.SpecX_pu = SpecRX_Ter.SpecX_pu / mul_Prim_Ter;

            SpecImpedanceMBA3RX SpecRX_Sec = dtoMBA3P.Impendance_MBA3.SpecRX_Sec;
            SpecRX_Sec.SpecR_pu = SpecRX_Sec.SpecR_pu / mul_Ter_Sec;
            SpecRX_Sec.SpecX_pu = SpecRX_Sec.SpecX_pu / mul_Ter_Sec;

            impedanceMBA3.SpecRX_Prim = SpecRX_Prim;
            impedanceMBA3.SpecRX_Ter = SpecRX_Ter;
            impedanceMBA3.SpecRX_Sec = SpecRX_Sec;

            impedanceMBA3.MagB_pu = dtoMBA3P.Impendance_MBA3.MagB_pu;
            impedanceMBA3.MagG_pu = dtoMBA3P.Impendance_MBA3.MagG_pu;

            return impedanceMBA3;
        }
    }
}
