using System;

namespace GeometryPrimitivesHierarchyLibrary
{
    public class Cycle : Shape
    {
        public double Radius { get; set; }

        public Cycle(double nRadius)
        {
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