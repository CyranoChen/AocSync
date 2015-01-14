using System;
using System.Collections.Generic;
using System.Text;
using AOCSync.Entity.AOCEnum;
using System.Reflection;
using System.Collections;
namespace AOCSync.Entity
{
    public class AOCCONBINE
    {
        private static Hashtable showName = InitHashtable();

        public static Hashtable InitHashtable()
        {
            Hashtable tmphas = new Hashtable();
            tmphas["URNO"] = "URNO";
            tmphas["CARRIER_IATA"] = "CIATA";
            tmphas["CARRIER_ICAO"] = "CICAO";
            tmphas["FL_NUMBER"] = "FLNUM";
            tmphas["FL_SUFFIX"] = "FLSU";
            tmphas["MFDI"] = "MFDI";
            tmphas["FLR"] = "FLR";
            tmphas["SDT"] = "SDT";
            tmphas["SDP"] = "SDP";
            tmphas["LINKEDFL_FLT"] = "LNKFL";
            tmphas["LINKEDFL_CARRIER"] = "LNKCR";
            tmphas["LINKEDFL_NUMBER"] = "LNKNUM";
            tmphas["LINKEDFL_SUFFIX"] = "LNKSU";
            tmphas["LINKEDFL_SDT"] = "LNKSDT";
            tmphas["LINKEDFL_FLR"] = "LNKFLR";
            tmphas["LINKFL_ID"] = "LNKID";
            tmphas["MASTERFL_CARRIER"] = "MTFLCA";
            tmphas["MASTERFL_NUMBER"] = "MTFLNUM";
            tmphas["MASTERFL_SUFFIX"] = "MTFLSU";
            tmphas["MASTERFL_FLT"] = "MTFLT";
            tmphas["MASTERFL_FLR"] = "MTFLR";
            tmphas["MASTERFL_ID"] = "MTFLID";
            tmphas["AIRCRAFT_CALLSIGN"] = "ACCS";
            tmphas["AIRCRAFT_OWNER"] = "ACOW";
            tmphas["AIRCRAFT_PAXCAP"] = "ACPC";
            tmphas["ATC5"] = "ATC5";
            tmphas["AIRCRAFT_TYPE"] = "ACTP";
            tmphas["AIRCRAFT_OPERATOR"] = "ACOT";
            tmphas["AIRCRAFT_TERMINAL"] = "ACTM";
            tmphas["AIRPORT_IATA"] = "AIATA";
            tmphas["BRC1"] = "BRC1";
            tmphas["RECLAIM_ROLE1"] = "RERO1";
            tmphas["BROD"] = "BROD";
            tmphas["BRCD"] = "BRCD";
            tmphas["EXITDOOR1"] = "EXITD1";
            tmphas["SRC2"] = "SRC2";
            tmphas["RECLAIM_ROLE2"] = "RERO2";
            tmphas["SBRO"] = "SBRO";
            tmphas["SBRC"] = "SBRC";
            tmphas["EXITDOOR2"] = "EXITD2";
            tmphas["MAKEUP_ID1"] = "MKID1";
            tmphas["MAKEUP_ROLE1"] = "MKRO1";
            tmphas["MAKEUP_OPEN_TIME1"] = "MKOT1";
            tmphas["MAKEUP_CLOSE_TIME1"] = "MKCT1";
            tmphas["MAKEUP_ID2"] = "MKID2";
            tmphas["MAKEUP_ROLE2"] = "MKRO2";
            tmphas["MAKEUP_OPEN_TIME2"] = "MKOT2";
            tmphas["MAKEUP_CLOSE_TIME2"] = "MKCT2";
            tmphas["ISBUSREQUIRED"] = "ISBQ";
            tmphas["CC_TYPE1"] = "CCTY1";
            tmphas["CKIF"] = "CKIF";
            tmphas["CC_ROLE1"] = "CCRO1";
            tmphas["CC_CLUSTERID1"] = "CCCID1";
            tmphas["CODT"] = "CODT";
            tmphas["CCDT"] = "CCDT";
            tmphas["CC_TYPE2"] = "CCTY2";
            tmphas["SCDR"] = "SCDR";
            tmphas["CC_ROLE2"] = "CCRO2";
            tmphas["CC_CLUSTERID2"] = "CCCID2";
            tmphas["SCODT"] = "SCODT";
            tmphas["SCCDT"] = "SCCDT";
            tmphas["SGCD"] = "SGCD";
            tmphas["SGOD"] = "SGOD";
            tmphas["GATE_BORDING_STATUS2"] = "GATBS2";
            tmphas["GATE_ROLE2"] = "GATRO2";
            tmphas["SGN"] = "SGN";
            tmphas["GCDT"] = "GCDT";
            tmphas["GODT"] = "GODT";
            tmphas["GBS"] = "GBS";
            tmphas["GATE_ROLE1"] = "GATRO1";
            tmphas["GENO"] = "GENO";
            tmphas["REMARK_CODE1"] = "RMKCD1";
            tmphas["REMARK_TYPE1"] = "RMKP1";
            tmphas["REMARK_CODE2"] = "RMKCD2";
            tmphas["REMARK_TYPE2"] = "RMKP2";
            tmphas["REMARK_CODE3"] = "RMKCD3";
            tmphas["REMARK_TYPE3"] = "RMKP3";
            tmphas["REMARK_CODE4"] = "RMKCD4";
            tmphas["REMARK_TYPE4"] = "RMKP4";
            tmphas["RUNWAY_ID"] = "RWID";
            tmphas["S_INFO_TYPE1"] = "SITP1";
            tmphas["S_INFO_TEXT1"] = "SITX1";
            tmphas["S_INFO_TYPE2"] = "SITP2";
            tmphas["S_INFO_TEXT2"] = "SITX2";
            tmphas["S_INFO_TYPE3"] = "SITP3";
            tmphas["S_INFO_TEXT3"] = "SITX3";
            tmphas["S_INFO_TYPE4"] = "SITP4";
            tmphas["S_INFO_TEXT4"] = "SITX4";
            tmphas["S_INFO_TYPE5"] = "SITP5";
            tmphas["S_INFO_TEXT5"] = "SITX5";
            tmphas["ACCOUNT_CODE"] = "ACCD";
            tmphas["CSS"] = "CSS";
            tmphas["DAIA"] = "DAIA";
            tmphas["FL_OPERATES_OVERNIGHT"] = "FLOPON";
            tmphas["TTYP"] = "TTYP";
            tmphas["FL_SERVICETYPE"] = "FLSVTP";
            tmphas["FLTI"] = "FLTI";
            tmphas["FL_TRANSITCODE"] = "FLTSCD";
            tmphas["HANDLINGAGENT1"] = "HDGT1";
            tmphas["HANDLING_SERVICE1"] = "HDSV1";
            tmphas["HANDLINGAGENT2"] = "HDGT2";
            tmphas["HANDLING_SERVICE2"] = "HDSV2";
            tmphas["HANDLINGAGENT3"] = "HDGT3";
            tmphas["HANDLING_SERVICE3"] = "HDSV3";
            tmphas["HANDLINGAGENT4"] = "HDGT4";
            tmphas["HANDLING_SERVICE4"] = "HDSV4";
            tmphas["HANDLINGAGENT5"] = "HDGT5";
            tmphas["HANDLING_SERVICE5"] = "HDSV5";
            tmphas["IRR_NUMBER1"] = "IRRNUM1";
            tmphas["IRR_CODE1"] = "IRRCD1";
            tmphas["IRR_DURATION1"] = "IRRDT1";
            tmphas["IRR_NUMBER2"] = "IRRNUM2";
            tmphas["IRR_CODE2"] = "IRRCD2";
            tmphas["IRR_DURATION2"] = "IRRDT2";
            tmphas["ISGVF"] = "ISGVF";
            tmphas["ISRETURNFL"] = "ISRTF";
            tmphas["ISTRANSFERFL"] = "ISTSF";
            tmphas["NEWFL_REASON"] = "NFRS";
            tmphas["OPERATIONTYPE_CODE1"] = "OPCD1";
            tmphas["TRANSFER_FL1"] = "TSFL1";
            tmphas["TRANSFER_FL2"] = "TSFL2";
            tmphas["TRANSFER_FL3"] = "TSFL3";
            tmphas["TRANSFER_FL4"] = "TSFL4";
            tmphas["TRANSFER_FL5"] = "TSFL5";
            tmphas["TRANSFER_FL6"] = "TSFL6";
            tmphas["TRANSFER_FL7"] = "TSFL7";
            tmphas["TRANSFER_FL8"] = "TSFL8";
            tmphas["TRANSFER_FL9"] = "TSFL9";
            tmphas["TRANSFER_FL10"] = "TSFL10";
            tmphas["TRANSFER_FL11"] = "TSFL11";
            tmphas["TRANSFER_FL12"] = "TSFL12";
            tmphas["TRANSFER_FL13"] = "TSFL13";
            tmphas["TRANSFER_FL14"] = "TSFL14";
            tmphas["TRANSFER_FL15"] = "TSFL15";
            tmphas["TRANSFER_FL16"] = "TSFL16";
            tmphas["TRANSFER_FL17"] = "TSFL17";
            tmphas["TRANSFER_FL18"] = "TSFL18";
            tmphas["TRANSFER_FL19"] = "TSFL19";
            tmphas["TRANSFER_FL20"] = "TSFL20";
            tmphas["SHAREFL_FLT1"] = "SHRFL1";
            tmphas["SHAREFL_FLN1"] = "SHRFN1";
            tmphas["SHAREFL_FLT2"] = "SHRFL2";
            tmphas["SHAREFL_FLN2"] = "SHRFN2";
            tmphas["SHAREFL_FLT3"] = "SHRFL3";
            tmphas["SHAREFL_FLN3"] = "SHRFN3";
            tmphas["SHAREFL_FLT4"] = "SHRFL4";
            tmphas["SHAREFL_FLN4"] = "SHRFN4";
            tmphas["SHAREFL_FLT5"] = "SHRFL5";
            tmphas["SHAREFL_FLN5"] = "SHRFN5";
            tmphas["SHAREFL_FLT6"] = "SHRFL6";
            tmphas["SHAREFL_FLN6"] = "SHRFN6";
            tmphas["TOTAL_BAGCOUNT"] = "TTBCT";
            tmphas["TOTAL_BAGWEIGHT"] = "TTBWT";
            tmphas["TOTAL_FREIGHTWEIGHT"] = "TTFWT";
            tmphas["TOTAL_MAILWEIGHT"] = "TTMWT";
            tmphas["TOTAL_LOADWEIGHT"] = "TLW";
            tmphas["ADULT_PAXCOUNT"] = "APCT";
            tmphas["BUSSINESS_PAXCOUNT"] = "BPCT";
            tmphas["CHILD_PAXCOUNT"] = "CPCT";
            tmphas["DOMESITEC_PAXCOUNT"] = "DPCT";
            tmphas["INFANT_PAXCOUNT"] = "IPCT";
            tmphas["INTERNATIONAL_PAXCOUNT"] = "ITPCT";
            tmphas["LOCAL_PAXCOUNT"] = "LCPCT";
            tmphas["NONTRANSFER_PAXCOUNT"] = "NTSPCT";
            tmphas["TOTAL_PAXCOUNT"] = "TTPCT";
            tmphas["TRANSFER_PAXCOUNT"] = "TSPCT";
            tmphas["TRANSIT_PAXCOUNT"] = "TSTPCT";
            tmphas["WHELLCHAIR_PAXCOUNT"] = "WCPCT";
            tmphas["TOTAL_CREWCOUNT"] = "TTCCT";
            tmphas["ECONOMY_PAXCOUNT"] = "EPCT";
            tmphas["FIRSTCLASS_PAXCOUNT"] = "FCPCT";
            tmphas["TRANSFER_BAGCOUNT"] = "TSBCT";
            tmphas["TRANSFER_BAGWEIGHT"] = "TSBWT";
            tmphas["TRANSFER_FREIGHTWEIGHT"] = "TSFWT";
            tmphas["TRANSFER_MAILWEIGHT"] = "TSMWT";
            tmphas["TRANSIT_BAGCOUNT"] = "TSTBCT";
            tmphas["TRANSIT_BAGWEIGHT"] = "TSTBWT";
            tmphas["TRANSIT_FREIGHTWEIGHT"] = "TSTFWT";
            tmphas["TRANSIT_MAILWEIGHT"] = "TSTMWT";
            tmphas["OFFBLOCK_TIME"] = "OFBT";
            tmphas["ONBLOCK_TIME"] = "ONBT";
            tmphas["EDTA"] = "EDTA";
            tmphas["EDTD"] = "EDTD";
            tmphas["E_FL_DURATION"] = "EFLDT";
            tmphas["FIRSTBAG_TIME"] = "FBGT";
            tmphas["LASTBAG_TIME"] = "LBGT";
            tmphas["FINALAPPROACH_TIME"] = "FAT";
            tmphas["LASTKNOWN_TIME"] = "LKT";
            tmphas["LASTKNOWN_SOURCE"] = "LKS";
            tmphas["NEXT_INFO_TIME"] = "NIFT";
            tmphas["A_NEXT_STATION_TIME"] = "ANST";
            tmphas["E_NEXT_STATION_TIME"] = "ENST";
            tmphas["S_NEXT_STATION_TIME"] = "SNST";
            tmphas["A_PREV_STATION_TIME"] = "APST";
            tmphas["E_PREV_STATION_TIME"] = "EPST";
            tmphas["S_PREV_STATION_TIME"] = "SPST";
            tmphas["LAND"] = "LAND";
            tmphas["AIRB"] = "AIRB";
            tmphas["TEN_MILES_TIME"] = "TMT";
            tmphas["ORG3"] = "ORG3";
            tmphas["DES3"] = "DES3";
            tmphas["ORG_ICAO"] = "OICAO";
            tmphas["DES_ICAO"] = "DICAO";
            tmphas["VIA1"] = "VIA1";
            tmphas["VIA_ICAO"] = "VICAO";
            tmphas["PUBLIC_FLT"] = "PFLT";
            tmphas["PUBLIC_FLC"] = "PFLC";
            tmphas["PUBLIC_TIME"] = "PUBT";
            tmphas["SECURE_STAND_IS_REQUIRED"] = "SSIRQ";
            tmphas["STOD"] = "STOD";
            tmphas["STOA"] = "STOA";
            tmphas["STPO"] = "STPO";
            tmphas["OPERATIONTYPE_CODE2"] = "OPCD2";
            tmphas["FIRSTBAG_TIME2"] = "FBGT2";
            tmphas["LASTBAG_TIME2"] = "LBGT2";
            tmphas["OPERATIONTYPE_ROLE1"] = "OPRO1";
            tmphas["OPERATIONTYPE_ROLE2"] = "OPRO2";
            tmphas["UPDATE_TIME"] = "UPT";
            tmphas["CUSTOM_STATUS"] = "CTST";
            tmphas["SUB_AIRLINE"] = "SUBAL";
            tmphas["LTD"] = "LTD";
            tmphas["LTA"] = "LTA";
            tmphas["AIRLINE_TERMINAL"] = "ATERM";
            tmphas["GATE_PLAN_CLOSE_TIME1"] = "GPCT1";
            tmphas["GATE_PLAN_OPEN_TIME1"] = "GPOT1";
            tmphas["GATE_PLAN_CLOSE_TIME2"] = "GPCT2";
            tmphas["GATE_PLAN_OPEN_TIME2"] = "GPOT2";
            tmphas["JFNO"] = "JFNO";
            tmphas["CTRL"] = "CTRL";
            tmphas["DRCT"] = "DRCT";
            tmphas["APTIATA"] = "APTIATA";
            tmphas["ASIA"] = "ASIA";
            tmphas["CDR"] = "CDR";
            tmphas["GN"] = "GN";
            tmphas["POCC"] = "POCC";
            tmphas["REGN"] = "REGN";
            tmphas["TERM"] = "TERM";
            tmphas["SP"] = "SP";
            tmphas["ADID"] = "ADID";
            tmphas["FLNO"] = "FLNO";
            tmphas["REMP"] = "REMP";
            tmphas["CKIT"] = "CKIT";
            tmphas["FL_STATUSCODE"] = "FLSC";
            tmphas["FL_CANCELCODE"] = "FLCC";
            tmphas["FL_CLASSIFICATIONCODE"] = "FLCCC";
            tmphas["ACTUALOFFBLOCKSDATETIME"] = "AOFBT";
            tmphas["ACTUALONBLOCKSDATETIME"] = "AONBT";
            tmphas["AIRCRAFTTERMINALCODE"] = "ATTC";
            tmphas["BAGGAGERECLAIMCAROUSELROLE"] = "BECRO";
            tmphas["OCCURDATETIME"] = "OCCT";
            tmphas["SDBAGRECLAIMCAROUSELROLE"] = "SBECRO";
            tmphas["SDFIRSTBAGDATETIME"] = "SFBGT";
            tmphas["SDLASTBAGDATETIME"] = "SLBGT";
            tmphas["SUPPLEMENTARYINFORMATION"] = "SMIF";
            tmphas["SUPPLEMENTARYINFORMATIONTEXT"] = "SMIFT";
            tmphas["FLIGHTFLAG"] = "FLFLG";
            tmphas["FLIGHTREPEATCOUNT"] = "FLRPCT";
            tmphas["ISGENERALAVIATIONFLIGHT"] = "ISGLAFL";
            tmphas["TRANSFERFLIGHTIDENTITY"] = "TSFLIT";
            return tmphas;
        }
        public static string ShowName(string name)
        {
            return showName[name].ToString();
        }
        public AOCCONBINE() 
        {
            InitHashtable();
        }
        private static AOCCONBINE CONBINEAOCDataCC(AOCDataCC aocDataCC)
        {
            AOCCONBINE a = new AOCCONBINE();
            if (aocDataCC.DRCT.CompareTo("D")==0)
            {
                a.STOD = aocDataCC.STOD;
                a.STOA = string.Empty;
            } 
            else
            {
                a.STOA = aocDataCC.STOD;
                a.STOD = string.Empty;
            }
            
            a.TTYP = aocDataCC.TTYP;
            a.URNO = aocDataCC.URNO;
            a.ORG3 = aocDataCC.ORG3;
            a.DES3 = aocDataCC.DES3;
            a.LAND = aocDataCC.LAND;
            a.AIRB = aocDataCC.AIRB;
            a.ATC5 = aocDataCC.ATC5;
            a.VIA1 = aocDataCC.VIA1;
            a.JFNO = aocDataCC.JFNO;
            a.CKIF = aocDataCC.CKIF;
            a.FLTI = aocDataCC.FLTI;
            a.TERM = aocDataCC.TERM;
            a.STPO = aocDataCC.STPO;
            a.GENO = aocDataCC.GENO;
            a.DAIA = aocDataCC.DAIA;
            a.CSS = aocDataCC.CSS;
            a.EDTA = aocDataCC.EDTA;
            a.EDTD = aocDataCC.EDTD;
            a.SP = aocDataCC.SP;
            a.CDR = aocDataCC.CDR;
            a.CODT = aocDataCC.CODT;
            a.CCDT = aocDataCC.CCDT;
            a.SCDR = aocDataCC.SCDR;
            a.SCODT = aocDataCC.SCODT;
            a.SCCDT = aocDataCC.SCCDT;
            a.BRC1 = aocDataCC.BRC1;
            a.BROD = aocDataCC.BROD;
            a.BRCD = aocDataCC.BRCD;
            a.SRC2 = aocDataCC.SRC2;
            a.SBRO = aocDataCC.SBRO;
            a.SBRC = aocDataCC.SBRC;
            a.GN = aocDataCC.GN;
            a.GBS = aocDataCC.GBS;
            a.GODT = aocDataCC.GODT;
            a.GCDT = aocDataCC.GCDT;
            a.SGN = aocDataCC.SGN;
            a.SGOD = aocDataCC.SGOD;
            a.POCC = aocDataCC.POCC;
            a.SGCD = aocDataCC.SGCD;
            a.ASIA = aocDataCC.ASIA;
            a.APTIATA = aocDataCC.APTIATA;
            a.REGN = aocDataCC.REGN;
            a.DRCT = aocDataCC.DRCT;
            //补全CC的字段
            a.ACTUALOFFBLOCKSDATETIME = aocDataCC.ACTUALOFFBLOCKSDATETIME;
            a.ACTUALONBLOCKSDATETIME = aocDataCC.ACTUALONBLOCKSDATETIME;
            a.AIRCRAFTTERMINALCODE = aocDataCC.AIRCRAFTTERMINALCODE;
            a.BAGGAGERECLAIMCAROUSELROLE = aocDataCC.BAGGAGERECLAIMCAROUSELROLE;
            a.E_FL_DURATION = aocDataCC.ESTIMATEDFLIGHTDURATION;
            a.FIRSTBAG_TIME = aocDataCC.FIRSTBAGDATETIME;
            a.LASTBAG_TIME = aocDataCC.LASTBAGDATETIME;
            a.LASTKNOWN_TIME = aocDataCC.LATESTKNOWNDATETIME;
            a.LASTKNOWN_SOURCE = aocDataCC.LATESTKNOWNDATETIMESOURCE;
            a.A_NEXT_STATION_TIME = aocDataCC.NEXTSTATIONACTUALDATETIME;
            a.E_NEXT_STATION_TIME = aocDataCC.NEXTSTATIONESTIMATEDDATETIME;
            a.S_NEXT_STATION_TIME = aocDataCC.NEXTSTATIONSCHEDULEDDATETIME;
            a.OCCURDATETIME = aocDataCC.OCCURDATETIME;
            a.A_PREV_STATION_TIME = aocDataCC.PREVIOUSAIRBORNEDATETIME;
            a.E_PREV_STATION_TIME = aocDataCC.PREVIOUSESTIMATEDDATETIME;
            a.S_PREV_STATION_TIME = aocDataCC.PREVIOUSSCHEDULEDDATETIME;
            a.SDT = aocDataCC.SCHEDULEDDATE;
            a.SDBAGRECLAIMCAROUSELROLE = aocDataCC.SDBAGRECLAIMCAROUSELROLE;
            a.SDFIRSTBAGDATETIME = aocDataCC.SDFIRSTBAGDATETIME;
            a.SDLASTBAGDATETIME = aocDataCC.SDLASTBAGDATETIME;
            a.SUPPLEMENTARYINFORMATION = aocDataCC.SUPPLEMENTARYINFORMATION;
            a.SUPPLEMENTARYINFORMATIONTEXT = aocDataCC.SUPPLEMENTARYINFORMATIONTEXT;
            a.CARRIER_IATA = aocDataCC.CARRIERIATACODE;
            a.CARRIER_ICAO = aocDataCC.CARRIERICAOCODE;
            a.FL_CANCELCODE = aocDataCC.FLIGHTCANCELCODE;
            a.FLIGHTFLAG = aocDataCC.FLIGHTFLAG;
            a.FL_NUMBER = aocDataCC.FLIGHTNUMBER;
            a.FLIGHTREPEATCOUNT = aocDataCC.FLIGHTREPEATCOUNT;
            a.FL_SERVICETYPE = aocDataCC.FLIGHTSERVICETYPEIATACODE;
            a.FL_STATUSCODE = aocDataCC.FLIGHTSTATUSCODE;
            a.FL_SUFFIX = aocDataCC.FLIGHTSUFFIX;
            a.FL_TRANSITCODE = aocDataCC.FLIGHTTRANSITCODE;
            a.ISGENERALAVIATIONFLIGHT = aocDataCC.ISGENERALAVIATIONFLIGHT;
            a.ISRETURNFL = aocDataCC.ISRETURNFLIGHT;
            a.NEWFL_REASON = aocDataCC.NEWFLIGHTREASON;
            a.TRANSFERFLIGHTIDENTITY = aocDataCC.TRANSFERFLIGHTIDENTITY;
            //补全CC的字段

            a.A_NEXT_STATION_TIME =  string.Empty;
            a.A_PREV_STATION_TIME =  string.Empty;
            a.ACCOUNT_CODE =  string.Empty;
            a.ADULT_PAXCOUNT =  string.Empty;
            a.AIRCRAFT_CALLSIGN =  string.Empty;
            a.AIRCRAFT_OPERATOR =  string.Empty;
            a.AIRCRAFT_OWNER =  string.Empty;
            a.AIRCRAFT_PAXCAP =  string.Empty;
            a.AIRCRAFT_TERMINAL =  string.Empty;
            a.AIRCRAFT_TYPE =  string.Empty;
            a.AIRLINE_TERMINAL =  string.Empty;
            a.AIRPORT_IATA =  string.Empty;
            a.BUSSINESS_PAXCOUNT =  string.Empty;
            a.CARRIER_IATA =  string.Empty;
            a.CARRIER_ICAO =  string.Empty;
            a.CC_CLUSTERID1 =  string.Empty;
            a.CC_CLUSTERID2 =  string.Empty;
            a.CC_ROLE1 =  string.Empty;
            a.CC_ROLE2 =  string.Empty;
            a.CC_TYPE1 =  string.Empty;
            a.CC_TYPE2 =  string.Empty;
            a.CHILD_PAXCOUNT =  string.Empty;
            a.FL_CLASSIFICATIONCODE =  string.Empty;
            a.CUSTOM_STATUS =  string.Empty;
            a.DES_ICAO =  string.Empty;
            a.DOMESITEC_PAXCOUNT =  string.Empty;
            a.E_FL_DURATION =  string.Empty;
            a.E_NEXT_STATION_TIME =  string.Empty;
            a.E_PREV_STATION_TIME =  string.Empty;
            a.ECONOMY_PAXCOUNT =  string.Empty;
            a.EXITDOOR1 =  string.Empty;
            a.EXITDOOR2 =  string.Empty;
            a.FINALAPPROACH_TIME =  string.Empty;
            a.FIRSTBAG_TIME =  string.Empty;
            a.FIRSTBAG_TIME2 =  string.Empty;
            a.FIRSTCLASS_PAXCOUNT =  string.Empty;
            a.FL_CANCELCODE =  string.Empty;
            a.FL_NUMBER =  string.Empty;
            a.FL_OPERATES_OVERNIGHT =  string.Empty;
            a.FL_SERVICETYPE =  string.Empty;
            a.FL_SUFFIX =  string.Empty;
            a.FL_TRANSITCODE =  string.Empty;
            a.FLR =  string.Empty;
            a.GATE_BORDING_STATUS2 =  string.Empty;
            a.GATE_PLAN_CLOSE_TIME1 =  string.Empty;
            a.GATE_PLAN_CLOSE_TIME2 =  string.Empty;
            a.GATE_PLAN_OPEN_TIME1 =  string.Empty;
            a.GATE_PLAN_OPEN_TIME2 =  string.Empty;
            a.GATE_ROLE1 =  string.Empty;
            a.GATE_ROLE2 =  string.Empty;
            a.HANDLING_SERVICE1 =  string.Empty;
            a.HANDLING_SERVICE2 =  string.Empty;
            a.HANDLING_SERVICE3 =  string.Empty;
            a.HANDLING_SERVICE4 =  string.Empty;
            a.HANDLING_SERVICE5 =  string.Empty;
            a.HANDLINGAGENT1 =  string.Empty;
            a.HANDLINGAGENT2 =  string.Empty;
            a.HANDLINGAGENT3 =  string.Empty;
            a.HANDLINGAGENT4 =  string.Empty;
            a.HANDLINGAGENT5 =  string.Empty;
            a.INFANT_PAXCOUNT =  string.Empty;
            a.INTERNATIONAL_PAXCOUNT =  string.Empty;
            a.IRR_CODE1 =  string.Empty;
            a.IRR_CODE2 =  string.Empty;
            a.IRR_DURATION1 =  string.Empty;
            a.IRR_DURATION2 =  string.Empty;
            a.IRR_NUMBER1 =  string.Empty;
            a.IRR_NUMBER2 =  string.Empty;
            a.ISBUSREQUIRED =  string.Empty;
            a.ISGVF =  string.Empty;
            a.ISRETURNFL =  string.Empty;
            a.ISTRANSFERFL =  string.Empty;
            a.LASTBAG_TIME =  string.Empty;
            a.LASTBAG_TIME2 =  string.Empty;
            a.LASTKNOWN_SOURCE =  string.Empty;
            a.LASTKNOWN_TIME =  string.Empty;
            a.LINKEDFL_CARRIER =  string.Empty;
            a.LINKEDFL_FLR =  string.Empty;
            a.LINKEDFL_FLT =  string.Empty;
            a.LINKEDFL_NUMBER =  string.Empty;
            a.LINKEDFL_SDT =  string.Empty;
            a.LINKEDFL_SUFFIX =  string.Empty;
            a.LINKFL_ID =  string.Empty;
            a.LOCAL_PAXCOUNT =  string.Empty;
            a.LTA =  string.Empty;
            a.LTD =  string.Empty;
            a.MAKEUP_CLOSE_TIME1 =  string.Empty;
            a.MAKEUP_CLOSE_TIME2 =  string.Empty;
            a.MAKEUP_ID1 =  string.Empty;
            a.MAKEUP_ID2 =  string.Empty;
            a.MAKEUP_OPEN_TIME1 =  string.Empty;
            a.MAKEUP_OPEN_TIME2 =  string.Empty;
            a.MAKEUP_ROLE1 =  string.Empty;
            a.MAKEUP_ROLE2 =  string.Empty;
            a.MASTERFL_CARRIER =  string.Empty;
            a.MASTERFL_FLR =  string.Empty;
            a.MASTERFL_FLT =  string.Empty;
            a.MASTERFL_ID =  string.Empty;
            a.MASTERFL_NUMBER =  string.Empty;
            a.MASTERFL_SUFFIX =  string.Empty;
            a.NEWFL_REASON =  string.Empty;
            a.NEXT_INFO_TIME =  string.Empty;
            a.NONTRANSFER_PAXCOUNT =  string.Empty;
            a.OFFBLOCK_TIME =  string.Empty;
            a.ONBLOCK_TIME =  string.Empty;
            a.OPERATIONTYPE_CODE1 =  string.Empty;
            a.OPERATIONTYPE_CODE2 =  string.Empty;
            a.OPERATIONTYPE_ROLE1 =  string.Empty;
            a.OPERATIONTYPE_ROLE2 =  string.Empty;
            a.ORG_ICAO =  string.Empty;
            a.PUBLIC_FLC =  string.Empty;
            a.PUBLIC_FLT =  string.Empty;
            a.PUBLIC_TIME =  string.Empty;
            a.RECLAIM_ROLE1 =  string.Empty;
            a.RECLAIM_ROLE2 =  string.Empty;
            a.REMARK_CODE1 =  string.Empty;
            a.REMARK_CODE2 =  string.Empty;
            a.REMARK_CODE3 =  string.Empty;
            a.REMARK_CODE4 =  string.Empty;
            a.REMARK_TYPE1 =  string.Empty;
            a.REMARK_TYPE2 =  string.Empty;
            a.REMARK_TYPE3 =  string.Empty;
            a.REMARK_TYPE4 =  string.Empty;
            a.RUNWAY_ID =  string.Empty;
            a.S_INFO_TEXT1 =  string.Empty;
            a.S_INFO_TEXT2 =  string.Empty;
            a.S_INFO_TEXT3 =  string.Empty;
            a.S_INFO_TEXT4 =  string.Empty;
            a.S_INFO_TEXT5 =  string.Empty;
            a.S_INFO_TYPE1 =  string.Empty;
            a.S_INFO_TYPE2 =  string.Empty;
            a.S_INFO_TYPE3 =  string.Empty;
            a.S_INFO_TYPE4 =  string.Empty;
            a.S_INFO_TYPE5 =  string.Empty;
            a.S_NEXT_STATION_TIME =  string.Empty;
            a.S_PREV_STATION_TIME =  string.Empty;
            a.SDP =  string.Empty;
            a.SDT =  string.Empty;
            a.SECURE_STAND_IS_REQUIRED =  string.Empty;
            a.SGCD =  string.Empty;
            a.SHAREFL_FLN1 =  string.Empty;
            a.SHAREFL_FLN2 =  string.Empty;
            a.SHAREFL_FLN3 =  string.Empty;
            a.SHAREFL_FLN4 =  string.Empty;
            a.SHAREFL_FLN5 =  string.Empty;
            a.SHAREFL_FLN6 =  string.Empty;
            a.SHAREFL_FLT1 =  string.Empty;
            a.SHAREFL_FLT2 =  string.Empty;
            a.SHAREFL_FLT3 =  string.Empty;
            a.SHAREFL_FLT4 =  string.Empty;
            a.SHAREFL_FLT5 =  string.Empty;
            a.SHAREFL_FLT6 =  string.Empty;
            a.SUB_AIRLINE =  string.Empty;
            a.TEN_MILES_TIME =  string.Empty;
            a.TOTAL_BAGCOUNT =  string.Empty;
            a.TOTAL_BAGWEIGHT =  string.Empty;
            a.TOTAL_CREWCOUNT =  string.Empty;
            a.TOTAL_FREIGHTWEIGHT =  string.Empty;
            a.TOTAL_LOADWEIGHT =  string.Empty;
            a.TOTAL_MAILWEIGHT =  string.Empty;
            a.TOTAL_PAXCOUNT =  string.Empty;
            a.TRANSFER_BAGCOUNT =  string.Empty;
            a.TRANSFER_BAGWEIGHT =  string.Empty;
            a.TRANSFER_FL1 =  string.Empty;
            a.TRANSFER_FL10 =  string.Empty;
            a.TRANSFER_FL11 =  string.Empty;
            a.TRANSFER_FL12 =  string.Empty;
            a.TRANSFER_FL13 =  string.Empty;
            a.TRANSFER_FL14 =  string.Empty;
            a.TRANSFER_FL15 =  string.Empty;
            a.TRANSFER_FL16 =  string.Empty;
            a.TRANSFER_FL17 =  string.Empty;
            a.TRANSFER_FL18 =  string.Empty;
            a.TRANSFER_FL19 =  string.Empty;
            a.TRANSFER_FL2 =  string.Empty;
            a.TRANSFER_FL20 =  string.Empty;
            a.TRANSFER_FL3 =  string.Empty;
            a.TRANSFER_FL4 =  string.Empty;
            a.TRANSFER_FL5 =  string.Empty;
            a.TRANSFER_FL6 =  string.Empty;
            a.TRANSFER_FL7 =  string.Empty;
            a.TRANSFER_FL8 =  string.Empty;
            a.TRANSFER_FL9 =  string.Empty;
            a.TRANSFER_FREIGHTWEIGHT =  string.Empty;
            a.TRANSFER_MAILWEIGHT =  string.Empty;
            a.TRANSFER_PAXCOUNT =  string.Empty;
            a.TRANSIT_BAGCOUNT =  string.Empty;
            a.TRANSIT_BAGWEIGHT =  string.Empty;
            a.TRANSIT_FREIGHTWEIGHT =  string.Empty;
            a.TRANSIT_MAILWEIGHT =  string.Empty;
            a.TRANSIT_PAXCOUNT =  string.Empty;
            a.UPDATE_TIME =  string.Empty;
            a.UPDATE_TIME =  string.Empty;
            a.VIA_ICAO =  string.Empty;
            a.WHELLCHAIR_PAXCOUNT =  string.Empty;
            a.FL_CANCELCODE = string.Empty;
            a.FL_CLASSIFICATIONCODE =  string.Empty;
            // Add new Poperty
            a.ADID = a.DRCT;//进出港标志 同drct
            a.FLNO = aocDataCC.FLNO;//当前航班号
            a.MFDI = aocDataCC.MFDI;//主航班号

            a.REMP = aocDataCC.REMP;//航班状态，如为DEL或DFI，则合并为DLY
            if (a.REMP.Equals("DEL", StringComparison.OrdinalIgnoreCase) || a.REMP.Equals("DFI", StringComparison.OrdinalIgnoreCase))
            { a.REMP = "DLY"; }

            if (string.IsNullOrEmpty(a.CKIF))
            {
                a.CKIT = string.Empty;//值机柜台截止
            }
            else
            {           
                string tmp=a.CKIF;
                int i=tmp.IndexOf("-");
                if (i >= 0)
                {
                    a.CKIT = a.CKIF.Substring(i+1);//值机柜台截止
                    a.CKIF = a.CKIF.Substring(0, i);
                }
                else
                {
                    a.CKIT = a.CKIF;//值机柜台截止
                }
               
            }
            
            return a;
        }
        private static AOCCONBINE CONBINEAOCDataFQS(AOCDataFQS aocDataFQS)
        {
            AOCCONBINE a = new AOCCONBINE();
            a.URNO = aocDataFQS.URNO;
            a.CARRIER_IATA = aocDataFQS.CARRIER_IATA;
            a.CARRIER_ICAO = aocDataFQS.CARRIER_ICAO;
            a.FL_NUMBER = aocDataFQS.FL_NUMBER;
            a.FL_SUFFIX = aocDataFQS.FL_SUFFIX;
            a.FLR = aocDataFQS.FLR;
            a.SDT = aocDataFQS.SDT;
            a.SDP = aocDataFQS.SDP;
            a.LINKEDFL_FLT = aocDataFQS.LINKEDFL_FLT;
            a.LINKEDFL_CARRIER = aocDataFQS.LINKEDFL_CARRIER;
            a.LINKEDFL_NUMBER = aocDataFQS.LINKEDFL_NUMBER;
            a.LINKEDFL_SUFFIX = aocDataFQS.LINKEDFL_SUFFIX;
            a.LINKEDFL_SDT = aocDataFQS.LINKEDFL_SDT;
            a.LINKEDFL_FLR = aocDataFQS.LINKEDFL_FLR;
            a.LINKFL_ID = aocDataFQS.LINKFL_ID;
            a.MASTERFL_CARRIER = aocDataFQS.MASTERFL_CARRIER;
            a.MASTERFL_NUMBER = aocDataFQS.MASTERFL_NUMBER;
            a.MASTERFL_SUFFIX = aocDataFQS.MASTERFL_SUFFIX;
            a.MASTERFL_FLT = aocDataFQS.MFDI;
            a.MASTERFL_FLR = aocDataFQS.MASTERFL_FLR;
            a.MASTERFL_ID = aocDataFQS.MASTERFL_ID;
            a.AIRCRAFT_CALLSIGN = aocDataFQS.AIRCRAFT_CALLSIGN;
            a.AIRCRAFT_OWNER = aocDataFQS.AIRCRAFT_OWNER;
            a.AIRCRAFT_PAXCAP = aocDataFQS.AIRCRAFT_PAXCAP;
            a.REGN = aocDataFQS.REGN;
            a.ATC5 = aocDataFQS.ATC5;
            a.AIRCRAFT_TYPE = aocDataFQS.AIRCRAFT_TYPE;
            a.AIRCRAFT_OPERATOR = aocDataFQS.AIRCRAFT_OPERATOR;
            a.AIRCRAFT_TERMINAL = aocDataFQS.AIRCRAFT_TERMINAL;
            a.AIRPORT_IATA = aocDataFQS.AIRPORT_IATA;
            a.BRC1 = aocDataFQS.BRC1;
            a.RECLAIM_ROLE1 = aocDataFQS.RECLAIM_ROLE1;
            a.BROD = aocDataFQS.BROD;
            a.BRCD = aocDataFQS.BRCD;
            a.EXITDOOR1 = aocDataFQS.EXITDOOR1;
            a.SRC2 = aocDataFQS.SRC2;
            a.RECLAIM_ROLE2 = aocDataFQS.RECLAIM_ROLE2;
            a.SBRO = aocDataFQS.SBRO;
            a.SBRC = aocDataFQS.SBRC;
            a.EXITDOOR2 = aocDataFQS.EXITDOOR2;
            a.MAKEUP_ID1 = aocDataFQS.MAKEUP_ID1;
            a.MAKEUP_ROLE1 = aocDataFQS.MAKEUP_ROLE1;
            a.MAKEUP_OPEN_TIME1 = aocDataFQS.MAKEUP_OPEN_TIME1;
            a.MAKEUP_CLOSE_TIME1 = aocDataFQS.MAKEUP_CLOSE_TIME1;
            a.MAKEUP_ID2 = aocDataFQS.MAKEUP_ID2;
            a.MAKEUP_ROLE2 = aocDataFQS.MAKEUP_ROLE2;
            a.MAKEUP_OPEN_TIME2 = aocDataFQS.MAKEUP_OPEN_TIME2;
            a.MAKEUP_CLOSE_TIME2 = aocDataFQS.MAKEUP_CLOSE_TIME2;
            a.ISBUSREQUIRED = aocDataFQS.ISBUSREQUIRED;
            a.CC_TYPE1 = aocDataFQS.CC_TYPE1;
            a.CKIF = aocDataFQS.CKIF;
            a.CC_ROLE1 = aocDataFQS.CC_ROLE1;
            a.CC_CLUSTERID1 = aocDataFQS.CC_CLUSTERID1;
            a.CODT = aocDataFQS.CODT;
            a.CCDT = aocDataFQS.CCDT;
            a.CC_TYPE2 = aocDataFQS.CC_TYPE2;
            a.SCDR = aocDataFQS.SCDR;
            a.CC_ROLE2 = aocDataFQS.CC_ROLE2;
            a.CC_CLUSTERID2 = aocDataFQS.CC_CLUSTERID2;
            a.SCODT = aocDataFQS.SCODT;
            a.SCCDT = aocDataFQS.SCCDT;
            a.SGCD = aocDataFQS.SGCD;
            a.SGOD = aocDataFQS.SGOD;
            a.GATE_BORDING_STATUS2 = aocDataFQS.GATE_BORDING_STATUS2;
            a.GATE_ROLE2 = aocDataFQS.GATE_ROLE2;
            a.SGN = aocDataFQS.SGN;
            a.GCDT = aocDataFQS.GCDT;
            a.GODT = aocDataFQS.GODT;
            a.GBS = aocDataFQS.GBS;
            a.GATE_ROLE1 = aocDataFQS.GATE_ROLE1;
            a.GENO = aocDataFQS.GENO;
            a.TERM = aocDataFQS.TERM;
            a.REMARK_CODE1 = aocDataFQS.REMARK_CODE1;
            a.REMARK_TYPE1 = aocDataFQS.REMARK_TYPE1;
            a.REMARK_CODE2 = aocDataFQS.REMARK_CODE2;
            a.REMARK_TYPE2 = aocDataFQS.REMARK_TYPE2;
            a.REMARK_CODE3 = aocDataFQS.REMARK_CODE3;
            a.REMARK_TYPE3 = aocDataFQS.REMARK_TYPE3;
            a.REMARK_CODE4 = aocDataFQS.REMARK_CODE4;
            a.REMARK_TYPE4 = aocDataFQS.REMARK_TYPE4;
            a.RUNWAY_ID = aocDataFQS.RUNWAY_ID;
            a.S_INFO_TYPE1 = aocDataFQS.S_INFO_TYPE1;
            a.S_INFO_TEXT1 = aocDataFQS.S_INFO_TEXT1;
            a.S_INFO_TYPE2 = aocDataFQS.S_INFO_TYPE2;
            a.S_INFO_TEXT2 = aocDataFQS.S_INFO_TEXT2;
            a.S_INFO_TYPE3 = aocDataFQS.S_INFO_TYPE3;
            a.S_INFO_TEXT3 = aocDataFQS.S_INFO_TEXT3;
            a.S_INFO_TYPE4 = aocDataFQS.S_INFO_TYPE4;
            a.S_INFO_TEXT4 = aocDataFQS.S_INFO_TEXT4;
            a.S_INFO_TYPE5 = aocDataFQS.S_INFO_TYPE5;
            a.S_INFO_TEXT5 = aocDataFQS.S_INFO_TEXT5;
            a.ACCOUNT_CODE = aocDataFQS.ACCOUNT_CODE;
            a.FL_CLASSIFICATIONCODE = aocDataFQS.FL_CLASSIFICATIONCODE;
            a.FL_STATUSCODE = aocDataFQS.FL_STATUSCODE;
            a.CSS = aocDataFQS.CSS;
            a.DAIA = aocDataFQS.DAIA;
            a.FL_CANCELCODE = aocDataFQS.FL_CANCELCODE;
            a.FL_OPERATES_OVERNIGHT = aocDataFQS.FL_OPERATES_OVERNIGHT;
            a.TTYP = aocDataFQS.TTYP;
            a.FL_SERVICETYPE = aocDataFQS.FL_SERVICETYPE;
            a.FLTI = aocDataFQS.FLTI;
            a.FL_TRANSITCODE = aocDataFQS.FL_TRANSITCODE;
            a.HANDLINGAGENT1 = aocDataFQS.HANDLINGAGENT1;
            a.HANDLING_SERVICE1 = aocDataFQS.HANDLING_SERVICE1;
            a.HANDLINGAGENT2 = aocDataFQS.HANDLINGAGENT2;
            a.HANDLING_SERVICE2 = aocDataFQS.HANDLING_SERVICE2;
            a.HANDLINGAGENT3 = aocDataFQS.HANDLINGAGENT3;
            a.HANDLING_SERVICE3 = aocDataFQS.HANDLING_SERVICE3;
            a.HANDLINGAGENT4 = aocDataFQS.HANDLINGAGENT4;
            a.HANDLING_SERVICE4 = aocDataFQS.HANDLING_SERVICE4;
            a.HANDLINGAGENT5 = aocDataFQS.HANDLINGAGENT5;
            a.HANDLING_SERVICE5 = aocDataFQS.HANDLING_SERVICE5;
            a.IRR_NUMBER1 = aocDataFQS.IRR_NUMBER1;
            a.IRR_CODE1 = aocDataFQS.IRR_CODE1;
            a.IRR_DURATION1 = aocDataFQS.IRR_DURATION1;
            a.IRR_NUMBER2 = aocDataFQS.IRR_NUMBER2;
            a.IRR_CODE2 = aocDataFQS.IRR_CODE2;
            a.IRR_DURATION2 = aocDataFQS.IRR_DURATION2;
            a.ISGVF = aocDataFQS.ISGVF;
            a.ISRETURNFL = aocDataFQS.ISRETURNFL;
            a.ISTRANSFERFL = aocDataFQS.ISTRANSFERFL;
            a.NEWFL_REASON = aocDataFQS.NEWFL_REASON;
            a.OPERATIONTYPE_CODE1 = aocDataFQS.OPERATIONTYPE_CODE1;
            a.TRANSFER_FL1 = aocDataFQS.TRANSFER_FL1;
            a.TRANSFER_FL2 = aocDataFQS.TRANSFER_FL2;
            a.TRANSFER_FL3 = aocDataFQS.TRANSFER_FL3;
            a.TRANSFER_FL4 = aocDataFQS.TRANSFER_FL4;
            a.TRANSFER_FL5 = aocDataFQS.TRANSFER_FL5;
            a.TRANSFER_FL6 = aocDataFQS.TRANSFER_FL6;
            a.TRANSFER_FL7 = aocDataFQS.TRANSFER_FL7;
            a.TRANSFER_FL8 = aocDataFQS.TRANSFER_FL8;
            a.TRANSFER_FL9 = aocDataFQS.TRANSFER_FL9;
            a.TRANSFER_FL10 = aocDataFQS.TRANSFER_FL10;
            a.TRANSFER_FL11 = aocDataFQS.TRANSFER_FL11;
            a.TRANSFER_FL12 = aocDataFQS.TRANSFER_FL12;
            a.TRANSFER_FL13 = aocDataFQS.TRANSFER_FL13;
            a.TRANSFER_FL14 = aocDataFQS.TRANSFER_FL14;
            a.TRANSFER_FL15 = aocDataFQS.TRANSFER_FL15;
            a.TRANSFER_FL16 = aocDataFQS.TRANSFER_FL16;
            a.TRANSFER_FL17 = aocDataFQS.TRANSFER_FL17;
            a.TRANSFER_FL18 = aocDataFQS.TRANSFER_FL18;
            a.TRANSFER_FL19 = aocDataFQS.TRANSFER_FL19;
            a.TRANSFER_FL20 = aocDataFQS.TRANSFER_FL20;
            a.SHAREFL_FLT1 = aocDataFQS.SHAREFL_FLT1;
            a.SHAREFL_FLN1 = aocDataFQS.SHAREFL_FLN1;
            a.SHAREFL_FLT2 = aocDataFQS.SHAREFL_FLT2;
            a.SHAREFL_FLN2 = aocDataFQS.SHAREFL_FLN2;
            a.SHAREFL_FLT3 = aocDataFQS.SHAREFL_FLT3;
            a.SHAREFL_FLN3 = aocDataFQS.SHAREFL_FLN3;
            a.SHAREFL_FLT4 = aocDataFQS.SHAREFL_FLT4;
            a.SHAREFL_FLN4 = aocDataFQS.SHAREFL_FLN4;
            a.SHAREFL_FLT5 = aocDataFQS.SHAREFL_FLT5;
            a.SHAREFL_FLN5 = aocDataFQS.SHAREFL_FLN5;
            a.SHAREFL_FLT6 = aocDataFQS.SHAREFL_FLT6;
            a.SHAREFL_FLN6 = aocDataFQS.SHAREFL_FLN6;
            a.TOTAL_BAGCOUNT = aocDataFQS.TOTAL_BAGCOUNT;
            a.TOTAL_BAGWEIGHT = aocDataFQS.TOTAL_BAGWEIGHT;
            a.TOTAL_FREIGHTWEIGHT = aocDataFQS.TOTAL_FREIGHTWEIGHT;
            a.TOTAL_MAILWEIGHT = aocDataFQS.TOTAL_MAILWEIGHT;
            a.TOTAL_LOADWEIGHT = aocDataFQS.TOTAL_LOADWEIGHT;
            a.ADULT_PAXCOUNT = aocDataFQS.ADULT_PAXCOUNT;
            a.BUSSINESS_PAXCOUNT = aocDataFQS.BUSSINESS_PAXCOUNT;
            a.CHILD_PAXCOUNT = aocDataFQS.CHILD_PAXCOUNT;
            a.DOMESITEC_PAXCOUNT = aocDataFQS.DOMESITEC_PAXCOUNT;
            a.INFANT_PAXCOUNT = aocDataFQS.INFANT_PAXCOUNT;
            a.INTERNATIONAL_PAXCOUNT = aocDataFQS.INTERNATIONAL_PAXCOUNT;
            a.LOCAL_PAXCOUNT = aocDataFQS.LOCAL_PAXCOUNT;
            a.NONTRANSFER_PAXCOUNT = aocDataFQS.NONTRANSFER_PAXCOUNT;
            a.TOTAL_PAXCOUNT = aocDataFQS.TOTAL_PAXCOUNT;
            a.TRANSFER_PAXCOUNT = aocDataFQS.TRANSFER_PAXCOUNT;
            a.TRANSIT_PAXCOUNT = aocDataFQS.TRANSIT_PAXCOUNT;
            a.WHELLCHAIR_PAXCOUNT = aocDataFQS.WHELLCHAIR_PAXCOUNT;
            a.TOTAL_CREWCOUNT = aocDataFQS.TOTAL_CREWCOUNT;
            a.ECONOMY_PAXCOUNT = aocDataFQS.ECONOMY_PAXCOUNT;
            a.FIRSTCLASS_PAXCOUNT = aocDataFQS.FIRSTCLASS_PAXCOUNT;
            a.TRANSFER_BAGCOUNT = aocDataFQS.TRANSFER_BAGCOUNT;
            a.TRANSFER_BAGWEIGHT = aocDataFQS.TRANSFER_BAGWEIGHT;
            a.TRANSFER_FREIGHTWEIGHT = aocDataFQS.TRANSFER_FREIGHTWEIGHT;
            a.TRANSFER_MAILWEIGHT = aocDataFQS.TRANSFER_MAILWEIGHT;
            a.TRANSIT_BAGCOUNT = aocDataFQS.TRANSIT_BAGCOUNT;
            a.TRANSIT_BAGWEIGHT = aocDataFQS.TRANSIT_BAGWEIGHT;
            a.TRANSIT_FREIGHTWEIGHT = aocDataFQS.TRANSIT_FREIGHTWEIGHT;
            a.TRANSIT_MAILWEIGHT = aocDataFQS.TRANSIT_MAILWEIGHT;
            a.OFFBLOCK_TIME = aocDataFQS.OFFBLOCK_TIME;
            a.ONBLOCK_TIME = aocDataFQS.ONBLOCK_TIME;
            a.EDTA = aocDataFQS.EDTA;
            a.EDTD = aocDataFQS.EDTD;
            a.E_FL_DURATION = aocDataFQS.E_FL_DURATION;
            a.FIRSTBAG_TIME = aocDataFQS.FIRSTBAG_TIME;
            a.LASTBAG_TIME = aocDataFQS.LASTBAG_TIME;
            a.FINALAPPROACH_TIME = aocDataFQS.FINALAPPROACH_TIME;
            a.LASTKNOWN_TIME = aocDataFQS.LASTKNOWN_TIME;
            a.LASTKNOWN_SOURCE = aocDataFQS.LASTKNOWN_SOURCE;
            a.NEXT_INFO_TIME = aocDataFQS.NEXT_INFO_TIME;
            a.A_NEXT_STATION_TIME = aocDataFQS.A_NEXT_STATION_TIME;
            a.E_NEXT_STATION_TIME = aocDataFQS.E_NEXT_STATION_TIME;
            a.S_NEXT_STATION_TIME = aocDataFQS.S_NEXT_STATION_TIME;
            a.A_PREV_STATION_TIME = aocDataFQS.A_PREV_STATION_TIME;
            a.E_PREV_STATION_TIME = aocDataFQS.E_PREV_STATION_TIME;
            a.S_PREV_STATION_TIME = aocDataFQS.S_PREV_STATION_TIME;
            a.LAND = aocDataFQS.LAND;
            a.AIRB = aocDataFQS.AIRB;
            a.TEN_MILES_TIME = aocDataFQS.TEN_MILES_TIME;
            a.ORG3 = aocDataFQS.ORG3;
            a.DES3 = aocDataFQS.DES3;
            a.ORG_ICAO = aocDataFQS.ORG_ICAO;
            a.DES_ICAO = aocDataFQS.DES_ICAO;
            a.VIA1 = aocDataFQS.VIA1;
            a.VIA_ICAO = aocDataFQS.VIA_ICAO;
            a.PUBLIC_FLT = aocDataFQS.PUBLIC_FLT;
            a.PUBLIC_FLC = aocDataFQS.PUBLIC_FLC;
            a.PUBLIC_TIME = aocDataFQS.PUBLIC_TIME;
            a.SECURE_STAND_IS_REQUIRED = aocDataFQS.SECURE_STAND_IS_REQUIRED;
            if (aocDataFQS.DRCT.CompareTo("D") == 0)
            {
                a.STOD = aocDataFQS.STOD;
                a.STOA = string.Empty;
            }
            else
            {
                a.STOA = aocDataFQS.STOD;
                a.STOD = string.Empty;
            }
           
            a.STPO = aocDataFQS.STPO;
            a.OPERATIONTYPE_CODE2 = aocDataFQS.OPERATIONTYPE_CODE2;
            a.FIRSTBAG_TIME2 = aocDataFQS.FIRSTBAG_TIME2;
            a.LASTBAG_TIME2 = aocDataFQS.LASTBAG_TIME2;
            a.OPERATIONTYPE_ROLE1 = aocDataFQS.OPERATIONTYPE_ROLE1;
            a.OPERATIONTYPE_ROLE2 = aocDataFQS.OPERATIONTYPE_ROLE2;
            a.UPDATE_TIME = aocDataFQS.UPDATE_TIME;
            a.CUSTOM_STATUS = aocDataFQS.CUSTOM_STATUS;
            a.SUB_AIRLINE = aocDataFQS.SUB_AIRLINE;
            a.LTD = aocDataFQS.LTD;
            a.LTA = aocDataFQS.LTA;
            a.AIRLINE_TERMINAL = aocDataFQS.AIRLINE_TERMINAL;
            a.GATE_PLAN_CLOSE_TIME1 = aocDataFQS.GATE_PLAN_CLOSE_TIME1;
            a.GATE_PLAN_OPEN_TIME1 = aocDataFQS.GATE_PLAN_OPEN_TIME1;
            a.GATE_PLAN_CLOSE_TIME2 = aocDataFQS.GATE_PLAN_CLOSE_TIME2;
            a.GATE_PLAN_OPEN_TIME2 = aocDataFQS.GATE_PLAN_OPEN_TIME2;            
            a.JFNO = aocDataFQS.JFNO;
            a.CTRL = aocDataFQS.CTRL;
            a.DRCT = aocDataFQS.DRCT;
            a.APTIATA =  "PVG";
            a.ASIA =  string.Empty;
            a.CDR =  string.Empty;
            a.GN =  string.Empty;
            a.POCC =  string.Empty;
            a.SP =  string.Empty;
            a.CDR =  string.Empty;

            a.ADID = a.DRCT;//进出港标志 同drct
            a.FLNO = aocDataFQS.FLT;//当前航班号
            a.MFDI = aocDataFQS.MFDI; //主航班号

            a.REMP = aocDataFQS.OPERATIONTYPE_CODE1;//航班状态，如为DEL或DFI，则合并为DLY
            if (a.REMP.Equals("DEL", StringComparison.OrdinalIgnoreCase) || a.REMP.Equals("DFI", StringComparison.OrdinalIgnoreCase))
            { a.REMP = "DLY"; }

            if (string.IsNullOrEmpty(a.CKIF))
            {
                a.CKIT = string.Empty;//值机柜台截止
            }
            else
            {
                string tmp = a.CKIF;
                int i = tmp.IndexOf("-");
                if (i >= 0)
                {
                    a.CKIT = a.CKIF.Substring(i+1);//值机柜台截止
                    a.CKIF = a.CKIF.Substring(0, i);
                }
                else
                {
                    a.CKIT = a.CKIF;//值机柜台截止
                }

            }
            a.FL_STATUSCODE=aocDataFQS.FL_STATUSCODE;    
            a.FL_CANCELCODE=aocDataFQS.FL_CANCELCODE;
            a.FL_CLASSIFICATIONCODE = aocDataFQS.FL_CLASSIFICATIONCODE;

            //补全CC的字段
            a.ACTUALOFFBLOCKSDATETIME = string.Empty;
            a.ACTUALONBLOCKSDATETIME = string.Empty;
            a.AIRCRAFTTERMINALCODE = string.Empty;
            a.BAGGAGERECLAIMCAROUSELROLE = string.Empty;
            a.OCCURDATETIME = string.Empty;
            a.SDBAGRECLAIMCAROUSELROLE = string.Empty;
            a.SDFIRSTBAGDATETIME = string.Empty;
            a.SDLASTBAGDATETIME = string.Empty;
            a.SUPPLEMENTARYINFORMATION = string.Empty;
            a.SUPPLEMENTARYINFORMATIONTEXT = string.Empty;
            a.FLIGHTFLAG = string.Empty;
            a.FLIGHTREPEATCOUNT = string.Empty;
            a.ISGENERALAVIATIONFLIGHT = string.Empty;
            a.TRANSFERFLIGHTIDENTITY = string.Empty;
            //补全CC的字段
            return a;
        }
  
