using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection.Metadata;
using Heimdal.Models;

namespace Heimdal.Main
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ShapeOperations shapeOperations = new ShapeOperations();
            var shapes = shapeOperations.GetShapes(5);
            shapeOperations.GetSumOfCircles(shapes);
            Console.WriteLine("**********************");
            shapes = shapeOperations.GetShapes(50);
            shapeOperations.GetSumOfCircles(shapes);
            Console.WriteLine("**********************");
            shapes = shapeOperations.GetShapes(-1);
            shapeOperations.GetSumOfCircles(shapes);
            Console.WriteLine("**********************");
            var result = shapeOperations.GetClockAngle(12, 60);
            Console.WriteLine("**********************");
            result = shapeOperations.GetClockAngle(3, 0);
            Console.ReadLine();
        }
    }
}