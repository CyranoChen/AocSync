using System.Configuration;
using System.Data.OracleClient;

namespace AOCSync.DataAccess
{
    public class ConnectStringOracle
    {
        public static string getStrConnectionCallCenter()
        {
            return ConfigurationManager.ConnectionStrings["Oracle.CallCenter.ConnectionString"].ConnectionString;
        }

        public static string getStrConnectionFlightQuerySystem()
        {
            return ConfigurationManager.ConnectionStrings["Oracle.FlightQuerySystem.ConnectionString"].ConnectionString;
        }
    }
}
