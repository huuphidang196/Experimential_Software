using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Calculate.Calculate_Y;

namespace Experimential_Software.Class_Calculate.CalculateCurve
{
    public class CalculatePointCurve
    {
        //protected Complex Sj_Load;

        protected List<Complex> E_AllMF;
        protected List<double> rad_ThetaK_All = new List<double>();
        protected Complex Pj_Ori;
        Complex[,] YBus;
        Complex[,] ZBus;

        public CalculatePointCurve(DataInputPowerSystem dataInputPS, Complex Pj_Ori, int numberLoad)
        {
            this.E_AllMF = dataInputPS.E_AllMF;
            foreach (Complex E_MF in dataInputPS.E_AllMF)
            {
                double rad_AlphaK = Math.Atan2(E_MF.Magnitude, E_MF.Real);
                this.rad_ThetaK_All.Add(rad_AlphaK);
            }
            this.Pj_Ori = Pj_Ori;
            this.YBus = CalculateYBus.CalculateYBusIsoval(this.E_AllMF.Count, numberLoad);
            this.ZBus = CalculateYBus.ConvertFormYBusToZBus(YBus); ;
        }

        public virtual Complex FuncFAByVoltageULoad(Complex Uj, Complex P_Lj_Run)
        {
            Complex Z_j0 = CalculateYBus.GetZIOFromYBus(this.E_AllMF.Count + 1, this.YBus);
            //P(Lj) Run from 0 -> X.   Run 

            //F1a(Uj)
            Complex F_A1_Uj = this.FuncFAOneByVoltageULoad(P_Lj_Run, Z_j0, Uj);

            //Sigmode of FAK(Uj)
            Complex Sigmod_F_AK_Uj = 0;//k = 2-> f (in code is 1 -> f - 1)
            for (int k = 1; k < this.E_AllMF.Count; k++)
            {
                //Calculate FAK(Uj)
                Complex F_AK_Uj = this.FunctFAKByVoltageULoad(k, Uj);
                Sigmod_F_AK_Uj += F_AK_Uj;
            }

            //Calculate 2 * Ar * Uj
            Complex Ar = this.CalculateARStep1(Z_j0);
            Complex F_A_ArUj = 2 * Ar * Uj;

            //Calculate F_A(Uj)
            Complex F_A_Uj = F_A1_Uj + Sigmod_F_AK_Uj - F_A_ArUj;

            return F_A_Uj;
        }

        #region Calculate_FA_1_Uj_Step1
        protected virtual Complex FuncFAOneByVoltageULoad(Complex P_Lj_Run, Complex Z_j0, Complex Uj)
        {
            //Now, YBus is count x count matrix => i = 1, j = count + 1. But run from 0 => i =0, j = count
            Complex Z_1j = this.ZBus[0, this.ZBus.GetLength(0) - 1];

            // Calculate T12 = E1 ^2 / Z1j
            Complex T12 = Complex.Pow(this.E_AllMF[0], 2) / Complex.Pow(Z_1j, 2);

            //(I.2)Calculate Q_1a => Aa, A1, alpha_k, T12, P_Lj_Run, Tk2, Tk1

            //Caculate Aa
            Complex Aa = this.CalculateAaStep1(Z_j0);

            //Caculate A1
            Complex A1 = this.CalculateA1Step1(Uj);

            //Calculate Qa1
            Complex Q_A1 = this.CalculateQAOneStepOne(T12, Aa, A1, Uj, P_Lj_Run);

            //Calculate 3 Element in Sum of F1A(Uj)
            Complex FA_One_Ele_1 = (T12 * Uj) / Q_A1;
            Complex FA_One_Ele_2 = this.GetFAOneElementTwo(Aa, A1, Uj, P_Lj_Run) / Q_A1;
            Complex FA_One_Ele_3 = this.GetFAOneElementThree(Aa, Uj);

            //Calculate F1a
            Complex FA1_Uj = FA_One_Ele_1 - FA_One_Ele_2 * FA_One_Ele_3;

            return FA1_Uj;
        }
        //Aa k = 1 -> F
        protected virtual Complex CalculateAaStep1(Complex Z_j0)
        {
            //(I.2.1) Calculate Aa => alphak, F, Zkj, R -> Ro, X0 -> Expermitally calculate by Yj0. not seperate YL and Yjo'
            Complex Ro = Z_j0.Real;
            Complex Xo = Z_j0.Imaginary;

            Complex R = Ro / (Complex.Pow(Ro, 2) + Complex.Pow(Xo, 2));

            Complex Aa = R;//k= 1-> F <=> 0 -> count - 1
            for (int k = 0; k < E_AllMF.Count; k++)
            {
                Complex Z_kj = ZBus[k, this.ZBus.GetLength(0) - 1];
                double alphaK = this.GetAlphaKJ(k);//rad
                Aa += Math.Sin(alphaK) / Z_kj;
            }

            return Aa;
        }
        //Aa k = 1 -> F

