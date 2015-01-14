using System.Configuration;
using System.Data.SqlClient;

namespace AOCSync.DataAccess
{
    public class ConnectStringMsSql
    {
        public static SqlConnection GetConnection()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["SqlServer.AOC.ConnectionString"].ConnectionString;//ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        
    }
}
