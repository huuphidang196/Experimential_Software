using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.DTO
{
    [Serializable]
    public enum TypeCodeBus
    {
        Non_Gen_Bus = 0,
        GeneratorBus = 1,
        SwingBus = 2,
    }

    [Serializable]
    public class DTOBusEPower : DataRecordEPower
    {
        //Basic Data
        public TypeCodeBus TypeCodeBus { get; set; }

        protected double _basekV;//Ucb
        public double BasekV
        {
            get { return _basekV; }
            set { _basekV = Math.Round(value, 1); }
        }

        //protected double _kChangerTap;
        //public double KChangerTap
        //{
        //    get { if (_kChangerTap == 0) return 1; return _kChangerTap; }
        //    set { _kChangerTap = Math.Round(value, 4); }
        //}
        protected double _voltage_pu;
        public double Voltage_pu
        {
            get { return _voltage_pu; }// * KChangerTap; }
            set { _voltage_pu = Math.Round(value, 4); }
        }

        //normal bus 
        protected double _U_normalkV;
        public double U_NormalkV
        {
            get { return this._voltage_pu * this._basekV; } //U_nor = Ubase * Upu
        }

        protected double _angle_rad;
        public double Angle_rad
        {
            get { return _angle_rad; }
            set { _angle_rad = Math.Round(value, 4); }
        }

        //LimitData
        protected double _normal_Vmax_pu;
        public double Normal_Vmax_pu
        {
            get { return _normal_Vmax_pu; }
            set { _normal_Vmax_pu = Math.Round(value, 2); }
        }

        protected double _normal_Vmin_pu;
        public double Normal_Vmin_pu
        {
            get { return _normal_Vmin_pu; }
            set { _normal_Vmin_pu = Math.Round(value, 2); }
        }

        protected double _emer_Vmax_pu;
        public double Emer_Vmax_pu
        {
            get { return _emer_Vmax_pu; }
            set { _emer_Vmax_pu = Math.Round(value, 2); }
        }

        protected double _emer_Vmin_pu;
        public double Emer_Vmin_pu
        {
            get { return _emer_Vmin_pu; }
            set { _emer_Vmin_pu = Math.Round(value, 2); }
        }
    }
}