        public static List<AOCCONBINE> GetAOCCONBINEDatas(List<AOCDataCC> lstAOCDataCC, List<AOCDataFQS> lstAOCDataFQS, AOCUserData aocUserData)
        {
            aocUserData.loginfo.WriteLine("in GetAOCCONBINEDatas");

            List<AOCCONBINE> list = new List<AOCCONBINE>();
            List<AOCDataCC> ccList = new List<AOCDataCC>();
            //////////////////////////////////////////////////////////////

            lstAOCDataCC.Sort();
            lstAOCDataFQS.Sort();

            int indexCC = 0;
            int indexFQS = 0;

            // Filter ccList and fqsList by AocUserData Configuration
            int _iata = aocUserData.AirportIATA;
            string[] _fn = aocUserData.FlightNature.Split(',');

            if (_iata >= 0)
            {
                if (_iata == 1)
                {
                    lstAOCDataCC = lstAOCDataCC.FindAll(delegate(AOCDataCC cc) { return cc.APTIATA.Equals("PVG", StringComparison.OrdinalIgnoreCase); });
                    lstAOCDataFQS = lstAOCDataFQS.FindAll(delegate(AOCDataFQS fqs) { return fqs.AIRPORT_IATA.Equals("PVG", StringComparison.OrdinalIgnoreCase); });
                }
                else if (_iata == 2)
                {
                    lstAOCDataCC = lstAOCDataCC.FindAll(delegate(AOCDataCC cc) { return cc.APTIATA.Equals("SHA", StringComparison.OrdinalIgnoreCase); });
                    lstAOCDataFQS = lstAOCDataFQS.FindAll(delegate(AOCDataFQS fqs) { return fqs.AIRPORT_IATA.Equals("SHA", StringComparison.OrdinalIgnoreCase); });
                }
            }
            else
            {
                return list;
            }

            if (_fn.Length > 0)
            {
                lstAOCDataCC = lstAOCDataCC.FindAll(delegate(AOCDataCC cc)
                {
                    bool retValue = false;

                    if (_fn[0].Equals("1"))
                    {
                        retValue = retValue || cc.TTYP.Equals("PAX", StringComparison.OrdinalIgnoreCase);
                    }

                    if (_fn[1].Equals("1"))
                    {
                        retValue = retValue || cc.TTYP.Equals("CGO", StringComparison.OrdinalIgnoreCase);
                    }

                    if (_fn[2].Equals("1"))
                    {
                        retValue = retValue || cc.TTYP.Equals("SPE", StringComparison.OrdinalIgnoreCase);
                    }

                    return retValue;
                });

                lstAOCDataFQS = lstAOCDataFQS.FindAll(delegate(AOCDataFQS fqs)
                {
                    bool retValue = false;

                    if (_fn[0].Equals("1"))
                    {
                        retValue = retValue || fqs.TTYP.Equals("PAX", StringComparison.OrdinalIgnoreCase);
                    }

                    if (_fn[1].Equals("1"))
                    {
                        retValue = retValue || fqs.TTYP.Equals("CGO", StringComparison.OrdinalIgnoreCase);
                    }

                    if (_fn[2].Equals("1"))
                    {
                        retValue = retValue || fqs.TTYP.Equals("SPE", StringComparison.OrdinalIgnoreCase);
                    }

                    return retValue;
                });
            }
            else
            {
                return list;
            }
            int breaks = 0;
            if (lstAOCDataCC.Count > 0 && lstAOCDataFQS.Count > 0)
            {
                bool loopend = false;
                while (!loopend)
                {
                    //循环比较所属机场、日期、航班号、进出港，把FQS、CC中相同的航班从CC中去除掉
                    if (lstAOCDataCC[indexCC].APTIATA.Equals("PVG"))//cc中PVG的航班
                    {
                        
                        int res = lstAOCDataCC[indexCC].FLNO.CompareTo(lstAOCDataFQS[indexFQS].FLT);//航班号
                        if (res == 0)//航班号相同
                        {
                            //string stodCC = lstAOCDataCC[indexCC].STOD.Substring(0, 8);
                            //string stodFQS = lstAOCDataFQS[indexFQS].STOD.Substring(0, 8);
                            //int res = stodCC.CompareTo(stodFQS);//日期
                            res = lstAOCDataCC[indexCC].STOD.CompareTo(lstAOCDataFQS[indexFQS].STOD);
                            if (res == 0)//日期相同
                            {
                                res = lstAOCDataCC[indexCC].DRCT.CompareTo(lstAOCDataFQS[indexFQS].DRCT);//进出港
                                if (res == 0)//进出港相同，跳过该航班
                                {
                                    indexCC++;
                                    indexFQS++;
                                    breaks++;
                                }
                                else if (res < 0)//进出港CC小，保留
                                {
                                    ccList.Add(lstAOCDataCC[indexCC]);
                                    indexCC++;
                                }
                                else//进出港大，比较下一个FQS
                                {
                                    indexFQS++;
                                }
                            }
                            else if (res < 0)//日期CC小，保留
                            {
                                ccList.Add(lstAOCDataCC[indexCC]);
                                indexCC++;
                            }
                            else//日期CC大，比较下一个FQS
                            {
                                indexFQS++;
                            }
                           
                        }
                        else if (res < 0)//航班号CC小，保留
                        {
                            ccList.Add(lstAOCDataCC[indexCC]);
                            indexCC++;
                        }
                        else//航班号CC大，比较下一个FQS
                        {
                            indexFQS++;
                        }
                       
                    }
                    else//CC中SHA的航班直接保留
                    {
                        ccList.Add(lstAOCDataCC[indexCC]);
                        indexCC++;
                    }
                    if (indexCC == lstAOCDataCC.Count || indexFQS == lstAOCDataFQS.Count)
                    {
                        loopend = true;
                    }
                }
            }

            for (indexFQS=0; indexFQS < lstAOCDataFQS.Count; indexFQS++)//FQS整个保留
            {
                list.Add(CONBINEAOCDataFQS(lstAOCDataFQS[indexFQS]));
            }

            for (; indexCC < lstAOCDataCC.Count; indexCC++)//如果CC还有剩余，全部保留
            {
                //if (lstAOCDataCC[indexCC].APTIATA.Equals("PVG"))
                //{
                    ccList.Add(lstAOCDataCC[indexCC]);
                //}
            }

            foreach (AOCDataCC ccData in ccList)//过滤出来的CC的航班，加入CONBIONE中
            {
                list.Add(CONBINEAOCDataCC(ccData));
            }
            aocUserData.loginfo.WriteLine("leave GetAOCCONBINEDatas");
            return list;
        }

