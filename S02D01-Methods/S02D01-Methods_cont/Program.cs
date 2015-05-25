using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02D01_Methods_cont
{
    class Program
    {
        static int Max(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else 
            {
                return b;
            }
            
        }
        static void Main(string[] args)
        {
            int globalVar = 20;
            int a = 10, b = 6;
            int min = Max(a, b);
            string s = "hello";
            
            Console.WriteLine("Max je " + min);
            Console.WriteLine("Max je " + Max(a, b));
        }
    }
}
