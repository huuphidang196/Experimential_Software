using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.Class_Database
{
    [Serializable]
    public class DTOLoadEPower : DataRecordEPower
    {
        //Basic Data
        public DTOBusEPower DTOBusConnected { get; set; }
        //Load ID == ObjName

        public bool IsInService { get; set; }

        //Load Data 
        private double _pLoad;
        public double PLoad
        {
            get { return _pLoad; }
            set { _pLoad = Math.Round(value, 4); }
        }

        private double _qLoad;
        public double QLoad
        {
            get { return _qLoad; }
            set { _qLoad = Math.Round(value, 4); }
        }


    }
}
