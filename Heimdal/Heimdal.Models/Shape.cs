using System;
using System.Collections.Generic;
using System.Text;

namespace Heimdal.Models
{
    public abstract class Shape
    {
        public Location C { get; set; }

        public abstract new string ToString();

        public abstract double Area();

        public abstract double Perimeter();
    }
}