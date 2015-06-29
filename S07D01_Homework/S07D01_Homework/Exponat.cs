using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace S07D01_Homework
{
    public abstract class Exponat : IComparable, ISearchable {

        private static int EXPONAT_COUNT = 0;

        private int id;
        private string name;
        private string description;

        public Exponat(string name, string description)
        {
            this.name = name;
            this.description = description;
            this.id = ++EXPONAT_COUNT;
        }

        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int Id { get { return id; } }

        public override bool Equals(object obj)
        {
            if (obj is Exponat) {
                Exponat other = (Exponat)obj;
                return this.id == other.id;
            } else {
                return false;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}: Name: {1}\nDescription: {2}\n",
                id, name, description);
        }


        public int CompareTo(object obj)
        {
            if (obj is Exponat) {
                Exponat other = (Exponat)obj;
                return this.name.CompareTo(other.name);
            } else {
                throw new ArgumentException("Obj is not Exponat");
            }
        }

        public virtual ISearchable FitsSearch(string s)
        {
            throw new NotImplementedException();
        }
    }
}