using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S08D04_MiniApp.Models;
using S08D05_MinniApp.Models;

namespace S08D04_MiniApp.Controllers
{
   
    public class MicroPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MicroPosts
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: MicroPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MicroPost microPost = db.MicroPosts.Find(id);
            if (microPost == null)
            {
                return HttpNotFound();
            }
            return View(microPost);
        }

        // GET: MicroPosts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = 
                new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: MicroPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "MicroPostId,Title,Content,CategoryId,ImageUrl")] MicroPost microPost)
        {
            if (ModelState.IsValid)
            {
                db.MicroPosts.Add(microPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", microPost.CategoryId);
            return View(microPost);
        }

        // GET: MicroPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MicroPost microPost = db.MicroPosts.Find(id);
            if (microPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", microPost.CategoryId);
            return View(microPost);
        }

        // POST: MicroPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MicroPostId,Title,Content,CategoryId,ImageUrl")] MicroPost microPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(microPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", microPost.CategoryId);
            return View(microPost);
        }

        // GET: MicroPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MicroPost microPost = db.MicroPosts.Find(id);
            if (microPost == null)
            {
                return HttpNotFound();
            }
            return View(microPost);
        }

        // POST: MicroPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MicroPost microPost = db.MicroPosts.Find(id);
            db.MicroPosts.Remove(microPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
