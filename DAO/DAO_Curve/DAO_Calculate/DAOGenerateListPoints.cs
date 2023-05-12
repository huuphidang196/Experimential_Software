using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

    [Serializable]
    public class MFEPowerComparer : IComparer<ConnectableE>
    {
        public int Compare(ConnectableE x, ConnectableE y)
        {
            return x.DatabaseE.DataRecordE.DTOGeneEPower.ObjectNumber.CompareTo(y.DatabaseE.DataRecordE.DTOGeneEPower.ObjectNumber);
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

        protected double _deltaP = 0.01;

        //Get List Point PL, QL. Input are List EPowers and Bus j
        public virtual List<PowerSystem> GenerateListPointStabilityLimitCurve(List<ConnectableE> AllEPowers, ConnectableE EPowerBusJLoad)
        {
            List<PowerSystem> List_PowerSystem = new List<PowerSystem>();

            // Set deltaP = 0 when Get List beacause SingleTon
            this._deltaP = 0.01;
            double QLj_Run = 0;
            double P_LjRun = 0;
            //Pmax <=> Q_Lj = 0;

            //EPower Load consider
            ConnectableE ELoad = DAOCalculateQLJStepOne.Instance.GetEPowerPLoadFromEPowerBusLoadConsider(EPowerBusJLoad);
            if (ELoad == null) return List_PowerSystem;

            double S_Base = ELoad.DatabaseE.DataRecordE.DTOLoadEPower.SBase;

            //Stop when Q < 0

            //Get List powerSyttem
            //Send Data Before
            this.SendDataBeforeCalculate(AllEPowers, EPowerBusJLoad);
            while (QLj_Run >= 0)
            {
                QLj_Run = this.CalculateQLjEquivalentPLj(P_LjRun);
                PowerSystem powerRun = new PowerSystem(P_LjRun * S_Base, QLj_Run * S_Base);

                //Add into List
                if (QLj_Run >= 0) List_PowerSystem.Add(powerRun);

                bool isQNegative = (QLj_Run == double.NaN);
                //increase PLj Run
                P_LjRun = this.ProcessIncreasePLJRun(P_LjRun, isQNegative);
                //Process Again Q if Q < 0
                if (QLj_Run < 0) QLj_Run = 0;

            }

            return List_PowerSystem;
        }

        protected virtual double ProcessIncreasePLJRun(double P_LjRun_Cur, bool isQNegative)
        {
            //Q_Lj_Run < 0
            if (isQNegative && this._deltaP > 1e-3)
            {
                //Q <0  then P retun previous value 
                P_LjRun_Cur -= this._deltaP;
                this._deltaP /= 10;
               // MessageBox.Show("delta = " + this._deltaP + ". P = " + (P_LjRun_Cur + this._deltaP));
            }
            double P_LjRun_Cal = P_LjRun_Cur + this._deltaP;

            return P_LjRun_Cal;
        }

        #region Send_Data_For_StepOne
        //Overall Form Isoval use
        public virtual void SendDataBeforeCalculate(List<ConnectableE> AllEPowers, ConnectableE EPowerBusJLoad)
        {
            //Get List All Bus from AllEPowers
            List<ConnectableE> allBus = this.GetAllBus(AllEPowers);

            //Generate AllMF from AllEPowers
            List<ConnectableE> allMF = this.GetAllMF(AllEPowers);

            //generate DTOData input PowerSystem
            DTODataInputPowerSystem dtoDataInputPS = new DTODataInputPowerSystem(allMF);

            DAOCalculateQLJStepOne.Instance.SetDatabaseOriginBeforeCalculate(dtoDataInputPS, allBus, EPowerBusJLoad);
        }
        //Overall Form Isoval use
        public virtual List<ConnectableE> GetAllBus(List<ConnectableE> AllEPowers)
        {
            //Get List All Bus from AllEPowers
            List<ConnectableE> allBus = AllEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.Bus);
            //Sort List All Bus by ObjNumber
            allBus.Sort(new BusEPowerComparer());

            return allBus;
        }

        //Overall Form Isoval use
        public virtual List<ConnectableE> GetAllMF(List<ConnectableE> AllEPowers)
        {           //Generate AllMF from AllEPowers
            List<ConnectableE> allMF = AllEPowers.FindAll(x => x.DatabaseE.ObjectType == ObjectType.MF);
            allMF.Sort(new MFEPowerComparer());

            return allMF;
        }

        #endregion Send_Data_For_StepOne

        protected double CalculateQLjEquivalentPLj(double P_LjRun)
        {
            double QLj_Run = DAOCalculateQLJStepOne.Instance.GetQLjSuitableForStablePower(P_LjRun);
            return QLj_Run;
        }
    }
}
