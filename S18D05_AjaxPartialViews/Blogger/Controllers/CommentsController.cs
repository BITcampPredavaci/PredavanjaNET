using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Blogger.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Blogger.Controllers
{
    public class CommentsController : Controller
    {
        // GET: /<controller>/
        [HttpPostAttribute]
        public IActionResult Create(Comment comment)
        {
            PostsController.CurrentPost.Comments.Add(comment);
            return PartialView("_Comment", comment);
        }
    }
}
