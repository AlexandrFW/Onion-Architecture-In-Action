using System;
using System.Linq;

namespace DelegateLambdasAndEventsConsoleApp
{
    public static class MatrixSort
    {
        public static void Sort(int[,] matrix, bool isAsc, Func<int[], int[], bool, bool> compareMethod)
        {
            if (matrix == null)
                throw new ArgumentException($"The { nameof(matrix)} should not be null");

            if (compareMethod == null)
                throw new ArgumentException($"The { nameof(compareMethod)} delegate method should be provided. Now it is null");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int nNextRow = i + 1;
                if (nNextRow >= matrix.GetLength(0))
                    break;

                int[] row1 = GetMatrixRow(matrix, i, matrix.GetLength(1));
                int[] row2 = GetMatrixRow(matrix, nNextRow, matrix.GetLength(1));

                if (compareMethod(row1, row2, isAsc))
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = row2[j];
                        matrix[nNextRow, j] = row1[j];
                    }
                    i = -1;
                }
            }
        }

        private static int[] GetMatrixRow(int[,] matrix, int nRowNumber, int nColumnsAmount)
        {
            int[] matrixRow = new int[nColumnsAmount];
            for (int i = 0; i < nColumnsAmount; i++)
                matrixRow[i] = matrix[nRowNumber, i];

            return matrixRow;
        }

        private static void CheckArgumentsByNull(int[] row1, int[] row2)
        {
            if (row1 == null)
                throw new ArgumentException($"{nameof(row1)} should not be null");

            if (row2 == null)
                throw new ArgumentException($"{nameof(row1)} should not be null");

            if (row1.Length <= 0)
                throw new ArgumentException($"{nameof(row1)} array should not be empty");

            if (row2.Length <= 0)
                throw new ArgumentException($"{nameof(row2)} array should not be empty");
        }

        /// <summary>
        /// Compare current and next rows of two-dimensional array by sum of elements
        /// </summary>
        /// <param name="row1">Current row (one-dimensional array)</param>
        /// <param name="row2">Next row (one-dimensional array)</param>
        /// <returns>Boolean representation of comparison action</returns>
        public static bool CompareByRowSum(int[] row1, int[] row2, bool isAsc)
        {
            CheckArgumentsByNull(row1, row2);

            if (isAsc)
                return row1.Sum() > row2.Sum();
            else
                return row1.Sum() < row2.Sum();
        }

        /// <summary>
        /// Compare current and next rows of two-dimensional array by min of elements
        /// </summary>
        /// </summary>
        /// <param name="row1">Current row (one-dimensional array)</param>
        /// <param name="row2">Next row (one-dimensional array)</param>
        /// <returns>Boolean representation of comparison action</returns>
        public static bool CompareByRowMin(int[] row1, int[] row2, bool isAsc)
        {
            CheckArgumentsByNull(row1, row2);

            if (isAsc)
                return row1.Min() > row2.Min();
            else
                return row1.Min() < row2.Min();
        }

        /// <summary>
        /// Compare current and next rows of two-dimensional array by max of elements
        /// </summary>
        /// </summary>
        /// <param name="row1">Current row (one-dimensional array)</param>
        /// <param name="row2">Next row (one-dimensional array)</param>
        /// <returns>Boolean representation of comparison action</returns>
        public static bool CompareByRowMax(int[] row1, int[] row2, bool isAsc)
        {
            CheckArgumentsByNull(row1, row2);

            if (isAsc)
                return row1.Max() > row2.Max();
            else
                return row1.Max() < row2.Max();
        }
    }
}