using Heimdal.Models;
using System;
using Xunit;

namespace Heimdal.Test
{
    public class GetClockAngleTest
    {
        private readonly ShapeOperations shapeOperations;

        public GetClockAngleTest()
        {
            shapeOperations = new ShapeOperations();
        }

        [Fact]
        public void TestMethod_0_0_PM()
        {
            double angle = shapeOperations.GetClockAngle(0, 0);
            Assert.Equal(0, angle);
        }

        [Fact]
        public void TestMethod_12_30_PM()
        {
            double angle = shapeOperations.GetClockAngle(12, 30);
            Assert.Equal(180, angle);
        }

        [Fact]
        public void TestMethod_3_00_PM()
        {
            double angle = shapeOperations.GetClockAngle(3, 0);
            Assert.Equal(90, angle);
        }
    }
}