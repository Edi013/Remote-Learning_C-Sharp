using System;

namespace iQuest.Geometrix.WithOcp.ShapeModel
{
    internal class Triangle : IShape
    {
        public double L1 { get; set; }
        public double L2 { get; set; }
        public double L3 { get; set; }


        public double CalculateArea()
        {
            return GetArea();
        }
        private double GetSemiPerimeter()
        {
            return (L1 + L2 + L3) / 2;
        }
        private double GetArea()
        {
            var semiPerimeter = GetSemiPerimeter();
            return Math.Sqrt(semiPerimeter * (semiPerimeter - L1) * (semiPerimeter - L2) * (semiPerimeter - L3));
        }
    }
}