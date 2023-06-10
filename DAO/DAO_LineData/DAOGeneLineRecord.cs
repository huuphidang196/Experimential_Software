using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_LineData
{
    public class DAOGeneLineRecord
    {
        private static DAOGeneLineRecord _instance;

        public static DAOGeneLineRecord Instance
        {
            get { if (_instance == null) _instance = new DAOGeneLineRecord(); return DAOGeneLineRecord._instance; }
            private set { DAOGeneLineRecord._instance = value; }
        }

        private DAOGeneLineRecord() { }

        public virtual DTOLineEPower GenerateDTOLineEPowerDefault(int ExistOrderBus)
        {
            DTOLineEPower dtoLineEPower = new DTOLineEPower();

            //Basic Data
            dtoLineEPower.DTOBus_From = null;
            dtoLineEPower.DTOBus_To = null;

            int numberObjectType = (int)ObjectType.LineEPower * 100;
            dtoLineEPower.ObjectNumber = (ExistOrderBus < 100) ? numberObjectType + 1 : ExistOrderBus + 1;
            dtoLineEPower.ObjectName = "";

            dtoLineEPower.IsInService = true;

            //Branch Data
            dtoLineEPower.ImpedanceLineE = new ImpedanceLineEPower();

            return dtoLineEPower;
        }
    }
}
