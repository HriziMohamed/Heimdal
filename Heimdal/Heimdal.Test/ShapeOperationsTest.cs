using Heimdal.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Heimdal.Test
{
    public class ShapeOperationsTest
    {
        private readonly ShapeOperations shapeOperations;

        public ShapeOperationsTest()
        {
            shapeOperations = new ShapeOperations();
        }

        [Fact]
        public void TestMethod_GetShapes_0()
        {
            var shapes = shapeOperations.GetShapes(0);
            Assert.Equal(0, shapes.Count);
        }

        [Fact]
        public void TestMethod_GetShapes_5()
        {
            var shapes = shapeOperations.GetShapes(5);
            Assert.Equal(5, shapes.Count);
        }

        [Fact]
        public void TestMethod_GetShapes_Perimeter()
        {
            var shapes = shapeOperations.GetShapes(6);
            double perimeter = shapes.ElementAt(3).Perimeter();
            Assert.Equal(3, perimeter);
        }

        [Fact]
        public void TestMethod_GetSumOfCircles()
        {
            var shapes = new List<Shape>();
            shapes.Add(new Rectangle(1, 2));
            shapes.Add(new Circle(0.15915494309189535));// perimeter 1
            shapes.Add(new Circle(0.3183098861837907));// perimeter 2
            shapes.Add(new Rectangle(2, 3));
            shapes.Add(new Rectangle(3, 4));
            shapes.Add(new Circle(0.7957747154594768));// perimeter 5
            double sum = shapeOperations.GetSumOfCircles(shapes);
            Assert.Equal(8, sum);
        }
    }
}