        //A1 k = 2 -> F
        protected virtual Complex CalculateA1Step1(Complex Uj)
        {
            Complex A1 = 0;
            for (int k = 1; k < this.E_AllMF.Count; k++)
            {
                //Caculate Tk1 , k = 2 -> f. Before Pkj_k
                Complex T_K1 = this.CalculateTK1(k, Uj);
                double alpha_k = this.GetAlphaKJ(k);

                A1 += (T_K1 * Math.Cos(2 * alpha_k));
            }

            return A1;
        }
        //A1 k = 2 -> F

        //Get 3 element
        protected virtual Complex GetFAOneElementThree(Complex Aa, Complex Uj)
        {
            Complex SigmodTwo = 0;
            for (int k = 1; k < this.E_AllMF.Count; k++)
            {
                double alpha_K = this.GetAlphaKJ(k);
                Complex T_K2 = this.CalculateTK2(k);
                Complex T_K1 = this.CalculateTK1(k, Uj);

                Complex numerator = Math.Sin(2 * alpha_K) * T_K2 * Uj;
                Complex denominator = Complex.Sqrt(T_K2 * Uj * Uj - Complex.Pow(T_K1, 2));

                SigmodTwo += numerator / denominator;
            }

            Complex FA_Ele_3 = 2 * Aa * Uj - SigmodTwo;

            return FA_Ele_3;
        }

        protected virtual Complex GetFAOneElementTwo(Complex Aa, Complex A1, Complex Uj, Complex P_Lj_Run)
        {
            //Calculate Signmod 
            Complex Sigmod = this.SigmodQAOneFromBrandTwo(Uj);
            Complex FA_Ele_2 = (P_Lj_Run + Aa * Complex.Pow(Uj, 2) - A1 - Sigmod);

            return FA_Ele_2;
        }
        //Get 3 element

        //Q1a
        protected Complex CalculateQAOneStepOne(Complex T12, Complex Aa, Complex A1, Complex Uj, Complex P_Lj_Run)
        {
            //Calculate Signmod 
            Complex Sigmod = this.SigmodQAOneFromBrandTwo(Uj);

            //Calculate Square
            Complex Square_Q1a = Complex.Pow((P_Lj_Run + Aa * Complex.Pow(Uj, 2) - A1 - Sigmod), 2);

            //Calculate Q1a
            Complex Q1A = Complex.Sqrt(T12 * Complex.Pow(Uj, 2) - Square_Q1a);

            return Q1A;
        }
        //Q1a

        //Sigmod of FA1
        protected Complex SigmodQAOneFromBrandTwo(Complex Uj)
        {
            Complex Sigmod = 0;
            for (int k = 1; k < this.E_AllMF.Count; k++)
            {
                Complex T_K2 = this.CalculateTK2(k);
                Complex T_K1 = this.CalculateTK1(k, Uj);
                double alpha_k = this.GetAlphaKJ(k);
                Sigmod += (Math.Sin(2 * alpha_k) * Complex.Sqrt(T_K2 * Complex.Pow(Uj, 2) - Complex.Pow(T_K1, 2)));
            }
            return Sigmod;
        }
        //Sigmod of FA1



        #endregion Calculate_FA_1_Uj_Step1

        #region Calculate_F_AK_Uj_Step1

