using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace ChainConnection
{
    
    class Program
    {

        private static int _port = 7321;

        static void Main(string[] args)
        {
            TcpClient reciever = new TcpClient("10.0.82.65", _port);
            

            StreamReader sr = new StreamReader(reciever.GetStream());

            Console.WriteLine(sr.ReadLine());

            reciever.Close();
        }
    }
}
