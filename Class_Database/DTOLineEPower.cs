using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace Experimential_Software.Class_Database
{
    [Serializable]
    public class ImpendanceLineEPower
    {
        //Branch Data
        //R
        protected double _lineR_pu;
        public double LineR_Pu
        {
            get { return _lineR_pu; }
            set { _lineR_pu = Math.Round(value, 6); }
        }
        //X
        protected double _lineX_pu;
        public double LineX_Pu
        {
            get { return _lineX_pu; }
            set { _lineX_pu = Math.Round(value, 6); }
        }
        //Charging B_pu
        protected double _chargingB_pu;
        public double ChargingB_Pu
        {
            get { return _chargingB_pu; }
            set { _chargingB_pu = Math.Round(value, 6); }
        }
        //GFrom
        protected double _lineGFrom_pu;
        public double LineGFrom_Pu
        {
            get { return _lineGFrom_pu; }
            set { _lineGFrom_pu = Math.Round(value, 6); }
        }
        //BFrom
        protected double _lineBFrom_pu;
        public double LineBFrom_Pu
        {
            get { if (this._chargingB_pu != 0) return this._chargingB_pu / 2; return _lineBFrom_pu; }
            set { _lineBFrom_pu = Math.Round(value, 6); }
        }
        //GTo
        protected double _lineGTo_pu;
        public double LineGTo_Pu
        {
            get { return _lineGTo_pu; }
            set { _lineGTo_pu = Math.Round(value, 6); }
        }
        //BTo
        protected double _lineBTo_pu;
        public double LineBTo_Pu
        {
            get { if (this._chargingB_pu != 0) return this._chargingB_pu / 2; return _lineBTo_pu; }
            set { _lineBTo_pu = Math.Round(value, 6); }
        }

        //Length
        protected double _lengthBr_KM;
        public double LengthBr_KM
        {
            get { return _lengthBr_KM; }
            set { _lengthBr_KM = Math.Round(value, 3); }
        }

         ///*********** Z and Yij***************************
        //Zij
        public Complex ZLine_Resis_LineE_pu
        {
            get { return new Complex(this._lineR_pu, this._lineX_pu) * this._lengthBr_KM; }
        }

        //Yij = 1/Zij
        public Complex Yij_Con_LineE_pu
        {
            get { return 1 / this.ZLine_Resis_LineE_pu; }
        }

        //Ybij = G + jB=> from
        public Complex YblineFrom_Con_LineE_pu
        {
            get { return new Complex(this._lineGFrom_pu, this._lineBFrom_pu); }
        }
        //Ybij = G + jB => To
        public Complex YblineTo_Con_LineE_pu
        {
            get { return new Complex(this._lineGTo_pu, this._lineBTo_pu); }
        }
        ///-----------------------------------------------------------------------------
        public ImpendanceLineEPower()
        {
            this._lineR_pu = 0;
            this._lineX_pu = 0.0001;
            this._chargingB_pu = 0;
            this._lineGFrom_pu = 0;
            this._lineBFrom_pu = 0;
            this._lineGTo_pu = 0;
            this._lineBTo_pu = 0;
            //Length = 1 beacause * Length
            this._lengthBr_KM = 1;
        }
    }
    [Serializable]
    public class DTOLineEPower : DataRecordEPower
    {
        //Basic Data
        //Line Only connect with Bus 
        public DTOBusEPower DTOBus_From { get; set; }
        public DTOBusEPower DTOBus_To { get; set; }

        public bool IsInService { get; set; }

        //Branch Data
       public ImpendanceLineEPower ImpendanceLineE { get; set; }
    }
}
