
using System;

namespace ChaosSoft.Core.Extensions
{
    public static class Matrix
    {
        /// <summary>
        /// Creates matrix with specific dimensions lengths.
        /// </summary>
        /// <param name="rows">rows count</param>
        /// <param name="columns">columns count</param>
        /// <param name="initialValue">initial value to fill with</param>
        /// <returns></returns>
        public static double[,] Create(int rows, int columns, double initialValue)
        {
            double[,] matrix = new double[rows, columns];

            if (initialValue != 0)
            {
                FillWith(matrix, initialValue);
            }

            return matrix;
        }

        /// <summary>
        /// Creates matrix with specific dimensions lengths.
        /// </summary>
        /// <param name="rows">rows count</param>
        /// <param name="columns">columns count</param>
        /// <param name="initialValue">initial value to fill with</param>
        /// <returns></returns>
        public static int[,] Create(int rows, int columns, int initialValue)
        {
            int[,] matrix = new int[rows, columns];

            if (initialValue != 0)
            {
                FillWith(matrix, initialValue);
            }

            return matrix;
        }

        /// <summary>
        /// Fills matrix with specific value.
        /// </summary>
        /// <param name="matrix">matrix to fill</param>
        /// <param name="value">value to fill with</param>
        public static void FillWith(double[,] matrix, double value)
        {
            int i, j;
            int xLen = matrix.GetLength(0);
            int yLen = matrix.GetLength(1);

            for (i = 0; i < xLen; i++)
            {
                for (j = 0; j < yLen; j++)
                {
                    matrix[i, j] = value;
                }
            }
        }

        /// <summary>
        /// Fills matrix with specific value.
        /// </summary>
        /// <param name="matrix">matrix to fill</param>
        /// <param name="value">value to fill with</param>
        public static void FillWith(int[,] matrix, int value)
        {
            int i, j;
            int xLen = matrix.GetLength(0);
            int yLen = matrix.GetLength(1);

            for (i = 0; i < xLen; i++)
            {
                for (j = 0; j < yLen; j++)
                {
                    matrix[i, j] = value;
                }
            }
        }

        /// <summary>
        /// Gets column at specific position from matrix.
        /// </summary>
        /// <param name="matrix">source matrix</param>
        /// <param name="index">column index</param>
        /// <returns>column as a vector</returns>
        public static double[] GetColumn(double[,] matrix, int index)
        {
            int length = matrix.GetLength(1);
            double[] row = new double[length];

            for (int i = 0; i < length; i++)
            {
                row[i] = matrix[index, i];
            }

            return row;
        }

        /// <summary>
        /// Gets column at specific position from matrix.
        /// </summary>
        /// <param name="matrix">source matrix</param>
        /// <param name="index">column index</param>
        /// <returns>column as a vector</returns>
        public static int[] GetColumn(int[,] matrix, int index)
        {
            int length = matrix.GetLength(1);
            int[] column = new int[length];

            for (int i = 0; i < length; i++)
            {
                column[i] = matrix[index, i];
            }

            return column;
        }

        /// <summary>
        /// Gets row at specific position from matrix.
        /// </summary>
        /// <param name="matrix">source matrix</param>
        /// <param name="index">row index</param>
        /// <returns>row as a vector</returns>
        public static double[] GetRow(double[,] matrix, int index)
        {
            int length = matrix.GetLength(0);
            double[] row = new double[length];

            for (int i = 0; i < length; i++)
            {
                row[i] = matrix[i, index];
            }

            return row;
        }

        /// <summary>
        /// Gets row at specific position from matrix.
        /// </summary>
        /// <param name="matrix">source matrix</param>
        /// <param name="index">row index</param>
        /// <returns>row as a vector</returns>
        public static int[] GetRow(int[,] matrix, int index)
        {
            int length = matrix.GetLength(0);
            int[] row = new int[length];

            for (int i = 0; i < length; i++)
            {
                row[i] = matrix[i, index];
            }

            return row;
        }

        /// <summary>
        /// Gets minimum value from matrix.
        /// </summary>
        /// <param name="vector">matrix</param>
        /// <returns>minimum value</returns>
        public static double Min(double[,] matrix)
        {
            double min = double.MaxValue;

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    min = Math.Min(min, matrix[x, y]);
                }
            }

            return min;
        }

        /// <summary>
        /// Gets minimum value from matrix.
        /// </summary>
        /// <param name="vector">matrix</param>
        /// <returns>minimum value</returns>
        public static int Min(int[,] matrix)
        {
            int min = int.MaxValue;

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    min = Math.Min(min, matrix[x, y]);
                }
            }

            return min;
        }

        /// <summary>
        /// Gets maximum value from matrix.
        /// </summary>
        /// <param name="vector">matrix</param>
        /// <returns>minimum value</returns>
        public static double Max(double[,] matrix)
        {
            double maxVal = double.MinValue;

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    maxVal = Math.Max(maxVal, matrix[x, y]);
                }
            }

            return maxVal;
        }

        /// <summary>
        /// Gets maximum value from matrix.
        /// </summary>
        /// <param name="vector">matrix</param>
        /// <returns>minimum value</returns>
        public static int Max(int[,] matrix)
        {
            int maxVal = int.MinValue;

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    maxVal = Math.Max(maxVal, matrix[x, y]);
                }
            }

            return maxVal;
        }

        /// <summary>
        /// Gets maximum absolute value from matrix.
        /// </summary>
        /// <param name="vector">matrix</param>
        /// <returns>maximum absolute value</returns>
        public static double MaxAbs(double[,] matrix)
        {
            double maxVal = double.MinValue;

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    maxVal = Math.Max(maxVal, Math.Abs(matrix[x, y]));
                }
            }

            return maxVal;
        }

        /// <summary>
        /// Gets maximum absolute value from matrix.
        /// </summary>
        /// <param name="vector">matrix</param>
        /// <returns>maximum absolute value</returns>
        public static int MaxAbs(int[,] matrix)
        {
            int maxVal = int.MinValue;

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    maxVal = Math.Max(maxVal, Math.Abs(matrix[x, y]));
                }
            }

            return maxVal;
        }
    }

}
