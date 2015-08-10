using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace ApiConsumer
{
    class TextSentiment
    {
        public double Score { get; set; }
        public string Sentiment { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"https://www.tweetsentimentapi.com/api/?";

            ApiRequest api = new ApiRequest(url);
            NameValueCollection param = new NameValueCollection();
            param.Add("key", "d918ec23b506d6f72ae91c2565146a360391a92d");
            param.Add("text", "Threads are discusting");
            string result = api.MakeRequestAsync(param);

            TextSentiment resultObj = 
                JsonConvert.DeserializeObject<TextSentiment>(result);

            Console.WriteLine("Score: " + resultObj.Score);
            Console.WriteLine("Sentiment: " + resultObj.Sentiment);

            Console.ReadLine();
        }
    }
}
