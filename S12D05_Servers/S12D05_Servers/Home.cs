using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S12D05_Servers
{
    class Home
    {
        public string Math()
        {

            return "<form method='post' action='/Home/Add' >"
                   + "<input type='number' name='a' />"
                   + "<input type='number' name='b' />"
                    + " <input type='submit' value='Submit' />"
                    + " </form> ";

        }
        public string Add(int a, int b)
        {
            return (a + b).ToString();
        }

        public string Index()
        {
            return "<h1> Welcome to Bit </h1>";
        }

    }
}
