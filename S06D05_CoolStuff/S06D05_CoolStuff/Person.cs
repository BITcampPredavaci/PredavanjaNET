using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace S06D05_CoolStuff
{
    public class Person {


        private string name;
        private string surname;
        private int age;

        public int Id { get; set; }
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public int Age { get { return age; } set { age = value; } }

        public Person()
        {}

        public Person(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }


        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}", Id, name, surname, age);
        }

    }
}