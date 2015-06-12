using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D05_NestedAndGenerics
{
    class Foo 
    {
        private static int a = 2;
        private Bar bar;

        public class Bar
        {
            private int b = a;
            private int c = 4;
        }

        public int A { get { return a; } }





        public int CompareTo(Foo other)
        {
            throw new NotImplementedException();
        }

       
    }

    class Program
    {

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void SimpleGenericClass()
        {
            StackInt si = new StackInt();
            si.Push(12);
            si.Push(13);
            Console.WriteLine(si.Peek());
            Console.WriteLine(si.Pop());
            si.Push(10);
            Console.WriteLine(si.Pop());

            Console.WriteLine("=================");

            Stack<int> sgi = new Stack<int>();
            sgi.Push(12);
            sgi.Push(13);
            Console.WriteLine(sgi.Peek());
            Console.WriteLine(sgi.Pop());
            sgi.Push(10);
            Console.WriteLine(sgi.Pop());

            Stack<string> sgs = new Stack<string>();
            sgs.Push("Hello");
            sgs.Push("World");
            Console.WriteLine(sgs.Peek());
            Console.WriteLine(sgs.Pop());
            sgs.Push("Last");
            Console.WriteLine(sgs.Pop());
        }

        static void SimpleGenericMethod()
        {
            int a = 3, b = 5;
            //string s = "s";
            Swap(ref a, ref b);
            Console.WriteLine(a);
        }

        static void Main(string[] args)
        {

            //SimpleGenericClass();
            //SimpleGenericMethod();

           /* DynamicArray<bool> arr = new DynamicArray<bool>();
            arr.Add(25);
            for (int i = 1; i <= 20; i++)
            {
                arr.Add(i);
            }

            int max = arr.GetMax();
            Console.WriteLine(max);*/

            //Stack<Foo> s = new Stack<Foo>();
           // DynamicArray<Foo> f = new DynamicArray<Foo>();

            DynamicSortedArray<int> ds = new DynamicSortedArray<int>();
            ds.Add(0);
            ds.Add(-1);
            ds.Add(1);
            ds.Add(-1);
            ds.Add(5);

            for (int i = 0; i < ds.Size; i++)
            {
                Console.WriteLine(ds.Get(i));
            }
        }
    }
}
