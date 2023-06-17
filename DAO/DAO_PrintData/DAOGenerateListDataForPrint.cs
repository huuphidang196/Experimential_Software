using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.DTO;
using Experimential_Software.CustomControl;

namespace Experimential_Software.DAO.DAO_PrintData
{
    [Serializable]
    public struct DataNodeSystem
    {
        public int Bus { get; set; }
        public double Pf { get; set; }
        public double Qfmin { get; set; }
        public double Qfmax { get; set; }
        public double PLoad { get; set; }
        public double QLoad { get; set; }
        public double U { get; set; }
        public double Upu { get; set; }
        public double Angle { get; set; }
    }

    [Serializable]
    public struct DataBranchSystem
    {
        public int BusFrom { get; set; }
        public int BusTo { get; set; }
        public double SpecR { get; set; }
        public double SpecX { get; set; }
        public double MagB { get; set; }
        public double MagG { get; set; }
        public string StrObjType { get; set; }
    }

    public class CompareNumberNode : IComparer<DataNodeSystem>
    {
        public int Compare(DataNodeSystem x, DataNodeSystem y)
        {
            return x.Bus.CompareTo(y.Bus);
        }
    }

    public class CompareNumberBranchFrom : IComparer<DataBranchSystem>
    {
        public int Compare(DataBranchSystem x, DataBranchSystem y)
        {
            return x.BusFrom.CompareTo(y.BusFrom);
        }
    }


    public class DAOGenerateListDataForPrint
    {
        private static DAOGenerateListDataForPrint _instance;
        public static DAOGenerateListDataForPrint Instance
        {
            get { if (_instance == null) _instance = new DAOGenerateListDataForPrint(); return _instance; }
            private set {; }
        }

        private DAOGenerateListDataForPrint() {; }

