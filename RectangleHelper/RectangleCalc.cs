namespace RectangleHelper
{
    public static class RectangleCalc
    {
        public static int RectanglePerimeterCalc(int nFirstSideLength, int nSecondSideLength)
        {
            int nPerimeter = (nFirstSideLength + nSecondSideLength) * 2;

            return nPerimeter;
        }

        public static int RectangleSquareCalc(int nFirstSideLength, int nSecondSideLength)
        {
            int nSquare = nFirstSideLength * nSecondSideLength;

            return nSquare;
        }
    }
}