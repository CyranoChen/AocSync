using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using AOCSync.Entity.AOCEnum;
using AOCSync.Entity.Tools;

namespace AOCSync.Entity
{
    public class CallCenterData
    {
        public CallCenterData() { }

        public CallCenterData(DataRow dr)
        {
            initCallCenter(dr);
        }

        private void initCallCenter(DataRow dr)
        {
            if (dr == null)
            {
                throw new Exception("Unable to init CallCenterData.");
            }
            FLIGHTDATAID                      = dr["FLIGHTDATAID"].ToString(); 
            OCCURDATETIME                     = dr["OCCURDATETIME"].ToString();
            FLIGHTIDENTITY                    = dr["FLIGHTIDENTITY"].ToString();
            SCHEDULEDDATE                     = dr["SCHEDULEDDATE"].ToString();
            CARRIERIATACODE                   = dr["CARRIERIATACODE"].ToString();
            FLIGHTNUMBER                      = dr["FLIGHTNUMBER"].ToString();
            FLIGHTSUFFIX                      = dr["FLIGHTSUFFIX"].ToString();
            FLIGHTDIRECTION                   = dr["FLIGHTDIRECTION"].ToString();
            FLIGHTREPEATCOUNT                 = dr["FLIGHTREPEATCOUNT"].ToString();
            CARRIERICAOCODE                   = dr["CARRIERICAOCODE"].ToString();
            AIRPORTIATACODE                   = dr["AIRPORTIATACODE"].ToString();
            CODESHARESTATUS                   = dr["CODESHARESTATUS"].ToString();
            FLIGHTCANCELCODE                  = dr["FLIGHTCANCELCODE"].ToString();
            DIVERTAIRPORTIATACODE             = dr["DIVERTAIRPORTIATACODE"].ToString();
            FLIGHTNATURECODE                  = dr["FLIGHTNATURECODE"].ToString();
            FLIGHTSERVICETYPEIATACODE         = dr["FLIGHTSERVICETYPEIATACODE"].ToString();
            FLIGHTSTATUSCODE                  = dr["FLIGHTSTATUSCODE"].ToString();
            FLIGHTSECTORCODE                  = dr["FLIGHTSECTORCODE"].ToString();
            ISRETURNFLIGHT                    = dr["ISRETURNFLIGHT"].ToString();
            ISGENERALAVIATIONFLIGHT           = dr["ISGENERALAVIATIONFLIGHT"].ToString();
            FLIGHTTRANSITCODE                 = dr["FLIGHTTRANSITCODE"].ToString();
            NEWFLIGHTREASON                   = dr["NEWFLIGHTREASON"].ToString();
            OPERATIONTYPECODE                 = dr["OPERATIONTYPECODE"].ToString();
            TRANSFERFLIGHTIDENTITY            = dr["TRANSFERFLIGHTIDENTITY"].ToString();
            ESTIMATEDDATETIME                 = dr["ESTIMATEDDATETIME"].ToString();
            SCHEDULEDDATETIME                 = dr["SCHEDULEDDATETIME"].ToString();
            WHEELSUPDOWNDATETIME              = dr["WHEELSUPDOWNDATETIME"].ToString();
            PORTOFCALLIATACODE                = dr["PORTOFCALLIATACODE"].ToString();
            FLIGHTFLAG                        = dr["FLIGHTFLAG"].ToString();
            MASTERFLIGHTDATAID                = dr["MASTERFLIGHTDATAID"].ToString();
            OCCURDATETIME                     = dr["OCCURDATETIME"].ToString();
            AIRPORTIATACODE                   = dr["AIRPORTIATACODE"].ToString();
            SCHEDULEDDATE                     = dr["SCHEDULEDDATE"].ToString();
            AIRCRAFTTERMINALCODE              = dr["AIRCRAFTTERMINALCODE"].ToString();
            PASSENGERTERMINALCODE             = dr["PASSENGERTERMINALCODE"].ToString();
            STANDPOSITION                     = dr["STANDPOSITION"].ToString();
            BAGGAGERECLAIMCAROUSELID          = dr["BAGGAGERECLAIMCAROUSELID"].ToString();
            BAGGAGERECLAIMCAROUSELROLE        = dr["BAGGAGERECLAIMCAROUSELROLE"].ToString();
            BAGGAGERECLAIMOPENDATETIME        = dr["BAGGAGERECLAIMOPENDATETIME"].ToString();
            BAGGAGERECLAIMCLOSEDDATETIME      = dr["BAGGAGERECLAIMCLOSEDDATETIME"].ToString();
            SDBAGRECLAIMCAROUSELID            = dr["SDBAGRECLAIMCAROUSELID"].ToString();
            SDBAGRECLAIMCAROUSELROLE          = dr["SDBAGRECLAIMCAROUSELROLE"].ToString();
            SDBAGRECLAIMOPENDATETIME          = dr["SDBAGRECLAIMOPENDATETIME"].ToString();
            SDBAGRECLAIMCLOSEDDATETIME        = dr["SDBAGRECLAIMCLOSEDDATETIME"].ToString();
            SDFIRSTBAGDATETIME                = dr["SDFIRSTBAGDATETIME"].ToString();
            SDLASTBAGDATETIME                 = dr["SDLASTBAGDATETIME"].ToString();
            CHECKINDESKRANGE                  = dr["CHECKINDESKRANGE"].ToString();
            CHECKINOPENDATETIME               = dr["CHECKINOPENDATETIME"].ToString();
            CHECKINCLOSEDDATETIME             = dr["CHECKINCLOSEDDATETIME"].ToString();
            SDCHECKINDESKRANGE                = dr["SDCHECKINDESKRANGE"].ToString();
            SDCHECKINOPENDATETIME             = dr["SDCHECKINOPENDATETIME"].ToString();
            SDCHECKINCLOSEDDATETIME           = dr["SDCHECKINCLOSEDDATETIME"].ToString();
            GATENUMBER                        = dr["GATENUMBER"].ToString();
            GATEBOARDINGSTATUS                = dr["GATEBOARDINGSTATUS"].ToString();
            GATEOPENDATETIME                  = dr["GATEOPENDATETIME"].ToString();
            GATECLOSEDDATETIME                = dr["GATECLOSEDDATETIME"].ToString();
            SDGATENUMBER                      = dr["SDGATENUMBER"].ToString();
            SDGATEOPENDATETIME                = dr["SDGATEOPENDATETIME"].ToString();
            SDGATECLOSEDDATETIME              = dr["SDGATECLOSEDDATETIME"].ToString();
            SUPPLEMENTARYINFORMATION          = dr["SUPPLEMENTARYINFORMATION"].ToString();
            SUPPLEMENTARYINFORMATIONTEXT      = dr["SUPPLEMENTARYINFORMATIONTEXT"].ToString();
            ACTUALOFFBLOCKSDATETIME           = dr["ACTUALOFFBLOCKSDATETIME"].ToString();
            ACTUALONBLOCKSDATETIME            = dr["ACTUALONBLOCKSDATETIME"].ToString();
            ESTIMATEDFLIGHTDURATION           = dr["ESTIMATEDFLIGHTDURATION"].ToString();
            NEXTSTATIONACTUALDATETIME         = dr["NEXTSTATIONACTUALDATETIME"].ToString();
            NEXTSTATIONESTIMATEDDATETIME      = dr["NEXTSTATIONESTIMATEDDATETIME"].ToString();
            NEXTSTATIONSCHEDULEDDATETIME      = dr["NEXTSTATIONSCHEDULEDDATETIME"].ToString();
            PREVIOUSAIRBORNEDATETIME          = dr["PREVIOUSAIRBORNEDATETIME"].ToString();
            PREVIOUSESTIMATEDDATETIME         = dr["PREVIOUSESTIMATEDDATETIME"].ToString();
            PREVIOUSSCHEDULEDDATETIME         = dr["PREVIOUSSCHEDULEDDATETIME"].ToString();
            FIRSTBAGDATETIME                  = dr["FIRSTBAGDATETIME"].ToString();
            LASTBAGDATETIME                   = dr["LASTBAGDATETIME"].ToString();
            LATESTKNOWNDATETIME               = dr["LATESTKNOWNDATETIME"].ToString();
            LATESTKNOWNDATETIMESOURCE         = dr["LATESTKNOWNDATETIMESOURCE"].ToString();
            AIRCRAFTSUBTYPEIATACODE           = dr["AIRCRAFTSUBTYPEIATACODE"].ToString();
            SCHEDULEDDATETIME = dr["SCHEDULEDDATETIME"].ToString();
            FLIGHTNATURECODE = dr["FLIGHTNATURECODE"].ToString();
            FLIGHTDATAID = dr["FLIGHTDATAID"].ToString();
            AIRPORTIATACODE = dr["AIRPORTIATACODE"].ToString();
            WHEELSUPDOWNDATETIME = dr["WHEELSUPDOWNDATETIME"].ToString();
            AIRCRAFTSUBTYPEIATACODE = dr["AIRCRAFTSUBTYPEIATACODE"].ToString();
            PORTOFCALLIATACODE = dr["PORTOFCALLIATACODE"].ToString();
            CHECKINDESKRANGE = dr["CHECKINDESKRANGE"].ToString();
            FLIGHTSECTORCODE = dr["FLIGHTSECTORCODE"].ToString();
            PASSENGERTERMINALCODE = dr["PASSENGERTERMINALCODE"].ToString();
            STANDPOSITION = dr["STANDPOSITION"].ToString();
            GATENUMBER = dr["GATENUMBER"].ToString();
            DIVERTAIRPORTIATACODE = dr["DIVERTAIRPORTIATACODE"].ToString();
            CODESHARESTATUS = dr["CODESHARESTATUS"].ToString();
            ESTIMATEDDATETIME = dr["ESTIMATEDDATETIME"].ToString();
            CHECKINOPENDATETIME = dr["CHECKINOPENDATETIME"].ToString();
            CHECKINCLOSEDDATETIME = dr["CHECKINCLOSEDDATETIME"].ToString();
            SDCHECKINDESKRANGE = dr["SDCHECKINDESKRANGE"].ToString();
            SDCHECKINOPENDATETIME = dr["SDCHECKINOPENDATETIME"].ToString();
            SDCHECKINCLOSEDDATETIME = dr["SDCHECKINCLOSEDDATETIME"].ToString();
            BAGGAGERECLAIMCAROUSELID = dr["BAGGAGERECLAIMCAROUSELID"].ToString();
            BAGGAGERECLAIMOPENDATETIME = dr["BAGGAGERECLAIMOPENDATETIME"].ToString();
            BAGGAGERECLAIMCLOSEDDATETIME = dr["BAGGAGERECLAIMCLOSEDDATETIME"].ToString();
            SDBAGRECLAIMCAROUSELID = dr["SDBAGRECLAIMCAROUSELID"].ToString();
            SDBAGRECLAIMOPENDATETIME = dr["SDBAGRECLAIMOPENDATETIME"].ToString();
            SDBAGRECLAIMCLOSEDDATETIME = dr["SDBAGRECLAIMCLOSEDDATETIME"].ToString();
            GATEBOARDINGSTATUS = dr["GATEBOARDINGSTATUS"].ToString();
            GATEOPENDATETIME = dr["GATEOPENDATETIME"].ToString();
            GATECLOSEDDATETIME = dr["GATECLOSEDDATETIME"].ToString();
            SDGATENUMBER = dr["SDGATENUMBER"].ToString();
            SDGATEOPENDATETIME = dr["SDGATEOPENDATETIME"].ToString();
            SDGATECLOSEDDATETIME = dr["SDGATECLOSEDDATETIME"].ToString();
            FLIGHTDIRECTION = dr["FLIGHTDIRECTION"].ToString();
            OPERATIONTYPECODE = dr["OPERATIONTYPECODE"].ToString();
            MASTERFLIGHTDATAID = dr["MASTERFLIGHTDATAID"].ToString();
        }

