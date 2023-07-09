using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.DAO.DAO_Curve;
using Experimential_Software.DTO;


namespace Experimential_Software.BLL.BLL_Curve.BLL_InteractServer
{
   public class BLLInteractServer
    {
        protected static BLLInteractServer _instance;
        public static BLLInteractServer Instance
        {
            get { if (_instance == null) _instance = new BLLInteractServer(); return _instance; }
            private set { }
        }

        private BLLInteractServer() { }

        public virtual void GetAndSetDataSystemFromServer(List<ConnectableE> allEPowers, string userName, string password)
        {
            foreach (ConnectableE ePower in allEPowers)
            {
                ObjectType objType = ePower.DatabaseE.ObjectType;
                switch (objType)
                {
                    case ObjectType.Bus: this.GetAndSetDataBusPower(ePower);
                        break;
                    case ObjectType.MF: this.GetAndSetDataMF(ePower);
                        break;
                    case ObjectType.MBA2P: this.GetAndSetDataMBA2P(ePower);
                        break;
                    case ObjectType.MBA3P:
                        break;
                    case ObjectType.LineEPower: this.GetAndSetDataLineEPower(ePower);
                        break;
                    case ObjectType.Load: this.GetAndSetDataLoadEPower(ePower);
                        break;
                }
                ePower.UpdateDataRecordEPowerWhenConnectOrRemove(false);
            }
        }

     
        protected virtual void GetAndSetDataBusPower(ConnectableE BusEPower)
        {
            DAODataProviderBus.Instance.ExecuteQuery(BusEPower);
        }

        protected virtual void GetAndSetDataMF(ConnectableE GenePower)
        {
            DAODataProviderMF.Instance.ExecuteQuery(GenePower);
        }

        protected virtual void GetAndSetDataMBA2P(ConnectableE MBA2PPower)
        {
            DAODataProviderMBA2P.Instance.ExecuteQuery(MBA2PPower);
        }

        protected virtual void GetAndSetDataLineEPower(ConnectableE LineEPower)
        {
            DAODataProviderLineEPower.Instance.ExecuteQuery(LineEPower);
        }

        protected virtual void GetAndSetDataLoadEPower(ConnectableE LoadPower)
        {
            DAODataProviderLoad.Instance.ExecuteQuery(LoadPower);
        }

    }
}
