using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S12D05_Servers.Models;

namespace S12D05_Servers.Controllers
{
    class People
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public string Add()
        {
            return ActionResult.View("People/Add.html");
        }

        public string Create(string name, int age)
        {
            Person p = new Person() { Name = name, Age = age };
            db.People.Add(p);
            db.SaveChanges();
            return String.Format("Name: {0}, Age: {1}", name, age);
        }

    }
}
