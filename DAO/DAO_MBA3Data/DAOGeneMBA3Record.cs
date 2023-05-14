using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_MBA3Data
{
    public class DAOGeneMBA3Record
    {
        private static DAOGeneMBA3Record _instance;
        public static DAOGeneMBA3Record Instance
        {
            get { if (_instance == null) _instance = new DAOGeneMBA3Record(); return _instance; }
            private set {; }
        }

        private DAOGeneMBA3Record() {; }

        public virtual DTOTransThreeEPower GenerateDTOTransThreeDefault(int ExistOrderBus)
        {
            DTOTransThreeEPower dtoMBA3 = new DTOTransThreeEPower();

            //LineBusConnect Data
            dtoMBA3.DTOBus_From = null;
            dtoMBA3.DTOBus_To = null;
            dtoMBA3.DTOBus_Ter = null;

            int numberObjectType = (int)ObjectType.MBA3P * 100;
            dtoMBA3.ObjectNumber = (ExistOrderBus < 100) ? numberObjectType + 1 : ExistOrderBus + 1;
            dtoMBA3.ObjectName = "";

            dtoMBA3.Index_InService = 1;//All in Service

            //Power Rating
            dtoMBA3.PowerRated_MVA = 100;

            //Transformer Impendance Data
            dtoMBA3.Impendance_MBA3 = new ImpedanceMBA3();

            //Set BaseMVA
            dtoMBA3.Trans3Winding_MVABase = new Transformer3PBaseMVA(100, 100, 100);

            //Set VoltageRating
            dtoMBA3.VoltageEnds_kV_Rated = this.GenerateVoltageEnds(0, 0,0);

            //Unit mode Form MainMBA2
            dtoMBA3.UnitTap_Main = UnitTapMode.Percent;

            //Set Percent Voltage Fixed prim
            dtoMBA3.Percent_PrimFixed = 1;
            //Set Percent Voltage Fixed tertiary
            dtoMBA3.Percent_TerFixed = 1;
            //Set Percent Voltage Fixed Sec
            dtoMBA3.Percent_SecFixed = 1;

            return dtoMBA3;
        }

        protected virtual VoltageEnds3P GenerateVoltageEnds(double Prim, double Ter, double Sec)
        {
            VoltageEnds3P voltageEnds = new VoltageEnds3P();
            voltageEnds.VolPrim_kV = Prim;
            voltageEnds.VolTer_kV = Ter;
            voltageEnds.VolSec_kV = Sec;

            return voltageEnds;
        }

       

    }
}
