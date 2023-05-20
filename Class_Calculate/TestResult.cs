using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System;

using MathNet.Numerics.LinearAlgebra.Complex;
using MathNet.Symbolics;
using System.Numerics;
using Experimential_Software.Class_Calculate.Calculate_Y;
using Experimential_Software.Class_Calculate.CalculateCurve;
using MathNet.Numerics.Data.Matlab;
using CsQuery.EquationParser.Implementation;
using MathNet.Numerics.RootFinding;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.LinearAlgebra.Complex.Solvers;
using Experimential_Software.Class_Database;

namespace Experimential_Software.Class_Calculate
{
    public class TestResult
    {
        DTODataInputPowerSystem dataInputPower;
        CalPointCurveStepOne pointCurve;
        protected Complex[,] Ybus;
        protected Complex[,] ZBus;

        protected int number_BusJ;

        
        public string ShowYBus()
        {
            int Count_FBus = this.dataInputPower.E_AllMF.Count;
            string s = "";
            for (int i = 0; i < Ybus.GetLength(0); i++)
            {
                if (i <= Count_FBus - 1) s += "Bus " + (i + 1) + new string(' ', 10);
                else s += "Bus " + number_BusJ + new string(' ', 10);

                for (int j = 0; j < Ybus.GetLength(1); j++)
                {
                    s += Ybus[i, j].Real + " + j" + Ybus[i, j].Imaginary + new string(' ', 15);
                }
                s += "\n";
            }

            return s;
        }

        public string ShowZBus(int Count_FBus, int number_BusJ)
        {
            //this.Ybus = CalculateYBus.CalculateYBusIsoval(Count_FBus, number_BusJ);
            //this.ZBus = CalculateYBus.ConvertFormYBusToZBus(this.Ybus);
            string s = "";
            for (int i = 0; i < this.ZBus.GetLength(0); i++)
            {
                for (int j = 0; j < this.ZBus.GetLength(1); j++)
                {
                    s += double.Parse(this.ZBus[i, j].Real.ToString("N6")) + " + j" + double.Parse(this.ZBus[i, j].Imaginary.ToString("N4")) + new string(' ', 15);
                }
                s += "\n";
            }

            var matrix = DenseMatrix.OfArray(this.ZBus);
            // MessageBox.Show(matrix.ToString("F5"));
            s = matrix.ToString("F5");
            return s;
        }

        public string ShowUj()
        {
            string s = "";
            double PLj_Run = 1;
            double QLj = this.pointCurve.GetQLjSuitableForStablePower(PLj_Run);

            return s;
        }

        protected virtual double BruteForceSearch(Func<double, double, double> F_UJ, double a, double b, double P_lj_Run, double eps)
        {
            double x = a;
            double fx = 0;
            while (x <= b)
            {
                fx = F_UJ(x, P_lj_Run);
                if (Math.Abs(fx) <= eps)
                {
                    MessageBox.Show("UJ_Found = " + x);
                    break;
                }
                x += 1e-5; // or any other small step size
            }
            return x;
        }

        protected virtual double Secant(Func<double, double, double> F_UJ, double a, double b, double P_lj_Run, double eps)
        {
            double x1 = b - F_UJ(b, P_lj_Run) * (b - a) / (F_UJ(b, P_lj_Run) - F_UJ(a, P_lj_Run));
            double x2 = x1 - F_UJ(x1, P_lj_Run) * (x1 - b) / (F_UJ(x1, P_lj_Run) - F_UJ(b, P_lj_Run));
            while (Math.Abs(x2 - x1) > eps)
            {
                x1 = x2;
                x2 = x1 - F_UJ(x1, P_lj_Run) * (x1 - b) / (F_UJ(x1, P_lj_Run) - F_UJ(b, P_lj_Run));
            }
            return x2;
        }
      
    }
    public static class Bisection
    {
        public static double FindRoot(Func<double, double, double> F_UJ, double a, double b, double P_lj_Run, double eps)
        {
            if (F_UJ(a, P_lj_Run) * F_UJ(b, P_lj_Run) > 0)
                throw new ArgumentException("The function has the same sign at a and b.");

            double c = 0;
            while (Math.Abs(b - a) > eps)
            {
                c = (a + b) / 2;

                if (Math.Abs(F_UJ(c, P_lj_Run)) <= eps)
                    break;
                else if (F_UJ(a, P_lj_Run) * F_UJ(c, P_lj_Run) < 0)
                    b = c;
                else 
                    a = c;
            }

            return c;
        }
    }
}
