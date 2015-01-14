using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AOCSync.Entity
{
    public class AOCDataFQSHIS
    {
        public AOCDataFQSHIS() { }
        public void Insert()
        {
            Insert(null);
        }
        public void Insert(SqlTransaction trans)
        {
            DataAccess.AOCDataFQSHIS.InsertAOCDataFQSHIS(
                ID, URNO, CARRIER_IATA, CARRIER_ICAO, FL_NUMBER, FL_SUFFIX, FLT, FLR, SDT, SDP, LINKEDFL_FLT, LINKEDFL_CARRIER,
                LINKEDFL_NUMBER, LINKEDFL_SUFFIX, LINKEDFL_SDT, LINKEDFL_FLR, LINKFL_ID, MASTERFL_CARRIER, MASTERFL_NUMBER, MASTERFL_SUFFIX, MFDI,
                MASTERFL_FLR, MASTERFL_ID, AIRCRAFT_CALLSIGN, AIRCRAFT_OWNER, AIRCRAFT_PAXCAP, REGN, ATC5, AIRCRAFT_TYPE, AIRCRAFT_OPERATOR,
                AIRCRAFT_TERMINAL, AIRPORT_IATA, BRC1, RECLAIM_ROLE1, BROD, BRCD, EXITDOOR1, SRC2, RECLAIM_ROLE2, SBRO, SBRC, EXITDOOR2, MAKEUP_ID1, MAKEUP_ROLE1,
                MAKEUP_OPEN_TIME1, MAKEUP_CLOSE_TIME1, MAKEUP_ID2, MAKEUP_ROLE2, MAKEUP_OPEN_TIME2, MAKEUP_CLOSE_TIME2, ISBUSREQUIRED, CC_TYPE1, CKIF, CC_ROLE1,
                CC_CLUSTERID1, CODT, CCDT, CC_TYPE2, SCDR, CC_ROLE2, CC_CLUSTERID2, SCODT, SCCDT, SGCD, SGOD, GATE_BORDING_STATUS2, GATE_ROLE2, SGN, GCDT, GODT,
                GBS, GATE_ROLE1, GENO, TERM, REMARK_CODE1, REMARK_TYPE1, REMARK_CODE2, REMARK_TYPE2, REMARK_CODE3, REMARK_TYPE3, REMARK_CODE4,
                REMARK_TYPE4, RUNWAY_ID, S_INFO_TYPE1, S_INFO_TEXT1, S_INFO_TYPE2, S_INFO_TEXT2, S_INFO_TYPE3, S_INFO_TEXT3, S_INFO_TYPE4, S_INFO_TEXT4,
                S_INFO_TYPE5, S_INFO_TEXT5, ACCOUNT_CODE, FL_CLASSIFICATIONCODE, FL_STATUSCODE, CSS, DAIA, FL_CANCELCODE, FL_OPERATES_OVERNIGHT, TTYP,
                FL_SERVICETYPE, FLTI, FL_TRANSITCODE, HANDLINGAGENT1, HANDLING_SERVICE1, HANDLINGAGENT2, HANDLING_SERVICE2, HANDLINGAGENT3, HANDLING_SERVICE3,
                HANDLINGAGENT4, HANDLING_SERVICE4, HANDLINGAGENT5, HANDLING_SERVICE5, IRR_NUMBER1, IRR_CODE1, IRR_DURATION1, IRR_NUMBER2, IRR_CODE2, IRR_DURATION2,
                ISGVF, ISRETURNFL, ISTRANSFERFL, NEWFL_REASON, OPERATIONTYPE_CODE1, TRANSFER_FL1, TRANSFER_FL2, TRANSFER_FL3, TRANSFER_FL4, TRANSFER_FL5,
                TRANSFER_FL6, TRANSFER_FL7, TRANSFER_FL8, TRANSFER_FL9, TRANSFER_FL10, TRANSFER_FL11, TRANSFER_FL12, TRANSFER_FL13, TRANSFER_FL14, TRANSFER_FL15,
                TRANSFER_FL16, TRANSFER_FL17, TRANSFER_FL18, TRANSFER_FL19, TRANSFER_FL20, SHAREFL_FLT1, SHAREFL_FLN1, SHAREFL_FLT2, SHAREFL_FLN2, SHAREFL_FLT3,
                SHAREFL_FLN3, SHAREFL_FLT4, SHAREFL_FLN4, SHAREFL_FLT5, SHAREFL_FLN5, SHAREFL_FLT6, SHAREFL_FLN6, TOTAL_BAGCOUNT, TOTAL_BAGWEIGHT,
                TOTAL_FREIGHTWEIGHT, TOTAL_MAILWEIGHT, TOTAL_LOADWEIGHT, ADULT_PAXCOUNT, BUSSINESS_PAXCOUNT, CHILD_PAXCOUNT, DOMESITEC_PAXCOUNT,
                INFANT_PAXCOUNT, INTERNATIONAL_PAXCOUNT, LOCAL_PAXCOUNT, NONTRANSFER_PAXCOUNT, TOTAL_PAXCOUNT, TRANSFER_PAXCOUNT, TRANSIT_PAXCOUNT,
                WHELLCHAIR_PAXCOUNT, TOTAL_CREWCOUNT, ECONOMY_PAXCOUNT, FIRSTCLASS_PAXCOUNT, TRANSFER_BAGCOUNT, TRANSFER_BAGWEIGHT, TRANSFER_FREIGHTWEIGHT,
                TRANSFER_MAILWEIGHT, TRANSIT_BAGCOUNT, TRANSIT_BAGWEIGHT, TRANSIT_FREIGHTWEIGHT, TRANSIT_MAILWEIGHT, OFFBLOCK_TIME, ONBLOCK_TIME, EDTA, EDTD,
                E_FL_DURATION, FIRSTBAG_TIME, LASTBAG_TIME, FINALAPPROACH_TIME, LASTKNOWN_TIME, LASTKNOWN_SOURCE, NEXT_INFO_TIME, A_NEXT_STATION_TIME,
                E_NEXT_STATION_TIME, S_NEXT_STATION_TIME, A_PREV_STATION_TIME, E_PREV_STATION_TIME, S_PREV_STATION_TIME, LAND, AIRB, TEN_MILES_TIME, ORG3, DES3,
                ORG_ICAO, DES_ICAO, VIA1, VIA_ICAO, PUBLIC_FLT, PUBLIC_FLC, PUBLIC_TIME, SECURE_STAND_IS_REQUIRED, STOD, STPO, OPERATIONTYPE_CODE2,
                FIRSTBAG_TIME2, LASTBAG_TIME2, OPERATIONTYPE_ROLE1, OPERATIONTYPE_ROLE2, UPDATE_TIME, CUSTOM_STATUS, SUB_AIRLINE, LTD, LTA, AIRLINE_TERMINAL,
                GATE_PLAN_CLOSE_TIME1, GATE_PLAN_OPEN_TIME1, GATE_PLAN_CLOSE_TIME2, GATE_PLAN_OPEN_TIME2, USEC, TYPC, CDAT, USEU, TYPU, LSTU, JFNO, CTRL, DRCT, trans);
        }
        public static void GenerateAOCDataFQSHISByAOCDataFQS(List<AOCDataFQS> aocDataList, SqlTransaction trans)
        {
            foreach (AOCDataFQS aocData in aocDataList)
            {
                GenerateAOCDataFQSHISByAOCDataFQS(aocData, trans);
            }
        }

        private static void GenerateAOCDataFQSHISByAOCDataFQS(AOCDataFQS aocData, SqlTransaction trans)
        {
            AOCDataFQSHIS aocHisData = new AOCDataFQSHIS();
            aocHisData.TransferToAOCDataFQSHISByAOCDataFQS(aocData);
            aocHisData.Insert(trans);           
        }

        public void TransferToAOCDataFQSHISByAOCDataFQS(AOCDataFQS aocData)
        {
            ID = aocData.ID.ToString();
            URNO = aocData.URNO;
            CARRIER_IATA = aocData.CARRIER_IATA;
            CARRIER_ICAO = aocData.CARRIER_ICAO;
            FL_NUMBER = aocData.FL_NUMBER;
            FL_SUFFIX = aocData.FL_SUFFIX;
            FLT = aocData.FLT;
            FLR = aocData.FLR;
            SDT = aocData.SDT;
            SDP = aocData.SDP;
            LINKEDFL_FLT = aocData.LINKEDFL_FLT;
            LINKEDFL_CARRIER = aocData.LINKEDFL_CARRIER;
            LINKEDFL_NUMBER = aocData.LINKEDFL_NUMBER;
            LINKEDFL_SUFFIX = aocData.LINKEDFL_SUFFIX;
            LINKEDFL_SDT = aocData.LINKEDFL_SDT;
            LINKEDFL_FLR = aocData.LINKEDFL_FLR;
            LINKFL_ID = aocData.LINKFL_ID;
            MASTERFL_CARRIER = aocData.MASTERFL_CARRIER;
            MASTERFL_NUMBER = aocData.MASTERFL_NUMBER;
            MASTERFL_SUFFIX = aocData.MASTERFL_SUFFIX;
            MFDI = aocData.FLT;
            MASTERFL_FLR = aocData.MASTERFL_FLR;
            MASTERFL_ID = aocData.MASTERFL_ID;
            AIRCRAFT_CALLSIGN = aocData.AIRCRAFT_CALLSIGN;
            AIRCRAFT_OWNER = aocData.AIRCRAFT_OWNER;
            AIRCRAFT_PAXCAP = aocData.AIRCRAFT_PAXCAP;
            REGN = aocData.REGN;
            ATC5 = aocData.ATC5;
            AIRCRAFT_TYPE = aocData.AIRCRAFT_TYPE;
            AIRCRAFT_OPERATOR = aocData.AIRCRAFT_OPERATOR;
            AIRCRAFT_TERMINAL = aocData.AIRCRAFT_TERMINAL;
            AIRPORT_IATA = aocData.AIRPORT_IATA;
            BRC1 = aocData.BRC1;
            RECLAIM_ROLE1 = aocData.RECLAIM_ROLE1;
            BROD = aocData.BROD;
            BRCD = aocData.BRCD;
            EXITDOOR1 = aocData.EXITDOOR1;
            SRC2 = aocData.SRC2;
            RECLAIM_ROLE2 = aocData.RECLAIM_ROLE2;
            SBRO = aocData.SBRO;
            SBRC = aocData.SBRC;
            EXITDOOR2 = aocData.EXITDOOR2;
            MAKEUP_ID1 = aocData.MAKEUP_ID1;
            MAKEUP_ROLE1 = aocData.MAKEUP_ROLE1;
            MAKEUP_OPEN_TIME1 = aocData.MAKEUP_OPEN_TIME1;
            MAKEUP_CLOSE_TIME1 = aocData.MAKEUP_CLOSE_TIME1;
            MAKEUP_ID2 = aocData.MAKEUP_ID2;
            MAKEUP_ROLE2 = aocData.MAKEUP_ROLE2;
            MAKEUP_OPEN_TIME2 = aocData.MAKEUP_OPEN_TIME2;
            MAKEUP_CLOSE_TIME2 = aocData.MAKEUP_CLOSE_TIME2;
            ISBUSREQUIRED = aocData.ISBUSREQUIRED;
            CC_TYPE1 = aocData.CC_TYPE1;
            CKIF = aocData.CKIF;
            CC_ROLE1 = aocData.CC_ROLE1;
            CC_CLUSTERID1 = aocData.CC_CLUSTERID1;
            CODT = aocData.CODT;
            CCDT = aocData.CCDT;
            CC_TYPE2 = aocData.CC_TYPE2;
            SCDR = aocData.SCDR;
            CC_ROLE2 = aocData.CC_ROLE2;
            CC_CLUSTERID2 = aocData.CC_CLUSTERID2;
            SCODT = aocData.SCODT;
            SCCDT = aocData.SCCDT;
            SGCD = aocData.SGCD;
            SGOD = aocData.SGOD;
            GATE_BORDING_STATUS2 = aocData.GATE_BORDING_STATUS2;
            GATE_ROLE2 = aocData.GATE_ROLE2;
            SGN = aocData.SGN;
            GCDT = aocData.GCDT;
            GODT = aocData.GODT;
            GBS = aocData.GBS;
            GATE_ROLE1 = aocData.GATE_ROLE1;
            GENO = aocData.GENO;
            TERM = aocData.TERM;
            REMARK_CODE1 = aocData.REMARK_CODE1;
            REMARK_TYPE1 = aocData.REMARK_TYPE1;
            REMARK_CODE2 = aocData.REMARK_CODE2;
            REMARK_TYPE2 = aocData.REMARK_TYPE2;
            REMARK_CODE3 = aocData.REMARK_CODE3;
            REMARK_TYPE3 = aocData.REMARK_TYPE3;
            REMARK_CODE4 = aocData.REMARK_CODE4;
            REMARK_TYPE4 = aocData.REMARK_TYPE4;
            RUNWAY_ID = aocData.RUNWAY_ID;
            S_INFO_TYPE1 = aocData.S_INFO_TYPE1;
            S_INFO_TEXT1 = aocData.S_INFO_TEXT1;
            S_INFO_TYPE2 = aocData.S_INFO_TYPE2;
            S_INFO_TEXT2 = aocData.S_INFO_TEXT2;
            S_INFO_TYPE3 = aocData.S_INFO_TYPE3;
            S_INFO_TEXT3 = aocData.S_INFO_TEXT3;
            S_INFO_TYPE4 = aocData.S_INFO_TYPE4;
            S_INFO_TEXT4 = aocData.S_INFO_TEXT4;
            S_INFO_TYPE5 = aocData.S_INFO_TYPE5;
            S_INFO_TEXT5 = aocData.S_INFO_TEXT5;
            ACCOUNT_CODE = aocData.ACCOUNT_CODE;
            FL_CLASSIFICATIONCODE = aocData.FL_CLASSIFICATIONCODE;
            FL_STATUSCODE = aocData.FL_STATUSCODE;
            CSS = aocData.CSS;
            DAIA = aocData.DAIA;
            FL_CANCELCODE = aocData.FL_CANCELCODE;
            FL_OPERATES_OVERNIGHT = aocData.FL_OPERATES_OVERNIGHT;
            TTYP = aocData.TTYP;
            FL_SERVICETYPE = aocData.FL_SERVICETYPE;
            FLTI = aocData.FLTI;
            FL_TRANSITCODE = aocData.FL_TRANSITCODE;
            HANDLINGAGENT1 = aocData.HANDLINGAGENT1;
            HANDLING_SERVICE1 = aocData.HANDLING_SERVICE1;
            HANDLINGAGENT2 = aocData.HANDLINGAGENT2;
            HANDLING_SERVICE2 = aocData.HANDLING_SERVICE2;
            HANDLINGAGENT3 = aocData.HANDLINGAGENT3;
            HANDLING_SERVICE3 = aocData.HANDLING_SERVICE3;
            HANDLINGAGENT4 = aocData.HANDLINGAGENT4;
            HANDLING_SERVICE4 = aocData.HANDLING_SERVICE4;
            HANDLINGAGENT5 = aocData.HANDLINGAGENT5;
            HANDLING_SERVICE5 = aocData.HANDLING_SERVICE5;
            IRR_NUMBER1 = aocData.IRR_NUMBER1;
            IRR_CODE1 = aocData.IRR_CODE1;
            IRR_DURATION1 = aocData.IRR_DURATION1;
            IRR_NUMBER2 = aocData.IRR_NUMBER2;
            IRR_CODE2 = aocData.IRR_CODE2;
            IRR_DURATION2 = aocData.IRR_DURATION2;
            ISGVF = aocData.ISGVF;
            ISRETURNFL = aocData.ISRETURNFL;
            ISTRANSFERFL = aocData.ISTRANSFERFL;
            NEWFL_REASON = aocData.NEWFL_REASON;
            OPERATIONTYPE_CODE1 = aocData.OPERATIONTYPE_CODE1;
            TRANSFER_FL1 = aocData.TRANSFER_FL1;
            TRANSFER_FL2 = aocData.TRANSFER_FL2;
            TRANSFER_FL3 = aocData.TRANSFER_FL3;
            TRANSFER_FL4 = aocData.TRANSFER_FL4;
            TRANSFER_FL5 = aocData.TRANSFER_FL5;
            TRANSFER_FL6 = aocData.TRANSFER_FL6;
            TRANSFER_FL7 = aocData.TRANSFER_FL7;
            TRANSFER_FL8 = aocData.TRANSFER_FL8;
            TRANSFER_FL9 = aocData.TRANSFER_FL9;
            TRANSFER_FL10 = aocData.TRANSFER_FL10;
            TRANSFER_FL11 = aocData.TRANSFER_FL11;
            TRANSFER_FL12 = aocData.TRANSFER_FL12;
            TRANSFER_FL13 = aocData.TRANSFER_FL13;
            TRANSFER_FL14 = aocData.TRANSFER_FL14;
            TRANSFER_FL15 = aocData.TRANSFER_FL15;
            TRANSFER_FL16 = aocData.TRANSFER_FL16;
            TRANSFER_FL17 = aocData.TRANSFER_FL17;
            TRANSFER_FL18 = aocData.TRANSFER_FL18;
            TRANSFER_FL19 = aocData.TRANSFER_FL19;
            TRANSFER_FL20 = aocData.TRANSFER_FL20;
            SHAREFL_FLT1 = aocData.SHAREFL_FLT1;
            SHAREFL_FLN1 = aocData.SHAREFL_FLN1;
            SHAREFL_FLT2 = aocData.SHAREFL_FLT2;
            SHAREFL_FLN2 = aocData.SHAREFL_FLN2;
            SHAREFL_FLT3 = aocData.SHAREFL_FLT3;
            SHAREFL_FLN3 = aocData.SHAREFL_FLN3;
            SHAREFL_FLT4 = aocData.SHAREFL_FLT4;
            SHAREFL_FLN4 = aocData.SHAREFL_FLN4;
            SHAREFL_FLT5 = aocData.SHAREFL_FLT5;
            SHAREFL_FLN5 = aocData.SHAREFL_FLN5;
            SHAREFL_FLT6 = aocData.SHAREFL_FLT6;
            SHAREFL_FLN6 = aocData.SHAREFL_FLN6;
            TOTAL_BAGCOUNT = aocData.TOTAL_BAGCOUNT;
            TOTAL_BAGWEIGHT = aocData.TOTAL_BAGWEIGHT;
            TOTAL_FREIGHTWEIGHT = aocData.TOTAL_FREIGHTWEIGHT;
            TOTAL_MAILWEIGHT = aocData.TOTAL_MAILWEIGHT;
            TOTAL_LOADWEIGHT = aocData.TOTAL_LOADWEIGHT;
            ADULT_PAXCOUNT = aocData.ADULT_PAXCOUNT;
            BUSSINESS_PAXCOUNT = aocData.BUSSINESS_PAXCOUNT;
            CHILD_PAXCOUNT = aocData.CHILD_PAXCOUNT;
            DOMESITEC_PAXCOUNT = aocData.DOMESITEC_PAXCOUNT;
            INFANT_PAXCOUNT = aocData.INFANT_PAXCOUNT;
            INTERNATIONAL_PAXCOUNT = aocData.INTERNATIONAL_PAXCOUNT;
            LOCAL_PAXCOUNT = aocData.LOCAL_PAXCOUNT;
            NONTRANSFER_PAXCOUNT = aocData.NONTRANSFER_PAXCOUNT;
            TOTAL_PAXCOUNT = aocData.TOTAL_PAXCOUNT;
            TRANSFER_PAXCOUNT = aocData.TRANSFER_PAXCOUNT;
            TRANSIT_PAXCOUNT = aocData.TRANSIT_PAXCOUNT;
            WHELLCHAIR_PAXCOUNT = aocData.WHELLCHAIR_PAXCOUNT;
            TOTAL_CREWCOUNT = aocData.TOTAL_CREWCOUNT;
            ECONOMY_PAXCOUNT = aocData.ECONOMY_PAXCOUNT;
            FIRSTCLASS_PAXCOUNT = aocData.FIRSTCLASS_PAXCOUNT;
            TRANSFER_BAGCOUNT = aocData.TRANSFER_BAGCOUNT;
            TRANSFER_BAGWEIGHT = aocData.TRANSFER_BAGWEIGHT;
            TRANSFER_FREIGHTWEIGHT = aocData.TRANSFER_FREIGHTWEIGHT;
            TRANSFER_MAILWEIGHT = aocData.TRANSFER_MAILWEIGHT;
            TRANSIT_BAGCOUNT = aocData.TRANSIT_BAGCOUNT;
            TRANSIT_BAGWEIGHT = aocData.TRANSIT_BAGWEIGHT;
            TRANSIT_FREIGHTWEIGHT = aocData.TRANSIT_FREIGHTWEIGHT;
            TRANSIT_MAILWEIGHT = aocData.TRANSIT_MAILWEIGHT;
            OFFBLOCK_TIME = aocData.OFFBLOCK_TIME;
            ONBLOCK_TIME = aocData.ONBLOCK_TIME;
            EDTA = aocData.EDTA;
            EDTD = aocData.EDTD;
            E_FL_DURATION = aocData.E_FL_DURATION;
            FIRSTBAG_TIME = aocData.FIRSTBAG_TIME;
            LASTBAG_TIME = aocData.LASTBAG_TIME;
            FINALAPPROACH_TIME = aocData.FINALAPPROACH_TIME;
            LASTKNOWN_TIME = aocData.LASTKNOWN_TIME;
            LASTKNOWN_SOURCE = aocData.LASTKNOWN_SOURCE;
            NEXT_INFO_TIME = aocData.NEXT_INFO_TIME;
            A_NEXT_STATION_TIME = aocData.A_NEXT_STATION_TIME;
            E_NEXT_STATION_TIME = aocData.E_NEXT_STATION_TIME;
            S_NEXT_STATION_TIME = aocData.S_NEXT_STATION_TIME;
            A_PREV_STATION_TIME = aocData.A_PREV_STATION_TIME;
            E_PREV_STATION_TIME = aocData.E_PREV_STATION_TIME;
            S_PREV_STATION_TIME = aocData.S_PREV_STATION_TIME;
            LAND = aocData.LAND;
            AIRB = aocData.AIRB;
            TEN_MILES_TIME = aocData.TEN_MILES_TIME;
            ORG3 = aocData.ORG3;
            DES3 = aocData.DES3;
            ORG_ICAO = aocData.ORG_ICAO;
            DES_ICAO = aocData.DES_ICAO;
            VIA1 = aocData.VIA1;
            VIA_ICAO = aocData.VIA_ICAO;
            PUBLIC_FLT = aocData.PUBLIC_FLT;
            PUBLIC_FLC = aocData.PUBLIC_FLC;
            PUBLIC_TIME = aocData.PUBLIC_TIME;
            SECURE_STAND_IS_REQUIRED = aocData.SECURE_STAND_IS_REQUIRED;
            STOD = aocData.STOD;
            STPO = aocData.STPO;
            OPERATIONTYPE_CODE2 = aocData.OPERATIONTYPE_CODE2;
            FIRSTBAG_TIME2 = aocData.FIRSTBAG_TIME2;
            LASTBAG_TIME2 = aocData.LASTBAG_TIME2;
            OPERATIONTYPE_ROLE1 = aocData.OPERATIONTYPE_ROLE1;
            OPERATIONTYPE_ROLE2 = aocData.OPERATIONTYPE_ROLE2;
            UPDATE_TIME = aocData.UPDATE_TIME;
            CUSTOM_STATUS = aocData.CUSTOM_STATUS;
            SUB_AIRLINE = aocData.SUB_AIRLINE;
            LTD = aocData.LTD;
            LTA = aocData.LTA;
            AIRLINE_TERMINAL = aocData.AIRLINE_TERMINAL;
            GATE_PLAN_CLOSE_TIME1 = aocData.GATE_PLAN_CLOSE_TIME1;
            GATE_PLAN_OPEN_TIME1 = aocData.GATE_PLAN_OPEN_TIME1;
            GATE_PLAN_CLOSE_TIME2 = aocData.GATE_PLAN_CLOSE_TIME2;
            GATE_PLAN_OPEN_TIME2 = aocData.GATE_PLAN_OPEN_TIME2;
            USEC = aocData.USEC;
            TYPC = aocData.TYPC;
            CDAT = aocData.CDAT;
            USEU = aocData.USEU;
            TYPU = aocData.TYPU;
            DateTime dtTemp;
            if (DateTime.TryParse(aocData.LSTU.ToString(), out dtTemp))
            {
                if (dtTemp == DateTime.MinValue)
                {
                    LSTU = DateTime.Now;
                }
                else
                {
                    LSTU = aocData.LSTU;
                }
            }
            else
            {
                LSTU = DateTime.Now;
            }
            JFNO = aocData.JFNO;
            CTRL = aocData.CTRL;
            DRCT = aocData.DRCT;
        }

        #region AOCFQSHIS COLUMNS

        //public string ID { set; get; }
        //public string URNO { set; get; }
        //public string CARRIER_IATA { set; get; }
        //public string CARRIER_ICAO { set; get; }
        //public string FL_NUMBER { set; get; }
        //public string FL_SUFFIX { set; get; }
        //public string MFDI { set; get; }
        //public string FLR { set; get; }
        //public string SDT { set; get; }
        //public string SDP { set; get; }
        //public string LINKEDFL_FLT { set; get; }
        //public string LINKEDFL_CARRIER { set; get; }
        //public string LINKEDFL_NUMBER { set; get; }
        //public string LINKEDFL_SUFFIX { set; get; }
        //public string LINKEDFL_SDT { set; get; }
        //public string LINKEDFL_FLR { set; get; }
        //public string LINKFL_ID { set; get; }
        //public string MASTERFL_CARRIER { set; get; }
        //public string MASTERFL_NUMBER { set; get; }
        //public string MASTERFL_SUFFIX { set; get; }
        //public string MASTERFL_FLT { set; get; }
        //public string MASTERFL_FLR { set; get; }
        //public string MASTERFL_ID { set; get; }
        //public string AIRCRAFT_CALLSIGN { set; get; }
        //public string AIRCRAFT_OWNER { set; get; }
        //public string AIRCRAFT_PAXCAP { set; get; }
        //public string REGN { set; get; }
        //public string ATC5 { set; get; }
        //public string AIRCRAFT_TYPE { set; get; }
        //public string AIRCRAFT_OPERATOR { set; get; }
        //public string AIRCRAFT_TERMINAL { set; get; }
        //public string AIRPORT_IATA { set; get; }
        //public string BRC1 { set; get; }
        //public string RECLAIM_ROLE1 { set; get; }
        //public string BROD { set; get; }
        //public string BRCD { set; get; }
        //public string EXITDOOR1 { set; get; }
        //public string SRC2 { set; get; }
        //public string RECLAIM_ROLE2 { set; get; }
        //public string SBRO { set; get; }
        //public string SBRC { set; get; }
        //public string EXITDOOR2 { set; get; }
        //public string MAKEUP_ID1 { set; get; }
        //public string MAKEUP_ROLE1 { set; get; }
        //public string MAKEUP_OPEN_TIME1 { set; get; }
        //public string MAKEUP_CLOSE_TIME1 { set; get; }
        //public string MAKEUP_ID2 { set; get; }
        //public string MAKEUP_ROLE2 { set; get; }
        //public string MAKEUP_OPEN_TIME2 { set; get; }
        //public string MAKEUP_CLOSE_TIME2 { set; get; }
        //public string ISBUSREQUIRED { set; get; }
        //public string CC_TYPE1 { set; get; }
        //public string CKIF { set; get; }
        //public string CC_ROLE1 { set; get; }
        //public string CC_CLUSTERID1 { set; get; }
        //public string CODT { set; get; }
        //public string CCDT { set; get; }
        //public string CC_TYPE2 { set; get; }
        //public string SCDR { set; get; }
        //public string CC_ROLE2 { set; get; }
        //public string CC_CLUSTERID2 { set; get; }
        //public string SCODT { set; get; }
        //public string SCCDT { set; get; }
        //public string SGCD { set; get; }
        //public string SGOD { set; get; }
        //public string GATE_BORDING_STATUS2 { set; get; }
        //public string GATE_ROLE2 { set; get; }
        //public string SGN { set; get; }
        //public string GCDT { set; get; }
        //public string GODT { set; get; }
        //public string GBS { set; get; }
        //public string GATE_ROLE1 { set; get; }
        //public string GENO { set; get; }
        //public string TERM { set; get; }
        //public string REMARK_CODE1 { set; get; }
        //public string REMARK_TYPE1 { set; get; }
        //public string REMARK_CODE2 { set; get; }
        //public string REMARK_TYPE2 { set; get; }
        //public string REMARK_CODE3 { set; get; }
        //public string REMARK_TYPE3 { set; get; }
        //public string REMARK_CODE4 { set; get; }
        //public string REMARK_TYPE4 { set; get; }
        //public string RUNWAY_ID { set; get; }
        //public string S_INFO_TYPE1 { set; get; }
        //public string S_INFO_TEXT1 { set; get; }
        //public string S_INFO_TYPE2 { set; get; }
        //public string S_INFO_TEXT2 { set; get; }
        //public string S_INFO_TYPE3 { set; get; }
        //public string S_INFO_TEXT3 { set; get; }
        //public string S_INFO_TYPE4 { set; get; }
        //public string S_INFO_TEXT4 { set; get; }
        //public string S_INFO_TYPE5 { set; get; }
        //public string S_INFO_TEXT5 { set; get; }
        //public string ACCOUNT_CODE { set; get; }
        //public string CODESHARE_STATUS { set; get; }
        //public string DEVERT_AIRPORT { set; get; }
        //public string CSS { set; get; }
        //public string DAIA { set; get; }
        //public string FL_NATURECODE { set; get; }
        //public string FL_OPERATES_OVERNIGHT { set; get; }
        //public string TTYP { set; get; }
        //public string FL_SERVICETYPE { set; get; }
        //public string FLTI { set; get; }
        //public string FL_TRANSITCODE { set; get; }
        //public string HANDLINGAGENT1 { set; get; }
        //public string HANDLING_SERVICE1 { set; get; }
        //public string HANDLINGAGENT2 { set; get; }
        //public string HANDLING_SERVICE2 { set; get; }
        //public string HANDLINGAGENT3 { set; get; }
        //public string HANDLING_SERVICE3 { set; get; }
        //public string HANDLINGAGENT4 { set; get; }
        //public string HANDLING_SERVICE4 { set; get; }
        //public string HANDLINGAGENT5 { set; get; }
        //public string HANDLING_SERVICE5 { set; get; }
        //public string IRR_NUMBER1 { set; get; }
        //public string IRR_CODE1 { set; get; }
        //public string IRR_DURATION1 { set; get; }
        //public string IRR_NUMBER2 { set; get; }
        //public string IRR_CODE2 { set; get; }
        //public string IRR_DURATION2 { set; get; }
        //public string ISGVF { set; get; }
        //public string ISRETURNFL { set; get; }
        //public string ISTRANSFERFL { set; get; }
        //public string NEWFL_REASON { set; get; }
        //public string OPERATIONTYPE_CODE1 { set; get; }
        //public string TRANSFER_FL1 { set; get; }
        //public string TRANSFER_FL2 { set; get; }
        //public string TRANSFER_FL3 { set; get; }
        //public string TRANSFER_FL4 { set; get; }
        //public string TRANSFER_FL5 { set; get; }
        //public string TRANSFER_FL6 { set; get; }
        //public string TRANSFER_FL7 { set; get; }
        //public string TRANSFER_FL8 { set; get; }
        //public string TRANSFER_FL9 { set; get; }
        //public string TRANSFER_FL10 { set; get; }
        //public string TRANSFER_FL11 { set; get; }
        //public string TRANSFER_FL12 { set; get; }
        //public string TRANSFER_FL13 { set; get; }
        //public string TRANSFER_FL14 { set; get; }
        //public string TRANSFER_FL15 { set; get; }
        //public string TRANSFER_FL16 { set; get; }
        //public string TRANSFER_FL17 { set; get; }
        //public string TRANSFER_FL18 { set; get; }
        //public string TRANSFER_FL19 { set; get; }
        //public string TRANSFER_FL20 { set; get; }
        //public string SHAREFL_FLT1 { set; get; }
        //public string SHAREFL_FLN1 { set; get; }
        //public string SHAREFL_FLT2 { set; get; }
        //public string SHAREFL_FLN2 { set; get; }
        //public string SHAREFL_FLT3 { set; get; }
        //public string SHAREFL_FLN3 { set; get; }
        //public string SHAREFL_FLT4 { set; get; }
        //public string SHAREFL_FLN4 { set; get; }
        //public string SHAREFL_FLT5 { set; get; }
        //public string SHAREFL_FLN5 { set; get; }
        //public string SHAREFL_FLT6 { set; get; }
        //public string SHAREFL_FLN6 { set; get; }
        //public string TOTAL_BAGCOUNT { set; get; }
        //public string TOTAL_BAGWEIGHT { set; get; }
        //public string TOTAL_FREIGHTWEIGHT { set; get; }
        //public string TOTAL_MAILWEIGHT { set; get; }
        //public string TOTAL_LOADWEIGHT { set; get; }
        //public string ADULT_PAXCOUNT { set; get; }
        //public string BUSSINESS_PAXCOUNT { set; get; }
        //public string CHILD_PAXCOUNT { set; get; }
        //public string DOMESITEC_PAXCOUNT { set; get; }
        //public string INFANT_PAXCOUNT { set; get; }
        //public string INTERNATIONAL_PAXCOUNT { set; get; }
        //public string LOCAL_PAXCOUNT { set; get; }
        //public string NONTRANSFER_PAXCOUNT { set; get; }
        //public string TOTAL_PAXCOUNT { set; get; }
        //public string TRANSFER_PAXCOUNT { set; get; }
        //public string TRANSIT_PAXCOUNT { set; get; }
        //public string WHELLCHAIR_PAXCOUNT { set; get; }
        //public string TOTAL_CREWCOUNT { set; get; }
        //public string ECONOMY_PAXCOUNT { set; get; }
        //public string FIRSTCLASS_PAXCOUNT { set; get; }
        //public string TRANSFER_BAGCOUNT { set; get; }
        //public string TRANSFER_BAGWEIGHT { set; get; }
        //public string TRANSFER_FREIGHTWEIGHT { set; get; }
        //public string TRANSFER_MAILWEIGHT { set; get; }
        //public string TRANSIT_BAGCOUNT { set; get; }
        //public string TRANSIT_BAGWEIGHT { set; get; }
        //public string TRANSIT_FREIGHTWEIGHT { set; get; }
        //public string TRANSIT_MAILWEIGHT { set; get; }
        //public string OFFBLOCK_TIME { set; get; }
        //public string ONBLOCK_TIME { set; get; }
        //public string EDTA { set; get; }
        //public string EDTD { set; get; }
        //public string E_FL_DURATION { set; get; }
        //public string FIRSTBAG_TIME { set; get; }
        //public string LASTBAG_TIME { set; get; }
        //public string FINALAPPROACH_TIME { set; get; }
        //public string LASTKNOWN_TIME { set; get; }
        //public string LASTKNOWN_SOURCE { set; get; }
        //public string NEXT_INFO_TIME { set; get; }
        //public string A_NEXT_STATION_TIME { set; get; }
        //public string E_NEXT_STATION_TIME { set; get; }
        //public string S_NEXT_STATION_TIME { set; get; }
        //public string A_PREV_STATION_TIME { set; get; }
        //public string E_PREV_STATION_TIME { set; get; }
        //public string S_PREV_STATION_TIME { set; get; }
        //public string LAND { set; get; }
        //public string AIRB { set; get; }
        //public string TEN_MILES_TIME { set; get; }
        //public string ORG3 { set; get; }
        //public string DES3 { set; get; }
        //public string ORG_ICAO { set; get; }
        //public string DES_ICAO { set; get; }
        //public string VIA1 { set; get; }
        //public string VIA_ICAO { set; get; }
        //public string PUBLIC_FLT { set; get; }
        //public string PUBLIC_FLC { set; get; }
        //public string PUBLIC_TIME { set; get; }
        //public string SECURE_STAND_IS_REQUIRED { set; get; }
        //public string STOD { set; get; }
        //public string STPO { set; get; }
        //public string OPERATIONTYPE_CODE2 { set; get; }
        //public string FIRSTBAG_TIME2 { set; get; }
        //public string LASTBAG_TIME2 { set; get; }
        //public string OPERATIONTYPE_ROLE1 { set; get; }
        //public string OPERATIONTYPE_ROLE2 { set; get; }
        //public string UPDATE_TIME { set; get; }
        //public string CUSTOM_STATUS { set; get; }
        //public string SUB_AIRLINE { set; get; }
        //public string LTD { set; get; }
        //public string LTA { set; get; }
        //public string AIRLINE_TERMINAL { set; get; }
        //public string GATE_PLAN_CLOSE_TIME1 { set; get; }
        //public string GATE_PLAN_OPEN_TIME1 { set; get; }
        //public string GATE_PLAN_CLOSE_TIME2 { set; get; }
        //public string GATE_PLAN_OPEN_TIME2 { set; get; }
        //public string USEC { set; get; }
        //public string TYPC { set; get; }
        //public DateTime CDAT { set; get; }
        //public string USEU { set; get; }
        //public string TYPU { set; get; }
        //public DateTime LSTU { set; get; }
        //public string JFNO { set; get; }
        //public int CTRL { set; get; }
        //public string DRCT { set; get; }

        private string id;
        private string urno;
        private string carrier_iata;
        private string carrier_icao;
        private string fl_number;
        private string fl_suffix;
        private string flt;
        private string flr;
        private string sdt;
        private string sdp;
        private string linkedfl_flt;
        private string linkedfl_carrier;
        private string linkedfl_number;
        private string linkedfl_suffix;
        private string linkedfl_sdt;
        private string linkedfl_flr;
        private string linkfl_id;
        private string masterfl_carrier;
        private string masterfl_number;
        private string masterfl_suffix;
        private string mfdi;
        private string masterfl_flr;
        private string masterfl_id;
        private string aircraft_callsign;
        private string aircraft_owner;
        private string aircraft_paxcap;
        private string regn;
        private string atc5;
        private string aircraft_type;
        private string aircraft_operator;
        private string aircraft_terminal;
        private string airport_iata;
        private string brc1;
        private string reclaim_role1;
        private string brod;
        private string brcd;
        private string exitdoor1;
        private string src2;
        private string reclaim_role2;
        private string sbro;
        private string sbrc;
        private string exitdoor2;
        private string makeup_id1;
        private string makeup_role1;
        private string makeup_open_time1;
        private string makeup_close_time1;
        private string makeup_id2;
        private string makeup_role2;
        private string makeup_open_time2;
        private string makeup_close_time2;
        private string isbusrequired;
        private string cc_type1;
        private string ckif;
        private string cc_role1;
        private string cc_clusterid1;
        private string codt;
        private string ccdt;
        private string cc_type2;
        private string scdr;
        private string cc_role2;
        private string cc_clusterid2;
        private string scodt;
        private string sccdt;
        private string sgcd;
        private string sgod;
        private string gate_bording_status2;
        private string gate_role2;
        private string sgn;
        private string gcdt;
        private string godt;
        private string gbs;
        private string gate_role1;
        private string geno;
        private string term;
        private string remark_code1;
        private string remark_type1;
        private string remark_code2;
        private string remark_type2;
        private string remark_code3;
        private string remark_type3;
        private string remark_code4;
        private string remark_type4;
        private string runway_id;
        private string s_info_type1;
        private string s_info_text1;
        private string s_info_type2;
        private string s_info_text2;
        private string s_info_type3;
        private string s_info_text3;
        private string s_info_type4;
        private string s_info_text4;
        private string s_info_type5;
        private string s_info_text5;
        private string account_code;
        private string codeshare_status;
        private string devert_airport;
        private string css;
        private string daia;
        private string fl_naturecode;
        private string fl_operates_overnight;
        private string ttyp;
        private string fl_servicetype;
        private string flti;
        private string fl_transitcode;
        private string handlingagent1;
        private string handling_service1;
        private string handlingagent2;
        private string handling_service2;
        private string handlingagent3;
        private string handling_service3;
        private string handlingagent4;
        private string handling_service4;
        private string handlingagent5;
        private string handling_service5;
        private string irr_number1;
        private string irr_code1;
        private string irr_duration1;
        private string irr_number2;
        private string irr_code2;
        private string irr_duration2;
        private string isgvf;
        private string isreturnfl;
        private string istransferfl;
        private string newfl_reason;
        private string operationtype_code1;
        private string transfer_fl1;
        private string transfer_fl2;
        private string transfer_fl3;
        private string transfer_fl4;
        private string transfer_fl5;
        private string transfer_fl6;
        private string transfer_fl7;
        private string transfer_fl8;
        private string transfer_fl9;
        private string transfer_fl10;
        private string transfer_fl11;
        private string transfer_fl12;
        private string transfer_fl13;
        private string transfer_fl14;
        private string transfer_fl15;
        private string transfer_fl16;
        private string transfer_fl17;
        private string transfer_fl18;
        private string transfer_fl19;
        private string transfer_fl20;
        private string sharefl_flt1;
        private string sharefl_fln1;
        private string sharefl_flt2;
        private string sharefl_fln2;
        private string sharefl_flt3;
        private string sharefl_fln3;
        private string sharefl_flt4;
        private string sharefl_fln4;
        private string sharefl_flt5;
        private string sharefl_fln5;
        private string sharefl_flt6;
        private string sharefl_fln6;
        private string total_bagcount;
        private string total_bagweight;
        private string total_freightweight;
        private string total_mailweight;
        private string total_loadweight;
        private string adult_paxcount;
        private string bussiness_paxcount;
        private string child_paxcount;
        private string domesitec_paxcount;
        private string infant_paxcount;
        private string international_paxcount;
        private string local_paxcount;
        private string nontransfer_paxcount;
        private string total_paxcount;
        private string transfer_paxcount;
        private string transit_paxcount;
        private string whellchair_paxcount;
        private string total_crewcount;
        private string economy_paxcount;
        private string firstclass_paxcount;
        private string transfer_bagcount;
        private string transfer_bagweight;
        private string transfer_freightweight;
        private string transfer_mailweight;
        private string transit_bagcount;
        private string transit_bagweight;
        private string transit_freightweight;
        private string transit_mailweight;
        private string offblock_time;
        private string onblock_time;
        private string edta;
        private string edtd;
        private string e_fl_duration;
        private string firstbag_time;
        private string lastbag_time;
        private string finalapproach_time;
        private string lastknown_time;
        private string lastknown_source;
        private string next_info_time;
        private string a_next_station_time;
        private string e_next_station_time;
        private string s_next_station_time;
        private string a_prev_station_time;
        private string e_prev_station_time;
        private string s_prev_station_time;
        private string land;
        private string airb;
        private string ten_miles_time;
        private string org3;
        private string des3;
        private string org_icao;
        private string des_icao;
        private string via1;
        private string via_icao;
        private string public_flt;
        private string public_flc;
        private string public_time;
        private string secure_stand_is_required;
        private string stod;
        private string stpo;
        private string operationtype_code2;
        private string firstbag_time2;
        private string lastbag_time2;
        private string operationtype_role1;
        private string operationtype_role2;
        private string update_time;
        private string custom_status;
        private string sub_airline;
        private string ltd;
        private string lta;
        private string airline_terminal;
        private string gate_plan_close_time1;
        private string gate_plan_open_time1;
        private string gate_plan_close_time2;
        private string gate_plan_open_time2;
        private string usec;
        private string typc;
        private DateTime cdat;
        private string useu;
        private string typu;
        private DateTime lstu;
        private string jfno;
        private int ctrl;
        private string drct;
        private string fl_statuscode;
        private string fl_cancelcode;
        private string fl_classificationcode;

        public string ID
        {
            set { id = value; }
            get { return id; }
        }
        public string URNO
        {
            set { urno = value; }
            get { return urno; }
        }
        public string CARRIER_IATA
        {
            set { carrier_iata = value; }
            get { return carrier_iata; }
        }
        public string CARRIER_ICAO
        {
            set { carrier_icao = value; }
            get { return carrier_icao; }
        }
        public string FL_NUMBER
        {
            set { fl_number = value; }
            get { return fl_number; }
        }
        public string FL_SUFFIX
        {
            set { fl_suffix = value; }
            get { return fl_suffix; }
        }
        public string FLT
        {
            set { flt = value; }
            get { return flt; }
        }
        public string FLR
        {
            set { flr = value; }
            get { return flr; }
        }
        public string SDT
        {
            set { sdt = value; }
            get { return sdt; }
        }
        public string SDP
        {
            set { sdp = value; }
            get { return sdp; }
        }
        public string LINKEDFL_FLT
        {
            set { linkedfl_flt = value; }
            get { return linkedfl_flt; }
        }
        public string LINKEDFL_CARRIER
        {
            set { linkedfl_carrier = value; }
            get { return linkedfl_carrier; }
        }
        public string LINKEDFL_NUMBER
        {
            set { linkedfl_number = value; }
            get { return linkedfl_number; }
        }
        public string LINKEDFL_SUFFIX
        {
            set { linkedfl_suffix = value; }
            get { return linkedfl_suffix; }
        }
        public string LINKEDFL_SDT
        {
            set { linkedfl_sdt = value; }
            get { return linkedfl_sdt; }
        }
        public string LINKEDFL_FLR
        {
            set { linkedfl_flr = value; }
            get { return linkedfl_flr; }
        }
        public string LINKFL_ID
        {
            set { linkfl_id = value; }
            get { return linkfl_id; }
        }
        public string MASTERFL_CARRIER
        {
            set { masterfl_carrier = value; }
            get { return masterfl_carrier; }
        }
        public string MASTERFL_NUMBER
        {
            set { masterfl_number = value; }
            get { return masterfl_number; }
        }
        public string MASTERFL_SUFFIX
        {
            set { masterfl_suffix = value; }
            get { return masterfl_suffix; }
        }
        public string MFDI
        {
            set { mfdi = value; }
            get { return mfdi; }
        }
        public string MASTERFL_FLR
        {
            set { masterfl_flr = value; }
            get { return masterfl_flr; }
        }
        public string MASTERFL_ID
        {
            set { masterfl_id = value; }
            get { return masterfl_id; }
        }
        public string AIRCRAFT_CALLSIGN
        {
            set { aircraft_callsign = value; }
            get { return aircraft_callsign; }
        }
        public string AIRCRAFT_OWNER
        {
            set { aircraft_owner = value; }
            get { return aircraft_owner; }
        }
        public string AIRCRAFT_PAXCAP
        {
            set { aircraft_paxcap = value; }
            get { return aircraft_paxcap; }
        }
        public string REGN
        {
            set { regn = value; }
            get { return regn; }
        }
        public string ATC5
        {
            set { atc5 = value; }
            get { return atc5; }
        }
        public string AIRCRAFT_TYPE
        {
            set { aircraft_type = value; }
            get { return aircraft_type; }
        }
        public string AIRCRAFT_OPERATOR
        {
            set { aircraft_operator = value; }
            get { return aircraft_operator; }
        }
        public string AIRCRAFT_TERMINAL
        {
            set { aircraft_terminal = value; }
            get { return aircraft_terminal; }
        }
        public string AIRPORT_IATA
        {
            set { airport_iata = value; }
            get { return airport_iata; }
        }
        public string BRC1
        {
            set { brc1 = value; }
            get { return brc1; }
        }
        public string RECLAIM_ROLE1
        {
            set { reclaim_role1 = value; }
            get { return reclaim_role1; }
        }
        public string BROD
        {
            set { brod = value; }
            get { return brod; }
        }
        public string BRCD
        {
            set { brcd = value; }
            get { return brcd; }
        }
        public string EXITDOOR1
        {
            set { exitdoor1 = value; }
            get { return exitdoor1; }
        }
        public string SRC2
        {
            set { src2 = value; }
            get { return src2; }
        }
        public string RECLAIM_ROLE2
        {
            set { reclaim_role2 = value; }
            get { return reclaim_role2; }
        }
        public string SBRO
        {
            set { sbro = value; }
            get { return sbro; }
        }
        public string SBRC
        {
            set { sbrc = value; }
            get { return sbrc; }
        }
        public string EXITDOOR2
        {
            set { exitdoor2 = value; }
            get { return exitdoor2; }
        }
        public string MAKEUP_ID1
        {
            set { makeup_id1 = value; }
            get { return makeup_id1; }
        }
        public string MAKEUP_ROLE1
        {
            set { makeup_role1 = value; }
            get { return makeup_role1; }
        }
        public string MAKEUP_OPEN_TIME1
        {
            set { makeup_open_time1 = value; }
            get { return makeup_open_time1; }
        }
        public string MAKEUP_CLOSE_TIME1
        {
            set { makeup_close_time1 = value; }
            get { return makeup_close_time1; }
        }
        public string MAKEUP_ID2
        {
            set { makeup_id2 = value; }
            get { return makeup_id2; }
        }
        public string MAKEUP_ROLE2
        {
            set { makeup_role2 = value; }
            get { return makeup_role2; }
        }
        public string MAKEUP_OPEN_TIME2
        {
            set { makeup_open_time2 = value; }
            get { return makeup_open_time2; }
        }
        public string MAKEUP_CLOSE_TIME2
        {
            set { makeup_close_time2 = value; }
            get { return makeup_close_time2; }
        }
        public string ISBUSREQUIRED
        {
            set { isbusrequired = value; }
            get { return isbusrequired; }
        }
        public string CC_TYPE1
        {
            set { cc_type1 = value; }
            get { return cc_type1; }
        }
        public string CKIF
        {
            set { ckif = value; }
            get { return ckif; }
        }
        public string CC_ROLE1
        {
            set { cc_role1 = value; }
            get { return cc_role1; }
        }
        public string CC_CLUSTERID1
        {
            set { cc_clusterid1 = value; }
            get { return cc_clusterid1; }
        }
        public string CODT
        {
            set { codt = value; }
            get { return codt; }
        }
        public string CCDT
        {
            set { ccdt = value; }
            get { return ccdt; }
        }
        public string CC_TYPE2
        {
            set { cc_type2 = value; }
            get { return cc_type2; }
        }
        public string SCDR
        {
            set { scdr = value; }
            get { return scdr; }
        }
        public string CC_ROLE2
        {
            set { cc_role2 = value; }
            get { return cc_role2; }
        }
        public string CC_CLUSTERID2
        {
            set { cc_clusterid2 = value; }
            get { return cc_clusterid2; }
        }
        public string SCODT
        {
            set { scodt = value; }
            get { return scodt; }
        }
        public string SCCDT
        {
            set { sccdt = value; }
            get { return sccdt; }
        }
        public string SGCD
        {
            set { sgcd = value; }
            get { return sgcd; }
        }
        public string SGOD
        {
            set { sgod = value; }
            get { return sgod; }
        }
        public string GATE_BORDING_STATUS2
        {
            set { gate_bording_status2 = value; }
            get { return gate_bording_status2; }
        }
        public string GATE_ROLE2
        {
            set { gate_role2 = value; }
            get { return gate_role2; }
        }
        public string SGN
        {
            set { sgn = value; }
            get { return sgn; }
        }
        public string GCDT
        {
            set { gcdt = value; }
            get { return gcdt; }
        }
        public string GODT
        {
            set { godt = value; }
            get { return godt; }
        }
        public string GBS
        {
            set { gbs = value; }
            get { return gbs; }
        }
        public string GATE_ROLE1
        {
            set { gate_role1 = value; }
            get { return gate_role1; }
        }
        public string GENO
        {
            set { geno = value; }
            get { return geno; }
        }
        public string TERM
        {
            set { term = value; }
            get { return term; }
        }
        public string REMARK_CODE1
        {
            set { remark_code1 = value; }
            get { return remark_code1; }
        }
        public string REMARK_TYPE1
        {
            set { remark_type1 = value; }
            get { return remark_type1; }
        }
        public string REMARK_CODE2
        {
            set { remark_code2 = value; }
            get { return remark_code2; }
        }
        public string REMARK_TYPE2
        {
            set { remark_type2 = value; }
            get { return remark_type2; }
        }
        public string REMARK_CODE3
        {
            set { remark_code3 = value; }
            get { return remark_code3; }
        }
        public string REMARK_TYPE3
        {
            set { remark_type3 = value; }
            get { return remark_type3; }
        }
        public string REMARK_CODE4
        {
            set { remark_code4 = value; }
            get { return remark_code4; }
        }
        public string REMARK_TYPE4
        {
            set { remark_type4 = value; }
            get { return remark_type4; }
        }
        public string RUNWAY_ID
        {
            set { runway_id = value; }
            get { return runway_id; }
        }
        public string S_INFO_TYPE1
        {
            set { s_info_type1 = value; }
            get { return s_info_type1; }
        }
        public string S_INFO_TEXT1
        {
            set { s_info_text1 = value; }
            get { return s_info_text1; }
        }
        public string S_INFO_TYPE2
        {
            set { s_info_type2 = value; }
            get { return s_info_type2; }
        }
        public string S_INFO_TEXT2
        {
            set { s_info_text2 = value; }
            get { return s_info_text2; }
        }
        public string S_INFO_TYPE3
        {
            set { s_info_type3 = value; }
            get { return s_info_type3; }
        }
        public string S_INFO_TEXT3
        {
            set { s_info_text3 = value; }
            get { return s_info_text3; }
        }
        public string S_INFO_TYPE4
        {
            set { s_info_type4 = value; }
            get { return s_info_type4; }
        }
        public string S_INFO_TEXT4
        {
            set { s_info_text4 = value; }
            get { return s_info_text4; }
        }
        public string S_INFO_TYPE5
        {
            set { s_info_type5 = value; }
            get { return s_info_type5; }
        }
        public string S_INFO_TEXT5
        {
            set { s_info_text5 = value; }
            get { return s_info_text5; }
        }
        public string ACCOUNT_CODE
        {
            set { account_code = value; }
            get { return account_code; }
        }
        public string CODESHARE_STATUS
        {
            set { codeshare_status = value; }
            get { return codeshare_status; }
        }
        public string DEVERT_AIRPORT
        {
            set { devert_airport = value; }
            get { return devert_airport; }
        }
        public string CSS
        {
            set { css = value; }
            get { return css; }
        }
        public string DAIA
        {
            set { daia = value; }
            get { return daia; }
        }
        public string FL_NATURECODE
        {
            set { fl_naturecode = value; }
            get { return fl_naturecode; }
        }
        public string FL_OPERATES_OVERNIGHT
        {
            set { fl_operates_overnight = value; }
            get { return fl_operates_overnight; }
        }
        public string TTYP
        {
            set { ttyp = value; }
            get { return ttyp; }
        }
        public string FL_SERVICETYPE
        {
            set { fl_servicetype = value; }
            get { return fl_servicetype; }
        }
        public string FLTI
        {
            set { flti = value; }
            get { return flti; }
        }
        public string FL_TRANSITCODE
        {
            set { fl_transitcode = value; }
            get { return fl_transitcode; }
        }
        public string HANDLINGAGENT1
        {
            set { handlingagent1 = value; }
            get { return handlingagent1; }
        }
        public string HANDLING_SERVICE1
        {
            set { handling_service1 = value; }
            get { return handling_service1; }
        }
        public string HANDLINGAGENT2
        {
            set { handlingagent2 = value; }
            get { return handlingagent2; }
        }
        public string HANDLING_SERVICE2
        {
            set { handling_service2 = value; }
            get { return handling_service2; }
        }
        public string HANDLINGAGENT3
        {
            set { handlingagent3 = value; }
            get { return handlingagent3; }
        }
        public string HANDLING_SERVICE3
        {
            set { handling_service3 = value; }
            get { return handling_service3; }
        }
        public string HANDLINGAGENT4
        {
            set { handlingagent4 = value; }
            get { return handlingagent4; }
        }
        public string HANDLING_SERVICE4
        {
            set { handling_service4 = value; }
            get { return handling_service4; }
        }
        public string HANDLINGAGENT5
        {
            set { handlingagent5 = value; }
            get { return handlingagent5; }
        }
        public string HANDLING_SERVICE5
        {
            set { handling_service5 = value; }
            get { return handling_service5; }
        }
        public string IRR_NUMBER1
        {
            set { irr_number1 = value; }
            get { return irr_number1; }
        }
        public string IRR_CODE1
        {
            set { irr_code1 = value; }
            get { return irr_code1; }
        }
        public string IRR_DURATION1
        {
            set { irr_duration1 = value; }
            get { return irr_duration1; }
        }
        public string IRR_NUMBER2
        {
            set { irr_number2 = value; }
            get { return irr_number2; }
        }
        public string IRR_CODE2
        {
            set { irr_code2 = value; }
            get { return irr_code2; }
        }
        public string IRR_DURATION2
        {
            set { irr_duration2 = value; }
            get { return irr_duration2; }
        }
        public string ISGVF
        {
            set { isgvf = value; }
            get { return isgvf; }
        }
        public string ISRETURNFL
        {
            set { isreturnfl = value; }
            get { return isreturnfl; }
        }
        public string ISTRANSFERFL
        {
            set { istransferfl = value; }
            get { return istransferfl; }
        }
        public string NEWFL_REASON
        {
            set { newfl_reason = value; }
            get { return newfl_reason; }
        }
        public string OPERATIONTYPE_CODE1
        {
            set { operationtype_code1 = value; }
            get { return operationtype_code1; }
        }
        public string TRANSFER_FL1
        {
            set { transfer_fl1 = value; }
            get { return transfer_fl1; }
        }
        public string TRANSFER_FL2
        {
            set { transfer_fl2 = value; }
            get { return transfer_fl2; }
        }
        public string TRANSFER_FL3
        {
            set { transfer_fl3 = value; }
            get { return transfer_fl3; }
        }
        public string TRANSFER_FL4
        {
            set { transfer_fl4 = value; }
            get { return transfer_fl4; }
        }
        public string TRANSFER_FL5
        {
            set { transfer_fl5 = value; }
            get { return transfer_fl5; }
        }
        public string TRANSFER_FL6
        {
            set { transfer_fl6 = value; }
            get { return transfer_fl6; }
        }
        public string TRANSFER_FL7
        {
            set { transfer_fl7 = value; }
            get { return transfer_fl7; }
        }
        public string TRANSFER_FL8
        {
            set { transfer_fl8 = value; }
            get { return transfer_fl8; }
        }
        public string TRANSFER_FL9
        {
            set { transfer_fl9 = value; }
            get { return transfer_fl9; }
        }
        public string TRANSFER_FL10
        {
            set { transfer_fl10 = value; }
            get { return transfer_fl10; }
        }
        public string TRANSFER_FL11
        {
            set { transfer_fl11 = value; }
            get { return transfer_fl11; }
        }
        public string TRANSFER_FL12
        {
            set { transfer_fl12 = value; }
            get { return transfer_fl12; }
        }
        public string TRANSFER_FL13
        {
            set { transfer_fl13 = value; }
            get { return transfer_fl13; }
        }
        public string TRANSFER_FL14
        {
            set { transfer_fl14 = value; }
            get { return transfer_fl14; }
        }
        public string TRANSFER_FL15
        {
            set { transfer_fl15 = value; }
            get { return transfer_fl15; }
        }
        public string TRANSFER_FL16
        {
            set { transfer_fl16 = value; }
            get { return transfer_fl16; }
        }
        public string TRANSFER_FL17
        {
            set { transfer_fl17 = value; }
            get { return transfer_fl17; }
        }
        public string TRANSFER_FL18
        {
            set { transfer_fl18 = value; }
            get { return transfer_fl18; }
        }
        public string TRANSFER_FL19
        {
            set { transfer_fl19 = value; }
            get { return transfer_fl19; }
        }
        public string TRANSFER_FL20
        {
            set { transfer_fl20 = value; }
            get { return transfer_fl20; }
        }
        public string SHAREFL_FLT1
        {
            set { sharefl_flt1 = value; }
            get { return sharefl_flt1; }
        }
        public string SHAREFL_FLN1
        {
            set { sharefl_fln1 = value; }
            get { return sharefl_fln1; }
        }
        public string SHAREFL_FLT2
        {
            set { sharefl_flt2 = value; }
            get { return sharefl_flt2; }
        }
        public string SHAREFL_FLN2
        {
            set { sharefl_fln2 = value; }
            get { return sharefl_fln2; }
        }
        public string SHAREFL_FLT3
        {
            set { sharefl_flt3 = value; }
            get { return sharefl_flt3; }
        }
        public string SHAREFL_FLN3
        {
            set { sharefl_fln3 = value; }
            get { return sharefl_fln3; }
        }
        public string SHAREFL_FLT4
        {
            set { sharefl_flt4 = value; }
            get { return sharefl_flt4; }
        }
        public string SHAREFL_FLN4
        {
            set { sharefl_fln4 = value; }
            get { return sharefl_fln4; }
        }
        public string SHAREFL_FLT5
        {
            set { sharefl_flt5 = value; }
            get { return sharefl_flt5; }
        }
        public string SHAREFL_FLN5
        {
            set { sharefl_fln5 = value; }
            get { return sharefl_fln5; }
        }
        public string SHAREFL_FLT6
        {
            set { sharefl_flt6 = value; }
            get { return sharefl_flt6; }
        }
        public string SHAREFL_FLN6
        {
            set { sharefl_fln6 = value; }
            get { return sharefl_fln6; }
        }
        public string TOTAL_BAGCOUNT
        {
            set { total_bagcount = value; }
            get { return total_bagcount; }
        }
        public string TOTAL_BAGWEIGHT
        {
            set { total_bagweight = value; }
            get { return total_bagweight; }
        }
        public string TOTAL_FREIGHTWEIGHT
        {
            set { total_freightweight = value; }
            get { return total_freightweight; }
        }
        public string TOTAL_MAILWEIGHT
        {
            set { total_mailweight = value; }
            get { return total_mailweight; }
        }
        public string TOTAL_LOADWEIGHT
        {
            set { total_loadweight = value; }
            get { return total_loadweight; }
        }
        public string ADULT_PAXCOUNT
        {
            set { adult_paxcount = value; }
            get { return adult_paxcount; }
        }
        public string BUSSINESS_PAXCOUNT
        {
            set { bussiness_paxcount = value; }
            get { return bussiness_paxcount; }
        }
        public string CHILD_PAXCOUNT
        {
            set { child_paxcount = value; }
            get { return child_paxcount; }
        }
        public string DOMESITEC_PAXCOUNT
        {
            set { domesitec_paxcount = value; }
            get { return domesitec_paxcount; }
        }
        public string INFANT_PAXCOUNT
        {
            set { infant_paxcount = value; }
            get { return infant_paxcount; }
        }
        public string INTERNATIONAL_PAXCOUNT
        {
            set { international_paxcount = value; }
            get { return international_paxcount; }
        }
        public string LOCAL_PAXCOUNT
        {
            set { local_paxcount = value; }
            get { return local_paxcount; }
        }
        public string NONTRANSFER_PAXCOUNT
        {
            set { nontransfer_paxcount = value; }
            get { return nontransfer_paxcount; }
        }
        public string TOTAL_PAXCOUNT
        {
            set { total_paxcount = value; }
            get { return total_paxcount; }
        }
        public string TRANSFER_PAXCOUNT
        {
            set { transfer_paxcount = value; }
            get { return transfer_paxcount; }
        }
        public string TRANSIT_PAXCOUNT
        {
            set { transit_paxcount = value; }
            get { return transit_paxcount; }
        }
        public string WHELLCHAIR_PAXCOUNT
        {
            set { whellchair_paxcount = value; }
            get { return whellchair_paxcount; }
        }
        public string TOTAL_CREWCOUNT
        {
            set { total_crewcount = value; }
            get { return total_crewcount; }
        }
        public string ECONOMY_PAXCOUNT
        {
            set { economy_paxcount = value; }
            get { return economy_paxcount; }
        }
        public string FIRSTCLASS_PAXCOUNT
        {
            set { firstclass_paxcount = value; }
            get { return firstclass_paxcount; }
        }
        public string TRANSFER_BAGCOUNT
        {
            set { transfer_bagcount = value; }
            get { return transfer_bagcount; }
        }
        public string TRANSFER_BAGWEIGHT
        {
            set { transfer_bagweight = value; }
            get { return transfer_bagweight; }
        }
        public string TRANSFER_FREIGHTWEIGHT
        {
            set { transfer_freightweight = value; }
            get { return transfer_freightweight; }
        }
        public string TRANSFER_MAILWEIGHT
        {
            set { transfer_mailweight = value; }
            get { return transfer_mailweight; }
        }
        public string TRANSIT_BAGCOUNT
        {
            set { transit_bagcount = value; }
            get { return transit_bagcount; }
        }
        public string TRANSIT_BAGWEIGHT
        {
            set { transit_bagweight = value; }
            get { return transit_bagweight; }
        }
        public string TRANSIT_FREIGHTWEIGHT
        {
            set { transit_freightweight = value; }
            get { return transit_freightweight; }
        }
        public string TRANSIT_MAILWEIGHT
        {
            set { transit_mailweight = value; }
            get { return transit_mailweight; }
        }
        public string OFFBLOCK_TIME
        {
            set { offblock_time = value; }
            get { return offblock_time; }
        }
        public string ONBLOCK_TIME
        {
            set { onblock_time = value; }
            get { return onblock_time; }
        }
        public string EDTA
        {
            set { edta = value; }
            get { return edta; }
        }
        public string EDTD
        {
            set { edtd = value; }
            get { return edtd; }
        }
        public string E_FL_DURATION
        {
            set { e_fl_duration = value; }
            get { return e_fl_duration; }
        }
        public string FIRSTBAG_TIME
        {
            set { firstbag_time = value; }
            get { return firstbag_time; }
        }
        public string LASTBAG_TIME
        {
            set { lastbag_time = value; }
            get { return lastbag_time; }
        }
        public string FINALAPPROACH_TIME
        {
            set { finalapproach_time = value; }
            get { return finalapproach_time; }
        }
        public string LASTKNOWN_TIME
        {
            set { lastknown_time = value; }
            get { return lastknown_time; }
        }
        public string LASTKNOWN_SOURCE
        {
            set { lastknown_source = value; }
            get { return lastknown_source; }
        }
        public string NEXT_INFO_TIME
        {
            set { next_info_time = value; }
            get { return next_info_time; }
        }
        public string A_NEXT_STATION_TIME
        {
            set { a_next_station_time = value; }
            get { return a_next_station_time; }
        }
        public string E_NEXT_STATION_TIME
        {
            set { e_next_station_time = value; }
            get { return e_next_station_time; }
        }
        public string S_NEXT_STATION_TIME
        {
            set { s_next_station_time = value; }
            get { return s_next_station_time; }
        }
        public string A_PREV_STATION_TIME
        {
            set { a_prev_station_time = value; }
            get { return a_prev_station_time; }
        }
        public string E_PREV_STATION_TIME
        {
            set { e_prev_station_time = value; }
            get { return e_prev_station_time; }
        }
        public string S_PREV_STATION_TIME
        {
            set { s_prev_station_time = value; }
            get { return s_prev_station_time; }
        }
        public string LAND
        {
            set { land = value; }
            get { return land; }
        }
        public string AIRB
        {
            set { airb = value; }
            get { return airb; }
        }
        public string TEN_MILES_TIME
        {
            set { ten_miles_time = value; }
            get { return ten_miles_time; }
        }
        public string ORG3
        {
            set { org3 = value; }
            get { return org3; }
        }
        public string DES3
        {
            set { des3 = value; }
            get { return des3; }
        }
        public string ORG_ICAO
        {
            set { org_icao = value; }
            get { return org_icao; }
        }
        public string DES_ICAO
        {
            set { des_icao = value; }
            get { return des_icao; }
        }
        public string VIA1
        {
            set { via1 = value; }
            get { return via1; }
        }
        public string VIA_ICAO
        {
            set { via_icao = value; }
            get { return via_icao; }
        }
        public string PUBLIC_FLT
        {
            set { public_flt = value; }
            get { return public_flt; }
        }
        public string PUBLIC_FLC
        {
            set { public_flc = value; }
            get { return public_flc; }
        }
        public string PUBLIC_TIME
        {
            set { public_time = value; }
            get { return public_time; }
        }
        public string SECURE_STAND_IS_REQUIRED
        {
            set { secure_stand_is_required = value; }
            get { return secure_stand_is_required; }
        }
        public string STOD
        {
            set { stod = value; }
            get { return stod; }
        }
        public string STPO
        {
            set { stpo = value; }
            get { return stpo; }
        }
        public string OPERATIONTYPE_CODE2
        {
            set { operationtype_code2 = value; }
            get { return operationtype_code2; }
        }
        public string FIRSTBAG_TIME2
        {
            set { firstbag_time2 = value; }
            get { return firstbag_time2; }
        }
        public string LASTBAG_TIME2
        {
            set { lastbag_time2 = value; }
            get { return lastbag_time2; }
        }
        public string OPERATIONTYPE_ROLE1
        {
            set { operationtype_role1 = value; }
            get { return operationtype_role1; }
        }
        public string OPERATIONTYPE_ROLE2
        {
            set { operationtype_role2 = value; }
            get { return operationtype_role2; }
        }
        public string UPDATE_TIME
        {
            set { update_time = value; }
            get { return update_time; }
        }
        public string CUSTOM_STATUS
        {
            set { custom_status = value; }
            get { return custom_status; }
        }
        public string SUB_AIRLINE
        {
            set { sub_airline = value; }
            get { return sub_airline; }
        }
        public string LTD
        {
            set { ltd = value; }
            get { return ltd; }
        }
        public string LTA
        {
            set { lta = value; }
            get { return lta; }
        }
        public string AIRLINE_TERMINAL
        {
            set { airline_terminal = value; }
            get { return airline_terminal; }
        }
        public string GATE_PLAN_CLOSE_TIME1
        {
            set { gate_plan_close_time1 = value; }
            get { return gate_plan_close_time1; }
        }
        public string GATE_PLAN_OPEN_TIME1
        {
            set { gate_plan_open_time1 = value; }
            get { return gate_plan_open_time1; }
        }
        public string GATE_PLAN_CLOSE_TIME2
        {
            set { gate_plan_close_time2 = value; }
            get { return gate_plan_close_time2; }
        }
        public string GATE_PLAN_OPEN_TIME2
        {
            set { gate_plan_open_time2 = value; }
            get { return gate_plan_open_time2; }
        }
        public string USEC
        {
            set { usec = value; }
            get { return usec; }
        }
        public string TYPC
        {
            set { typc = value; }
            get { return typc; }
        }
        public DateTime CDAT
        {
            set { cdat = value; }
            get { return cdat; }
        }
        public string USEU
        {
            set { useu = value; }
            get { return useu; }
        }
        public string TYPU
        {
            set { typu = value; }
            get { return typu; }
        }
        public DateTime LSTU
        {
            set { lstu = value; }
            get { return lstu; }
        }
        public string JFNO
        {
            set { jfno = value; }
            get { return jfno; }
        }
        public int CTRL
        {
            set { ctrl = value; }
            get { return ctrl; }
        }
        public string DRCT
        {
            set { drct = value; }
            get { return drct; }
        }


        public string FL_STATUSCODE
        {
            set { fl_statuscode = value; }
            get { return fl_statuscode; }
        }
        public string FL_CANCELCODE
        {
            set { fl_cancelcode = value; }
            get { return fl_cancelcode; }
        }
        public string FL_CLASSIFICATIONCODE
        {
            set { fl_classificationcode = value; }
            get { return fl_classificationcode; }
        }
        #endregion

    }
}
