using System;

namespace GeometryPrimitivesHierarchyLibrary
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double nRadius)
        {
            if (nRadius <= 0)
                throw new ArgumentException("Radius should not be less or equals Zero");

            Radius = nRadius;
        }

        public override double CalcPerimeter()
        {
            return Math.Round(Math.PI * 2 *Radius, 2);    
        }

        public override double CalcArea()
        {
            return Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
        }
    }
}