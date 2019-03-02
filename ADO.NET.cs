using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

class Program
{
    public static class Database
    {
        //private static string connectionString = "Server=.;Database=DataBase;User Id=username;Password=password;";
        private static string connectionString = "Server=.;Database=Database;Trusted_Connection=True;";

        public static IList<IDictionary<string, object>> Select(string query, IDictionary<string, object> parameters = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);

                if (parameters != null) { parameters.ToList().ForEach(x => command.Parameters.AddWithValue(x.Key, x.Value)); }

                connection.Open();

                var reader = command.ExecuteReader();

                var rows = new List<IDictionary<string, object>>();

                while (reader.Read())
                {
                    var columns = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columns.Add(reader.GetName(i), reader[i]);
                    }

                    rows.Add(columns);
                }

                return rows;
            }
        }
    }

    public class User
    {
        public long UserId { get; set; }

        public string Name { get; set; }
    }

    static void Main(string[] args)
    {
        var query = "SELECT * FROM [User].[Users] WHERE UserId = @UserId";

        var parameters = new Dictionary<string, object> { { "UserId", 1 } };

        var result = Database.Select(query, parameters);
    }
}