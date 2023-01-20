using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.Geometrix.NoOcp.ShapeModel
{
    internal class Triangle
    {
        public double L1 { get; set; }
        public double L2 { get; set; }
        public double L3 { get; set; }
        
        private double GetSemiPerimeter()
        {
            return ( L1 + L2 + L3 )/2;
        }
        public double GetArea()
        {
            var semiPerimeter = GetSemiPerimeter();
            return Math.Sqrt(semiPerimeter*(semiPerimeter-L1)*(semiPerimeter-L2)*(semiPerimeter-L3));
        }
    }
}
