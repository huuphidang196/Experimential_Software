using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.DAO.DAO_Curve.DAO_IsovalForm
{
    public class DAOGetTextSysemIsoval
    {
        private static DAOGetTextSysemIsoval _instance;
        public static DAOGetTextSysemIsoval Instance
        {
            get { if (_instance == null) _instance = new DAOGetTextSysemIsoval(); return _instance; }
            private set { }
        }

        private DAOGetTextSysemIsoval() { }

        #region Zone_YState
        public virtual string GetTextYStateShowForm(Complex[,] Ystate)
        {
            int spaceEmpty = 10;
            string txtYsate = new string(' ', 26);

            for (int i = 0; i < Ystate.GetLength(0); i++)
            {
                string numBus = "Bus_" + (i + 1).ToString("D2") + new string(' ', 28);
                txtYsate += numBus;
            }
            //Down row
            txtYsate += "\n";

            for (int i = 0; i < Ystate.GetLength(0); i++)
            {
                string numBus = "Bus_" + (i + 1).ToString("D2") + new string(' ', spaceEmpty);
                for (int j = 0; j < Ystate.GetLength(1); j++)
                {
                    numBus += "( " + Ystate[i, j].Real.ToString("F4") + " + j" + Ystate[i, j].Imaginary.ToString("F4")
                        + ")" + new string(' ', spaceEmpty);
                }
                txtYsate += numBus + "\n";
            }

            return txtYsate;
        }
        #endregion Zone_YState

        #region Zone_Y_Bus
        public virtual string GetObjectNumberAllMF(List<ConnectableE> allMF)
        {
            string strMF = "";
            for (int i = 0; i < allMF.Count; i++)
            {
                strMF += allMF[i].DatabaseE.DataRecordE.DTOGeneEPower.ObjectNumber;
                if (i != allMF.Count - 1) strMF += ", ";
            }

            return strMF;
        }

        public virtual string GetTextYBusShowFrom(ConnectableE _busExamined, Complex[,] YBus)
        {
            int spaceEmpty = 10;
            string txtYbus = new string(' ', 26);

            for (int i = 0; i < YBus.GetLength(0); i++)
            {
                string numBus = "Bus_" + this.GetNumberBus(i, _busExamined, YBus).ToString("D2") + new string(' ', 28);
                txtYbus += numBus;
            }
            //Down row
            txtYbus += "\n";

            for (int i = 0; i < YBus.GetLength(0); i++)
            {
                string numBus = "Bus_" + this.GetNumberBus(i, _busExamined, YBus).ToString("D2") + new string(' ', spaceEmpty);
                for (int j = 0; j < YBus.GetLength(1); j++)
                {
                    numBus += "( " + YBus[i, j].Real.ToString("F4") + " + j" + YBus[i, j].Imaginary.ToString("F4")
                        + ")" + new string(' ', spaceEmpty);
                }
                txtYbus += numBus + "\n";
            }

            return txtYbus;
        }

        protected virtual int GetNumberBus(int i, ConnectableE _busExamined, Complex[,] YBus)
        {
            int numberBus = (i != YBus.GetLength(0) - 1) ? (i + 1) : (_busExamined.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber - 100 * (int)ObjectType.Bus);
            return numberBus;
        }
        #endregion Y_Bus
    }
}
