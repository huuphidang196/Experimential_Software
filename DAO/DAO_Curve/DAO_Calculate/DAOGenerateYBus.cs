using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.DAO.DAO_Curve.DAO_Calculate
{
    public class DAOGenerateYBus
    {
        private static DAOGenerateYBus _instance;
        public static DAOGenerateYBus Instance
        {
            get { if (_instance == null) _instance = new DAOGenerateYBus(); return _instance; }
            private set { }
        }

        private DAOGenerateYBus() { }

        #region YBus_Isoval

        // Ybus isoval
        public virtual Complex[,] CalculateYBusIsoval(int CountMF, ConnectableE EPowerBusJLoad, Complex[,] YSate)
        {
            //swap row order j with f + 1, same with column

            int number_BusJ = EPowerBusJLoad.DatabaseE.DataRecordE.DTOBusEPower.ObjectNumber - 100 * (int)ObjectType.Bus;
            Complex[,] Y_Transfer = this.GetYTransferRowAndCol(CountMF, number_BusJ, YSate);

            //Clone Y bus temp = Y state
            Complex[,] Y_Temp = (Complex[,])Y_Transfer.Clone();

            // Tính ma trận đẳng trị
            //In order to have matrix (f+f) x (f+1) <=> k stop where k = f. Beacause k run from length <=> number N in paper => k stop k = f + 2 > f + 1 
            for (int k = Y_Transfer.GetLength(0); k > CountMF + 1; k--)
            {
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        Complex Y_Devide = (Y_Temp[i, k - 1] * Y_Temp[k - 1, j]) / (Y_Temp[k - 1, k - 1]);

                        Complex Y_ij = Y_Temp[i, j] - Y_Devide;

                        Y_Temp[i, j] = new Complex(double.Parse(Y_ij.Real.ToString("N4")),
                       double.Parse(Y_ij.Imaginary.ToString("N4")));
                    }

                }

            }

            //Remove All Coulumn and Row have value Elements = 0. In spite of this case is not nescessary cause from F + 2

            Complex[,] Y_Bus = this.PruneMatrixByRemoveZero(Y_Temp);

            // Trả về ma trận đẳng trị
            return Y_Bus;
        }

        protected virtual Complex[,] GetYTransferRowAndCol(int CountMF, int number_BusJ, Complex[,] YSate)
        {
            // Transfer Y_State to YTransfer by swapping row order j with f = 1, do same with column 
            Complex[,] Y_Transfer = (Complex[,])YSate.Clone();

            int j = number_BusJ - 1;
            int f = CountMF - 1;
            int n = Y_Transfer.GetLength(0);

            // Đảo các phần tử của hàng thứ j và hàng thứ (f+1)
            for (int i = 0; i < n; i++)
            {
                var temp = Y_Transfer[j, i];
                Y_Transfer[j, i] = Y_Transfer[f + 1, i];
                Y_Transfer[f + 1, i] = temp;
            }

            // Đảo các phần tử của cột thứ j và cột thứ (f+1)
            for (int i = 0; i < n; i++)
            {
                var temp = Y_Transfer[i, j];
                Y_Transfer[i, j] = Y_Transfer[i, f + 1];
                Y_Transfer[i, f + 1] = temp;
            }

            return Y_Transfer;
        }


        protected virtual Complex[,] PruneMatrixByRemoveZero(Complex[,] Y_Temp)
        {
            DenseMatrix Y_Tem_RMZ = DenseMatrix.OfArray((Complex[,])Y_Temp.Clone());

            // Rút gọn ma trận bằng cách loại bỏ các hàng và cột có giá trị bằng 0
            for (int i = Y_Tem_RMZ.RowCount - 1; i >= 0; i--)
            {
                if (Y_Tem_RMZ.Row(i).All(x => x == Complex.Zero))
                {
                    Y_Tem_RMZ = (DenseMatrix)Y_Tem_RMZ.RemoveRow(i);
                }
            }

            for (int j = Y_Tem_RMZ.ColumnCount - 1; j >= 0; j--)
            {
                if (Y_Tem_RMZ.Column(j).All(x => x == Complex.Zero))
                {
                    Y_Tem_RMZ = (DenseMatrix)Y_Tem_RMZ.RemoveColumn(j);
                }
            }

            return Y_Tem_RMZ.ToArray();
        }
        // Ybus isoval    
        #endregion YBus_Isoval

        #region Z_Bus_Isoval
        // Chuyển ma trận tổng dẫn sang ma trận tổng trở
        public virtual Complex[,] ConvertFormYBusToZBus(Complex[,] YBus)
        {
            //Chuyển ma trận số phức thành ma trận DenseMatrix:
            DenseMatrix denseMatrix = DenseMatrix.OfArray((Complex[,])YBus.Clone());

            //Tìm ma trận nghịch đảo:
            DenseMatrix inverseMatrix = (DenseMatrix)denseMatrix.Inverse();

            //Chuyển ma trận nghịch đảo từ kiểu DenseMatrix sang kiểu Complex[,] (nếu cần):
            Complex[,] ZBus = inverseMatrix.ToArray();

            return ZBus;
        }

        // Z_ko , k = 1 --> F + 1, j default = 3 (<=> 4)
        public virtual Complex GetZIOFromYBus(int branchI, Complex[,] YBus, ConnectableE ELoad)
        {
            //branch i input = stt run 1- F standard with diagram
            Complex Y_ii = YBus[branchI - 1, branchI - 1];
            Complex Y_io = Y_ii;
            for (int j = 0; j < YBus.GetLength(1); j++)
            {
                if (j != branchI - 1) Y_io -= YBus[branchI - 1, j];
            }
            //If branch i = bus Load <=> F + 1 => Get Z'io
            if (branchI == YBus.GetLength(0)) Y_io -= ELoad.DatabaseE.DataRecordE.DTOLoadEPower.YLConductanceLoadPU;

            Complex Z_io = 1 / Y_io;

            return Z_io;
        }


        #endregion Zbus_Isoval
    }
}
