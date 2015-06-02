using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S03D02_IO_Recursion_Exception
{
    class Program
    {



        static void PrintToN(int n)
        {
            if (n == -1)
            {
                return;
            }
            Console.WriteLine(n);
            PrintToN(--n);
        }

        static void Print1DArray(int[] array)
        {
            foreach (int el in array)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

        static void ChangeToFour(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 4;
            }
        }

        static void Print2DArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                ChangeToFour(array[i]);
                Print1DArray(array[i]);
            }
        }

        static void PrintArrayRec(int[] array, int i  = 0)
        {
            if (i == array.Length)
                return;
            Console.Write(array[i] + " ");
            PrintArrayRec(array, i + 1);
        }


        static void Main(string[] args)
        {

            int[][] array = {
                  new int[] {1},
                  new int[] {2, 3},
                  new int[] {4, 5, 6}
        };

           // Print2DArray(array);

            PrintArrayRec(array[2]);

        }
    }
}
