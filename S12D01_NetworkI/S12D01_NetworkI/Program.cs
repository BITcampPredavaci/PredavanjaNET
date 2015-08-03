using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace S12D01_NetworkI
{
    class Program
    {

        private static int _port = 7321;

        static void startServer()
        {
            TcpListener server = new TcpListener(IPAddress.Any , _port);
            server.Start();
            TcpClient client = server.AcceptTcpClient();
            NetworkStream ns = client.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            string fromClient = sr.ReadLine();
            Console.WriteLine(fromClient);
            sw.WriteLine(fromClient);
            sw.Flush();

            server.Stop();
        }

        static void startClient()
        {
            TcpClient client = new TcpClient("10.0.82.65", _port);
            NetworkStream ns = client.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            sw.WriteLine("Hello World");
            sw.Flush();

            string line = sr.ReadLine();
            Console.WriteLine(line);


            client.Close();
        }

        static void Main(string[] args)
        {

            if (args[0] == "server")
                startServer();
            else
                startClient();
           
        }

    }
}
