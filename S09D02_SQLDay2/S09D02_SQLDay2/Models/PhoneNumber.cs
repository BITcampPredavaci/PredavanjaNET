using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S09D02_SQLDay2.Models
{
    class PhoneNumber
    {
        public int Id { get; set; }

        public int ContactId { get; private set; }

        public string Title { get; set; }

        public string Number { get; set; }

        public PhoneNumber()
        {}

        public PhoneNumber(int contactId, string title, string number)
        {
            ContactId = contactId;
            Title = title;
            Number = number;
        }

        public bool SaveToDb()
        {
            string query = "";
            if (Id == 0) {
                query =
                    String.Format("INSERT INTO PhoneNumbers VALUES ('{0}', '{1}', '{2}');", ContactId, Number, Title);
            } else {
                query =
                    String.Format("UPDATE PhoneNumbers SET Title = '{0}', Number = '{1}' WHERE id = '{2}' ;", Title, Number, Id);
            }

            return DbConnection.ExecuteQuery(query);
        }

        public static PhoneNumber GetPhoneNumber(int id)
        {
            string query = String.Format("SELECT * FROM PhoneNumbers WHERE id = '{0}'; ", id);

            List<object[]> result = DbConnection.ExecuteQueryForResult(query);
            if (result == null || result.Count == 0)
                return null;

            object[] row = result.ElementAt(0);

            PhoneNumber pn = new PhoneNumber() {
                Id = (int)row[0],
                ContactId = (int)row[1],
                Number = (string)row[2],
                Title = (string)row[3]
            };
            return pn;
        }


        public override string ToString()
        {
            return String.Format("{0}: {1} - {2}", Id, Title, Number);
        }
    }
}
