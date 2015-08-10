using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;

namespace ApiConsumer
{
    class ApiRequest
    {
        public delegate void Callback(string s);

        private string url;

        public ApiRequest(string url)
        {
            this.url = url;
        }


        public string MakeRequestAsync(NameValueCollection param)
        {
            //add param to url
            StringBuilder sb = new StringBuilder(url);

            foreach(string key in param)
            {
                sb.Append(String.Format("{0}={1}", key, WebUtility.UrlEncode(param.Get(key))));
                sb.Append("&");
            }

            HttpWebRequest request = WebRequest.CreateHttp(sb.ToString());
           
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return "";
            }

            sb.Clear();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            while(sr.Peek() > -1)
            {
                sb.Append(sr.ReadLine());
            }
            sr.Close();
            response.Close();

            return sb.ToString();
           
        }

    }
}
