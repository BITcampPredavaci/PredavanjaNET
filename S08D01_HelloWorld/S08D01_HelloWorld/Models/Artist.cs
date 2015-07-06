using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S08D01_HelloWorld.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int BirthYear { get; set; }

        public string FullName { get { return Name + " " + Surname; } }

    }
}