using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S09D02_SQLDay2.Models
{
    class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public List<PhoneNumber> PhoneNumbers { get; private set; }


        public bool SaveToDb()
        {
            string query = "";
            if (Id == 0)
                query = String.Format("INSERT INTO Contacts VALUES ('{0}','{1}');", Name, Surname);
            else
                query = String.Format("UPDATE Contacts SET Name = '{0}', Surname = '{1}' WHERE id = '{2}'; ", Name, Surname, Id);
            return DbConnection.ExecuteQuery(query);
        }


        public static Contact GetContact(int id)
        {
            string query =
                string.Format("SELECT * FROM Contacts WHERE id = '{0}';", id);

            List<object[]> result = 
                DbConnection.ExecuteQueryForResult(query);
            if (result == null || result.Count == 0)
                return null;

            object[] row = result.ElementAt(0);

            Contact contact = new Contact() {
                Id = (int)row[0],
                Name = (string)row[1],
                Surname = (string)row[2]
            };

            return contact;
        }

        public void AddNumber(string title, string number)
        {
            PhoneNumber pn = new PhoneNumber(Id, title, number);
            pn.SaveToDb();
            PhoneNumbers.Add(pn);
        }

        public override string ToString()
        {
            return String.Format("{0}: {1} {2}", Id, Name, Surname);
        }
    }
}
