using S09D02_SQLDay2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S09D02_SQLDay2
{
    class Program
    {

        private static void OldCode()
        {
            string query = "SELECT * FROM Contacts";
            string insertQuery = "INSERT INTO Contacts VALUES ('Rijad', 'Memic');";

            Contact cont = Contact.GetContact(3);
            cont.Name = "E nije Rijad";
            cont.SaveToDb();

            List<Contact> contacts = new List<Contact>();

            List<object[]> results = DbConnection.ExecuteQueryForResult(query);

            foreach (object[] row in results) {
                /*object[] row = new object[reader.FieldCount];
                reader.GetValues(row);*/

                Contact contact = new Contact() {
                    Id = (int)row[0],
                    Name = (string)row[1],
                    Surname = (string)row[2]
                };
                contacts.Add(contact);
            }

            foreach (Contact c in contacts) {
                Console.WriteLine(c);
            }
        }
        static void Main(string[] args)
        {
            
           
            try {
                PhoneNumber num = new PhoneNumber(2, "Home", "1233456");
                num.SaveToDb();

                Console.WriteLine(PhoneNumber.GetPhoneNumber(2));
               
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
