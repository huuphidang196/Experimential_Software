using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.CustomControl;

namespace Experimential_Software.DAO.DAO_Curve.DAO_Calculate
{

    public class DAOGenerateYState
    {
        private static DAOGenerateYState _instance;
        public static DAOGenerateYState Instance
        {
            get { if (_instance == null) _instance = new DAOGenerateYState(); return _instance; }
            private set { }
        }

        private DAOGenerateYState() { }

        public virtual Complex[,] CalculateMatrixYState(List<ConnectableE> allBus)
        {
            //string s = "";
            //foreach (ConnectableE ePower in allBus)
            //{
            //    s += ePower.ToString();
            //}
            //MessageBox.Show(s);

            //Size Ystate
            int lengthYState = allBus.Count;
            //Assignment
            Complex[,] Y_State = new Complex[lengthYState, lengthYState];

            // Calculate conductance matrix
            for (int i = 0; i < lengthYState; i++)
            {
                //get Bus => List 
                ConnectableE bus_Consider = allBus[i];
                //get List Epower Connect with Bus  is Consider
                List<ConnectableE> List_otherEPowers = this.GetListEPowerConnectWithBusConsider(bus_Consider);
                //if Yii => Get All Yij and Yio
                Complex Yii_Bus_consider = this.GetAllYijOtherEPowerConnectBusConsider(List_otherEPowers, bus_Consider);
                //Set Yii
                Y_State[i, i] = Yii_Bus_consider;
                //get List OrtherBus Connect with other EPower
                List<ConnectableE> List_otherBusEPowers = this.GetOrtherBusConnectWithBusConsiderByOrtherEPower(List_otherEPowers, bus_Consider);

                //if Count = 0 then Yij = 0
                if (List_otherBusEPowers.Count == 0) continue;
                // if Have set Yij
                foreach (ConnectableE ortherBus in List_otherBusEPowers)
                {
                    int j = allBus.IndexOf(ortherBus);
                    List<ConnectableE> List_ortherEPowerOfOrtherBus = this.GetListEPowerConnectWithBusConsider(ortherBus);
                    //get all OrtherEPower Overall between 2 List of BusConsider and OrtherBus Connect
                    List<ConnectableE> ListOverallTwoBus = List_ortherEPowerOfOrtherBus.Intersect(List_otherEPowers).ToList();
                    foreach (ConnectableE overallEPower in ListOverallTwoBus)
                    {
                        Y_State[i, j] = -1 * this.GetYijOfEPowerAffectedByRX(overallEPower);
                    }

                }

            }
            return Y_State;
        }
        //Get List Other Epower connect with bus_Consider have ObjType != Bus From List of Bus_Consider
        protected virtual List<ConnectableE> GetListEPowerConnectWithBusConsider(ConnectableE bus_Consider)
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
        protected virtual Complex GetAllYijOtherEPowerConnectBusConsider(List<ConnectableE> List_otherEPower, ConnectableE bus_Consider)
        {
            Complex Sigmoid = 0;
            foreach (ConnectableE otherEPower in List_otherEPower)
            {
                //Yij <= R, X
                Complex y_ij_otherEPower = this.GetYijOfEPowerAffectedByRX(otherEPower);
                //Get Yi0 if other EPower is MBA, Line , maybe MF still is considered
                Complex y_i0_otherEPower = this.GetYioOfEPowerAfftecdByGB(otherEPower, bus_Consider);

                Sigmoid +=  y_ij_otherEPower + y_i0_otherEPower;
            }

            return Sigmoid;
        }

