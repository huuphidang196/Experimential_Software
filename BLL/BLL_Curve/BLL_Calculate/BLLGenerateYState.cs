using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.DAO.DAO_Curve;

namespace Experimential_Software.BLL.BLL_Curve.BLL_Calculate
{

    public class BLLGenerateYState
    {
        private static BLLGenerateYState _instance;
        public static BLLGenerateYState Instance
        {
            get { if (_instance == null) _instance = new BLLGenerateYState(); return _instance; }
            private set { }
        }

        public object MesssageBox { get; private set; }

        private BLLGenerateYState() { }

        public virtual Complex[,] CalculateMatrixYState(List<ConnectableE> allBus)
        {
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
                List<ConnectableE> List_otherEPowers = DAOGetDataOfEPower.Instance.GetListEPowerConnectWithBusConsider(bus_Consider);
                //if Yii => Get All Yij and Yio
                Complex Yii_Bus_consider = DAOGetDataOfEPower.Instance.GetAllYijOtherEPowerConnectBusConsider(List_otherEPowers, bus_Consider);
                //Set Yii
                Y_State[i, i] = Yii_Bus_consider;
                //get List OrtherBus Connect with other EPower
                List<ConnectableE> List_otherBusEPowers = DAOGetDataOfEPower.Instance.GetOrtherBusConnectWithBusConsiderByOrtherEPower(List_otherEPowers, bus_Consider);

                //if Count = 0 then Yij = 0
                if (List_otherBusEPowers.Count == 0) continue;
                // if Have set Yij
                foreach (ConnectableE ortherBus in List_otherBusEPowers)
                {
                    int j = allBus.IndexOf(ortherBus);
                    List<ConnectableE> List_ortherEPowerOfOrtherBus = DAOGetDataOfEPower.Instance.GetListEPowerConnectWithBusConsider(ortherBus);
                    //get all OrtherEPower Overall between 2 List of BusConsider and OrtherBus Connect
                    List<ConnectableE> ListOverallTwoBus = List_ortherEPowerOfOrtherBus.Intersect(List_otherEPowers).ToList();
                    foreach (ConnectableE overallEPower in ListOverallTwoBus)
                    {
                        if (overallEPower.DatabaseE.ObjectType != ObjectType.MBA3P) Y_State[i, j] = -1 * DAOGetDataOfEPower.Instance.GetYijOfEPowerAffectedByRXGetYIJPerBus(overallEPower);
                        else Y_State[i, j] = -1 * DAOGetDataOfEPower.Instance.GetPerConnectYijOfEPowerAffectedByRXSpecifiedForMBA3P(overallEPower, ortherBus, bus_Consider);
                        //bus Consider not orther bus beacause Examine where is BusConsider of overallEPower
                    }

                }

            }
            return Y_State;
        }
       

        #region CheckBusIsPrimOrSec
   
        public virtual bool CheckBusCosiderIsPrimBus(ConnectableE otherEPower_MBA2, ConnectableE bus_Consider)
        {
            return otherEPower_MBA2.DatabaseE.DataRecordE.DTOTransTwoEPower.DTOBus_From.ObjectNumber == bus_Consider.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber;
        }
        public virtual bool CheckBusCosiderIsFromBus(ConnectableE otherEPower_LineE, ConnectableE bus_Consider)
        {
            return otherEPower_LineE.DatabaseE.DataRecordE.DTOLineEPower.DTOBus_From.ObjectNumber == bus_Consider.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber;
        }

        #endregion CheckBusIsPrimOrSec

    }
}
