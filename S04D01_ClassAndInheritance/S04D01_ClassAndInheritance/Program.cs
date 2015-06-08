using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker;

namespace S04D01_ClassAndInheritance
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Circle c = new Circle(1.5);
            Console.WriteLine(c.ToString());
            Circle c2 = c;
            Console.WriteLine("C2: " + c2.ToString());

            c2.Radius = 30;
            Console.WriteLine(c.ToString());
            Console.WriteLine("C2: " + c2.ToString());
            
            int a = 3;
            int b = a;

            Circle[] array = new Circle[5];
            Console.WriteLine(array[0]);
            array[0] = new Circle(2);
            Console.WriteLine(array[0]);
            Console.WriteLine(array); 


            Square sq = new Square(2);
            Rectangle rect = new Rectangle(3, 4);

            
            Console.WriteLine("Sq: " + sq);
            Console.WriteLine("Rect: " + rect); */

            SalaryWorker sw = new SalaryWorker("Worker1", "Surname1", 1200);
            Console.WriteLine(sw);
            HourlyWorker hw = new HourlyWorker("Worker2", "Surname2", 15, 30);
            Console.WriteLine(hw);
            SalaryWorker swCopy = new SalaryWorker(sw);
            Console.WriteLine(swCopy);
        }
    }
}
