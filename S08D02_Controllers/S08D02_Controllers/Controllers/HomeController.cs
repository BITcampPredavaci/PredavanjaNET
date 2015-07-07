using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S08D02_Controllers.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public string About()
        {
            return "Getting into controllers";
        }

        public string Greeting(int id)
        {
            string output = "";
            for (int i = 0; i < id; i++)
                output += "Hello World<br />";
            return output;
        }

        public string OperationAPI(int? a, int? b, string isMultiplication)
        {
           
            if (isMultiplication == null) {
                return (a + b).ToString();
            } else {
                return (a * b).ToString();
            }
        }

        public ActionResult Sum(int? a, int? b, string isMultiplication)
        {
            ViewBag.a = a;
            ViewBag.b = b;
            if (isMultiplication == null) {
                ViewBag.Result = a + b;
            } else {
                ViewBag.Result = a * b;
            }
            return View();
        }
    }
}