        /// <summary>
        /// 获取AOC的所有属性
        /// </summary>
        /// <returns></returns>
        public static List<PropertyInfo> GetAOCCONBINEProperties()
        {
            List<PropertyInfo> aocDataPropertiesList = new List<PropertyInfo>();
            Type typeAOC = typeof(AOCCONBINE);

            foreach (PropertyInfo AOCProperty in typeAOC.GetProperties())
            {
                aocDataPropertiesList.Add(AOCProperty);
            }

            return aocDataPropertiesList;
        }

        //public static List<PropertyInfo> AOCCONBINEDataPropertiesList;

        #region AOC FQS COLUMNS


        private string urno;
        private string carrier_iata;
        private string carrier_icao;
        private string fl_number;
        private string fl_suffix;
        private string mfdi;
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
        private string masterfl_flt;
        private string masterfl_flr;
        private string masterfl_id;
        private string aircraft_callsign;
        private string aircraft_owner;
        private string aircraft_paxcap;
        private string aircraft_registration;
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
        private string css;
        private string daia;
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
        private string stoa;
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
        private string jfno;
        private int ctrl;
        private string drct;
        private string aptiata;
        private string asia;
        private string cdr;
        private string gn;
        private string pocc;
        private string regn;
        private string term;
        private string sp;
        private string adid;//进出港标志 同drct
        private string flno;//当前航班号
        private string remp;//航班状态
        private string ckit;//值机柜台截止
        private string fl_statuscode;  
        private string fl_cancelcode;
        private string fl_classificationcode;

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
        public string MFDI
        {
            set { mfdi = value; }
            get { return mfdi; }
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
        public string MASTERFL_FLT
        {
            set { masterfl_flt = value; }
            get { return masterfl_flt; }
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
        public string STOA
        {
            set { stoa = value; }
            get { return stoa; }
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
        public string APTIATA
        {
            set { aptiata = value; }
            get { return aptiata; }
        }
        public string ASIA
        {
            set { asia = value; }
            get { return asia; }
        }
        public string CDR
        {
            set { cdr = value; }
            get { return cdr; }
        }
        public string GN
        {
            set { gn = value; }
            get { return gn; }
        }
        public string POCC
        {
            set { pocc = value; }
            get { return pocc; }
        }
        public string REGN
        {
            set { regn = value; }
            get { return regn; }
        }
        public string TERM
        {
            set { term = value; }
            get { return term; }
        }
        public string SP
        {
            set { sp = value; }
            get { return sp; }
        }
        public string ADID//进出港标志 同drct
        {
            set { adid = value; }
            get { return adid; }
        }
        public string FLNO//当前航班号
        {
            set { flno = value; }
            get { return flno; }
        }
        public string REMP//航班状态
        {
            get { return remp; }
            set { remp = value; }
        }
        public string CKIT//值机柜台截止
        {
            set { ckit = value; }
            get { return ckit; }
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
        //补全CC的字段
        private string actualoffblocksdatetime;
        private string actualonblocksdatetime;
        private string aircraftterminalcode;
        private string baggagereclaimcarouselrole;
        private string occurdatetime;
        private string sdbagreclaimcarouselrole;
        private string sdfirstbagdatetime;
        private string sdlastbagdatetime;
        private string supplementaryinformation;
        private string supplementaryinformationtext;
        private string flightflag;
        private string flightrepeatcount;
        private string isgeneralaviationflight;
        private string transferflightidentity;
        public string ACTUALOFFBLOCKSDATETIME { set { actualoffblocksdatetime = value; } get { return actualoffblocksdatetime; } }
        public string ACTUALONBLOCKSDATETIME { set { actualonblocksdatetime = value; } get { return actualonblocksdatetime; } }
        public string AIRCRAFTTERMINALCODE { set { aircraftterminalcode = value; } get { return aircraftterminalcode; } }
        public string BAGGAGERECLAIMCAROUSELROLE { set { baggagereclaimcarouselrole = value; } get { return baggagereclaimcarouselrole; } }
        public string OCCURDATETIME { set { occurdatetime = value; } get { return occurdatetime; } }
        public string SDBAGRECLAIMCAROUSELROLE { set { sdbagreclaimcarouselrole = value; } get { return sdbagreclaimcarouselrole; } }
        public string SDFIRSTBAGDATETIME { set { sdfirstbagdatetime = value; } get { return sdfirstbagdatetime; } }
        public string SDLASTBAGDATETIME { set { sdlastbagdatetime = value; } get { return sdlastbagdatetime; } }
        public string SUPPLEMENTARYINFORMATION { set { supplementaryinformation = value; } get { return supplementaryinformation; } }
        public string SUPPLEMENTARYINFORMATIONTEXT { set { supplementaryinformationtext = value; } get { return supplementaryinformationtext; } }
        public string FLIGHTFLAG { set { flightflag = value; } get { return flightflag; } }
        public string FLIGHTREPEATCOUNT { set { flightrepeatcount = value; } get { return flightrepeatcount; } }
        public string ISGENERALAVIATIONFLIGHT { set { isgeneralaviationflight = value; } get { return isgeneralaviationflight; } }
        public string TRANSFERFLIGHTIDENTITY { set { transferflightidentity = value; } get { return transferflightidentity; } }
        //补全CC的字段

        #endregion
    }
}
