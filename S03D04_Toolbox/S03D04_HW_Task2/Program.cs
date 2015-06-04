using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S03D04_HW_Task2
{
    class Program
    {
        /// <summary>
        /// Gets an integer from the console
        /// </summary>
        /// <returns>the enetered value</returns>
        static int GetInput()
        {
            while (true)
            {
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    return number;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Not a number, try again");
                }
            }
        }

        static void Main(string[] args)
        {
            int height, width;
            Console.WriteLine("Enter the width");
            width = GetInput();
            Console.WriteLine("Enter the height");
            height = GetInput();

            //initializing the table
            int[][] table = new int[height][];
            for (int i = 0; i < height; i++)
            {
                table[i] = new int[width];
            }

            //set the table elements
            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < table[i].Length; j++)
                {
                    Console.WriteLine("Next element: ");
                    table[i][j] = GetInput();
                }
            }

            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < table[i].Length; j++)
                {
                    Console.Write(table[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
