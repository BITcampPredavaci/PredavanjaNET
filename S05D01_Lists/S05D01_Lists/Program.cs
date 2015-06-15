using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S05D01_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            BitListInt intList = new BitListInt();
            intList.Add(1);
            intList.Add(2);
            intList.Add(3);
            intList.Add(55);

            intList.PrintListR();

            Console.WriteLine("========");
            intList.Remove(0);
            intList.PrintListR();

            Console.WriteLine("========");
            intList.Remove(2);
            intList.PrintListR();


        }
    }
}
