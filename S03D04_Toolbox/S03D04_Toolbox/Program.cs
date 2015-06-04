using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camp;

namespace S03D04_Toolbox
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = -1;
            int[] array = new int[3];
            ArrayHelper.SetElements(array, -1);
            int index = 0;
            do
            {
                Console.WriteLine("Unesi broj");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input == -1)
                    {
                        break;
                    }
                    ArrayHelper.AddToArray(ref array, index, input);
                    index++;
                    Console.WriteLine(int.MaxValue);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Not added, not a number");
                }
            } while (input != -1);

            ArrayHelper.PrintArray(array);

            //Toolbox.HelloWorld();
            //Toolbox.Sum(2, 3);
            //Remote.HelloWorld();
            //Console.WriteLine(
            //    CampMath.Pow(2, 0)
            //    );
        }
    }
}