        protected virtual Complex FunctFAKByVoltageULoad(int k, Complex Uj)
        {
            double alpha_K = this.GetAlphaKJ(k);
            Complex T_K1 = this.CalculateTK1(k, Uj);
            Complex T_K2 = this.CalculateTK2(k);

            //Caculate 3 eleement of sum Q_AK
            Complex Q_AK_Ele1 = T_K2 * Math.Cos(2 * alpha_K) * Complex.Pow(Uj, 2);
            Complex Q_AK_Ele2 = Complex.Pow(T_K1, 2) * Math.Cos(4 * alpha_K);
            Complex Q_AK_Ele3 = T_K1 * Math.Sin(4 * alpha_K) * Complex.Sqrt(T_K2 * Complex.Pow(Uj, 2) - Complex.Pow(T_K1, 2));

            Complex Q_AK = Complex.Sqrt(Q_AK_Ele1 - Q_AK_Ele2 - Q_AK_Ele3);

            //Caculate 2 eleement of sum F_AK_Uj
            Complex F_AK_Ele1 = (T_K2 * Math.Pow(Math.Cos(2 * alpha_K), 2) * Uj) / Q_AK;
            Complex F_AK_Ele2 = (T_K1 * Math.Sin(4 * alpha_K) * T_K2 * Uj) / (2 * Q_AK * Complex.Sqrt(T_K2 * Uj * Uj - T_K1 * T_K1));

            Complex F_AK_Uj = F_AK_Ele1 - F_AK_Ele2;

            return F_AK_Uj;
        }

        #endregion Calculate_F_AK_Uj_Step1

        #region Calculate_Ar_Uj_Step1

        protected virtual Complex CalculateARStep1(Complex Z_j0)
        {
            //(I.2.1) Calculate Ar => X -> Ro, X0 -> Expermitally calculate by Yj0. not seperate YL and Yjo'
            Complex Ro = Z_j0.Real;
            Complex Xo = Z_j0.Imaginary;

            Complex X = Xo / (Complex.Pow(Ro, 2) + Complex.Pow(Xo, 2));

            //k = 1-> f (in code is 0 -> f - 1)
            Complex Ar = X;
            for (int k = 0; k < this.E_AllMF.Count; k++)
            {
                double alpha_K = this.GetAlphaKJ(k);
                Complex Z_kj = this.ZBus[k, this.ZBus.GetLength(0) - 1];
                Ar += (Math.Cos(alpha_K) / Z_kj);
            }

            return Ar;
        }

        #endregion Calculate_Ar_Uj_Step1

        #region Func_Overrall
        //Tk1 k is parameter
        protected virtual Complex CalculateTK1(int k, Complex Uj)
        {
            Complex Z_kj = this.ZBus[k, this.ZBus.GetLength(0) - 1];
            double alphaK = this.GetAlphaKJ(k);
            Complex E_k = this.E_AllMF[k];

            Complex Pkj_k = (Math.Sin(alphaK) * Complex.Pow(E_k, 2)) / Z_kj + (E_k * Uj * Math.Sin(this.rad_ThetaK_All[k] - alphaK)) / Z_kj;

            Complex T_K1 = Pkj_k - (Math.Sin(alphaK) * Complex.Pow(E_k, 2)) / Z_kj;

            return T_K1;
        }
        //Tk1 k is parameter

        //TK2
        protected virtual Complex CalculateTK2(int k)
        {
            Complex Z_kj = this.ZBus[k, this.ZBus.GetLength(0) - 1];
            Complex E_k = this.E_AllMF[k];

            Complex T_K2 = Complex.Pow(E_k, 2) / Complex.Pow(Z_kj, 2);

            return T_K2;
        }
        //Tk2

        //Alpha_KJ
        protected virtual double GetAlphaKJ(int k)
        {
            Complex Z_kj = this.ZBus[k, this.ZBus.GetLength(0) - 1];
            return (Math.PI / 2) - Math.Atan2(Z_kj.Imaginary, Z_kj.Real);
        }
        //Alpha_KJ
        #endregion Func_Overrall
    }
}


















