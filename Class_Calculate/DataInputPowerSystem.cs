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
        public List<Complex> _e_AllMF = new List<Complex>();
        public List<Complex> E_AllMF { get => _e_AllMF; set => _e_AllMF = value; }

        public virtual void AddEMF(Complex E_MF)
        {
            this._e_AllMF.Add(E_MF);
        }
    }
}
