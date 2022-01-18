using System;

namespace GeometryPrimitivesHierarchyLibrary
{
    public class Square : Shape
    {
        public double SideLength { get; set; }

        public Square(double SideLength)
        {
            this.SideLength = SideLength;
        }

        public override double CalcArea()
        {
            return Math.Round(Math.Pow(SideLength, 2));
        }

        public override double CalcPerimeter()
        {
            return Math.Round(SideLength * 4, 2);
        }
    }
}