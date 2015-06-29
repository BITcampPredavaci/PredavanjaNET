using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07D01_Homework
{
    class Program
    {
        public static void PrintExponates(Museum m)
        {
            foreach (Exponat e in m.Exponates) {
                Console.WriteLine(e);
            }
        }

        static void PrintSearchResults(Museum m, string s)
        {
            List<ISearchable> res = m.Find(s);
            foreach (ISearchable r in res) {
                Console.WriteLine(r);
            }
        }

        static void Main(string[] args)
        {
            Museum m = new Museum();
            Painting p = new Painting("Rodenje Rijada",
                "Rijad u skoljci, a oko njega flora i fauna",
                "Da Rijad", (Painting.Period)1);

            Artifact a = new Artifact("Keyboard", "Keyboard of the first camper", "IUS", Artifact.Period.MiddleAge);

            m.AddExponat(p);
            m.AddExponat(a);

            Employee rijad = new Employee("Rijad", "Memic");
            Employee other = new Employee("Dajir", "Mimem");

            m.AddEmployee(rijad);
            m.AddEmployee(other);

            PrintExponates(m);

            Console.WriteLine("===========");
            PrintSearchResults(m, "Rijad");
            
        }
    }
}
