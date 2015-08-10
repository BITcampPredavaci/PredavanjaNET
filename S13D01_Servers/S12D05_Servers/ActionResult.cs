using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;

namespace S12D05_Servers
{
    class ActionResult
    {
        private static string BASE_PATH = Path.Combine(
                   System.Environment.CurrentDirectory,
                   "Views/"
               );

        public static string View(string path)
        {
            FileStream fs = File.OpenRead(
               Path.Combine(
                  BASE_PATH, path
               ));
            StreamReader sr = new StreamReader(fs);
            string html = sr.ReadToEnd();
            sr.Close();
            return html;
        }

        public static string View(string path, NameValueCollection data)
        {
            FileStream fs = File.OpenRead(
               Path.Combine(
                  BASE_PATH, path
               ));
            StreamReader sr = new StreamReader(fs);
            string html = sr.ReadToEnd();

            foreach(string key in data.AllKeys)
            {
                html = html.Replace(key, data.Get(key));
            }
            sr.Close();
            return html;
        }

    }
}
