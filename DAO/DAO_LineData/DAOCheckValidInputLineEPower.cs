using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Experimential_Software.DAO.DAO_LineData
{
    public class DAOCheckValidInputLineEPower
    {
        private static DAOCheckValidInputLineEPower _instance;

        public static DAOCheckValidInputLineEPower Instance
        {
            get { if (_instance == null) _instance = new DAOCheckValidInputLineEPower(); return DAOCheckValidInputLineEPower._instance; }
            private set { DAOCheckValidInputLineEPower._instance = value; }
        }

        private DAOCheckValidInputLineEPower() { }

        public virtual bool CheckValidInputDataLine(params string[] dataLineE)
        {
            foreach (string data in dataLineE)
            {
                bool isIDInter = data.Split('.')[0].All(c => char.IsDigit(c));
                if (!isIDInter)
                {
                    MessageBox.Show(data + " is not Integer!", "Error ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }                              
            }
            return true;
        }
    }
}
