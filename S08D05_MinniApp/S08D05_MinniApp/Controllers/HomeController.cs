using S08D04_MiniApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using S08D05_MinniApp.Models;

namespace S08D04_MiniApp.Controllers
{
    public class HomeController : Controller
    {
       
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            //calculate total number of pages
            MicroPostViewModel posts;

            if (page == null) {
                posts = new MicroPostViewModel();
            } else {
                posts = new MicroPostViewModel(page.Value);
            }


            ViewBag.CategoryId =
                new SelectList(db.Categories, "CategoryId", "Name");
            
            return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}