        //Calculate per Yij =< R, X
        protected virtual Complex GetYijOfEPowerAffectedByRX(ConnectableE otherEPower)
        {
            ObjectType objType = otherEPower.DatabaseE.ObjectType;
            switch (objType)
            {
                case ObjectType.MF:
                    return otherEPower.DatabaseE.DataRecordE.DTOGeneEPower.ImpendanceMF.YF_Con_MF_pu;

                case ObjectType.MBA2P:
                    return otherEPower.DatabaseE.DataRecordE.DTOTransTwoEPower.Impendace_MBA2.Yb_Con_MBA2_pu;

                case ObjectType.MBA3P:
                    break;

                case ObjectType.LineEPower:
                    return otherEPower.DatabaseE.DataRecordE.DTOLineEPower.ImpendanceLineE.Yij_Con_LineE_pu;

                case ObjectType.Load:
                    return otherEPower.DatabaseE.DataRecordE.DTOLoadEPower.YLConductanceLoadPU;
            }

            return new Complex(0, 0);
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
                bool isPrim_MBA = this.CheckBusCosiderIsPrimBus(otherEPower, bus_Consider);
                if (!isPrim_MBA) return new Complex(0, 0);// not CA <=> not prim => Yob = 0

                return otherEPower.DatabaseE.DataRecordE.DTOTransTwoEPower.Impendace_MBA2.Y0b_Con_MBA2_pu;
            }

            if (objType == ObjectType.LineEPower)
            {
                //if Prim then bus have Y0b of MBA 
                bool isFrom_Line = this.CheckBusCosiderIsFromBus(otherEPower, bus_Consider);
                if (isFrom_Line) return otherEPower.DatabaseE.DataRecordE.DTOLineEPower.ImpendanceLineE.YblineFrom_Con_LineE_pu;// CA <=> bus from => Ybline = from

                return otherEPower.DatabaseE.DataRecordE.DTOLineEPower.ImpendanceLineE.YblineTo_Con_LineE_pu;// Bus to=> YbiLineTo
            }

            return new Complex(0, 0);
        }

        protected virtual bool CheckBusCosiderIsPrimBus(ConnectableE otherEPower_MBA2, ConnectableE bus_Consider)
        {
            return otherEPower_MBA2.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From.ObjectNumber == bus_Consider.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber;
        }
        protected virtual bool CheckBusCosiderIsFromBus(ConnectableE otherEPower_LineE, ConnectableE bus_Consider)
        {
            return otherEPower_LineE.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_From.ObjectNumber == bus_Consider.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber;
        }

        #endregion Calculate_Per_Yi0_G_B

        #region Get_All_Orther_Bus
        //Get List Other Bus connect with Bus Consider by Other Epower
        protected virtual List<ConnectableE> GetOrtherBusConnectWithBusConsiderByOrtherEPower(List<ConnectableE> List_otherEPowers, ConnectableE bus_Consider)
        {
            List<ConnectableE> List_ortherBusEPowers = new List<ConnectableE>();
            foreach (ConnectableE otherEPower in List_otherEPowers)
            {
                //per Other EPoer have List LineConnect with another Epower
                List<LineConnect> Lines_OtherE = otherEPower.ListBranch_Drawn;
                //if OtherEpower is Load or MF then not add into list
                //Certainly is Line, MBA2, MBA3
                ConnectableE busConnectedOther = this.GetOtherBusConnectWithOtherEPower(Lines_OtherE, bus_Consider, otherEPower);

                if (busConnectedOther == null) continue;
                List_ortherBusEPowers.Add(busConnectedOther);
            }

            return List_ortherBusEPowers;
        }

        protected virtual ConnectableE GetOtherBusConnectWithOtherEPower(List<LineConnect> lines_OrtherE, ConnectableE bus_Consider, ConnectableE otherEPower)
        {
            if (otherEPower.DatabaseE.ObjectType == ObjectType.Load || otherEPower.DatabaseE.ObjectType == ObjectType.MF) return null;

            //input Certainly is Line, MBA2, MBA3
            foreach (LineConnect line_orther in lines_OrtherE)
            {
                //if other Epower is not connected with orther Bus then continue 
                //Load or MF only Connect with 1 bus
                //per Line have 1 bus because other End is Other bus
                if (line_orther.StartEPower != bus_Consider && line_orther.StartEPower != otherEPower) return line_orther.StartEPower;
                if (line_orther.EndEPower != bus_Consider && line_orther.EndEPower != otherEPower) return line_orther.EndEPower;
            }

            return null;
        }
        #endregion Get_All_Orther_Bus
    }
}
