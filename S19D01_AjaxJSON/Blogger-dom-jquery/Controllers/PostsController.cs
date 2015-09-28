using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Blogger.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Blogger.Controllers
{
    public class PostsController : Controller
    {
        public static Post CurrentPost = new Post() {
            Id = 1,
            Title = "Hello, world!",
            Body = "This is my first post on Blogger!",
            Comments = new List<Comment>() {
                new Comment() {
                    Id = 1,
                    Body = "First!!!1"
                },
                new Comment() {
                    Id = 2,
                    Body = "Very good post, visit my blog!"
                }
            }
        };
            
        // GET: /<controller>/
        public IActionResult Details(int id)
        {
            return View(CurrentPost);
        }
    }
}
