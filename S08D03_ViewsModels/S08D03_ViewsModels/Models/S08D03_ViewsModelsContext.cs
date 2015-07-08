using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S08D03_ViewsModels.Models
{
    public class S08D03_ViewsModelsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public S08D03_ViewsModelsContext() : base("name=S08D03_ViewsModelsContext")
        {
        }

        public System.Data.Entity.DbSet<S08D03_ViewsModels.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<S08D03_ViewsModels.Models.Book> Books { get; set; }

    }
}
