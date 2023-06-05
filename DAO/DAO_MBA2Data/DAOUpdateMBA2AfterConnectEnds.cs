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

        public virtual void UpdateMBA2AfterConnectEnds(ConnectableE mba2EPower)
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
                //set From and End
                if (i == 0) mba2EPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_From = dtoBusEPower;
                else if (i == 1) mba2EPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_To = dtoBusEPower;
            }

            //Only use compare not set because set will error
            DTOBusEPower dtoBus_From = mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From;
            DTOBusEPower dtoBus_To = mba2EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_To;

            string str_From = (dtoBus_From != null) ? dtoBus_From.ObjectName : "NULL";
            string str_To = (dtoBus_To != null) ? dtoBus_To.ObjectName : "NULL";

            //Set Line Name
            mba2EPower.DatabaseE.DataRecordE.DTOLineEPower.ObjectName = "Line " + str_From + " - " + str_To;

        }

        protected virtual void SetNullEndsLineEPower(ConnectableE mba2EPower)
        {
            //Ends null <=> 2 Bus From and to null <=> DTO bus From and To null
            mba2EPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_From = null;
            mba2EPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_To = null;
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
    }
}
