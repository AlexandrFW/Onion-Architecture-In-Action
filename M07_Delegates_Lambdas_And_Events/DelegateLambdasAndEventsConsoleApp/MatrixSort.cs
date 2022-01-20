using System;

namespace DelegateLambdasAndEventsConsoleApp
{
    public static class MatrixSort
    {
        public static void Sort(int[,] matrix, bool IsAsc, Func<int[], int[], int, bool, bool> compareMethod)
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

                if (compareMethod(row1, row2, matrix.GetLength(1), IsAsc))
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = row2[j];
                        matrix[nNextRow, j] = row1[j];
                    }
                    i = 0;
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

        private static bool CheckArgumentsByNull(int[] row1, int[] row2, int nRowLength)
        {
            if (row1 == null)
                throw new ArgumentException($"{nameof(row1)} should not be null");

            if (row2 == null)
                throw new ArgumentException($"{nameof(row1)} should not be null");

            if (row1.Length <= 0)
                throw new ArgumentException($"{nameof(row1)} array should not be empty");

            if (row2.Length <= 0)
                throw new ArgumentException($"{nameof(row2)} array should not be empty");

            if (nRowLength <= 0)
                throw new ArgumentException($"{nameof(nRowLength)} array length must be greater than zero");

            return true;
        }

        /// <summary>
        /// Compare current and next rows of two-dimensional array by sum of elements
        /// </summary>
        /// <param name="row1">Current row (one-dimensional array)</param>
        /// <param name="row2">Next row (one-dimensional array)</param>
        /// <param name="nRowLength">Length of rows</param>
        /// <returns>Boolean representation of comparison action</returns>
        public static bool CompareByRowSum(int[] row1, int[] row2, int nRowLength, bool IsAsc)
        {
            CheckArgumentsByNull(row1, row2, nRowLength);

            if (IsAsc)
                return Sum(row1, nRowLength) < Sum(row2, nRowLength); 
            else
                return Sum(row1, nRowLength) > Sum(row2, nRowLength);
        }

        /// <summary>
        /// Compare current and next rows of two-dimensional array by min of elements
        /// </summary>
        /// </summary>
        /// <param name="row1">Current row (one-dimensional array)</param>
        /// <param name="row2">Next row (one-dimensional array)</param>
        /// <param name="nRowLength">Length of rows</param>
        /// <returns>Boolean representation of comparison action</returns>
        public static bool CompareByRowMin(int[] row1, int[] row2, int nRowLength, bool IsAsc)
        {
            CheckArgumentsByNull(row1, row2, nRowLength);

            if (IsAsc)
                return Min(row1, nRowLength) < Min(row2, nRowLength);
            else
                return Min(row1, nRowLength) > Min(row2, nRowLength);
        }

        /// <summary>
        /// Compare current and next rows of two-dimensional array by max of elements
        /// </summary>
        /// </summary>
        /// <param name="row1">Current row (one-dimensional array)</param>
        /// <param name="row2">Next row (one-dimensional array)</param>
        /// <param name="nRowLength">Length of rows</param>
        /// <returns>Boolean representation of comparison action</returns>
        public static bool CompareByRowMax(int[] row1, int[] row2, int nRowLength, bool IsAsc)
        {
            CheckArgumentsByNull(row1, row2, nRowLength);

            if (IsAsc)
                return Max(row1, nRowLength) < Max(row2, nRowLength);
            else
                return Max(row1, nRowLength) > Max(row2, nRowLength);
        }

        private static int Sum(int[] row, int nRowLength)
        {
            int n = 0;
            for (nRowLength--; nRowLength >= 0; nRowLength--) n += row[nRowLength];

            return n;
        }

        private static int Min(int[] row, int nRowLength)
        {
            int minm = row[nRowLength - 1];
            for (nRowLength--; nRowLength >= 0; nRowLength--)
            {
                if (row[nRowLength] < minm)
                {
                    minm = row[nRowLength];
                }
            }

            return minm;
        }

        private static int Max(int[] row, int nRowLength)
        {
            int minm = row[nRowLength - 1];
            for (nRowLength--; nRowLength >= 0; nRowLength--)
            {
                if (row[nRowLength] > minm)
                {
                    minm = row[nRowLength];
                }
            }

            return minm;
        }
    }
}