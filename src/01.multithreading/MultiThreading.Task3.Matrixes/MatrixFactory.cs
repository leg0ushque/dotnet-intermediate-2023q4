using System;
using MultiThreading.Task3.MatrixMultiplier.Matrices;

namespace MultiThreading.Task3.MatrixMultiplier
{
    public static class MatrixFactory
    {
        public static IMatrix CreateMatrixOfRandoms(int rowCount, int colCount, int minValue, int maxValue)
        {
            Random rand = new Random();
            IMatrix matrix = new Matrix(rowCount, colCount);
            for (long i = 0; i < rowCount; i++)
            {
                for (byte j = 0; j < colCount; j++)
                {
                    matrix.SetElement(i, j, rand.Next(minValue, maxValue));
                }
            }
            return matrix;
        }
    }
}
