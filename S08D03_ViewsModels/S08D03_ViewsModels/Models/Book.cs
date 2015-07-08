using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S08D03_ViewsModels.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [DisplayName("Naziv")]
        public string Title { get; set; }

        [Range(1, 100)]
        public int Price { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}