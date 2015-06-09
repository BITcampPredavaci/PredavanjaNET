using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D02_StructsClassesInheritance
{
    class Program
    {

        static void GeneratePoints(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(i, i);
            }
        }

        static void PrintPoints(Point[] points)
        {
            foreach (Point p in points)
            {
                Console.WriteLine(p);
            }
        }

        static void PrintDistanceFromFirst(Point[] points)
        {
            for (int i = 1; i < points.Length; i++)
            {
                Console.WriteLine("Distance from "
                    + points[0] + " to " + points[i] + ": "
                    + points[0].Distance(points[i]));
            }
        }

        static void Main(string[] args)
        {
            Point[] points = new Point[5];

            GeneratePoints(points);
            PrintPoints(points);
            PrintDistanceFromFirst(points);

            DynamicArray array = new DynamicArray();

            for (int i = 0; i < 10; i++)
            {
                array.AddElement(i);
            }
            array.RemoveElement(1);
            Console.WriteLine(array);
        }
    }
}
