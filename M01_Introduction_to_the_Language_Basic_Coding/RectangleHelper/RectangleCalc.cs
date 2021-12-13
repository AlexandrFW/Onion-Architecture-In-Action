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
            ParametersValidation(nFirstSideLength, nSecondSideLength);

            return checked((nFirstSideLength + nSecondSideLength) * 2); 
        }

        /// <summary>
        /// Calculate a square of a rectangle
        /// </summary>
        /// <param name="nFirstSideLength">One side of a rectangle</param>
        /// <param name="nSecondSideLength">Second side of a rectangle</param>
        /// <returns>Calculated square of a rectangle</returns>
        public static int RectangleSquareCalc(int nFirstSideLength, int nSecondSideLength)
        {
            ParametersValidation(nFirstSideLength, nSecondSideLength);

            return checked(nFirstSideLength * nSecondSideLength);
        }

        private static void ParametersValidation(int nFirstSideLength, int nSecondSideLength)
        {
            // Validation if negative value given 
            if (nFirstSideLength < 0 || nSecondSideLength < 0)
                throw new ArgumentException("The first side or the second side of the given rectangle should not be negative");
        }
    }
}