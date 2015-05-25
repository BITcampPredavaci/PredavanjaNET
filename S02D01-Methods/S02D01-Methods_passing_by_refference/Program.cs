using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02D01_Methods_passing_by_refference
{
    class Program
    {

        static int GetInput()
        {
            Console.WriteLine("Enter a number: ");
            int inputNum = Convert.ToInt32(Console.ReadLine());
            return inputNum;
        }

        static bool GetMax()
        {
            int num1 = GetInput(),
                num2 = GetInput();

            if (num1 > num2)
            {
                Console.WriteLine("Max: " + num1);
                return true;
            }
            else if (num2 > num1)
            {
                Console.WriteLine("Max: " + num2);
                return true;
            }
            else
            {
                return false;
            }
        }


        static void ChangeNumber(int num)
        {
            num = num * 2;
            Console.WriteLine("Num in method: " + num);
        }

        static void ChangeNumberByRefference(
            ref int num, int num2 )
        {
            num = num * 2;
            Console.WriteLine("Num in method: " + num);
        }

        static void Square(int a,
                            ref int b)
        {
            //a = a * a;
            a *= a;
            //b = b *b ;
            b *= b;
        }


        static void Replace(ref string original, 
            string search, string replace)
        {
           original = original.Replace(search, replace);
        }


        static void Main(string[] args)
        {
            /*int num = 4;
            Console.WriteLine("Num: " + num);
            ChangeNumber(num);
            Console.WriteLine("Num: " + num);
            Console.WriteLine("===By refference==");
            Console.WriteLine("Num: " + num);
            ChangeNumberByRefference(ref num);
            Console.WriteLine("Num: " + num);*/

            /*int m = 3, n = 5;
            Square(m, ref n);
            Console.WriteLine("a: " + m);
            Console.WriteLine("b: " + n);

            String s = "Ovo je tesko";
            Replace(s, "tesko", "lagano");
            Console.WriteLine(s);*/

            Console.WriteLine(GetMax());
        }
    }
}
