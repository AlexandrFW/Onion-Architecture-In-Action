using System;

namespace GeometryPrimitivesHierarchyLibrary
{
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double Length, double Width) 
        {
            if (Length <= 0)
                throw new ArgumentException($"{nameof(Length)} should not be less or equals Zero");

            if (Width <= 0)
                throw new ArgumentException($"{nameof(Width)} should not be less or equals Zero");

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