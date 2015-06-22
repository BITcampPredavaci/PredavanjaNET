using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D01_Lambda
{
    class Program
    {

        static void CountingSort(int[] array, int maxElement)
        {
            int[] counts = new int[maxElement+1];

            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i]]++;
            }

            int j = 0, idx = 0;
            while(j < array.Length)
            {
                while (counts[idx] != 0)
                {
                    array[j++] = idx;
                    counts[idx]--;
                }
                idx++;
            }
        }

        delegate bool IsBigger(int a);
        delegate int Count();
       
        static void Main(string[] args)
        {

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int sum =
                numbers.Where(x => x > 2 && x < 6).Sum();

            Console.WriteLine("Sum for x > 2 && x < 6: " + sum);
            int numberSum = numbers.Sum();

            Console.WriteLine("Numbers sum: " + numberSum);

            int doubleNumbersSum = numbers.Sum(x => x * 2);

            Console.WriteLine("Numbers sum double: " + doubleNumbersSum);

            string[] names = new string[] 
            { "Mirza", "Melisa", "Rijad", "Edina",
               "Hazim", "Dijana", "Mustafa", "Sabaheta",
               "Zorica"
            };

            IEnumerable<string> filteredNames
                = names.Where(x => x[0] < 75 && x[0] > 64)
                .Where(x => x.Contains("n"))
                .Select(x => x.ToUpper())
                .OrderBy(x => x.Length);
              
           foreach(string s in filteredNames)
               Console.Write(s + " ");

            IsBigger ib = (x) => x > 5;
            
            Console.WriteLine(ib(10));

            int counter = 0;
            Count c = () => ++counter;

            Console.WriteLine(c());
            Console.WriteLine(c());
            Console.WriteLine(c());
           

            counter = 10;

            Func<int, bool> fb = x => x < 3;
            fb += x => x > 5 && x < 3;

            Console.WriteLine(fb(12));

            Action[] actionArray = new Action[3];
            for (int i = 0; i < actionArray.Length; i++)
            {
                actionArray[i] = () => Console.WriteLine(i);
            }

            foreach (Action a in actionArray)
            {
                a();
            }

        }
    }
}
