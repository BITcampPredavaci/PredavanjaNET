using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace S06D05_CoolStuff
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
