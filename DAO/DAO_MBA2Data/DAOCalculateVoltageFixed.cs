using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.DTO;

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

        public virtual double GetPercentVoltageFixedByVoltageRated(string strVolRated, string strVolFixed, UnitTapMode unitMode)
        {
            double Vol_Rated = double.Parse(strVolRated);
            double Vol_Fixed = double.Parse(strVolFixed);

            double percent_Fixed = 0;

            if (unitMode == UnitTapMode.Percent)
            {
                //Get Percent Directly
                percent_Fixed = 1 + Vol_Fixed / 100;
                return percent_Fixed;
            }

            //kV Mode
            if (Vol_Rated == 0) return 1;//Voltage Value not entered

            //Volatage diff 0 => not NaN
            percent_Fixed = Vol_Fixed / Vol_Rated;

            return percent_Fixed;
        }

    }
}
