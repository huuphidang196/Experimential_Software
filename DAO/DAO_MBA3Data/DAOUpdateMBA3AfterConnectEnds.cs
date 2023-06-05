using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;
using Experimential_Software.EPowerProcess;
using MoreLinq;

namespace Experimential_Software.DAO.DAO_MBA3Data
{
    public class DTOBusComparer : IComparer<DTOBusEPower>
    {
        public int Compare(DTOBusEPower dtoBusX, DTOBusEPower dtoBusY)
        {
            return dtoBusX.ObjectNumber.CompareTo(dtoBusY.ObjectNumber);
        }
    }
    public class DAOUpdateMBA3AfterConnectEnds
    {
        private static DAOUpdateMBA3AfterConnectEnds _instance;

        public static DAOUpdateMBA3AfterConnectEnds Instance
        {
            get { if (_instance == null) _instance = new DAOUpdateMBA3AfterConnectEnds(); return _instance; }
            private set { _instance = value; }
        }

        private DAOUpdateMBA3AfterConnectEnds() { }

        public virtual void UpdateMBA3AfterConnectEnds(ConnectableE mba3EPower)
        {
            //Get 2 Bus connected with MBA2P
            List<ConnectableE> ListEPowerEnds = this.GetEPowerConnectWithMBA3EPOwer(mba3EPower);

            if (ListEPowerEnds == null)
            {
                //Ends null <=> 3 Bus From and to, Ter null <=> DTO bus From and To null
               this.SetNUllAllBusConnectWithMBA3P(mba3EPower);
                return;
            }

            //Get List EPower that ListLine Draw of EPower
            List<DTOBusEPower> ListDTOBusExist = ListEPowerEnds.Select(x => x.DatabaseE.DataRecordE.DTOBusEPower).ToList();
      
            //Sort By Object Number
            ListDTOBusExist.Sort(new DTOBusComparer());
            //Set null All in order to set again. not affect beacause List ListDTOBusExist contain address
            this.SetNUllAllBusConnectWithMBA3P(mba3EPower);
            //Process Add DTOBus For MBA3 
            for (int i = 0; i < ListDTOBusExist.Count; i++)
            {
                DTOBusEPower dtoBus = ListDTOBusExist[i];
                switch (i)
                {
                    case 0: mba3EPower.DatabaseE.DataRecordE.DTOTransThreeEPower.DTOBus_From = dtoBus;
                        break;
                    case 1:
                        mba3EPower.DatabaseE.DataRecordE.DTOTransThreeEPower.DTOBus_Ter = dtoBus;
                        break;
                    case 2:
                        mba3EPower.DatabaseE.DataRecordE.DTOTransThreeEPower.DTOBus_To = dtoBus;
                        break;
                } 
                    
            }
           
        }

        protected virtual void SetNUllAllBusConnectWithMBA3P(ConnectableE mba3EPower)
        {
            mba3EPower.DatabaseE.DataRecordE.DTOTransThreeEPower.DTOBus_From = null;
            mba3EPower.DatabaseE.DataRecordE.DTOTransThreeEPower.DTOBus_Ter = null;
            mba3EPower.DatabaseE.DataRecordE.DTOTransThreeEPower.DTOBus_To = null;
        }


        protected virtual void ProcessNullBusOfMBA3IsRemoved(List<DTOBusEPower> ListDTOBusDataBase, List<DTOBusEPower> listDTOBusIsRemoved)
        {
            for (int i = 0; i < ListDTOBusDataBase.Count; i++)
            {
                DTOBusEPower dtoBusConsider = ListDTOBusDataBase[i];
                //diff null => have remove => null
                bool isRemoved = listDTOBusIsRemoved.Find(x => x.ObjectNumber == dtoBusConsider.ObjectNumber) != null;

                if (!isRemoved) continue;
                dtoBusConsider = null;
            }

        }


        protected virtual List<ConnectableE> GetEPowerConnectWithMBA3EPOwer(ConnectableE mba3EPower)
        {
            List<LineConnect> lineConnecteds = mba3EPower.ListBranch_Drawn;

            if (lineConnecteds.Count == 0) return null;

            List<ConnectableE> ListBusEPowerEnds = new List<ConnectableE>();
            foreach (LineConnect lineConnected in lineConnecteds)
            {
                //Start Coincide MBA2EPower => End is other EPower. Start Diffence Line => End is another EPower
                ConnectableE BusEPower = lineConnected.StartEPower.DatabaseE.ObjectType == ObjectType.MBA3P ? lineConnected.EndEPower : lineConnected.StartEPower;
                ListBusEPowerEnds.Add(BusEPower);
            }

            return ListBusEPowerEnds;
        }

        protected virtual void ProcessRemovedDTOBusRemoved(ConnectableE mba3EPower, DTOBusEPower dtoBusEPower)
        {
            //if LineConnected with LineEPower not removed then remove other dto
            bool isDTOPrim = (dtoBusEPower.ObjectNumber == mba3EPower.DatabaseE.DataRecordE.DTOTransThreeEPower.DTOBus_From.ObjectNumber);

            //false <=> Bus from is removed 
            if (!isDTOPrim) mba3EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From = null;
            mba3EPower.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_To = null;
        }
    }
}
