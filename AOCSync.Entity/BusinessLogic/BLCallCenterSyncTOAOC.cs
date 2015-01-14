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
        /// ��ѯͬ������CallCenter��ͬ������(����)
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncCallCenterToAOCITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //��ȡCallCenter���з���ʱ�䷶Χ�����к��Ż�������
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd);

                //����ȡ���ĺ���ͬ����AOC����
                if (ccDataList != null && ccDataList.Count > 0)
                {
                    //BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(dateTimeCheckPoint,ccDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //����AOC������Ϣ����
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
        /// ��ѯͬ������CallCenter��ͬ������(���㷨)
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncCallCenterToAOCSimpleITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //��ȡCallCenter���з���ʱ�䷶Χ�����к��Ż�������
                DateTime t1 = DateTime.Now;
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd);                
                msgSyncOut += "load from CallCenterData " + ccDataList.Count + "use " + (DateTime.Now - t1).ToString() + "\r\n";
                //ɾ��ԭ��ʱ�����CCȫ����¼
                DateTime t2 = DateTime.Now; 
                AOCDataCC.DeleteAOCDataCCByDateTime(dateTimeStart, dateTimeEnd, null);               
                msgSyncOut += "delete from AOC use " + (DateTime.Now - t2).ToString() + "\r\n";
                //����ȡ���ĺ���ͬ����AOC����
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
                    //����AOC������Ϣ����
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
        /// ��ѯͬ������CallCenter��ͬ�����ź��ࣨ���㷨��
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncCallCenterSHAToAOCSimpleITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //��ȡCallCenter���з���ʱ�䷶Χ�����к��Ż�������
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd).FindAll(delegate(CallCenterData callCenterData)
                {
                    return callCenterData.AIRPORTIATACODE.Equals(AOCSync.Entity.AOCEnum.EnumAOCSync.SHA.ToString());
                });

                //ɾ��ԭ��ʱ�����CC����ȫ����¼
                AOCDataCC.DeleteAOCSHADataCCByDateTime(dateTimeStart, dateTimeEnd, null);


                //����ȡ���ĺ���ͬ����AOC����
                if (ccDataList != null && ccDataList.Count > 0)
                {
                   // BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataSimpleITV(ccDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //����AOC������Ϣ����
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
        /// ��ѯͬ������CallCenter��ͬ�����ź���(����)
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncCallCenterSHAToAOCITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //��ȡCallCenter���з���ʱ�䷶Χ�����к��Ż�������
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd).FindAll(delegate(CallCenterData callCenterData)
                {
                    return callCenterData.AIRPORTIATACODE.Equals(AOCSync.Entity.AOCEnum.EnumAOCSync.SHA.ToString());
                });

                //����ȡ���ĺ���ͬ����AOC����
                if (ccDataList != null && ccDataList.Count > 0)
                {
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);

                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //����AOC������Ϣ����
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
        /// ��ѯͬ������CallCenter��ͬ���ֶ�����(���㷨)
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncCallCenterPVGToAOCSimpleITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //��ȡCallCenter���з���ʱ�䷶Χ�������ֶ���������
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd).FindAll(delegate(CallCenterData callCenterData)
                {
                    return callCenterData.AIRPORTIATACODE.Equals(AOCSync.Entity.AOCEnum.EnumAOCSync.PVG.ToString());
                });

                //ɾ��ԭ��ʱ�����CC �ֶ�ȫ����¼
                AOCDataCC.DeleteAOCPVGDataCCByDateTime(dateTimeStart, dateTimeEnd, null);

                //����ȡ���ĺ���ͬ����AOC����
                if (ccDataList != null && ccDataList.Count > 0)
                {
                   // BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataSimpleITV(ccDataList, out countList, out countInsert, out countUpdate);

                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //����AOC������Ϣ����
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
        /// ��ѯͬ������CallCenter��ͬ���ֶ�����(����)
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncCallCenterPVGToAOCITV(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //��ȡCallCenter���з���ʱ�䷶Χ�������ֶ���������
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd).FindAll(delegate(CallCenterData callCenterData)
                {
                    return callCenterData.AIRPORTIATACODE.Equals(AOCSync.Entity.AOCEnum.EnumAOCSync.PVG.ToString());
                });

                //����ȡ���ĺ���ͬ����AOC����
                if (ccDataList != null && ccDataList.Count > 0)
                {
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);

                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //����AOC������Ϣ����
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
        /// ÿ��ͬ������CallCenter��ͬ�����к��ൽAOC��
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncCallCenterToAOCSimpleDAY(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //��ȡCallCenter���з���ʱ�䷶Χ�����к���
                DateTime t1 = DateTime.Now;
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd);               
                msgSyncOut += "load from CallCenterData " + ccDataList.Count + "use " + (DateTime.Now - t1).ToString() + "\r\n";
                //ɾ��ԭ��ʱ�����CCȫ����¼
                DateTime t2 = DateTime.Now;               
                AOCDataCC.DeleteAOCDataCCByDateTime(dateTimeStart, dateTimeEnd, null);
                msgSyncOut += "delete from AOC use " + (DateTime.Now - t2).ToString() + "\r\n";
                DateTime t3 = DateTime.Now;
                //����ȡ�������к���ͬ����AOC����
                if (ccDataList != null && ccDataList.Count > 0)
                {
                    //BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataDAY(ccDataList, out countList, out countInsert, out countUpdate);
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataSimpleDAY(ccDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);
                    msgSyncOut += ",insert into AOC use " + (DateTime.Now - t3).ToString() + "\r\n";
                    //����AOC������Ϣ����
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
        /// ÿ��ͬ������CallCenter��ͬ�����к��ൽAOC�⣨�Ѳ�ʹ�ã�
        /// </summary>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <param name="msgSyncOut">��������ͬ�����</param>
        public static void SyncCallCenterToAOCDAY(DateTime dateTimeCheckPoint, out string msgSyncOut)
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
                //��ȡCallCenter���з���ʱ�䷶Χ�����к���
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd);
                
                //����ȡ�������к���ͬ����AOC����
                if (ccDataList != null && ccDataList.Count > 0)
                {
                    //BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataDAY(ccDataList, out countList, out countInsert, out countUpdate);
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataDAY(dateTimeCheckPoint,ccDataList, out countList, out countInsert, out countUpdate);
                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //����AOC������Ϣ����
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
        /// ��ѯͬ�������õ���CallCenter������ͬ����AOC����
        /// </summary>
        /// <param name="ccDataList">CallCenter������</param>
        public static void GenerateAOCDataByCallCenterDataITV(List<CallCenterData> ccDataList)
        {
            //��ִ��ͬ��ǰȥ�����ݿ����Ӳ�����SqlTransaction���ع�����
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                    //��CallCenter�������е�������������AOC����
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        GenerateAOCDataByCallCenterDataITV(ccData, trans);
                    }
                    trans.Commit();//���ݿ����ȫ���ɹ���COMMIT

                    //����AOC������Ϣ����
                    AOCDataCC.Cache.RefreshCache();
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
        //(����)
        public static void GenerateAOCDataByCallCenterDataITV(DateTime dt,List<CallCenterData> ccDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = ccDataList.Count;
            countInsert = 0;
            countUpdate = 0;
            int resultInsert = 0;
            int resultUpdate = 0;

            //��ִ��ͬ��ǰȥ�����ݿ����Ӳ�����SqlTransaction���ع�����
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                ///////////////////////////////////////////////////////////////////
                //�ӻ������ҵ���ǰ��Χ��CC
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
                SqlTransaction trans = connSql.BeginTransaction();//�򿪻ع�����
                try
                {
                    
                    //��CallCenter�������е�������������AOC����
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        GenerateAOCDataByCallCenterDataITV(ccData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                        ///////////////////////////////////////////////////////////
                        //���µģ���aocDataFQSList��ȥ������ʣ�µľ���Ҫɾ����
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
                    trans.Commit();//���ݿ����ȫ���ɹ���COMMIT

                    //����AOC������Ϣ����
                    AOCDataCC.Cache.RefreshCache();
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
        //���㷨
        public static void GenerateAOCDataByCallCenterDataSimpleITV(DateTime dt, List<CallCenterData> ccDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = ccDataList.Count;
            countInsert = 0;
            countUpdate = 0;
            //int resultInsert = 0;
            //int resultUpdate = 0;

            //��ִ��ͬ��ǰȥ�����ݿ����Ӳ�����SqlTransaction���ع�����
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
               

                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();//�򿪻ع�����
                try
                {

                    //��CallCenter�������е�������������AOC����
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        AOCDataCC aoc = new AOCDataCC();
                        aoc = TransferToAOCDataByCallCenterData(ccData);
                        //add by march 20140425��ccDataList�в���MASTERFLIGHTDATAID
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

                        trans.Commit();//���ݿ����ȫ���ɹ���COMMIT

                        //����AOC������Ϣ����
                        AOCDataCC.Cache.RefreshCache();
                   
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
        /// ��ѯͬ�������õ���CallCenter������ͬ����AOC���У����㷨��
        /// </summary>
        /// <param name="ccDataList">CallCenter������</param>
        /// <param name="countList">������ CallCenter�����ݲ�������</param>
        /// <param name="countInsert">������ CallCenter������insert����</param>
        /// <param name="countUpdate">������ CallCenter������update����</param>
        public static void GenerateAOCDataByCallCenterDataSimpleITV(List<CallCenterData> ccDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = ccDataList.Count;
            countInsert = 0;
            countUpdate = 0;
           

            //��ִ��ͬ��ǰȥ�����ݿ����Ӳ�����SqlTransaction���ع�����
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();//�򿪻ع�����
                try
                {
                    //��CallCenter�������е�������������AOC����
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        //��CallCenter����ת��ΪAOC��������
                        AOCDataCC aoc = new AOCDataCC();
                        aoc = TransferToAOCDataByCallCenterData(ccData);

                        aoc.CDAT = DateTime.Now;
                        aoc.LSTU = DateTime.Now;
                        aoc.TYPC = EnumSyncWorkType.DAY.ToString();
                        aoc.Insert(trans);

                        countInsert++;
                    }
                    trans.Commit();//���ݿ����ȫ���ɹ���COMMIT

                    //����AOC������Ϣ����
                    AOCDataCC.Cache.RefreshCache();
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
        /// ��ѯͬ�������õ���CallCenter������ͬ����AOC���У����ã�
        /// </summary>
        /// <param name="ccDataList">CallCenter������</param>
        /// <param name="countList">������ CallCenter�����ݲ�������</param>
        /// <param name="countInsert">������ CallCenter������insert����</param>
        /// <param name="countUpdate">������ CallCenter������update����</param>
        public static void GenerateAOCDataByCallCenterDataITV(List<CallCenterData> ccDataList, out int countList, out int countInsert, out int countUpdate)
        {
            countList = ccDataList.Count;
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
                    //��CallCenter�������е�������������AOC����
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        GenerateAOCDataByCallCenterDataITV(ccData, trans, out resultInsert, out resultUpdate);
                        countInsert += resultInsert;
                        countUpdate += resultUpdate;
                    }
                    trans.Commit();//���ݿ����ȫ���ɹ���COMMIT

                    //����AOC������Ϣ����
                    AOCDataCC.Cache.RefreshCache();
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
        /// ÿ��ͬ�������õ���CallCenter������ͬ����AOC����
        /// </summary>
        /// <param name="ccDataList">CallCenter������</param>
        public static void GenerateAOCDataByCallCenterDataDAY(List<CallCenterData> ccDataList)
        {
            //��ִ��ͬ��ǰȥ�����ݿ����Ӳ�����SqlTransaction���ع�����
            using (SqlConnection connSql = DataAccess.ConnectStringMsSql.GetConnection())
            {
                connSql.Open();
                SqlTransaction trans = connSql.BeginTransaction();
                try
                {
                    //��CallCenter�������е�������������AOC����
                    foreach (CallCenterData ccData in ccDataList)
                    {
                        GenerateAOCDataByCallCenterDataDAY(ccData, trans);
                    }
                    trans.Commit();//���ݿ����ȫ���ɹ���COMMIT
                    
                    //����AOC������Ϣ����
                    AOCDataCC.Cache.RefreshCache();
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

                        //��CallCenter����ת��ΪAOC��������
                        AOCDataCC aoc = new AOCDataCC();
                        aoc = TransferToAOCDataByCallCenterData(ccData);
                        //add by march 20140425��ccDataList�в���MASTERFLIGHTDATAID
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

                    //����AOC������Ϣ����
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
        /// �ɷ������Ѳ�ʹ�ã�
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
                    //�ӻ������ҵ���ǰ��Χ��CC
                    DateTime dateTimeStart = dt.Date;
                    DateTime dateTimeEnd = dt.Date.AddHours(AOCConfig.INTERVALEVENTDAILYAFTER).AddSeconds(-1);//��X��ȫ������
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
                        //���µģ���aocDataFQSList��ȥ������ʣ�µľ���Ҫɾ����
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

                    //����AOC������Ϣ����
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
        /// ÿ��ͬ�������õ���CallCenter������ͬ����AOC����
        /// </summary>
        /// <param name="ccDataList">CallCenter������</param>
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

                    //����AOC������Ϣ����
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
        /// ��ѯͬ�������õ���CallCenter������ͬ����AOC����
        /// </summary>
        /// <param name="ccData">����CallCenter����</param>
        /// <param name="trans"></param>
        private static void GenerateAOCDataByCallCenterDataITV(CallCenterData ccData,SqlTransaction trans)
        {
            int countInsert, countUpdate;
            GenerateAOCDataByCallCenterDataITV( ccData, trans,out countInsert,out countUpdate);
            ////��CallCenter����ת��ΪAOC��������
            //AOCDataCC aoc = new AOCDataCC();
            //aoc = TransferToAOCDataByCallCenterData(ccData);

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
        /// ��ѯͬ��������CallCenter����ͬ����AOC����
        /// </summary>
        /// <param name="ccData">����CallCenter����</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">��������Insert��</param>
        /// <param name="countUpdate">��������Update��</param>
        private static void GenerateAOCDataByCallCenterDataITV(CallCenterData ccData,SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            //��CallCenter����ת��ΪAOC��������
            AOCDataCC aoc = new AOCDataCC();
            aoc = TransferToAOCDataByCallCenterData(ccData);

            try
            {
                //��ѯͬ����������AOC��������ͬ����AOC����
                UpdateOrInsertAOCDataToDBITV(aoc,trans, out countInsert, out countUpdate);
            }
            catch (Exception exSql)
            {
                throw exSql;
            }
        }

        /// <summary>
        /// ÿ�շ�ʽ������CallCenter����ͬ����AOC����
        /// </summary>
        /// <param name="ccData">����CallCenter����</param>
        /// <param name="trans"></param>
        private static void GenerateAOCDataByCallCenterDataDAY(CallCenterData ccData,SqlTransaction trans)
        {
            int countInsert, countUpdate;
            GenerateAOCDataByCallCenterDataDAY(ccData,trans,out countInsert, out countUpdate);
            ////��CallCenter����ת��ΪAOC��������
            //AOCDataCC aoc = new AOCDataCC();
            //aoc = TransferToAOCDataByCallCenterData(ccData);

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
        /// ÿ�շ�ʽ������CallCenter����ͬ����AOC����
        /// </summary>
        /// <param name="ccData">����CallCenter����</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">���������¼��Insert����</param>
        /// <param name="countUpdate">���������¼��Update����</param>
        private static void GenerateAOCDataByCallCenterDataDAY(CallCenterData ccData, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            //��CallCenter����ת��ΪAOC��������
            AOCDataCC aoc = new AOCDataCC();
            aoc = TransferToAOCDataByCallCenterData(ccData);

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
        private static void UpdateOrInsertAOCDataToDBITV(AOCDataCC aoc, SqlTransaction trans)
        {
            int countInsert, countUpdate;
            UpdateOrInsertAOCDataToDBITV(aoc, trans, out countInsert,out countUpdate);
            //try
            //{
            //    //�ж�ִ��Update����Insert,�����ǰAOC���д�����ͬ��URNO��¼������£���������
            //    if (AOCDataCC.Cache.AOCDataList.Exists(delegate(AOCDataCC aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }))
            //    {
            //        //ִ�и��²���
            //        aoc.AOCID = AOCDataCC.Cache.AOCDataList.Find(delegate(AOCDataCC aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }).AOCID;
            //        aoc.LSTU = DateTime.Now;
            //        aoc.TYPU = EnumSyncWorkType.ITV.ToString();

            //        aoc.Update(trans);
            //    }
            //    else
            //    {
            //        //ִ����������
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
        /// ��ѯ��ʽ������AOC��������ͬ����AOC����
        /// </summary>
        /// <param name="aoc">����AOC����</param>
        /// <param name="trans"></param>
        /// <param name="countInsert">���������¼��Insert����</param>
        /// <param name="countUpdate">���������¼��Update����</param>
        private static void UpdateOrInsertAOCDataToDBITV(AOCDataCC aoc, SqlTransaction trans, out int countInsert, out int countUpdate)
        {
            countInsert = int.MinValue;
            countUpdate = int.MinValue;

            try
            {
                //�ж�ִ��Update����Insert,�����ǰAOC���д�����ͬ��URNO��¼������£���������
                if (AOCDataCC.Cache.AOCDataList.Exists(delegate(AOCDataCC aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }))
                {
                    //ִ�и��²���
                    aoc.AOCID = AOCDataCC.Cache.AOCDataList.Find(delegate(AOCDataCC aocTemp) { return aocTemp.URNO.Equals(aoc.URNO, StringComparison.OrdinalIgnoreCase); }).AOCID;
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
            //     * �ж�ִ��Update����Insert
            //     * �����ǰAOC���е���Ҫ�أ�MFDI,DRCT,APTIATA���Ƿ���ȫ��ͬ��
            //     * MFDI:�����
            //     * DRCT:�����
            //     * APTIATA:��������
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
            //        //���Ϊ�ֶ����࣬��ִ�и��²���
            //        //���ź�����ִ�и��²���
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
            //    //throw exSql;
            //}
        }

        /// <summary>
        /// ÿ��ͬ��������AOC��������ͬ����AOC����
        /// </summary>
        /// <param name="aoc">����AOC����</param>
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
                 * �ж�ִ��Update����Insert                
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
        /// ����һ����Ϣ����ǰʱ���û����Ҫͬ��������
        /// </summary>
        /// <param name="NameFunction">ִ��ͬ���ķ���</param>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <returns></returns>
        private static string GenerateMsgNoData(string NameFunction, DateTime dateTimeCheckPoint)
        {
            return string.Format("{0} No data of this checkPointTime:{1}", NameFunction, dateTimeCheckPoint.ToString());
        }

        #region TransferToAOCDataByCallCenterData
        /// <summary>
        /// ����CallCenterDataת��Ϊ����AOCData����
        /// </summary>
        /// <param name="ccData">����CallCenterData����</param>
        /// <returns></returns>
        private static AOCDataCC TransferToAOCDataByCallCenterData(CallCenterData ccData)
        {
            //ʵ������AOCData����
            AOCDataCC aocData = new AOCDataCC();

            //��AOCData�����ÿ�����Էֱ�ֵ
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

            //remark by march 20140425 �˴�����BUG��CallCenterData.Cache����ˢ�£����Կ��ܻ��Ҳ���MASTERFLIGHTDATAID��Ӧ����
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

            //��ȫCC���ֶ�
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
            //��ȫCC���ֶ�
            return aocData;
        }

        /// <summary>
        /// ��ȡĿ�Ļ��� CallCenter
        /// </summary>
        /// <param name="CallCenterFlightDirection">����۱�־λ</param>
        /// <param name="CallCenterPortOfCallIataCode">��ͣ�����б�</param>
        /// <returns></returns>
        private static string GetDES3ByCallCenterData(string CallCenterFlightDirection, string CallCenterPortOfCallIataCode)
        {
            if (string.IsNullOrEmpty(CallCenterFlightDirection) || string.IsNullOrEmpty(CallCenterPortOfCallIataCode))
            {
                return string.Empty;
            }

            //��Ӣ��ע�ͣ�����������
            //Chinese & English Explaination,AHHHHHHHHHHHHHHH
            //DES3:only in departure flight,the last airport of PORTOFCALLIATACODE 
            //Ŀ�Ļ���������������ۺ��࣬�Ǿ�ͣ�����б��е����һ������
            //PORTOFCALLIATACODE is splited by ','
            //��ͣ�����б����ŷָ�
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
        /// ��ȡ��ɻ��� CallCenter
        /// </summary>
        /// <param name="CallCenterFlightDirection">����۱�־λ</param>
        /// <param name="CallCenterPortOfCallIataCode">��ͣ�����б�</param>
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
        /// ��ȡʵ�ʳ���ʱ�� CallCenter
        /// </summary>
        /// <param name="CallCenterFlightDirection">����۱�־λ</param>
        /// <param name="CallCenterWheelsUpDownDateTime">���ֵ����ֵ�ʱ��</param>
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
        /// ��ȡʵ�ʵ���ʱ�� CallCenter
        /// </summary>
        /// <param name="CallCenterFlightDirection">����۱�־λ</param>
        /// <param name="CallCenterWheelsUpDownDateTime">���ֵ����ֵ�ʱ��</param>
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
        /// ��ȡ��ͣ���� CallCenter
        /// </summary>
        /// <param name="CallCenterFlightDirection">����۱�־λ</param>
        /// <param name="CallCenterPortOfCallIataCode">��ͣ�����б�</param>
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
        /// ��ȡԤ�Ƶ���ʱ�� CallCenter
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
        /// ��ȡԤ�Ƴ���ʱ��
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
