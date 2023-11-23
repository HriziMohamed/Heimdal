using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdal.Models
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Circle : radius {Radius} Area {Area()} Perimetre {Perimeter()}";
        }
    }
}