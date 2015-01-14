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
        /// ��ѯͬ������FlightQuerySystem��ͬ�����ൽAOCFQS��(����)
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncFlightQuerySystemToAOCFQSITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
            //��ʼ��count��¼,count���ڼ�¼�������,�ֱ�Ϊ����������������������������
            int countList = int.MinValue;
            int countInsert = int.MinValue;
            int countUpdate = int.MinValue;
            string msgSync = string.Empty;
            //��ʼ����ǰ������Ϣ
            string nameFunction = TextTool.GetFunctionInfo();
            //��ʼ����ѯͬ����ͬ��ʱ�䷶Χ
            DateTime dateTimeStart = dateTimeCheckPoint.AddHours(AOCConfig.INTERVALEVENTBEFORE);
            DateTime dateTimeEnd = dateTimeCheckPoint.AddHours(AOCConfig.INTERVALEVENTAFTER);

            try
            {
                //��ȡFlightQuerySystem���з���ʱ�䷶Χ�����к��Ż�������
                List<FlightQuerySystemData> fqsDataList = FlightQuerySystemData.GetFlightQuerySystemData(dateTimeStart, dateTimeEnd);

                //����ȡ���ĺ���ͬ����AOC����
                if (fqsDataList != null && fqsDataList.Count > 0)
                {
                    //BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataITV(fqsDataList, out countList, out countInsert, out countUpdate);
                    BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataITV(dateTimeCheckPoint, fqsDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;
                    AOCLog.logSuccess(msgSync);

                    //����AOC������Ϣ����
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
        /// ��ѯͬ������FlightQuerySystem��ͬ�����ൽAOCFQS��
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncFlightQuerySystemToAOCFQSSimpleITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
            //��ʼ��count��¼,count���ڼ�¼�������,�ֱ�Ϊ����������������������������
            int countList = int.MinValue;
            int countInsert = int.MinValue;
            int countUpdate = int.MinValue;
            string msgSync = string.Empty;
            //��ʼ����ǰ������Ϣ
            string nameFunction = TextTool.GetFunctionInfo();
            //��ʼ����ѯͬ����ͬ��ʱ�䷶Χ
            DateTime dateTimeStart = dateTimeCheckPoint.AddHours(AOCConfig.INTERVALEVENTBEFORE);
            DateTime dateTimeEnd = dateTimeCheckPoint.AddHours(AOCConfig.INTERVALEVENTAFTER);

            try
            {
                //��ȡFlightQuerySystem���з���ʱ�䷶Χ�����к��Ż�������
                DateTime t1 = DateTime.Now;
                List<FlightQuerySystemData> fqsDataList = FlightQuerySystemData.GetFlightQuerySystemData(dateTimeStart, dateTimeEnd);
                msgSyncOut += "load from FlightQuerySystemData " + fqsDataList.Count + "use " + (DateTime.Now - t1).ToString() + "\r\n";
                //ɾ��ԭ��ʱ�����FQSȫ����¼��new��
                DateTime t2 = DateTime.Now;
                AOCDataFQS.DeleteAOCDataFQSByDateTime(dateTimeStart, dateTimeEnd, null);
                msgSyncOut += "delete from AOCFQS use " + (DateTime.Now - t2).ToString() + "\r\n";
                //����ȡ���ĺ���ͬ����AOC����
                DateTime t3 = DateTime.Now;
                if (fqsDataList != null && fqsDataList.Count > 0)
                {
                    //BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataITV(fqsDataList, out countList, out countInsert, out countUpdate);
                    BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataSimpleITV(dateTimeCheckPoint, fqsDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;
                    AOCLog.logSuccess(msgSync);
                    msgSyncOut += "insert into AOCFQS use " + (DateTime.Now - t3).ToString() + "\r\n";
                    //����AOC������Ϣ����
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
        /// ÿ��ͬ������FlightQuerySystem��ͬ�����к��ൽAOCFQS��
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncFlightQuerySystemToAOCFQSSimpleDAY(DateTime dateTimeCheckPoint, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
            //��ʼ��count��¼,count���ڼ�¼�������,�ֱ�Ϊ����������������������������
            int countList = int.MinValue;
            int countInsert = int.MinValue;
            int countUpdate = int.MinValue;
            string msgSync = string.Empty;

            //��ʼ����ǰ������Ϣ
            string nameFunction = TextTool.GetFunctionInfo();

            //��ʼ��ÿ��ͬ����ͬ��ʱ�䷶Χ
            DateTime dateTimeStart = dateTimeCheckPoint.Date;//����
            DateTime dateTimeEnd = dateTimeCheckPoint.Date.AddHours(AOCConfig.INTERVALEVENTDAILYAFTER).AddSeconds(-1);//��X��ȫ������

            try
            {
                //��ȡFlightQuerySystem���з���ʱ�䷶Χ�����к���
                DateTime t1 = DateTime.Now;
                List<FlightQuerySystemData> fqsDataList = FlightQuerySystemData.GetFlightQuerySystemData(dateTimeStart, dateTimeEnd);
                msgSyncOut += "load from FlightQuerySystemData " + fqsDataList.Count + "use " + (DateTime.Now - t1).ToString() + "\r\n";
                //ɾ��ԭ��ʱ�����FQSȫ����¼
                DateTime t2 = DateTime.Now;
                AOCDataFQS.DeleteAOCDataFQSByDateTime(dateTimeStart, dateTimeEnd, null);
                msgSyncOut += "delete from AOCFQS use " + (DateTime.Now - t2).ToString() + "\r\n";
                //����ȡ�������к���ͬ����AOC����
                DateTime t3 = DateTime.Now;
                if (fqsDataList != null && fqsDataList.Count > 0)
                {
                    BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataSimpleDAY(fqsDataList, out countList, out countInsert, out countUpdate);

                    msgSync = AOCLog.GenerateSuccessMSGForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);
                    msgSyncOut += ",insert into AOCFQS use " + (DateTime.Now - t3).ToString() + "\r\n";
                    //����AOC������Ϣ����
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
        /// ÿ��ͬ������FlightQuerySystem��ͬ�����к��ൽAOCFQS��(���㷨����ʹ��)
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncFlightQuerySystemToAOCFQSDAY(DateTime dateTimeCheckPoint, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
            //��ʼ��count��¼,count���ڼ�¼�������,�ֱ�Ϊ����������������������������
            int countList = int.MinValue;
            int countInsert = int.MinValue;
            int countUpdate = int.MinValue;
            string msgSync = string.Empty;
            //��ʼ����ǰ������Ϣ
            string nameFunction = TextTool.GetFunctionInfo();
            //��ʼ��ÿ��ͬ����ͬ��ʱ�䷶Χ
            DateTime dateTimeStart = dateTimeCheckPoint.Date;//����
            DateTime dateTimeEnd = dateTimeCheckPoint.Date.AddHours(AOCConfig.INTERVALEVENTDAILYAFTER).AddSeconds(-1);//��X��ȫ������

            try
            {
                //��ȡFlightQuerySystem���з���ʱ�䷶Χ�����к���
                List<FlightQuerySystemData> fqsDataList = FlightQuerySystemData.GetFlightQuerySystemData(dateTimeStart, dateTimeEnd);

                //����ȡ�������к���ͬ����AOC����
                if (fqsDataList != null && fqsDataList.Count > 0)
                {
                    //BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataDAY(fqsDataList, out countList, out countInsert, out countUpdate);
                    BLFlightQuerySystemSyncTOAOC.GenerateAOCDataByFlightQuerySystemDataDAY(dateTimeCheckPoint, fqsDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForFlightQuerySystemSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //����AOC������Ϣ����
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
        /// ��ѯͬ�������õ���FlightQuerySystem������ͬ����AOCFQS����
        /// </summary>
        /// <param name="fqsDataList">FlightQuerySystem������</param>
        public static void GenerateAOCDataByFlightQuerySystemDataITV(List<FlightQuerySystemData> fqsDataList)
        {
            //��ִ��ͬ��ǰȥ�����ݿ����Ӳ�����SqlTransaction���ع�����
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                    //��FlightQuerySystem�������е�������������AOC����
                    foreach (FlightQuerySystemData fqsData in fqsDataList)
                    {
                        GenerateAOCDataByFlightQuerySystemDataITV(fqsData, trans);
                    }
                    trans.Commit();//���ݿ����ȫ���ɹ���COMMIT

                    //����AOC������Ϣ����
                    AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();//�����ݲ������ɹ�ʱ��ȫ���ع�
                    throw exSql;
                }
                finally
                {
                    connSql.Close();//�ر����ݿ�����
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

            //��ִ��ͬ��ǰȥ�����ݿ����Ӳ�����SqlTransaction���ع�����
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                ///////////////////////////////////////////////////////////////////
                //�ӻ������ҵ���ǰ��Χ��FQS
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
                SqlTransaction trans = connSql.BeginTransaction();//�򿪻ع�����
                try
                {
                    //��FlightQuerySystem�������е�������������AOC����
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
                        ////���µģ���aocDataFQSList��ȥ������ʣ�µľ���Ҫɾ����
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
                    trans.Commit();//���ݿ����ȫ���ɹ���COMMIT

                    //����AOC������Ϣ����
                    AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();//�����ݲ������ɹ�ʱ��ȫ���ع�
                    countInsert = -1;
                    countUpdate = -1;
                    throw exSql;
                }
                finally
                {
                    connSql.Close();//�ر����ݿ�����
                }
            }
        }
        //(����)
        public static void GenerateAOCDataByFlightQuerySystemDataITV(DateTime dt, List<FlightQuerySystemData> fqsDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = fqsDataList.Count;
            countInsert = 0;
            countUpdate = 0;
            int resultInsert = 0;
            int resultUpdate = 0;

            //��ִ��ͬ��ǰȥ�����ݿ����Ӳ�����SqlTransaction���ع�����
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                ///////////////////////////////////////////////////////////////////
                //�ӻ������ҵ���ǰ��Χ��FQS
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
                SqlTransaction trans = connSql.BeginTransaction();//�򿪻ع�����
                try
                {
                    //��FlightQuerySystem�������е�������������AOC����
                    foreach (FlightQuerySystemData fqsData in fqsDataList)
                    {
                        GenerateAOCDataByFlightQuerySystemDataITV(fqsData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                        ///////////////////////////////////////////////////////////
                        //���µģ���aocDataFQSList��ȥ������ʣ�µľ���Ҫɾ����
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
                    trans.Commit();//���ݿ����ȫ���ɹ���COMMIT

                    //����AOC������Ϣ����
                    AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();//�����ݲ������ɹ�ʱ��ȫ���ع�
                    countInsert = 0;
                    countUpdate = 0;
                    throw exSql;
                }
                finally
                {
                    connSql.Close();//�ر����ݿ�����
                }
            }
        }

        /// <summary>
        /// ��ѯͬ�������õ���FlightQuerySystem������ͬ����AOC����
        /// </summary>
        /// <param name="fqsDataList">FlightQuerySystem������</param>
        /// <param name="countList">������ FlightQuerySystem�����ݲ�������</param>
        /// <param name="countInsert">������ FlightQuerySystem������insert����</param>
        /// <param name="countUpdate">������ FlightQuerySystem������update����</param>
        public static void GenerateAOCDataByFlightQuerySystemDataITV(List<FlightQuerySystemData> fqsDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = fqsDataList.Count;
            countInsert = 0;
            countUpdate = 0;
            int resultInsert = 0;
            int resultUpdate = 0;

            //��ִ��ͬ��ǰȥ�����ݿ����Ӳ�����SqlTransaction���ع�����
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();//�򿪻ع�����
                try
                {
                    //��FlightQuerySystem�������е�������������AOC����
                    foreach (FlightQuerySystemData ccData in fqsDataList)
                    {
                        GenerateAOCDataByFlightQuerySystemDataITV(ccData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                    }
                    trans.Commit();//���ݿ����ȫ���ɹ���COMMIT

                    //����AOC������Ϣ����
                    AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();//�����ݲ������ɹ�ʱ��ȫ���ع�
                    countInsert = 0;
                    countUpdate = 0;
                    throw exSql;
                }
                finally
                {
                    connSql.Close();//�ر����ݿ�����
                }
            }
        }

        /// <summary>
        /// ÿ��ͬ�������õ���FlightQuerySystem������ͬ����AOC����
        /// </summary>
        /// <param name="fqsDataList">FlightQuerySystem������</param>
        public static void GenerateAOCDataByFlightQuerySystemDataDAY(List<FlightQuerySystemData> fqsDataList)
        {
            //��ִ��ͬ��ǰȥ�����ݿ����Ӳ�����SqlTransaction���ع�����
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                    //��FlightQuerySystem�������е�������������AOC����
                    foreach (FlightQuerySystemData ccData in fqsDataList)
                    {
                        GenerateAOCDataByFlightQuerySystemDataDAY(ccData, trans);
                    }
                    trans.Commit();//���ݿ����ȫ���ɹ���COMMIT

                    //����AOC������Ϣ����
                    AOCDataFQS.Cache.RefreshCache();
                }
                catch (Exception exSql)
                {
                    trans.Rollback();//�����ݲ������ɹ�ʱ��ȫ���ع�
                    throw exSql;
                }
                finally
                {
                    connSql.Close();//�ر����ݿ�����
                }
            }
        }

        /// <summary>
        /// ���㷨
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
                        //��FlightQuerySystem����ת��ΪAOC��������
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
                        ////���µģ���aocDataFQSList��ȥ������ʣ�µľ���Ҫɾ����
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

                    //����AOC������Ϣ����
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
        /// ���㷨�ѱ��Ż�
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
                    //�ӻ������ҵ���ǰ��Χ��FQS
                    DateTime dateTimeStart = dt.Date;//����
                    DateTime dateTimeEnd = dt.Date.AddHours(AOCConfig.INTERVALEVENTDAILYAFTER).AddSeconds(-1);//��X��ȫ������
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
                        //���µģ���aocDataFQSList��ȥ������ʣ�µľ���Ҫɾ����
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

                    //����AOC������Ϣ����
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
        /// ÿ��ͬ�������õ���FlightQuerySystem������ͬ����AOC����
        /// </summary>
        /// <param name="fqsDataList">FlightQuerySystem������</param>
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

                    //����AOC������Ϣ����
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
        /// ��ѯͬ�������õ���FlightQuerySystem������ͬ����AOC����
        /// </summary>
        /// <param name="fqsData">����FlightQuerySystem����</param>
        /// <param name="trans"></param>
        private static void GenerateAOCDataByFlightQuerySystemDataITV(FlightQuerySystemData fqsData, SqlTransaction trans)
        {
            int countInsert, countUpdate;
            GenerateAOCDataByFlightQuerySystemDataITV(fqsData, trans, out countInsert, out countUpdate);
            ////��FlightQuerySystem����ת��ΪAOC��������
            //AOCDataFQS aoc = new AOCDataFQS();
            //aoc = TransferToAOCDataByFlightQuerySystemData(ccData);

            //try
            //{
            //    //��ѯͬ����������AOC��������ͬ����AOC����
            //    UpdateOrInsertAOCDataToDBITV(aoc, trans);
            //}
            //catch (Exception exSql)
            //{
            //    throw exSql;
            //}
        }

        /// <summary>
        /// ��ѯͬ��������FlightQuerySystem����ͬ����AOC����
        /// </summary>
        /// <param name="ccData">����FlightQuerySystem����</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">��������Insert��</param>
        /// <param name="countUpdate">��������Update��</param>
        private static void GenerateAOCDataByFlightQuerySystemDataITV(FlightQuerySystemData ccData, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            //��FlightQuerySystem����ת��ΪAOC��������
            AOCDataFQS aoc = new AOCDataFQS();
            aoc = TransferToAOCDataByFlightQuerySystemData(ccData);

            try
            {
                //��ѯͬ����������AOC��������ͬ����AOC����
                UpdateOrInsertAOCDataToDBITV(aoc, trans, out countInsert, out countUpdate);
            }
            catch (Exception exSql)
            {
                throw exSql;
            }
        }

        /// <summary>
        /// ÿ�շ�ʽ������FlightQuerySystem����ͬ����AOC����
        /// </summary>
        /// <param name="ccData">����FlightQuerySystem����</param>
        /// <param name="trans"></param>
        private static void GenerateAOCDataByFlightQuerySystemDataDAY(FlightQuerySystemData fqsData, SqlTransaction trans)
        {
            int countInsert;
            int countUpdate;
            GenerateAOCDataByFlightQuerySystemDataDAY(fqsData, trans, out countInsert, out countUpdate);
            ////��FlightQuerySystem����ת��ΪAOC��������
            //AOCDataFQS aoc = new AOCDataFQS();
            //aoc = TransferToAOCDataByFlightQuerySystemData(ccData);

            //try
            //{
            //    //ÿ�շ�ʽ��������AOC��������ͬ����AOC����
            //    UpdateOrInsertAOCDataToDBDAY(aoc,trans);
            //}
            //catch (Exception exSql)
            //{
            //    throw exSql;
            //}
        }

        /// <summary>
        /// ÿ�շ�ʽ������FlightQuerySystem����ͬ����AOC����
        /// </summary>
        /// <param name="fqsData">����FlightQuerySystem����</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">���������¼��Insert����</param>
        /// <param name="countUpdate">���������¼��Update����</param>
        private static void GenerateAOCDataByFlightQuerySystemDataDAY(FlightQuerySystemData fqsData, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            //��FlightQuerySystem����ת��ΪAOC��������
            AOCDataFQS aoc = new AOCDataFQS();
            aoc = TransferToAOCDataByFlightQuerySystemData(fqsData);

            try
            {
                //ÿ�շ�ʽ��������AOC��������ͬ����AOC����
                UpdateOrInsertAOCDataToDBDAY(aoc, trans, out countInsert, out countUpdate);
            }
            catch (Exception exSql)
            {
                throw exSql;
            }
        }

        /// <summary>
        /// ��ѯ��ʽ������AOC��������ͬ����AOC����
        /// </summary>
        /// <param name="aoc">����AOC����</param>
        /// <param name="trans"></param>
        private static void UpdateOrInsertAOCDataToDBITV(AOCDataFQS aoc, SqlTransaction trans)
        {
            try
            {
                //�ж�ִ��Update����Insert,�����ǰAOC���д�����ͬ��URNO��¼������£���������
                if (AOCDataFQS.Cache.AOCDataList.Exists(delegate(AOCDataFQS aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }))
                {
                    //ִ�и��²���
                    aoc.ID = AOCDataFQS.Cache.AOCDataList.Find(delegate(AOCDataFQS aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }).ID;
                    aoc.LSTU = DateTime.Now;
                    aoc.TYPU = EnumSyncWorkType.ITV.ToString();

                    aoc.Update(trans);
                }
                else
                {
                    //ִ����������
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
        /// ��ѯ��ʽ������AOC��������ͬ����AOC����
        /// </summary>
        /// <param name="aoc">����AOC����</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">���������¼��Insert����</param>
        /// <param name="countUpdate">���������¼��Update����</param>
        private static void UpdateOrInsertAOCDataToDBITV(AOCDataFQS aoc, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            try
            {
                //�ж�ִ��Update����Insert,�����ǰAOC���д�����ͬ��URNO��¼������£���������
                if (AOCDataFQS.Cache.AOCDataList.Exists(delegate(AOCDataFQS aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }))
                {
                    //ִ�и��²���
                    aoc.ID = AOCDataFQS.Cache.AOCDataList.Find(delegate(AOCDataFQS aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }).ID;
                    aoc.LSTU = DateTime.Now;
                    aoc.TYPU = EnumSyncWorkType.ITV.ToString();

                    aoc.Update(trans);
                    countUpdate = 1;
                    countInsert = 0;
                }
                else
                {
                    //ִ����������
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
        /// ÿ��ͬ��������AOC��������ͬ����AOC����
        /// </summary>
        /// <param name="aoc">����AOC����</param>
        /// <param name="trans"></param>
        private static void UpdateOrInsertAOCDataToDBDAY(AOCDataFQS aoc, SqlTransaction trans)
        {
            int countInsert, countUpdate;
            UpdateOrInsertAOCDataToDBDAY(aoc, trans, out countInsert, out countUpdate);
            //bool EqualURNO = false;
            //try
            //{
            //    /*
            //     * �ж�ִ��Update����Insert
            //     * �����ǰAOC���е���Ҫ�أ�MFDI,DRCT,APTIATA���Ƿ���ȫ��ͬ��
            //     * MFDI:�����
            //     * DRCT:�����
            //     * APTIATA:��������
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
            //        //ִ����������
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
        /// ÿ��ͬ��������AOC��������ͬ����AOC����
        /// </summary>
        /// <param name="aoc">����AOC����</param>
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
                 * �ж�ִ��Update����Insert
                 * �����ǰAOCFQS���е�URNO�Ƿ���ȫ��ͬ��                
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
        /// ����һ����Ϣ����ǰʱ���û����Ҫͬ��������
        /// </summary>
        /// <param name="NameFunction">ִ��ͬ���ķ���</param>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <returns></returns>
        private static string GenerateMsgNoData(string NameFunction, DateTime dateTimeCheckPoint)
        {
            return string.Format("{0} No data of this checkPointTime:{1}", NameFunction, dateTimeCheckPoint.ToString());
        }

        #region TransferToAOCDataByFlightQuerySystemData
        /// <summary>
        /// ����FlightQuerySystemDataת��Ϊ����AOCData����
        /// </summary>
        /// <param name="fqsData">����FlightQuerySystemData����</param>
        /// <returns></returns>
        private static AOCDataFQS TransferToAOCDataByFlightQuerySystemData(FlightQuerySystemData fqsData)
        {
            //ʵ������AOCData����
            AOCDataFQS aocData = new AOCDataFQS();

            //��AOCData�����ÿ�����Էֱ�ֵ
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
