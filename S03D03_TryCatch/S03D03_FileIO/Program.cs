using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace S03D03_FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr =
                File.OpenText("..//..//data.txt");


            string line;
            int sum = 0;
            while(sr.EndOfStream == false){
                line = sr.ReadLine();
                int n = Convert.ToInt32(line);
                sum += n;
                Console.WriteLine(line);
            }

            Console.WriteLine("Suma: " + sum);
            sr.Close();
        }
    }
}
