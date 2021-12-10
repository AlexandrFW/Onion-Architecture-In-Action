using System;
using System.Diagnostics;

namespace ArrayHelper
{
    public static class ArrayCalc
    {
        /// <summary>
        /// Calculate sum of all positive elemets of two dimensional array
        /// </summary>
        /// <param name="arrTwoDimensionalArray">Two-dimetional array which positive elements should be sum</param>
        /// <returns>Sum of all positive elements </returns>
        public static int SumAllPositiveElementsOfTwoDimensionalArray(int[,] arrTwoDimensionalArray)
        {
            if (arrTwoDimensionalArray is null)
                return -1;

            int nSum = 0;
            int nRank = arrTwoDimensionalArray.Rank;

            // Two-dimentional array only
            if (nRank == 2)
            {
                // Specify sizes of each dimentions
                int nSize1 = arrTwoDimensionalArray.GetUpperBound(0) + 1;
                int nSize2 = arrTwoDimensionalArray.Length / nSize1;

                // Go through all of elements
                for (int i = 0; i < nSize1; i++)
                    for (int j = 0; j < nSize2; j++)
                    {
                        // Sum of all positive elements
                        if (arrTwoDimensionalArray[i, j] > 0)
                        {
                            nSum += arrTwoDimensionalArray[i, j];
                        }
                    }

                return nSum;
            }
            else
            {
                return -1;
            }            
        }
    }
}