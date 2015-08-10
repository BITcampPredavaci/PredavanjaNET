using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace S13D01_AThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task(() =>
            {
                for(int i = 0; i < 5; i++)
                    Console.WriteLine("Task " + i);
            });
            t.Start();
            t.GetAwaiter().OnCompleted(() =>
            {
                int i = 0;
                for(;;)
                {
                    Console.WriteLine("Completed " + i++);
                }
            });

            for(int i = 0; i < 30; i++)
                Console.WriteLine("Main " + i + " Status: " + t.Status );

            Console.WriteLine("Status: " + t.Status);
        }


        
    }
}
