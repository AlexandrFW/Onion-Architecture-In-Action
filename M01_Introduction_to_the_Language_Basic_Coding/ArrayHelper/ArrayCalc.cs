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

            // Go through all of elements
            foreach (int i in arrTwoDimensionalArray)
            {
                // Sum of all positive elements
                if (i > 0)
                {
                    nSum += i;
                }
            }

            return nSum;
        }
    }
}