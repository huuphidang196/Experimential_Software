using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.Class_Database
{
    [Serializable]
    public class DTOLineEPower : DataRecordEPower
    {
        //Basic Data
        //Line Only connect with Bus 
        public DTOBusEPower DTOBusFrom { get; set; }
        public DTOBusEPower DTOBusTo { get; set; }

        public bool IsInService { get; set; }

        //Branch Data
        protected double _lineR_pu;
        public double LineR_Pu
        {
            get { return _lineR_pu; }
            set { _lineR_pu = Math.Round(value, 6); }
        }

        protected double _lineX_pu;
        public double LineX_Pu
        {
            get { return _lineX_pu; }
            set { _lineX_pu = Math.Round(value, 6); }
        }

        protected double _lengthBr_KM;
        public double LengthBr_KM
        {
            get { return _lengthBr_KM; }
            set { _lengthBr_KM = Math.Round(value, 3); }
        }
    }
}
