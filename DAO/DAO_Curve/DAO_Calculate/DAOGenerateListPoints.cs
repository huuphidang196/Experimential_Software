using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_Curve.DAO_Calculate
{

    [Serializable]
    public class BusEPowerComparer : IComparer<ConnectableE>
    {
        public int Compare(ConnectableE x, ConnectableE y)
        {
            return x.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber.CompareTo(y.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber);
        }
    }

    public class DAOGenerateListPoints
    {
        private static DAOGenerateListPoints _instance;
        public static DAOGenerateListPoints Instance
        {
            get { if (_instance == null) _instance = new DAOGenerateListPoints(); return _instance; }
            private set { }
        }
        private DAOGenerateListPoints() { }

        //Get List Point PL, QL. Input are List EPowers and Bus j
        public virtual List<PowerSystem> GenerateListPointStabilityLimitCurve(List<ConnectableE> AllEPowers, ConnectableE EPowerBusJLoad)
        {
            List<PowerSystem> List_PowerSystem = new List<PowerSystem>();

            // int TotalPoints = 200;
            double QLj_Run = 1;
            double P_LjRun = 0;
            double M_Base = DAOCalculateQLJStepOne.Instance.GetEPowerPLoadFromEPowerBusLoadConsider(EPowerBusJLoad).DatabaseE.DataRecordE.DTOLoadEPower.SBase;
            //Stop when Q < 0
            // int i = 0;
            //Get List powerSyttem
            //Send Data Before
            this.SendDataBeforeCalculate(AllEPowers, EPowerBusJLoad);
            while (QLj_Run >= 0)
            {
                QLj_Run = this.CalculateQLjEquivalentPLj(P_LjRun);
                PowerSystem powerRun = new PowerSystem(P_LjRun * M_Base, QLj_Run * M_Base);
                //Add into List
                if (QLj_Run >= 0) List_PowerSystem.Add(powerRun);
                //increase PLj Run
                P_LjRun += 0.1;
                // i++;
            }

            return List_PowerSystem;
        }
        protected virtual void SendDataBeforeCalculate(List<ConnectableE> AllEPowers, ConnectableE EPowerBusJLoad)
        {
            //Get List All Bus from AllEPowers
            List<ConnectableE> allBus = AllEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.Bus);
            //Sort List All Bus by ObjNumber
            allBus.Sort(new BusEPowerComparer());

            //Generate AllMF from AllEPowers
            List<ConnectableE> allMF = AllEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.MF);
            //generate DTOData input PowerSystem
            DTODataInputPowerSystem dtoDataInputPS = new DTODataInputPowerSystem(allMF);

            DAOCalculateQLJStepOne.Instance.SetDatabaseOriginBeforeCalculate(dtoDataInputPS, allBus, EPowerBusJLoad);
        }
        protected double CalculateQLjEquivalentPLj(double P_LjRun)
        {
            double QLj_Run = DAOCalculateQLJStepOne.Instance.GetQLjSuitableForStablePower(P_LjRun);
            return QLj_Run;
        }
    }
}
