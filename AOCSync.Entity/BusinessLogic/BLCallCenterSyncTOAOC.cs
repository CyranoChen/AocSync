using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AOCSync.Entity.AOCEnum;
using AOCSync.Entity.Tools;

namespace AOCSync.Entity
{
    public class BLCallCenterSyncTOAOC
    {
        /// <summary>
        /// 轮询同步，从CallCenter库同步航班(不用)
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncCallCenterToAOCITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //获取CallCenter库中符合时间范围的所有虹桥机场航班
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd);

                //将获取到的航班同步到AOC库中
                if (ccDataList != null && ccDataList.Count > 0)
                {
                    //BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(dateTimeCheckPoint,ccDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataCC.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception ex)
            {
                msgSync = AOCLog.GenerateParamsErroForCallCenterSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                msgSyncOut += ex.Message.ToString();

                AOCLog.logErro(ex, msgSync);
            }
        }



        /// <summary>
        /// 轮询同步，从CallCenter库同步航班(新算法)
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncCallCenterToAOCSimpleITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //获取CallCenter库中符合时间范围的所有虹桥机场航班
                DateTime t1 = DateTime.Now;
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd);                
                msgSyncOut += "load from CallCenterData " + ccDataList.Count + "use " + (DateTime.Now - t1).ToString() + "\r\n";
                //删除原有时间段内CC全部记录
                DateTime t2 = DateTime.Now; 
                AOCDataCC.DeleteAOCDataCCByDateTime(dateTimeStart, dateTimeEnd, null);               
                msgSyncOut += "delete from AOC use " + (DateTime.Now - t2).ToString() + "\r\n";
                //将获取到的航班同步到AOC库中
                DateTime t3 = DateTime.Now;
                if (ccDataList != null && ccDataList.Count > 0)
                {
                    //BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);
                    //BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(dateTimeCheckPoint, ccDataList, out countList, out countInsert, out countUpdate);

                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataSimpleITV(dateTimeCheckPoint, ccDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);
                    msgSyncOut += "insert into AOC use " + (DateTime.Now - t3).ToString() + "\r\n";
                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataCC.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception ex)
            {
                msgSync = AOCLog.GenerateParamsErroForCallCenterSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                msgSyncOut += ex.Message.ToString();

                AOCLog.logErro(ex, msgSync);
            }
        }


        /// <summary>
        /// 轮询同步，从CallCenter库同步虹桥航班（新算法）
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncCallCenterSHAToAOCSimpleITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //获取CallCenter库中符合时间范围的所有虹桥机场航班
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd).FindAll(delegate(CallCenterData callCenterData)
                {
                    return callCenterData.AIRPORTIATACODE.Equals(AOCSync.Entity.AOCEnum.EnumAOCSync.SHA.ToString());
                });

                //删除原有时间段内CC虹桥全部记录
                AOCDataCC.DeleteAOCSHADataCCByDateTime(dateTimeStart, dateTimeEnd, null);


                //将获取到的航班同步到AOC库中
                if (ccDataList != null && ccDataList.Count > 0)
                {
                   // BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataSimpleITV(ccDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataCC.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception ex)
            {
                msgSync = AOCLog.GenerateParamsErroForCallCenterSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                msgSyncOut += ex.Message.ToString();

                AOCLog.logErro(ex, msgSync);
            }
        }
        /// <summary>
        /// 轮询同步，从CallCenter库同步虹桥航班(不用)
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncCallCenterSHAToAOCITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //获取CallCenter库中符合时间范围的所有虹桥机场航班
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd).FindAll(delegate(CallCenterData callCenterData)
                {
                    return callCenterData.AIRPORTIATACODE.Equals(AOCSync.Entity.AOCEnum.EnumAOCSync.SHA.ToString());
                });

                //将获取到的航班同步到AOC库中
                if (ccDataList != null && ccDataList.Count > 0)
                {
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);

                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataCC.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception ex)
            {
                msgSync = AOCLog.GenerateParamsErroForCallCenterSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                msgSyncOut += ex.Message.ToString();

                AOCLog.logErro(ex, msgSync);
            }
        }



        /// <summary>
        /// 轮询同步，从CallCenter库同步浦东航班(新算法)
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncCallCenterPVGToAOCSimpleITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //获取CallCenter库中符合时间范围的所有浦东机场航班
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd).FindAll(delegate(CallCenterData callCenterData)
                {
                    return callCenterData.AIRPORTIATACODE.Equals(AOCSync.Entity.AOCEnum.EnumAOCSync.PVG.ToString());
                });

                //删除原有时间段内CC 浦东全部记录
                AOCDataCC.DeleteAOCPVGDataCCByDateTime(dateTimeStart, dateTimeEnd, null);

                //将获取到的航班同步到AOC库中
                if (ccDataList != null && ccDataList.Count > 0)
                {
                   // BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataSimpleITV(ccDataList, out countList, out countInsert, out countUpdate);

                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataCC.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception exp)
            {
                msgSyncOut = exp.Message.ToString();
                msgSync = AOCLog.GenerateParamsErroForCallCenterSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                AOCLog.logErro(exp, msgSync);
            }
        }



        /// <summary>
        /// 轮询同步，从CallCenter库同步浦东航班(不用)
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncCallCenterPVGToAOCITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //获取CallCenter库中符合时间范围的所有浦东机场航班
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd).FindAll(delegate(CallCenterData callCenterData)
                {
                    return callCenterData.AIRPORTIATACODE.Equals(AOCSync.Entity.AOCEnum.EnumAOCSync.PVG.ToString());
                });

                //将获取到的航班同步到AOC库中
                if (ccDataList != null && ccDataList.Count > 0)
                {
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);

                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataCC.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception exp)
            {
                msgSyncOut = exp.Message.ToString();
                msgSync = AOCLog.GenerateParamsErroForCallCenterSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                AOCLog.logErro(exp, msgSync);
            }
        }


        /// <summary>
        /// 每日同步，从CallCenter库同步所有航班到AOC库
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncCallCenterToAOCSimpleDAY(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //获取CallCenter库中符合时间范围的所有航班
                DateTime t1 = DateTime.Now;
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd);               
                msgSyncOut += "load from CallCenterData " + ccDataList.Count + "use " + (DateTime.Now - t1).ToString() + "\r\n";
                //删除原有时间段内CC全部记录
                DateTime t2 = DateTime.Now;               
                AOCDataCC.DeleteAOCDataCCByDateTime(dateTimeStart, dateTimeEnd, null);
                msgSyncOut += "delete from AOC use " + (DateTime.Now - t2).ToString() + "\r\n";
                DateTime t3 = DateTime.Now;
                //将获取到的所有航班同步到AOC库中
                if (ccDataList != null && ccDataList.Count > 0)
                {
                    //BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataDAY(ccDataList, out countList, out countInsert, out countUpdate);
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataSimpleDAY(ccDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);
                    msgSyncOut += ",insert into AOC use " + (DateTime.Now - t3).ToString() + "\r\n";
                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataCC.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception ex)
            {
                msgSyncOut = ex.Message;
                msgSync = AOCLog.GenerateParamsErroForCallCenterSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                AOCLog.logErro(ex, msgSync);
            }
        }

        /// <summary>
        /// 每日同步，从CallCenter库同步所有航班到AOC库（已不使用）
        /// </summary>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <param name="msgSyncOut">输出结果：同步结果</param>
        public static void SyncCallCenterToAOCDAY(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //获取CallCenter库中符合时间范围的所有航班
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd);
                
                //将获取到的所有航班同步到AOC库中
                if (ccDataList != null && ccDataList.Count > 0)
                {
                    //BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataDAY(ccDataList, out countList, out countInsert, out countUpdate);
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataDAY(dateTimeCheckPoint,ccDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //更新AOC航班信息缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataCC.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(GenerateMsgNoData(nameFunction, dateTimeCheckPoint));
                }
            }
            catch (Exception ex)
            {
                msgSyncOut = ex.Message;
                msgSync = AOCLog.GenerateParamsErroForCallCenterSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                AOCLog.logErro(ex, msgSync);
            }
        }

        /// <summary>
        /// 轮询同步，将得到的CallCenter库数据同步到AOC库中
        /// </summary>
        /// <param name="ccDataList">CallCenter库数据</param>
        public static void GenerateAOCDataByCallCenterDataITV(List<CallCenterData> ccDataList)
        {
            //在执行同步前去的数据库连接并建立SqlTransaction，回滚机制
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                    //将CallCenter库数据中的数据逐条插入AOC库中
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        GenerateAOCDataByCallCenterDataITV(ccData, trans);
                    }
                    trans.Commit();//数据库操作全部成功后，COMMIT

                    //更新AOC航班信息缓存
                    AOCDataCC.Cache.RefreshCache();
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
        //(不用)
        public static void GenerateAOCDataByCallCenterDataITV(DateTime dt,List<CallCenterData> ccDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = ccDataList.Count;
            countInsert = 0;
            countUpdate = 0;
            int resultInsert = 0;
            int resultUpdate = 0;

            //在执行同步前去的数据库连接并建立SqlTransaction，回滚机制
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                ///////////////////////////////////////////////////////////////////
                //从缓存中找到当前范围的CC
                DateTime dateTimeStart = dt.AddHours(AOCConfig.INTERVALEVENTBEFORE);
                DateTime dateTimeEnd = dt.AddHours(AOCConfig.INTERVALEVENTAFTER);
                string dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
                string dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");

                List<AOCDataCC> aocDataCCList = AOCDataCC.Cache.AOCDataList.FindAll(delegate(AOCDataCC aocdataInList)
                {
                    return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0;
                }
                );
                ////////////////////////////////////////////////////////////////

                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();//打开回滚机制
                try
                {
                    
                    //将CallCenter库数据中的数据逐条插入AOC库中
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        GenerateAOCDataByCallCenterDataITV(ccData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                        ///////////////////////////////////////////////////////////
                        //更新的，从aocDataFQSList中去除掉，剩下的就是要删除的
                        if (resultUpdate == 1)
                        {
                            AOCDataCC tmp = aocDataCCList.Find(delegate(AOCDataCC aocInList)
                            {
                                return aocInList.URNO.Equals(ccData.FLIGHTDATAID, StringComparison.OrdinalIgnoreCase);
                            }
                              );
                            if (tmp != null)
                            {
                                aocDataCCList.Remove(tmp);
                            }
                        }
                        //////////////////////////////////////////////////////////////////
                    }
                    ///////////////////////////////////////////////////////////////////
                    foreach (AOCDataCC aocDatacc in aocDataCCList)
                    {
                        aocDatacc.Delete();
                    }
                    ///////////////////////////////////////////////////////////////////
                    trans.Commit();//数据库操作全部成功后，COMMIT

                    //更新AOC航班信息缓存
                    AOCDataCC.Cache.RefreshCache();
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
        //新算法
        public static void GenerateAOCDataByCallCenterDataSimpleITV(DateTime dt, List<CallCenterData> ccDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = ccDataList.Count;
            countInsert = 0;
            countUpdate = 0;
            //int resultInsert = 0;
            //int resultUpdate = 0;

            //在执行同步前去的数据库连接并建立SqlTransaction，回滚机制
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
               

                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();//打开回滚机制
                try
                {

                    //将CallCenter库数据中的数据逐条插入AOC库中
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        AOCDataCC aoc = new AOCDataCC();
                        aoc = TransferToAOCDataByCallCenterData(ccData);
                        //add by march 20140425在ccDataList中查找MASTERFLIGHTDATAID
                        if (ccData.FLIGHTDATAID != ccData.MASTERFLIGHTDATAID)
                        {
                            CallCenterData cc = ccDataList.Find(delegate(CallCenterData tmp) { return tmp.FLIGHTDATAID.Equals(ccData.MASTERFLIGHTDATAID, StringComparison.OrdinalIgnoreCase); });
                               
                            if (cc != null)
                            {
                                aoc.MFDI = cc.FLIGHTIDENTITY;
                            }
                            else
                            {
                                aoc.MFDI = ccData.MASTERFLIGHTDATAID;
                            }
                        }
                        else
                        {
                            aoc.MFDI = aoc.FLNO;
                        }
                        aoc.CDAT = DateTime.Now;
                        aoc.TYPC = EnumSyncWorkType.ITV.ToString();
                        aoc.LSTU = DateTime.Now;
                        aoc.Insert(trans);
                        countInsert++;
                    }

                        trans.Commit();//数据库操作全部成功后，COMMIT

                        //更新AOC航班信息缓存
                        AOCDataCC.Cache.RefreshCache();
                   
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
        /// 轮询同步，将得到的CallCenter库数据同步到AOC库中（新算法）
        /// </summary>
        /// <param name="ccDataList">CallCenter库数据</param>
        /// <param name="countList">输出结果 CallCenter库数据操作总数</param>
        /// <param name="countInsert">输出结果 CallCenter库数据insert总数</param>
        /// <param name="countUpdate">输出结果 CallCenter库数据update总数</param>
        public static void GenerateAOCDataByCallCenterDataSimpleITV(List<CallCenterData> ccDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = ccDataList.Count;
            countInsert = 0;
            countUpdate = 0;
           

            //在执行同步前去的数据库连接并建立SqlTransaction，回滚机制
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();//打开回滚机制
                try
                {
                    //将CallCenter库数据中的数据逐条插入AOC库中
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        //将CallCenter数据转化为AOC数据类型
                        AOCDataCC aoc = new AOCDataCC();
                        aoc = TransferToAOCDataByCallCenterData(ccData);

                        aoc.CDAT = DateTime.Now;
                        aoc.LSTU = DateTime.Now;
                        aoc.TYPC = EnumSyncWorkType.DAY.ToString();
                        aoc.Insert(trans);

                        countInsert++;
                    }
                    trans.Commit();//数据库操作全部成功后，COMMIT

                    //更新AOC航班信息缓存
                    AOCDataCC.Cache.RefreshCache();
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
        /// 轮询同步，将得到的CallCenter库数据同步到AOC库中（不用）
        /// </summary>
        /// <param name="ccDataList">CallCenter库数据</param>
        /// <param name="countList">输出结果 CallCenter库数据操作总数</param>
        /// <param name="countInsert">输出结果 CallCenter库数据insert总数</param>
        /// <param name="countUpdate">输出结果 CallCenter库数据update总数</param>
        public static void GenerateAOCDataByCallCenterDataITV(List<CallCenterData> ccDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = ccDataList.Count;
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
                    //将CallCenter库数据中的数据逐条插入AOC库中
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        GenerateAOCDataByCallCenterDataITV(ccData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                    }
                    trans.Commit();//数据库操作全部成功后，COMMIT

                    //更新AOC航班信息缓存
                    AOCDataCC.Cache.RefreshCache();
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
        /// 每日同步，将得到的CallCenter库数据同步到AOC库中
        /// </summary>
        /// <param name="ccDataList">CallCenter库数据</param>
        public static void GenerateAOCDataByCallCenterDataDAY(List<CallCenterData> ccDataList)
        {
            //在执行同步前去的数据库连接并建立SqlTransaction，回滚机制
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                    //将CallCenter库数据中的数据逐条插入AOC库中
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        GenerateAOCDataByCallCenterDataDAY(ccData, trans);
                    }
                    trans.Commit();//数据库操作全部成功后，COMMIT
                    
                    //更新AOC航班信息缓存
                    AOCDataCC.Cache.RefreshCache();
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

        public static void GenerateAOCDataByCallCenterDataSimpleDAY(List<CallCenterData> ccDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = ccDataList.Count;
            countInsert = 0;
            countUpdate = 0;
           

            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                   
                    foreach (CallCenterData ccData in ccDataList)
                    {

                        //将CallCenter数据转化为AOC数据类型
                        AOCDataCC aoc = new AOCDataCC();
                        aoc = TransferToAOCDataByCallCenterData(ccData);
                        //add by march 20140425在ccDataList中查找MASTERFLIGHTDATAID
                        if (ccData.FLIGHTDATAID != ccData.MASTERFLIGHTDATAID)
                        {
                            CallCenterData cc = ccDataList.Find(delegate(CallCenterData tmp) { return tmp.FLIGHTDATAID.Equals(ccData.MASTERFLIGHTDATAID, StringComparison.OrdinalIgnoreCase); });

                            if (cc != null)
                            {
                                aoc.MFDI = cc.FLIGHTIDENTITY;
                            }
                            else
                            {
                                aoc.MFDI = ccData.MASTERFLIGHTDATAID;
                            }
                        }
                        else
                        {
                            aoc.MFDI = aoc.FLNO;
                        }
                        aoc.CDAT = DateTime.Now;
                        aoc.LSTU = DateTime.Now;
                        aoc.TYPC = EnumSyncWorkType.DAY.ToString();
                        aoc.Insert(trans);

                        countInsert++;

                    }
                  
                    trans.Commit();

                    //更新AOC航班信息缓存
                    AOCDataCC.Cache.RefreshCache();
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
        /// 旧方法（已不使用）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ccDataList"></param>
        /// <param name="countList"></param>
        /// <param name="countInsert"></param>
        /// <param name="countUpdate"></param>
        public static void GenerateAOCDataByCallCenterDataDAY(DateTime dt,List<CallCenterData> ccDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = ccDataList.Count;
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
                    //从缓存中找到当前范围的CC
                    DateTime dateTimeStart = dt.Date;
                    DateTime dateTimeEnd = dt.Date.AddHours(AOCConfig.INTERVALEVENTDAILYAFTER).AddSeconds(-1);//后X天全天数据
                    string dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
                    string dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");

                    List<AOCDataCC> aocDataCCList = AOCDataCC.Cache.AOCDataList.FindAll(delegate(AOCDataCC aocdataInList)
                    {
                        return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0;
                    }
                        );
                    ////////////////////////////////////////////////////////////////

                    foreach (CallCenterData ccData in ccDataList)
                    {
                        GenerateAOCDataByCallCenterDataDAY(ccData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                        ///////////////////////////////////////////////////////////
                        //更新的，从aocDataFQSList中去除掉，剩下的就是要删除的
                        if (resultUpdate == 1)
                        {
                            AOCDataCC tmp = aocDataCCList.Find(delegate(AOCDataCC aocInList)
                            {
                                return aocInList.URNO.Equals(ccData.FLIGHTDATAID, StringComparison.OrdinalIgnoreCase);
                            }
                              );
                            if (tmp != null)
                            {
                                aocDataCCList.Remove(tmp);
                            }
                        }
                        //////////////////////////////////////////////////////////////////
                    }
                    ///////////////////////////////////////////////////////////////////
                    foreach (AOCDataCC aocDataCC in aocDataCCList)
                    {
                        aocDataCC.Delete();
                    }
                    ///////////////////////////////////////////////////////////////////
                    trans.Commit();

                    //更新AOC航班信息缓存
                    AOCDataCC.Cache.RefreshCache();
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
        /// 每日同步，将得到的CallCenter库数据同步到AOC库中
        /// </summary>
        /// <param name="ccDataList">CallCenter库数据</param>
        /// <param name="countList"></param>
        /// <param name="countInsert"></param>
        /// <param name="countUpdate"></param>
        public static void GenerateAOCDataByCallCenterDataDAY(List<CallCenterData> ccDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = ccDataList.Count;
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
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        GenerateAOCDataByCallCenterDataDAY(ccData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                    }
                    trans.Commit();

                    //更新AOC航班信息缓存
                    AOCDataCC.Cache.RefreshCache();
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
        /// 轮询同步，将得到的CallCenter库数据同步到AOC库中
        /// </summary>
        /// <param name="ccData">单条CallCenter数据</param>
        /// <param name="trans"></param>
        private static void GenerateAOCDataByCallCenterDataITV(CallCenterData ccData,SqlTransaction trans)
        {
            int countInsert, countUpdate;
            GenerateAOCDataByCallCenterDataITV( ccData, trans,out countInsert,out countUpdate);
            ////将CallCenter数据转化为AOC数据类型
            //AOCDataCC aoc = new AOCDataCC();
            //aoc = TransferToAOCDataByCallCenterData(ccData);

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
        /// 轮询同步，单条CallCenter数据同步到AOC库中
        /// </summary>
        /// <param name="ccData">单条CallCenter数据</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">输出结果，Insert数</param>
        /// <param name="countUpdate">输出结果，Update数</param>
        private static void GenerateAOCDataByCallCenterDataITV(CallCenterData ccData,SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            //将CallCenter数据转化为AOC数据类型
            AOCDataCC aoc = new AOCDataCC();
            aoc = TransferToAOCDataByCallCenterData(ccData);

            try
            {
                //轮询同步，将此条AOC类型数据同步到AOC库中
                UpdateOrInsertAOCDataToDBITV(aoc,trans, out countInsert, out countUpdate);
            }
            catch (Exception exSql)
            {
                throw exSql;
            }
        }

        /// <summary>
        /// 每日方式，单条CallCenter数据同步到AOC库中
        /// </summary>
        /// <param name="ccData">单条CallCenter数据</param>
        /// <param name="trans"></param>
        private static void GenerateAOCDataByCallCenterDataDAY(CallCenterData ccData,SqlTransaction trans)
        {
            int countInsert, countUpdate;
            GenerateAOCDataByCallCenterDataDAY(ccData,trans,out countInsert, out countUpdate);
            ////将CallCenter数据转化为AOC数据类型
            //AOCDataCC aoc = new AOCDataCC();
            //aoc = TransferToAOCDataByCallCenterData(ccData);

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
        /// 每日方式，单条CallCenter数据同步到AOC库中
        /// </summary>
        /// <param name="ccData">单条CallCenter数据</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">输出操作记录，Insert数量</param>
        /// <param name="countUpdate">输出操作记录，Update数量</param>
        private static void GenerateAOCDataByCallCenterDataDAY(CallCenterData ccData, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            //将CallCenter数据转化为AOC数据类型
            AOCDataCC aoc = new AOCDataCC();
            aoc = TransferToAOCDataByCallCenterData(ccData);

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
        private static void UpdateOrInsertAOCDataToDBITV(AOCDataCC aoc, SqlTransaction trans)
        {
            int countInsert, countUpdate;
            UpdateOrInsertAOCDataToDBITV(aoc, trans, out countInsert,out countUpdate);
            //try
            //{
            //    //判断执行Update还是Insert,如果当前AOC库中存在相同的URNO记录，则更新，否则新增
            //    if (AOCDataCC.Cache.AOCDataList.Exists(delegate(AOCDataCC aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }))
            //    {
            //        //执行更新操作
            //        aoc.AOCID = AOCDataCC.Cache.AOCDataList.Find(delegate(AOCDataCC aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }).AOCID;
            //        aoc.LSTU = DateTime.Now;
            //        aoc.TYPU = EnumSyncWorkType.ITV.ToString();

            //        aoc.Update(trans);
            //    }
            //    else
            //    {
            //        //执行新增操作
            //        aoc.CDAT = DateTime.Now;
            //        aoc.TYPC = EnumSyncWorkType.ITV.ToString();

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
        /// 轮询方式，单条AOC数据类型同步到AOC库中
        /// </summary>
        /// <param name="aoc">单条AOC数据</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">输出操作记录，Insert数量</param>
        /// <param name="countUpdate">输出操作记录，Update数量</param>
        private static void UpdateOrInsertAOCDataToDBITV(AOCDataCC aoc, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            try
            {
                //判断执行Update还是Insert,如果当前AOC库中存在相同的URNO记录，则更新，否则新增
                if (AOCDataCC.Cache.AOCDataList.Exists(delegate(AOCDataCC aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }))
                {
                    //执行更新操作
                    aoc.AOCID = AOCDataCC.Cache.AOCDataList.Find(delegate(AOCDataCC aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }).AOCID;
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
        private static void UpdateOrInsertAOCDataToDBDAY(AOCDataCC aoc, SqlTransaction trans)
        {
            int countInsert ,countUpdate ;
            UpdateOrInsertAOCDataToDBDAY(aoc, trans, out countInsert, out countUpdate);
            //bool EqualsMFDI = false;
            //bool EqualsDRCT = false;
            //bool EqualAPTIATA = false;
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
            //    if (AOCDataCC.Cache.AOCDataList.Exists(delegate(AOCDataCC aocInList)
            //    {
            //        EqualsMFDI = aocInList.MFDI.Equals(aoc.MFDI, StringComparison.OrdinalIgnoreCase);
            //        EqualsDRCT = aocInList.DRCT.Equals(aoc.DRCT, StringComparison.OrdinalIgnoreCase);
            //        EqualAPTIATA = aocInList.APTIATA.Equals(aoc.APTIATA, StringComparison.OrdinalIgnoreCase);

            //        return EqualsMFDI && EqualsDRCT && EqualAPTIATA;
            //    }))
            //    {
            //        //如果为浦东航班，不执行更新操作
            //        //虹桥航班需执行更新操作
            //        if (aoc.APTIATA.Equals(EnumAOCSync.SHA.ToString()))
            //        {
            //            aoc.AOCID = AOCDataCC.Cache.AOCDataList.Find(delegate(AOCDataCC aocInList)
            //                            {
            //                                EqualsMFDI = aocInList.MFDI.Equals(aoc.MFDI, StringComparison.OrdinalIgnoreCase);
            //                                EqualsDRCT = aocInList.DRCT.Equals(aoc.DRCT, StringComparison.OrdinalIgnoreCase);
            //                                EqualAPTIATA = aocInList.APTIATA.Equals(aoc.APTIATA, StringComparison.OrdinalIgnoreCase);

            //                                return EqualsMFDI && EqualsDRCT && EqualAPTIATA;
            //                            }
            //                        ).AOCID;

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
            //    //throw exSql;
            //}
        }

        /// <summary>
        /// 每日同步，单条AOC数据类型同步到AOC库中
        /// </summary>
        /// <param name="aoc">单条AOC数据</param>
        /// <param name="trans"></param>
        /// <param name="countInsert"></param>
        /// <param name="countUpdate"></param>
        private static void UpdateOrInsertAOCDataToDBDAY(AOCDataCC aoc, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;
            //bool EqualsMFDI = false;
            //bool EqualsDRCT = false;
            //bool EqualAPTIATA = false;
            try
            {
                /*
                 * 判断执行Update还是Insert                
                 * 
                 * */

                if (AOCDataCC.Cache.AOCDataList.Exists(delegate(AOCDataCC aocInList)
                {
                    return aocInList.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase);
                    //EqualsMFDI = aocInList.MFDI.Equals(aoc.MFDI, StringComparison.OrdinalIgnoreCase);
                    //EqualsDRCT = aocInList.DRCT.Equals(aoc.DRCT, StringComparison.OrdinalIgnoreCase);
                    //EqualAPTIATA = aocInList.APTIATA.Equals(aoc.APTIATA, StringComparison.OrdinalIgnoreCase);

                    //return EqualsMFDI && EqualsDRCT && EqualAPTIATA;
                }))
                {

                   //if (aoc.APTIATA.Equals(EnumAOCSync.SHA.ToString()))
                   //{
                        aoc.AOCID = AOCDataCC.Cache.AOCDataList.Find(delegate(AOCDataCC aocInList)
                                        {
                                            return aocInList.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase);
                                            //EqualsMFDI = aocInList.MFDI.Equals(aoc.MFDI, StringComparison.OrdinalIgnoreCase);
                                            //EqualsDRCT = aocInList.DRCT.Equals(aoc.DRCT, StringComparison.OrdinalIgnoreCase);
                                            //EqualAPTIATA = aocInList.APTIATA.Equals(aoc.APTIATA, StringComparison.OrdinalIgnoreCase);
                                            //return EqualsMFDI && EqualsDRCT && EqualAPTIATA;
                                        }
                                    ).AOCID;

                        aoc.LSTU = DateTime.Now;
                        aoc.TYPU = EnumSyncWorkType.DAY.ToString();

                        aoc.Update(trans);

                        countUpdate = 1;
                        countInsert = 0;
                    //}
                    //else
                    //{
                    //    countUpdate = 0;
                    //    countInsert = 0;
                    //}
                }
                else
                {
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

        #region TransferToAOCDataByCallCenterData
        /// <summary>
        /// 单条CallCenterData转换为单条AOCData数据
        /// </summary>
        /// <param name="ccData">单条CallCenterData输入</param>
        /// <returns></returns>
        private static AOCDataCC TransferToAOCDataByCallCenterData(CallCenterData ccData)
        {
            //实例化新AOCData对象
            AOCDataCC aocData = new AOCDataCC();

            //对AOCData对象的每个属性分别赋值
            aocData.STOD = ccData.SCHEDULEDDATETIME;
            aocData.TTYP = ccData.FLIGHTNATURECODE;
            aocData.URNO = ccData.FLIGHTDATAID;
            aocData.DES3 = GetDES3ByCallCenterData(ccData.FLIGHTDIRECTION, ccData.PORTOFCALLIATACODE);
            aocData.ORG3 = GetORG3ByCallCenterData(ccData.FLIGHTDIRECTION, ccData.PORTOFCALLIATACODE);
            aocData.AIRB = GetAIRBByCallCenterData(ccData.FLIGHTDIRECTION, ccData.WHEELSUPDOWNDATETIME);
            aocData.LAND = GetLANDByCallCenterData(ccData.FLIGHTDIRECTION, ccData.WHEELSUPDOWNDATETIME);
            aocData.ATC5 = ccData.AIRCRAFTSUBTYPEIATACODE;
            aocData.VIA1 = GetVIA1ByCallCenterData(ccData.FLIGHTDIRECTION, ccData.PORTOFCALLIATACODE);
            aocData.JFNO = string.Empty;
            aocData.CKIF = ccData.CHECKINDESKRANGE;
            aocData.FLTI = ccData.FLIGHTSECTORCODE;
            aocData.TERM = ccData.PASSENGERTERMINALCODE;
            aocData.STPO = ccData.STANDPOSITION;
            aocData.GENO = ccData.GATENUMBER;
            aocData.DAIA = ccData.DIVERTAIRPORTIATACODE;
            aocData.CSS = ccData.CODESHARESTATUS;
            aocData.EDTA = GetEDTAByCallCenterData(ccData.FLIGHTDIRECTION, ccData.ESTIMATEDDATETIME);
            aocData.EDTD = GetEDTDByCallCenterData(ccData.FLIGHTDIRECTION, ccData.ESTIMATEDDATETIME);
            aocData.SP = ccData.STANDPOSITION;
            aocData.CDR = ccData.CHECKINDESKRANGE;
            aocData.CODT = ccData.CHECKINOPENDATETIME;
            aocData.CCDT = ccData.CHECKINCLOSEDDATETIME;
            aocData.SCDR = ccData.SDCHECKINDESKRANGE;
            aocData.SCODT = ccData.SDCHECKINOPENDATETIME;
            aocData.SCCDT = ccData.SDCHECKINCLOSEDDATETIME;
            aocData.BRC1 = ccData.BAGGAGERECLAIMCAROUSELID;
            aocData.BROD = ccData.BAGGAGERECLAIMOPENDATETIME;
            aocData.BRCD = ccData.BAGGAGERECLAIMCLOSEDDATETIME;
            aocData.SRC2 = ccData.SDBAGRECLAIMCAROUSELID;
            aocData.SBRO = ccData.SDBAGRECLAIMOPENDATETIME;
            aocData.SBRC = ccData.SDBAGRECLAIMCLOSEDDATETIME;
            aocData.GN = ccData.GATENUMBER;
            aocData.GBS = ccData.GATEBOARDINGSTATUS;
            aocData.GODT = ccData.GATEOPENDATETIME;
            aocData.GCDT = ccData.GATECLOSEDDATETIME;
            aocData.SGN = ccData.SDGATENUMBER;
            aocData.SGOD = ccData.SDGATEOPENDATETIME;
            aocData.POCC = GetVIA1ByCallCenterData(ccData.FLIGHTDIRECTION, ccData.PORTOFCALLIATACODE);
            aocData.SGCD = ccData.SDGATECLOSEDDATETIME;
            aocData.ASIA = ccData.AIRCRAFTSUBTYPEIATACODE;
            aocData.DRCT = ccData.FLIGHTDIRECTION;

            // dut to DRCT, D: ORG3 -> AIRPORTIATACODE; DES3 -> PORTOFCALLIATACODE, A: ORG3 -> PORTOFCALLIATACODE; DES3 -> AIRPORTIATACODE
            if (aocData.DRCT.Equals("D", StringComparison.OrdinalIgnoreCase))
            {
                aocData.ORG3 = ccData.AIRPORTIATACODE;
                //aocData.DES3 = ccData.PORTOFCALLIATACODE;
            }
            else if (aocData.DRCT.Equals("A", StringComparison.OrdinalIgnoreCase))
            {
               // aocData.ORG3 = ccData.PORTOFCALLIATACODE;
                aocData.DES3 = ccData.AIRPORTIATACODE;
            }

            aocData.REGN = string.Empty;
            aocData.APTIATA = ccData.AIRPORTIATACODE;
            aocData.USEC = EnumDataBaseSource.CC.ToString();
            aocData.USEU = EnumDataBaseSource.CC.ToString();
            aocData.REMP = ccData.OPERATIONTYPECODE;
            aocData.FLNO = ccData.FLIGHTIDENTITY;

            //remark by march 20140425 此处存在BUG，CallCenterData.Cache不会刷新，所以可能会找不到MASTERFLIGHTDATAID对应航班
            //// Get MasterFlight.FlightID By MFDI
            //CallCenterData cc = CallCenterData.Cache.Load(ccData.MASTERFLIGHTDATAID);

            //if (cc != null)
            //{
            //    aocData.MFDI = cc.FLIGHTIDENTITY;
            //}
            //else
            //{
            //    aocData.MFDI = ccData.FLIGHTIDENTITY;
            //}

            //补全CC的字段
            aocData.ACTUALOFFBLOCKSDATETIME = ccData.ACTUALOFFBLOCKSDATETIME;
            aocData.ACTUALONBLOCKSDATETIME = ccData.ACTUALONBLOCKSDATETIME;
            aocData.AIRCRAFTTERMINALCODE = ccData.AIRCRAFTTERMINALCODE;
            aocData.BAGGAGERECLAIMCAROUSELROLE = ccData.BAGGAGERECLAIMCAROUSELROLE;
            aocData.ESTIMATEDFLIGHTDURATION = ccData.ESTIMATEDFLIGHTDURATION;
            aocData.FIRSTBAGDATETIME = ccData.FIRSTBAGDATETIME;
            aocData.LASTBAGDATETIME = ccData.LASTBAGDATETIME;
            aocData.LATESTKNOWNDATETIME = ccData.LATESTKNOWNDATETIME;
            aocData.LATESTKNOWNDATETIMESOURCE = ccData.LATESTKNOWNDATETIMESOURCE;
            aocData.NEXTSTATIONACTUALDATETIME = ccData.NEXTSTATIONACTUALDATETIME;
            aocData.NEXTSTATIONESTIMATEDDATETIME = ccData.NEXTSTATIONESTIMATEDDATETIME;
            aocData.NEXTSTATIONSCHEDULEDDATETIME = ccData.NEXTSTATIONSCHEDULEDDATETIME;
            aocData.OCCURDATETIME = ccData.OCCURDATETIME;
            aocData.PREVIOUSAIRBORNEDATETIME = ccData.PREVIOUSAIRBORNEDATETIME;
            aocData.PREVIOUSESTIMATEDDATETIME = ccData.PREVIOUSESTIMATEDDATETIME;
            aocData.PREVIOUSSCHEDULEDDATETIME = ccData.PREVIOUSSCHEDULEDDATETIME;
            aocData.SCHEDULEDDATE = ccData.SCHEDULEDDATE;
            aocData.SDBAGRECLAIMCAROUSELROLE = ccData.SDBAGRECLAIMCAROUSELROLE;
            aocData.SDFIRSTBAGDATETIME = ccData.SDFIRSTBAGDATETIME;
            aocData.SDLASTBAGDATETIME = ccData.SDLASTBAGDATETIME;
            aocData.SUPPLEMENTARYINFORMATION = ccData.SUPPLEMENTARYINFORMATION;
            aocData.SUPPLEMENTARYINFORMATIONTEXT = ccData.SUPPLEMENTARYINFORMATIONTEXT;
            aocData.CARRIERIATACODE = ccData.CARRIERIATACODE;
            aocData.CARRIERICAOCODE = ccData.CARRIERICAOCODE;
            aocData.FLIGHTCANCELCODE = ccData.FLIGHTCANCELCODE;
            aocData.FLIGHTFLAG = ccData.FLIGHTFLAG;
            aocData.FLIGHTNUMBER = ccData.FLIGHTNUMBER;
            aocData.FLIGHTREPEATCOUNT = ccData.FLIGHTREPEATCOUNT;
            aocData.FLIGHTSERVICETYPEIATACODE = ccData.FLIGHTSERVICETYPEIATACODE;
            aocData.FLIGHTSTATUSCODE = ccData.FLIGHTSTATUSCODE;
            aocData.FLIGHTSUFFIX = ccData.FLIGHTSUFFIX;
            aocData.FLIGHTTRANSITCODE = ccData.FLIGHTTRANSITCODE;
            aocData.ISGENERALAVIATIONFLIGHT = ccData.ISGENERALAVIATIONFLIGHT;
            aocData.ISRETURNFLIGHT = ccData.ISRETURNFLIGHT;
            aocData.NEWFLIGHTREASON = ccData.NEWFLIGHTREASON;
            aocData.TRANSFERFLIGHTIDENTITY = ccData.TRANSFERFLIGHTIDENTITY;
            //补全CC的字段
            return aocData;
        }

        /// <summary>
        /// 获取目的机场 CallCenter
        /// </summary>
        /// <param name="CallCenterFlightDirection">进离港标志位</param>
        /// <param name="CallCenterPortOfCallIataCode">经停机场列表</param>
        /// <returns></returns>
        private static string GetDES3ByCallCenterData(string CallCenterFlightDirection, string CallCenterPortOfCallIataCode)
        {
            if (string.IsNullOrEmpty(CallCenterFlightDirection) || string.IsNullOrEmpty(CallCenterPortOfCallIataCode))
            {
                return string.Empty;
            }

            //中英文注释，啊哈哈哈哈
            //Chinese & English Explaination,AHHHHHHHHHHHHHHH
            //DES3:only in departure flight,the last airport of PORTOFCALLIATACODE 
            //目的机场，仅存在于离港航班，是经停机场列表中的最后一个机场
            //PORTOFCALLIATACODE is splited by ','
            //经停机场列表按逗号分隔
            if (CallCenterFlightDirection.Equals("D"))
            {
                string splitSymbol = ",";
                if (CallCenterPortOfCallIataCode.Contains(splitSymbol))
                {
                    return CallCenterPortOfCallIataCode.Substring(CallCenterPortOfCallIataCode.LastIndexOf(splitSymbol) + splitSymbol.Length).Trim();
                }
                else
                {
                    return CallCenterPortOfCallIataCode;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取起飞机场 CallCenter
        /// </summary>
        /// <param name="CallCenterFlightDirection">进离港标志位</param>
        /// <param name="CallCenterPortOfCallIataCode">经停机场列表</param>
        /// <returns></returns>
        private static string GetORG3ByCallCenterData(string CallCenterFlightDirection, string CallCenterPortOfCallIataCode)
        {
            if (string.IsNullOrEmpty(CallCenterFlightDirection) || string.IsNullOrEmpty(CallCenterPortOfCallIataCode))
            {
                return string.Empty;
            }

            //ORG3:only in arrival flight,the first airport of PORTOFCALLIATACODE
            //PORTOFCALLIATACODE is splited by ','
            if (CallCenterFlightDirection.Equals("A"))
            {
                string splitSymbol = ",";
                if (CallCenterPortOfCallIataCode.Contains(splitSymbol))
                {
                    return CallCenterPortOfCallIataCode.Substring(0, CallCenterPortOfCallIataCode.IndexOf(splitSymbol)).Trim();
                }
                else
                {
                    return CallCenterPortOfCallIataCode;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取实际出发时间 CallCenter
        /// </summary>
        /// <param name="CallCenterFlightDirection">进离港标志位</param>
        /// <param name="CallCenterWheelsUpDownDateTime">撤轮档上轮档时间</param>
        /// <returns></returns>
        private static string GetAIRBByCallCenterData(string CallCenterFlightDirection, string CallCenterWheelsUpDownDateTime)
        {
            if (string.IsNullOrEmpty(CallCenterFlightDirection) || string.IsNullOrEmpty(CallCenterWheelsUpDownDateTime))
            {
                return string.Empty;
            }

            //only in departure flights
            if (CallCenterFlightDirection.Equals("D"))
            {
                return CallCenterWheelsUpDownDateTime;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取实际到达时间 CallCenter
        /// </summary>
        /// <param name="CallCenterFlightDirection">进离港标志位</param>
        /// <param name="CallCenterWheelsUpDownDateTime">撤轮档上轮档时间</param>
        /// <returns></returns>
        private static string GetLANDByCallCenterData(string CallCenterFlightDirection, string CallCenterWheelsUpDownDateTime)
        {
            if (string.IsNullOrEmpty(CallCenterFlightDirection) || string.IsNullOrEmpty(CallCenterWheelsUpDownDateTime))
            {
                return string.Empty;
            }

            //only in arrival flights
            if (CallCenterFlightDirection.Equals("A"))
            {
                return CallCenterWheelsUpDownDateTime;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取经停机场 CallCenter
        /// </summary>
        /// <param name="CallCenterFlightDirection">进离港标志位</param>
        /// <param name="CallCenterPortOfCallIataCode">经停机场列表</param>
        /// <returns></returns>
        private static string GetVIA1ByCallCenterData(string CallCenterFlightDirection, string CallCenterPortOfCallIataCode)
        {
            if (string.IsNullOrEmpty(CallCenterFlightDirection) || string.IsNullOrEmpty(CallCenterPortOfCallIataCode))
            {
                return string.Empty;
            }

            /*VIA1:
             *Arrival Flights:
             *                1.airport count =1:no VIA1 
             *                2.airport count >1:all airports except the first airport
             *Departure Flights:
             *                1.airport count =1:no VIA1
             *                2.airport count >1:all airports except the last airport
             * 
             * airports are splited by ','
             **/

            string splitSymbol = ",";
            if (CallCenterFlightDirection.Equals("A"))
            {
                if (CallCenterPortOfCallIataCode.Contains(splitSymbol))
                {
                    return CallCenterPortOfCallIataCode.Substring(CallCenterPortOfCallIataCode.IndexOf(splitSymbol) + splitSymbol.Length).Trim();
                }
                else
                {
                    return string.Empty;
                }
            }
            else if (CallCenterFlightDirection.Equals("D"))
            {
                if (CallCenterPortOfCallIataCode.Contains(splitSymbol))
                {
                    return CallCenterPortOfCallIataCode.Remove(CallCenterPortOfCallIataCode.LastIndexOf(splitSymbol)).Trim();
                }
                else
                {
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取预计到达时间 CallCenter
        /// </summary>
        /// <param name="CallCenterFlightDirection"></param>
        /// <param name="CallCenterEstimatedDateTime"></param>
        /// <returns></returns>
        private static string GetEDTAByCallCenterData(string CallCenterFlightDirection, string CallCenterEstimatedDateTime)
        {
            if (string.IsNullOrEmpty(CallCenterFlightDirection) || string.IsNullOrEmpty(CallCenterEstimatedDateTime))
            {
                return string.Empty;
            }

            //EDTA:only in arrival flight
            if (CallCenterFlightDirection.Equals("A"))
            {
                return CallCenterEstimatedDateTime;
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取预计出发时间
        /// </summary>
        /// <param name="CallCenterFlightDirection"></param>
        /// <param name="CallCenterEstimatedDateTime"></param>
        /// <returns></returns>
        private static string GetEDTDByCallCenterData(string CallCenterFlightDirection, string CallCenterEstimatedDateTime)
        {
            if (string.IsNullOrEmpty(CallCenterFlightDirection) || string.IsNullOrEmpty(CallCenterEstimatedDateTime))
            {
                return string.Empty;
            }

            //EDTD:only in departure flight
            if (CallCenterFlightDirection.Equals("D"))
            {
                return CallCenterEstimatedDateTime;
            }

            return string.Empty;
        }
        #endregion
    }
}
