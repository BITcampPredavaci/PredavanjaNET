using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S03D04_Toolbox
{
    class Toolbox
    {
      public  static void HelloWorld()
        {
            Console.WriteLine("Hello World");
        }

      private static void Something()
      {
          Console.WriteLine("Private");
      }

        /// <summary>
        /// Adds 2 numbers
        /// </summary>
        /// <param name="a">first number to add</param>
        /// <param name="b">second number to add</param>
        /// <returns>the sum of a and b</returns>
      public static int Sum(int a, int b)
      {
          return a + b;
      }
    }
}
