using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DTOGeneEPower : DataRecordEPower
    {
        //********Basic Data*********
        public DTOBusEPower DTOBusConnected { get; set; }
        //Machine ID is ObjetName

        public bool IsInService { get; set; }
        //*******Machine Data********
        //Pgen
        protected double _pgen_MW;
        public double Pgen_MW
        {
            get { return _pgen_MW;}
            set { _pgen_MW = Math.Round(value, 4); }
        }
        //Pmax
        protected double _pmax_MW;
        public double Pmax_MW
        {
            get { return _pmax_MW; }
            set { _pmax_MW = Math.Round(value, 4); }
        }
        //Pmin
        protected double _pmin_MW;
        public double Pmin_MW
        {
            get { return _pmin_MW; }
            set { _pmin_MW = Math.Round(value, 4); }
        }
        //Qgen
        protected double _qgen_MW;
        public double Qgen_MW
        {
            get { return _qgen_MW; }
            set { _qgen_MW = Math.Round(value, 4); }
        }
        //Qmax
        protected double _qmax_MW;
        public double Qmax_MW
        {
            get { return _qmax_MW; }
            set { _qmax_MW = Math.Round(value, 4); }
        }
        //Qmin
        protected double _qmin_MW;
        public double Qmin_MW
        {
            get { return _qmin_MW; }
            set { _qmin_MW = Math.Round(value, 4); }
        }

        //Mbase => Công suất đinh mức Rated Power
        protected double _mBase;
        public double MBase
        {
            get { return _mBase; }
            set { _mBase = Math.Round(value, 2); }
        }

        //*******Transformer Data => Can have or maybe not **********
        //RTran
        protected double _rTran_pu;
        public double RTran_pu
        {
            get { return _rTran_pu; }
            set { _rTran_pu = Math.Round(value, 5); }
        }

        //XTran
        protected double _xTran_pu;
        public double XTran_pu
        {
            get { return _xTran_pu; }
            set { _xTran_pu = Math.Round(value, 5); }
        }
        //GenTap
        protected double _genTap_pu;
        public double Gentap
        {
            get { return _genTap_pu; }
            set { _genTap_pu = Math.Round(value, 5); }
        }

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

    }
}
