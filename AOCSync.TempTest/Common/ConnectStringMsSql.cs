using System.Configuration;
using System.Data.SqlClient;

namespace AOCSync.TempTest.Common
{
    public class ConnectStringMsSql
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=(localdb)\\Projects;Initial Catalog=AOCSync;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            return new SqlConnection(connectionString);
        }
    }
}
