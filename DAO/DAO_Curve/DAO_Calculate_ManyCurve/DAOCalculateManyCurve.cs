using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.DAO.DAO_Curve.DAO_Calculate_ManyCurve
{
    public class DAOCalculateManyCurve
    {
        private static DAOCalculateManyCurve _instance;
        public static DAOCalculateManyCurve Instance
        {
            get { if (_instance == null) _instance = new DAOCalculateManyCurve(); return _instance; }
            private set { }
        }

        private DAOCalculateManyCurve() { }


        public virtual ConnectableE GetELoadFromBusConsider(List<ConnectableE> allEPowerOri, int busChangePower)
        {
            int numberBusChanged = 100 * (int)ObjectType.Bus + busChangePower;

            ConnectableE EbusChanged = allEPowerOri.Find(x => x.DatabaseE.ObjectType == ObjectType.Bus && x.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber == numberBusChanged);
            if (EbusChanged == null)
            {
                MessageBox.Show("Bus not exist!");
                return null;
            }

            LineConnect lineConnect = EbusChanged.ListBranch_Drawn.Find(x => x.StartEPower.DatabaseE.ObjectType == ObjectType.Load || x.EndEPower.DatabaseE.ObjectType == ObjectType.Load);

            ConnectableE ELoadConnect = (lineConnect.StartEPower.DatabaseE.ObjectType == ObjectType.Load) ? lineConnect.StartEPower : lineConnect.EndEPower;
            return ELoadConnect;
        }
    }
}
