using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S06D05_CoolStuff
{
    class Program
    {

        static void AddPerson(ApplicationDbContext ac)
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            ac.People.Add(new Person(name, surname, age));
            ac.SaveChangesAsync();
        }

        static void ListPeople(ApplicationDbContext ac){
            foreach (Person p in ac.People) {
                Console.WriteLine(p);
            }
        }

        static void RemovePerson(ApplicationDbContext ac)
        {
            Console.WriteLine("Enter Id: ");
            int id = int.Parse(Console.ReadLine());
            Person toRemove = ac.People.Single(x => x.Id == id);
            ac.People.Remove(toRemove);
            ac.SaveChanges();
        }

        static void Main(string[] args)
        {
            ApplicationDbContext ac = new ApplicationDbContext();

            while (true) {
                Console.WriteLine("Enter 1 to add");
                Console.WriteLine("Enter 2 to list");
                Console.WriteLine("Enter 4 to remove person");

                int pick = int.Parse(Console.ReadLine());

                switch (pick) {
                    case 1:
                        AddPerson(ac);
                        break;
                    case 2:
                        ListPeople(ac);
                        break;
                    case 3:
                        RemovePerson(ac);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                };



            }
        }
    }
}
