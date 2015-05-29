using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02D05_Last5
{
    class Program
    {
        static void PrintArray(int[] array)
        {
            foreach (int el in array)
            {
                if (el != -1)
                {
                    Console.Write(el + " ");
                }
            }
            Console.WriteLine();
        }

        static int Sum(int[] array)
        {
            int sum = 0;
            foreach (int a in array)
            {
                //sum = sum + a;
                if (a != -1)
                {
                    sum += a;
                }
            }
            return sum;
        }

        static double Average(int[] array)
        {
            int sum = 0;

            int count = 0;
            foreach (int el in array)
            {
                if (el != -1)
                {
                    sum += el;
                    count++;
                }
            }

            if (count == 0)
            {
                return 0;
            }

            double average = (double)sum / count;
            return average;
        }

        static void ShiftLeft(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                array[i] = array[i + 1];
            }

            array[array.Length - 1] = -1;
        }

        static void InitArray(int[] array, int defaultValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = defaultValue;
            }
        }

        static void Main(string[] args)
        {
            int input = 0;
            int[] numbers = new int[5];
            InitArray(numbers, -1);
            int index = 0;
            while (input != -1)
            {
                Console.WriteLine("Enter a number, -1 to exit");
                input = Convert.ToInt32(Console.ReadLine());
                if (input == -1)
                {
                    break;
                }
             
                int lastIndex = index % 5;
                numbers[lastIndex] = input;
                index++;
            }

            PrintArray(numbers);
            Console.WriteLine("Sum: " + Sum(numbers));
            Console.WriteLine("Average: " + Average(numbers));

        }
    }
}
