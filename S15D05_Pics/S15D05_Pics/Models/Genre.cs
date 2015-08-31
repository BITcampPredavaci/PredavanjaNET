using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S15D05_Pics.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}
