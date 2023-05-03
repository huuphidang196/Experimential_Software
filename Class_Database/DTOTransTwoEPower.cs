using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.Class_Database
{
    [Serializable]
    public struct ImpendanceMBA2
    {
        //R
        private double _specR_pu;
        public double SpecR_pu
        {
            get { return _specR_pu; }
            set { _specR_pu = Math.Round(value, 6); }
        }

        //X
        private double _specX_pu;
        public double SpecX_pu
        {
            get { return _specX_pu; }
            set { _specX_pu = Math.Round(value, 6); }
        }

        //G
        private double _magG_pu;
        public double MagG_pu
        {
            get { return _magG_pu; }
            set { _magG_pu = Math.Round(value, 6); }
        }

        //B
        private double _magB_pu;
        public double MagB_pu
        {
            get { return _magB_pu; }
            set
            {
                _magB_pu = Math.Round(value, 6);
            }
        }
    }

    [Serializable]
    public struct VoltageEnds
    {
        //Prim    
        private double _volPrim_kV;
        public double VolPrim_kV
        {
            get { return _volPrim_kV; }
            set { _volPrim_kV = Math.Round(value, 3); }
        }

        //Sec
        private double _volSec_kV;
        public double VolSec_kV
        {
            get { return _volSec_kV; }
            set { _volSec_kV = Math.Round(value, 3); }
        }
    }

    [Serializable]
    public enum UnitTapMode
    {
        Percent = 0,

        KV_Number = 1,
    }
    [Serializable]
    public class DTOTransTwoTapRanger
    {
        //Voltage tap 0 => Volatge rating of . Set Before Open Form Tap Ranger
        public double Voltage_TapZero_ByRated { get; set; }

        //Unit Mode of Changer Form TapRanger => Form Sub
        public UnitTapMode UnitTap_Ranger { get; set; }

        // Min ranger 
        protected double _minRanger_Per;
        public double MinRanger_Per
        {
            get { return _minRanger_Per; }
            set { _minRanger_Per = Math.Round(value, 5); }
        }

        // Max ranger 
        protected double _maxRanger_Per;
        public double MaxRanger_Per
        {
            get { return _maxRanger_Per; }
            set { _maxRanger_Per = Math.Round(value, 5); }
        }

        //Count Tap Changer
        public int CountTapChanger { get; set; }

        //Step not Round, only Display 
        protected double _step_Per;
        public double Step_Per
        {
            get { return (this._maxRanger_Per - this._minRanger_Per) / (this.CountTapChanger - 1); }
        }

        public virtual DTOTransTwoTapRanger CloneTransTwoTapRanger()
        {
            DTOTransTwoTapRanger dTOTransTwoTapRanger = new DTOTransTwoTapRanger()
            {
                Voltage_TapZero_ByRated = this.Voltage_TapZero_ByRated,

                UnitTap_Ranger = this.UnitTap_Ranger,

                _minRanger_Per = this._minRanger_Per,
                _maxRanger_Per = this._maxRanger_Per,
                CountTapChanger = this.CountTapChanger
            };

            return dTOTransTwoTapRanger;
        }
    }

    [Serializable]
    public class DTOTransTwoEPower : DataRecordEPower
    {
        //Line Data MBA2
        public DTOBusEPower DTOBus_From { get; set; }
        public DTOBusEPower DTOBus_To { get; set; }

        public bool IsInService { get; set; }

        //Power Rating
        protected double _powerRated_MVA
        {
            get { return _powerRated_MVA; }
            set { _powerRated_MVA = Math.Round(value, 3); }
        }

        public double PowerRated_MVA { get; set; }

        //Transfomer Impendance Data
        public ImpendanceMBA2 Impendace_MBA2 { get; set; }

        //Voltage Rating MBA . U Ends
        public VoltageEnds VoltageEnds_Rated { get; set; }

        //When press btnPrim => setting count Tap and percent
        protected DTOTransTwoTapRanger _prim_RangerTap;
        public DTOTransTwoTapRanger Prim_RangerTap
        {
            get { _prim_RangerTap.Voltage_TapZero_ByRated = this.VoltageEnds_Rated.VolPrim_kV; return _prim_RangerTap; }//tap Zero = rated Volatge busPrim
            set { _prim_RangerTap = value; }
        }

        protected DTOTransTwoTapRanger _sec_RangerTap;
        public DTOTransTwoTapRanger Sec_RangerTap
        {
            get { _sec_RangerTap.Voltage_TapZero_ByRated = this.VoltageEnds_Rated.VolSec_kV; return _sec_RangerTap; }//tap Zero = rated Volatge busSec
            set { _sec_RangerTap = value; }
        }

        //Unit Mode of Changer Form Main
        public UnitTapMode UnitTap_Main { get; set; }

        //percent Voltage Fixed compare to Rated
        public double Percent_PrimFixed { get; set; }
        public double Percent_SecFixed { get; set; }

        protected double _numberTapFixed_Prim;
        public double NumberTapFixed_Prim
        {
            get { return _numberTapFixed_Prim; }
            set { _numberTapFixed_Prim = Math.Round(value, 0); }
        }

        protected double _numberTapFixed_Sec;
        public double NumberTapFixed_Sec
        {
            get { return _numberTapFixed_Sec; }
            set { _numberTapFixed_Sec = Math.Round(value, 0); }
        }

        //Fixed Voltage After Adjust Tap Changer
        protected VoltageEnds _voltageEnds_Fixed;
        public VoltageEnds VoltageEnds_Fixed
        {
            get
            {
                _voltageEnds_Fixed.VolPrim_kV = this.Percent_PrimFixed * this.VoltageEnds_Rated.VolPrim_kV;
                _voltageEnds_Fixed.VolSec_kV = this.Percent_SecFixed * this.VoltageEnds_Rated.VolSec_kV;
                return _voltageEnds_Fixed;
            }
        }

    }
}
