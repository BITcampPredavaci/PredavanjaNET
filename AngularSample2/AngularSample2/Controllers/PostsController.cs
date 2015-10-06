using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AngularSample2.Models;
using Microsoft.AspNet.Identity;

namespace AngularSample2.Controllers
{
    public class PostsController : ApiController
    {


        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Posts
        public IHttpActionResult GetPosts(int? page)
        {
            int pageSize = 2;
            int skip = 0;
            if (page != null)
                skip = page.Value;

            List<Post> posts = db.Posts
                .OrderBy(x => x.Id)
                .Skip(skip * pageSize)
                .Take(pageSize)
                .ToList();

            bool hasNext = db.Posts.Count() > ((skip + 1) * pageSize);
            int next = skip + 1;

            return Ok(new PaginationResult()
            {
                Posts = posts,
                HasNext = hasNext,
                NextPage = next
            });
        }

        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(int id, Post post)
        {
            post.AuthorId = "e267323f-4a8d-4da0-ab75-a6d1bcbe6d28";
            this.Validate(post);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Posts
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(Post post)
        {
            post.AuthorId = "e267323f-4a8d-4da0-ab75-a6d1bcbe6d28";
            this.Validate(post);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            db.SaveChanges();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}