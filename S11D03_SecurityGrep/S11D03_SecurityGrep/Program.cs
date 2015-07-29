using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace S11D03_SecurityGrep
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            SearchParam sP;
            if (args.Length <= 0) {
                Console.WriteLine("Enter search: ");
                string input = Console.ReadLine();

                 sP = new SearchParam(input);
            } else {
                sP = new SearchParam(args[0], args[1]);
            }

            Search.StartSearch(sP);
            watch.Stop();
            Console.WriteLine("Time: " + watch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
