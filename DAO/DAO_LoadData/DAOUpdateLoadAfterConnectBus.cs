using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;
using Experimential_Software.EPowerProcess;

namespace Experimential_Software.DAO.DAO_LoadData
{
    public class DAOUpdateLoadAfterConnectBus
    {
        private static DAOUpdateLoadAfterConnectBus _instance;

        public static DAOUpdateLoadAfterConnectBus Instance
        {
            get { if (_instance == null) _instance = new DAOUpdateLoadAfterConnectBus(); return _instance; }
           private set {; }
        }

        private DAOUpdateLoadAfterConnectBus() { }

        public virtual void UpDateLoadRecordAfterConnectBus(ConnectableE loadEPower)
        {
            //get BusConnect. Bus always connect by Phead
            ConnectableE busConnected = this.GetBusConnectWithLoad(loadEPower);

            if (busConnected == null)
            {
                //same case MF. Load Only connect a bus . <=> bus null => DTO bus Connect null
                loadEPower.DatabaseE.DataRecordE.DTOLoadEPower.DTOBusConnected = null;
                return;
            }
            //Get DTO Bus
            DTOBusEPower dtoBusEPower = busConnected.DatabaseE.DataRecordE.DTOBusEPower;

            //Set data bus inside Load
            DTOLoadEPower dtoLoadEPower = loadEPower.DatabaseE.DataRecordE.DTOLoadEPower;
            dtoLoadEPower.DTOBusConnected = dtoBusEPower;

        }

        protected virtual ConnectableE GetBusConnectWithLoad(ConnectableE loadEPower)
        {
            //Get Class ProcessEPowerMove => Get Function get Line
            //   ProcessEPowerMove processEPowerMove = loadEPower.EPowerProcessMouse.ProcessEPowerMove;
            //get Line Connect Bus with Load. Load only connect with Bus

            //<LineConnect> ListlineConnected = processEPowerMove.GetLineStageEPower(loadEPower);

            List<LineConnect> ListlineConnected = loadEPower.ListBranch_Drawn;

            if (ListlineConnected.Count == 0) return null;

            LineConnect lineConnectedBus = ListlineConnected[0];
            //Start Coincode Load => End is Bus. Start Diffence Load => End is Bus
            ConnectableE busConnected = lineConnectedBus.StartEPower.DatabaseE.ObjectType == ObjectType.Load ? lineConnectedBus.EndEPower : lineConnectedBus.StartEPower;

            return busConnected;
        }
    }
}
