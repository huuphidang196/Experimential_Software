using Experimential_Software.CustomControl;
using Experimential_Software.EPowerProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;
using System.Windows.Forms;

namespace Experimential_Software.DAO.DAO_LineData
{
    public class DAOUpdateLineAfterConnectEnds
    {
        private static DAOUpdateLineAfterConnectEnds _instance;

        public static DAOUpdateLineAfterConnectEnds Instance
        {
            get { if (_instance == null) _instance = new DAOUpdateLineAfterConnectEnds(); return _instance; }
            private set { _instance = value; }
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
                if (lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBusFrom == null) lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBusFrom = dtoBusEPower;
                else lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBusTo = dtoBusEPower;
            }

            //not use set value beacause error 
            DTOBusEPower dtoBus_From = lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBusFrom;
            DTOBusEPower dtoBus_To = lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBusTo;

            if (dtoBus_From == null || dtoBus_To == null) return;

            //Check Again valid Location Bus Ends is Connnected with MBA2
            if (dtoBus_From.ObjectNumber < dtoBus_To.ObjectNumber) return;

            //Set Again DTO From and to. If number obj of any DTO min => set from, other set Bus to
            DTOBusEPower dtoBusTemp = dtoBus_From;
            lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBusFrom = dtoBus_To;
            lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBusTo = dtoBusTemp;
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
