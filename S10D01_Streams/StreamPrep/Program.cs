using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPrep
{
    class Program
    {

        static byte[] ToByteArray(string str)
        {
            char[] chars = str.ToCharArray();
            byte[] bytes = new byte[chars.Length * sizeof(char)];
            System.Buffer.BlockCopy(chars, 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string ByteArrayToString(byte[] array)
        {
            char[] chars = new char[array.Length / sizeof(char)];
            System.Buffer.BlockCopy(array, 0, chars, 0, array.Length);
            return new String(chars);
        }

        static void Main(string[] args)
        {

            FileStream fs =
                new FileStream("MyFile.txt", FileMode.OpenOrCreate);

            CampStream cs = new CampStream(fs);


            string message = "Hello World";
            byte[] messageBytes = ToByteArray(message);

            fs.Write(messageBytes, 0, messageBytes.Length);
            fs.Flush();

            fs.Position = 0;

            //citanje
            byte[] buffer = new byte[10];

            StringBuilder sb = new StringBuilder();
            int read = 0;
            while ((read = fs.Read(buffer, 0, buffer.Length)) > 0) {
                if (read < buffer.Length) {
                    byte[] temp = new byte[read];
                    Array.Copy(buffer, temp, temp.Length);
                    sb.Append(ByteArrayToString(temp));
                } else {
                    sb.Append(ByteArrayToString(buffer));
                }
            }

            Console.WriteLine(sb.ToString() + "!");

           
            
           
            fs.Close();
        }
    }
}
