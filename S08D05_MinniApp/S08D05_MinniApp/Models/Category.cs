using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S08D04_MiniApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }


        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
    }
}