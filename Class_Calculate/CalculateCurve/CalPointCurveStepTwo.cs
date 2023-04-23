using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.Class_Calculate.CalculateCurve
{
    public class CalPointCurveStepTwo
    {
        CalPointCurveStepOne _curveStepOne;

        protected List<double> _e_AllMF;
        public List<double> E_AllMF => _e_AllMF;

        protected List<double> _rad_ThetaK_All;
        public List<double> Rad_ThetaK_All => _rad_ThetaK_All;

        // Use step 2 . SatifyList contain s Power, Unlist contain f - s EPower
        protected List<int> _ePower_Satify;
        public List<int> EPower_Satify => _ePower_Satify;

        protected List<int> _ePower_UnSatify;
        public List<int> EPower_UnSatify => _ePower_UnSatify;

        //list contain all Q_Kj-K
        protected List<double> _powers_Q_Kj_K;
        public List<double> Powers_Q_Kj_K => _powers_Q_Kj_K;

        //list contain all P_Kj-K
        protected List<double> _powers_P_Kj_K;
        public List<double> Powers_P_Kj_K => _powers_P_Kj_K;

        protected double _UJ_StepOne_Found = 0;
        public double UJ_StepOne_Found => _UJ_StepOne_Found;

        public CalPointCurveStepTwo(CalPointCurveStepOne curveStepOne)
        {
            this._curveStepOne = curveStepOne;
            this._e_AllMF = curveStepOne.E_AllMF;
            this._rad_ThetaK_All = curveStepOne.Rad_ThetaK_All;

            this._ePower_Satify = curveStepOne.EPower_Satify;
            this._ePower_UnSatify = curveStepOne.EPower_UnSatify;

            this._powers_P_Kj_K = curveStepOne.Powers_P_Kj_K;
            this._powers_Q_Kj_K = curveStepOne.Powers_Q_Kj_K;

            //Uj at Step 1 Found
            this._UJ_StepOne_Found = this._curveStepOne.UJ_StepOne_Found;
        }

        #region Calculate_F_B(UJ)
        public virtual double FuncFBByVoltageULoad(double Uj, double P_Lj_Run)
        {
            //Calculate F1b(Uj)
            double F_1B_Uj = this.CalculateFBOneStepTwo(Uj, P_Lj_Run);

            //Calculate Sigmod of FKB(UJ)
            double Sigmod_FKB = 0;
            for (int i = 1; i < this._ePower_Satify.Count; i++)
            {
                int numberKPower = this._ePower_Satify[i];
                //F_kB(UJ) => Tk1, Tk2, alphaK, Qb_KJ, Uj
                double F_KB_UJ = this.CalculateFKBStepTwo(numberKPower, Uj);
                Sigmod_FKB += F_KB_UJ;
            }

            //Calculate 2 * Br * Uj
            double Br = this.CalculateBr();
            double F_B_Uj = F_1B_Uj + Sigmod_FKB - 2 * Br * Uj;

            return F_B_Uj;
        }

        #region Calculate_F_1_B_Uj
        //F_1_B(UJ)
        protected virtual double CalculateFBOneStepTwo(double Uj, double P_Lj_Run)
        {
            double T12 = this._curveStepOne.CalculateTK2(0);

            double Q_B_1j = this.CalculateQBOneJ(Uj, P_Lj_Run);

            //F1b_Ele1 => T12, Uj, QB_1j
            double F_1B_Ele1 = (T12 * Uj) / Q_B_1j;

            //F1b_Ele2 => Plj, Ba, B1, alphaK, Tk2, Tk1, QB_1j
            double F_1B_Ele2 = this.CalculateFBOneEleTwo(Uj, P_Lj_Run) / Q_B_1j;

            //F1B_Ele3 => Ba, Uj, alphaK, TK2, Uj, Tk1
            double F_1B_Ele3 = this.CalculateFBOneEleThree(Uj);

            double F_1B_Uj = F_1B_Ele1 - F_1B_Ele2 * F_1B_Ele3;

            return F_1B_Uj;
        }

        //F_1_B(UJ)

        //Q_B_1J
        protected virtual double CalculateQBOneJ(double Uj, double P_Lj_Run)
        {
            //Q_B_1J => T12, Ba, B1, alphaK, TK2, TK1
            double Sigmod = 0;
            for (int i = 1; i < this._ePower_Satify.Count; i++)
            {
                //Get number E is Satify because numbers diffenrence 
                int numberKPower = this._ePower_Satify[i];
                double alpha_K = this._curveStepOne.GetAlphaKJ(numberKPower);

                double TK1 = this._curveStepOne.CalculateTK1(numberKPower, Uj);
                double TK2 = this._curveStepOne.CalculateTK2(numberKPower);

                double Square_Sig = Math.Sin(2 * alpha_K) * Math.Sqrt(TK2 * Math.Pow(Uj, 2) - Math.Pow(TK1, 2));
                Sigmod += Square_Sig;
            }
            double T12 = this._curveStepOne.CalculateTK2(0);
            double Ba = this.CalculateBAStepTwo();
            double B1 = this.CalculateB1StepTwo(Uj);

            double Square_Big = Math.Pow((P_Lj_Run + Ba * Math.Pow(Uj, 2) - B1 - Sigmod), 2);
            //Calculate Q_1B_J
            double Q_B_1J = Math.Sqrt(T12 * Math.Pow(Uj, 2) - Square_Big);
            return Q_B_1J;
        }
        //Q_B_1J

        //Ba
        protected virtual double CalculateBAStepTwo()
        {
            //Calculate Ba => R, alpha1, alphaK, Z1j, Zkj , k = 2->s// k not number bus => transfer to number bus
            bool isReal = true;
            double R = this._curveStepOne.GetROrXFromZJ0(isReal);

            double alpha_1 = this._curveStepOne.GetAlphaKJ(0);
            double Z_1J = this._curveStepOne.GetAbsZKJ(0);
            double Ba_Ele2 = Math.Sin(alpha_1) / Z_1J;

            double Ba_Ele3 = 0;
            for (int i = 1; i < this._ePower_Satify.Count; i++)
            {
                //Get number E is Satify because numbers diffenrence 
                int numberKPower = this._ePower_Satify[i];
                double alpha_K = this._curveStepOne.GetAlphaKJ(numberKPower);

                double Z_KJ = this._curveStepOne.GetAbsZKJ(numberKPower);
                double Ba_ELe3_Small = Math.Sin(alpha_K) / Z_KJ;

                Ba_Ele3 += Ba_ELe3_Small;
            }

            double Ba = R + Ba_Ele2 + Ba_Ele3;

            return Ba;
        }
        //Ba

        //B1
        protected virtual double CalculateB1StepTwo(double Uj)
        {
            double B1_Sig_Ele1 = 0;
            // i = 2->s
            for (int i = 1; i < this._ePower_Satify.Count; i++)
            {
                //Get number E is Satify because numbers diffenrence 
                int numberKPower = this._ePower_Satify[i];
                double alpha_K = this._curveStepOne.GetAlphaKJ(numberKPower);
                double TK1 = this._curveStepOne.CalculateTK1(numberKPower, Uj);

                B1_Sig_Ele1 += TK1 * Math.Cos(2 * alpha_K);
            }

            double B1_Sig_Ele2 = 0;
            // i = s+1-> F
            for (int i = 0; i < this._ePower_UnSatify.Count; i++)
            {
                //Get number E is Satify because numbers diffenrence 
                int numberKPower = this._ePower_UnSatify[i];

                double P_Kj_j = this.CalculatePKJJStepTwo(numberKPower);
                B1_Sig_Ele2 += P_Kj_j;
            }
            double B1 = B1_Sig_Ele1 + B1_Sig_Ele2;

            return B1;
        }
        //B1

        //P_KJ_J
        protected virtual double CalculatePKJJStepTwo(int numberKPower)
        {
            //P_KJ_J => P_KJ_K , Q_KJ_K, R_KJ, U_re temp have value = UFound Step 1
            double P_KJ_K = this._powers_P_Kj_K[numberKPower];
            double Q_KJ_K = this._powers_Q_Kj_K[numberKPower];

            double U_ref = this._UJ_StepOne_Found;

            Complex Z_KJ = this._curveStepOne.GetComplexZKJ(numberKPower);
            double R_KJ = Z_KJ.Real;

            double P_KJ_J = P_KJ_K - R_KJ * ((Math.Pow(P_KJ_K, 2) + Math.Pow(Q_KJ_K, 2)) / Math.Pow(U_ref, 2));

            return P_KJ_J;
        }
        //P_KJ_J

        //FB1_ELement
        protected virtual double CalculateFBOneEleTwo(double Uj, double P_Lj_Run)
        {
            double Sigmod = 0;
            for (int i = 1; i < this._ePower_Satify.Count; i++)
            {
                int numberKPower = this._ePower_Satify[i];
                double TK1 = this._curveStepOne.CalculateTK1(numberKPower, Uj);
                double TK2 = this._curveStepOne.CalculateTK2(numberKPower);
                double alpha_K = this._curveStepOne.GetAlphaKJ(numberKPower);

                double Sigmod_Once = Math.Sin(2 * alpha_K) * Math.Sqrt(TK2 * Math.Pow(Uj, 2) - Math.Pow(TK1, 2));
                Sigmod += Sigmod_Once;
            }
            double Ba = this.CalculateBAStepTwo();
            double B1 = this.CalculateB1StepTwo(Uj);
            double FB_1_Ele2 = P_Lj_Run + Ba * Math.Pow(Uj, 2) - B1 - Sigmod;

            return FB_1_Ele2;
        }


        protected virtual double CalculateFBOneEleThree(double Uj)
        {
            double Sigmod = 0;
            for (int i = 1; i < this._ePower_Satify.Count; i++)
            {
                int numberKPower = this._ePower_Satify[i];
                double TK1 = this._curveStepOne.CalculateTK1(numberKPower, Uj);
                double TK2 = this._curveStepOne.CalculateTK2(numberKPower);
                double alpha_K = this._curveStepOne.GetAlphaKJ(numberKPower);

                double Numerator = Math.Sin(2 * alpha_K) * TK2 * Uj;
                double Denominator = Math.Sqrt(TK2 * Math.Pow(Uj, 2) - Math.Pow(TK1, 2));

                double Fraction = Numerator / Denominator;
                Sigmod += Fraction;

            }
            double Ba = this.CalculateBAStepTwo();
            double FB_1_Ele3 = 2 * Ba * Uj - Sigmod;

            return FB_1_Ele3;
        }

        #endregion Calculate_F_1_B_Uj

        #region Calculate_F_K_B_UJ
        protected virtual double CalculateFKBStepTwo(int numberKPower, double Uj)
        {
            double TK1 = this._curveStepOne.CalculateTK1(numberKPower, Uj);
            double TK2 = this._curveStepOne.CalculateTK2(numberKPower);
            double alphaK = this._curveStepOne.GetAlphaKJ(numberKPower);
            double Q_B_KJ = this.CalculateQBKJ(numberKPower, Uj);

            double F_KB_UJ_Ele1 = (TK2 * Math.Pow(Math.Cos(2 * alphaK), 2) * Uj) / Q_B_KJ;

            double F_KB_UJ_Ele2 = (TK1 * Math.Sin(4 * alphaK) * TK2 * Uj) / (2 * Q_B_KJ * Math.Sqrt(TK2 * Math.Pow(Uj, 2) - Math.Pow(TK1, 2)));

            double F_KB_UJ = F_KB_UJ_Ele1 - F_KB_UJ_Ele2;

            return F_KB_UJ;
        }

        protected virtual double CalculateQBKJ(int numberKPower, double Uj)
        {
            //Q_B_KJ => TK1, Tk2, alphaK
            double TK1 = this._curveStepOne.CalculateTK1(numberKPower, Uj);
            double TK2 = this._curveStepOne.CalculateTK2(numberKPower);
            double alphaK = this._curveStepOne.GetAlphaKJ(numberKPower);

            double Q_B_KJ_Ele1 = TK2 * Math.Pow(Math.Cos(2 * alphaK), 2) * Math.Pow(Uj, 2);
            double Q_B_KJ_Ele2 = Math.Pow(TK1, 2) * Math.Cos(4 * alphaK);
            double Q_B_KJ_Ele3 = TK1 * Math.Sin(4 * alphaK) * Math.Sqrt(TK2 * Math.Pow(Uj, 2) - Math.Pow(TK1, 2));

            double Q_B_KJ = Math.Sqrt(Q_B_KJ_Ele1 - Q_B_KJ_Ele2 - Q_B_KJ_Ele3);

            return Q_B_KJ;
        }


        protected virtual double CalculateBr()
        {
            //Calculate Br => X, alpha1, alphaK, Z1j, Zkj , k = 2->s// k not number bus => transfer to number bus
            bool isReal = false;
            double X = this._curveStepOne.GetROrXFromZJ0(isReal);

            double alpha_1 = this._curveStepOne.GetAlphaKJ(0);
            double Z_1J = this._curveStepOne.GetAbsZKJ(0);
            double Br_Ele2 = Math.Cos(alpha_1) / Z_1J;

            double Br_Ele3 = 0;
            for (int i = 1; i < this._ePower_Satify.Count; i++)
            {
                //Get number E is Satify because numbers diffenrence 
                int numberKPower = this._ePower_Satify[i];
                double alpha_K = this._curveStepOne.GetAlphaKJ(numberKPower);

                double Z_KJ = this._curveStepOne.GetAbsZKJ(numberKPower);
                double Br_ELe3_Small = Math.Cos(alpha_K) / Z_KJ;

                Br_Ele3 += Br_ELe3_Small;
            }

            double Br = X + Br_Ele2 + Br_Ele3;

            return Br;
        }


        #endregion Calculate_F_K_B_UJ

        //FB1_ELement
        #endregion Calculate_F_B(UJ)
    }
}
