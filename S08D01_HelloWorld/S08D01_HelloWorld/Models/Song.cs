using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S08D01_HelloWorld.Models
{
    public class Song
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public double Length { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}