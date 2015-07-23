using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10D02_Streams
{
    class Program
    {
        static void Main(string[] args)
        {

            FileStream sw = new FileStream("crypt.dat", FileMode.Create);

            Console.WriteLine("Enter string: ");
            string input = Console.ReadLine();
            string cipherd = CryptUtil.Encrypt(input, -2);

            foreach (char c in cipherd) {
                sw.WriteByte((byte)c);
            }

            sw.Flush();

            sw.Position = 0;

            StringBuilder sb = new StringBuilder();

            byte[] buffer = new byte[sw.Length];
            sw.Read(buffer, 0, buffer.Length);

            foreach (byte b in buffer) {
                sb.Append((char)b);
            }

            Console.WriteLine("Dec: " +CryptUtil.Decrypt(sb.ToString(), 2));

            List<string> results = CryptUtil.BruteForce(sb.ToString());

            foreach (string res in results) {
                Console.WriteLine(res);
            }

        }
    }
}
