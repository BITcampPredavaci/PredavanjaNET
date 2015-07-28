using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace S11D02_ThreadsIntro
{
    class Program
    {
        static void Print(object line)
        {
            string s = (string)line;
            for (int i = 0; i < 5; i++) {
                Console.WriteLine(s);
                Thread.Sleep(1000);
            }
        }

        static void Print1(object line)
        {
            string s = (string)line;
            for (int i = 0; i < 5; i++) {
                Console.WriteLine(s);
                Thread.Sleep(2000);
            }
        }



        static void Main(string[] args)
        {
            Thread t = new Thread(Print);
            t.Start("Ovo je thread");
            Thread t1 = new Thread(Print1);
            t1.Start("Ovo je drugi thread");

            Thread t3 = new Thread(
                () => {
                    for (int i = 0; i < 5; i++)
                        Console.WriteLine("Ovo je lambda thread");
                }
                );
            t3.Start();

            for (int i = 0; i < 5; i++)
                Console.WriteLine("Main");

            t.Join();
            t1.Join();
            Console.WriteLine("End of main");
        }
    }
}
