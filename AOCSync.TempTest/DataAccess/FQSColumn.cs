using System;
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

namespace AOCSync.TempTest.DataAccesss
{
    public class FQSColumn
    {
        public static DataTable GetAOCFQSColumns()
        {
            string sql = @"SELECT     sys.syscolumns.name, sys.systypes.name AS type, sys.syscolumns.isnullable, sys.syscolumns.length
                                FROM         sys.syscolumns INNER JOIN
                                                      sys.systypes ON sys.syscolumns.xusertype = sys.systypes.xusertype
                                WHERE     (sys.syscolumns.id = OBJECT_ID('AOCFQS'))";

            DataSet ds = SqlHelper.ExecuteDataset(Common.ConnectStringMsSql.GetConnection(), CommandType.Text, sql);

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