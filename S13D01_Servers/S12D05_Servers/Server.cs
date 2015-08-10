using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Specialized;
using System.Reflection;

namespace S12D05_Servers
{
    class Server
    {

        HttpListener server;

        public Server(string host)
        {
            server = new HttpListener();
            server.Prefixes.Add(host);
        }

        public void Start()
        {
            server.Start();
        }

        public void AcceptConnection()
        {
            //Represents our client
            HttpListenerContext conection = server.GetContext();

            //The object encapsulating the clients request
            HttpListenerRequest request = conection.Request;
            //The object encapsulating the server response
            HttpListenerResponse response = conection.Response;

            string result = Routing.GetResult(request);
            
            StreamWriter sw = new StreamWriter(response.OutputStream);
            sw.WriteLine(result);
            sw.Flush();

            response.Close();
        }

       

    }
}
