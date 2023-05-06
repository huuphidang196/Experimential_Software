using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_Curve.DAO_Calculate
{
    [Serializable]
    public class PowerSystem
    {
        public double P_ActivePower { get; set; }
        public double Q_ReactivePower { get; set; }

        public PowerSystem(double P_ActivePower, double Q_ReactivePower)
        {
            this.P_ActivePower = P_ActivePower;
            this.Q_ReactivePower = Q_ReactivePower;
        }
    }
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
        public virtual List<PowerSystem> GenerateListPointStabilityLimitCurve(List<ConnectableE> AllEPowers, ConnectableE EPowerBusJLoad, int TotalPoints)
        {
            List<PowerSystem> List_PowerSystem = new List<PowerSystem>();

            //Get List powerSyttem
            for (int i = 0; i < TotalPoints; i++)
            {
                double P_LjRun = 0;
                double QLj_Run = this.CalculateQLjEquivalentPLj(AllEPowers, EPowerBusJLoad);
                PowerSystem powerRun = new PowerSystem(P_LjRun, QLj_Run);
                //Add into List
                List_PowerSystem.Add(powerRun);
            }

            return List_PowerSystem;
        }

        protected double CalculateQLjEquivalentPLj(List<ConnectableE> AllEPowers, ConnectableE EPowerBusJLoad)
        {
            //Get List All Bus from AllEPowers
            List<ConnectableE> _allBus = AllEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.Bus);
            //Sort List All Bus by ObjNumber
            _allBus.Sort(new BusEPowerComparer());

            //Generate AllMF from AllEPowers
            List<ConnectableE> allMF = AllEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.MF);
            //generate DTOData input PowerSystem
            DTODataInputPowerSystem dtoDataInput = new DTODataInputPowerSystem(allMF);

            return 0;
        }
    }
}
