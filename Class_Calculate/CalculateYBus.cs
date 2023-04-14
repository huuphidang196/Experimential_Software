using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.Class_Calculate
{
    public class CalculateYBus
    {
        public static string ShowYBus(int number_FBus, int number_BusJ)
        {
            Complex[,] Ybus = CalculateYBus.CalculateYBusIsoval(number_FBus, number_BusJ);
            string s = "";
            for (int i = 0; i < Ybus.GetLength(0); i++)
            {
                if (i <= number_FBus) s += "Bus " + (i + 1) + new string(' ', 10);
                else s += "Bus " + (number_BusJ + 1) + new string(' ', 10);

                for (int j = 0; j < Ybus.GetLength(1); j++)
                {
                    s += Ybus[i, j] + new string(' ', 15);
                }
                s += "\n";
            }

            return s;
        }
    

        public static Complex[,] CalculateYBusIsoval(int number_FBus, int number_BusJ)
        {
            //swap row order j with f + 1, same with column

            Complex[,] Y_Transfer = CalculateYBus.GetYTransferRowAndCol(number_FBus, number_BusJ);

            //Clone Y bus temp = Y state
            Complex[,] Y_Temp = (Complex[,])Y_Transfer.Clone();

            // Tính ma trận đẳng trị
            //In order to have matrix (f+f) x (f+1) <=> k stop where k = f+2. Beacause k run from length => k stop where k = f + 3 
            for (int k = Y_Transfer.GetLength(0); k > number_FBus + 2; k--)
            {
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        Complex Y_Devide = (Y_Temp[i, k - 1] * Y_Temp[k - 1, j]) / (Y_Temp[k - 1, k - 1]);

                        Complex Y_ij  = Y_Temp[i, j] - Y_Devide;

                        Y_Temp[i,j] = new Complex(double.Parse(Y_ij.Real.ToString("N4")),
                       double.Parse(Y_ij.Imaginary.ToString("N4")));
                    }

                }

            }

            // remove row and columns equal 0
            Complex[,] Y_Bus = new Complex[number_FBus + 2,number_FBus + 2];// because numberFBus now equal real value - 1
            for (int i = 0; i < Y_Bus.GetLength(0); i++)
            {
                for (int j = 0; j < Y_Bus.GetLength(1); j++)
                {
                    Y_Bus[i, j] = Y_Temp[i, j];
                }
            }

            // Trả về ma trận đẳng trị
            return Y_Bus;
        }

        private static Complex[,] GetYTransferRowAndCol(int number_FBus, int number_BusJ)
        {
            // Transfer Y_State to YTransfer by swapping row order j with f = 1, do same with column 
            Complex[,] Y_Transfer = CalculateYState.CalculateMatrixYState(9);

            int j = number_BusJ;
            int f = number_FBus;
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
    }
}
