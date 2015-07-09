using S08D04_MiniApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace S08D04_MiniApp.Controllers
{
    public class HomeController : Controller
    {
       
        private ApplicationDbContext db = new ApplicationDbContext();
        private static int _postsPerPage = 8;
        

        public ActionResult Index(int? page)
        {
            //calculate total number of pages
            int _numberOfPages = 
                (int)Math.Ceiling(db.MicroPosts.Count() / (double)_postsPerPage);
           
            int skip = 0;
           
            ViewBag.CurrentPage = 1;
            ViewBag.LastPage = _numberOfPages;

            if (page != null) {
                //calculate how many posts to skip
                skip = _postsPerPage * (page.Value - 1);
                ViewBag.CurrentPage = page.Value;
            }

            if (ViewBag.CurrentPage > 1)
                ViewBag.Previous = ViewBag.CurrentPage - 1;
            else
                ViewBag.Previous = null;

            if (ViewBag.CurrentPage < _numberOfPages)
                ViewBag.Next = ViewBag.CurrentPage + 1;
            else
                ViewBag.Next = null;
            

            var posts = db.MicroPosts
                .OrderByDescending(x => x.MicroPostId)
                .Skip(skip)
                .Take(_postsPerPage)
                .Include(m => m.Category)
                .ToList();

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