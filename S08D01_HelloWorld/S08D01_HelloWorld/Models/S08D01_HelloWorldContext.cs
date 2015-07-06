using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S08D01_HelloWorld.Models
{
    public class S08D01_HelloWorldContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public S08D01_HelloWorldContext() : base("name=S08D01_HelloWorldContext")
        {
        }

        public System.Data.Entity.DbSet<S08D01_HelloWorld.Models.Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<S08D01_HelloWorld.Models.Song> Songs { get; set; }
    
    }
}
