using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_MBA2Data
{
    public class DAOCalculateVoltageFixed
    {
        private static DAOCalculateVoltageFixed _instance;
        public static DAOCalculateVoltageFixed Instance
        {
            get { if (DAOCalculateVoltageFixed._instance == null) DAOCalculateVoltageFixed._instance = new DAOCalculateVoltageFixed(); return _instance; }
            private set {; }
        }

        private DAOCalculateVoltageFixed() {; }

        public virtual double TransferKVUnitToPercentTap(DTOTransTwoEPower dtoMBA2 ,bool isPrim)
        {
            //tap zero base get data from volatgeRated. => get normalKv
            double normalKvBusEnds = isPrim ? dtoMBA2.VoltageEnds_Rated.VolPrim_kV : dtoMBA2.VoltageEnds_Rated.VolSec_kV;
            //get Volatage Fixed by isPrim
            double Vol_FixedEnds = isPrim ? dtoMBA2.VoltageEnds_Fixed.VolPrim_kV : dtoMBA2.VoltageEnds_Fixed.VolSec_kV;

            //Transfer to percent compare to normalBus
            double percent = (Vol_FixedEnds - normalKvBusEnds) / (normalKvBusEnds + 0.000000001);//avoid divisor = 0. that will appeear NaN error

            return Math.Round(percent, 2);
        }

    }
}
