using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S12D05_Servers.Models
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public override string ToString()
        {
            return String.Format("{0} {1}", Name, Age);
        }
    }
}
