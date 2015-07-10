using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using S08D04_MiniApp.Models;

namespace S08D05_MinniApp.Models
{
    public class MicroPostViewModel
    {
        public List<MicroPost> Posts { get; set; }

        public int Next { get; set; }

        public int Previous { get; set; }

        public int Current { get; set; }

        public int Last { get; set; }

        public Category Category { get; set; }

        private static int _postsPerPage = 2;

        private ApplicationDbContext db = new ApplicationDbContext();

        public MicroPostViewModel() : this(1)
        {}

        public MicroPostViewModel(int current)
        {
            int numberOfPages =
                (int)Math.Ceiling(db.MicroPosts.Count() / (double)_postsPerPage);

            int skip = 0;
            skip = _postsPerPage * (current - 1);

            Current = current;
            Previous = current > 1 ? current - 1 : 0;
            Next = current < numberOfPages ? current + 1 : 0;
            Last = numberOfPages;

            Posts = db.MicroPosts.
                OrderByDescending(x => x.MicroPostId)
                .Skip(skip)
                .Take(_postsPerPage)
                .ToList();

        }

        public MicroPostViewModel(int current, Category category)
        {
            int numberOfPages =
            (int)Math.Ceiling(db.MicroPosts.Where(x => x.CategoryId == category.CategoryId).Count() / (double)_postsPerPage);

            int skip = 0;
            skip = _postsPerPage * (current - 1);

            Current = current;
            Previous = current > 1 ? current - 1 : 0;
            Next = current < numberOfPages ? current + 1 : 0;
            Last = numberOfPages;

            Category = category;

            Posts = db.MicroPosts.
                OrderByDescending(x => x.MicroPostId)
                .Where(x => x.CategoryId == category.CategoryId)
                .Skip(skip)
                .Take(_postsPerPage)
                .ToList();
        }

    }
}