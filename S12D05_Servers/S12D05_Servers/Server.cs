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

            //we will use this to store name->value pairs for variables passed
            //from the client
            NameValueCollection data = null;

            //depending on the request get the variables from the
            //"valid" source
            if (request.HttpMethod == "GET")
                data = request.QueryString;
            else
                data = VariablesPOST(request);

            //asume the client wants to get to the index page
            string className = "Home";
            string methodName = "Index";

            //this will store the clean URL value (without additional data)
            string cleanUrl = "";
            if (request.RawUrl.IndexOf("?") > -1)
            {
                cleanUrl =
                    request.RawUrl.Substring(0, request.RawUrl.IndexOf("?"));
            }
            if (cleanUrl == "")
                cleanUrl = request.RawUrl;

            //because we did not implement this jet
            if (cleanUrl.Contains("favicon"))
            {
                response.Close();
                return;
            }

            //if the client did not request the index page figure out
            //what he did request
            if (cleanUrl != "/")
            {
                string[] parts = cleanUrl.Split('/');
                className = parts[1];
                methodName = parts[2];
            }

           
            //get a refference to the class
            Type type = Type.GetType("S12D05_Servers."+className); 
            //make a new object from the previously figured out class
            var obj = Activator.CreateInstance(type);

            //get data about the method
            MethodInfo mi = type.GetMethod(methodName);
            //list of paramethers the method accepts
            ParameterInfo[] pi = mi.GetParameters();
            foreach(ParameterInfo p in pi)
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.ParameterType);
            }

            Home h = new Home();
            //string result = h.Add(data.Get("a"), data.Get("b"));
            object[] param = new object[pi.Length];
            //for each paramether in the list get the value
            //from the client passed variables and convert them
            //to the proper type
            for(int i = 0; i < pi.Length; i++)
            {
                string value = data.Get(pi[i].Name);
                param[i] = Convert.ChangeType(value, pi[i].ParameterType);
            }

            //the value we will return to the user
            string result = (string)mi.Invoke(obj, param);


            StreamWriter sw = new StreamWriter(response.OutputStream);
            sw.WriteLine(result);
            sw.Flush();

            response.Close();
        }

        private NameValueCollection VariablesPOST(HttpListenerRequest request)
        {
            StreamReader sr = new StreamReader(request.InputStream);
            string rawVariables = sr.ReadLine();
            NameValueCollection data = new NameValueCollection();
            if (rawVariables != null)
            {
                string[] variables = rawVariables.Split('&');
                
                foreach (string variable in variables)
                {
                    string[] variableParts = variable.Split('=');
                    data.Add(variableParts[0], variableParts[1]);
                }
            }
            return data;
        }

    }
}
