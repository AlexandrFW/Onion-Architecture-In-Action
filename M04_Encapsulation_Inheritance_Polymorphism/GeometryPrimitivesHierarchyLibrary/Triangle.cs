using System;

namespace GeometryPrimitivesHierarchyLibrary
{
    public class Triangle : Shape
    {
        public double FirstSideLength { get; set; }
        public double SecondSideLength { get; set; }
        public double ThirdSideLength { get; set; }

        public Triangle(double FirstSideLength, double SecondSideLength, double ThirdSideLength)
        {
            if (FirstSideLength <= 0)
                throw new ArgumentException($"{nameof(FirstSideLength)} should not be less or equals Zero");

            if (SecondSideLength <= 0)
                throw new ArgumentException($"{nameof(SecondSideLength)} should not be less or equals Zero");

            if (ThirdSideLength <= 0)
                throw new ArgumentException($"{nameof(ThirdSideLength)} should not be less or equals Zero");

            this.FirstSideLength = FirstSideLength;
            this.SecondSideLength = SecondSideLength;
            this.ThirdSideLength = ThirdSideLength;
        }

        public override double CalcPerimeter()
        {
            return Math.Round(FirstSideLength + SecondSideLength + ThirdSideLength, 2);
        }

        public override double CalcArea()
        {
            double p = 0.5 * CalcPerimeter();
            return Math.Round(Math.Sqrt(p * (p - FirstSideLength) * (p - SecondSideLength) * (p - ThirdSideLength)), 2);
        }
    }
}