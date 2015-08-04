using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace S12D02_FtpClient
{
    class FTPClient
    {

        private FtpWebRequest ftpRequest;
        private FtpWebResponse ftpResponse;
        private NetworkCredential credentials;
        private string domain;

        public delegate void ProgressUpdate(double x);

        /// <summary>
        /// Creates credentials with the given username and password which will be used
        /// to connect to the FTP server. And a ftp://host/ domain reference
        /// </summary>
        /// <param name="username">Username to use for connection</param>
        /// <param name="password">Password to use for connection</param>
        /// <param name="host">the host to connect to</param>
        public FTPClient(string username, string password, string host)
        {
            credentials = new NetworkCredential(username, password);
            domain = "ftp://"+host+"/";
        }

        /// <summary>
        /// Common FTP request initialization
        /// </summary>
        /// <param name="path">The path the request will use</param>
        private void InitFtpRequest(string path)
        {
            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(domain + path);
            ftpRequest.Credentials = credentials;
            ftpRequest.UseBinary = true;
        }

        /// <summary>
        /// Returns all directories in the folder on the server specified by the path
        /// </summary>
        /// <param name="path">the folder path</param>
        /// <returns>Files/Folders in the folder specified by the path</returns>
        public List<string> ListDirectory(string path = "")
        {
            InitFtpRequest(path);
            
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

            Stream s = ftpResponse.GetResponseStream();
            StreamReader sr = new StreamReader(s);

            List<string> fileNames = new List<string>();

            while(sr.Peek() > -1)
            {
                fileNames.Add(sr.ReadLine());
            }

            s.Close();
            ftpResponse.Close();

            return fileNames;
        }

        /// <summary>
        /// Downloads a file from the server
        /// </summary>
        /// <param name="path">the path of the file on the server</param>
        /// <param name="localFile">stream to a local file</param>
        /// <param name="handler">the update method (progress bar)</param>
        public void DownloadFile(string path, Stream localFile, ProgressUpdate handler)
        {
            InitFtpRequest(path);
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

            Stream s = ftpResponse.GetResponseStream();

            TransferData(s, localFile, handler);

            s.Close();
            ftpResponse.Close();
            localFile.Close();
        }

        /// <summary>
        /// Upload a file to the server
        /// </summary>
        /// <param name="path">the path of the new file</param>
        /// <param name="localFile">stream to a local file</param>
        /// <param name="handler">the update method (progress bar)</param>
        public void UploadFile(string path, Stream localFile,
           ProgressUpdate handler)
        {
            InitFtpRequest(path);
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            Stream s = ftpRequest.GetRequestStream();
            TransferData(localFile, s, handler);
            s.Close();
            localFile.Close();
        }

        /// <summary>
        /// Creates a folder on the server
        /// </summary>
        /// <param name="path">Path to the folder</param>
        public void CreateFolder(string path)
        {
            InitFtpRequest(path);
            ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;

            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

            ftpResponse.Close();
        }

        /// <summary>
        /// A helper method to transfer data from one stream to another
        /// </summary>
        /// <param name="source">Stream from which to read</param>
        /// <param name="destination">Stream from which to write</param>
        /// <param name="handler">the update method (progress bar)</param>
        private void TransferData(Stream source, Stream destination, ProgressUpdate handler)
        {
            int bufferSize = 2048;
            byte[] buffer = new byte[bufferSize];
            int bytesRead = 0;
            double progress = 0;
            while ((bytesRead = source.Read(buffer, 0, bufferSize)) > 0)
            {
                progress += 5;
                handler(progress);
                destination.Write(buffer, 0, bytesRead);
            }
        }

       
    }
}
