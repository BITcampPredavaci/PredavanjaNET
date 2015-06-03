using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S03D03_TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                int n = Convert.ToInt32(Console.ReadLine());
                int result = 5 / n;
                Console.WriteLine(result);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Not a number");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                
                Console.WriteLine("Finally");
            }

        }
    }
}
