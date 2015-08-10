using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;
using System.Reflection;
using System.Net;

namespace S12D05_Servers
{
    class Routing
    {
        private static string[] FILE_EXTENSIONS = { ".css", ".js" };
        
        private static string GetCleanUrl(string url)
        {
            //this will store the clean URL value (without additional data)
            string cleanUrl = "";
            if (url.IndexOf("?") > -1)
            {
                cleanUrl =
                    url.Substring(0, url.IndexOf("?"));
            }
            if (cleanUrl == "")
                cleanUrl = url;

            return cleanUrl;
        } 
        public static string GetResult(HttpListenerRequest request)
        {
            string cleanUrl = GetCleanUrl(request.RawUrl);
            string extension = Path.GetExtension(cleanUrl);
            if(extension != String.Empty)
            {
                //if it is one of the permited extensions
                if (FILE_EXTENSIONS.Contains(extension))
                {
                    return ReadStaticFile(cleanUrl);
                }
                else
                {
                    return "";
                }
            } else
            {
                //assume it is controller/action url

                string className = "Home";
                string methodName = "Index";
                NameValueCollection data = null;

                //if the client did not request the index page figure out
                //what he did request
                if (cleanUrl != "/")
                {
                    string[] parts = cleanUrl.Split('/');
                    className = parts[1];
                    methodName = parts[2];
                }
                //depending on the request get the variables from the
                //"valid" source
                if (request.HttpMethod == "GET")
                    data = request.QueryString;
                else
                    data = VariablesPOST(request);

                //get a refference to the class
                Type type = Type.GetType("S12D05_Servers.Controllers." + className);
                //make a new object from the previously figured out class
                var obj = Activator.CreateInstance(type);

                //get data about the method
                MethodInfo mi = type.GetMethod(methodName);
                //list of paramethers the method accepts
                ParameterInfo[] pi = mi.GetParameters();
                foreach (ParameterInfo p in pi)
                {
                    Console.WriteLine(p.Name);
                    Console.WriteLine(p.ParameterType);
                }

                //Home h = new Home();
                //string result = h.Add(data.Get("a"), data.Get("b"));
                object[] param = new object[pi.Length];
                //for each paramether in the list get the value
                //from the client passed variables and convert them
                //to the proper type
                for (int i = 0; i < pi.Length; i++)
                {
                    string value = data.Get(pi[i].Name);
                    param[i] = Convert.ChangeType(value, pi[i].ParameterType);
                }

                //the value we will return to the user
                return (string)mi.Invoke(obj, param);
            }
        }


        private static string ReadStaticFile(string name)
        {
            string base_path = Path.Combine(
                   System.Environment.CurrentDirectory,
                   "Content"
               );
            FileStream fs = File.OpenRead(
               Path.GetFullPath(base_path + name)
               );

            StreamReader sr = new StreamReader(fs);
            return sr.ReadToEnd();
        }


        private static NameValueCollection VariablesPOST(HttpListenerRequest request)
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
