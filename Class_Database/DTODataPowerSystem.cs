using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.CustomControl;

namespace Experimential_Software.Class_Database
{
    [Serializable]
    public class DTODataPowerSystem
    {
        protected double _powerBase_S_MVA;
        public double PowreBase_S_MVA
        {
            get { return _powerBase_S_MVA; }
            set { _powerBase_S_MVA = Math.Round(value, 2); }
        }

        protected double _frequency_System_Hz;
        public double Frequency_System_Hz
        {
            get { return _frequency_System_Hz; }
            set { _frequency_System_Hz = Math.Round(value, 2); }
        }

        public List<DatabaseEPower> Database_EPowersSave { get; set; }
        public List<DatabaseLineConnect> Database_LinesConnected { get; set; }

        public DTODataPowerSystem()
        {
            this.PowreBase_S_MVA = 100;
            this.Frequency_System_Hz = 50;
        }
    }
}
