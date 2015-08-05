using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {

            /* TcpListener server = new TcpListener(IPAddress.Any, 7321);
             server.Start();
             TcpClient client = server.AcceptTcpClient();
             StreamReader sr = new StreamReader(client.GetStream());
             Console.WriteLine(sr.ReadLine());

             sr.Close();
             client.Close();*/

            TcpClient client = new TcpClient("141.101.112.88", 80);
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());

            sw.WriteLine("GET /");
            sw.WriteLine("User-Agent:Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.125 Safari/537.36");
            sw.WriteLine();
            sw.Flush();
            while(sr.Peek() > -1)
            {
                Console.WriteLine(sr.ReadLine());
            }


        }
    }
}
