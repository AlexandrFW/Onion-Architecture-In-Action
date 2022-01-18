using System;

namespace GeometryPrimitivesHierarchyLibrary
{
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double Length, double Width) 
        {
            this.Length = Length;
            this.Width = Width;
        }

        public override double CalcPerimeter()
        {
            return Math.Round(2 * (Length + Width), 2);
        }

        public override double CalcArea()
        {
            return Length * Width;
        }
    }
}