        #region Get_List_Node_System
        public virtual List<DataNodeSystem> GetListDataNodeSystem(List<ConnectableE> allEPowers)
        {
            List<DataNodeSystem> ListNode = new List<DataNodeSystem>();
            List<ConnectableE> allMF = allEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.MF);
            List<ConnectableE> allLoad = allEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.Load);
            List<ConnectableE> remiderBus = allEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.Bus);

            //Add ListMF
            ListNode.AddRange(this.GetListDataNodeSystemFromMF(allMF));
            //Add ListLoad
            ListNode.AddRange(this.GetListDataNodeSystemFromLoad(allLoad));
            //Add ListBus
            ListNode.AddRange(this.GetListDataNodeSystemFromBus(remiderBus));

            //Sort by NodeNumber
            ListNode.Sort(new CompareNumberNode());

            return ListNode;
        }

        protected virtual List<DataNodeSystem> GetListDataNodeSystemFromMF(List<ConnectableE> allMF)
        {
            List<DataNodeSystem> ListNodeMF = new List<DataNodeSystem>();
            foreach (ConnectableE mf in allMF)
            {
                DTOGeneEPower dtoMF = mf.DatabaseE.DataRecordE.DTOGeneEPower;
                int numberMF = dtoMF.ObjectNumber - 100 * (int)ObjectType.MF;
                double Pf = dtoMF.PowerMachineMF.Pgen_MW;
                double Qfmin = dtoMF.PowerMachineMF.Qmin_Mvar;
                double Qfmax = dtoMF.PowerMachineMF.Qmax_Mvar;
                double U_kv = dtoMF.DTOBusConnected.BasekV;
                double U_pu = dtoMF.DTOBusConnected.Voltage_pu;
                double Angle = dtoMF.DTOBusConnected.Angle_rad;

                DataNodeSystem dtNode = new DataNodeSystem()
                {
                    Bus = numberMF,
                    Pf = Pf,
                    Qfmin = Qfmin,
                    Qfmax = Qfmax,
                    PLoad = 0,
                    QLoad = 0,
                    U = U_kv,
                    Upu = U_pu,
                    Angle = Angle
                };

                ListNodeMF.Add(dtNode);
            }

            return ListNodeMF;
        }

        protected virtual List<DataNodeSystem> GetListDataNodeSystemFromLoad(List<ConnectableE> allLoad)
        {
            List<DataNodeSystem> ListNodeLoad = new List<DataNodeSystem>();
            foreach (ConnectableE load in allLoad)
            {
                DTOLoadEPower dtoLoad = load.DatabaseE.DataRecordE.DTOLoadEPower;
                int numberMF = dtoLoad.ObjectNumber - 100 * (int)ObjectType.Load;
                double PLoad = dtoLoad.PLoad;
                double QLoad = dtoLoad.QLoad;
                double U_kv = dtoLoad.DTOBusConnected.BasekV;
                double U_pu = dtoLoad.DTOBusConnected.Voltage_pu;
                double Angle = dtoLoad.DTOBusConnected.Angle_rad;

                DataNodeSystem dtNode = new DataNodeSystem()
                {
                    Bus = numberMF,
                    Pf = 0,
                    Qfmin = 0,
                    Qfmax = 0,
                    PLoad = PLoad,
                    QLoad = QLoad,
                    U = U_kv,
                    Upu = U_pu,
                    Angle = Angle
                };

                ListNodeLoad.Add(dtNode);
            }

            return ListNodeLoad;
        }
        protected virtual List<DataNodeSystem> GetListDataNodeSystemFromBus(List<ConnectableE> allBus)
        {
            //Get All Bus not Connect With Load Or MF
            List<ConnectableE> allBusNull = allBus.Where(x => this.CheckConnectLoadOrMF(x)).ToList();
            List<DataNodeSystem> ListNodeBusNull = new List<DataNodeSystem>();
            foreach (ConnectableE bus in allBusNull)
            {
                DTOBusEPower dtoBus = bus.DatabaseE.DataRecordE.DTOBusEPower;
                int numberMF = dtoBus.ObjectNumber - 100 * (int)ObjectType.Bus;
                double U_kv = dtoBus.BasekV;
                double U_pu = dtoBus.Voltage_pu;
                double Angle = dtoBus.Angle_rad;

                DataNodeSystem dtNode = new DataNodeSystem()
                {
                    Bus = numberMF,
                    Pf = 0,
                    Qfmin = 0,
                    Qfmax = 0,
                    PLoad = 0,
                    QLoad = 0,
                    U = U_kv,
                    Upu = U_pu,
                    Angle = Angle
                };

                ListNodeBusNull.Add(dtNode);
            }

            return ListNodeBusNull;
        }

        protected virtual bool CheckConnectLoadOrMF(ConnectableE busConsider)
        {
            List<LineConnect> ListLine = busConsider.ListBranch_Drawn;
            if (ListLine.All(x => x.StartEPower.DatabaseE.ObjectType != ObjectType.MF && x.StartEPower.DatabaseE.ObjectType != ObjectType.Load))
                if (ListLine.All(x => x.EndEPower.DatabaseE.ObjectType != ObjectType.MF && x.EndEPower.DatabaseE.ObjectType != ObjectType.Load))
                    return true;
            return false;
        }

        #endregion Get_List_Node_System

        #region Get_List_Branch_System
        public virtual List<DataBranchSystem> GetListDataBranchSystem(List<ConnectableE> allEPowers)
        {
            List<DataBranchSystem> ListBranch = new List<DataBranchSystem>();
            List<ConnectableE> allMBA2P = allEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.MBA2P);
            //<ConnectableE> allMBA3P = allEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.MBA3P);
            List<ConnectableE> allLineE = allEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.LineEPower);

            //Add List MBA2P
            ListBranch.AddRange(this.GetListDataBranchSystemFromMBA2P(allMBA2P));
            //Add List Line
            ListBranch.AddRange(this.GetListDataBranchSystemFromLineEPower(allLineE));
           
            //Sort by NodeNumber
            ListBranch.Sort(new CompareNumberBranchFrom());

            return ListBranch;
        }

        protected virtual List<DataBranchSystem> GetListDataBranchSystemFromMBA2P(List<ConnectableE> allMBA2P)
        {
            List<DataBranchSystem> ListBranchMF = new List<DataBranchSystem>();
            foreach (ConnectableE mba2P in allMBA2P)
            {
                DTOTransTwoEPower dtoMBA2P = mba2P.DatabaseE.DataRecordE.DTOTransTwoEPower;
                int Bus_From = dtoMBA2P.DTOBus_From.ObjectNumber - 100 * (int)ObjectType.Bus;
                int Bus_To = dtoMBA2P.DTOBus_To.ObjectNumber - 100 * (int)ObjectType.Bus;
                double Spec_R = dtoMBA2P.Impendance_MBA2.SpecR_pu;
                double Spec_X = dtoMBA2P.Impendance_MBA2.SpecX_pu;
                double Mag_B = dtoMBA2P.Impendance_MBA2.MagB_pu;
                double Mag_G = dtoMBA2P.Impendance_MBA2.MagG_pu;
                string str_ObjType = ObjectType.MBA2P.ToString();
                
                DataBranchSystem dtBranch = new DataBranchSystem()
                {
                    BusFrom = Bus_From,
                    BusTo = Bus_To,
                    SpecR = Spec_R,
                    SpecX = Spec_X,
                     MagB = Mag_B,
                    MagG = Mag_G,
                    StrObjType =str_ObjType,
                };

                ListBranchMF.Add(dtBranch);
            }

            return ListBranchMF;
        }

        //LIneE
        protected virtual List<DataBranchSystem> GetListDataBranchSystemFromLineEPower(List<ConnectableE> allLineE)
        {
            List<DataBranchSystem> ListBranchMF = new List<DataBranchSystem>();
            foreach (ConnectableE lineE in allLineE)
            {
                DTOLineEPower dtoLineE = lineE.DatabaseE.DataRecordE.DTOLineEPower;
                int Bus_From = dtoLineE.DTOBus_From.ObjectNumber - 100 * (int)ObjectType.Bus;
                int Bus_To = dtoLineE.DTOBus_To.ObjectNumber - 100 * (int)ObjectType.Bus;
                double Spec_R = dtoLineE.ImpedanceLineE.LineR_Pu;
                double Spec_X = dtoLineE.ImpedanceLineE.LineX_Pu;
                double Mag_B = dtoLineE.ImpedanceLineE.LineBFrom_Pu + dtoLineE.ImpedanceLineE.LineBTo_Pu;
                double Mag_G = dtoLineE.ImpedanceLineE.LineGFrom_Pu + dtoLineE.ImpedanceLineE.LineGTo_Pu;
                string str_ObjType = "ĐZ";

                DataBranchSystem dtBranch = new DataBranchSystem()
                {
                    BusFrom = Bus_From,
                    BusTo = Bus_To,
                    SpecR = Spec_R,
                    SpecX = Spec_X,
                    MagB = Mag_B,
                    MagG = Mag_G,
                    StrObjType = str_ObjType,
                };

                ListBranchMF.Add(dtBranch);
            }

            return ListBranchMF;
        }

        #endregion Get_List_Branch_System
    }
}
