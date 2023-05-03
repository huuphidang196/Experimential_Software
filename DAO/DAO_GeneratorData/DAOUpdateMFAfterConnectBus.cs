using Experimential_Software.CustomControl;
using Experimential_Software.EPowerProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_GeneratorData
{
    public class DAOUpdateMFAfterConnectBus
    {
        private static DAOUpdateMFAfterConnectBus _instance;

        public static DAOUpdateMFAfterConnectBus Instance
        {
            get { if (_instance == null) _instance = new DAOUpdateMFAfterConnectBus(); return DAOUpdateMFAfterConnectBus._instance; }
            private set { DAOUpdateMFAfterConnectBus._instance = value; }
        }

        private DAOUpdateMFAfterConnectBus() { }

        public virtual void UpdateMFAfterConnectEnds(ConnectableE MFEPower)
        {
            //Line isnot Connected with Line
            ConnectableE BusConnected = this.GetEPowerConnectWithMFEPOwer(MFEPower);

            if (BusConnected == null)
            {
                //it only connect with one Bus. So if Bus null <=> DTOBus Connected null
                MFEPower.DatabaseE.DataRecordE.DTOGeneEPower.DTOBusConnected = null;
                return;
            }
            DTOBusEPower dtoBusEPower = BusConnected.DatabaseE.DataRecordE.DTOBusEPower;
            //Set dto bus connected with MF
            MFEPower.DatabaseE.DataRecordE.DTOGeneEPower.DTOBusConnected = dtoBusEPower;
        }

        protected virtual ConnectableE GetEPowerConnectWithMFEPOwer(ConnectableE lineEPower)
        {
            //Get Class ProcessEPowerMove => Get Function get Line
            ProcessEPowerMove processEPowerMove = lineEPower.EPowerProcessMouse.ProcessEPowerMove;
            //get ConnectedBus with MF. MF only connect with Bus => similar Load
            List<LineConnect> ListlineConnected = processEPowerMove.GetLineStageEPower(lineEPower);

            if (ListlineConnected.Count == 0) return null;

            LineConnect lineConnected = ListlineConnected[0];
            //Start Coincode MFEPower => End is another EPower. Start Diffence MF
            ConnectableE BusEPower = lineConnected.StartEPower.DatabaseE.ObjectType == ObjectType.MF ? lineConnected.EndEPower : lineConnected.StartEPower;

            return BusEPower;
        }


    }
}
