using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdal.Models
{
    public class Rectangle : Shape
    {
        public Rectangle(double side1, double side2)
        {
            Side1 = side1;
            Side2 = side2;
        }

        public double Side1 { get; }
        public double Side2 { get; }

        public override double Area()
        {
            return Side1 * Side2;
        }

        public override double Perimeter()
        {
            return 2 * (Side1 + Side2);
        }

        public override string ToString()
        {
            return $"Rectangle : side1 {Side1} side2 {Side2} Area {Area()} Perimetre {Perimeter()}";
        }
    }
}