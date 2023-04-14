using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.Class_Calculate
{
    public class CalculateYState
    {
        public static Complex[,] CalculateMatrixYState(int N)
        {
            Random rd = new Random();
            // Tạo ma trận Admittance
            Complex[,] Y_State = new Complex[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Y_State[i, j] = new Complex(rd.NextDouble(), rd.NextDouble());
                }
            }

            return Y_State;
        }
    }
}
