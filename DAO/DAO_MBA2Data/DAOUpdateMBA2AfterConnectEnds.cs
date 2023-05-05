using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;
using Experimential_Software.EPowerProcess;

namespace Experimential_Software.DAO.DAO_MBA2Data
{
    public class DAOUpdateMBA2AfterConnectEnds
    {
        private static DAOUpdateMBA2AfterConnectEnds _instance;

        public static DAOUpdateMBA2AfterConnectEnds Instance
        {
            get { if (_instance == null) _instance = new DAOUpdateMBA2AfterConnectEnds(); return _instance; }
            private set { _instance = value; }
        }

        private DAOUpdateMBA2AfterConnectEnds() { }

        public virtual void UpdateMBA2AfterConnectEnds(ConnectableE mba2EPower, bool isRemoved)
        {
            //Get 2 Bus connected with MBA2P
            List<ConnectableE> ListEPowerEnds = this.GetEPowerConnectWithMBA2EPOwer(mba2EPower);

            if (ListEPowerEnds == null)
            {
                //Ends null <=> 2 Bus From and to null <=> DTO bus From and To null
                mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From = null;
                mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_To = null;
                return;
            }

            for (int i = 0; i < ListEPowerEnds.Count; i++)
            {
                DTOBusEPower dtoBusEPower = ListEPowerEnds[i].DatabaseE.DataRecordE.DTOBusEPower;
                if (isRemoved) this.ProcessRemovedDTOBusRemoved(mba2EPower, dtoBusEPower);
                //set From and End
                if (mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From == null) mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From = dtoBusEPower;
                else mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_To = dtoBusEPower;
            }

            //Only use compare not set because set will error
            DTOBusEPower dtoBus_From = mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From;
            DTOBusEPower dtoBus_To = mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_To;

            if (dtoBus_From == null || dtoBus_To == null) return;

            //Check Again valid Location Bus Ends is Connnected with MBA2
            if (dtoBus_From.ObjectNumber < dtoBus_To.ObjectNumber) return;

            //Set Again DTO From and to. If number obj of any DTO min => set from, other set Bus to
            DTOBusEPower dtoBusTemp = dtoBus_From;
            mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From = dtoBus_To;
            mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_To = dtoBusTemp;

        }

        protected virtual List<ConnectableE> GetEPowerConnectWithMBA2EPOwer(ConnectableE mba2EPower)
        {
            //Get Class ProcessEPowerMove => Get Function get Line
         //   ProcessEPowerMove processEPowerMove = mba2EPower.EPowerProcessMouse.ProcessEPowerMove;
            //get Line Connect Bus with MBA. BUs only connect with Bus 
           // List<LineConnect> lineConnecteds = processEPowerMove.GetLineStageEPower(mba2EPower);

            List<LineConnect> lineConnecteds = mba2EPower.ListBranch_Drawn;

            if (lineConnecteds.Count == 0) return null;

            List<ConnectableE> ListBusEPowerEnds = new List<ConnectableE>();
            foreach (LineConnect lineConnected in lineConnecteds)
            {
                //Start Coincide MBA2EPower => End is other EPower. Start Diffence Line => End is another EPower
                ConnectableE BusEPower = lineConnected.StartEPower.DatabaseE.ObjectType == ObjectType.MBA2P ? lineConnected.EndEPower : lineConnected.StartEPower;
                ListBusEPowerEnds.Add(BusEPower);
            }

            return ListBusEPowerEnds;
        }

        protected virtual void ProcessRemovedDTOBusRemoved(ConnectableE mba2EPower, DTOBusEPower dtoBusEPower)
        {
            //if LineConnected with LineEPower not removed then remove other dto
            bool isDTOFrom = (dtoBusEPower.ObjectNumber == mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From.ObjectNumber);

            //false <=> Bus from is removed 
            if (!isDTOFrom) mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From = null;
            mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_To = null;
        }
    }
}
