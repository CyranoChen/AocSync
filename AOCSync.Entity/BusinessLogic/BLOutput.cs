using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using AOCSync.Entity.Tools;

namespace AOCSync.Entity
{
    public class BLOutput
    {
        public static void FTPDAY(DateTime dateTime, out string msgSyncOut, AOCUserData aocUserData)
        {
            //msgSyncOut = string.Format("WorkFTPDAY time:{0}\r\n", dateTime.ToString());
            string orgFlieName = string.Empty;

            JudgeData(dateTime, out msgSyncOut);
            string desFileName = string.Empty;

            bool success = DAYlogic(dateTime, out msgSyncOut, aocUserData);

            if (success)
            {
                orgFlieName = string.Format("{0}\\{1}\\{2}.dat", "DAT", aocUserData.UserName, "wee_atc" + dateTime.ToString(TextTool.DATEFORMAT));
                desFileName = string.Format("{0}\\{1}\\wee_atc.dat", "DAT", aocUserData.UserName);

                if (File.Exists(desFileName))
                {
                    File.Delete(desFileName);
                }
                File.Copy(orgFlieName, desFileName);
                msgSyncOut += string.Format("WorkFTPDAY write {0} Success\r\n", orgFlieName);

                if (!File.Exists(desFileName))
                {
                    msgSyncOut += string.Format("WorkFTPDAY no file {0}\r\n", desFileName);
                    AOCLog.logErro(string.Format("WorkFTPDAY no file {0}", desFileName));
                }
                else
                {
                    //if (aocUserData.IsPack == "True")
                    //{
                    //    ZipHelper.ZipFile(desFileName, desFileName + ".zip");

                    //    FTPClientPort ftpclient = new FTPClientPort(aocUserData.FTPIP, aocUserData.FTPPort, desFileName + ".zip", aocUserData.FTPLogName, aocUserData.FTPPassword);

                    //    ftpclient.MakeDir(aocUserData.UserName.ToString());

                    //    if (ftpclient.Upload(out msgSyncOut, aocUserData))
                    //    {
                    //        msgSyncOut += string.Format("WorkFTPDAY UPLOAD {0} Success\r\n", desFileName + ".zip");
                    //        File.Delete(desFileName + ".zip");
                    //    }
                    //    else
                    //    {
                    //        msgSyncOut += string.Format("WorkFTPDAY UPLOAD {0} Fail\r\n", desFileName + ".zip");
                    //    }
                    //}
                    //else
                    //{
                    //    FTPClientPort ftpclient = new FTPClientPort(aocUserData.FTPIP, aocUserData.FTPPort, desFileName, aocUserData.FTPLogName, aocUserData.FTPPassword);

                    //    if (!string.IsNullOrEmpty(aocUserData.FTPRemoteDir))
                    //    {
                    //        ftpclient.MakeDir(aocUserData.FTPRemoteDir);
                    //    }
                    //    else
                    //    {
                    //        ftpclient.MakeDir(aocUserData.UserName);
                    //    }

                    //    if (ftpclient.Upload(out msgSyncOut, aocUserData))
                    //    {
                    //        msgSyncOut += string.Format("WorkFTPDAY UPLOAD {0} Success\r\n", desFileName);
                    //    }
                    //    else
                    //    {
                    //        msgSyncOut += string.Format("WorkFTPDAY UPLOAD {0} Fail\r\n", desFileName);
                    //    }
                    //}
                    string _fileType = string.Empty;
                    if (aocUserData.IsPack == "True")
                    {
                        _fileType = ".zip";
                        if (File.Exists(desFileName + _fileType))
                        {
                            File.Delete(desFileName + _fileType);
                        }
                        ZipHelper.ZipFile(desFileName, desFileName + _fileType);
                    }

                    success = FTPLogic(aocUserData, desFileName + _fileType, out msgSyncOut);

                    if (success)
                    {
                        msgSyncOut += string.Format("WorkFTPDAY UPLOAD {0} Success\r\n", desFileName + _fileType);
                        //File.Delete(desFileName + _fileType);
                    }
                    else
                    {
                        msgSyncOut += string.Format("WorkFTPDAY UPLOAD {0} Fail\r\n", desFileName + _fileType);
                    }
                }

                //if (File.Exists(desFileName))
                //{
                //    File.Delete(desFileName);
                //} //File.Delete(desFileName);
            }
        }

