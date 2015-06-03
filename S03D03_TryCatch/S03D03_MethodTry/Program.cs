using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S03D03_MethodTry
{
    class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="DivideByZero">
        /// If b is 0
        /// </exception>
        static int Divide(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        static void Main(string[] args)
        {
            int a = 3, b = 0;
            
            try
            {
                Console.WriteLine(Divide(a, b));

            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}
