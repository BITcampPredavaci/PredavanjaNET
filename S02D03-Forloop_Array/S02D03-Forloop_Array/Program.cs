using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02D03_Forloop_Array
{
    class Program
    {
        static int ArraySum(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

                return sum;
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void PrintFirst(int[] array, int m)
        {
            for (int i = 0; i < m; i++)
            {
                Console.Write(array[i] + " ");
            }
        }


        static void SetToOne(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 1;
            }
        }

        static double ArrayAverage(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                //sum = sum + aray[i]
                sum += array[i];
            }

            double average = (double)sum / array.Length;

            return average;
        }

        static void Main(string[] args)
        {
            //ako znate koje su vrijednosti u nizu
            Console.WriteLine("How many numbers o you have");
            int arraySize = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[arraySize]; 

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Unesi broj: ");
                array[i]  = Convert.ToInt32(Console.ReadLine());

            }
            double average = ArrayAverage(array);
            Console.WriteLine("Average: " + average);
        }
    }
}
