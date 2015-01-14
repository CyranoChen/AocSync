using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using AOCSync.Entity.AOCEnum;
using AOCSync.Entity.Tools;

namespace AOCSync.Entity
{
    public class BLFlightQuerySystemSyncTOAOC
    {
        /// <summary>
        /// 轮询同步，从FlightQuerySystem库同步航班到AOCFQS库(不用)
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncFlightQuerySystemToAOCFQSITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
            //初始化count记录,count用于记录操作结果,分别为操作总数，插入总数，更新总数
            int countList = int.MinValue;
            int countInsert = int.MinValue;
            int countUpdate = int.MinValue;
            string msgSync = string.Empty;
            //初始化当前方法信息
            string nameFunction = TextTool.GetFunctionInfo();
            //初始化轮询同步的同步时间范围
            DateTime dateTimeStart = dateTimeCheckPoint.AddHours(AOCConfig.INTERVALEVENTBEFORE);
            DateTime dateTimeEnd = dateTimeCheckPoint.AddHours(AOCConfig.INTERVALEVENTAFTER);

            try
            {
                //获取FlightQuerySystem库中符合时间范围的所有虹桥机场航班
                List<FlightQuerySystemData> fqsDataList = FlightQuerySystemData.GetFlightQuerySystemData(dateTimeStart, dateTimeEnd);

                //将获取到的航班同步到AOC库中
                if (fqsDataList != null && fqsDataList.Count > 0)
                {
                    //BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataITV(fqsDataList, out countList, out countInsert, out countUpdate);
                    BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataITV(dateTimeCheckPoint, fqsDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;
                    AOCLog.logSuccess(msgSync);

                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataFQS.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception ex)
            {
                msgSync = AOCLog.GenerateParamsErroForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                msgSyncOut += ex.Message.ToString();
                AOCLog.logErro(ex, msgSync);
            }
        }

        /// <summary>
        /// 轮询同步，从FlightQuerySystem库同步航班到AOCFQS库
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncFlightQuerySystemToAOCFQSSimpleITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
            //初始化count记录,count用于记录操作结果,分别为操作总数，插入总数，更新总数
            int countList = int.MinValue;
            int countInsert = int.MinValue;
            int countUpdate = int.MinValue;
            string msgSync = string.Empty;
            //初始化当前方法信息
            string nameFunction = TextTool.GetFunctionInfo();
            //初始化轮询同步的同步时间范围
            DateTime dateTimeStart = dateTimeCheckPoint.AddHours(AOCConfig.INTERVALEVENTBEFORE);
            DateTime dateTimeEnd = dateTimeCheckPoint.AddHours(AOCConfig.INTERVALEVENTAFTER);

            try
            {
                //获取FlightQuerySystem库中符合时间范围的所有虹桥机场航班
                DateTime t1 = DateTime.Now;
                List<FlightQuerySystemData> fqsDataList = FlightQuerySystemData.GetFlightQuerySystemData(dateTimeStart, dateTimeEnd);
                msgSyncOut += "load from FlightQuerySystemData " + fqsDataList.Count + "use " + (DateTime.Now - t1).ToString() + "\r\n";
                //删除原有时间段内FQS全部记录（new）
                DateTime t2 = DateTime.Now;
                AOCDataFQS.DeleteAOCDataFQSByDateTime(dateTimeStart, dateTimeEnd, null);
                msgSyncOut += "delete from AOCFQS use " + (DateTime.Now - t2).ToString() + "\r\n";
                //将获取到的航班同步到AOC库中
                DateTime t3 = DateTime.Now;
                if (fqsDataList != null && fqsDataList.Count > 0)
                {
                    //BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataITV(fqsDataList, out countList, out countInsert, out countUpdate);
                    BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataSimpleITV(dateTimeCheckPoint, fqsDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;
                    AOCLog.logSuccess(msgSync);
                    msgSyncOut += "insert into AOCFQS use " + (DateTime.Now - t3).ToString() + "\r\n";
                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataFQS.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception ex)
            {
                msgSync = AOCLog.GenerateParamsErroForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                msgSyncOut += ex.Message.ToString();
                AOCLog.logErro(ex, msgSync);
            }
        }

        /// <summary>
        /// 每日同步，从FlightQuerySystem库同步所有航班到AOCFQS库
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncFlightQuerySystemToAOCFQSSimpleDAY(DateTime dateTimeCheckPoint, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
            //初始化count记录,count用于记录操作结果,分别为操作总数，插入总数，更新总数
            int countList = int.MinValue;
            int countInsert = int.MinValue;
            int countUpdate = int.MinValue;
            string msgSync = string.Empty;

            //初始化当前方法信息
            string nameFunction = TextTool.GetFunctionInfo();

            //初始化每日同步的同步时间范围
            DateTime dateTimeStart = dateTimeCheckPoint.Date;//当天
            DateTime dateTimeEnd = dateTimeCheckPoint.Date.AddHours(AOCConfig.INTERVALEVENTDAILYAFTER).AddSeconds(-1);//后X天全天数据

            try
            {
                //获取FlightQuerySystem库中符合时间范围的所有航班
                DateTime t1 = DateTime.Now;
                List<FlightQuerySystemData> fqsDataList = FlightQuerySystemData.GetFlightQuerySystemData(dateTimeStart, dateTimeEnd);
                msgSyncOut += "load from FlightQuerySystemData " + fqsDataList.Count + "use " + (DateTime.Now - t1).ToString() + "\r\n";
                //删除原有时间段内FQS全部记录
                DateTime t2 = DateTime.Now;
                AOCDataFQS.DeleteAOCDataFQSByDateTime(dateTimeStart, dateTimeEnd, null);
                msgSyncOut += "delete from AOCFQS use " + (DateTime.Now - t2).ToString() + "\r\n";
                //将获取到的所有航班同步到AOC库中
                DateTime t3 = DateTime.Now;
                if (fqsDataList != null && fqsDataList.Count > 0)
                {
                    BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataSimpleDAY(fqsDataList, out countList, out countInsert, out countUpdate);

                    msgSync = AOCLog.GenerateSuccessMSGForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);
                    msgSyncOut += ",insert into AOCFQS use " + (DateTime.Now - t3).ToString() + "\r\n";
                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataFQS.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception ex)
            {
                msgSyncOut = ex.Message;
                msgSync = AOCLog.GenerateParamsErroForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                AOCLog.logErro(ex, msgSync);
            }

        }

        /// <summary>
        /// 每日同步，从FlightQuerySystem库同步所有航班到AOCFQS库(此算法不被使用)
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncFlightQuerySystemToAOCFQSDAY(DateTime dateTimeCheckPoint, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
            //初始化count记录,count用于记录操作结果,分别为操作总数，插入总数，更新总数
            int countList = int.MinValue;
            int countInsert = int.MinValue;
            int countUpdate = int.MinValue;
            string msgSync = string.Empty;
            //初始化当前方法信息
            string nameFunction = TextTool.GetFunctionInfo();
            //初始化每日同步的同步时间范围
            DateTime dateTimeStart = dateTimeCheckPoint.Date;//当天
            DateTime dateTimeEnd = dateTimeCheckPoint.Date.AddHours(AOCConfig.INTERVALEVENTDAILYAFTER).AddSeconds(-1);//后X天全天数据

            try
            {
                //获取FlightQuerySystem库中符合时间范围的所有航班
                List<FlightQuerySystemData> fqsDataList = FlightQuerySystemData.GetFlightQuerySystemData(dateTimeStart, dateTimeEnd);

                //将获取到的所有航班同步到AOC库中
                if (fqsDataList != null && fqsDataList.Count > 0)
                {
                    //BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataDAY(fqsDataList, out countList, out countInsert, out countUpdate);
                    BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataDAY(dateTimeCheckPoint, fqsDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataFQS.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception ex)
            {
                msgSyncOut = ex.Message;
                msgSync = AOCLog.GenerateParamsErroForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                AOCLog.logErro(ex, msgSync);
            }
        }

        /// <summary>
        /// 轮询同步，将得到的FlightQuerySystem库数据同步到AOCFQS库中
        /// </summary>
        /// <param name="fqsDataList">FlightQuerySystem库数据</param>
        public static void GenerateAOCDataByFlightQuerySystemDataITV(List<FlightQuerySystemData> fqsDataList)
        {
            //在执行同步前去的数据库连接并建立SqlTransaction，回滚机制
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                    //将FlightQuerySystem库数据中的数据逐条插入AOC库中
                    foreach (FlightQuerySystemData fqsData in fqsDataList)
                    {
                        GenerateAOCDataByFlightQuerySystemDataITV(fqsData, trans);
                    }
                    trans.Commit();//数据库操作全部成功后，COMMIT

                    //更新AOC航班信息缓存
                    AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();//当数据操作不成功时，全部回滚
                    throw exSql;
                }
                finally
                {
                    connSql.Close();//关闭数据库连接
                }
            }
        }


        public static void GenerateAOCDataByFlightQuerySystemDataSimpleITV(DateTime dt, List<FlightQuerySystemData> fqsDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = fqsDataList.Count;
            countInsert = 0;
            countUpdate = 0;
         //  int resultInsert = 0;
          // int resultUpdate = 0;

            //在执行同步前去的数据库连接并建立SqlTransaction，回滚机制
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                ///////////////////////////////////////////////////////////////////
                //从缓存中找到当前范围的FQS
                //DateTime dateTimeStart = dt.AddHours(AOCConfig.INTERVALEVENTBEFORE);
                //DateTime dateTimeEnd = dt.AddHours(AOCConfig.INTERVALEVENTAFTER);
                //string dtStart = dateTimeStart.ToString();
                //string dtEnd = dateTimeEnd.ToString();
                //List<AOCDataFQS> aocDataFQSList = AOCDataFQS.Cache.AOCDataList.FindAll(delegate(AOCDataFQS aocdataInList)
                //{
                //    if (!string.IsNullOrEmpty(aocdataInList.STOD))
                //    {
                //        dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
                //        dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");
                //        return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0;
                //    }
                //    else
                //    {
                //        return aocdataInList.SDT.CompareTo(dtStart) >= 0 && aocdataInList.SDT.CompareTo(dtEnd) <= 0;
                //    }
                //}
                //);
                ////////////////////////////////////////////////////////////////
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();//打开回滚机制
                try
                {
                    //将FlightQuerySystem库数据中的数据逐条插入AOC库中
                    foreach (FlightQuerySystemData fqsData in fqsDataList)
                    {
                        AOCDataFQS aoc = new AOCDataFQS();
                        aoc = TransferToAOCDataByFlightQuerySystemData(fqsData);

                        aoc.CDAT = DateTime.Now;
                        aoc.LSTU = DateTime.Now;
                        aoc.TYPC = EnumSyncWorkType.ITV.ToString();

                        aoc.Insert(trans);
                      
                        countInsert++;
                        //GenerateAOCDataByFlightQuerySystemDataITV(fqsData, trans, out resultInsert, out resultUpdate);
                        //countInsert += resultInsert;
                        //countUpdate += resultUpdate;
                        /////////////////////////////////////////////////////////////
                        ////更新的，从aocDataFQSList中去除掉，剩下的就是要删除的
                        //if (resultUpdate == 1)
                        //{
                        //    AOCDataFQS tmp = aocDataFQSList.Find(delegate(AOCDataFQS aocInList)
                        //    {
                        //        return aocInList.URNO.Equals(fqsData.URNO, StringComparison.OrdinalIgnoreCase);
                        //    }
                        //      );
                        //    if (tmp != null)
                        //    {
                        //        aocDataFQSList.Remove(tmp);
                        //    }
                        //}
                        //////////////////////////////////////////////////////////////////
                    }
                    ///////////////////////////////////////////////////////////////////
                    //foreach (AOCDataFQS aocDatafqs in aocDataFQSList)
                    //{
                    //    aocDatafqs.Delete();
                    //}
                    ///////////////////////////////////////////////////////////////////
                    
                   
                    countUpdate = countList - fqsDataList.Count;
                    trans.Commit();//数据库操作全部成功后，COMMIT

                    //更新AOC航班信息缓存
                    AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();//当数据操作不成功时，全部回滚
                    countInsert = -1;
                    countUpdate = -1;
                    throw exSql;
                }
                finally
                {
                    connSql.Close();//关闭数据库连接
                }
            }
        }
        //(不用)
        public static void GenerateAOCDataByFlightQuerySystemDataITV(DateTime dt, List<FlightQuerySystemData> fqsDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = fqsDataList.Count;
            countInsert = 0;
            countUpdate = 0;
            int resultInsert = 0;
            int resultUpdate = 0;

            //在执行同步前去的数据库连接并建立SqlTransaction，回滚机制
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                ///////////////////////////////////////////////////////////////////
                //从缓存中找到当前范围的FQS
                DateTime dateTimeStart = dt.AddHours(AOCConfig.INTERVALEVENTBEFORE);
                DateTime dateTimeEnd = dt.AddHours(AOCConfig.INTERVALEVENTAFTER);
                string dtStart = dateTimeStart.ToString();
                string dtEnd = dateTimeEnd.ToString();
                List<AOCDataFQS> aocDataFQSList = AOCDataFQS.Cache.AOCDataList.FindAll(delegate(AOCDataFQS aocdataInList)
                {
                    if (!string.IsNullOrEmpty(aocdataInList.STOD))
                    {
                        dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
                        dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");
                        return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0;
                    }
                    else
                    {
                        return aocdataInList.SDT.CompareTo(dtStart) >= 0 && aocdataInList.SDT.CompareTo(dtEnd) <= 0;
                    }
                }
                );
                ////////////////////////////////////////////////////////////////
               connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();//打开回滚机制
                try
                {
                    //将FlightQuerySystem库数据中的数据逐条插入AOC库中
                    foreach (FlightQuerySystemData fqsData in fqsDataList)
                    {
                        GenerateAOCDataByFlightQuerySystemDataITV(fqsData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                        ///////////////////////////////////////////////////////////
                        //更新的，从aocDataFQSList中去除掉，剩下的就是要删除的
                        if (resultUpdate == 1)
                        {
                            AOCDataFQS tmp = aocDataFQSList.Find(delegate(AOCDataFQS aocInList)
                            {
                                return aocInList.URNO.Equals(fqsData.URNO, StringComparison.OrdinalIgnoreCase);
                            }
                              );
                            if (tmp != null)
                            {
                                aocDataFQSList.Remove(tmp);
                            }
                        }
                        //////////////////////////////////////////////////////////////////
                    }
                    ///////////////////////////////////////////////////////////////////
                    foreach (AOCDataFQS aocDatafqs in aocDataFQSList)
                    {
                        aocDatafqs.Delete();
                    }
                    ///////////////////////////////////////////////////////////////////
                    trans.Commit();//数据库操作全部成功后，COMMIT

                    //更新AOC航班信息缓存
                    AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();//当数据操作不成功时，全部回滚
                    countInsert = 0;
                    countUpdate = 0;
                    throw exSql;
                }
                finally
                {
                    connSql.Close();//关闭数据库连接
                }
            }
        }

        /// <summary>
        /// 轮询同步，将得到的FlightQuerySystem库数据同步到AOC库中
        /// </summary>
        /// <param name="fqsDataList">FlightQuerySystem库数据</param>
        /// <param name="countList">输出结果 FlightQuerySystem库数据操作总数</param>
        /// <param name="countInsert">输出结果 FlightQuerySystem库数据insert总数</param>
        /// <param name="countUpdate">输出结果 FlightQuerySystem库数据update总数</param>
        public static void GenerateAOCDataByFlightQuerySystemDataITV(List<FlightQuerySystemData> fqsDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = fqsDataList.Count;
            countInsert = 0;
            countUpdate = 0;
            int resultInsert = 0;
            int resultUpdate = 0;

            //在执行同步前去的数据库连接并建立SqlTransaction，回滚机制
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();//打开回滚机制
                try
                {
                    //将FlightQuerySystem库数据中的数据逐条插入AOC库中
                    foreach (FlightQuerySystemData ccData in fqsDataList)
                    {
                        GenerateAOCDataByFlightQuerySystemDataITV(ccData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                    }
                    trans.Commit();//数据库操作全部成功后，COMMIT

                    //更新AOC航班信息缓存
                    AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();//当数据操作不成功时，全部回滚
                    countInsert = 0;
                    countUpdate = 0;
                    throw exSql;
                }
                finally
                {
                    connSql.Close();//关闭数据库连接
                }
            }
        }

        /// <summary>
        /// 每日同步，将得到的FlightQuerySystem库数据同步到AOC库中
        /// </summary>
        /// <param name="fqsDataList">FlightQuerySystem库数据</param>
        public static void GenerateAOCDataByFlightQuerySystemDataDAY(List<FlightQuerySystemData> fqsDataList)
        {
            //在执行同步前去的数据库连接并建立SqlTransaction，回滚机制
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                    //将FlightQuerySystem库数据中的数据逐条插入AOC库中
                    foreach (FlightQuerySystemData ccData in fqsDataList)
                    {
                        GenerateAOCDataByFlightQuerySystemDataDAY(ccData, trans);
                    }
                    trans.Commit();//数据库操作全部成功后，COMMIT

                    //更新AOC航班信息缓存
                    AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();//当数据操作不成功时，全部回滚
                    throw exSql;
                }
                finally
                {
                    connSql.Close();//关闭数据库连接
                }
            }
        }

