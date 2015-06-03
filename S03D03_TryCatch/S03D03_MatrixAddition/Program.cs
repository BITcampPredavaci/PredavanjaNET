using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S03D03_MatrixAddition
{
    class Program
    {
        static void InitArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new int[5];
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = (i + 1) * (j + 1);
                }
            }
        }

        static void PrintArray(int[][] array)
        {
            foreach (int[] row in array)
            {
                foreach (int element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int[][] AddMatrix(int[][] arr1, int[][] arr2)
        {
            int[][] result = new int[arr1.Length][];
            InitArray(result);

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr1[i].Length; j++)
                {
                    result[i][j] = arr1[i][j] + arr2[i][j];
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            int[][] array1 = new int[3][];
            int[][] array2 = new int[3][];

            InitArray(array1);
            InitArray(array2);

            PrintArray(array1);
            PrintArray(array2);

            int[][] result = AddMatrix(array1, array2);
            PrintArray(result);
        }
    }
}
