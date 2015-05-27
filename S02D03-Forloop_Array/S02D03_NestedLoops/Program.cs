using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02D03_NestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = Convert.ToInt32(Console.ReadLine());
            int height = Convert.ToInt32(Console.ReadLine());

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < num; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }


        }
    }
}