        public static void FTPITV(DateTime dateTime, out string msgSyncOut, AOCUserData aocUserData)
        {
            DateTime nowdateTime = dateTime;
            string orgFlieName = string.Empty;
            string desFileName = string.Empty;

            //msgSyncOut = string.Format("\nWorkFTPITV time:{0}\r\n", dateTime.ToString());
            JudgeData(dateTime, out msgSyncOut);
            aocUserData.loginfo.WriteLine("after function JudgeData");
            aocUserData.loginfo.WriteLine(msgSyncOut);
            bool success = ITVlogic(dateTime, out msgSyncOut, aocUserData, nowdateTime);
            aocUserData.loginfo.WriteLine(msgSyncOut);
            if (success)
            {
                orgFlieName = string.Format("{0}\\{1}\\{2}{3}.dat", "DAT", aocUserData.UserName, "ats_atc", dateTime.ToString(TextTool.DATEFORMAT));
                desFileName = string.Format("{0}\\{1}\\ats_atc.dat", "DAT", aocUserData.UserName);
                if (File.Exists(desFileName))
                {
                    File.Delete(desFileName);
                }
                File.Copy(orgFlieName, desFileName);

                msgSyncOut += string.Format("WorkFTPITV write {0} Success\r\n", orgFlieName);

                if (!File.Exists(desFileName))
                {
                    msgSyncOut += string.Format("WorkFTPITV no file {0}\r\n", desFileName);
                    AOCLog.logErro(string.Format("WorkFTPITV no file {0}", desFileName));
                }
                else
                {
                    string _fileType = string.Empty;
                    if (aocUserData.IsPack == "True")
                    {
                        _fileType = ".zip";
                        if (File.Exists(desFileName + _fileType))
                        {
                            File.Delete(desFileName + _fileType);
                        }
                        ZipHelper.ZipFile(desFileName, desFileName + _fileType);
                    }
                    aocUserData.loginfo.WriteLine(msgSyncOut);
                    success = FTPLogic(aocUserData, desFileName + _fileType, out msgSyncOut);

                    if (success)
                    {
                        msgSyncOut += string.Format("WorkFTPITV UPLOAD {0} Success\r\n", desFileName + _fileType);
                        //File.Delete(desFileName + _fileType);
                    }
                    else
                    {
                        msgSyncOut += string.Format("WorkFTPITV UPLOAD {0} Fail\r\n", desFileName + _fileType);
                    }
                    aocUserData.loginfo.WriteLine(msgSyncOut);
                }

                //if (File.Exists(desFileName))
                //{
                //    File.Delete(desFileName);
                //}
            }
        }

        public static bool FTPLogic(AOCUserData aocUserData, string filePath, out string msgSyncOut)
        {
            aocUserData.loginfo.WriteLine("in FTPLogic");
            msgSyncOut = string.Empty;
            bool ret = false;
            try
            {
                if (aocUserData.FTPMode.Equals("PASV", StringComparison.OrdinalIgnoreCase))
                {

                    string _ftpRemoteDir = string.Empty;
                    if (!string.IsNullOrEmpty(aocUserData.FTPRemoteDir))
                    {
                        _ftpRemoteDir = aocUserData.FTPRemoteDir;

                    }
                    else
                    {
                        //_ftpRemoteDir = aocUserData.UserName;
                        _ftpRemoteDir = "/";
                    }
                    FTPClientPasv ftpclient = new FTPClientPasv(aocUserData.FTPIP, aocUserData.FTPPort, filePath, aocUserData.FTPLogName, aocUserData.FTPPassword, _ftpRemoteDir);
                    ftpclient.SetTransferType(FTPClientPasv.TransferType.Binary);
                    msgSyncOut = ftpclient.MsgSyncOut;
                    ret = ftpclient.Put(filePath);
                }
                else
                {
                    FTPClientPort ftpclient = new FTPClientPort(aocUserData.FTPIP, aocUserData.FTPPort, filePath, aocUserData.FTPLogName, aocUserData.FTPPassword);

                    //if (!string.IsNullOrEmpty(aocUserData.FTPRemoteDir))
                    //{
                    //    ftpclient.MakeDir(aocUserData.FTPRemoteDir);
                    //}
                    //else
                    //{
                    //    ftpclient.MakeDir(aocUserData.UserName);
                    //}

                    ret = ftpclient.Upload(aocUserData);

                }
                aocUserData.loginfo.WriteLine("leave FTPLogic");
                aocUserData.loginfo.Write(msgSyncOut);
                
            }
            catch (Exception e)
            {
                aocUserData.loginfo.WriteLine("FTPLogic Wrong" + e);
              
            }
            return ret;
          
        }


