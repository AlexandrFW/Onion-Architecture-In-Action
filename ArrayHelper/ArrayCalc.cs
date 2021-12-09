using System;

namespace ArrayHelper
{
    public static class ArrayCalc
    {
        /// <summary>
        /// Calculate sum of all positive elemets of two dimensional array
        /// </summary>
        /// <param name="arrTwoDimensialArray">Two-dimetional array which positive elements should be sum</param>
        /// <returns>Sum of all positive elements </returns>
        public static int SumAllPositiveElementsOfTwoDimensialArray(int[,] arrTwoDimensialArray)
        {
            int nSum = 0;
            int nSize1 = 0;
            int nSize2 = 0;
            int nRank = arrTwoDimensialArray.Rank;

            // Two-dimentional array only
            if (nRank == 2)
            {
                // Try specify sizes of each dimentions
                for (int dimension = 1; dimension <= nRank; dimension++)
                    switch (dimension)
                    {
                        case 1:
                            nSize1 = arrTwoDimensialArray.GetUpperBound(dimension - 1) + 1;
                            break;

                        case 2:
                            nSize2 = arrTwoDimensialArray.GetUpperBound(dimension - 1) + 1;
                            break;

                        default:
                            break;
                    }

                // Go through all of elements
                for (int i = 0; i < nSize1; i++)
                    for (int j = 0; j < nSize2; j++)
                    {
                        // Sum of all positive elements
                        if (arrTwoDimensialArray[i, j] > 0)
                            nSum += arrTwoDimensialArray[i, j];
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