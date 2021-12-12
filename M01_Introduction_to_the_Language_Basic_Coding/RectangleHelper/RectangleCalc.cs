using System;

namespace RectangleHelper
{
    public static class RectangleCalc
    {
        /// <summary>
        /// Calculate a perimeter of a rectangle
        /// </summary>
        /// <param name="nFirstSideLength">One side of a rectangle</param>
        /// <param name="nSecondSideLength">Second side of a rectangle</param>
        /// <returns>Calculated perimeter of a rectangle</returns>
        public static int RectanglePerimeterCalc(int nFirstSideLength, int nSecondSideLength)
        {
            ValidationParameters(nFirstSideLength, nSecondSideLength);

            return (nFirstSideLength + nSecondSideLength) * 2; 
        }

        /// <summary>
        /// Calculate a square of a rectangle
        /// </summary>
        /// <param name="nFirstSideLength">One side of a rectangle</param>
        /// <param name="nSecondSideLength">Second side of a rectangle</param>
        /// <returns>Calculated square of a rectangle</returns>
        public static int RectangleSquareCalc(int nFirstSideLength, int nSecondSideLength)
        {
            ValidationParameters(nFirstSideLength, nSecondSideLength);

            return nFirstSideLength * nSecondSideLength;
        }

        private static void ValidationParameters(int nFirstSideLength, int nSecondSideLength)
        {
            // Validation if negative value given 
            if (nFirstSideLength < 0 || nSecondSideLength < 0)
                throw new ArgumentException("The first side or the second side of the given rectangle should not be negative");

            // Validation if Int32.MaxValue values given
            if (nFirstSideLength == Int32.MaxValue || nSecondSideLength == Int32.MaxValue)
                throw new ArithmeticException("The first side or the second side of the given rectangle should not be Int32.MaxValue due to arithmetic overlow");
        }
    }
}