using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S03D02_Recap
{
    class Program
    {

        static bool Equal(int[] array)
        {
            int value = array[0];
            foreach (int el in array)
            {
                if (el != value)
                {
                    return false;
                }
            }
            return true;
        }

        static bool HasEqualRow(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (Equal(array[i]) == true)
                {
                    return true;
                }
            }

            return false;
        }

        static void PrintLine(int width, bool firstOrLast)
        {
            char edge = '+', middle = '-';
            if (firstOrLast == false)
            {
                edge = '|';
                middle = ' ';
            }

            Console.Write(edge);

            for (int i = 0; i < width; i++)
            {
                Console.Write(middle);
            }
            Console.Write(edge);

            Console.WriteLine();
        }

        static void PrintSquare(int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                bool firstOrLast = false;
                if (i == 0 || i == height - 1)
                {
                    firstOrLast = true;
                }
                PrintLine(width, firstOrLast);
            }
        }

        static bool CheckColumn(int[][] array, int column)
        {
            int value = array[0][column];

            for (int row = 0; row < array.Length; row++)
            {
                if (value != array[row][column])
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckColumns(int[][] array)
        {
            for (int column = 0; column < array[0].Length; column++)
            {
                if (CheckColumn(array, column) == true)
                    return true;
            }
            return false;
        }

        static bool ComplicatedCheck(int[][] array)
        {
            for (int column = 0; column < array[0].Length; column++)
            {
                bool allEqual = true;
                int value = array[0][column];
                for (int row = 0; row < array.Length; row++)
                {
                    if (value != array[row][column])
                    {
                        allEqual = false;
                        break;
                    }
                }
                if (allEqual == true)
                {
                    return true;
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            PrintSquare(5, 10);
        }
    }
}
