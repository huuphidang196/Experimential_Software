using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        //Mbase => Scb system
        protected double _sBase;
        public double SBase
        {
            get { return _sBase; }
            set { _sBase = Math.Round(value, 2); }
        }

        public Complex SNormal_MVA
        {
            get { return new Complex(this._pLoad, this._qLoad); }
        }

        public Complex YLConductanceLoadPU
        {
            get
            {
                Complex S_Relative = this.SNormal_MVA / this._sBase;
                double Vol_pu = this.DTOBusConnected.Voltage_pu;
                Complex ZLoad = 0;
                if (S_Relative != 0) ZLoad = Math.Pow(Vol_pu, 2) / S_Relative;
                else return ZLoad;

                return 1 / ZLoad;
            }

        }
        public DTOLoadEPower()
        {
            this._pLoad = this._qLoad = 0;
            this._sBase = 100;
        }
    }
}
