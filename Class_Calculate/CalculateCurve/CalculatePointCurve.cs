using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Calculate.Calculate_Y;
using System.Windows.Forms;

namespace Experimential_Software.Class_Calculate.CalculateCurve
{
    public class CalculatePointCurve
    {
        //protected Complex Sj_Load;

        protected List<double> _e_AllMF;
        protected List<double> _rad_ThetaK_All;
        protected double Pj_Ori;
        protected Complex[,] YBus;
        public Complex[,] YBusIsoval => YBus;

        protected Complex[,] ZBus;
        public Complex[,] ZBusIsoval => ZBus;

        Complex Z_j0_Complex = 1;

        public CalculatePointCurve(DataInputPowerSystem dataInputPS, double Pj_Ori, int numberLoad)
        {
            this._e_AllMF = dataInputPS.E_AllMF;
            this._rad_ThetaK_All = dataInputPS.Rad_ThetaK_All;
            this.Pj_Ori = Pj_Ori;
            this.YBus = CalculateYBus.CalculateYBusIsoval(this._e_AllMF.Count, numberLoad);
            this.ZBus = CalculateYBus.ConvertFormYBusToZBus(YBus);
            this.Z_j0_Complex = CalculateYBus.GetZIOFromYBus(dataInputPS.E_AllMF.Count + 1, this.YBus);
        }

        public virtual double FuncFAByVoltageULoad(double Uj, double P_Lj_Run)
        {
            //F1a(Uj)
            double F_A1_Uj = this.FuncFAOneByVoltageULoad(Uj, P_Lj_Run);

            //Sigmode of FAK(Uj)
            double Sigmod_F_AK_Uj = 0;//k = 2-> f (in code is 1 -> f - 1)
            for (int k = 1; k < this._e_AllMF.Count; k++)
            {
                //Calculate FAK(Uj)
                double F_AK_Uj = this.FunctFAKByVoltageULoad(k, Uj);
                Sigmod_F_AK_Uj += F_AK_Uj;
            }

            //Calculate 2 * Ar * Uj
            double Ar = this.CalculateARStep1();
            double F_A_ArUj = 2 * Ar * Uj;

            //Calculate F_A(Uj)
            double F_A_Uj = F_A1_Uj + Sigmod_F_AK_Uj - F_A_ArUj;

            return F_A_Uj;
        }

        #region Calculate_FA_1_Uj_Step1
        protected virtual double FuncFAOneByVoltageULoad(double Uj, double P_Lj_Run)
        {
            //Now, YBus is count x count matrix => i = 1, j = count + 1. But run from 0 => i =0, j = count
            double Z_1j = this.GetAbsZKJ(0);

            // Calculate T12 = E1 ^2 / Z1j
            double T12 = Math.Pow(this._e_AllMF[0], 2) / Math.Pow(Z_1j, 2);

            //(I.2)Calculate Q_1a => Aa, A1, alpha_k, T12, P_Lj_Run, Tk2, Tk1

            //Caculate Aa
            double Aa = this.CalculateAaStep1();

            //Caculate A1
            double A1 = this.CalculateA1Step1(Uj);

            //Calculate Qa1
            double Q_A1 = this.CalculateQAOneStepOne(T12, Aa, A1, Uj, P_Lj_Run);

            //Calculate 3 Element in Sum of F1A(Uj)
            double FA_One_Ele_1 = (T12 * Uj) / Q_A1;
            double FA_One_Ele_2 = this.GetFAOneElementTwo(Aa, A1, Uj, P_Lj_Run) / Q_A1;
            double FA_One_Ele_3 = this.GetFAOneElementThree(Aa, Uj);

            //Calculate F1a
            double FA1_Uj = FA_One_Ele_1 - FA_One_Ele_2 * FA_One_Ele_3;

            return FA1_Uj;
        }
        //Aa k = 1 -> F
        protected virtual double CalculateAaStep1()
        {
            //(I.2.1) Calculate Aa => alphak, F, Zkj, R -> Ro, X0 -> Expermitally calculate by Yj0. not seperate YL and Yjo'
            double Ro = this.Z_j0_Complex.Real;
            double Xo = this.Z_j0_Complex.Imaginary;

            double R = Ro / (Math.Pow(Ro, 2) + Math.Pow(Xo, 2));

            double Aa = R;//k= 1-> F <=> 0 -> count - 1
            for (int k = 0; k < this._e_AllMF.Count; k++)
            {
                double Z_kj = this.GetAbsZKJ(k);
                double alphaK = this.GetAlphaKJ(k);//rad
                Aa += (Math.Sin(alphaK) / Z_kj);
            }

            return Aa;
        }
        //Aa k = 1 -> F

