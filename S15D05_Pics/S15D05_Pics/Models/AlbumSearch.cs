using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S15D05_Pics.Models
{
    public class AlbumSearch
    {
        public string Name { get; set; }
        [Range(1, 10)]
        public double Price { get; set; }
        [Range(1, int.MaxValue)]
        public int ArtistId { get; set; }
        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }
    }
}
