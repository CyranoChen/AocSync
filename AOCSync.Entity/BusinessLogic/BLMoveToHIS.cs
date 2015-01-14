using System;
using System.Collections.Generic;
using AOCSync.Entity;
using AOCSync.Entity.Tools;
using System.Data.SqlClient;
namespace AOCSync.Entity
{
    public class BLMoveToHIS
    {
        public static void MoveCCToHis(DateTime dateTime, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
            DateTime dateTimeEnd = dateTime.Date.AddDays(AOCConfig.INTERVALEVENTHISTORYBEFORE);            
            string dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");
             
             List<AOCDataCC> aocDataCCList = AOCDataCC.Cache.AOCDataList.FindAll(delegate(AOCDataCC aocdataInList)
                {
                    return aocdataInList.STOD.CompareTo(dtEnd) < 0;
                }
            );
             if (aocDataCCList.Count>0)
            {
                using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
                {
                    connSql.Open();
                    SqlTransaction trans = connSql.BeginTransaction();
                    try
                    {
                        msgSyncOut=string.Format("CC CountMove={0}",aocDataCCList.Count);
                        AOCDataCCHIS.GenerateAOCDataCCHISByAOCData(aocDataCCList,trans);
                        AOCDataCC.DeleteAOCDataCCByDateTime(dateTimeEnd, trans);
                        trans.Commit();                    
                        AOCDataCC.Cache.RefreshCache();     

                    }
                    catch (Exception exSql)
                    {
                	     trans.Rollback();
                         msgSyncOut=exSql.Message.ToString();
                    }
                    finally
                    {
                        connSql.Close();
                    }
                 }
            }
            else
                msgSyncOut = "CC no data to move";
                  
        }
         public static void MoveFQSToHis(DateTime dateTime, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
             DateTime dateTimeEnd = dateTime.Date.AddDays(AOCConfig.INTERVALEVENTHISTORYBEFORE);            
            string dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");
            List<AOCDataFQS> aocDataFQSList = AOCDataFQS.Cache.AOCDataList.FindAll(delegate(AOCDataFQS aocdataInList)
                {
                    return aocdataInList.STOD.CompareTo(dtEnd) < 0 || aocdataInList.SDT.CompareTo(dtEnd) < 0;               
                }
            );
            if (aocDataFQSList.Count > 0)
            {
                using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
                {
                    connSql.Open();
                    SqlTransaction trans = connSql.BeginTransaction();
                    try
                    {
                        msgSyncOut = string.Format("FQS CountMove={0}", aocDataFQSList.Count);
                        AOCDataFQSHIS.GenerateAOCDataFQSHISByAOCDataFQS(aocDataFQSList, trans);
                        AOCDataFQS.DeleteAOCDataFQSByDateTime(dateTimeEnd, trans);
                        trans.Commit();
                        AOCDataFQS.Cache.RefreshCache();
                    }
                    catch (Exception exSql)
                    {
                        trans.Rollback();
                        msgSyncOut = exSql.Message.ToString();
                    }
                    finally
                    {
                        connSql.Close();
                    }
                }
            }
            else
                msgSyncOut = "FQS no data to move";
        }
    }
}
