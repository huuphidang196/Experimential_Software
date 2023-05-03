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

       

    }
}
