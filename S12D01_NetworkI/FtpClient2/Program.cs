using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace FtpClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create("ftp://10.0.82.97/css");
            ftpRequest.Credentials = new NetworkCredential("camp", "123456");

            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;


            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            Console.WriteLine(ftpResponse.WelcomeMessage);
            StreamReader sr = new StreamReader(ftpResponse.GetResponseStream());

            while(sr.Peek() > -1)
            {
                Console.WriteLine(sr.ReadLine());
            }

        }
    }
}
