using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.DAO.DAO_Curve.DAO_Calculate
{
    public class DAOCalculateQLJStepOne
    {
        private static DAOCalculateQLJStepOne _instance;
        public static DAOCalculateQLJStepOne Instance
        {
            get { if (_instance == null) _instance = new DAOCalculateQLJStepOne(); return _instance; }
            private set { }
        }
        private DAOCalculateQLJStepOne() { }
    }
}
