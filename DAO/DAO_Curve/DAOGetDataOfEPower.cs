using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.BLL.BLL_Curve.BLL_Calculate;
using Experimential_Software.CustomControl;
using Experimential_Software.DTO;

namespace Experimential_Software.DAO.DAO_Curve
{
    public class DAOGetDataOfEPower
    {
        private static DAOGetDataOfEPower _instance;

        public static DAOGetDataOfEPower Instance
        {
            get { if (_instance == null) _instance = new DAOGetDataOfEPower(); return DAOGetDataOfEPower._instance; }
            private set { DAOGetDataOfEPower._instance = value; }
        }
        private DAOGetDataOfEPower() { }

        public virtual ConnectableE GetEPowerPLoadFromEPowerBusLoadConsider(ConnectableE ePowerBusJLoad)
        {
            LineConnect lineConELoad = ePowerBusJLoad.ListBranch_Drawn.Find(x => x.StartEPower.DatabaseE.ObjectType == ObjectType.Load || x.EndEPower.DatabaseE.ObjectType == ObjectType.Load);
            if (lineConELoad == null)
            {
                MessageBox.Show("This Bus is not connected with any Load !\nPlease Select Again!");
                return null;
            }
            ConnectableE ELoad = (lineConELoad.StartEPower.DatabaseE.ObjectType == ObjectType.Load) ? lineConELoad.StartEPower : lineConELoad.EndEPower;

            //Set EPowerLoad for Y'j0 use
            return ELoad;
        }


        //Get List Other Epower connect with bus_Consider have ObjType != Bus From List of Bus_Consider
        public virtual List<ConnectableE> GetListEPowerConnectWithBusConsider(ConnectableE bus_Consider)
        {
            List<ConnectableE> List_otherEPower = new List<ConnectableE>();
            foreach (LineConnect lineConnect in bus_Consider.ListBranch_Drawn)
            {
                ConnectableE other_Epower = (lineConnect.StartEPower.DatabaseE.ObjectType != ObjectType.Bus) ? lineConnect.StartEPower : lineConnect.EndEPower;
                //Add into List
                List_otherEPower.Add(other_Epower);
            }

            return List_otherEPower;
        }

        //get All Yij <= R, X of Bus Consider
        public virtual Complex GetAllYijOtherEPowerConnectBusConsider(List<ConnectableE> List_otherEPower, ConnectableE bus_Consider)
        {
            Complex Sigmoid = 0;
            foreach (ConnectableE ortherEPower in List_otherEPower)
            {
                Complex y_ij_otherEPower = 0;
                //Yij <= R, X
                if (ortherEPower.DatabaseE.ObjectType != ObjectType.MBA3P) y_ij_otherEPower = this.GetYijOfEPowerAffectedByRXGetYIJPerBus(ortherEPower);
                else y_ij_otherEPower = this.GetSumYijOfEPowerAffectedByRXSpecifiedForMBA3P(ortherEPower, bus_Consider);
                //Get Yi0 if other EPower is MBA, Line , maybe MF still is considered
                Complex y_i0_otherEPower = this.GetYioOfEPowerAfftecdByGB(ortherEPower, bus_Consider);
                Sigmoid += y_ij_otherEPower + y_i0_otherEPower;
            }
            return Sigmoid;
        }

        //Calculate per Yij =< R, X
        public virtual Complex GetYijOfEPowerAffectedByRXGetYIJPerBus(ConnectableE otherEPower)
        {
            ObjectType objType = otherEPower.DatabaseE.ObjectType;
            switch (objType)
            {
                case ObjectType.MF:
                    return otherEPower.DatabaseE.DataRecordE.DTOGeneEPower.PowerMachineMF.YF_Con_MF_pu;
                case ObjectType.MBA2P:
                    return otherEPower.DatabaseE.DataRecordE.DTOTransTwoEPower.Impendance_MBA2.Yb_Con_MBA2_pu;
                case ObjectType.LineEPower:
                    return otherEPower.DatabaseE.DataRecordE.DTOLineEPower.ImpedanceLineE.Yij_Con_LineE_pu;
                case ObjectType.Load:
                    return otherEPower.DatabaseE.DataRecordE.DTOLoadEPower.YLConductanceLoadPU;
            }

            return new Complex(0, 0);
        }
        //Calculate per Yij =< R, X Specified for MBA3P
        protected virtual Complex GetSumYijOfEPowerAffectedByRXSpecifiedForMBA3P(ConnectableE otherEPower, ConnectableE bus_Consider)
        {
            DTOBusEPower dtoBusConsider = bus_Consider.DatabaseE.DataRecordE.DTOBusEPower;
            DTOTransThreeEPower dtoMBA3P = otherEPower.DatabaseE.DataRecordE.DTOTransThreeEPower;
            //Check BusConsider is Where ?
            if (dtoMBA3P.DTOBus_From.ObjectNumber == dtoBusConsider.ObjectNumber) return dtoMBA3P.Impedance_MBA3.Yb_Sum_Con_Relative_Prim;//Sum prim
            else if (dtoMBA3P.DTOBus_Ter.ObjectNumber == dtoBusConsider.ObjectNumber) return dtoMBA3P.Impedance_MBA3.Yb_Sum_Con_Relative_Ter;//Sum Ter
            return dtoMBA3P.Impedance_MBA3.Yb_Sum_Con_Relative_Sec;//Sum Sec
        }

