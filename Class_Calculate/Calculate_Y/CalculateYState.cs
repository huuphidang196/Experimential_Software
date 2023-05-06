using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Calculate.CalculateCurve;

namespace Experimential_Software.Class_Calculate.Calculate_Y
{
    public class CalculateYState
    {
        protected CalPointCurveStepOne _curveStepOne;

        protected DTODataInputPowerSystem _dataInputPower;

        public CalculateYState(CalPointCurveStepOne CalPointCurveStepOne)
        {
            this._curveStepOne = CalPointCurveStepOne;
            this._dataInputPower = CalPointCurveStepOne.DataInputPS;
        }

        public virtual Complex[,] CalculateMatrixYState(int N)
        {

            Random rd = new Random();
            // Tạo ma trận Admittance
            Complex[,] Y_State = new Complex[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (Y_State[i, j] != 0) continue;

                    Y_State[i, j] = 12 * new Complex(rd.NextDouble(), rd.NextDouble());
                    Y_State[j, i] = Y_State[i, j];
                }
            }

            return Y_State;
        }
    }
}









/*
 * Complex[,] Y_State = new Complex[9, 9] {
    { new Complex(18.5571, -55.6746), new Complex(-6.5692, 19.8718), new Complex(-12.9879, 35.8026), new Complex(-6.8966, 20.6897), Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero },
    { new Complex(-6.5692, 19.8718), new Complex(10.1844, -31.3064), new Complex(-3.6152, 10.9890), new Complex(-0.9999, 3.0000),
                    new Complex(-0.9999, 3.0000), Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero },
    { new Complex(-12.9879, 35.8026), new Complex(-3.6152, 10.9890), new Complex(16.6028, -46.5139), new Complex(-0.9999, 3.0000), Complex.Zero, new Complex(-0.9999, 3.0000), Complex.Zero, Complex.Zero, Complex.Zero },
    { new Complex(-6.8966, 20.6897), new Complex(-0.9999, 3.0000), new Complex(-0.9999, 3.0000), new Complex(8.6297, -23.2929),
                    new Complex(-0.9999, 3.0000), Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero },
    { Complex.Zero, new Complex(-0.9999, 3.0000), Complex.Zero, new Complex(-0.9999, 3.0000), new Complex(4.9999, -14.9987),
                    new Complex(-0.9999, 3.0000), Complex.Zero, Complex.Zero, Complex.Zero },
    { Complex.Zero, Complex.Zero, new Complex(-0.9999, 3.0000), Complex.Zero, new Complex(-0.9999, 3.0000), new Complex(5.9999, -17.9975),
                    new Complex(-0.9999, 3.0000), Complex.Zero, Complex.Zero },
    { Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, new Complex(9.9999, -30.0000),
                    new Complex(-3.0000, 9.0000),new  Complex(-6.9999, 21.0000) },
    { Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, new Complex(-3.0000, 9.0000),
                    new Complex(6.9999, -21.0000), new Complex(-3.9999, 12.0000) },
    { Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, new Complex(-6.9999, 21.0000),
                    new Complex(-3.9999, 12.0000), new Complex(10.9998, -33.0000) }};
 */