        //A1 k = 2 -> F
        protected virtual double CalculateA1Step1(double Uj)
        {
            double A1 = 0;
            for (int k = 1; k < this._e_AllMF.Count; k++)
            {
                //Caculate Tk1 , k = 2 -> f. Before Pkj_k
                double T_K1 = this.CalculateTK1(k, Uj);
                double alpha_k = this.GetAlphaKJ(k);

                A1 += (T_K1 * Math.Cos(2 * alpha_k));
            }

            return A1;
        }
        //A1 k = 2 -> F

        //Get 3 element
        protected virtual double GetFAOneElementThree(double Aa, double Uj)
        {
            double SigmodTwo = 0;
            for (int k = 1; k < this._e_AllMF.Count; k++)
            {
                double alpha_K = this.GetAlphaKJ(k);
                double T_K2 = this.CalculateTK2(k);
                double T_K1 = this.CalculateTK1(k, Uj);

                double numerator = Math.Sin(2 * alpha_K) * T_K2 * Uj;
                double denominator = Math.Sqrt(T_K2 * Uj * Uj - Math.Pow(T_K1, 2));

                SigmodTwo += (numerator / denominator);
            }

            double FA_Ele_3 = 2 * Aa * Uj - SigmodTwo;

            return FA_Ele_3;
        }

        protected virtual double GetFAOneElementTwo(double Aa, double A1, double Uj, double P_Lj_Run)
        {
            //Calculate Signmod 
            double Sigmod = this.SigmodQAOneFromBrandTwo(Uj);
            double FA_Ele_2 = (P_Lj_Run + Aa * Math.Pow(Uj, 2) - A1 - Sigmod);

            return FA_Ele_2;
        }
        //Get 3 element

        //Q1a
        protected double CalculateQAOneStepOne(double T12, double Aa, double A1, double Uj, double P_Lj_Run)
        {
            //Calculate Signmod 
            double Sigmod = this.SigmodQAOneFromBrandTwo(Uj);

            //Calculate Square
            double Square_Q1a = Math.Pow((P_Lj_Run + Aa * Math.Pow(Uj, 2) - A1 - Sigmod), 2);

            //Calculate Q1a
            double Q1A = Math.Sqrt(T12 * Math.Pow(Uj, 2) - Square_Q1a);

            return Q1A;
        }
        //Q1a

        //Sigmod of FA1
        protected double SigmodQAOneFromBrandTwo(double Uj)
        {
            double Sigmod = 0;
            for (int k = 1; k < this._e_AllMF.Count; k++)
            {
                double T_K2 = this.CalculateTK2(k);
                double T_K1 = this.CalculateTK1(k, Uj);
                double alpha_k = this.GetAlphaKJ(k);
                Sigmod += (Math.Sin(2 * alpha_k) * Math.Sqrt(T_K2 * Math.Pow(Uj, 2) - Math.Pow(T_K1, 2)));
            }
            return Sigmod;
        }
        //Sigmod of FA1



        #endregion Calculate_FA_1_Uj_Step1

        #region Calculate_F_AK_Uj_Step1

        protected virtual double FunctFAKByVoltageULoad(int k, double Uj)
        {
            double alpha_K = this.GetAlphaKJ(k);
            double T_K1 = this.CalculateTK1(k, Uj);
            double T_K2 = this.CalculateTK2(k);

            double Q_AK = this.CalculateQAK(k, Uj);

            //Caculate 2 eleement of sum F_AK_Uj
            double F_AK_Ele1 = (T_K2 * Math.Pow(Math.Cos(2 * alpha_K), 2) * Uj) / Q_AK;
            double F_AK_Ele2 = (T_K1 * Math.Sin(4 * alpha_K) * T_K2 * Uj) / (2 * Q_AK * Math.Sqrt(T_K2 * Uj * Uj - T_K1 * T_K1));

            double F_AK_Uj = F_AK_Ele1 - F_AK_Ele2;

            return F_AK_Uj;
        }

        #endregion Calculate_F_AK_Uj_Step1

        #region Calculate_Ar_Uj_Step1

        protected virtual double CalculateARStep1()
        {
            //(I.2.1) Calculate Ar => X -> Ro, X0 -> Expermitally calculate by Yj0. not seperate YL and Yjo'
            double Ro = this.Z_j0_Complex.Real;
            double Xo = this.Z_j0_Complex.Imaginary;

            double X = Xo / (Math.Pow(Ro, 2) + Math.Pow(Xo, 2));

            //k = 1-> f (in code is 0 -> f - 1)
            double Ar = X;
            for (int k = 0; k < this._e_AllMF.Count; k++)
            {
                double alpha_K = this.GetAlphaKJ(k);
                double Z_kj = this.GetAbsZKJ(k);
                Ar += (Math.Cos(alpha_K) / Z_kj);
            }

            return Ar;
        }

