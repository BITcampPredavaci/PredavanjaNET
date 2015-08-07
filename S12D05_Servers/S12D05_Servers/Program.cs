using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S12D05_Servers
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server("http://localhost:8888/");
            s.Start();
            while (true)
            {
                s.AcceptConnection();
            }
        }
    }
}
