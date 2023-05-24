using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_MBA2Data
{
    public class DAOUpdateImpendanceWhenChangeTap
    {
        private static DAOUpdateImpendanceWhenChangeTap _instance;
        public static DAOUpdateImpendanceWhenChangeTap Instance
        {
            get { if (_instance == null) _instance = new DAOUpdateImpendanceWhenChangeTap(); return _instance; }
            private set {; }
        }

        private DAOUpdateImpendanceWhenChangeTap() {; }

        public virtual ImpendanceMBA2 ProcessUpdateImpendanceByTransformerRatio(DTOTransTwoEPower dtoTrans, ImpendanceMBA2 _impendanceTemp)
        {
            double ratioFixed_Ks = dtoTrans.VoltageEnds_kV_Fixed.K_Ratio_Vol_Prim_Sec;
            double ratioRated_K = dtoTrans.VoltageEnds_kV_Rated.K_Ratio_Vol_Prim_Sec;

          //  MessageBox.Show("ratioFixed_Ks =" + ratioFixed_Ks + ", ratioRated_K = " + ratioRated_K);

            double mul_K_Transfer = Math.Round(Math.Pow(ratioFixed_Ks / ratioRated_K, 2), 6);
            //m = (k'/k)^2
            //SpecR_pu
            double SpecR_pu = _impendanceTemp.SpecR_pu * mul_K_Transfer;
            //SpecX_pu
            double SpecX_pu = _impendanceTemp.SpecX_pu * mul_K_Transfer;

            //MagG_pu not change when change Tap
            double MagG_pu = _impendanceTemp.MagG_pu;
            //MagB_pu  not change when change Tap
            double MagB_pu = _impendanceTemp.MagB_pu;

            //Clone ImpendancemBA temp 
            ImpendanceMBA2 impendanceMBA2Tem = new ImpendanceMBA2(SpecR_pu, SpecX_pu, MagG_pu, MagB_pu);

            return impendanceMBA2Tem;
        }

        //When Start
        public virtual ImpendanceMBA2 ProcessUpdateImpendanceTempWhenStart(DTOTransTwoEPower dtoTrans)
        {
            double ratioFixed_Ks = dtoTrans.VoltageEnds_kV_Fixed.K_Ratio_Vol_Prim_Sec;
            double ratioRated_K = dtoTrans.VoltageEnds_kV_Rated.K_Ratio_Vol_Prim_Sec;

            double mul_K_Transfer = Math.Round(Math.Pow(ratioFixed_Ks / ratioRated_K, 2), 6);

        //    MessageBox.Show("ratioFixed_Ks =" + ratioFixed_Ks + ", ratioRated_K = " + ratioRated_K);
            ImpendanceMBA2 impendanceOld = dtoTrans.Impendance_MBA2;

            //SpecR_pu
            double SpecR_pu = impendanceOld.SpecR_pu / mul_K_Transfer;
            //SpecX_pu
            double SpecX_pu = impendanceOld.SpecX_pu / mul_K_Transfer;

            //MagG_pu  not change when change Tap
            double MagG_pu = impendanceOld.MagG_pu;
            //MagB_pu  not change when change Tap
            double MagB_pu = impendanceOld.MagB_pu;

            //Clone ImpendancemBA temp 
            ImpendanceMBA2 impendanceMBA2Tem = new ImpendanceMBA2(SpecR_pu, SpecX_pu, MagG_pu, MagB_pu);

            return impendanceMBA2Tem;
        }
    }
}