        public static void DATDAY(DateTime dateTime, out string msgSyncOut)
        {
            DateTime t1 = DateTime.Now;
            msgSyncOut = string.Empty;
            string MsgSyncOut = string.Empty;
            JudgeData(dateTime, out msgSyncOut);
            //DateTime dateTimeStart = dateTime.Date;
            //DateTime dateTimeEnd = dateTime.Date.AddHours(AOCConfig.INTERVALEVENTDAILYAFTER).AddSeconds(-1);//后X天全天数据

            //string dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
            //string dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");

            //List<AOCDataCC> aocDataCCList = AOCDataCC.Cache.AOCDataList.FindAll(delegate(AOCDataCC aocdataInList)
            //{ return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0; });

            //dtStart = dateTimeStart.ToString();
            //dtEnd = dateTimeEnd.ToString();

            //List<AOCDataFQS> aocDataFQSList = AOCDataFQS.Cache.AOCDataList.FindAll(delegate(AOCDataFQS aocdataInList)
            //{
            //    if (!string.IsNullOrEmpty(aocdataInList.STOD))
            //    {
            //        return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0;
            //    }
            //    else
            //    {
            //        return aocdataInList.SDT.CompareTo(dtStart) >= 0 && aocdataInList.SDT.CompareTo(dtEnd) <= 0;
            //    }
            //});

            foreach (AOCUserData aocUserData in AOCUserData.Cache.AOCUserList)
            {
                if (AOCUserData.Cache.AOCUserList.Count > 0)
                {
                    DAYlogic(dateTime, out MsgSyncOut, aocUserData);
                    msgSyncOut += MsgSyncOut;
                    //    List<AOCCONBINE> aocconbineList = AOCCONBINE.GetAOCCONBINEDatas(aocDataCCList, aocDataFQSList);

                    //    bool success = DataFileTool.MakeDataFile(aocconbineList, aocUserData, dateTime, "wee");

                    //    if (success)
                    //    {
                    //        msgSyncOut += string.Format("{0} fail \r\n", aocUserData.UserName);
                    //    }
                    //    else
                    //    {
                    //        msgSyncOut += string.Format("{0} success \r\n", aocUserData.UserName);
                    //    }
                }
                else
                {
                    msgSyncOut += "no user";
                }
            }
        }

        public static void DATITV(DateTime dateTime, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
            DateTime nowdateTime = dateTime;
            string MsgSyncOut = string.Empty;
            JudgeData(dateTime, out msgSyncOut);
            //DateTime dateTimeStart = dateTime.AddHours(AOCConfig.INTERVALEVENTBEFORE);
            //DateTime dateTimeEnd = dateTime.AddHours(AOCConfig.INTERVALEVENTAFTER);

            //string dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
            //string dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");

            //List<AOCDataCC> aocDataCCList = AOCDataCC.Cache.AOCDataList.FindAll(delegate(AOCDataCC aocdataInList)
            //{
            //    return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0;
            //}
            //    );
            //dtStart = dateTimeStart.ToString();
            //dtEnd = dateTimeEnd.ToString();
            //List<AOCDataFQS> aocDataFQSList = AOCDataFQS.Cache.AOCDataList.FindAll(delegate(AOCDataFQS aocdataInList)
            //{
            //    if (!string.IsNullOrEmpty(aocdataInList.STOD))
            //    {
            //        return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0;
            //    }
            //    else
            //    {
            //        return aocdataInList.SDT.CompareTo(dtStart) >= 0 && aocdataInList.SDT.CompareTo(dtEnd) <= 0;
            //    }
            //}
            //    );
            foreach (AOCUserData aocUserData in AOCUserData.Cache.AOCUserList)
            {
                if (AOCUserData.Cache.AOCUserList.Count > 0)
                {
                    //List<AOCCONBINE> aocconbineList = AOCCONBINE.GetAOCCONBINEDatas(aocDataCCList, aocDataFQSList);

                    //bool success = DataFileTool.MakeDataFile(aocconbineList, aocUserData, dateTime, "ats");
                    ITVlogic(dateTime, out MsgSyncOut, aocUserData, nowdateTime);
                    msgSyncOut += MsgSyncOut;
                }
                else
                {
                    msgSyncOut += "no user";
                }
            }

        }

        private static bool DAYlogic(DateTime dateTime, out string msgSyncOut, AOCUserData aocUserData)
        {
            msgSyncOut = string.Empty;
            List<AOCDataCC> aocDataCCList = new List<AOCDataCC>();
            List<AOCDataFQS> aocDataFQSList = new List<AOCDataFQS>();

            //初始化每日同步的同步时间范围
            DateTime dateTimeStart = dateTime.Date;
            DateTime dateTimeEnd = dateTime.Date.AddHours(AOCConfig.INTERVALEVENTDAILYAFTER).AddDays(1).AddSeconds(-1);//后X天全天数据
            string dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
            string dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");

            aocDataCCList = AOCDataCC.Cache.AOCDataList.FindAll(delegate(AOCDataCC aocdataInList)
            {
                return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) < 0;
            });

