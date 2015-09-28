using System.Linq;
using Microsoft.AspNet.Mvc;
using Blogger.Models;

namespace Blogger.Controllers
{
    public class CommentsController : Controller
    {
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
