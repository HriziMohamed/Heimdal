using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Heimdal.Models
{
    public class ShapeOperations
    {
        private static Random _random;

        private static Random Random
        {
            get
            {
                if (_random == null)
                    _random = new Random();

                return _random;
            }
        }

        public double GetSumOfCircles(ICollection<Shape> shapes)
        {
            double sum = 0;
            SemaphoreSlim semaphore = new SemaphoreSlim(2);
            object sumLock = new object();
            if (shapes == null)
            {
                Console.WriteLine("The collection must be not null");
                return sum;
            }
            Parallel.ForEach(shapes, (shape) =>
            {
                if (shape is Circle circle)
                {
                    semaphore.Wait();
                    try
                    {
                        lock (sumLock)
                        {
                            sum = sum + shape.Perimeter();
                        }
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }
            });
            Console.WriteLine($"The sum of the list is {sum}");
            return sum;
        }

        public ICollection<Shape> GetShapes(int n)
        {
            List<Shape> shapes = new List<Shape>();
            double perimeter = 0;
            double radius = 0;
            double side1, side2 = 0;
            if (n < 0)
            {
                Console.WriteLine("The size of collection must be positive");
                return null;
            }
            for (int i = 0; i < n; i++)
            {
                bool isCircle = Random.Next(2) == 0;
                Shape shape;
                perimeter = i;

                if (isCircle)
                {
                    radius = perimeter / (2 * Math.PI);
                    shape = new Circle(radius);
                }
                else
                {
                    side1 = (perimeter / 2) - (perimeter / 6);
                    side2 = (perimeter / 2) - side1;
                    shape = new Rectangle(side1, side2);
                }
                Console.WriteLine(shape.ToString());
                shapes.Insert(i, shape);
            }

            return shapes;
        }

        public double GetClockAngle(int hour, int minute)
        {
            // validate the input
            if (hour < 0 || minute < 0 || minute > 60)
                Console.WriteLine("Wrong input");

            if (hour > 12)
                hour = hour - 12;

            if (hour == 12) hour = 0;
            if (minute == 60)
            {
                minute = 0;
                hour += 1;
                if (hour > 12)
                    hour = hour - 12;
            }

            var angle = Math.Abs(hour * 30 - minute * 6);
            if (angle > 180)
            {
                angle = 360 - angle;
            }
            Console.WriteLine($"The angle between the hour {hour} and the minute {minute} is {angle}");
            return angle;
        }
    }
}