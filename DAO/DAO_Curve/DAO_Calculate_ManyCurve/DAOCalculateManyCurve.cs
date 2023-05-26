using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.DAO.DAO_Curve.DAO_Calculate_ManyCurve
{
    public class DAOCalculateManyCurve
    {
        private static DAOCalculateManyCurve _instance;
        public static DAOCalculateManyCurve Instance
        {
            get { if (_instance == null) _instance = new DAOCalculateManyCurve(); return _instance; }
            private set { }
        }

        private DAOCalculateManyCurve() { }

        //Generate new Dictionary save old Power Load
        public virtual Dictionary<string, PowerSystem> GetDictionaryPowerSystemOld(List<ConnectableE> allEPowerOri)
        {
            Dictionary<string, PowerSystem> Dic_PowerSysten_Old = new Dictionary<string, PowerSystem>();

            List<DTOLoadEPower> allDTOLoad = this.GetListDTOAllLoad(allEPowerOri);

            foreach (DTOLoadEPower load in allDTOLoad)
            {
                int numberLoad = load.ObjectNumber;
                string dicName = "Load" + numberLoad;
                // not Reference directly
                Dic_PowerSysten_Old.Add(dicName, new PowerSystem(load.PLoad, load.QLoad));
            }

            return Dic_PowerSysten_Old;
        }    

        protected virtual List<DTOLoadEPower> GetListDTOAllLoad(List<ConnectableE> allEPowerOri)
        {
            List<ConnectableE> allLoad = allEPowerOri.FindAll(x => x.DatabaseE.ObjectType == ObjectType.Load);
            List<DTOLoadEPower> allDTOLoad = allLoad.Select(x => x.DatabaseE.DataRecordE.DTOLoadEPower).ToList();

            return allDTOLoad;
        }

        //Reccify Power all Load
        public virtual List<ConnectableE> RecifyAllPowerSystemLoad(List<ConnectableE> allEPowerOri, Dictionary<string, PowerSystem> Dic_PowerSysten_Old, double rateMin, double rateMax)
        {
            List<DTOLoadEPower> allDTOLoad = this.GetListDTOAllLoad(allEPowerOri);
            Random rd = new Random();
            foreach (DTOLoadEPower load in allDTOLoad)
            {
                int numberLoad = load.ObjectNumber;
                string dicName = "Load" + numberLoad;
                PowerSystem ps = Dic_PowerSysten_Old[dicName];

                //Change Load value
                double P_random = rd.NextDouble() * (ps.P_ActivePower * rateMax - ps.P_ActivePower * rateMin) + ps.P_ActivePower * rateMin;
                double Q_random = rd.NextDouble() * (ps.Q_ReactivePower * rateMax - ps.Q_ReactivePower * rateMin) + ps.Q_ReactivePower * rateMin;

                load.PLoad = P_random;
                load.QLoad = Q_random;
            }

            return allEPowerOri;
        }

        // Save Old Power Load
        public virtual List<ConnectableE> ReturnAllPowerSystemLoadOrigin(List<ConnectableE> allEPowerOri, Dictionary<string, PowerSystem> Dic_PowerSysten_Old)
        {
            List<DTOLoadEPower> allDTOLoad = this.GetListDTOAllLoad(allEPowerOri);
            foreach (DTOLoadEPower load in allDTOLoad)
            {
                int numberLoad = load.ObjectNumber;
                string dicName = "Load" + numberLoad;
                PowerSystem ps = Dic_PowerSysten_Old[dicName];

                //retun old Value
                load.PLoad = ps.P_ActivePower;
                load.QLoad = ps.Q_ReactivePower;
            }

            return allEPowerOri;
        }

       
    }
}
