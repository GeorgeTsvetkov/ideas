using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ideas.Data
{
    internal class Database
    {
        private static string connectionString = "Server=.\\SQLEXPRESS; Database=product; Integrated Security=true";
        public static SqlConnection GetConnection() => new SqlConnection(connectionString);
    }
}
