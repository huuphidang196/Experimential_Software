using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_GeneratorData
{
    public class DAOGeneMFRecord
    {
        private static DAOGeneMFRecord _instance;
        public static DAOGeneMFRecord Instance
        {
            get { if (_instance == null) _instance = new DAOGeneMFRecord(); return _instance; }
            private set { }
        }

        private DAOGeneMFRecord() { }

        public virtual DTOGeneEPower GenerateDTOMFEPowerDefault(int ExistOrderBus)
        {
            DTOGeneEPower dtoMF = new DTOGeneEPower();
            //set null for Bus Connect
            dtoMF.DTOBusConnected = null;

            //Set ObjetName => Machine ID
            dtoMF.ObjectName = "";

            return dtoMF;
        }

    }
}
