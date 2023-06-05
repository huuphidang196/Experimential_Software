using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;
using Experimential_Software.DAO.DAO_Curve.DAO_Calculate;
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
                this.SetNullEndsLineEPower(mba2EPower);
                return;
            }

            //Sort by Obejct Number
            if (ListEPowerEnds.Count > 1) ListEPowerEnds.Sort(new BusEPowerComparer());

            this.SetNullEndsLineEPower(mba2EPower);

            for (int i = 0; i < ListEPowerEnds.Count; i++)
            {
                DTOBusEPower dtoBusEPower = ListEPowerEnds[i].DatabaseE.DataRecordE.DTOBusEPower;
                if (i == 0) mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From = dtoBusEPower;
                else if (i == 1) mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_To = dtoBusEPower;
               
                if (isRemoved) this.ProcessRemovedDTOBusRemoved(mba2EPower, dtoBusEPower);             
            }
        }

        protected virtual void SetNullEndsLineEPower(ConnectableE mba2EPower)
        {
            //Ends null <=> 2 Bus From and to null <=> DTO bus From and To null
            mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From = null;
            mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_To = null;
        }
        protected virtual List<ConnectableE> GetEPowerConnectWithMBA2EPOwer(ConnectableE mba2EPower)
        {
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
            bool isDTOFrom = (dtoBusEPower.ObjectNumber == mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From.ObjectNumber);

            //false <=> Bus from is removed 
            if (!isDTOFrom) mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From = null;
            else mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_To = null;
        }
    }
}
