using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S15D05_Pics.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace S15D05_Pics.Controllers
{
    public class AlbumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Albums
        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Artist).Include(a => a.Genre);
            return View(albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,Name,Price,CoverUrl,ArtistId,GenreId")] Album album)
        {
            if (ModelState.IsValid)
            {
                if(HandleFileUpload(ref album))
                {
                    db.Albums.Add(album);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return View(album);

        }
        private string[] _allowedTypes = new string[] {"image/jpeg", "image/jpg", "image/png" };
        private bool HandleFileUpload(ref Album album)
        {
            string filePath = @"~\Content\albumart.jpg";
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                if (file.ContentLength > 0 && _allowedTypes.Contains(file.ContentType))
                {
                    try {
                        using (var bitmap = new Bitmap(file.InputStream))
                        {
                        }
                    } catch
                    {
                        ModelState.AddModelError("CoverUrl", "The file type is not supported");
                        return false;
                    }

                    string fileName = Path.GetFileName(file.FileName);
                    filePath = Path.Combine(@"~\Content\Uploads", fileName);
                    string fullPath = Path.Combine(Server.MapPath(@"~\Content\Uploads"), fileName);
                    file.SaveAs(fullPath);
                } else
                {
                    if (file.ContentLength > 0 && !_allowedTypes.Contains(file.ContentType))
                    {
                        ModelState.AddModelError("CoverUrl", "The file type is not supported");
                        return false;
                    }

                }
            }
            album.CoverUrl = filePath;
            return true;
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,Name,Price,CoverUrl,ArtistId,GenreId")] Album album)
        {
            if (ModelState.IsValid)
            {
                if (!HandleFileUpload(ref album))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.ExpectationFailed);
                }
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public JsonResult CheckAlbumName(string name)
        {
            bool result = db.Albums.Count(al => al.Name == name) == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
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
