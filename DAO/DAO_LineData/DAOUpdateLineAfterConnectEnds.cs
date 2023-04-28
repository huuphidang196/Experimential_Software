using Experimential_Software.CustomControl;
using Experimential_Software.EPowerProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_LineData
{
    public class DAOUpdateLineAfterConnectEnds
    {
        private static DAOUpdateLineAfterConnectEnds _instance;

        public static DAOUpdateLineAfterConnectEnds Instance
        {
            get { if (_instance == null) _instance = new DAOUpdateLineAfterConnectEnds(); return DAOUpdateLineAfterConnectEnds._instance; }
            private set { DAOUpdateLineAfterConnectEnds._instance = value; }
        }

        private DAOUpdateLineAfterConnectEnds() { }

        public virtual void UpdateLineAfterConnectEnds(ConnectableE lineEPower)
        {
            //Line isnot Connected with Line
            List<ConnectableE> ListEPowerEnds = this.GetEPowerConnectWithLineEPOwer(lineEPower);

            if (ListEPowerEnds.Count == 0) return;

            for (int i = 0; i < ListEPowerEnds.Count; i++)
            {
                DTOBusEPower dtoBusEPower = ListEPowerEnds[i].DatabaseE.DataRecordE.DTOBusEPower;
                //set From and End
                if (i == 0) lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBusFrom = dtoBusEPower;
                if (i == 1) lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBusTo = dtoBusEPower;
            } 
        }

        protected virtual List<ConnectableE> GetEPowerConnectWithLineEPOwer(ConnectableE lineEPower)
        {
            //Get Class ProcessEPowerMove => Get Function get Line
            ProcessEPowerMove processEPowerMove = lineEPower.EPowerProcessMouse.ProcessEPowerMove;
            //get Line Connect Bus with Load. Line only connect with Bus => similar Load
            List<LineConnect> lineConnecteds = processEPowerMove.GetLineStageEPower(lineEPower);

            if (lineConnecteds.Count == 0) return null;

            List<ConnectableE> ListBusEPowerEnds = new List<ConnectableE>();
            foreach (LineConnect lineConnected in lineConnecteds)
            {
                //Start Coincode LineEPower => End is another EPower. Start Diffence Line => End is another EPower.Line isnot Connected with Line
                ConnectableE BusEPower = lineConnected.StartEPower.DatabaseE.ObjectType == ObjectType.LineEPower ? lineConnected.EndEPower : lineConnected.StartEPower;
                ListBusEPowerEnds.Add(BusEPower);
            }

            return ListBusEPowerEnds;
        }
    }
}