        public void Select()
        {
            DataRow dr = DataAccess.CallCenterData.GetCallCenterDataByID(FLIGHTDATAID);

            if (dr != null)
            {
                initCallCenter(dr);
            }
        }

        public static List<CallCenterData> GetCallCenterData()
        {
            DataTable dt = DataAccess.CallCenterData.GetCallCenterDatas();
            List<CallCenterData> list = new List<CallCenterData>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CallCenterData(dr));
                }
            }

            return list;
        }

        public static List<CallCenterData> GetCallCenterData(DateTime dateTimeStart, DateTime dateTimeAfter)
        {
            DataTable dt = DataAccess.CallCenterData.GetCallCenterDatasByDateDiff(dateTimeStart, dateTimeAfter);
            List<CallCenterData> list = new List<CallCenterData>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CallCenterData(dr));
                }
            }

            return list;
        }

        /// <summary>
        /// CallCenterDataCache
        /// </summary>
        public static class Cache
        {
            static Cache()
            {
                InitCache();
            }

            public static void RefreshCache()
            {
                InitCache();
            }

            private static void InitCache()
            {
                CallCenterDataListTemp = GetCallCenterData();
                CallCenterDataList = CallCenterDataListTemp;
            }

            private static void InitCache(DateTime dateTimeBefore, DateTime dateTimeAfter)
            {
                CallCenterDataListTemp = GetCallCenterData(dateTimeBefore, dateTimeAfter);
                CallCenterDataList = CallCenterDataListTemp;
            }

            public static CallCenterData Load(string ccid)
            {
                return CallCenterDataList.Find(delegate(CallCenterData cc) { return cc.FLIGHTDATAID.Equals(ccid, StringComparison.OrdinalIgnoreCase); });
            }

            public static List<CallCenterData> CallCenterDataList;
            private static List<CallCenterData> CallCenterDataListTemp;

            public static List<CallCenterData> GetCallCenterDataListSHA()
            {
                return CallCenterDataList.FindAll(delegate(CallCenterData callCenterData) { return callCenterData.AIRPORTIATACODE.Equals(EnumAOCSync.SHA.ToString()); });
            }

            public static List<CallCenterData> GetCallCenterDataListPVG()
            {
                return CallCenterDataList.FindAll(delegate(CallCenterData callCenterData) { return callCenterData.AIRPORTIATACODE.Equals(EnumAOCSync.PVG.ToString()); });
            }

        }

        #region CallCenter COLUMNS
        private string flightdataid                     ;//--航班信息序号(自动生成)
        private string occurdatetime                    ;//--发生时间(系统服务器时间)
        private string flightidentity                   ;//--航班标示
        private string scheduleddate                    ;//--计划日期
        private string carrieriatacode                  ;//--航空公司IATA代码, 航空公司二字码
        private string flightnumber                     ;//--航班号
        private string flightsuffix                     ;//--航班后缀
        private string flightdirection                  ;//--航班方向--'D' Departure--'A' Arrival
        private string flightrepeatcount                ;//--航班重复数量
        private string carriericaocode                  ;//--航空公司ICAO代码
        private string airportiatacode                  ;//--机场代码
        private string codesharestatus                  ;//--代码共享状态--SF 共享航班--'00'到'99'
        private string flightcancelcode                 ;//--航班取消代码--'C' Cancelled 航班取消--'D' Diverted 航班改降 --'N' Non-operational 不运营
        private string divertairportiatacode            ;//--中转机场代码
        private string flightnaturecode                 ;//--航班性质代码
        private string flightservicetypeiatacode        ;//--航班服务类型代码
        private string flightstatuscode                 ;//--航班状态代码--AB-Airborne--BD-Boarding--CX-Cancelled--DV-Diverted--ES-Estimated--EX-Expected--FB-First Bag--FS-Final Approach--FX-Flight Fixed--GA-Gate Attended--GC-Gate Close--GO-Gate Open--LB-Last Bag--LC-Last Call--LD-Landed--NI-Next Information--OB-On/Off Blocks--OT-On Time--OV-Overshoot--RS-Return To Stand--SH-Scheduled--ZN-Zoning
        private string flightsectorcode                 ;//--航段代码--'D'国内航班--'I'国际航班--'R'区域航班--'M'混合航班
        private string isreturnflight                   ;//--是否是返回航班--'0'非返回航班--'1'返回航班
        private string isgeneralaviationflight          ;//--是否是正常航班
        private string flighttransitcode                ;//--航班中转代码--'Y'-Normal--'T'-Technical
        private string newflightreason                  ;//--新加航班原因--'RET'--表示返航航班--'DIV'--表示备降航班, 从不同的机场备降到本机场的航班
        private string operationtypecode                ;//--航班运营类型代码--'DEL'--表示航班延误, 但有准确的预计时间, 并且预计时间与计划时间相差足够大--'DFI'--表示航班延误, 并且新的预计时间未知时--'CAN'--表示航班取消--'ADV'--表示航班提前, 更新则EstimatedDateTime字段标记时间--'MER'--表示该航班是合并航班--'CSF'--表示该航班是共享航班--'RET'--表示是返航航班--'SLI'--表示滑回航班--'MVT'--表示地面移动航班, 航班从一个机位牵引到另一个机位--'ALT'--表示备降航班, 改降到其他机场, 如航班正常是降落到浦东, 由于天气等原因, 降落到杭州机场--'CHG'--表示改降航班, 改降到本地机场, 如从浦东改降到虹桥机场--'ADF'--表示是当天的即时航班--'POS'--表示是调剂航班，如虹桥机场的航班调剂到浦东机场--'NOP'--表示是非运营航班--'REG'--航班正常
        private string transferflightidentity           ;//--中转航班标示
        private string estimateddatetime                ;//--预计时间
        private string scheduleddatetime                ;//--计划时间
        private string wheelsupdowndatetime             ;//--出发/到达时间
        private string portofcalliatacode               ;//--经停机场
        private string flightflag                       ;//--航班标志--'0'正常航班--'1'主共享航班--'2'从共享航班--'3'主合并航班--'4'从合并航班
        private string masterflightdataid               ;//--主航班序号
        private string aircraftterminalcode             ;//--办票航站楼
        private string passengerterminalcode            ;//--登机航站楼
        private string standposition                    ;//--机位代码
        private string baggagereclaimcarouselid         ;//--行李提取转盘代码
        private string baggagereclaimcarouselrole       ;//--行李提取转盘作用
        private string baggagereclaimopendatetime       ;//--行李提取转盘开始时间
        private string baggagereclaimcloseddatetime     ;//--行李提取转盘结束时间
        private string sdbagreclaimcarouselid           ;//--从行李提取转盘代码
        private string sdbagreclaimcarouselrole         ;//--从行李提取转盘作用
        private string sdbagreclaimopendatetime         ;//--从行李提取转盘开始时间
        private string sdbagreclaimcloseddatetime       ;//--从行李提取转盘结束时间
        private string sdfirstbagdatetime               ;//--从提取行李的开始时间
        private string sdlastbagdatetime                ;//--从提取行李的结束时间
        private string checkindeskrange                 ;//--所有办票柜台, 如'16, 18, 20'
        private string checkinopendatetime              ;//--办票开始时间
        private string checkincloseddatetime            ;//--办票结束时间
        private string sdcheckindeskrange               ;//--从所有办票柜台, 如'16, 18, 20'
        private string sdcheckinopendatetime            ;//--从办票开始时间
        private string sdcheckincloseddatetime          ;//--从办票结束时间
        private string gatenumber                       ;//--登机门标示
        private string gateboardingstatus               ;//--登机门状态--'0'--Open--'1'--Attended--'2'--Boarding--'3'--Last Call--'9'--Closed
        private string gateopendatetime                 ;//--登机门开始时间
        private string gatecloseddatetime               ;//--登机门结束时间
        private string sdgatenumber                     ;//--从登机门标示
        private string sdgateopendatetime               ;//--从登机门开始时间
        private string sdgatecloseddatetime             ;//--从登机门结束时间
        private string supplementaryinformation         ;//--附助信息
        private string supplementaryinformationtext     ;//--附助信息文本
        private string actualoffblocksdatetime          ;//--起飞下轮挡
        private string actualonblocksdatetime           ;//--到达上轮档
        private string estimatedflightduration          ;//--预计航班飞行区域
        private string nextstationactualdatetime        ;//--飞机到达下一个机场的准确时间
        private string nextstationestimateddatetime     ;//--飞机到达下一个机场的预计时间
        private string nextstationscheduleddatetime     ;//--飞机到达下一个机场的计划时间
        private string previousairbornedatetime         ;//--上一站的准确出发时间
        private string previousestimateddatetime        ;//--上一站的预计出发时间
        private string previousscheduleddatetime        ;//--上一站的计划出发时间
        private string firstbagdatetime                 ;//--提取行李的开始时间
        private string lastbagdatetime                  ;//--提取行李的结束时间
        private string latestknowndatetime              ;//--最近的出发或到达日期和时间
        private string latestknowndatetimesource        ;//--最近的出发或降落日期和时间的信息来源--计划时间 scheduled time--预计时间 estimate time--实际时间 actual time
        private string aircraftsubtypeiatacode          ;//--机型  

        public string FLIGHTDATAID                     {            set { flightdataid                     = value; }            get { return flightdataid                     ; }        }
        public string OCCURDATETIME                    {            set { occurdatetime                    = value; }            get { return occurdatetime                    ; }        }
        public string FLIGHTIDENTITY                   {            set { flightidentity                   = value; }            get { return flightidentity                   ; }        }
        public string SCHEDULEDDATE                    {            set { scheduleddate                    = value; }            get { return scheduleddate                    ; }        }
        public string CARRIERIATACODE                  {            set { carrieriatacode                  = value; }            get { return carrieriatacode                  ; }        }
        public string FLIGHTNUMBER                     {            set { flightnumber                     = value; }            get { return flightnumber                     ; }        }
        public string FLIGHTSUFFIX                     {            set { flightsuffix                     = value; }            get { return flightsuffix                     ; }        }
        public string FLIGHTDIRECTION                  {            set { flightdirection                  = value; }            get { return flightdirection                  ; }        }
        public string FLIGHTREPEATCOUNT                {            set { flightrepeatcount                = value; }            get { return flightrepeatcount                ; }        }
        public string CARRIERICAOCODE                  {            set { carriericaocode                  = value; }            get { return carriericaocode                  ; }        }
        public string AIRPORTIATACODE                  {            set { airportiatacode                  = value; }            get { return airportiatacode                  ; }        }
        public string CODESHARESTATUS                  {            set { codesharestatus                  = value; }            get { return codesharestatus                  ; }        }
        public string FLIGHTCANCELCODE                 {            set { flightcancelcode                 = value; }            get { return flightcancelcode                 ; }        }
        public string DIVERTAIRPORTIATACODE            {            set { divertairportiatacode            = value; }            get { return divertairportiatacode            ; }        }
        public string FLIGHTNATURECODE                 {            set { flightnaturecode                 = value; }            get { return flightnaturecode                 ; }        }
        public string FLIGHTSERVICETYPEIATACODE        {            set { flightservicetypeiatacode        = value; }            get { return flightservicetypeiatacode        ; }        }
        public string FLIGHTSTATUSCODE                 {            set { flightstatuscode                 = value; }            get { return flightstatuscode                 ; }        }
        public string FLIGHTSECTORCODE                 {            set { flightsectorcode                 = value; }            get { return flightsectorcode                 ; }        }
        public string ISRETURNFLIGHT                   {            set { isreturnflight                   = value; }            get { return isreturnflight                   ; }        }
        public string ISGENERALAVIATIONFLIGHT          {            set { isgeneralaviationflight          = value; }            get { return isgeneralaviationflight          ; }        }
        public string FLIGHTTRANSITCODE                {            set { flighttransitcode                = value; }            get { return flighttransitcode                ; }        }
        public string NEWFLIGHTREASON                  {            set { newflightreason                  = value; }            get { return newflightreason                  ; }        }
        public string OPERATIONTYPECODE                {            set { operationtypecode                = value; }            get { return operationtypecode                ; }        }
        public string TRANSFERFLIGHTIDENTITY           {            set { transferflightidentity           = value; }            get { return transferflightidentity           ; }        }
        public string ESTIMATEDDATETIME                {            set { estimateddatetime                = value; }            get { return estimateddatetime                ; }        }
        public string SCHEDULEDDATETIME                {            set { scheduleddatetime                = value; }            get { return scheduleddatetime                ; }        }
        public string WHEELSUPDOWNDATETIME             {            set { wheelsupdowndatetime             = value; }            get { return wheelsupdowndatetime             ; }        }
        public string PORTOFCALLIATACODE               {            set { portofcalliatacode               = value; }            get { return portofcalliatacode               ; }        }
        public string FLIGHTFLAG                       {            set { flightflag                       = value; }            get { return flightflag                       ; }        }
        public string MASTERFLIGHTDATAID               {            set { masterflightdataid               = value; }            get { return masterflightdataid               ; }        }
        public string AIRCRAFTTERMINALCODE             {            set { aircraftterminalcode             = value; }            get { return aircraftterminalcode             ; }        }
        public string PASSENGERTERMINALCODE            {            set { passengerterminalcode            = value; }            get { return passengerterminalcode            ; }        }
        public string STANDPOSITION                    {            set { standposition                    = value; }            get { return standposition                    ; }        }
        public string BAGGAGERECLAIMCAROUSELID         {            set { baggagereclaimcarouselid         = value; }            get { return baggagereclaimcarouselid         ; }        }
        public string BAGGAGERECLAIMCAROUSELROLE       {            set { baggagereclaimcarouselrole       = value; }            get { return baggagereclaimcarouselrole       ; }        }
        public string BAGGAGERECLAIMOPENDATETIME       {            set { baggagereclaimopendatetime       = value; }            get { return baggagereclaimopendatetime       ; }        }
        public string BAGGAGERECLAIMCLOSEDDATETIME     {            set { baggagereclaimcloseddatetime     = value; }            get { return baggagereclaimcloseddatetime     ; }        }
        public string SDBAGRECLAIMCAROUSELID           {            set { sdbagreclaimcarouselid           = value; }            get { return sdbagreclaimcarouselid           ; }        }
        public string SDBAGRECLAIMCAROUSELROLE         {            set { sdbagreclaimcarouselrole         = value; }            get { return sdbagreclaimcarouselrole         ; }        }
        public string SDBAGRECLAIMOPENDATETIME         {            set { sdbagreclaimopendatetime         = value; }            get { return sdbagreclaimopendatetime         ; }        }
        public string SDBAGRECLAIMCLOSEDDATETIME       {            set { sdbagreclaimcloseddatetime       = value; }            get { return sdbagreclaimcloseddatetime       ; }        }
        public string SDFIRSTBAGDATETIME               {            set { sdfirstbagdatetime               = value; }            get { return sdfirstbagdatetime               ; }        }
        public string SDLASTBAGDATETIME                {            set { sdlastbagdatetime                = value; }            get { return sdlastbagdatetime                ; }        }
        public string CHECKINDESKRANGE                 {            set { checkindeskrange                 = value; }            get { return checkindeskrange                 ; }        }
        public string CHECKINOPENDATETIME              {            set { checkinopendatetime              = value; }            get { return checkinopendatetime              ; }        }
        public string CHECKINCLOSEDDATETIME            {            set { checkincloseddatetime            = value; }            get { return checkincloseddatetime            ; }        }
        public string SDCHECKINDESKRANGE               {            set { sdcheckindeskrange               = value; }            get { return sdcheckindeskrange               ; }        }
        public string SDCHECKINOPENDATETIME            {            set { sdcheckinopendatetime            = value; }            get { return sdcheckinopendatetime            ; }        }
        public string SDCHECKINCLOSEDDATETIME          {            set { sdcheckincloseddatetime          = value; }            get { return sdcheckincloseddatetime          ; }        }
        public string GATENUMBER                       {            set { gatenumber                       = value; }            get { return gatenumber                       ; }        }
        public string GATEBOARDINGSTATUS               {            set { gateboardingstatus               = value; }            get { return gateboardingstatus               ; }        }
        public string GATEOPENDATETIME                 {            set { gateopendatetime                 = value; }            get { return gateopendatetime                 ; }        }
        public string GATECLOSEDDATETIME               {            set { gatecloseddatetime               = value; }            get { return gatecloseddatetime               ; }        }
        public string SDGATENUMBER                     {            set { sdgatenumber                     = value; }            get { return sdgatenumber                     ; }        }
        public string SDGATEOPENDATETIME               {            set { sdgateopendatetime               = value; }            get { return sdgateopendatetime               ; }        }
        public string SDGATECLOSEDDATETIME             {            set { sdgatecloseddatetime             = value; }            get { return sdgatecloseddatetime             ; }        }
        public string SUPPLEMENTARYINFORMATION         {            set { supplementaryinformation         = value; }            get { return supplementaryinformation         ; }        }
        public string SUPPLEMENTARYINFORMATIONTEXT     {            set { supplementaryinformationtext     = value; }            get { return supplementaryinformationtext     ; }        }
        public string ACTUALOFFBLOCKSDATETIME          {            set { actualoffblocksdatetime          = value; }            get { return actualoffblocksdatetime          ; }        }
        public string ACTUALONBLOCKSDATETIME           {            set { actualonblocksdatetime           = value; }            get { return actualonblocksdatetime           ; }        }
        public string ESTIMATEDFLIGHTDURATION          {            set { estimatedflightduration          = value; }            get { return estimatedflightduration          ; }        }
        public string NEXTSTATIONACTUALDATETIME        {            set { nextstationactualdatetime        = value; }            get { return nextstationactualdatetime        ; }        }
        public string NEXTSTATIONESTIMATEDDATETIME     {            set { nextstationestimateddatetime     = value; }            get { return nextstationestimateddatetime     ; }        }
        public string NEXTSTATIONSCHEDULEDDATETIME     {            set { nextstationscheduleddatetime     = value; }            get { return nextstationscheduleddatetime     ; }        }
        public string PREVIOUSAIRBORNEDATETIME         {            set { previousairbornedatetime         = value; }            get { return previousairbornedatetime         ; }        }
        public string PREVIOUSESTIMATEDDATETIME        {            set { previousestimateddatetime        = value; }            get { return previousestimateddatetime        ; }        }
        public string PREVIOUSSCHEDULEDDATETIME        {            set { previousscheduleddatetime        = value; }            get { return previousscheduleddatetime        ; }        }
        public string FIRSTBAGDATETIME                 {            set { firstbagdatetime                 = value; }            get { return firstbagdatetime                 ; }        }
        public string LASTBAGDATETIME                  {            set { lastbagdatetime                  = value; }            get { return lastbagdatetime                  ; }        }
        public string LATESTKNOWNDATETIME              {            set { latestknowndatetime              = value; }            get { return latestknowndatetime              ; }        }
        public string LATESTKNOWNDATETIMESOURCE        {            set { latestknowndatetimesource        = value; }            get { return latestknowndatetimesource        ; }        }
        public string AIRCRAFTSUBTYPEIATACODE          {            set { aircraftsubtypeiatacode          = value; }            get { return aircraftsubtypeiatacode          ; }        }
        //private string scheduledDateTime;
        //private string flightNatureCode;
        //private string flightDataId;
        //private string airportIataCode;
        //private string wheelsUpDownDateTime;
        //private string aircraftSubtypeIataCode;
        //private string portOfCallIataCode;
        //private string checkinDeskRange;
        //private string flightSectorCode;
        //private string passengerTerminalCode;
        //private string standPosition;
        //private string gateNumber;
        //private string divertAirportIataCode;
        //private string codeShareStatus;
        //private string estimatedDateTime;
        //private string checkinOpenDateTime;
        //private string checkinClosedDateTime;
        //private string sdCheckinDeskRange;
        //private string sdCheckinOpenDateTime;
        //private string sdCheckinClosedDateTime;
        //private string baggageReclaimCarouselId;
        //private string baggageReclaimOpenDateTime;
        //private string baggageReclaimClosedDateTime;
        //private string sdBagReclaimCarouselId;
        //private string sdBagReclaimOpenDateTime;
        //private string sdBagReclaimClosedDateTime;
        //private string gateBoardingStatus;
        //private string gateOpenDateTime;
        //private string gateClosedDateTime;
        //private string sdGateNumber;
        //private string sdGateOpenDateTime;
        //private string flightIdentity;
        //private string sdGateClosedDateTime;
        //private string flightDirection;
        //private string operationtypecode;
        //private string masterflightdataid;
        //
        ///// <summary>
        ///// 出发航班的计划出发时间
        ///// </summary>
        //public string SCHEDULEDDATETIME
        //{
        //    set { scheduledDateTime = value; }
        //    get { return scheduledDateTime; }
        //}
        ///// <summary>
        ///// 客货班性质
        ///// </summary>
        //public string FLIGHTNATURECODE
        //{
        //    set { flightNatureCode = value; }
        //    get { return flightNatureCode; }
        //}
        ///// <summary>
        ///// 航班唯一标识
        ///// </summary>
        //public string FLIGHTDATAID
        //{
        //    set { flightDataId = value; }
        //    get { return flightDataId; }
        //}
        ///// <summary>
        ///// 到达航班的前站出发机场,出发航班的目的机场
        ///// </summary>
        //public string AIRPORTIATACODE
        //{
        //    set { airportIataCode = value; }
        //    get { return airportIataCode; }
        //}
        ///// <summary>
        ///// 实际到达时间,实际出发时间
        ///// </summary>
        //public string WHEELSUPDOWNDATETIME
        //{
        //    set { wheelsUpDownDateTime = value; }
        //    get { return wheelsUpDownDateTime; }
        //}
        ///// <summary>
        ///// 机型
        ///// </summary>
        //public string AIRCRAFTSUBTYPEIATACODE
        //{
        //    set { aircraftSubtypeIataCode = value; }
        //    get { return aircraftSubtypeIataCode; }
        //}
        ///// <summary>
        ///// 经停机场
        ///// </summary>
        //public string PORTOFCALLIATACODE
        //{
        //    set { portOfCallIataCode = value; }
        //    get { return portOfCallIataCode; }
        //}
        ///// <summary>
        ///// 办票柜台
        ///// </summary>
        //public string CHECKINDESKRANGE
        //{
        //    set { checkinDeskRange = value; }
        //    get { return checkinDeskRange; }
        //}
        ///// <summary>
        ///// 航段代码（D表示国内，I表示国际，R表示区域，M表示混合）
        ///// </summary>
        //public string FLIGHTSECTORCODE
        //{
        //    set { flightSectorCode = value; }
        //    get { return flightSectorCode; }
        //}
        ///// <summary>
        ///// 候机楼
        ///// </summary>
        //public string PASSENGERTERMINALCODE
        //{
        //    set { passengerTerminalCode = value; }
        //    get { return passengerTerminalCode; }
        //}
        ///// <summary>
        ///// 停机位
        ///// </summary>
        //public string STANDPOSITION
        //{
        //    set { standPosition = value; }
        //    get { return standPosition; }
        //}
        ///// <summary>
        ///// 登机门
        ///// </summary>
        //public string GATENUMBER
        //{
        //    set { gateNumber = value; }
        //    get { return gateNumber; }
        //}
        ///// <summary>
        ///// 中转机场代码
        ///// </summary>
        //public string DIVERTAIRPORTIATACODE
        //{
        //    set { divertAirportIataCode = value; }
        //    get { return divertAirportIataCode; }
        //}
        ///// <summary>
        ///// 代码共享状态
        ///// </summary>
        //public string CODESHARESTATUS
        //{
        //    set { codeShareStatus = value; }
        //    get { return codeShareStatus; }
        //}
        ///// <summary>
        ///// 出发航班的预计出发时间,到达航班的预计到达时间
        ///// </summary>
        //public string ESTIMATEDDATETIME
        //{
        //    set { estimatedDateTime = value; }
        //    get { return estimatedDateTime; }
        //}
        ///// <summary>
        ///// 办票开始时间
        ///// </summary>
        //public string CHECKINOPENDATETIME
        //{
        //    set { checkinOpenDateTime = value; }
        //    get { return checkinOpenDateTime; }
        //}
        ///// <summary>
        ///// 办票结束时间
        ///// </summary>
        //public string CHECKINCLOSEDDATETIME
        //{
        //    set { checkinClosedDateTime = value; }
        //    get { return checkinClosedDateTime; }
        //}
        ///// <summary>
        ///// 从办票柜台
        ///// </summary>
        //public string SDCHECKINDESKRANGE
        //{
        //    set { sdCheckinDeskRange = value; }
        //    get { return sdCheckinDeskRange; }
        //}
        ///// <summary>
        ///// 从办票柜台开始时间
        ///// </summary>
        //public string SDCHECKINOPENDATETIME
        //{
        //    set { sdCheckinOpenDateTime = value; }
        //    get { return sdCheckinOpenDateTime; }
        //}
        ///// <summary>
        ///// 从办票柜台结束时间
        ///// </summary>
        //public string SDCHECKINCLOSEDDATETIME
        //{
        //    set { sdCheckinClosedDateTime = value; }
        //    get { return sdCheckinClosedDateTime; }
        //}
        ///// <summary>
        ///// 行李提取转盘代码
        ///// </summary>
        //public string BAGGAGERECLAIMCAROUSELID
        //{
        //    set { baggageReclaimCarouselId = value; }
        //    get { return baggageReclaimCarouselId; }
        //}
        ///// <summary>
        ///// 行李提取转盘开始时间
        ///// </summary>
        //public string BAGGAGERECLAIMOPENDATETIME
        //{
        //    set { baggageReclaimOpenDateTime = value; }
        //    get { return baggageReclaimOpenDateTime; }
        //}
        ///// <summary>
        ///// 行李提取转盘结束时间
        ///// </summary>
        //public string BAGGAGERECLAIMCLOSEDDATETIME
        //{
        //    set { baggageReclaimClosedDateTime = value; }
        //    get { return baggageReclaimClosedDateTime; }
        //}
        ///// <summary>
        ///// 从行李提取转盘代码
        ///// </summary>
        //public string SDBAGRECLAIMCAROUSELID
        //{
        //    set { sdBagReclaimCarouselId = value; }
        //    get { return sdBagReclaimCarouselId; }
        //}
        ///// <summary>
        ///// 从行李提取转盘开始时间
        ///// </summary>
        //public string SDBAGRECLAIMOPENDATETIME
        //{
        //    set { sdBagReclaimOpenDateTime = value; }
        //    get { return sdBagReclaimOpenDateTime; }
        //}
        ///// <summary>
        ///// 从行李提取转盘结束时间
        ///// </summary>
        //public string SDBAGRECLAIMCLOSEDDATETIME
        //{
        //    set { sdBagReclaimClosedDateTime = value; }
        //    get { return sdBagReclaimClosedDateTime; }
        //}
        ///// <summary>
        ///// 登机门状态
        ///// </summary>
        //public string GATEBOARDINGSTATUS
        //{
        //    set { gateBoardingStatus = value; }
        //    get { return gateBoardingStatus; }
        //}
        ///// <summary>
        ///// 登机门开放时间
        ///// </summary>
        //public string GATEOPENDATETIME
        //{
        //    set { gateOpenDateTime = value; }
        //    get { return gateOpenDateTime; }
        //}
        ///// <summary>
        ///// 登机门关闭时间
        ///// </summary>
        //public string GATECLOSEDDATETIME
        //{
        //    set { gateClosedDateTime = value; }
        //    get { return gateClosedDateTime; }
        //}
        ///// <summary>
        ///// 从登机门
        ///// </summary>
        //public string SDGATENUMBER
        //{
        //    set { sdGateNumber = value; }
        //    get { return sdGateNumber; }
        //}
        ///// <summary>
        ///// 从登机门开放时间
        ///// </summary>
        //public string SDGATEOPENDATETIME
        //{
        //    set { sdGateOpenDateTime = value; }
        //    get { return sdGateOpenDateTime; }
        //}
        ///// <summary>
        ///// 航班号
        ///// </summary>
        //public string FLIGHTIDENTITY
        //{
        //    set { flightIdentity = value; }
        //    get { return flightIdentity; }
        //}
        ///// <summary>
        ///// 从登机门关闭时间
        ///// </summary>
        //public string SDGATECLOSEDDATETIME
        //{
        //    set { sdGateClosedDateTime = value; }
        //    get { return sdGateClosedDateTime; }
        //}
        ///// <summary>
        ///// 航路方向
        ///// </summary>
        //public string FLIGHTDIRECTION
        //{
        //    set { flightDirection = value; }
        //    get { return flightDirection; }
        //}
        ///// <summary>
        ///// 航班状态
        ///// </summary>
        //public string OPERATIONTYPECODE
        //{
        //    get { return operationtypecode; }
        //    set { operationtypecode = value; }
        //}
        ///// <summary>
        ///// 主航班ID
        ///// </summary>
        //public string MASTERFLIGHTDATAID
        //{
        //    get { return masterflightdataid; }
        //    set { masterflightdataid = value; }
        //}
        #endregion
    }
}
