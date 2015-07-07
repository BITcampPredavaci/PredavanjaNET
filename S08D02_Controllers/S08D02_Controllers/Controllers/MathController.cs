using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S08D02_Controllers.Controllers
{
    public class MathController : Controller
    {
        // GET: Math
        public ActionResult Index()
        {
            return View();
        }

        private bool IsPrime(int n)
        {
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        public ActionResult CheckPrime(int? number)
        {
            if (number != null) {
                ViewBag.IsPrime = IsPrime(number.Value);
            }
            return View();
        }

        public ActionResult PrimesInRange(int? start, int? end)
        {
            List<PrimeNumber> numbers = new List<PrimeNumber>();
            if (start != null && end != null) {
                for (int i = start.Value; i < end.Value; i++) {
                    numbers.Add(new PrimeNumber { Value = i, IsPrime = IsPrime(i) });
                }
            }
            ViewBag.Numbers = numbers;
            return View();
        }


    }

    public struct PrimeNumber
    {
        public int Value { get; set; }
        public bool IsPrime { get; set; }
    }
}