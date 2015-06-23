using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D02_LINQ
{
    class Program
    {

        static void PrintEnumerable<T>(IEnumerable<T> result)
        {
            foreach (T el in result)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

        static void LINQSample()
        {
            int[] array = new int[] { 8, 4, 3, 5, 2, 1, 7, 8, 4, 3, 5, 2, 1, 7 };
            IEnumerable<int> lessThan = array.Where(x => x < 5);
            PrintEnumerable(lessThan);
            IEnumerable<int> sortedLess = lessThan.OrderBy(x => x);
            PrintEnumerable(sortedLess);
            IEnumerable<int> sortedDesc = sortedLess.OrderByDescending(x => x);
            PrintEnumerable(sortedDesc);

            IEnumerable<int> sortedSmallNumbers = array.Where(x => x < 5)
                                                        .OrderBy(x => x);

            IEnumerable<int> firstSorted2 = array.OrderBy(x => x).Take(2);
            IEnumerable<int> first2 = array.Take(2).OrderBy(x => x);

            PrintEnumerable(firstSorted2);
            PrintEnumerable(first2);

            List<int> list = new List<int>(array);

            int count = list.Where(x => x < 5).Count();
            Console.WriteLine("Count: " + count);

            IEnumerable<int> smallNumbers = list.Where(x => x < 5).Select(x => x * 2);

            list.Add(3);
            PrintEnumerable(smallNumbers);

            list.Add(2);
            PrintEnumerable(smallNumbers);

            IEnumerable<int> unique = list.Distinct();
            PrintEnumerable(unique);
            PrintEnumerable(array);
        }

        static void Main(string[] args)
        {

            Student s = new Student("John", "Doe");
            Course c = new Course("Math", "Miller");

            s.AddCourse(c);
            Console.WriteLine(s.AddCourse(c));

        }
    }
}
