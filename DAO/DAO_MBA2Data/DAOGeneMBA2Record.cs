using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;

namespace Experimential_Software.DAO.DAO_MBA2Data
{
    public class DAOGeneMBA2Record
    {
        private static DAOGeneMBA2Record _instance;
        public static DAOGeneMBA2Record Instance
        {
            get { if (DAOGeneMBA2Record._instance == null) DAOGeneMBA2Record._instance = new DAOGeneMBA2Record(); return _instance; }
            private set {; }
        }

        private DAOGeneMBA2Record() {; }

        public virtual DTOTransTwoEPower GenerateDTOTransTwoDefault(int ExistOrderBus)
        {
            DTOTransTwoEPower dtoMBA2 = new DTOTransTwoEPower();

            //LineBusConnect Data
            dtoMBA2.DTOBus_From = null;
            dtoMBA2.DTOBus_To = null;

            int numberObjectType = (int)ObjectType.MBA2P * 100;
            dtoMBA2.ObjectNumber = (ExistOrderBus < 100) ? numberObjectType + 1 : ExistOrderBus + 1;
            dtoMBA2.ObjectName = "";

            dtoMBA2.IsInService = true;

            //Power Rating
            dtoMBA2.PowerRated_MVA = 100;

            //Transformer Impendance Data
            dtoMBA2.Impendace_MBA2 = new ImpendanceMBA2();

            //Set VoltageRating
            dtoMBA2.VoltageEnds_Rated = this.GenerateVoltageEnds(0, 0);

            dtoMBA2.Prim_RangerTap = this.GenerateEndsRangerTap();
            dtoMBA2.Sec_RangerTap = this.GenerateEndsRangerTap();

            dtoMBA2.NumberTapFixed_Prim = 0;
            dtoMBA2.NumberTapFixed_Sec = 0;

            //Unit mode Form MainMBA2
            dtoMBA2.UnitTap_Main = UnitTapMode.Percent;

            //Set Percent Voltage Fixed prim
            dtoMBA2.Percent_PrimFixed = 1;
            //Set Percent Voltage Fixed Sec
            dtoMBA2.Percent_SecFixed = 1;

            return dtoMBA2;
        }

        protected virtual VoltageEnds2P GenerateVoltageEnds(double Prim, double Sec)
        {
            VoltageEnds2P voltageEnds = new VoltageEnds2P();
            voltageEnds.VolPrim_kV = Prim;
            voltageEnds.VolSec_kV = Sec;

            return voltageEnds;
        }

        protected virtual DTOTransTwoTapRanger GenerateEndsRangerTap()
        {
            DTOTransTwoTapRanger dtoTapRangerEnds = new DTOTransTwoTapRanger();
            // Ignor Tap Zero because it is set = voltage Rated

            //Set Unit Mode Form Tap Ranger
            dtoTapRangerEnds.UnitTap_Ranger = UnitTapMode.Percent;

            //Set default min = -5 %, ,max +5 %. But unit default value is kV => 5% * 0 = 0;
            dtoTapRangerEnds.MinRanger_Per = 0.95;
            dtoTapRangerEnds.MaxRanger_Per = 1.05;

            //Set count tap = 5
            dtoTapRangerEnds.CountTapChanger = 5;

            return dtoTapRangerEnds;
        }

    }
}
