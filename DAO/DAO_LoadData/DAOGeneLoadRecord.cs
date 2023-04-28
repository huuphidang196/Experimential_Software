using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_LoadData
{
    public class DAOGeneLoadRecord
    {
        private static DAOGeneLoadRecord _instance;
        public static DAOGeneLoadRecord Instance
        {
            get { if (DAOGeneLoadRecord._instance == null) DAOGeneLoadRecord._instance = new DAOGeneLoadRecord(); return _instance; }
            private set {; }
        }

        private DAOGeneLoadRecord() {; }

        public virtual DTOLoadEPower GenerateDTOLoadDefault(int ExistOrderBus)
        {
            DTOLoadEPower dtoLoadEPower = new DTOLoadEPower();

            //Basic Data
            dtoLoadEPower.ObjectName = "L" + ((ExistOrderBus + 1) % 500);
            int numberObjectType = (int)ObjectType.Load * 100;
            dtoLoadEPower.ObjectNumber = (ExistOrderBus < 100) ? ((ExistOrderBus + 1) * numberObjectType + 1) : ExistOrderBus + 1;

            dtoLoadEPower.IsInService = true;

            dtoLoadEPower.PLoad = 0;
            dtoLoadEPower.QLoad = 0;

            return dtoLoadEPower;
        }
    }
}
