using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.DTO;

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
            dtoMBA3.Impedance_MBA3 = new ImpedanceMBA3();

            //Set BaseMVA
            dtoMBA3.Trans3Winding_MVABase = new Transformer3PBaseMVA(100, 100, 100);

            //Set VoltageRating
            dtoMBA3.VoltageEnds_kV_Rated = this.GenerateVoltageEndsByNumber(0, 0, 0);

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

        public virtual VoltageEnds3P GenerateVoltageEndsByText(string txtPrim, string txtTer, string txtSec)
        {
            VoltageEnds3P voltageEnds = new VoltageEnds3P();
            voltageEnds.VolPrim_kV = double.Parse(txtPrim);
            voltageEnds.VolTer_kV = double.Parse(txtTer);
            voltageEnds.VolSec_kV = double.Parse(txtSec);

            return voltageEnds;
        }

        public virtual VoltageEnds3P GenerateVoltageEndsByNumber(double Prim, double Ter, double Sec)
        {
            VoltageEnds3P voltageEnds = new VoltageEnds3P();
            voltageEnds.VolPrim_kV = Prim;
            voltageEnds.VolTer_kV = Ter;
            voltageEnds.VolSec_kV = Sec;

            return voltageEnds;
        }

        public virtual VoltageEnds3P GenerateVoltageEndsFixedByUnitMode(double PerPrim, double PerTer, double PerSec, VoltageEnds3P volRated)
        {
            //Percent
            double Vol_Prim = (1 + PerPrim / 100) * volRated.VolPrim_kV;
            double Vol_Ter = (1 + PerTer / 100) * volRated.VolTer_kV;
            double Vol_Sec = (1 + PerSec / 100) * volRated.VolSec_kV;

            VoltageEnds3P voltageEnds = new VoltageEnds3P() { VolPrim_kV = Vol_Prim, VolTer_kV = Vol_Ter, VolSec_kV = Vol_Sec };

            return voltageEnds;
        }

        public virtual SpecImpedanceMBA3RX GenerateSpecRX(double SpecR, double SpecX)
        {
            SpecImpedanceMBA3RX Spec_Impe = new SpecImpedanceMBA3RX();

            Spec_Impe.SpecR_pu = SpecR;
            Spec_Impe.SpecX_pu = SpecX;

            return Spec_Impe;
        }

        public virtual double GetPercentVoltageFixedDisplayOneHundredPercent(string txtVoltage_Fixed, string txtVoltage_Rated, UnitTapMode unitMode)
        {
            double Vol_Fixed = double.Parse(txtVoltage_Fixed);
            double Vol_Rated = double.Parse(txtVoltage_Rated);

            if (unitMode == UnitTapMode.Percent) return Vol_Fixed;//Mode Percent

            if (Vol_Rated == 0) return 0;// no have data

            double per100 = 100 * (Vol_Fixed / Vol_Rated - 1);

            return per100;
        }
    }
}
