using System;

namespace PhoneBook
{
    public class Program
    {
       
        static void AddContact(Phonebook book){
            System.Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            System.Console.WriteLine("Enter surname: ");
            string surname = Console.ReadLine();
            System.Console.WriteLine("Enter number: ");
            string number = Console.ReadLine();
            
            book.AddContact(name, number, surname);  
        }
        
        static void ListContacts(Phonebook book){
            Console.WriteLine("Contacts: ");
            foreach(Contact c in book.AllContacts){
                Console.WriteLine(c);
            }
        }
        
        static void RemoveContact(Phonebook book){
            System.Console.WriteLine("ID of contact to remove: ");
            int id = int.Parse(Console.ReadLine());
            book.Remove(id);
         }

        public static void Main(string[] args)
        {
          Phonebook book = new Phonebook();
          
          while(true){
            
            Console.WriteLine("Enter 1 to list contacts: ");
            Console.WriteLine("Enter 2 to add a contact");
            Console.WriteLine("Enter 3 to remove contact");
            
            int choice = int.Parse(Console.ReadLine());
            
            switch(choice) {
                
                case 1:
                    ListContacts(book);
                    break;
                case 2:
                    AddContact(book);
                    break;
                    
                case 3:
                    RemoveContact(book);
                    break;
                    
                default:
                    Console.WriteLine("Invalid input");
                    break;
                
                
            }
                
          }
          
        }
    }
}
