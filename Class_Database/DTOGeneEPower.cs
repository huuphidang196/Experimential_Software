using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.Class_Database
{
    [Serializable]
    public enum WindMFControlMode
    {
        Not_a_Wind_Machine = 0,

        Standard_QT_QB_limits = 1,

        Q_limits_based_on_WPF = 2,

        Fixed_Q_based_on_WPF = 3,
    }

    [Serializable]
    public class PowerMachineDataMF
    {
        //*******Machine Data********
        //Pgen
        private double _pgen_MW;
        public double Pgen_MW
        {
            get { return _pgen_MW; }
            set { _pgen_MW = Math.Round(value, 4); }
        }
        //Pmax
        private double _pmax_MW;
        public double Pmax_MW
        {
            get { return _pmax_MW; }
            set { _pmax_MW = Math.Round(value, 4); }
        }
        //Pmin
        private double _pmin_MW;
        public double Pmin_MW
        {
            get { return _pmin_MW; }
            set { _pmin_MW = Math.Round(value, 4); }
        }
        //Qgen
        private double _qgen_Mvar;
        public double Qgen_Mvar
        {
            get { return _qgen_Mvar; }
            set { _qgen_Mvar = Math.Round(value, 4); }
        }
        //Qmax
        private double _qmax_Mvar;
        public double Qmax_Mvar
        {
            get { return _qmax_Mvar; }
            set { _qmax_Mvar = Math.Round(value, 4); }
        }
        //Qmin
        private double _qmin_Mvar;
        public double Qmin_Mvar
        {
            get { return _qmin_Mvar; }
            set { _qmin_Mvar = Math.Round(value, 4); }
        }

        //Mbase => Scb system
        private double _mBase;
        public double MBase
        {
            get { return _mBase; }
            set { _mBase = Math.Round(value, 2); }
        }

        public PowerMachineDataMF()
        {
            //Set Pgen
            this.Pgen_MW = 0;
            //setPmax
            this.Pmax_MW = 9999;
            //set Pmin
            this.Pmin_MW = -9999;

            //Set Qgen
            this.Qgen_Mvar = 0;
            //set Qmax 
            this.Qmax_Mvar = 9999;
            //set Qmin 
            this.Qmin_Mvar = -9999;
            //set Mbase => CHT
            this.MBase = 100;
        }
    }

    [Serializable]
    public class ImpendanceMF
    {
        //*******Transformer Data => Can have or maybe not **********
        //RTran
        private double _rTran_pu;
        public double RTran_pu
        {
            get { return _rTran_pu; }
            set { _rTran_pu = Math.Round(value, 5); }
        }

        //XTran
        private double _xTran_pu;
        public double XTran_pu
        {
            get { return _xTran_pu; }
            set { _xTran_pu = Math.Round(value, 5); }
        }
        //GenTap
        private double _genTap_pu;
        public double Gentap
        {
            get { return _genTap_pu; }
            set { _genTap_pu = Math.Round(value, 5); }
        }

        //Z_MF
        public Complex Z_Res_MF_pu
        {
            get { return new Complex(this._rTran_pu, this._xTran_pu); }
        }

        //YF = 1 /Z_MF
        public Complex YF_Con_MF_pu
        {
            get { if (this.Z_Res_MF_pu != 0) return 1 / this.Z_Res_MF_pu; return 0; }
        }

        //Constuctor
        public ImpendanceMF()
        {
            this._rTran_pu = 0;
            this._xTran_pu = 0;
            this._genTap_pu = 1;
        }
    }

    [Serializable]
    public class DTOGeneEPower : DataRecordEPower
    {
        //********Basic Data*********
        public DTOBusEPower DTOBusConnected { get; set; }
        //Machine ID is ObjetName

        public bool IsInService { get; set; }
        //------------------------------------------------------------------------

        //*******Machine Data********

        public PowerMachineDataMF PowerMachineMF { get; set; }

        //------------------------------------------------------------------------

        //*******Transformer Data => Can have or maybe not **********

        public ImpendanceMF ImpendanceMF { get; set; }
        //------------------------------------------------------------------------

        //**********Wind Data  => Can have or maybe not***************

        //Control Mode
        public WindMFControlMode WindCtrlMode { get; set; }
        //Power Factor
        protected double _power_Factor;
        public double PowerFactor
        {
            get { return _power_Factor; }
            set { _power_Factor = Math.Round(value, 3); }
        }
        //------------------------------------------------------------------------

        //**********Sched Voltage=> Can have or maybe not***************
        //Sched Voltage
        protected double _schedVoltage;
        public double SchedVoltage
        {
            get { return _schedVoltage; }
            set { _schedVoltage = Math.Round(value, 4); }

        }

        //Remote Bus
        public int Remote_Bus { get; set; }

        //------------------------------------------------------------------------
    }
}
