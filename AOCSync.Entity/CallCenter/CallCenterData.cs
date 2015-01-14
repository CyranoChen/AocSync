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
        private string flightdataid                     ;//--������Ϣ���(�Զ�����)
        private string occurdatetime                    ;//--����ʱ��(ϵͳ������ʱ��)
        private string flightidentity                   ;//--�����ʾ
        private string scheduleddate                    ;//--�ƻ�����
        private string carrieriatacode                  ;//--���չ�˾IATA����, ���չ�˾������
        private string flightnumber                     ;//--�����
        private string flightsuffix                     ;//--�����׺
        private string flightdirection                  ;//--���෽��--'D' Departure--'A' Arrival
        private string flightrepeatcount                ;//--�����ظ�����
        private string carriericaocode                  ;//--���չ�˾ICAO����
        private string airportiatacode                  ;//--��������
        private string codesharestatus                  ;//--���빲��״̬--SF ������--'00'��'99'
        private string flightcancelcode                 ;//--����ȡ������--'C' Cancelled ����ȡ��--'D' Diverted ����Ľ� --'N' Non-operational ����Ӫ
        private string divertairportiatacode            ;//--��ת��������
        private string flightnaturecode                 ;//--�������ʴ���
        private string flightservicetypeiatacode        ;//--����������ʹ���
        private string flightstatuscode                 ;//--����״̬����--AB-Airborne--BD-Boarding--CX-Cancelled--DV-Diverted--ES-Estimated--EX-Expected--FB-First Bag--FS-Final Approach--FX-Flight Fixed--GA-Gate Attended--GC-Gate Close--GO-Gate Open--LB-Last Bag--LC-Last Call--LD-Landed--NI-Next Information--OB-On/Off Blocks--OT-On Time--OV-Overshoot--RS-Return To Stand--SH-Scheduled--ZN-Zoning
        private string flightsectorcode                 ;//--���δ���--'D'���ں���--'I'���ʺ���--'R'���򺽰�--'M'��Ϻ���
        private string isreturnflight                   ;//--�Ƿ��Ƿ��غ���--'0'�Ƿ��غ���--'1'���غ���
        private string isgeneralaviationflight          ;//--�Ƿ�����������
        private string flighttransitcode                ;//--������ת����--'Y'-Normal--'T'-Technical
        private string newflightreason                  ;//--�¼Ӻ���ԭ��--'RET'--��ʾ��������--'DIV'--��ʾ��������, �Ӳ�ͬ�Ļ����������������ĺ���
        private string operationtypecode                ;//--������Ӫ���ʹ���--'DEL'--��ʾ��������, ����׼ȷ��Ԥ��ʱ��, ����Ԥ��ʱ����ƻ�ʱ������㹻��--'DFI'--��ʾ��������, �����µ�Ԥ��ʱ��δ֪ʱ--'CAN'--��ʾ����ȡ��--'ADV'--��ʾ������ǰ, ������EstimatedDateTime�ֶα��ʱ��--'MER'--��ʾ�ú����Ǻϲ�����--'CSF'--��ʾ�ú����ǹ�����--'RET'--��ʾ�Ƿ�������--'SLI'--��ʾ���غ���--'MVT'--��ʾ�����ƶ�����, �����һ����λǣ������һ����λ--'ALT'--��ʾ��������, �Ľ�����������, �纽�������ǽ��䵽�ֶ�, ����������ԭ��, ���䵽���ݻ���--'CHG'--��ʾ�Ľ�����, �Ľ������ػ���, ����ֶ��Ľ������Ż���--'ADF'--��ʾ�ǵ���ļ�ʱ����--'POS'--��ʾ�ǵ������࣬����Ż����ĺ���������ֶ�����--'NOP'--��ʾ�Ƿ���Ӫ����--'REG'--��������
        private string transferflightidentity           ;//--��ת�����ʾ
        private string estimateddatetime                ;//--Ԥ��ʱ��
        private string scheduleddatetime                ;//--�ƻ�ʱ��
        private string wheelsupdowndatetime             ;//--����/����ʱ��
        private string portofcalliatacode               ;//--��ͣ����
        private string flightflag                       ;//--�����־--'0'��������--'1'��������--'2'�ӹ�����--'3'���ϲ�����--'4'�Ӻϲ�����
        private string masterflightdataid               ;//--���������
        private string aircraftterminalcode             ;//--��Ʊ��վ¥
        private string passengerterminalcode            ;//--�ǻ���վ¥
        private string standposition                    ;//--��λ����
        private string baggagereclaimcarouselid         ;//--������ȡת�̴���
        private string baggagereclaimcarouselrole       ;//--������ȡת������
        private string baggagereclaimopendatetime       ;//--������ȡת�̿�ʼʱ��
        private string baggagereclaimcloseddatetime     ;//--������ȡת�̽���ʱ��
        private string sdbagreclaimcarouselid           ;//--��������ȡת�̴���
        private string sdbagreclaimcarouselrole         ;//--��������ȡת������
        private string sdbagreclaimopendatetime         ;//--��������ȡת�̿�ʼʱ��
        private string sdbagreclaimcloseddatetime       ;//--��������ȡת�̽���ʱ��
        private string sdfirstbagdatetime               ;//--����ȡ����Ŀ�ʼʱ��
        private string sdlastbagdatetime                ;//--����ȡ����Ľ���ʱ��
        private string checkindeskrange                 ;//--���а�Ʊ��̨, ��'16, 18, 20'
        private string checkinopendatetime              ;//--��Ʊ��ʼʱ��
        private string checkincloseddatetime            ;//--��Ʊ����ʱ��
        private string sdcheckindeskrange               ;//--�����а�Ʊ��̨, ��'16, 18, 20'
        private string sdcheckinopendatetime            ;//--�Ӱ�Ʊ��ʼʱ��
        private string sdcheckincloseddatetime          ;//--�Ӱ�Ʊ����ʱ��
        private string gatenumber                       ;//--�ǻ��ű�ʾ
        private string gateboardingstatus               ;//--�ǻ���״̬--'0'--Open--'1'--Attended--'2'--Boarding--'3'--Last Call--'9'--Closed
        private string gateopendatetime                 ;//--�ǻ��ſ�ʼʱ��
        private string gatecloseddatetime               ;//--�ǻ��Ž���ʱ��
        private string sdgatenumber                     ;//--�ӵǻ��ű�ʾ
        private string sdgateopendatetime               ;//--�ӵǻ��ſ�ʼʱ��
        private string sdgatecloseddatetime             ;//--�ӵǻ��Ž���ʱ��
        private string supplementaryinformation         ;//--������Ϣ
        private string supplementaryinformationtext     ;//--������Ϣ�ı�
        private string actualoffblocksdatetime          ;//--������ֵ�
        private string actualonblocksdatetime           ;//--�������ֵ�
        private string estimatedflightduration          ;//--Ԥ�ƺ����������
        private string nextstationactualdatetime        ;//--�ɻ�������һ��������׼ȷʱ��
        private string nextstationestimateddatetime     ;//--�ɻ�������һ��������Ԥ��ʱ��
        private string nextstationscheduleddatetime     ;//--�ɻ�������һ�������ļƻ�ʱ��
        private string previousairbornedatetime         ;//--��һվ��׼ȷ����ʱ��
        private string previousestimateddatetime        ;//--��һվ��Ԥ�Ƴ���ʱ��
        private string previousscheduleddatetime        ;//--��һվ�ļƻ�����ʱ��
        private string firstbagdatetime                 ;//--��ȡ����Ŀ�ʼʱ��
        private string lastbagdatetime                  ;//--��ȡ����Ľ���ʱ��
        private string latestknowndatetime              ;//--����ĳ����򵽴����ں�ʱ��
        private string latestknowndatetimesource        ;//--����ĳ����������ں�ʱ�����Ϣ��Դ--�ƻ�ʱ�� scheduled time--Ԥ��ʱ�� estimate time--ʵ��ʱ�� actual time
        private string aircraftsubtypeiatacode          ;//--����  

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
        ///// ��������ļƻ�����ʱ��
        ///// </summary>
        //public string SCHEDULEDDATETIME
        //{
        //    set { scheduledDateTime = value; }
        //    get { return scheduledDateTime; }
        //}
        ///// <summary>
        ///// �ͻ�������
        ///// </summary>
        //public string FLIGHTNATURECODE
        //{
        //    set { flightNatureCode = value; }
        //    get { return flightNatureCode; }
        //}
        ///// <summary>
        ///// ����Ψһ��ʶ
        ///// </summary>
        //public string FLIGHTDATAID
        //{
        //    set { flightDataId = value; }
        //    get { return flightDataId; }
        //}
        ///// <summary>
        ///// ���ﺽ���ǰվ��������,���������Ŀ�Ļ���
        ///// </summary>
        //public string AIRPORTIATACODE
        //{
        //    set { airportIataCode = value; }
        //    get { return airportIataCode; }
        //}
        ///// <summary>
        ///// ʵ�ʵ���ʱ��,ʵ�ʳ���ʱ��
        ///// </summary>
        //public string WHEELSUPDOWNDATETIME
        //{
        //    set { wheelsUpDownDateTime = value; }
        //    get { return wheelsUpDownDateTime; }
        //}
        ///// <summary>
        ///// ����
        ///// </summary>
        //public string AIRCRAFTSUBTYPEIATACODE
        //{
        //    set { aircraftSubtypeIataCode = value; }
        //    get { return aircraftSubtypeIataCode; }
        //}
        ///// <summary>
        ///// ��ͣ����
        ///// </summary>
        //public string PORTOFCALLIATACODE
        //{
        //    set { portOfCallIataCode = value; }
        //    get { return portOfCallIataCode; }
        //}
        ///// <summary>
        ///// ��Ʊ��̨
        ///// </summary>
        //public string CHECKINDESKRANGE
        //{
        //    set { checkinDeskRange = value; }
        //    get { return checkinDeskRange; }
        //}
        ///// <summary>
        ///// ���δ��루D��ʾ���ڣ�I��ʾ���ʣ�R��ʾ����M��ʾ��ϣ�
        ///// </summary>
        //public string FLIGHTSECTORCODE
        //{
        //    set { flightSectorCode = value; }
        //    get { return flightSectorCode; }
        //}
        ///// <summary>
        ///// ���¥
        ///// </summary>
        //public string PASSENGERTERMINALCODE
        //{
        //    set { passengerTerminalCode = value; }
        //    get { return passengerTerminalCode; }
        //}
        ///// <summary>
        ///// ͣ��λ
        ///// </summary>
        //public string STANDPOSITION
        //{
        //    set { standPosition = value; }
        //    get { return standPosition; }
        //}
        ///// <summary>
        ///// �ǻ���
        ///// </summary>
        //public string GATENUMBER
        //{
        //    set { gateNumber = value; }
        //    get { return gateNumber; }
        //}
        ///// <summary>
        ///// ��ת��������
        ///// </summary>
        //public string DIVERTAIRPORTIATACODE
        //{
        //    set { divertAirportIataCode = value; }
        //    get { return divertAirportIataCode; }
        //}
        ///// <summary>
        ///// ���빲��״̬
        ///// </summary>
        //public string CODESHARESTATUS
        //{
        //    set { codeShareStatus = value; }
        //    get { return codeShareStatus; }
        //}
        ///// <summary>
        ///// ���������Ԥ�Ƴ���ʱ��,���ﺽ���Ԥ�Ƶ���ʱ��
        ///// </summary>
        //public string ESTIMATEDDATETIME
        //{
        //    set { estimatedDateTime = value; }
        //    get { return estimatedDateTime; }
        //}
        ///// <summary>
        ///// ��Ʊ��ʼʱ��
        ///// </summary>
        //public string CHECKINOPENDATETIME
        //{
        //    set { checkinOpenDateTime = value; }
        //    get { return checkinOpenDateTime; }
        //}
        ///// <summary>
        ///// ��Ʊ����ʱ��
        ///// </summary>
        //public string CHECKINCLOSEDDATETIME
        //{
        //    set { checkinClosedDateTime = value; }
        //    get { return checkinClosedDateTime; }
        //}
        ///// <summary>
        ///// �Ӱ�Ʊ��̨
        ///// </summary>
        //public string SDCHECKINDESKRANGE
        //{
        //    set { sdCheckinDeskRange = value; }
        //    get { return sdCheckinDeskRange; }
        //}
        ///// <summary>
        ///// �Ӱ�Ʊ��̨��ʼʱ��
        ///// </summary>
        //public string SDCHECKINOPENDATETIME
        //{
        //    set { sdCheckinOpenDateTime = value; }
        //    get { return sdCheckinOpenDateTime; }
        //}
        ///// <summary>
        ///// �Ӱ�Ʊ��̨����ʱ��
        ///// </summary>
        //public string SDCHECKINCLOSEDDATETIME
        //{
        //    set { sdCheckinClosedDateTime = value; }
        //    get { return sdCheckinClosedDateTime; }
        //}
        ///// <summary>
        ///// ������ȡת�̴���
        ///// </summary>
        //public string BAGGAGERECLAIMCAROUSELID
        //{
        //    set { baggageReclaimCarouselId = value; }
        //    get { return baggageReclaimCarouselId; }
        //}
        ///// <summary>
        ///// ������ȡת�̿�ʼʱ��
        ///// </summary>
        //public string BAGGAGERECLAIMOPENDATETIME
        //{
        //    set { baggageReclaimOpenDateTime = value; }
        //    get { return baggageReclaimOpenDateTime; }
        //}
        ///// <summary>
        ///// ������ȡת�̽���ʱ��
        ///// </summary>
        //public string BAGGAGERECLAIMCLOSEDDATETIME
        //{
        //    set { baggageReclaimClosedDateTime = value; }
        //    get { return baggageReclaimClosedDateTime; }
        //}
        ///// <summary>
        ///// ��������ȡת�̴���
        ///// </summary>
        //public string SDBAGRECLAIMCAROUSELID
        //{
        //    set { sdBagReclaimCarouselId = value; }
        //    get { return sdBagReclaimCarouselId; }
        //}
        ///// <summary>
        ///// ��������ȡת�̿�ʼʱ��
        ///// </summary>
        //public string SDBAGRECLAIMOPENDATETIME
        //{
        //    set { sdBagReclaimOpenDateTime = value; }
        //    get { return sdBagReclaimOpenDateTime; }
        //}
        ///// <summary>
        ///// ��������ȡת�̽���ʱ��
        ///// </summary>
        //public string SDBAGRECLAIMCLOSEDDATETIME
        //{
        //    set { sdBagReclaimClosedDateTime = value; }
        //    get { return sdBagReclaimClosedDateTime; }
        //}
        ///// <summary>
        ///// �ǻ���״̬
        ///// </summary>
        //public string GATEBOARDINGSTATUS
        //{
        //    set { gateBoardingStatus = value; }
        //    get { return gateBoardingStatus; }
        //}
        ///// <summary>
        ///// �ǻ��ſ���ʱ��
        ///// </summary>
        //public string GATEOPENDATETIME
        //{
        //    set { gateOpenDateTime = value; }
        //    get { return gateOpenDateTime; }
        //}
        ///// <summary>
        ///// �ǻ��Źر�ʱ��
        ///// </summary>
        //public string GATECLOSEDDATETIME
        //{
        //    set { gateClosedDateTime = value; }
        //    get { return gateClosedDateTime; }
        //}
        ///// <summary>
        ///// �ӵǻ���
        ///// </summary>
        //public string SDGATENUMBER
        //{
        //    set { sdGateNumber = value; }
        //    get { return sdGateNumber; }
        //}
        ///// <summary>
        ///// �ӵǻ��ſ���ʱ��
        ///// </summary>
        //public string SDGATEOPENDATETIME
        //{
        //    set { sdGateOpenDateTime = value; }
        //    get { return sdGateOpenDateTime; }
        //}
        ///// <summary>
        ///// �����
        ///// </summary>
        //public string FLIGHTIDENTITY
        //{
        //    set { flightIdentity = value; }
        //    get { return flightIdentity; }
        //}
        ///// <summary>
        ///// �ӵǻ��Źر�ʱ��
        ///// </summary>
        //public string SDGATECLOSEDDATETIME
        //{
        //    set { sdGateClosedDateTime = value; }
        //    get { return sdGateClosedDateTime; }
        //}
        ///// <summary>
        ///// ��·����
        ///// </summary>
        //public string FLIGHTDIRECTION
        //{
        //    set { flightDirection = value; }
        //    get { return flightDirection; }
        //}
        ///// <summary>
        ///// ����״̬
        ///// </summary>
        //public string OPERATIONTYPECODE
        //{
        //    get { return operationtypecode; }
        //    set { operationtypecode = value; }
        //}
        ///// <summary>
        ///// ������ID
        ///// </summary>
        //public string MASTERFLIGHTDATAID
        //{
        //    get { return masterflightdataid; }
        //    set { masterflightdataid = value; }
        //}
        #endregion
    }
}
