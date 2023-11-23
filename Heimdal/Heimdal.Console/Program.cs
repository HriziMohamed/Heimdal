using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection.Metadata;
using Heimdal.Models;

namespace Heimdal.Console
{
    internal class Program
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

        private static void Main(string[] args)
        {
            var shapes = GetShapes(5);
            //List<Shape> shapes2 = new List<Shape>();
            //shapes2.Add(new Circle(0));
            //shapes2.Add(new Circle(0.15915494309189535));
            //shapes2.Add(new Rectangle(0.6666666666666667, 0.33333333333333326));
            //shapes2.Add(new Rectangle(1.3333333333333335, 0.6666666666666665));
            //shapes2.Add(new Circle(0.6366197723675814));
            //foreach (Shape shape in shapes2)
            //{
            //    Console.WriteLine(shape.ToString());
            //}
            GetSumOfCircles(shapes.ToList());
            var result = GetClockAngle(12, 60);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static double GetSumOfCircles(List<Shape> shapes)
        {
            double sum = 0;
            SemaphoreSlim semaphore = new SemaphoreSlim(2);

            // Use Parallel.ForEach to calculate the sum in parallel
            Parallel.ForEach(shapes, (shape) =>
            {
                if (shape is Circle circle)
                {
                    semaphore.Wait(); // Wait until a thread can enter the critical section
                    try
                    {
                        sum += circle.Perimeter();
                    }
                    finally
                    {
                        semaphore.Release(); // Release the semaphore to allow other threads to enter the critical section
                    }
                }
            });

            Console.WriteLine(sum);
            return sum;
        }

        private static ICollection<Shape> GetShapes(int n)
        {
            List<Shape> shapes = new List<Shape>();
            double perimeter = 0;
            double radius = 0;
            double side1, side2 = 0;
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
                    // For rectangles, create a random length and width
                    side1 = (perimeter / 2) - (perimeter / 6);
                    side2 = (perimeter / 2) - side1;
                    shape = new Rectangle(side1, side2);
                }
                Console.WriteLine(shape.ToString());
                shapes.Insert(i, shape);
            }

            return shapes;
        }

        private static double GetClockAngle(int hour, int minute)
        {
            // ∆θ = |5(6H - 11/10M)|
            // hour => H
            // minute => M
            // return Math.Abs(5 * ((6 * hour) - (1.1 * minute)));

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
            return angle;
        }

        //static double GetClockAngle(int h, int m)
        //{
        //    // validate the input
        //    if (h < 0 || m < 0 || h > 12 || m > 60)
        //        Console.WriteLine("Wrong input");

        //    if (h == 12) h = 0;
        //    if (m == 60)
        //    {
        //        m = 0;
        //        h += 1;
        //        if (h > 12)
        //            h = h - 12;
        //    }

        //    // Calculate the angles moved
        //    // by hour and minute hands
        //    // with reference to 12:00
        //    double hour_angle = 0.5 * (h * 60 + m);
        //    double minute_angle = 6 * m;

        //    // Find the difference between two angles
        //    double angle = Math.Abs(hour_angle - minute_angle);

        //    // Return the smaller angle of two possible angles
        //    angle = Math.Min(360 - angle, angle);

        //    return angle;
        //}
    }
}