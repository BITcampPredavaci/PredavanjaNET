using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S08D03_ViewsModels.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [DisplayName("Ime")]
        [Required]
        public string FirstName { get; set; }
        [MinLength(3)]
        public string LastName { get; set; }

        [Range(18, 78)]
        public int Age { get; set; }

    }
}