using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.DAO.DAO_Curve.DAO_Calculate
{
    public class DAOCalculateQLJStepOne
    {
        private static DAOCalculateQLJStepOne _instance;
        public static DAOCalculateQLJStepOne Instance
        {
            get { if (_instance == null) _instance = new DAOCalculateQLJStepOne(); return _instance; }
            private set { }
        }
        private DAOCalculateQLJStepOne() { }

        #region Variable
        protected ConnectableE _ePower_LoadJ;

        protected List<double> _e_AllMF;

        public List<double> E_AllMF => _e_AllMF;

        protected List<double> _rad_ThetaK_All;
        public List<double> Rad_ThetaK_All => _rad_ThetaK_All;

        protected Complex[,] _YState;
        public Complex[,] YState => _YState;

        protected Complex[,] YBus;
        public Complex[,] YBusIsoval => YBus;

        protected Complex[,] ZBus;
        public Complex[,] ZBusIsoval => ZBus;


        protected List<ReactPowerQLimit> _power_Q_GK_Limits;

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

        protected double _uJ_BusLoad = 0;
        public double UJ_BusLoad => _uJ_BusLoad;

        #endregion Variable

        #region Process_Generate_QLj
        public virtual void SetDatabaseOriginBeforeCalculate(DTODataInputPowerSystem dataInputPS, List<ConnectableE> allBus, ConnectableE EPowerBusJLoad)
        {
            this._e_AllMF = dataInputPS.E_AllMF;
            this._rad_ThetaK_All = dataInputPS.Rad_ThetaK_All;
            this._power_Q_GK_Limits = dataInputPS.Q_GK_Limits;

            this._ePower_LoadJ = this.GetEPowerPLoadFromEPowerBusLoadConsider(EPowerBusJLoad);
            this._uJ_BusLoad = EPowerBusJLoad.DatabaseE.DataRecordE.DTOBusEPower.Voltage_pu;//Uref use Step 2 is Udm at Bus J => Bus is examined

            this._YState = DAOGenerateYState.Instance.CalculateMatrixYState(allBus);
            this.YBus = DAOGenerateYBus.Instance.CalculateYBusIsoval(this._e_AllMF.Count, EPowerBusJLoad, YState);
            this.ZBus = DAOGenerateYBus.Instance.ConvertFormYBusToZBus(YBus);

        }

        public virtual ConnectableE GetEPowerPLoadFromEPowerBusLoadConsider(ConnectableE ePowerBusJLoad)
        {
            LineConnect lineConELoad = ePowerBusJLoad.ListBranch_Drawn.Find(x => x.StartEPower.DatabaseE.ObjectType == ObjectType.Load || x.EndEPower.DatabaseE.ObjectType == ObjectType.Load);
            if (lineConELoad == null)
            {
                MessageBox.Show("This Bus is not connected with any Load !\nPlease Select Again!");
                return null;
            }
            ConnectableE ELoad = (lineConELoad.StartEPower.DatabaseE.ObjectType == ObjectType.Load) ? lineConELoad.StartEPower : lineConELoad.EndEPower;

            //Set EPowerLoad for Y'j0 use
            return ELoad;
        }

        public virtual double GetQLjSuitableForStablePower(double P_Lj_Run)
        {
            double Uj_Min = 0;
            double Uj_Max = 2;
            double eps = 0.3;
            double Q_Lj_Found = 0;

            Func<double, double, double> F_UJ = this.FuncFAByVoltageULoad;

            // Use BruteForceSearch method in order to Find UJ variable
            double UJ_Found = BruteForceSearch(F_UJ, Uj_Min, Uj_Max, P_Lj_Run, eps);

            //Check Condition of 2.2 Equation
            bool isCurveLimit = this.CheckQLJStepOneIsOnCurve(UJ_Found);

            // this.ExperimentalPrintValueOfLists();
            if (isCurveLimit)
            {
                // Calculate QlJ step1. Check=> true return, false then implement step 2
                Q_Lj_Found = this.CalculateReactivePowerQLJStepOne(UJ_Found, P_Lj_Run);
                return Q_Lj_Found;
            }

            while (!isCurveLimit)
            {
                //UpdateData after Each loop
                DAOCalculateQLJStepSecond.Instance.UpdateDataAgainAfterOnceLoop();

                //FunctionB = 0. F_B(Uj) = 0
                F_UJ = DAOCalculateQLJStepSecond.Instance.FuncFBByVoltageULoadStepTwo;

                UJ_Found = BruteForceSearch(F_UJ, Uj_Min, Uj_Max, P_Lj_Run, eps);

                //Check Step 2 in Script of Step One in order to Set list satify and unsatify
                isCurveLimit = this.CheckQLJStepTwoIsOnCurve(UJ_Found);

                if (isCurveLimit)
                {
                    //Calculate QlJ step1. Check => true return, false then implement step 2
                    Q_Lj_Found = DAOCalculateQLJStepSecond.Instance.CalculateReactivePowerQLJStepTwo(UJ_Found, P_Lj_Run);
                    break;
                }
            }

            return Q_Lj_Found;
        }

        #region Check_IsOnCurve_StepOne
        protected virtual bool CheckQLJStepOneIsOnCurve(double UJ_Found)
        {
            this.GenerateListAndAddPowerOneInitial(UJ_Found);

            //Calculate Q_KJ_K upstream 
            for (int k = 1; k < this.E_AllMF.Count; k++)
            {
                //Calculate Pkjk in order to calculate pkjj step 2
                double P_KJ_K = this.CalculatePowerPKJKUpStreamStepOne(UJ_Found, k);
                // get k beacause E_AllMF contain All MF
                double Q_KJ_K = this.CalculatePowerQKJKUpStreamStepOne(UJ_Found, k);
                bool isAboutLimit = this.CheckLimitQKJK(Q_KJ_K, k);
                //Check then add List
                if (isAboutLimit) this._ePower_Satify.Add(k);
                else
                {
                    // not satify
                    this._ePower_UnSatify.Add(k);
                    Q_KJ_K = this.SetValueForPowerUnSatify(Q_KJ_K, k);//Case not satify must set value equal min or max = const
                }
                // Add Q_KJ_K
                this._powers_Q_Kj_K.Add(Q_KJ_K);
                //add P_KJ_K
                this.Powers_P_Kj_K.Add(P_KJ_K);
            }
            //If no child in unSatify then All Epower suitable => QLj is on Curve
            if (this._ePower_UnSatify.Count == 0) return true;

            return false;
        }

        protected virtual void GenerateListAndAddPowerOneInitial(double UJ_Found)
        {
            //When go step2 then generate List satify and un 
            this._ePower_Satify = new List<int>();
            this._ePower_UnSatify = new List<int>();

            this._powers_Q_Kj_K = new List<double>();
            this._powers_P_Kj_K = new List<double>();

            //Add Bus 1 => Slack always satify
            this._ePower_Satify.Add(0);

            double Q_1J_1 = this.CalculatePowerQKJKUpStreamStepOne(UJ_Found, 0);
            // Add Q_1J_1
            this._powers_Q_Kj_K.Add(Q_1J_1);

            //add P_1J_1
            double P_1J_1 = this.CalculatePowerPKJKUpStreamStepOne(UJ_Found, 0);
            this._powers_P_Kj_K.Add(P_1J_1);

        }

        protected virtual double SetValueForPowerUnSatify(double Q_KJ_K, int k)
        {
            ReactPowerQLimit powerQLimit = this._power_Q_GK_Limits[k];
            double Q_GK_Max = powerQLimit.Q_Gk_Max;
            double Q_GK_Min = powerQLimit.Q_Gk_Min;

            //Qk_min
            double Q_K_Min = Q_GK_Min - this.GetRectPowerQKZero(k);
            //Qk_max
            double Q_K_Max = Q_GK_Max - this.GetRectPowerQKZero(k);

            if (Q_KJ_K <= Q_K_Min) return Q_K_Min;

            return Q_K_Max;
        }

        #endregion Check_IsOnCurve_StepOne


        protected virtual bool CheckQLJStepTwoIsOnCurve(double UJ_Found)
        {
            //Check in the list Satify have any power Unsatify => if not any unsatify => Qlj, if have then loop step2=> add List Unsatify
            //Calculate P_KJ_K, QkjK after find UJ on step 2 same step 1 . Diffence list contain k
            //ignore E1 => Slack. Please change code if have any change E1 
            if (this._ePower_Satify.Count == 1) return true; // because now only contain E1

            for (int i = 1; i < this._ePower_Satify.Count; i++)
            {
                //don't get k beacause only consider list MF that it is satifying => Check 
                int numKPower = this._ePower_Satify[i];
                double Q_KJ_K = this.CalculatePowerQKJKUpStreamStepOne(UJ_Found, numKPower);
                bool isAboutLimit = this.CheckLimitQKJK(Q_KJ_K, numKPower);
                if (!isAboutLimit)
                {
                    //remove Power unsatify 
                    this._ePower_Satify.RemoveAt(i);
                    //add to list Unsatify
                    this._ePower_UnSatify.Add(numKPower);
                    Q_KJ_K = this.SetValueForPowerUnSatify(Q_KJ_K, numKPower);//Case not satify must set value equal min or max = const
                    //Recify PKJ_K and Q_KJ_K at bus unstify
                    double P_KJ_K = this.CalculatePowerPKJKUpStreamStepOne(UJ_Found, numKPower);

                    this._powers_Q_Kj_K[numKPower] = Q_KJ_K;
                    this._powers_P_Kj_K[numKPower] = P_KJ_K;
                    return false;
                }

            }

            return true;
        }
        #region Func_Search
        protected virtual double BruteForceSearch(Func<double, double, double> F_UJ, double Uj_Min, double Uj_Max, double P_lj_Run, double eps)
        {
            double x = Uj_Min;
            double fx = 0;
            while (x < Uj_Max)
            {
                fx = F_UJ(x, P_lj_Run);
                if (Math.Abs(fx) < eps) break;

                x += 2e-3; // or any other small step size
            }
            return x;
        }
        #endregion Func_Search

        #endregion Process_Generate_QLj

        #region Step_One

        public virtual double FuncFAByVoltageULoad(double Uj, double P_Lj_Run)
        {
            //F1a(Uj)
            double F_A1_Uj = this.FuncFAOneByVoltageULoad(Uj, P_Lj_Run);

            //Sigmode of FAK(Uj)
            double Sigmod_F_AK_Uj = 0;//k = 2-> f (in code is 1 -> f - 1)
            for (int k = 1; k < this.E_AllMF.Count; k++)
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
            double T12 = Math.Pow(this.E_AllMF[0], 2) / Math.Pow(Z_1j, 2);

            //(I.2)Calculate Q_1a => Aa, A1, alpha_k, T12, P_Lj_Run, Tk2, Tk1

            //Caculate Aa
            double Aa = this.CalculateAaStepOne();

            //Caculate A1
            double A1 = this.CalculateA1StepOne(Uj);

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
        protected virtual double CalculateAaStepOne()
        {
            bool isReal = true;
            double R = this.GetROrXFromZJ0(isReal);

            double Aa = R;//k= 1-> F <=> 0 -> count - 1
            for (int k = 0; k < this.E_AllMF.Count; k++)
            {
                double Z_kj = this.GetAbsZKJ(k);
                double alphaK = this.GetAlphaKJ(k);//rad
                Aa += (Math.Sin(alphaK) / Z_kj);
            }

            return Aa;
        }
        //Aa k = 1 -> F

        //A1 k = 2 -> F
        protected virtual double CalculateA1StepOne(double Uj)
        {
            double A1 = 0;
            for (int k = 1; k < this.E_AllMF.Count; k++)
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
            for (int k = 1; k < this.E_AllMF.Count; k++)
            {
                double alpha_K = this.GetAlphaKJ(k);
                double T_K2 = this.CalculateTK2(k);
                double T_K1 = this.CalculateTK1(k, Uj);

                double numerator = Math.Sin(2 * alpha_K) * T_K2 * Uj;
                double denominator = Math.Sqrt(T_K2 * Math.Pow(Uj, 2) - Math.Pow(T_K1, 2));

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

            //MessageBox.Show((T12 * Math.Pow(Uj, 2) - Square_Q1a).ToString());
            return Q1A;
        }
        //Q1a

        //Sigmod of FA1
        protected double SigmodQAOneFromBrandTwo(double Uj)
        {
            double Sigmod = 0;
            for (int k = 1; k < this.E_AllMF.Count; k++)
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
            double F_AK_Ele2 = (T_K1 * Math.Sin(4 * alpha_K) * T_K2 * Uj) / (2 * Q_AK * Math.Sqrt(T_K2 * Math.Pow(Uj, 2) - Math.Pow(T_K1, 2)));

            double F_AK_Uj = F_AK_Ele1 - F_AK_Ele2;

            return F_AK_Uj;
        }

        #endregion Calculate_F_AK_Uj_Step1

        #region Calculate_Ar_Uj_Step1

        protected virtual double CalculateARStep1()
        {
            bool isReal = false;//getX not R
            double X = this.GetROrXFromZJ0(isReal);

            //k = 1-> f (in code is 0 -> f - 1)
            double Ar = X;
            for (int k = 0; k < this.E_AllMF.Count; k++)
            {
                double alpha_K = this.GetAlphaKJ(k);
                double Z_kj = this.GetAbsZKJ(k);
                Ar += (Math.Cos(alpha_K) / Z_kj);
            }

            return Ar;
        }

        #endregion Calculate_Ar_Uj_Step1

        #region Cal_QL(j)_Ref
        //After assign value for Plj and find Uj => Q_L(j)
        protected double CalculateReactivePowerQLJStepOne(double Uj, double P_Lj_Run)
        {
            //Now, YBus is count x count matrix => i = 1, j = count + 1. But run from 0 => i =0, j = count
            double Z_1j = this.GetAbsZKJ(0);

            // Calculate T12 = E1 ^2 / Z1j
            double T12 = Math.Pow(this.E_AllMF[0], 2) / Math.Pow(Z_1j, 2);

            //(I.2)Calculate Q_1a => Aa, A1, alpha_k, T12, P_Lj_Run, Tk2, Tk1

            //Caculate Aa
            double Aa = this.CalculateAaStepOne();

            //Caculate A1
            double A1 = this.CalculateA1StepOne(Uj);

            //Calculate Qa1
            double Q_A1 = this.CalculateQAOneStepOne(T12, Aa, A1, Uj, P_Lj_Run);


            //Sigmode of QAK(Uj)
            double Sigmod_Q_AK_Uj = 0;//k = 2-> f (in code is 1 -> f - 1)
            for (int k = 1; k < this.E_AllMF.Count; k++)
            {
                //Calculate FAK(Uj)
                double Q_AK_Uj = this.CalculateQAK(k, Uj);
                Sigmod_Q_AK_Uj += Q_AK_Uj;
            }

            //Calculate Ar * Uj^2
            double Ar = this.CalculateARStep1();
            double Q_LJ_ArUj = Ar * Math.Pow(Uj, 2);

            double Q_Lj = Q_A1 + Sigmod_Q_AK_Uj - Q_LJ_ArUj;

            //     MessageBox.Show("QA1 = " + Q_A1 + ", Sigmod_Q_AK_Uj = " + Sigmod_Q_AK_Uj + ", Q_LJ_ArUj = " + Q_LJ_ArUj + "QLJ = " + Q_Lj);

            return Q_Lj;
        }

        //Calculate Q_KJ_K 
        protected virtual double CalculatePowerQKJKUpStreamStepOne(double UJ_Found, int k)
        {
            double alpha_K = this.GetAlphaKJ(k);
            double Z_kj = this.GetAlphaKJ(k);
            double E_K = this.E_AllMF[k];
            double Pkj_k = ((Math.Sin(alpha_K) * Math.Pow(E_K, 2)) / Z_kj) + ((E_K * UJ_Found * Math.Sin(this._rad_ThetaK_All[k] - alpha_K)) / Z_kj);

            double Q_Kj_K_Ele1 = Math.Cos(alpha_K) * (Math.Pow(E_K, 2) / Z_kj);

            double Q_Kj_K_Ele2A = Math.Pow((E_K * UJ_Found) / Z_kj, 2);
            double Q_Kj_K_Ele2B = Math.Pow(Pkj_k - (Math.Sin(alpha_K) * Math.Pow(E_K, 2)) / Z_kj, 2);
            double Q_Kj_K_Ele2 = Math.Sqrt(Q_Kj_K_Ele2A - Q_Kj_K_Ele2B);

            double Q_Kj_K = Q_Kj_K_Ele1 - Q_Kj_K_Ele2;

            return Q_Kj_K;
        }

        //check limit Q_Kj_k
        protected virtual bool CheckLimitQKJK(double Q_KJ_K, int k)
        {
            ReactPowerQLimit powerQLimit = this._power_Q_GK_Limits[k];
            double Q_GK_Max = powerQLimit.Q_Gk_Max;
            double Q_GK_Min = powerQLimit.Q_Gk_Min;

            //Qk_min
            double Q_K_Min = Q_GK_Min - this.GetRectPowerQKZero(k);
            //Qk_max
            double Q_K_Max = Q_GK_Max - this.GetRectPowerQKZero(k);

            if (Q_KJ_K > Q_K_Min && Q_KJ_K < Q_K_Max) return true;

            return false;
        }

        //Calculate Q_KJ_K 
        protected virtual double CalculatePowerPKJKUpStreamStepOne(double UJ_Found, int k)
        {
            double alpha_K = this.GetAlphaKJ(k);
            double Z_kj = this.GetAlphaKJ(k);
            double E_K = this.E_AllMF[k];
            double Pkj_k = ((Math.Sin(alpha_K) * Math.Pow(E_K, 2)) / Z_kj) + ((E_K * UJ_Found * Math.Sin(this._rad_ThetaK_All[k] - alpha_K)) / Z_kj);

            return Pkj_k;
        }

        #endregion Cal_QL(j)_Ref

        #endregion Step_One

        #region Func_Overrall

        //Tk1 k is parameter
        public virtual double CalculateTK1(int k, double Uj)
        {
            double Z_kj = this.GetAbsZKJ(k);
            double alpha_K = this.GetAlphaKJ(k);
            double E_K = this.E_AllMF[k];

            double Pkj_k = ((Math.Sin(alpha_K) * Math.Pow(E_K, 2)) / Z_kj) + ((E_K * Uj * Math.Sin(this._rad_ThetaK_All[k] - alpha_K)) / Z_kj);

            double T_K1 = Pkj_k - ((Math.Sin(alpha_K) * Math.Pow(E_K, 2)) / Z_kj);

            return T_K1;
        }
        //Tk1 k is parameter

        //double Z_kj_Complex
        public virtual Complex GetComplexZKJ(int k)
        {
            Complex Z_kj = this.ZBus[k, this.ZBus.GetLength(0) - 1];

            return Z_kj;
        }
        //double Z_kj_Complex

        //double Z_kj
        public virtual double GetAbsZKJ(int k)
        {
            Complex Z_kj = this.GetComplexZKJ(k);
            double Abs_ZKj = Complex.Abs(Z_kj);

            return Abs_ZKj;
        }
        //double Z_kj

        //TK2
        public virtual double CalculateTK2(int k)
        {
            double Z_kj = this.GetAbsZKJ(k);
            double E_k = this.E_AllMF[k];

            double T_K2 = Math.Pow(E_k, 2) / Math.Pow(Z_kj, 2);

            return T_K2;
        }
        //Tk2

        //Alpha_KJ
        public virtual double GetAlphaKJ(int k)
        {
            Complex Z_kj = this.GetComplexZKJ(k);
            return (Math.PI / 2) - Math.Atan2(Z_kj.Imaginary, Z_kj.Real);
        }
        //Alpha_KJ

        //Q_AK
        public virtual double CalculateQAK(int k, double Uj)
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

        //Q_K0
        public virtual double GetRectPowerQKZero(int k)
        {
            // Qk0 -> Ek, Zk0, alpha_k0
            double Z_K0 = this.GetZK0FromYBusAndK(k);
            //alpha_K0
            double alpha_K0 = this.GetAlphaK0(k);
            //EK
            double E_K = this.E_AllMF[k];

            double Q_K0 = Math.Cos(alpha_K0) * (Math.Pow(E_K, 2) / Z_K0);

            return Q_K0;
        }
        //Q_K0

        //ZK0
        public virtual double GetZK0FromYBusAndK(int k)
        {
            Complex Z_K0_Complex = DAOGenerateYBus.Instance.GetZIOFromYBus(k + 1, this.YBus, this._ePower_LoadJ);
            double Z_K0 = Complex.Abs(Z_K0_Complex);
            return Z_K0;
        }
        //ZK0

        // alpha_K0
        public virtual double GetAlphaK0(int k)
        {
            Complex Z_K0_Complex = DAOGenerateYBus.Instance.GetZIOFromYBus(k + 1, this.YBus, this._ePower_LoadJ);

            return (Math.PI / 2) - Math.Atan2(Z_K0_Complex.Imaginary, Z_K0_Complex.Real);
        }
        //alpha_K0

        //R or X => Get Z_J0 
        public virtual double GetROrXFromZJ0(bool isReal)
        {
            Complex Z_j0_Complex = this.GetZK0FromYBusAndK(this.E_AllMF.Count);
            //(I.2.1) Calculate Aa => alphak, F, Zkj, R -> Ro, X0 -> calculate vu Yjo'
            double Ro = Z_j0_Complex.Real;
            double Xo = Z_j0_Complex.Imaginary;

            double R = Ro / (Math.Pow(Ro, 2) + Math.Pow(Xo, 2));
            double X = Xo / (Math.Pow(Ro, 2) + Math.Pow(Xo, 2));

            if (isReal) return R;

            return X;
        }
        #endregion Func_Overrall
    }
}
