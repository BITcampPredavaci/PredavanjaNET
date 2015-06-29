using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07D01_Homework
{
    class Employee : ISearchable, IComparable
    {
        private string name;
        private string lastName;

        public Employee(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        public string FullName { get { return name + " " + lastName } }
        public override string ToString()
        {
            return String.Format("{0} {1}", name, lastName);
        }


        public ISearchable FitsSearch(string s)
        {
            if (this.name.Contains(s) || this.lastName.Contains(s))
                return this;
            else
                return null;
        }

        public int CompareTo(object obj)
        {
            if (obj is Employee) {
                Employee other = (Employee)obj;
                return this.FullName.CompareTo(other.FullName);
            } else {
                throw new ArgumentException();
            }
        }
    }
}
