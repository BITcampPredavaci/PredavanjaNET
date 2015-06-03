using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S03D03_Input
{
    class Program
    {

        static int ParseInt(string s)
        {
            int n = Convert.ToInt32(s);
            return n;
        }

        static bool TryParseInt(string s, out int n)
        {
            try
            {
                n = ParseInt(s);
                return true;
            }
            catch(Exception e)
            {
                n = -1;
                return false;
            }
        }

        static string GetInput()
        {
            return Console.ReadLine();
        }

        static int GetInputs()
        {
            while (true)
            {
                try
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    return n;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Unesi broj");
            int number  = 0;
            bool success = TryParseInt(
                Console.ReadLine(),
                out number);
            Console.WriteLine(number);

        }
    }
}
