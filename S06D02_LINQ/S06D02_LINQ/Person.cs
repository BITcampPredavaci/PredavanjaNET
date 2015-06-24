using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D02_LINQ
{
    class Person
    {

        private string name;
        private string lastName;
        private int age;

        public Person(string name, string lastName, int age)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
        }

        public string Name { get { return name; } }

        public string LastName { get { return lastName; } }
        public int Age { get { return age; } set { age = value; } }


        public override string ToString()
        {
            return String.Format("Name: {0}, Surname: {1}", name, lastName);
        }

    }
}