            //dtStart = dateTimeStart.ToString();
            //dtEnd = dateTimeEnd.ToString();

            aocDataFQSList = AOCDataFQS.Cache.AOCDataList.FindAll(delegate(AOCDataFQS aocdataInList)
            {
                if (!string.IsNullOrEmpty(aocdataInList.STOD))
                {
                    return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) < 0;
                }
                else
                {
                    return aocdataInList.SDT.CompareTo(dtStart) >= 0 && aocdataInList.SDT.CompareTo(dtEnd) < 0;
                }
            });

            List<AOCCONBINE> aocCOMDATAList = AOCCONBINE.GetAOCCONBINEDatas(aocDataCCList, aocDataFQSList, aocUserData);

            if (aocCOMDATAList.Count <= 0)
            {
                msgSyncOut += string.Format("no data  Fail\r\n");
                return false;
            }

            bool success = DataFileTool.MakeDataFile(aocCOMDATAList, aocUserData, dateTime, "wee");
            if (success)
            {
                msgSyncOut += string.Format("{0} success \r\n", aocUserData.UserName);
            }
            else
            {
                msgSyncOut += string.Format("{0} fail \r\n", aocUserData.UserName);
            }
            return success;

        }

        private static void JudgeData(DateTime dateTime, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;

            if (AOCUserData.Cache.AOCUserList.Count == 0)
            {
                msgSyncOut += "WorkFTPDAY no user";
                AOCLog.logErro("WorkFTPDAY no user");
                return;
            }
            if (AOCDataCC.Cache.AOCDataList.Count == 0 && AOCDataFQS.Cache.AOCDataList.Count == 0)
            {
                msgSyncOut += "WorkFTPDAY no data";
                AOCLog.logErro("WorkFTPDAY no data");
                return;
            }

        }

        private static bool ITVlogic(DateTime dateTime, out string msgSyncOut, AOCUserData aocUserData, DateTime nowdateTime)
        {
            msgSyncOut = string.Empty;
            List<AOCDataCC> aocDataCCList = new List<AOCDataCC>();
            List<AOCDataFQS> aocDataFQSList = new List<AOCDataFQS>();

            if (AOCUserData.Cache.AOCUserList.Count == 0)
            {
                msgSyncOut += "WorkFTPITV no user";
                AOCLog.logErro("WorkFTPITV no user");
                aocUserData.loginfo.WriteLine("in ITVlogic error WorkFTPITV no user");
                return false;
            }
            if (AOCDataCC.Cache.AOCDataList.Count == 0 && AOCDataFQS.Cache.AOCDataList.Count == 0)
            {
                msgSyncOut += "WorkFTPITV no data";
                AOCLog.logErro("WorkFTPITV no data");
                aocUserData.loginfo.WriteLine("in ITVlogic error WorkFTPITV no data");
                return false;
            }

            dateTime = nowdateTime;
            DateTime dateTimeStart = dateTime.AddHours(AOCConfig.INTERVALEVENTBEFORE);
            DateTime dateTimeEnd = dateTime.AddHours(AOCConfig.INTERVALEVENTAFTER);

            string dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
            string dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");

            aocDataCCList = AOCDataCC.Cache.AOCDataList.FindAll(delegate(AOCDataCC aocdataInList)
            {
                return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) < 0;
            }
            );

            //dtStart = dateTimeStart.ToString();
            //dtEnd = dateTimeEnd.ToString();
            aocDataFQSList = AOCDataFQS.Cache.AOCDataList.FindAll(delegate(AOCDataFQS aocdataInList)
            {
                //if (!string.IsNullOrEmpty(aocdataInList.STOD))
                //{
                return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) < 0;
                //}
                //else
                //{
                //    return aocdataInList.SDT.CompareTo(dtStart) >= 0 && aocdataInList.SDT.CompareTo(dtEnd) < 0;
                //}
            }
            );

            List<AOCCONBINE> aocCOMDATAList = AOCCONBINE.GetAOCCONBINEDatas(aocDataCCList, aocDataFQSList, aocUserData);

            if (aocCOMDATAList.Count <= 0)
            {
                msgSyncOut += string.Format("{0} fail no data\r\n", aocUserData.UserName);
                aocUserData.loginfo.WriteLine("after conbine fail no data");
                return false;
            }
            bool success = DataFileTool.MakeDataFile(aocCOMDATAList, aocUserData, dateTime, "ats");
            if (success)
            {
                msgSyncOut += string.Format("{0} success \r\n", aocUserData.UserName);
            }
            else
            {
                msgSyncOut += string.Format("{0} fail \r\n", aocUserData.UserName);
            }
            return success;
        }

    }
}

