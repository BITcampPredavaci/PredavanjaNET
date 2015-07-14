using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S09D02_SQLDay2.Models
{

    class DbConnection
    {
        private static string connectionString =
            @"Data source=(localdb)\v11.0; Initial catalog=S09D02_SQLDay2; Integrated security=true;";
        private static SqlConnection connection = new SqlConnection(connectionString);
        private static SqlCommand command = new SqlCommand();


        public static bool ExecuteQuery(string query)
        {
            try {
                connection.Open();
                command.Connection = connection;
                command.CommandText = query;
                
                //command.ExecuteScalar
                return command.ExecuteNonQuery() > 0;
            }
            catch {
                return false;
            }
            finally {
                connection.Close();
            }
        }


        public static List<object[]> ExecuteQueryForResult(string query)
        {
            try {
                connection.Open();
                command.Connection = connection;
                command.CommandText = query;

                SqlDataReader reader = command.ExecuteReader();
                List<object[]> results = new List<object[]>();

                while (reader.Read()) {
                    object[] row = new object[reader.FieldCount];
                    reader.GetValues(row);
                    results.Add(row);
                }

                return results;

            }
            catch {
                return null;
            }
            finally {
                connection.Close();
            }
        }
    }
}
