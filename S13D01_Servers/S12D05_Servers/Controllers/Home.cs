using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using S12D05_Servers.Models;
using System.Collections.Specialized;

namespace S12D05_Servers.Controllers
{
    class Home
    {
        private ApplicationDbContext db = new ApplicationDbContext();
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
            StringBuilder sb = new StringBuilder();
            db.People.ToList().ForEach(person =>
            {
                sb.Append(person.ToString());
            });
            NameValueCollection data = new NameValueCollection();
            data.Add("<%LIST_PEOPLE%>", sb.ToString());
            return ActionResult.View("Home/Index.html", data);
        }

    }
}
