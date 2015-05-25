using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02D01_Methods
{
    class Program
    {
        int someVar = 10;

        static int GetInput(string message)
        {
            int inputNumber;
            Console.WriteLine(message);
            inputNumber = Convert.ToInt32(Console.ReadLine());
            return inputNumber;
        }

        static void MultipleParams(int num,
            string message, int num2, int num3)
        {
            Console.WriteLine("num: " + num);
            Console.WriteLine("message: " + message);
            Console.WriteLine("num2: " + num2);
            Console.WriteLine("num3: " + num3);
        }

        static void WithReturn(int c)
        {
            if (c % 2 == 0)
                return;

            Console.WriteLine("Nije paran");
        }

        static double Sum(double num1, 
            double num2)
        {
            double sum = num1 + num2;
            if (num1 == 2)
            {
                Console.WriteLine("Prvi return");
                return (double)2;
            }
            Console.WriteLine("Onaj drugi return");
            return sum;
        }

       

        static void Main(string[] args)
        {
            /*int a = GetInput("Unesite vrijednost za a"),
                b = GetInput("Unesite vrijednost za b");
            Console.WriteLine("a+b = " + (a+b) );*/
            /*int fromMain = 0;
            int a = 10;
            ChangeA(a);
            Console.WriteLine("a: " + a);
            MultipleParams(10, "string", 3, 3); */

            Console.WriteLine("Sum: " + Sum(1, 2));
            double a = 2, b = 10;
            Console.WriteLine("Sum: " + Sum(a, b));
           // Console.WriteLine("Sum: " + Sum(a, 10));
        }
    }
}
