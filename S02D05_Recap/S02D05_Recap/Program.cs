using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02D05_Recap
{
    class Program
    {
        /// <summary>
        /// Reverses the string passed as param
        /// </summary>
        /// <param name="s">the string to reverse</param>
        static void Reverse(ref string s){

            string reverse = "";

            for (int i = s.Length-1; i >= 0; i--)
            {
                reverse += s[i];
            }
            s = reverse;
        }

         /// <summary>
        /// Shifts the elements of the passed array by one
        /// place left, sets the last element to 0
        /// </summary>
        /// <param name="array">The array you want to shift</param>
        static void ShiftLeft(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                array[i - 1] = array[i];
            }

            array[array.Length - 1] = 0;
        }

        /// <summary>
        /// Prints the element of the array next to
        /// each other
        /// </summary>
        /// <param name="array">array we want to print</param>
        static void PrintArray(int[] array)
        {
            
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        { 
            string s = "Hello";
            Console.WriteLine(s);
            Reverse(ref s);
            Console.WriteLine(s);

            int[] array = { 1, 2, 3, 4, 5 };
            PrintArray(array);
            ShiftLeft(array);
            PrintArray(array);
        }
    }
}
