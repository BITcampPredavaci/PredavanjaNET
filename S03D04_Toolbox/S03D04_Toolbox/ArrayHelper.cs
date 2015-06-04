using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S03D04_Toolbox
{
    class ArrayHelper
    {

        public static void PrintArray(int[][] array)
        {
            foreach (int[] row in array)
            {
                PrintArray(row);
            }
        }

        
        /// <summary>
        /// Sets all the elements of array to defaultValue
        /// </summary>
        /// <param name="array">the array whose elements we want to set</param>
        /// <param name="defaultValue">the default value</param>
        public static void SetElements(int[] array, 
            int defaultValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = defaultValue;
            }
        }

        /// <summary>
        /// Prints the elements of the array next to each other
        /// </summary>
        /// <param name="array">The array we want to print</param>
        public static void PrintArray(int[] array)
        {
            foreach (int el in array)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

        public static void AddToArray(ref int[] array, int index, int value)
        {
            if (index >= array.Length)
            {
                ResizeArray(ref array);
            }
            array[index] = value;
            PrintArray(array);
        }

        private static void ResizeArray(ref int[] array)
        {
            double pi = Math.PI;

            int[] temp = new int[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
        }

    }
}
