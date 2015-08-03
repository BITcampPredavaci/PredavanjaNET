using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FtpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create("ftp://10.0.82.97");
            ftpRequest.Credentials = new NetworkCredential("camp", "123456");

            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.KeepAlive = true;

            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;

            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

            Stream responseStream = ftpResponse.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            while(reader.Peek() > -1)
            {
                Console.WriteLine(reader.ReadLine());
            }

            ftpResponse.Close();

        }
    }
}
