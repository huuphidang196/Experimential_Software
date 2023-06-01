using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public virtual void ShowYStateShowOnDataGridViewForm(Complex[,] YState, DataGridView dgvMatrixYState)
        {
            dgvMatrixYState.RowCount = YState.GetLength(0) + 1;
            dgvMatrixYState.ColumnCount = YState.GetLength(1) + 1;

            for (int i = 0; i < dgvMatrixYState.RowCount; i++)
            {
                for (int j = 0; j < dgvMatrixYState.ColumnCount; j++)
                {
                    if (i == 0 && j == 0) continue;

                    if (i == 0 && j != 0) dgvMatrixYState[i, j].Value = "Bus_" + j.ToString("#0");
                    else if (i != 0 && j == 0) dgvMatrixYState[i, j].Value = "Bus_" + i.ToString("#0");
                    else dgvMatrixYState[i, j].Value = YState[i - 1, j - 1].Real.ToString("F4") + " + j" + YState[i - 1, j - 1].Imaginary.ToString("F4");
                }
            }

            // Đặt SortMode cho từng cột thành NotSortable
            foreach (DataGridViewColumn column in dgvMatrixYState.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

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

        public virtual void ShowYBusShowOnDataGridViewForm(ConnectableE _busExamined, Complex[,] YBus, DataGridView dgvMatrixYBus)
        {
            dgvMatrixYBus.RowCount = YBus.GetLength(0) + 1;
            dgvMatrixYBus.ColumnCount = YBus.GetLength(1) + 1;

            for (int i = 0; i < dgvMatrixYBus.RowCount; i++)
            {
                for (int j = 0; j < dgvMatrixYBus.ColumnCount; j++)
                {
                    if (i == 0 && j == 0) continue;

                    if (i == 0 && j != 0) dgvMatrixYBus[i, j].Value = "Bus_" + this.GetNumberBus(j, _busExamined, YBus).ToString("#0");
                    else if (i != 0 && j == 0) dgvMatrixYBus[i, j].Value = "Bus_" + this.GetNumberBus(i, _busExamined, YBus).ToString("#0");
                    else dgvMatrixYBus[i, j].Value = YBus[i - 1, j - 1].Real.ToString("F4") + " + j" + YBus[i - 1, j - 1].Imaginary.ToString("F4");
                }
            }

            // Đặt SortMode cho từng cột thành NotSortable
            foreach (DataGridViewColumn column in dgvMatrixYBus.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        protected virtual int GetNumberBus(int i, ConnectableE _busExamined, Complex[,] YBus)
        {
            int numberBus = (i != YBus.GetLength(0)) ? i  : (_busExamined.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber - 100 * (int)ObjectType.Bus);
            return numberBus;
        }
        #endregion Y_Bus
    }
}
