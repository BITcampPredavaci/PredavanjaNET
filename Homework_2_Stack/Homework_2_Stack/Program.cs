using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_Stack
{
    class Program
    {
        static void QueueTest()
        {
            Queue<int> q = new Queue<int>();

            q.Push(1);
            q.Push(2);
            q.Push(3);
            q.Push(4);

            while (q.Length > 0)
            {
                Console.WriteLine(q.Pop());
            }
        }


        static void SuperriorArrayTest()
        {
            SuperiorArray<int> sa = new SuperiorArray<int>();
            sa.Add(1);
            sa.Add(2);
            sa.Add(1);
            sa.Add(1);
            sa.Add(3);
            sa.Add(5);
            sa.Add(5);

            sa.Add(0, 0);
            sa.RemoveAt(7);
            sa.Remove(1);
            sa.RemoveAll(1);
            Console.WriteLine("Max: " + sa.GetMax());
            Console.WriteLine("Min: " + sa.GetMin());
            sa.RemoveMax();
            sa.RemoveMin();
            for (int i = 0; i < sa.Length; i++)
            {
                Console.WriteLine(sa[i]);
            }

            SuperiorArray<int> sl = new SuperiorArray<int>();
            sl.Add(4);
            sl.Add(5);

            Console.WriteLine("Add: ");
            SuperiorArray<int> add = sa + sl;
            for (int i = 0; i < add.Length; i++)
            {
                Console.WriteLine(add[i]);
            }


            Console.WriteLine("Sub: ");
            SuperiorArray<int> sub = add - sl;
            for (int i = 0; i < sub.Length; i++)
            {
                Console.WriteLine(sub[i]);
            }


        }

        static void Main(string[] args)
        {
            //QueueTest();
            SuperriorArrayTest();
        }
    }
}
