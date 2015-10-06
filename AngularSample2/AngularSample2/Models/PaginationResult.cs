using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularSample2.Models
{
    public class PaginationResult
    {

        public List<Post> Posts { get; set; }

        public bool HasNext { get; set; }

        public int NextPage { get; set; }

    }
}
