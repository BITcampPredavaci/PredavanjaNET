using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S05D03_Stack_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            BitList<int> list = new BitList<int>();
            list.Add(1, 0);
            list.Add(2, 0);
            list.Add(3, 0);
            list.Add(4, 1);
            list.Add(5, 3);

            list.PrintList();
        }
    }
}
