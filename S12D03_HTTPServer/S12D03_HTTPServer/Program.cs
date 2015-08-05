using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace S12D03_HTTPServer
{
    class Program
    { 
        static void Main()
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://localhost:7321/");
            server.Start();
            HttpListenerContext context =  server.GetContext();

            Console.WriteLine(context.Request.HttpMethod);
            Console.WriteLine(context.Request.RawUrl);
            Console.WriteLine(context.Request.UserAgent);
        }
       
    }
}
