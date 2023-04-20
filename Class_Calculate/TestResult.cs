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

namespace Experimential_Software.Class_Calculate
{
    public class TestResult
    {
        public string ShowYBus(int Count_FBus, int number_BusJ)
        {
            Complex[,] Ybus = CalculateYBus.CalculateYBusIsoval(Count_FBus, number_BusJ);
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
            Complex[,] Ybus = CalculateYBus.CalculateYBusIsoval(Count_FBus, number_BusJ);
            Complex[,] ZBus = CalculateYBus.ConvertFormYBusToZBus(Ybus);
            string s = "";
            for (int i = 0; i < ZBus.GetLength(0); i++)
            {
                for (int j = 0; j < ZBus.GetLength(1); j++)
                {
                    s += double.Parse(ZBus[i, j].Real.ToString("N6")) + " + j" + double.Parse(ZBus[i, j].Imaginary.ToString("N4")) + new string(' ', 15);
                }
                s += "\n";
            }

                var matrix = DenseMatrix.OfArray(ZBus);
            // MessageBox.Show(matrix.ToString("F5"));
            //     s = matrix.ToString("F5");
            return s;
        }

        public string ShowUj( int number_BusJ)
        {
            DataInputPowerSystem dataInputPower = new DataInputPowerSystem();

            dataInputPower.AddEMF(new Complex(1.05, 0));
            dataInputPower.AddEMF(new Complex(0.9848, -0.0456));
            dataInputPower.AddEMF(new Complex(1.0007, -0.0398));

            CalculatePointCurve pointCurve = new CalculatePointCurve(dataInputPower, 1, number_BusJ);
            string s = "";
            Complex PLj_Run = 0.001;

            Func<Complex, Complex, Complex> F_UJ = (Uj, P_lj_Run) => pointCurve.FuncFAByVoltageULoad(Uj, PLj_Run);

            Complex a = new Complex(-0.1, -0.1);
            Complex b = new Complex(2, 2);
            Complex eps = new Complex(1e-8, 0);

            Complex root = Bisection.FindRoot(F_UJ, a, b, PLj_Run, eps);

            Console.WriteLine($"The root is {root}");

            s = root + "";
            return s;
        }

    }
    public static class Bisection
    {
        public static Complex FindRoot(Func<Complex, Complex, Complex> F_UJ, Complex a, Complex b, Complex P_lj_Run, Complex eps)
        {
            if (F_UJ(a, P_lj_Run).Real * F_UJ(b, P_lj_Run).Real > 0)
                throw new ArgumentException("The function has the same sign at a and b.");

            Complex c = new Complex();
            while (Complex.Abs(b - a) > Complex.Abs(eps))
            {
                c = (a + b) / new Complex(2, 0);

                if (F_UJ(c, P_lj_Run).Real == 0)
                    break;
                else if (F_UJ(a, P_lj_Run).Real * F_UJ(c, P_lj_Run).Real < 0)
                    b = c;
                else
                    a = c;
            }

            return c;
        }
    }
}