        #endregion Calculate_Ar_Uj_Step1

        #region Cal_QL(j)
        //After assign value for Plj and find Uj
        public double CalculateReactivePowerQLJStepOne(double Uj, double P_Lj_Run)
        {
            //Now, YBus is count x count matrix => i = 1, j = count + 1. But run from 0 => i =0, j = count
            double Z_1j = this.GetAbsZKJ(0);

            // Calculate T12 = E1 ^2 / Z1j
            double T12 = Math.Pow(this._e_AllMF[0], 2) / Math.Pow(Z_1j, 2);

            //(I.2)Calculate Q_1a => Aa, A1, alpha_k, T12, P_Lj_Run, Tk2, Tk1

            //Caculate Aa
            double Aa = this.CalculateAaStep1();

            //Caculate A1
            double A1 = this.CalculateA1Step1(Uj);

            //Calculate Qa1
            double Q_A1 = this.CalculateQAOneStepOne(T12, Aa, A1, Uj, P_Lj_Run);


            //Sigmode of QAK(Uj)
            double Sigmod_Q_AK_Uj = 0;//k = 2-> f (in code is 1 -> f - 1)
            for (int k = 1; k < this._e_AllMF.Count; k++)
            {
                //Calculate FAK(Uj)
                double Q_AK_Uj = this.CalculateQAK(k, Uj);
                Sigmod_Q_AK_Uj += Q_AK_Uj;
            }

            //Calculate Ar * Uj^2
            double Ar = this.CalculateARStep1();
            double Q_LJ_ArUj = Ar * Math.Pow(Uj, 2);

            double Q_Lj = Q_A1 + Sigmod_Q_AK_Uj - Q_LJ_ArUj;

            MessageBox.Show("QA1 = " + Q_A1 + ", Sigmod_Q_AK_Uj = " + Sigmod_Q_AK_Uj + ", Q_LJ_ArUj = " + Q_LJ_ArUj);

            return Q_Lj;
        }

        #endregion Cal_QL

        #region Func_Overrall


        //Tk1 k is parameter
        protected virtual double CalculateTK1(int k, double Uj)
        {
            double Z_kj = this.GetAbsZKJ(k);
            double alphaK = this.GetAlphaKJ(k);
            double E_k = this._e_AllMF[k];

            double Pkj_k = ((Math.Sin(alphaK) * Math.Pow(E_k, 2)) / Z_kj) + ((E_k * Uj * Math.Sin(this._rad_ThetaK_All[k] - alphaK)) / Z_kj);

            double T_K1 = Pkj_k - ((Math.Sin(alphaK) * Math.Pow(E_k, 2)) / Z_kj);

            return T_K1;
        }
        //Tk1 k is parameter

        //double Z_kj
        protected virtual double GetAbsZKJ(int k)
        {
            Complex Z_kj = this.ZBus[k, this.ZBus.GetLength(0) - 1];
            double Abs_ZKj = Complex.Abs(Z_kj);

            return Abs_ZKj;
        }
        //double Z_kj

        //TK2
        protected virtual double CalculateTK2(int k)
        {
            double Z_kj = this.GetAbsZKJ(k);
            double E_k = this._e_AllMF[k];

            double T_K2 = Math.Pow(E_k, 2) / Math.Pow(Z_kj, 2);

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

        //Q_AK
        protected virtual double CalculateQAK(int k, double Uj)
        {
            double alpha_K = this.GetAlphaKJ(k);
            double T_K1 = this.CalculateTK1(k, Uj);
            double T_K2 = this.CalculateTK2(k);

            //Caculate 3 eleement of sum Q_AK
            double Q_AK_Ele1 = T_K2 * Math.Pow(Math.Cos(2 * alpha_K), 2) * Math.Pow(Uj, 2);
            double Q_AK_Ele2 = Math.Pow(T_K1, 2) * Math.Cos(4 * alpha_K);
            double Q_AK_Ele3 = T_K1 * Math.Sin(4 * alpha_K) * Math.Sqrt(T_K2 * Math.Pow(Uj, 2) - Math.Pow(T_K1, 2));

            double Q_AK = Math.Sqrt(Q_AK_Ele1 - Q_AK_Ele2 - Q_AK_Ele3);
            return Q_AK;
        }
        //Q_AK
        #endregion Func_Overrall
    }
}


















