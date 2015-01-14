using System;
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

namespace AOCSync.DataAccess
{
    public class AOC_CTRL
    {
        //TODO:modify columns




        public static DataRow GetAOCCTRLDataByDB(string mDB)
        {
            string sql = "SELECT * FROM [AOC_TEST].[dbo].[AOC_CTRL] WHERE DB = @mDB";

            DataSet ds = SqlHelper.ExecuteDataset(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, new SqlParameter("@mDB", mDB));

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static void UpdateAOCCTRLData(
            string mDB, Int64 itv, Int64 day
            )
        {
            string sql = @"UPDATE    [AOC_TEST].[dbo].[AOC_CTRL]
                    SET       ITV=@ITV,   DAY=@DAY  
                    WHERE     DB = @mDB";

            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@mDB", mDB);
            para[1] = new SqlParameter("@ITV", itv);
            para[2] = new SqlParameter("@DAY", day);

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }


        public static DataTable GetAOCCTRLData()
        {
            string sql = @"SELECT DB, ITV, DAY FROM [AOC_TEST].[dbo].[AOC_CTRL]";

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
