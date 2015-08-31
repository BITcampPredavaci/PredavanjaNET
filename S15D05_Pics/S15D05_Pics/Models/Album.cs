using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S15D05_Pics.validators;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace S15D05_Pics.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        [Remote("CheckAlbumName", "Albums")]
        public string Name { get; set; }
        [PriceValidator(0, 10)]
        public double Price { get; set; }
        public string CoverUrl { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
