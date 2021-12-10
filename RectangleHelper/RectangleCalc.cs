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
            int nPerimeter = (nFirstSideLength + nSecondSideLength) * 2;

            return nPerimeter;
        }

        /// <summary>
        /// Calculate a square of a rectangle
        /// </summary>
        /// <param name="nFirstSideLength">One side of a rectangle</param>
        /// <param name="nSecondSideLength">Second side of a rectangle</param>
        /// <returns>Calculated square of a rectangle</returns>
        public static int RectangleSquareCalc(int nFirstSideLength, int nSecondSideLength)
        {
            int nSquare = nFirstSideLength * nSecondSideLength;

            return nSquare;
        }
    }
}