using System;

namespace ChaosSoft.Core.Extensions
{
    /// <summary>
    /// Common operations on vectors.
    /// </summary>
    public static class Vector
    {
        /// <summary>
        /// Creates uniform vector starting from some value with specific step.
        /// </summary>
        /// <param name="length">vector length</param>
        /// <param name="start">value start from</param>
        /// <param name="step">value increment</param>
        /// <returns>uniform vector</returns>
        public static double[] CreateUniform(int length, double start, double step)
        {
            double[] array = new double[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = start + step * i;
            }

            return array;
        }

        /// <summary>
        /// Creates uniform vector starting from some value with specific step.
        /// </summary>
        /// <param name="length">vector length</param>
        /// <param name="start">value start from</param>
        /// <param name="step">value increment</param>
        /// <returns>uniform vector</returns>
        public static int[] CreateUniform(int length, int start, int step)
        {
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = start + step * i;
            }

            return array;
        }

        /// <summary>
        /// Fills vector with scpecific value.
        /// </summary>
        /// <param name="vector">vector to fill</param>
        /// <param name="value">value to fill with</param>
        public static void FillWith(double[] vector, double value)
        {
            int i;
            int len = vector.Length;

            for (i = 0; i < len; i++)
            {
                vector[i] = value;
            }
        }

        /// <summary>
        /// Fills vector with scpecific value.
        /// </summary>
        /// <param name="vector">vector to fill</param>
        /// <param name="value">value to fill with</param>
        public static void FillWith(int[] vector, int value)
        {
            int i;
            int len = vector.Length;

            for (i = 0; i < len; i++)
            {
                vector[i] = value;
            }
        }

        /// <summary>
        /// Gets minimum value from vector.
        /// </summary>
        /// <param name="vector">array</param>
        /// <returns>minimum value</returns>
        public static double Min(double[] vector)
        {
            double minVal = double.MaxValue;

            foreach (double val in vector)
            {
                if (val < minVal)
                {
                    minVal = val;
                }
            }

            return minVal;
        }

        /// <summary>
        /// Gets minimum value from vector.
        /// </summary>
        /// <param name="vector">array</param>
        /// <returns>minimum value</returns>
        public static int Min(int[] vector)
        {
            int minVal = int.MaxValue;

            foreach (int val in vector)
            {
                if (val < minVal)
                {
                    minVal = val;
                }
            }

            return minVal;
        }

        /// <summary>
        /// Gets maximum value from vector.
        /// </summary>
        /// <param name="vector">array</param>
        /// <returns>maximum value</returns>
        public static double Max(double[] vector)
        {
            double maxVal = double.MinValue;

            foreach (double val in vector)
            {
                if (val > maxVal)
                {
                    maxVal = val;
                }
            }

            return maxVal;
        }

        /// <summary>
        /// Gets maximum value from vector.
        /// </summary>
        /// <param name="vector">array</param>
        /// <returns>maximum value</returns>
        public static int Max(int[] vector)
        {
            int maxVal = int.MinValue;

            foreach (int val in vector)
            {
                if (val > maxVal)
                {
                    maxVal = val;
                }
            }

            return maxVal;
        }

        /// <summary>
        /// Gets maximum absolute value from vecor.
        /// </summary>
        /// <param name="vector">array</param>
        /// <returns>maximum absolute value</returns>
        public static double MaxAbs(double[] vector)
        {
            double maxVal = double.MinValue;

            foreach (double val in vector)
            {
                maxVal = Math.Max(maxVal, Math.Abs(val));
            }

            return maxVal;
        }

        /// <summary>
        /// Gets maximum absolute value from vecor.
        /// </summary>
        /// <param name="vector">array</param>
        /// <returns>maximum absolute value</returns>
        public static int MaxAbs(int[] vector)
        {
            int maxVal = int.MinValue;

            foreach (int val in vector)
            {
                maxVal = Math.Max(maxVal, Math.Abs(val));
            }

            return maxVal;
        }

        /// <summary>
        /// Shifts vector until it's min == 0 and rescales it by it's interval.
        /// </summary>
        /// <param name="vector">vector to rescale</param>
        /// <returns>original vector interval</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double Rescale(double[] vector)
        {
            var max = Max(vector);
            var min = Min(vector);
            var interval = max - min;

            if (interval == 0d)
            {
                throw new ArgumentException("Data amplitude is zero, it makes no sense to continue.");
            }

            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = (vector[i] - min) / interval;
            }

            return interval;
        }
    }

}
