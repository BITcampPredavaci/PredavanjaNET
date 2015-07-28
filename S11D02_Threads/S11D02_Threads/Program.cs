using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace S11D02_Threads
{
    struct Range
    {
        public int Start { get; set; }
        public int End { get; set; }
    }

    class Program
    {

        static bool IsPrime(object number)
        {
            int n = (int)number;
            for (int i = 2; i < n / 2; i++) {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        static void CheckPrimes(object range)
        {
            Range r = (Range)range;
            int count = 0;
            for (int i = r.Start; i < r.End; i++) {
                if (IsPrime(i) == true)
                    count++;
            }
            Console.WriteLine("Primes in range {0} to {1}: {2}", r.Start, r.End, count);
        }

        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            int start = 1, end = 1000000;
            //CheckPrimes(new Range { Start = start, End = end });

            int step = 100000;
            Thread[] threads = new Thread[end / step];

            for (int i = 0; i < threads.Length; i++) {
                Range r = new Range {Start = (i*step)+1, End=(i+1)*step };
                //threads[i] = new Thread(CheckPrimes);
                //threads[i].Start(r);
                ThreadPool.QueueUserWorkItem(
                    x => {
                        CheckPrimes(r);
                    }
                    );
            }


           /* foreach (Thread t in threads) {
                t.Join();
            }*/
            Thread.Sleep(30000);
                s.Stop();

            Console.WriteLine("Time: " + s.Elapsed);
        }
    }
}
