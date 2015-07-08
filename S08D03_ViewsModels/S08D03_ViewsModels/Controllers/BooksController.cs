using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S08D03_ViewsModels.Models;
using System.Data.Entity;

namespace S08D03_ViewsModels.Controllers
{
    
    public class BooksController : Controller
    {
        private S08D03_ViewsModelsContext db = new S08D03_ViewsModelsContext();
        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            Book book = db.Books.Find(id);
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid) {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            } else {
                return View(book);
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = db.Books.Find(id);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid) {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
