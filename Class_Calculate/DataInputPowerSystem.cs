using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.Class_Calculate
{
    public class DataInputPowerSystem
    {
        protected List<double> _e_AllMF = new List<double>();
        public List<double> E_AllMF => _e_AllMF;

        protected List<double> _rad_ThetaK_All = new List<double>();
        public List<double> Rad_ThetaK_All => _rad_ThetaK_All;

        protected List<ReactPowerQLimit> _q_GK_Limits = new List<ReactPowerQLimit>();
        public List<ReactPowerQLimit> Q_GK_Limits => _q_GK_Limits;


        public virtual void AddEMF(double E_MF)
        {
            this._e_AllMF.Add(E_MF);
        }

        public virtual void AddRadThetaEMF(double rad_E_MF)
        {
            this._rad_ThetaK_All.Add(rad_E_MF);
        }

        public virtual void AddReactPowerQLimit(double Q_Gk_Min, double Q_Gk_Max)
        {
            ReactPowerQLimit reactP = new ReactPowerQLimit() { Q_Gk_Min = Q_Gk_Min, Q_Gk_Max = Q_Gk_Max }; 
            this._q_GK_Limits.Add(reactP);
        }
    }

    public class ReactPowerQLimit
    {
        public double Q_Gk_Min { get; set; }
        public double Q_Gk_Max { get; set; }
    }
}
