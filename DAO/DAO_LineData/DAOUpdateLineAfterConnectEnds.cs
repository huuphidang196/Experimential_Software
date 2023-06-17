using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Experimential_Software.DTO;
using Experimential_Software.CustomControl;
using Experimential_Software.BLL.BLL_Curve.BLL_Calculate;

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

        public virtual void UpdateLineAfterConnectEnds(ConnectableE lineEPower, bool isRemoved)
        {
            //Line isnot Connected with Line
            List<ConnectableE> ListEPowerEnds = this.GetEPowerConnectWithLineEPOwer(lineEPower);

            if (ListEPowerEnds == null)
            {
                this.SetNullEndsLineEPower(lineEPower);
                return;
            }

            //Sort by Obejct Number
            if (ListEPowerEnds.Count > 1) ListEPowerEnds.Sort(new BusEPowerComparer());

            this.SetNullEndsLineEPower(lineEPower);

            for (int i = 0; i < ListEPowerEnds.Count; i++)
            {
                DTOBusEPower dtoBusEPower = ListEPowerEnds[i].DatabaseE.DataRecordE.DTOBusEPower;
                if (i == 0) lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_From = dtoBusEPower;
                else if (i == 1) lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_To = dtoBusEPower;

                if (isRemoved) this.ProcessRemovedDTOBusRemoved(lineEPower, dtoBusEPower);
              
            }

            //not use set value beacause error 
            DTOBusEPower dtoBus_From = lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_From;
            DTOBusEPower dtoBus_To = lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_To;

            string str_From = (dtoBus_From != null) ? dtoBus_From.ObjectName : "NULL";
            string str_To = (dtoBus_To != null) ? dtoBus_To.ObjectName : "NULL";

            //Set Line Name
            lineEPower.DatabaseE.DataRecordE.DTOLineEPower.ObjectName = "Line " + str_From + " - " + str_To;
        }

        protected virtual void SetNullEndsLineEPower(ConnectableE lineEPower)
        {
            //Ends null <=> 2 Bus From and to null <=> DTO bus From and To null
            lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_From = null;
            lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_To = null;
        } 
        protected virtual List<ConnectableE> GetEPowerConnectWithLineEPOwer(ConnectableE lineEPower)
        {
            List<LineConnect> lineConnecteds = lineEPower.ListBranch_Drawn;

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


        protected virtual void ProcessRemovedDTOBusRemoved(ConnectableE lineEPower, DTOBusEPower dtoBusEPower)
        {
            //if LineConnected with LineEPower not removed then remove other dto
            bool isDTOFrom = (dtoBusEPower.ObjectNumber == lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_From.ObjectNumber);

            //false <=> Bus from is removed 
            if (!isDTOFrom) lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_From = null;
            else lineEPower.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_To = null;
        }

    }
}
