using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.Class_Calculate.Calculate_Y
{
    public class CalculateYBus
    {
        #region YBus_Isoval

        // Ybus isoval
        public static Complex[,] CalculateYBusIsoval(int Count_FBus, int number_BusJ)
        {
            //swap row order j with f + 1, same with column

            Complex[,] Y_Transfer = CalculateYBus.GetYTransferRowAndCol(Count_FBus, number_BusJ);

            //Clone Y bus temp = Y state
            Complex[,] Y_Temp = (Complex[,])Y_Transfer.Clone();

            // Tính ma trận đẳng trị
            //In order to have matrix (f+f) x (f+1) <=> k stop where k = f. Beacause k run from length <=> number N in paper => k stop k = f + 2 > f + 1 
            for (int k = Y_Transfer.GetLength(0); k > Count_FBus + 1; k--)
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

            Complex[,] Y_Bus = CalculateYBus.PruneMatrixByRemoveZero(Y_Temp);

            // Trả về ma trận đẳng trị
            return Y_Bus;
        }

        private static Complex[,] GetYTransferRowAndCol(int Count_FBus, int number_BusJ)
        {
            // Transfer Y_State to YTransfer by swapping row order j with f = 1, do same with column 
            Complex[,] Y_Transfer = CalculateYState.CalculateMatrixYState(9);

            int j = number_BusJ - 1;
            int f = Count_FBus - 1;
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


        private static Complex[,] PruneMatrixByRemoveZero(Complex[,] Y_Temp)
        {
            DenseMatrix Y_Tem_RMZ = DenseMatrix.OfArray(Y_Temp);

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
        public static Complex[,] ConvertFormYBusToZBus(Complex[,] YBus)
        {
            //Chuyển ma trận số phức thành ma trận DenseMatrix:
            DenseMatrix denseMatrix = DenseMatrix.OfArray(YBus);

            //Tìm ma trận nghịch đảo:
            DenseMatrix inverseMatrix = (DenseMatrix)denseMatrix.Inverse();

            //Chuyển ma trận nghịch đảo từ kiểu DenseMatrix sang kiểu Complex[,] (nếu cần):
            Complex[,] ZBus = inverseMatrix.ToArray();

            return ZBus;
        }

        // Z_ko , k = 1 --> F + 1, j default = 3 (<=> 4)
        public static Complex GetZIOFromYBus(int branchI, Complex[,] YBus)
        {
            //branch i input = stt run 1- F standard with diagram
            Complex Y_ii = YBus[branchI - 1, branchI - 1];
            Complex Y_io = Y_ii;
            for (int j = 0; j < YBus.GetLength(1); j++)
            {
                if (j != branchI - 1) Y_io -= YBus[branchI - 1, j];
            }

            Complex Z_io = 1 / Y_io;
            return Z_io;
        }


        #endregion Zbus_Isoval

    }
}























/*
 *
        private static Complex[,] GetYBusFromYTransferByRemoveZero(Complex[,] Y_Temp)
        {
            int n = Y_Temp.GetLength(0); // lấy kích thước của ma trận vuông
                                         // Loại bỏ các hàng có các phần tử đều bằng 0
            bool[] rowToRemove = new bool[Y_Temp.GetLength(0)];
            for (int i = 0; i < Y_Temp.GetLength(0); i++)
            {
                bool isRowZero = true;
                for (int j = 0; j < Y_Temp.GetLength(1); j++)
                {
                    if (Y_Temp[i, j] != 0)
                    {
                        isRowZero = false;
                        break;
                    }
                }
                if (isRowZero)
                {
                    rowToRemove[i] = true;
                }
            }

            // Loại bỏ các cột có các phần tử đều bằng 0
            bool[] colToRemove = new bool[Y_Temp.GetLength(1)];
            for (int j = 0; j < Y_Temp.GetLength(1); j++)
            {
                bool isColZero = true;
                for (int i = 0; i < Y_Temp.GetLength(0); i++)
                {
                    if (Y_Temp[i, j] != 0)
                    {
                        isColZero = false;
                        break;
                    }
                }
                if (isColZero)
                {
                    colToRemove[j] = true;
                }
            }

            int newN = n - rowToRemove.Count(r => r); // tính kích thước của ma trận mới sau khi loại bỏ các hàng và cột. false thì r -> !r
                                                      // bool allZeros = Array.TrueForAll(Y_Transfer, row => row.All(value => value == 0));

            Complex[,] Ybus = new Complex[newN, newN]; // khởi tạo ma trận mới

            int newRow = 0;
            for (int i = 0; i < n; i++)
            {
                // Nếu hàng i không bị loại bỏ, kiểm tra xem cột i có bị loại bỏ hay không
                if (rowToRemove[i]) continue;

                int newCol = 0;
                for (int j = 0; j < n; j++)
                {
                    // Nếu cột j không bị loại bỏ, sao chép phần tử từ ma trận cũ sang ma trận mới
                    if (!colToRemove[j])
                    {
                        Ybus[newRow, newCol] = Y_Temp[i, j];
                        newCol++;
                    }
                }
                newRow++;
            }

            return Ybus;

            // Sau khi loại bỏ các hàng và cột, ma trận mới sẽ có kích thước newN x newN
            // Các phần tử trong ma trận mới sẽ là các phần tử không thuộc hàng và cột đã loại bỏ
            //Row và colum ++ là lấy các hàng cột xem giữa các hàng cột ko phải All Elenment là 0. Mặc dù vậy trường hợp này không cần cũng được 

        }
 */