        //bus Consider not orther bus beacause Examine where is BusConsider of overallEPower
        public virtual Complex GetPerConnectYijOfEPowerAffectedByRXSpecifiedForMBA3P(ConnectableE overallEPower, ConnectableE orther_Bus, ConnectableE bus_Consider)
        {
            DTOBusEPower dtoBusConsider = bus_Consider.DatabaseE.DataRecordE.DTOBusEPower;
            DTOBusEPower dtoBusOrther = orther_Bus.DatabaseE.DataRecordE.DTOBusEPower;

            DTOTransThreeEPower dtoMBA3P = overallEPower.DatabaseE.DataRecordE.DTOTransThreeEPower;

            Complex Yij_Prim_Ter = dtoMBA3P.Impedance_MBA3.Yij_Con_Relative_Prim_Ter;
            Complex Yij_Prim_Sec = dtoMBA3P.Impedance_MBA3.Yij_Con_Relative_Prim_Sec;
            Complex Yij_Ter_Sec = dtoMBA3P.Impedance_MBA3.Yij_Con_Relative_Ter_Sec;

            //Bus Consider is bus From
            if (dtoBusConsider.ObjectNumber == dtoMBA3P.DTOBus_From.ObjectNumber)
            {
                if (dtoBusOrther.ObjectNumber == dtoMBA3P.DTOBus_Ter.ObjectNumber) return Yij_Prim_Ter;
                return Yij_Prim_Sec;
            }
            // Bus Consder is bus Ter            
            if (dtoBusConsider.ObjectNumber == dtoMBA3P.DTOBus_Ter.ObjectNumber)
            {
                if (dtoBusOrther.ObjectNumber == dtoMBA3P.DTOBus_From.ObjectNumber) return Yij_Prim_Ter;
                return Yij_Ter_Sec;
            }

            // Bus Consder is bus Sec         
            if (dtoBusOrther.ObjectNumber == dtoMBA3P.DTOBus_From.ObjectNumber) return Yij_Prim_Sec;
            return Yij_Ter_Sec;
        }

        #region Calculate_Per_Yi0_G_B
        //Calculate per Yi0 <= G, B
        protected virtual Complex GetYioOfEPowerAfftecdByGB(ConnectableE otherEPower, ConnectableE bus_Consider)
        {
            ObjectType objType = otherEPower.DatabaseE.ObjectType;
            //if Load then return beacuse load don't have Yio. MF is still is Considered
            //MF, Line, MBA2, MBA3
            if (objType == ObjectType.MF || objType == ObjectType.Load) return new Complex(0, 0);

            if (objType == ObjectType.MBA2P)
            {
                //if Prim then bus have Y0b of MBA 
                bool isPrim_MBA = BLLGenerateYState.Instance.CheckBusCosiderIsPrimBus(otherEPower, bus_Consider);
                if (!isPrim_MBA) return new Complex(0, 0);// not CA <=> not prim => Yob = 0

                return otherEPower.DatabaseE.DataRecordE.DTOTransTwoEPower.Impendance_MBA2.Y0b_Con_MBA2_pu;
            }

            if (objType == ObjectType.LineEPower)
            {
                //if Prim then bus have Y0b of MBA 
                bool isFrom_Line = BLLGenerateYState.Instance.CheckBusCosiderIsFromBus(otherEPower, bus_Consider);
                if (isFrom_Line) return otherEPower.DatabaseE.DataRecordE.DTOLineEPower.ImpedanceLineE.YblineFrom_Con_LineE_pu;// CA <=> bus from => Ybline = from

                return otherEPower.DatabaseE.DataRecordE.DTOLineEPower.ImpedanceLineE.YblineTo_Con_LineE_pu;// Bus to=> YbiLineTo
            }

            return new Complex(0, 0);
        }
        #endregion Calculate_Per_Yi0_G_B


        #region Get_All_Orther_Bus
        //Get List Other Bus connect with Bus Consider by Other Epower
        public virtual List<ConnectableE> GetOrtherBusConnectWithBusConsiderByOrtherEPower(List<ConnectableE> List_otherEPowers, ConnectableE bus_Consider)
        {
            List<ConnectableE> List_ortherBusEPowers = new List<ConnectableE>();
            foreach (ConnectableE otherEPower in List_otherEPowers)
            {
                //per Other EPoer have List LineConnect with another Epower
                List<LineConnect> Lines_OtherE = otherEPower.ListBranch_Drawn;
                //if OtherEpower is Load or MF then not add into list
                //Certainly is Line, MBA2, MBA3
                List<ConnectableE> listEOrtherBus = this.GetOtherBusConnectWithOtherEPower(Lines_OtherE, bus_Consider, otherEPower);

                if (listEOrtherBus == null || listEOrtherBus.Count == 0) continue;
                List_ortherBusEPowers.AddRange(listEOrtherBus);
            }

            return List_ortherBusEPowers;
        }

        protected virtual List<ConnectableE> GetOtherBusConnectWithOtherEPower(List<LineConnect> lines_OrtherE, ConnectableE bus_Consider, ConnectableE otherEPower)
        {
            if (otherEPower.DatabaseE.ObjectType == ObjectType.Load || otherEPower.DatabaseE.ObjectType == ObjectType.MF) return null;
            List<ConnectableE> listEOrtherBus = new List<ConnectableE>();
            //input Certainly is Line, MBA2, MBA3
            foreach (LineConnect line_orther in lines_OrtherE)
            {
                //if other Epower is not connected with orther Bus then continue 
                //Load or MF only Connect with 1 bus
                //per Line have 1 bus because other End is Other bus, expcept MBA3P
                if (line_orther.StartEPower != bus_Consider && line_orther.StartEPower != otherEPower) listEOrtherBus.Add(line_orther.StartEPower);
                if (line_orther.EndEPower != bus_Consider && line_orther.EndEPower != otherEPower) listEOrtherBus.Add(line_orther.EndEPower);
            }

            return listEOrtherBus;
        }
        #endregion Get_All_Orther_Bus
    }
}
