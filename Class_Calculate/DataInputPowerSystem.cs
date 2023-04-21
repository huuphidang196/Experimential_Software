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
        public List<double> E_AllMF { get => _e_AllMF; }

        protected List<double> _rad_ThetaK_All = new List<double>();
        public List<double> Rad_ThetaK_All => _rad_ThetaK_All;

        public virtual void AddEMF(double E_MF)
        {
            this._e_AllMF.Add(E_MF);
        }

        public virtual void AddRadThetaEMF(double rad_E_MF)
        {
            this._rad_ThetaK_All.Add(rad_E_MF);
        }
    }
}
