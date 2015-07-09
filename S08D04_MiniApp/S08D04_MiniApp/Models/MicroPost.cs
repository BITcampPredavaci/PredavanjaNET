using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S08D04_MiniApp.Models
{
    public class MicroPost
    {
        public int MicroPostId { get; set; }

        [MaxLength(20)]
        [MinLength(5)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(200)]
        public string Content { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        
        public virtual Category Category { get; set; }
    }
}