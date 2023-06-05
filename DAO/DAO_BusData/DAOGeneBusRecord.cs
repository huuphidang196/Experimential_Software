using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;
using System.Windows.Forms;
using Experimential_Software.CustomControl;

namespace Experimential_Software.DAO.DAO_BusData
{
    public class DAOGeneBusRecord
    {
        private static DAOGeneBusRecord _instance;

        public static DAOGeneBusRecord Instance
        {
            get { if (_instance == null) _instance = new DAOGeneBusRecord(); return DAOGeneBusRecord._instance; }
            private set { DAOGeneBusRecord._instance = value; }
        }

        private DAOGeneBusRecord() { }

        public virtual DTOBusEPower GenerateDTOBusDefault(int ExistOrderBus)
        {
            DTOBusEPower dtoBusE = new DTOBusEPower();

            //Basic Data
            dtoBusE.ObjectName = "";

            int numberObjectType = (int)ObjectType.Bus * 100;
            dtoBusE.ObjectNumber = (ExistOrderBus < 100) ? numberObjectType + 1 : ExistOrderBus + 1;

            dtoBusE.TypeCodeBus = TypeCodeBus.Non_Gen_Bus;
            dtoBusE.BasekV = 0;
            dtoBusE.KChangerTap = 1;
            dtoBusE.Voltage_pu = 1;
            dtoBusE.Angle_rad = 0;

            //limitData
            dtoBusE.Normal_Vmax_pu = 1.1;
            dtoBusE.Normal_Vmin_pu = 0.9;

            dtoBusE.Emer_Vmax_pu = 1.1;
            dtoBusE.Emer_Vmin_pu = 0.9;

            return dtoBusE;
        }

        public virtual void ProcessUpdateNameBusForLineConnected(ConnectableE busConsidered)
        {
            List<LineConnect> listLineDrawn = busConsidered.ListBranch_Drawn;

            if (listLineDrawn.Count == 0) return;

            this.AddEPowerOnList(ObjectType.LineEPower, listLineDrawn);
        }

        protected virtual void AddEPowerOnList(ObjectType objectType, List<LineConnect> listLineDrawn)
        {
            List<ConnectableE> listEPowersConn = new List<ConnectableE>();
            foreach (LineConnect lineBranch in listLineDrawn)
            {
                if (lineBranch.StartEPower.DatabaseE.ObjectType == objectType) listEPowersConn.Add(lineBranch.StartEPower);
                else if (lineBranch.EndEPower.DatabaseE.ObjectType == objectType) listEPowersConn.Add(lineBranch.EndEPower);
            }

            if (listEPowersConn.Count == 0) return;

            foreach (ConnectableE item in listEPowersConn)
            {
                item.UpdateDataRecordEPowerWhenConnectOrRemove(false);
            }
        }
    }
}
