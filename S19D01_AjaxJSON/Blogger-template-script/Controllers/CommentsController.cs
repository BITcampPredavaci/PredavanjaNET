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
            var maxId = PostsController.CurrentPost.Comments
                .Select(c => c.Id)
                .DefaultIfEmpty()
                .Max();
                
            comment.Id = maxId + 1;
            PostsController.CurrentPost.Comments.Add(comment);
            return Json(comment);
        }
        
        [HttpPostAttribute]
        public IActionResult Delete(int id)
        {
            var comment = PostsController.CurrentPost.Comments
                .Where(c => c.Id == id)
                .FirstOrDefault();
            
            if (comment != null) {
                PostsController.CurrentPost.Comments.Remove(comment);   
            }
            
            return Json(new {});    
        }
    }
}
