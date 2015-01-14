using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

namespace AOCSync.DataAccess
{
    public class User
    {
        public static DataRow GetUserByID(int userID)
        {
            string sql = "SELECT ID, UserName, UserPassword, FTPIP, FTPPort, FTPLogName, FTPPassword, FTPRemoteDir, FTPMode, ExportColumns, IsPack, ITVTime, AirportIATA, FlightNature FROM [AOC_User] WHERE ID = @logID";

            DataSet ds = SqlHelper.ExecuteDataset(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, new SqlParameter("@logID", userID));

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static void UpdateUser(int userID, string userName, string userPassword, string ftpIP, string ftpPort, string ftpLogName, string ftpPassword, string ftpRemoteDir, string ftpMode, string isPack, int itvTime, int airportIATA, string flightNature, string exportColumns)
        {
            string sql = @"UPDATE [AOC_User] SET UserName = @userName, UserPassword = @userPassword, FTPIP=@ftpIP, FTPPort=@ftpPort, FTPLogName = @ftpLogName, FTPPassword = @ftpPassword, FTPRemoteDir = @ftpRemoteDir, FTPMode = @ftpMode,
                                ExportColumns = @exportColumns, IsPack=@isPack, ITVTime=@itvTime, AirportIATA=@airportIATA, FlightNature=@flightNature WHERE ID = @userID";

            SqlParameter[] para = { new SqlParameter("@userName", userName), 
                                    new SqlParameter("@userPassword", userPassword), 
                                    new SqlParameter("@ftpIP", ftpIP), 
                                    new SqlParameter("@ftpPort", ftpPort), 
                                    new SqlParameter("@ftpLogName", ftpLogName), 
                                    new SqlParameter("@ftpPassword", ftpPassword), 
                                    new SqlParameter("@ftpRemoteDir", ftpRemoteDir),
                                    new SqlParameter("@ftpMode", ftpMode),
                                    new SqlParameter("@exportColumns", exportColumns),
                                    new SqlParameter("@isPack", isPack), 
                                    new SqlParameter("@iTVTime", itvTime), 
                                    new SqlParameter("@airportIATA", airportIATA), 
                                    new SqlParameter("@flightNature", flightNature), 
                                    new SqlParameter("@userID", userID) };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void UpdateUser(int userID, string userName, string userPassword, string ftpIP, string ftpPort, string ftpLogName, string ftpPassword, string ftpRemoteDir, string ftpMode, string isPack, int itvTime, int airportIATA, string flightNature, string exportColumns, SqlTransaction trans)
        {
            string sql = @"UPDATE [AOC_User] SET UserName = @userName, UserPassword = @userPassword, FTPIP=@ftpIP, FTPPort=@ftpPort, FTPLogName = @ftpLogName, FTPPassword = @ftpPassword, FTPRemoteDir = @ftpRemoteDir, FTPMode = @ftpMode, 
                               ExportColumns = @exportColumns, IsPack=@isPack, ITVTime=@itvTime, AirportIATA=@airportIATA, FlightNature=@flightNature WHERE ID = @userID";

            SqlParameter[] para = { new SqlParameter("@userName", userName), 
                                    new SqlParameter("@userPassword", userPassword), 
                                    new SqlParameter("@ftpIP", ftpIP), 
                                    new SqlParameter("@ftpPort", ftpPort), 
                                    new SqlParameter("@ftpLogName", ftpLogName), 
                                    new SqlParameter("@ftpPassword", ftpPassword), 
                                    new SqlParameter("@ftpRemoteDir", ftpRemoteDir),
                                    new SqlParameter("@ftpMode", ftpMode),
                                    new SqlParameter("@exportColumns", exportColumns),
                                    new SqlParameter("@isPack", isPack), 
                                    new SqlParameter("@iTVTime", itvTime), 
                                    new SqlParameter("@airportIATA", airportIATA), 
                                    new SqlParameter("@flightNature", flightNature), 
                                    new SqlParameter("@userID", userID) };

            if (trans != null)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, para);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
            }
        }

