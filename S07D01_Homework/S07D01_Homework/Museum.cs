using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07D01_Homework
{
    class Museum
    {
        private List<Exponat> exponates;
        private List<Employee> employees;

        public Museum()
        {
            this.exponates = new List<Exponat>();
            this.employees = new List<Employee>();
        }

        public List<Exponat> Exponates { get { return exponates; } }

        public void AddExponat(Exponat e)
        {
            exponates.Add(e);
            exponates.Sort();
        }

        public void AddEmployee(Employee e)
        {
            employees.Add(e);
            employees.Sort();
        }

        public List<ISearchable> Find(string s)
        {
            List<ISearchable> everything = new List<ISearchable>(employees);
            everything.AddRange(exponates);
            List<ISearchable> results = new List<ISearchable>();
            foreach (ISearchable e in everything) {
                if (e.FitsSearch(s) != null)
                    results.Add(e);
            }
            return results;
        }

    }
}