        /// <summary>
        /// 新算法
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fqsDataList"></param>
        /// <param name="countList"></param>
        /// <param name="countInsert"></param>
        /// <param name="countUpdate"></param>
        public static void GenerateAOCDataByFlightQuerySystemDataSimpleDAY( List<FlightQuerySystemData> fqsDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = fqsDataList.Count;
            countInsert = 0;
            countUpdate = 0;

            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                    ////////////////////////////////////////////////////////////////
                    foreach (FlightQuerySystemData fqsData in fqsDataList)
                    {
                        //将FlightQuerySystem数据转化为AOC数据类型
                        AOCDataFQS aoc = new AOCDataFQS();
                        aoc = TransferToAOCDataByFlightQuerySystemData(fqsData);

                        aoc.CDAT = DateTime.Now;
                        aoc.LSTU = DateTime.Now;
                        aoc.TYPU = EnumSyncWorkType.DAY.ToString();

                        aoc.Insert(trans);

                        countInsert++;

                        //GenerateAOCDataByFlightQuerySystemDataDAY(fqsData, trans, out resultInsert, out resultUpdate);
                        //countInsert += resultInsert;
                        //countUpdate += resultUpdate;
                        /////////////////////////////////////////////////////////////
                        ////更新的，从aocDataFQSList中去除掉，剩下的就是要删除的
                        //if (resultUpdate == 1)
                        //{
                        //    AOCDataFQS tmp = aocDataFQSList.Find(delegate(AOCDataFQS aocInList)
                        //    {
                        //        return aocInList.URNO.Equals(fqsData.URNO, StringComparison.OrdinalIgnoreCase);
                        //    }
                        //      );
                        //    if (tmp != null)
                        //    {
                        //        aocDataFQSList.Remove(tmp);
                        //    }
                        //}
                        ////////////////////////////////////////////////////////////////////
                    }
                    ///////////////////////////////////////////////////////////////////
                    //foreach (AOCDataFQS aocDatafqs in aocDataFQSList)
                    //{
                    //    aocDatafqs.Delete();
                    //}
                    ///////////////////////////////////////////////////////////////////
                    trans.Commit();

                    //更新AOC航班信息缓存
                   AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();
                    countInsert = -1;
                    countUpdate = -1;
                    throw exSql;
                }
                finally
                {
                    connSql.Close();
                }
            }
        }

        /// <summary>
        /// 该算法已被优化
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fqsDataList"></param>
        /// <param name="countList"></param>
        /// <param name="countInsert"></param>
        /// <param name="countUpdate"></param>
        public static void GenerateAOCDataByFlightQuerySystemDataDAY(DateTime dt, List<FlightQuerySystemData> fqsDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = fqsDataList.Count;
            countInsert = 0;
            countUpdate = 0;
            int resultInsert = 0;
            int resultUpdate = 0;

            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                    ///////////////////////////////////////////////////////////////////
                    //从缓存中找到当前范围的FQS
                    DateTime dateTimeStart = dt.Date;//当天
                    DateTime dateTimeEnd = dt.Date.AddHours(AOCConfig.INTERVALEVENTDAILYAFTER).AddSeconds(-1);//后X天全天数据
                    string dtStart = dateTimeStart.ToString();
                    string dtEnd = dateTimeEnd.ToString();
                    List<AOCDataFQS> aocDataFQSList = AOCDataFQS.Cache.AOCDataList.FindAll(delegate(AOCDataFQS aocdataInList)
                            {
                                if (!string.IsNullOrEmpty(aocdataInList.STOD))
                                {
                                    dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
                                    dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");
                                    return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0;
                                }
                                else
                                {
                                    return aocdataInList.SDT.CompareTo(dtStart) >= 0 && aocdataInList.SDT.CompareTo(dtEnd) <= 0;
                                }
                            }
                    );
                    ////////////////////////////////////////////////////////////////
                    foreach (FlightQuerySystemData fqsData in fqsDataList)
                    {
                        GenerateAOCDataByFlightQuerySystemDataDAY(fqsData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                        ///////////////////////////////////////////////////////////
                        //更新的，从aocDataFQSList中去除掉，剩下的就是要删除的
                        if (resultUpdate == 1)
                        {
                            AOCDataFQS tmp = aocDataFQSList.Find(delegate(AOCDataFQS aocInList)
                                  {
                                      return aocInList.URNO.Equals(fqsData.URNO, StringComparison.OrdinalIgnoreCase);
                                  }
                              );
                            if (tmp != null)
                            {
                                aocDataFQSList.Remove(tmp);
                            }
                        }
                        //////////////////////////////////////////////////////////////////
                    }
                    ///////////////////////////////////////////////////////////////////
                    foreach (AOCDataFQS aocDatafqs in aocDataFQSList)
                    {
                        aocDatafqs.Delete();
                    }
                    ///////////////////////////////////////////////////////////////////
                    trans.Commit();

                    //更新AOC航班信息缓存
                    //AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();
                    countInsert = 0;
                    countUpdate = 0;
                    throw exSql;
                }
                finally
                {
                    connSql.Close();
                }
            }
        }


        /// <summary>
        /// 每日同步，将得到的FlightQuerySystem库数据同步到AOC库中
        /// </summary>
        /// <param name="fqsDataList">FlightQuerySystem库数据</param>
        /// <param name="countList"></param>
        /// <param name="countInsert"></param>
        /// <param name="countUpdate"></param>
        public static void GenerateAOCDataByFlightQuerySystemDataDAY(List<FlightQuerySystemData> fqsDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = fqsDataList.Count;
            countInsert = 0;
            countUpdate = 0;
            int resultInsert = 0;
            int resultUpdate = 0;

            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                    foreach (FlightQuerySystemData fqsData in fqsDataList)
                    {
                        GenerateAOCDataByFlightQuerySystemDataDAY(fqsData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                    }
                    trans.Commit();

                    //更新AOC航班信息缓存
                    //AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();
                    countInsert = 0;
                    countUpdate = 0;
                    throw exSql;
                }
                finally
                {
                    connSql.Close();
                }
            }
        }

        /// <summary>
        /// 轮询同步，将得到的FlightQuerySystem库数据同步到AOC库中
        /// </summary>
        /// <param name="fqsData">单条FlightQuerySystem数据</param>
        /// <param name="trans"></param>
        private static void GenerateAOCDataByFlightQuerySystemDataITV(FlightQuerySystemData fqsData, SqlTransaction trans)
        {
            int countInsert, countUpdate;
            GenerateAOCDataByFlightQuerySystemDataITV(fqsData, trans, out countInsert, out countUpdate);
            ////将FlightQuerySystem数据转化为AOC数据类型
            //AOCDataFQS aoc = new AOCDataFQS();
            //aoc = TransferToAOCDataByFlightQuerySystemData(ccData);

            //try
            //{
            //    //轮询同步，将此条AOC类型数据同步到AOC库中
            //    UpdateOrInsertAOCDataToDBITV(aoc, trans);
            //}
            //catch (Exception exSql)
            //{
            //    throw exSql;
            //}
        }

        /// <summary>
        /// 轮询同步，单条FlightQuerySystem数据同步到AOC库中
        /// </summary>
        /// <param name="ccData">单条FlightQuerySystem数据</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">输出结果，Insert数</param>
        /// <param name="countUpdate">输出结果，Update数</param>
        private static void GenerateAOCDataByFlightQuerySystemDataITV(FlightQuerySystemData ccData, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            //将FlightQuerySystem数据转化为AOC数据类型
            AOCDataFQS aoc = new AOCDataFQS();
            aoc = TransferToAOCDataByFlightQuerySystemData(ccData);

            try
            {
                //轮询同步，将此条AOC类型数据同步到AOC库中
                UpdateOrInsertAOCDataToDBITV(aoc, trans, out countInsert, out countUpdate);
            }
            catch (Exception exSql)
            {
                throw exSql;
            }
        }

        /// <summary>
        /// 每日方式，单条FlightQuerySystem数据同步到AOC库中
        /// </summary>
        /// <param name="ccData">单条FlightQuerySystem数据</param>
        /// <param name="trans"></param>
        private static void GenerateAOCDataByFlightQuerySystemDataDAY(FlightQuerySystemData fqsData, SqlTransaction trans)
        {
            int countInsert;
            int countUpdate;
            GenerateAOCDataByFlightQuerySystemDataDAY(fqsData, trans, out countInsert, out countUpdate);
            ////将FlightQuerySystem数据转化为AOC数据类型
            //AOCDataFQS aoc = new AOCDataFQS();
            //aoc = TransferToAOCDataByFlightQuerySystemData(ccData);

            //try
            //{
            //    //每日方式，将此条AOC类型数据同步到AOC库中
            //    UpdateOrInsertAOCDataToDBDAY(aoc,trans);
            //}
            //catch (Exception exSql)
            //{
            //    throw exSql;
            //}
        }

        /// <summary>
        /// 每日方式，单条FlightQuerySystem数据同步到AOC库中
        /// </summary>
        /// <param name="fqsData">单条FlightQuerySystem数据</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">输出操作记录，Insert数量</param>
        /// <param name="countUpdate">输出操作记录，Update数量</param>
        private static void GenerateAOCDataByFlightQuerySystemDataDAY(FlightQuerySystemData fqsData, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            //将FlightQuerySystem数据转化为AOC数据类型
            AOCDataFQS aoc = new AOCDataFQS();
            aoc = TransferToAOCDataByFlightQuerySystemData(fqsData);

            try
            {
                //每日方式，将此条AOC类型数据同步到AOC库中
                UpdateOrInsertAOCDataToDBDAY(aoc, trans, out countInsert, out countUpdate);
            }
            catch (Exception exSql)
            {
                throw exSql;
            }
        }

        /// <summary>
        /// 轮询方式，单条AOC数据类型同步到AOC库中
        /// </summary>
        /// <param name="aoc">单条AOC数据</param>
        /// <param name="trans"></param>
        private static void UpdateOrInsertAOCDataToDBITV(AOCDataFQS aoc, SqlTransaction trans)
        {
            try
            {
                //判断执行Update还是Insert,如果当前AOC库中存在相同的URNO记录，则更新，否则新增
                if (AOCDataFQS.Cache.AOCDataList.Exists(delegate(AOCDataFQS aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }))
                {
                    //执行更新操作
                    aoc.ID = AOCDataFQS.Cache.AOCDataList.Find(delegate(AOCDataFQS aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }).ID;
                    aoc.LSTU = DateTime.Now;
                    aoc.TYPU = EnumSyncWorkType.ITV.ToString();

                    aoc.Update(trans);
                }
                else
                {
                    //执行新增操作
                    aoc.CDAT = DateTime.Now;
                    aoc.TYPC = EnumSyncWorkType.ITV.ToString();

                    aoc.Insert(trans);
                }
            }
            catch (Exception exSql)
            {
                Exception exCus = new Exception(string.Format("UpdateOrInsertAOCDataToDBITV AOC URNO:{0} {1}", aoc.URNO, exSql.Message));
                throw exCus;
            }
        }

        /// <summary>
        /// 轮询方式，单条AOC数据类型同步到AOC库中
        /// </summary>
        /// <param name="aoc">单条AOC数据</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">输出操作记录，Insert数量</param>
        /// <param name="countUpdate">输出操作记录，Update数量</param>
        private static void UpdateOrInsertAOCDataToDBITV(AOCDataFQS aoc, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            try
            {
                //判断执行Update还是Insert,如果当前AOC库中存在相同的URNO记录，则更新，否则新增
                if (AOCDataFQS.Cache.AOCDataList.Exists(delegate(AOCDataFQS aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }))
                {
                    //执行更新操作
                    aoc.ID = AOCDataFQS.Cache.AOCDataList.Find(delegate(AOCDataFQS aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }).ID;
                    aoc.LSTU = DateTime.Now;
                    aoc.TYPU = EnumSyncWorkType.ITV.ToString();

                    aoc.Update(trans);
                    countUpdate = 1;
                    countInsert = 0;
                }
                else
                {
                    //执行新增操作
                    aoc.CDAT = DateTime.Now;
                    aoc.TYPC = EnumSyncWorkType.ITV.ToString();

                    aoc.Insert(trans);
                    countInsert = 1;
                    countUpdate = 0;
                }
            }
            catch (Exception exSql)
            {
                Exception exCus = new Exception(string.Format("UpdateOrInsertAOCDataToDBITV AOC URNO:{0} {1}", aoc.URNO, exSql.Message));
                throw exCus;
                //throw exSql;
            }
        }

        /// <summary>
        /// 每日同步，单条AOC数据类型同步到AOC库中
        /// </summary>
        /// <param name="aoc">单条AOC数据</param>
        /// <param name="trans"></param>
        private static void UpdateOrInsertAOCDataToDBDAY(AOCDataFQS aoc, SqlTransaction trans)
        {
            int countInsert, countUpdate;
            UpdateOrInsertAOCDataToDBDAY(aoc, trans, out countInsert, out countUpdate);
            //bool EqualURNO = false;
            //try
            //{
            //    /*
            //     * 判断执行Update还是Insert
            //     * 如果当前AOC库中的三要素（MFDI,DRCT,APTIATA）是否完全相同：
            //     * MFDI:航班号
            //     * DRCT:进离港
            //     * APTIATA:所属机场
            //     * 
            //     * */
            //    if (AOCDataFQS.Cache.AOCDataList.Exists(delegate(AOCDataFQS aocInList)
            //    {
            //        EqualURNO = aocInList.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase);
            //        return EqualURNO;
            //    }))
            //    {
            //        if(true)
            //        {
            //            aoc.ID = AOCDataFQS.Cache.AOCDataList.Find(delegate(AOCDataFQS aocInList)
            //                            {
            //                                EqualURNO = aocInList.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase);
            //                                return EqualURNO;
            //                            }
            //                        ).ID;

            //            aoc.LSTU = DateTime.Now;
            //            aoc.TYPU = EnumSyncWorkType.DAY.ToString();

            //            aoc.Update(trans);
            //        }
            //    }
            //    else
            //    {
            //        //执行新增操作
            //        aoc.CDAT = DateTime.Now;
            //        aoc.TYPC = EnumSyncWorkType.DAY.ToString();

            //        aoc.Insert(trans);

            //    }
            //}
            //catch (Exception exSql)
            //{
            //    Exception exCus = new Exception(string.Format("UpdateOrInsertAOCDataToDBITV AOC URNO:{0} {1}", aoc.URNO, exSql.Message));
            //    throw exCus;
            //}
        }

        /// <summary>
        /// 每日同步，单条AOC数据类型同步到AOC库中
        /// </summary>
        /// <param name="aoc">单条AOC数据</param>
        /// <param name="trans"></param>
        /// <param name="countInsert"></param>
        /// <param name="countUpdate"></param>
        private static void UpdateOrInsertAOCDataToDBDAY(AOCDataFQS aoc, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;
            bool EqualURNO = false;
            try
            {
                /*
                 * 判断执行Update还是Insert
                 * 如果当前AOCFQS库中的URNO是否完全相同：                
                 * 
                 * */

                if (AOCDataFQS.Cache.AOCDataList.Exists(delegate(AOCDataFQS aocInList)
                {
                    EqualURNO = aocInList.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase);
                    return EqualURNO;
                }))
                {
                    //UPDATE
                    aoc.ID = AOCDataFQS.Cache.AOCDataList.Find(delegate(AOCDataFQS aocInList)
                                    {
                                        EqualURNO = aocInList.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase);
                                        return EqualURNO;
                                    }
                                ).ID;

                    aoc.LSTU = DateTime.Now;
                    aoc.TYPU = EnumSyncWorkType.DAY.ToString();

                    aoc.Update(trans);

                    countUpdate = 1;
                    countInsert = 0;


                }
                else
                {
                    //INSERT
                    aoc.CDAT = DateTime.Now;
                    aoc.TYPC = EnumSyncWorkType.DAY.ToString();

                    aoc.Insert(trans);
                    countInsert = 1;
                    countUpdate = 0;
                }

            }
            catch (Exception exSql)
            {
                countInsert = 0;
                countUpdate = 0;
                Exception exCus = new Exception(string.Format("UpdateOrInsertAOCDataToDBDAY AOC URNO:{0} {1}", aoc.URNO, exSql.Message));
                throw exCus;
            }
        }

        /// <summary>
        /// 返回一个消息：当前时间点没有需要同步的数据
        /// </summary>
        /// <param name="NameFunction">执行同步的方法</param>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <returns></returns>
        private static string GenerateMsgNoData(string NameFunction, DateTime dateTimeCheckPoint)
        {
            return string.Format("{0} No data of this checkPointTime:{1}", NameFunction, dateTimeCheckPoint.ToString());
        }

        #region TransferToAOCDataByFlightQuerySystemData
        /// <summary>
        /// 单条FlightQuerySystemData转换为单条AOCData数据
        /// </summary>
        /// <param name="fqsData">单条FlightQuerySystemData输入</param>
        /// <returns></returns>
        private static AOCDataFQS TransferToAOCDataByFlightQuerySystemData(FlightQuerySystemData fqsData)
        {
            //实例化新AOCData对象
            AOCDataFQS aocData = new AOCDataFQS();

            //对AOCData对象的每个属性分别赋值
            //aocData.ID = new Guid();
            aocData.URNO = fqsData.URNO;
            aocData.CARRIER_IATA = fqsData.CARRIER_IATA;
            aocData.CARRIER_ICAO = fqsData.CARRIER_ICAO;
            aocData.FL_NUMBER = fqsData.FL_NUMBER;
            aocData.FL_SUFFIX = fqsData.FL_SUFFIX;
            aocData.FLT = fqsData.FLT;
            aocData.FLR = fqsData.FLR;
            aocData.SDT = fqsData.SDT;
            aocData.SDP = fqsData.SDP;
            aocData.LINKEDFL_FLT = fqsData.LINKEDFL_FLT;
            aocData.LINKEDFL_CARRIER = fqsData.LINKEDFL_CARRIER;
            aocData.LINKEDFL_NUMBER = fqsData.LINKEDFL_NUMBER;
            aocData.LINKEDFL_SUFFIX = fqsData.LINKEDFL_SUFFIX;
            aocData.LINKEDFL_SDT = fqsData.LINKEDFL_SDT;
            aocData.LINKEDFL_FLR = fqsData.LINKEDFL_FLR;
            aocData.LINKFL_ID = fqsData.LINKFL_ID;
            aocData.MASTERFL_CARRIER = fqsData.MASTERFL_CARRIER;
            aocData.MASTERFL_NUMBER = fqsData.MASTERFL_NUMBER;
            aocData.MASTERFL_SUFFIX = fqsData.MASTERFL_SUFFIX;

            // If MFDI is string.empty, set it as FLT
            if (!string.IsNullOrEmpty(fqsData.MFDI))
            {
                aocData.MFDI = fqsData.MFDI;
            }
            else
            {
                aocData.MFDI = fqsData.FLT;
            }

            aocData.MASTERFL_FLR = fqsData.MASTERFL_FLR;
            aocData.MASTERFL_ID = fqsData.MASTERFL_ID;
            aocData.AIRCRAFT_CALLSIGN = fqsData.AIRCRAFT_CALLSIGN;
            aocData.AIRCRAFT_OWNER = fqsData.AIRCRAFT_OWNER;
            aocData.AIRCRAFT_PAXCAP = fqsData.AIRCRAFT_PAXCAP;
            aocData.REGN = fqsData.REGN;
            aocData.ATC5 = fqsData.ATC5;
            aocData.AIRCRAFT_TYPE = fqsData.AIRCRAFT_TYPE;
            aocData.AIRCRAFT_OPERATOR = fqsData.AIRCRAFT_OPERATOR;
            aocData.AIRCRAFT_TERMINAL = fqsData.AIRCRAFT_TERMINAL;
            aocData.AIRPORT_IATA = fqsData.AIRPORT_IATA;
            aocData.BRC1 = fqsData.BRC1;
            aocData.RECLAIM_ROLE1 = fqsData.RECLAIM_ROLE1;
            aocData.BROD = fqsData.BROD;
            aocData.BRCD = fqsData.BRCD;
            aocData.EXITDOOR1 = fqsData.EXITDOOR1;
            aocData.SRC2 = fqsData.SRC2;
            aocData.RECLAIM_ROLE2 = fqsData.RECLAIM_ROLE2;
            aocData.SBRO = fqsData.SBRO;
            aocData.SBRC = fqsData.SBRC;
            aocData.EXITDOOR2 = fqsData.EXITDOOR2;
            aocData.MAKEUP_ID1 = fqsData.MAKEUP_ID1;
            aocData.MAKEUP_ROLE1 = fqsData.MAKEUP_ROLE1;
            aocData.MAKEUP_OPEN_TIME1 = fqsData.MAKEUP_OPEN_TIME1;
            aocData.MAKEUP_CLOSE_TIME1 = fqsData.MAKEUP_CLOSE_TIME1;
            aocData.MAKEUP_ID2 = fqsData.MAKEUP_ID2;
            aocData.MAKEUP_ROLE2 = fqsData.MAKEUP_ROLE2;
            aocData.MAKEUP_OPEN_TIME2 = fqsData.MAKEUP_OPEN_TIME2;
            aocData.MAKEUP_CLOSE_TIME2 = fqsData.MAKEUP_CLOSE_TIME2;
            aocData.ISBUSREQUIRED = fqsData.ISBUSREQUIRED;
            aocData.CC_TYPE1 = fqsData.CC_TYPE1;
            aocData.CKIF = fqsData.CKIF;
            aocData.CC_ROLE1 = fqsData.CC_ROLE1;
            aocData.CC_CLUSTERID1 = fqsData.CC_CLUSTERID1;
            aocData.CODT = fqsData.CODT;
            aocData.CCDT = fqsData.CCDT;
            aocData.CC_TYPE2 = fqsData.CC_TYPE2;
            aocData.SCDR = fqsData.SCDR;
            aocData.CC_ROLE2 = fqsData.CC_ROLE2;
            aocData.CC_CLUSTERID2 = fqsData.CC_CLUSTERID2;
            aocData.SCODT = fqsData.SCODT;
            aocData.SCCDT = fqsData.SCCDT;
            aocData.SGCD = fqsData.SGCD;
            aocData.SGOD = fqsData.SGOD;
            aocData.GATE_BORDING_STATUS2 = fqsData.GATE_BORDING_STATUS2;
            aocData.GATE_ROLE2 = fqsData.GATE_ROLE2;
            aocData.SGN = fqsData.SGN;
            aocData.GCDT = fqsData.GCDT;
            aocData.GODT = fqsData.GODT;
            aocData.GBS = fqsData.GBS;
            aocData.GATE_ROLE1 = fqsData.GATE_ROLE1;
            aocData.GENO = fqsData.GENO;
            aocData.TERM = fqsData.TERM;
            aocData.REMARK_CODE1 = fqsData.REMARK_CODE1;
            aocData.REMARK_TYPE1 = fqsData.REMARK_TYPE1;
            aocData.REMARK_CODE2 = fqsData.REMARK_CODE2;
            aocData.REMARK_TYPE2 = fqsData.REMARK_TYPE2;
            aocData.REMARK_CODE3 = fqsData.REMARK_CODE3;
            aocData.REMARK_TYPE3 = fqsData.REMARK_TYPE3;
            aocData.REMARK_CODE4 = fqsData.REMARK_CODE4;
            aocData.REMARK_TYPE4 = fqsData.REMARK_TYPE4;
            aocData.RUNWAY_ID = fqsData.RUNWAY_ID;
            aocData.S_INFO_TYPE1 = fqsData.S_INFO_TYPE1;
            aocData.S_INFO_TEXT1 = fqsData.S_INFO_TEXT1;
            aocData.S_INFO_TYPE2 = fqsData.S_INFO_TYPE2;
            aocData.S_INFO_TEXT2 = fqsData.S_INFO_TEXT2;
            aocData.S_INFO_TYPE3 = fqsData.S_INFO_TYPE3;
            aocData.S_INFO_TEXT3 = fqsData.S_INFO_TEXT3;
            aocData.S_INFO_TYPE4 = fqsData.S_INFO_TYPE4;
            aocData.S_INFO_TEXT4 = fqsData.S_INFO_TEXT4;
            aocData.S_INFO_TYPE5 = fqsData.S_INFO_TYPE5;
            aocData.S_INFO_TEXT5 = fqsData.S_INFO_TEXT5;
            aocData.ACCOUNT_CODE = fqsData.ACCOUNT_CODE;
            aocData.CSS = fqsData.CSS;
            aocData.DAIA = fqsData.DAIA;
            aocData.FL_OPERATES_OVERNIGHT = fqsData.FL_OPERATES_OVERNIGHT;
            aocData.TTYP = fqsData.TTYP;
            aocData.FL_SERVICETYPE = fqsData.FL_SERVICETYPE;
            aocData.FLTI = fqsData.FLTI;
            aocData.FL_TRANSITCODE = fqsData.FL_TRANSITCODE;
            aocData.HANDLINGAGENT1 = fqsData.HANDLINGAGENT1;
            aocData.HANDLING_SERVICE1 = fqsData.HANDLING_SERVICE1;
            aocData.HANDLINGAGENT2 = fqsData.HANDLINGAGENT2;
            aocData.HANDLING_SERVICE2 = fqsData.HANDLING_SERVICE2;
            aocData.HANDLINGAGENT3 = fqsData.HANDLINGAGENT3;
            aocData.HANDLING_SERVICE3 = fqsData.HANDLING_SERVICE3;
            aocData.HANDLINGAGENT4 = fqsData.HANDLINGAGENT4;
            aocData.HANDLING_SERVICE4 = fqsData.HANDLING_SERVICE4;
            aocData.HANDLINGAGENT5 = fqsData.HANDLINGAGENT5;
            aocData.HANDLING_SERVICE5 = fqsData.HANDLING_SERVICE5;
            aocData.IRR_NUMBER1 = fqsData.IRR_NUMBER1;
            aocData.IRR_CODE1 = fqsData.IRR_CODE1;
            aocData.IRR_DURATION1 = fqsData.IRR_DURATION1;
            aocData.IRR_NUMBER2 = fqsData.IRR_NUMBER2;
            aocData.IRR_CODE2 = fqsData.IRR_CODE2;
            aocData.IRR_DURATION2 = fqsData.IRR_DURATION2;
            aocData.ISGVF = fqsData.ISGVF;
            aocData.ISRETURNFL = fqsData.ISRETURNFL;
            aocData.ISTRANSFERFL = fqsData.ISTRANSFERFL;
            aocData.NEWFL_REASON = fqsData.NEWFL_REASON;
            aocData.OPERATIONTYPE_CODE1 = fqsData.OPERATIONTYPE_CODE1;
            aocData.TRANSFER_FL1 = fqsData.TRANSFER_FL1;
            aocData.TRANSFER_FL2 = fqsData.TRANSFER_FL2;
            aocData.TRANSFER_FL3 = fqsData.TRANSFER_FL3;
            aocData.TRANSFER_FL4 = fqsData.TRANSFER_FL4;
            aocData.TRANSFER_FL5 = fqsData.TRANSFER_FL5;
            aocData.TRANSFER_FL6 = fqsData.TRANSFER_FL6;
            aocData.TRANSFER_FL7 = fqsData.TRANSFER_FL7;
            aocData.TRANSFER_FL8 = fqsData.TRANSFER_FL8;
            aocData.TRANSFER_FL9 = fqsData.TRANSFER_FL9;
            aocData.TRANSFER_FL10 = fqsData.TRANSFER_FL10;
            aocData.TRANSFER_FL11 = fqsData.TRANSFER_FL11;
            aocData.TRANSFER_FL12 = fqsData.TRANSFER_FL12;
            aocData.TRANSFER_FL13 = fqsData.TRANSFER_FL13;
            aocData.TRANSFER_FL14 = fqsData.TRANSFER_FL14;
            aocData.TRANSFER_FL15 = fqsData.TRANSFER_FL15;
            aocData.TRANSFER_FL16 = fqsData.TRANSFER_FL16;
            aocData.TRANSFER_FL17 = fqsData.TRANSFER_FL17;
            aocData.TRANSFER_FL18 = fqsData.TRANSFER_FL18;
            aocData.TRANSFER_FL19 = fqsData.TRANSFER_FL19;
            aocData.TRANSFER_FL20 = fqsData.TRANSFER_FL20;
            aocData.SHAREFL_FLT1 = fqsData.SHAREFL_FLT1;
            aocData.SHAREFL_FLN1 = fqsData.SHAREFL_FLN1;
            aocData.SHAREFL_FLT2 = fqsData.SHAREFL_FLT2;
            aocData.SHAREFL_FLN2 = fqsData.SHAREFL_FLN2;
            aocData.SHAREFL_FLT3 = fqsData.SHAREFL_FLT3;
            aocData.SHAREFL_FLN3 = fqsData.SHAREFL_FLN3;
            aocData.SHAREFL_FLT4 = fqsData.SHAREFL_FLT4;
            aocData.SHAREFL_FLN4 = fqsData.SHAREFL_FLN4;
            aocData.SHAREFL_FLT5 = fqsData.SHAREFL_FLT5;
            aocData.SHAREFL_FLN5 = fqsData.SHAREFL_FLN5;
            aocData.SHAREFL_FLT6 = fqsData.SHAREFL_FLT6;
            aocData.SHAREFL_FLN6 = fqsData.SHAREFL_FLN6;
            aocData.TOTAL_BAGCOUNT = fqsData.TOTAL_BAGCOUNT;
            aocData.TOTAL_BAGWEIGHT = fqsData.TOTAL_BAGWEIGHT;
            aocData.TOTAL_FREIGHTWEIGHT = fqsData.TOTAL_FREIGHTWEIGHT;
            aocData.TOTAL_MAILWEIGHT = fqsData.TOTAL_MAILWEIGHT;
            aocData.TOTAL_LOADWEIGHT = fqsData.TOTAL_LOADWEIGHT;
            aocData.ADULT_PAXCOUNT = fqsData.ADULT_PAXCOUNT;
            aocData.BUSSINESS_PAXCOUNT = fqsData.BUSSINESS_PAXCOUNT;
            aocData.CHILD_PAXCOUNT = fqsData.CHILD_PAXCOUNT;
            aocData.DOMESITEC_PAXCOUNT = fqsData.DOMESITEC_PAXCOUNT;
            aocData.INFANT_PAXCOUNT = fqsData.INFANT_PAXCOUNT;
            aocData.INTERNATIONAL_PAXCOUNT = fqsData.INTERNATIONAL_PAXCOUNT;
            aocData.LOCAL_PAXCOUNT = fqsData.LOCAL_PAXCOUNT;
            aocData.NONTRANSFER_PAXCOUNT = fqsData.NONTRANSFER_PAXCOUNT;
            aocData.TOTAL_PAXCOUNT = fqsData.TOTAL_PAXCOUNT;
            aocData.TRANSFER_PAXCOUNT = fqsData.TRANSFER_PAXCOUNT;
            aocData.TRANSIT_PAXCOUNT = fqsData.TRANSIT_PAXCOUNT;
            aocData.WHELLCHAIR_PAXCOUNT = fqsData.WHELLCHAIR_PAXCOUNT;
            aocData.TOTAL_CREWCOUNT = fqsData.TOTAL_CREWCOUNT;
            aocData.ECONOMY_PAXCOUNT = fqsData.ECONOMY_PAXCOUNT;
            aocData.FIRSTCLASS_PAXCOUNT = fqsData.FIRSTCLASS_PAXCOUNT;
            aocData.TRANSFER_BAGCOUNT = fqsData.TRANSFER_BAGCOUNT;
            aocData.TRANSFER_BAGWEIGHT = fqsData.TRANSFER_BAGWEIGHT;
            aocData.TRANSFER_FREIGHTWEIGHT = fqsData.TRANSFER_FREIGHTWEIGHT;
            aocData.TRANSFER_MAILWEIGHT = fqsData.TRANSFER_MAILWEIGHT;
            aocData.TRANSIT_BAGCOUNT = fqsData.TRANSIT_BAGCOUNT;
            aocData.TRANSIT_BAGWEIGHT = fqsData.TRANSIT_BAGWEIGHT;
            aocData.TRANSIT_FREIGHTWEIGHT = fqsData.TRANSIT_FREIGHTWEIGHT;
            aocData.TRANSIT_MAILWEIGHT = fqsData.TRANSIT_MAILWEIGHT;
            aocData.OFFBLOCK_TIME = fqsData.OFFBLOCK_TIME;
            aocData.ONBLOCK_TIME = fqsData.ONBLOCK_TIME;
            aocData.EDTA = fqsData.EDTA;
            aocData.EDTD = fqsData.EDTD;
            aocData.E_FL_DURATION = fqsData.E_FL_DURATION;
            aocData.FIRSTBAG_TIME = fqsData.FIRSTBAG_TIME;
            aocData.LASTBAG_TIME = fqsData.LASTBAG_TIME;
            aocData.FINALAPPROACH_TIME = fqsData.FINALAPPROACH_TIME;
            aocData.LASTKNOWN_TIME = fqsData.LASTKNOWN_TIME;
            aocData.LASTKNOWN_SOURCE = fqsData.LASTKNOWN_SOURCE;
            aocData.NEXT_INFO_TIME = fqsData.NEXT_INFO_TIME;
            aocData.A_NEXT_STATION_TIME = fqsData.A_NEXT_STATION_TIME;
            aocData.E_NEXT_STATION_TIME = fqsData.E_NEXT_STATION_TIME;
            aocData.S_NEXT_STATION_TIME = fqsData.S_NEXT_STATION_TIME;
            aocData.A_PREV_STATION_TIME = fqsData.A_PREV_STATION_TIME;
            aocData.E_PREV_STATION_TIME = fqsData.E_PREV_STATION_TIME;
            aocData.S_PREV_STATION_TIME = fqsData.S_PREV_STATION_TIME;
            aocData.LAND = fqsData.LAND;
            aocData.AIRB = fqsData.AIRB;
            aocData.TEN_MILES_TIME = fqsData.TEN_MILES_TIME;
            aocData.ORG3 = fqsData.ORG3;
            aocData.DES3 = fqsData.DES3;
            aocData.ORG_ICAO = fqsData.ORG_ICAO;
            aocData.DES_ICAO = fqsData.DES_ICAO;
            aocData.VIA1 = fqsData.VIA1;
            aocData.VIA_ICAO = fqsData.VIA_ICAO;
            aocData.PUBLIC_FLT = fqsData.PUBLIC_FLT;
            aocData.PUBLIC_FLC = fqsData.PUBLIC_FLC;
            aocData.PUBLIC_TIME = fqsData.PUBLIC_TIME;
            aocData.SECURE_STAND_IS_REQUIRED = fqsData.SECURE_STAND_IS_REQUIRED;
            aocData.STOD = fqsData.STOD;
            aocData.STPO = fqsData.STPO;
            aocData.OPERATIONTYPE_CODE2 = fqsData.OPERATIONTYPE_CODE2;
            aocData.FIRSTBAG_TIME2 = fqsData.FIRSTBAG_TIME2;
            aocData.LASTBAG_TIME2 = fqsData.LASTBAG_TIME2;
            aocData.OPERATIONTYPE_ROLE1 = fqsData.OPERATIONTYPE_ROLE1;
            aocData.OPERATIONTYPE_ROLE2 = fqsData.OPERATIONTYPE_ROLE2;
            aocData.UPDATE_TIME = fqsData.UPDATE_TIME;
            aocData.CUSTOM_STATUS = fqsData.CUSTOM_STATUS;
            aocData.SUB_AIRLINE = fqsData.SUB_AIRLINE;
            aocData.LTD = fqsData.LTD;
            aocData.LTA = fqsData.LTA;
            aocData.AIRLINE_TERMINAL = fqsData.AIRLINE_TERMINAL;
            aocData.GATE_PLAN_CLOSE_TIME1 = fqsData.GATE_PLAN_CLOSE_TIME1;
            aocData.GATE_PLAN_OPEN_TIME1 = fqsData.GATE_PLAN_OPEN_TIME1;
            aocData.GATE_PLAN_CLOSE_TIME2 = fqsData.GATE_PLAN_CLOSE_TIME2;
            aocData.GATE_PLAN_OPEN_TIME2 = fqsData.GATE_PLAN_OPEN_TIME2;
            aocData.FL_STATUSCODE= fqsData.FL_STATUSCODE;       
            aocData.FL_CANCELCODE= fqsData.FL_CANCELCODE;
            aocData.FL_CLASSIFICATIONCODE = fqsData.FL_CLASSIFICATIONCODE;

            aocData.JFNO = string.Empty;
            aocData.CTRL = 0;

            aocData.DRCT = fqsData.DRCT;

            // dut to DRCT, D: ORG3 -> AIRPORT_IATA; DES3 -> DES_IATA, A: ORG3 -> ORG_IATA; DES3 -> AIRPORT_IATA
            if (aocData.DRCT.Equals("D", StringComparison.OrdinalIgnoreCase))
            {
                aocData.ORG3 = fqsData.AIRPORT_IATA;
               // aocData.DES3 = fqsData.DES3;
            }
            else if (aocData.DRCT.Equals("A", StringComparison.OrdinalIgnoreCase))
            {
               // aocData.ORG3 = fqsData.ORG3;
                aocData.DES3 = fqsData.AIRPORT_IATA;
            }

            aocData.USEC = EnumDataBaseSource.FQS.ToString();
            aocData.USEU = EnumDataBaseSource.FQS.ToString();

            return aocData;
        }
        #endregion
    }
}
