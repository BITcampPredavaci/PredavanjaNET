using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02D04_ZadaciZaSamostalniRad
{
    class Program
    {

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static void Multiply(ref int a, int b)
        {
            a = a * b;
        }

        static void SayHello(string name)
        {
            if (name == "Joe")
            {
                Console.WriteLine("Hey Joe");
            }
        }

        static void PrintArray(int[] array)
        {
            int i = 0;
            while (i < array.Length)
            {
                Console.WriteLine(array[i]);
                i++;
            }
        }

        static void PrintFirstN(int[] array, int n)
        {
            if (n > array.Length)
            {
                n = array.Length;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static void PrintLastN(int[] array, int n)
        {
            int startIndex = array.Length - n;
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            for (int i = startIndex; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static int CountEven(int[] array)
        {
            int evenCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenCount++;
                }
            }
            return evenCount;
        }

        static bool IsPrime(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static void PrintPrimesInRange(int n)
        {
            for (int i = 1; i < n; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime == true)
                {
                    Console.WriteLine(i);
                }
            }
        }

        //static int Pow(int m, int n)
        //{
        //    int power = 1;

        //    for (int i = 0; i < n; i++)
        //    {
        //        //power = power * m;
        //        power *= m;
        //    }
        //    return power;
        //}

        static int IndexOf(string s, char c)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    return i;
                }
            }
            return -1; 
        }

        static int LastIndexOf(string s, char c)
        {
            int index = -1;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    index = i;
                }
            }

                return index;
        }


        static int LastIndexOfV2(string s, char c)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == c)
                {
                    return i;
                }
            }

            return -1;
        }


        static int FindMin(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        static int CountOccurences(int[] array, int k)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == k)
                {
                    counter++;
                }
            }
            return counter;
        }

        static void InitArray(int[] array, int n)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = n;
            }
        }

        static bool AreEqual(int[] array)
        {
            int value = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != value)
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Returns a substring of the string
        /// </summary>
        /// <param name="s">some string</param>
        /// <param name="n">starting index</param>
        /// <param name="m">last index</param>
        /// <returns>part of the string between n and m</returns>
        static string Substring(string s, int n, int m)
        {
            string substring = "";
            for (int i = n; i < m; i++)
            {
                substring += s[i];
            }
            return substring;
        }

        /// <summary>
        /// Reverses the array
        /// </summary>
        /// <param name="array">Niz</param>
        static void Reverse(int[] array)
        {
            
            for (int i = 0; i < array.Length / 2; i++)
            {
                int currentIndex = array.Length - 1 - i;
                int temp = array[i];
                array[i] = array[currentIndex];
                array[currentIndex] = temp;
            }

           
        }

        static int Pow(int m, int n = 2)
        {
            int power = 1;
            for (int i = 0; i < n; i++)
            {
                power *= m;
            }

            return power;
        }

        static int SumParams(params int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
                return sum;
        }

        static void Main(string[] args)
        {
            //int[] a = { 1, 2, 3, 4, 5 };
            //PrintArray(a);
            
            //Console.WriteLine("Mult: " + Multiply(2, 3));
            //int a = 2;
            //Multiply(2, 3);
            //Console.WriteLine("Novo a: " + a);
            //SayHello("Joe");

            //int[] array = new int[5];
            //PrintArray(array);
            //InitArray(array, 3);
            //PrintArray(array);

            int[] array = { 1, 2, 3, 4, 5 };
            PrintArray(array);
            Reverse(array);
            PrintArray(array);

            Pow(3, 5);
            Pow(3);

            int sum1 = SumParams(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            int sum2 = SumParams(1, 2, 3, 4);

            Console.WriteLine("S1:" + sum1);
            Console.WriteLine("S2: " + sum2);



        }
    }
}
