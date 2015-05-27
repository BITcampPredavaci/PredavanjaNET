using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca_Petlje
{
    class Program
    {
        /// <summary>
        /// Prints a message to the user and takes a integer input.
        /// Returns the entered value
        /// </summary>
        /// <returns>the input from the user</returns>
        static int GetInput()
        {
            Console.WriteLine("Enter a number: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Prints all the numbers between n and m including n and m
        /// </summary>
        /// <param name="n">start of interval</param>
        /// <param name="m">end of interval</param>
        static void PrintInterval(int n, int m)
        {
            //we will increase n untill it gets to m
            while (n <= m)
            {
                //print the number
                Console.WriteLine(n);
                //increase n by 1
                n++;
            }
        }

        /// <summary>
        /// Counts and displays the number of even and odd inputs form the user
        /// Input reading terminates after the user enters -1
        /// </summary>
        static void CountInputs()
        {
            int input = GetInput();
            int countEven = 0, countOdd = 0;

            while (input != -1)
            {
                if (input % 2 == 0)
                {
                    countEven++;
                }
                else
                {
                    countOdd++;
                }
                input = GetInput();
            }
            Console.WriteLine("Even numbers: " + countEven);
            Console.WriteLine("Odd numbers: " + countOdd);
        }

        /// <summary>
        /// Checks if a number is "magic" - if
        /// the sum of its divisors is equal to the number
        /// </summary>
        /// <param name="num">the number we want to check</param>
        /// <returns></returns>
        static bool IsMagic(int num)
        {
            int sum = 0;
            int divisor = 1;
            
            while (divisor < num)
            {
                if (num % divisor == 0)
                {
                    sum += divisor;
                }
                divisor++;
            }

            if (sum == num)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Prints the number of digits for a given number
        /// </summary>
        /// <param name="n">the number we want to check</param>
        static void PrintDigits(int n)
        {
            int numDigits = 0;

            while (n > 0)
            {
                numDigits++;
                n /= 10;
            }
            Console.WriteLine("Number of digits: " + numDigits);
        }

        /// <summary>
        /// Reverses a given number, e.g. 123 becomes 321
        /// </summary>
        /// <param name="number">The number we want to reverese</param>
        /// <returns>The reversed number</returns>
        static int ReverseNumber(int number)
        {
            int reverse = 0;
            while (number > 0)
            {
                //get the last digit
                int lastDigit = number % 10;
                //add a 0 to the end of the current number
                reverse = reverse * 10;

                //add the last digit to the reverse
                reverse = reverse + lastDigit;

                //"cut" the last digit from the number
                number /= 10;
            }

            return reverse;
        }

        /// <summary>
        /// Checks if a number is a palindrome
        /// </summary>
        /// <param name="number"> The number we want to test</param>
        /// <returns>true if the number is a palindrome, false otherwise</returns>
        static bool IsPalindrome(int number)
        {
            int reverseNumber = ReverseNumber(number);

            return reverseNumber == number;
        }

        /// <summary>
        /// Calculates n!
        /// </summary>
        /// <param name="number">The number whose factorial we want to calculate</param>
        /// <returns>The factorial of n (n!)</returns>
        static int Factorial(int number)
        {
            int i = 1;
            int factorial = 1;
            while (i <= number)
            {
                factorial *= i;
                i++;
            }
            return factorial;
        }

        /// <summary>
        /// Converts a decimal number into a binary number
        /// </summary>
        /// <param name="number">The number to convert</param>
        /// <returns>The number in binary form</returns>
        static string ToBinary(int number)
        {
            string binary = "";

            while (number > 0)
            {
                int reminder = number % 2;
                binary = reminder + binary;
                number /= 2;
            }
            return binary;
        }

        static int ToDecimal(int binary)
        {
            int i = 0;
            int number = 0;
            while (binary > 0)
            {
                int lastDigit = binary % 10;
                number += (int)(lastDigit * Math.Pow(2, i));
                i++;
                binary /= 10;
            }
            return number;
        }

        static void Main(string[] args)
        {
            int n = GetInput(), m = GetInput();
            PrintInterval(n, m);

            CountInputs();

            int checkIfMagic = GetInput();
            bool isMagic = IsMagic(checkIfMagic);
            Console.WriteLine(checkIfMagic + " is magic: " + isMagic); 

            int testingDigits = GetInput();
            PrintDigits(testingDigits); 

            int palindromeCheck = GetInput();
            bool isPalindrome = IsPalindrome(palindromeCheck);
            Console.WriteLine(palindromeCheck + " is palindrome: " + isPalindrome); 

            int numFact = GetInput();
            Console.WriteLine(Factorial(numFact));

            int toBinary = GetInput();
            string binary = ToBinary(toBinary);
            Console.WriteLine(toBinary + " as binary: " + binary); 

            Console.WriteLine("Eneter a binary number");
            int inBinary = Convert.ToInt32(Console.ReadLine());
            int inDecimal = ToDecimal(inBinary);
            Console.WriteLine(inBinary + " as decimal " + inDecimal);

        }
    }
}
