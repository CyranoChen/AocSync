using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

namespace AOCSync.DataAccess
{
    public class Log
    {
        public static DataRow GetLogEventByID(int logID)
        {
            string sql = "SELECT ID, EventType, Message, ErrorStackTrace, EventDate, ErrorParam FROM dbo.AOC_LogEvent WHERE ID = @logID";

            DataSet ds = SqlHelper.ExecuteDataset(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, new SqlParameter("@logID", logID));

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static void UpdateLogEvent(int logID, string eventType, string message, string errorStackTrace, string errorParam)
        {
            string sql = "UPDATE dbo.AOC_LogEvent SET EventType = @eventType, Message = @message, ErrorStackTrace = @errorStackTrace, ErrorParam = @errorParam WHERE ID = @logID";

            SqlParameter[] para = { new SqlParameter("@eventType", eventType), new SqlParameter("@message", message), new SqlParameter("@errorStackTrace", errorStackTrace), new SqlParameter("@errorParam", errorParam), new SqlParameter("@logID", logID) };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void InsertLogEvent(string eventType, string message, string errorStackTrace, string errorParam)
        {
            string sql = "INSERT INTO dbo.AOC_LogEvent (EventType, Message, ErrorStackTrace, EventDate, ErrorParam) VALUES (@eventType, @message, @errorStackTrace, GETDATE(), @errorParam)";

            SqlParameter[] para = { new SqlParameter("@eventType", eventType), new SqlParameter("@message", message), new SqlParameter("@errorStackTrace", errorStackTrace), new SqlParameter("@errorParam", errorParam) };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void DeleteLogEvent(int logID)
        {
            string sql = "DELETE FROM AOC_LogEvent WHERE ID = @logID";

            SqlParameter[] para = { new SqlParameter("@logID", logID) };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static DataTable GetLogEvents()
        {
            string sql = @"SELECT ID, EventType, Message, ErrorStackTrace, EventDate, ErrorParam FROM dbo.AOC_LogEvent ORDER BY EventDate DESC";

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