        public static void InsertUser(string userName, string userPassword, string ftpIP, string ftpPort, string ftpLogName, string ftpPassword, string ftpRemoteDir, string ftpMode, string isPack, int itvTime, int airportIATA, string flightNature, string exportColumns)
        {
            string sql = @"INSERT INTO [AOC_User] (UserName, UserPassword, FTPIP, FTPPort, FTPLogName, FTPPassword, FTPRemoteDir, FTPMode, IsPack, ITVTime, AirportIATA, FlightNature, ExportColumns) VALUES 
                                (@userName, @userPassword, @ftpIP, @ftpPort, @ftpLogName, @ftpPassword, @ftpRemoteDir, @ftpMode,  @isPack, @itvTime, @airportIATA, @flightNature, @exportColumns)";

            SqlParameter[] para = { new SqlParameter("@userName", userName), 
                                    new SqlParameter("@userPassword", userPassword), 
                                    new SqlParameter("@ftpIP", ftpIP), 
                                    new SqlParameter("@ftpPort", ftpPort), 
                                    new SqlParameter("@ftpLogName", ftpLogName), 
                                    new SqlParameter("@ftpPassword", ftpPassword),
                                    new SqlParameter("@ftpRemoteDir", ftpRemoteDir),
                                    new SqlParameter("@ftpMode", ftpMode),
                                    new SqlParameter("@isPack", isPack), 
                                    new SqlParameter("@itvTime", itvTime), 
                                    new SqlParameter("@airportIATA", airportIATA), 
                                    new SqlParameter("@flightNature", flightNature), 
                                    new SqlParameter("@exportColumns", exportColumns) };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void InsertUser(string userName, string userPassword, string ftpIP, string ftpPort, string ftpLogName, string ftpPassword, string ftpRemoteDir, string ftpMode, string isPack, int itvTime, int airportIATA, string flightNature, string exportColumns, SqlTransaction trans)
        {
            string sql = @"INSERT INTO [AOC_User] (UserName, UserPassword, FTPIP, FTPPort, FTPLogName, FTPPassword, FTPRemoteDir, FTPMode, IsPack, ITVTime, AirportIATA, FlightNature, ExportColumns) VALUES 
                                (@userName, @userPassword, @ftpIP, @ftpPort, @ftpLogName, @ftpPassword, @ftpRemoteDir, @ftpMode,  @isPack, @itvTime, @airportIATA, @flightNature, @exportColumns)";

            SqlParameter[] para = { new SqlParameter("@userName", userName), 
                                    new SqlParameter("@userPassword", userPassword), 
                                    new SqlParameter("@ftpIP", ftpIP), 
                                    new SqlParameter("@ftpPort", ftpPort), 
                                    new SqlParameter("@ftpLogName", ftpLogName), 
                                    new SqlParameter("@ftpPassword", ftpPassword),
                                    new SqlParameter("@ftpRemoteDir", ftpRemoteDir),
                                    new SqlParameter("@ftpMode", ftpMode),
                                    new SqlParameter("@isPack", isPack), 
                                    new SqlParameter("@itvTime", itvTime), 
                                    new SqlParameter("@airportIATA", airportIATA), 
                                    new SqlParameter("@flightNature", flightNature), 
                                    new SqlParameter("@exportColumns", exportColumns) };

            if (trans != null)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, para);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
            }
        }

        public static void DeleteUser(int userID)
        {
            string sql = "DELETE FROM [AOC_User] WHERE ID = @userID";

            SqlParameter[] para = { new SqlParameter("@userID", userID) };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void DeleteUser(int userID, SqlTransaction trans)
        {
            string sql = "DELETE FROM [AOC_User] WHERE ID = @userID";

            SqlParameter[] para = { new SqlParameter("@userID", userID) };

            if (trans != null)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, para);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
            }
        }

        public static DataTable GetUsers()
        {
            string sql = @"SELECT ID, UserName, UserPassword, FTPIP, FTPPort, FTPLogName, FTPPassword, FTPRemoteDir, FTPMode, IsPack, ITVTime, AirportIATA, FlightNature, ExportColumns FROM [AOC_User] ORDER BY ID";

            DataSet ds = SqlHelper.ExecuteDataset(ConnectStringMsSql.GetConnection(), CommandType.Text, sql);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }
    }
}
