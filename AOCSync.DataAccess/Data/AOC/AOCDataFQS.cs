using System;
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

namespace AOCSync.DataAccess
{
    public class AOCDataFQS
    {
        public static DataRow GetAOCDataByID(Guid aGuid)
        {
            string sql = @"SELECT [ID],[URNO], [CARRIER_IATA], [CARRIER_ICAO], [FL_NUMBER], [FL_SUFFIX], [FLT], [FLR], [SDT], [SDP], [LINKEDFL_FLT], 
                                [LINKEDFL_CARRIER], [LINKEDFL_NUMBER], [LINKEDFL_SUFFIX], [LINKEDFL_SDT], [LINKEDFL_FLR], [LINKFL_ID], [MASTERFL_CARRIER], 
                                [MASTERFL_NUMBER], [MASTERFL_SUFFIX], [MFDI], [MASTERFL_FLR], [MASTERFL_ID], [AIRCRAFT_CALLSIGN], [AIRCRAFT_OWNER], 
                                [AIRCRAFT_PAXCAP], [REGN], [ATC5], [AIRCRAFT_TYPE], [AIRCRAFT_OPERATOR], [AIRCRAFT_TERMINAL], [AIRPORT_IATA], 
                                [BRC1], [RECLAIM_ROLE1], [BROD], [BRCD], [EXITDOOR1], [SRC2], [RECLAIM_ROLE2], [SBRO], [SBRC], [EXITDOOR2], [MAKEUP_ID1], [MAKEUP_ROLE1], 
                                [MAKEUP_OPEN_TIME1], [MAKEUP_CLOSE_TIME1], [MAKEUP_ID2], [MAKEUP_ROLE2], [MAKEUP_OPEN_TIME2], [MAKEUP_CLOSE_TIME2], [ISBUSREQUIRED], 
                                [CC_TYPE1], [CKIF], [CC_ROLE1], [CC_CLUSTERID1], [CODT], [CCDT], [CC_TYPE2], [SCDR], [CC_ROLE2], [CC_CLUSTERID2], [SCODT], [SCCDT], [SGCD], 
                                [SGOD], [GATE_BORDING_STATUS2], [GATE_ROLE2], [SGN], [GCDT], [GODT], [GBS], [GATE_ROLE1], [GENO], [TERM], [REMARK_CODE1], 
                                [REMARK_TYPE1], [REMARK_CODE2], [REMARK_TYPE2], [REMARK_CODE3], [REMARK_TYPE3], [REMARK_CODE4], [REMARK_TYPE4], [RUNWAY_ID], 
                                [S_INFO_TYPE1], [S_INFO_TEXT1], [S_INFO_TYPE2], [S_INFO_TEXT2], [S_INFO_TYPE3], [S_INFO_TEXT3], [S_INFO_TYPE4], [S_INFO_TEXT4], 
                                [S_INFO_TYPE5], [S_INFO_TEXT5], [ACCOUNT_CODE], [FL_CLASSIFICATIONCODE], [FL_STATUSCODE], [CSS], [DAIA], [FL_CANCELCODE], [FL_OPERATES_OVERNIGHT], 
                                [TTYP], [FL_SERVICETYPE], [FLTI], [FL_TRANSITCODE], [HANDLINGAGENT1], [HANDLING_SERVICE1], [HANDLINGAGENT2], [HANDLING_SERVICE2], [HANDLINGAGENT3], 
                                [HANDLING_SERVICE3], [HANDLINGAGENT4], [HANDLING_SERVICE4], [HANDLINGAGENT5], [HANDLING_SERVICE5], [IRR_NUMBER1], [IRR_CODE1], [IRR_DURATION1], 
                                [IRR_NUMBER2], [IRR_CODE2], [IRR_DURATION2], [ISGVF], [ISRETURNFL], [ISTRANSFERFL], [NEWFL_REASON], [OPERATIONTYPE_CODE1], [TRANSFER_FL1], 
                                [TRANSFER_FL2], [TRANSFER_FL3], [TRANSFER_FL4], [TRANSFER_FL5], [TRANSFER_FL6], [TRANSFER_FL7], [TRANSFER_FL8], [TRANSFER_FL9], [TRANSFER_FL10], 
                                [TRANSFER_FL11], [TRANSFER_FL12], [TRANSFER_FL13], [TRANSFER_FL14], [TRANSFER_FL15], [TRANSFER_FL16], [TRANSFER_FL17], [TRANSFER_FL18], [TRANSFER_FL19], 
                                [TRANSFER_FL20], [SHAREFL_FLT1], [SHAREFL_FLN1], [SHAREFL_FLT2], [SHAREFL_FLN2], [SHAREFL_FLT3], [SHAREFL_FLN3], [SHAREFL_FLT4], [SHAREFL_FLN4], 
                                [SHAREFL_FLT5], [SHAREFL_FLN5], [SHAREFL_FLT6], [SHAREFL_FLN6], [TOTAL_BAGCOUNT], [TOTAL_BAGWEIGHT], [TOTAL_FREIGHTWEIGHT], [TOTAL_MAILWEIGHT], 
                                [TOTAL_LOADWEIGHT], [ADULT_PAXCOUNT], [BUSSINESS_PAXCOUNT], [CHILD_PAXCOUNT], [DOMESITEC_PAXCOUNT], [INFANT_PAXCOUNT], [INTERNATIONAL_PAXCOUNT], 
                                [LOCAL_PAXCOUNT], [NONTRANSFER_PAXCOUNT], [TOTAL_PAXCOUNT], [TRANSFER_PAXCOUNT], [TRANSIT_PAXCOUNT], [WHELLCHAIR_PAXCOUNT], [TOTAL_CREWCOUNT], 
                                [ECONOMY_PAXCOUNT], [FIRSTCLASS_PAXCOUNT], [TRANSFER_BAGCOUNT], [TRANSFER_BAGWEIGHT], [TRANSFER_FREIGHTWEIGHT], [TRANSFER_MAILWEIGHT], 
                                [TRANSIT_BAGCOUNT], [TRANSIT_BAGWEIGHT], [TRANSIT_FREIGHTWEIGHT], [TRANSIT_MAILWEIGHT], [OFFBLOCK_TIME], [ONBLOCK_TIME], [EDTA], [EDTD], [E_FL_DURATION], 
                                [FIRSTBAG_TIME], [LASTBAG_TIME], [FINALAPPROACH_TIME], [LASTKNOWN_TIME], [LASTKNOWN_SOURCE], [NEXT_INFO_TIME], [A_NEXT_STATION_TIME], 
                                [E_NEXT_STATION_TIME], [S_NEXT_STATION_TIME], [A_PREV_STATION_TIME], [E_PREV_STATION_TIME], [S_PREV_STATION_TIME], [LAND], [AIRB], [TEN_MILES_TIME], 
                                [ORG3], [DES3], [ORG_ICAO], [DES_ICAO], [VIA1], [VIA_ICAO], [PUBLIC_FLT], [PUBLIC_FLC], [PUBLIC_TIME], [SECURE_STAND_IS_REQUIRED], [STOD], [STPO], 
                                [OPERATIONTYPE_CODE2], [FIRSTBAG_TIME2], [LASTBAG_TIME2], [OPERATIONTYPE_ROLE1], [OPERATIONTYPE_ROLE2], [UPDATE_TIME], [CUSTOM_STATUS], 
                                [SUB_AIRLINE], [LTD], [LTA], [AIRLINE_TERMINAL], [GATE_PLAN_CLOSE_TIME1], [GATE_PLAN_OPEN_TIME1], [GATE_PLAN_CLOSE_TIME2], [GATE_PLAN_OPEN_TIME2], 
                                [USEC], [USEU], [TYPU], [LSTU], [JFNO], [CTRL], [DRCT]
                              FROM  [AOCFQS]
                              WHERE ID = @aGuid";

            DataSet ds = SqlHelper.ExecuteDataset(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, new SqlParameter("@aGuid", aGuid));

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static void UpdateAOCData(
                Guid id,
                string urno, string carrier_iata, string carrier_icao, string fl_number, string fl_suffix, string flt, string flr, string sdt, string sdp, string linkedfl_flt,
                string linkedfl_carrier, string linkedfl_number, string linkedfl_suffix, string linkedfl_sdt, string linkedfl_flr, string linkfl_id, string masterfl_carrier,
                string masterfl_number, string masterfl_suffix, string mfdi, string masterfl_flr, string masterfl_id, string aircraft_callsign, string aircraft_owner,
                string aircraft_paxcap, string regn, string atc5, string aircraft_type, string aircraft_operator, string aircraft_terminal, string airport_iata,
                string brc1, string reclaim_role1, string brod, string brcd, string exitdoor1, string src2, string reclaim_role2, string sbro, string sbrc, string exitdoor2,
                string makeup_id1, string makeup_role1, string makeup_open_time1, string makeup_close_time1, string makeup_id2, string makeup_role2, string makeup_open_time2,
                string makeup_close_time2, string isbusrequired, string cc_type1, string ckif, string cc_role1, string cc_clusterid1, string codt, string ccdt, string cc_type2,
                string scdr, string cc_role2, string cc_clusterid2, string scodt, string sccdt, string sgcd, string sgod, string gate_bording_status2, string gate_role2, string sgn,
                string gcdt, string godt, string gbs, string gate_role1, string geno, string term, string remark_code1, string remark_type1, string remark_code2,
                string remark_type2, string remark_code3, string remark_type3, string remark_code4, string remark_type4, string runway_id, string s_info_type1, string s_info_text1,
                string s_info_type2, string s_info_text2, string s_info_type3, string s_info_text3, string s_info_type4, string s_info_text4, string s_info_type5, string s_info_text5,
                string account_code, string fl_classificationcode, string fl_statuscode, string css, string daia, string fl_cancelcode, string fl_operates_overnight, string ttyp,
                string fl_servicetype, string flti, string fl_transitcode, string handlingagent1, string handling_service1, string handlingagent2, string handling_service2, string handlingagent3,
                string handling_service3, string handlingagent4, string handling_service4, string handlingagent5, string handling_service5, string irr_number1, string irr_code1,
                string irr_duration1, string irr_number2, string irr_code2, string irr_duration2, string isgvf, string isreturnfl, string istransferfl, string newfl_reason, string operationtype_code1,
                string transfer_fl1, string transfer_fl2, string transfer_fl3, string transfer_fl4, string transfer_fl5, string transfer_fl6, string transfer_fl7, string transfer_fl8, string transfer_fl9,
                string transfer_fl10, string transfer_fl11, string transfer_fl12, string transfer_fl13, string transfer_fl14, string transfer_fl15, string transfer_fl16, string transfer_fl17,
                string transfer_fl18, string transfer_fl19, string transfer_fl20, string sharefl_flt1, string sharefl_fln1, string sharefl_flt2, string sharefl_fln2, string sharefl_flt3,
                string sharefl_fln3, string sharefl_flt4, string sharefl_fln4, string sharefl_flt5, string sharefl_fln5, string sharefl_flt6, string sharefl_fln6, string total_bagcount,
                string total_bagweight, string total_freightweight, string total_mailweight, string total_loadweight, string adult_paxcount, string bussiness_paxcount, string child_paxcount,
                string domesitec_paxcount, string infant_paxcount, string international_paxcount, string local_paxcount, string nontransfer_paxcount, string total_paxcount,
                string transfer_paxcount, string transit_paxcount, string whellchair_paxcount, string total_crewcount, string economy_paxcount, string firstclass_paxcount,
                string transfer_bagcount, string transfer_bagweight, string transfer_freightweight, string transfer_mailweight, string transit_bagcount, string transit_bagweight,
                string transit_freightweight, string transit_mailweight, string offblock_time, string onblock_time, string edta, string edtd, string e_fl_duration, string firstbag_time,
                string lastbag_time, string finalapproach_time, string lastknown_time, string lastknown_source, string next_info_time, string a_next_station_time, string e_next_station_time,
                string s_next_station_time, string a_prev_station_time, string e_prev_station_time, string s_prev_station_time, string land, string airb, string ten_miles_time,
                string org3, string des3, string org_icao, string des_icao, string via1, string via_icao, string public_flt, string public_flc, string public_time, string secure_stand_is_required,
                string stod, string stpo, string operationtype_code2, string firstbag_time2, string lastbag_time2, string operationtype_role1, string operationtype_role2,
                string update_time, string custom_status, string sub_airline, string ltd, string lta, string airline_terminal, string gate_plan_close_time1, string gate_plan_open_time1,
                string gate_plan_close_time2, string gate_plan_open_time2, string usec, string typc, DateTime cdat, string useu, string typu, DateTime lstu, string jfno, int ctrl, string drct
            )
        {
            string sql = @"UPDATE  [AOCFQS] SET
                                    [URNO] = @urno, [CARRIER_IATA] = @carrier_iata, [CARRIER_ICAO] = @carrier_icao, [FL_NUMBER] = @fl_number, [FL_SUFFIX] = @fl_suffix, [FLT] = @flt, 
                                    [FLR] = @flr, [SDT] = @sdt, [SDP] = @sdp, [LINKEDFL_FLT] = @linkedfl_flt, [LINKEDFL_CARRIER] = @linkedfl_carrier, [LINKEDFL_NUMBER] = @linkedfl_number, 
                                    [LINKEDFL_SUFFIX] = @linkedfl_suffix, [LINKEDFL_SDT] = @linkedfl_sdt, [LINKEDFL_FLR] = @linkedfl_flr, [LINKFL_ID] = @linkfl_id, [MASTERFL_CARRIER] = @masterfl_carrier, 
                                    [MASTERFL_NUMBER] = @masterfl_number, [MASTERFL_SUFFIX] = @masterfl_suffix, [MFDI] = @mfdi, [MASTERFL_FLR] = @masterfl_flr, 
                                    [MASTERFL_ID] = @masterfl_id, [AIRCRAFT_CALLSIGN] = @aircraft_callsign, [AIRCRAFT_OWNER] = @aircraft_owner, [AIRCRAFT_PAXCAP] = @aircraft_paxcap, 
                                    [REGN] = @regn, [ATC5] = @atc5, [AIRCRAFT_TYPE] = @aircraft_type, [AIRCRAFT_OPERATOR] = @aircraft_operator, 
                                    [AIRCRAFT_TERMINAL] = @aircraft_terminal, [AIRPORT_IATA] = @airport_iata, [BRC1] = @brc1, [RECLAIM_ROLE1] = @reclaim_role1, [BROD] = @brod, [BRCD] = @brcd, 
                                    [EXITDOOR1] = @exitdoor1, [SRC2] = @src2, [RECLAIM_ROLE2] = @reclaim_role2, [SBRO] = @sbro, [SBRC] = @sbrc, [EXITDOOR2] = @exitdoor2, [MAKEUP_ID1] = @makeup_id1, 
                                    [MAKEUP_ROLE1] = @makeup_role1, [MAKEUP_OPEN_TIME1] = @makeup_open_time1, [MAKEUP_CLOSE_TIME1] = @makeup_close_time1, [MAKEUP_ID2] = @makeup_id2, 
                                    [MAKEUP_ROLE2] = @makeup_role2, [MAKEUP_OPEN_TIME2] = @makeup_open_time2, [MAKEUP_CLOSE_TIME2] = @makeup_close_time2, [ISBUSREQUIRED] = @isbusrequired, 
                                    [CC_TYPE1] = @cc_type1, [CKIF] = @ckif, [CC_ROLE1] = @cc_role1, [CC_CLUSTERID1] = @cc_clusterid1, [CODT] = @codt, [CCDT] = @ccdt, [CC_TYPE2] = @cc_type2, 
                                    [SCDR] = @scdr, [CC_ROLE2] = @cc_role2, [CC_CLUSTERID2] = @cc_clusterid2, [SCODT] = @scodt, [SCCDT] = @sccdt, [SGCD] = @sgcd, [SGOD] = @sgod, 
                                    [GATE_BORDING_STATUS2] = @gate_bording_status2, [GATE_ROLE2] = @gate_role2, [SGN] = @sgn, [GCDT] = @gcdt, [GODT] = @godt, [GBS] = @gbs, [GATE_ROLE1] = @gate_role1, 
                                    [GENO] = @geno, [TERM] = @term, [REMARK_CODE1] = @remark_code1, [REMARK_TYPE1] = @remark_type1, [REMARK_CODE2] = @remark_code2, 
                                    [REMARK_TYPE2] = @remark_type2, [REMARK_CODE3] = @remark_code3, [REMARK_TYPE3] = @remark_type3, [REMARK_CODE4] = @remark_code4, [REMARK_TYPE4] = @remark_type4, 
                                    [RUNWAY_ID] = @runway_id, [S_INFO_TYPE1] = @s_info_type1, [S_INFO_TEXT1] = @s_info_text1, [S_INFO_TYPE2] = @s_info_type2, [S_INFO_TEXT2] = @s_info_text2, 
                                    [S_INFO_TYPE3] = @s_info_type3, [S_INFO_TEXT3] = @s_info_text3, [S_INFO_TYPE4] = @s_info_type4, [S_INFO_TEXT4] = @s_info_text4, [S_INFO_TYPE5] = @s_info_type5, 
                                    [S_INFO_TEXT5] = @s_info_text5, [ACCOUNT_CODE] = @account_code, [FL_CLASSIFICATIONCODE] = @fl_classificationcode, [FL_STATUSCODE] = @fl_statuscode, [CSS] = @css, 
                                    [DAIA] = @daia, [FL_CANCELCODE] = @fl_cancelcode, [FL_OPERATES_OVERNIGHT] = @fl_operates_overnight, [TTYP] = @ttyp, [FL_SERVICETYPE] = @fl_servicetype, 
                                    [FLTI] = @flti, [FL_TRANSITCODE] = @fl_transitcode, [HANDLINGAGENT1] = @handlingagent1, [HANDLING_SERVICE1] = @handling_service1, [HANDLINGAGENT2] = @handlingagent2, 
                                    [HANDLING_SERVICE2] = @handling_service2, [HANDLINGAGENT3] = @handlingagent3, [HANDLING_SERVICE3] = @handling_service3, [HANDLINGAGENT4] = @handlingagent4, 
                                    [HANDLING_SERVICE4] = @handling_service4, [HANDLINGAGENT5] = @handlingagent5, [HANDLING_SERVICE5] = @handling_service5, [IRR_NUMBER1] = @irr_number1, 
                                    [IRR_CODE1] = @irr_code1, [IRR_DURATION1] = @irr_duration1, [IRR_NUMBER2] = @irr_number2, [IRR_CODE2] = @irr_code2, [IRR_DURATION2] = @irr_duration2, [ISGVF] = @isgvf, 
                                    [ISRETURNFL] = @isreturnfl, [ISTRANSFERFL] = @istransferfl, [NEWFL_REASON] = @newfl_reason, [OPERATIONTYPE_CODE1] = @operationtype_code1, [TRANSFER_FL1] = @transfer_fl1, 
                                    [TRANSFER_FL2] = @transfer_fl2, [TRANSFER_FL3] = @transfer_fl3, [TRANSFER_FL4] = @transfer_fl4, [TRANSFER_FL5] = @transfer_fl5, [TRANSFER_FL6] = @transfer_fl6, 
                                    [TRANSFER_FL7] = @transfer_fl7, [TRANSFER_FL8] = @transfer_fl8, [TRANSFER_FL9] = @transfer_fl9, [TRANSFER_FL10] = @transfer_fl10, [TRANSFER_FL11] = @transfer_fl11, 
                                    [TRANSFER_FL12] = @transfer_fl12, [TRANSFER_FL13] = @transfer_fl13, [TRANSFER_FL14] = @transfer_fl14, [TRANSFER_FL15] = @transfer_fl15, [TRANSFER_FL16] = @transfer_fl16, 
                                    [TRANSFER_FL17] = @transfer_fl17, [TRANSFER_FL18] = @transfer_fl18, [TRANSFER_FL19] = @transfer_fl19, [TRANSFER_FL20] = @transfer_fl20, [SHAREFL_FLT1] = @sharefl_flt1, 
                                    [SHAREFL_FLN1] = @sharefl_fln1, [SHAREFL_FLT2] = @sharefl_flt2, [SHAREFL_FLN2] = @sharefl_fln2, [SHAREFL_FLT3] = @sharefl_flt3, [SHAREFL_FLN3] = @sharefl_fln3, 
                                    [SHAREFL_FLT4] = @sharefl_flt4, [SHAREFL_FLN4] = @sharefl_fln4, [SHAREFL_FLT5] = @sharefl_flt5, [SHAREFL_FLN5] = @sharefl_fln5, [SHAREFL_FLT6] = @sharefl_flt6, 
                                    [SHAREFL_FLN6] = @sharefl_fln6, [TOTAL_BAGCOUNT] = @total_bagcount, [TOTAL_BAGWEIGHT] = @total_bagweight, [TOTAL_FREIGHTWEIGHT] = @total_freightweight, 
                                    [TOTAL_MAILWEIGHT] = @total_mailweight, [TOTAL_LOADWEIGHT] = @total_loadweight, [ADULT_PAXCOUNT] = @adult_paxcount, [BUSSINESS_PAXCOUNT] = @bussiness_paxcount, 
                                    [CHILD_PAXCOUNT] = @child_paxcount, [DOMESITEC_PAXCOUNT] = @domesitec_paxcount, [INFANT_PAXCOUNT] = @infant_paxcount, 
                                    [INTERNATIONAL_PAXCOUNT] = @international_paxcount, [LOCAL_PAXCOUNT] = @local_paxcount, [NONTRANSFER_PAXCOUNT] = @nontransfer_paxcount, 
                                    [TOTAL_PAXCOUNT] = @total_paxcount, [TRANSFER_PAXCOUNT] = @transfer_paxcount, [TRANSIT_PAXCOUNT] = @transit_paxcount, 
                                    [WHELLCHAIR_PAXCOUNT] = @whellchair_paxcount, [TOTAL_CREWCOUNT] = @total_crewcount, [ECONOMY_PAXCOUNT] = @economy_paxcount, 
                                    [FIRSTCLASS_PAXCOUNT] = @firstclass_paxcount, [TRANSFER_BAGCOUNT] = @transfer_bagcount, [TRANSFER_BAGWEIGHT] = @transfer_bagweight, 
                                    [TRANSFER_FREIGHTWEIGHT] = @transfer_freightweight, [TRANSFER_MAILWEIGHT] = @transfer_mailweight, [TRANSIT_BAGCOUNT] = @transit_bagcount, 
                                    [TRANSIT_BAGWEIGHT] = @transit_bagweight, [TRANSIT_FREIGHTWEIGHT] = @transit_freightweight, [TRANSIT_MAILWEIGHT] = @transit_mailweight, 
                                    [OFFBLOCK_TIME] = @offblock_time, [ONBLOCK_TIME] = @onblock_time, [EDTA] = @edta, [EDTD] = @edtd, [E_FL_DURATION] = @e_fl_duration, 
                                    [FIRSTBAG_TIME] = @firstbag_time, [LASTBAG_TIME] = @lastbag_time, [FINALAPPROACH_TIME] = @finalapproach_time, [LASTKNOWN_TIME] = @lastknown_time, 
                                    [LASTKNOWN_SOURCE] = @lastknown_source, [NEXT_INFO_TIME] = @next_info_time, [A_NEXT_STATION_TIME] = @a_next_station_time, 
                                    [E_NEXT_STATION_TIME] = @e_next_station_time, [S_NEXT_STATION_TIME] = @s_next_station_time, [A_PREV_STATION_TIME] = @a_prev_station_time, 
                                    [E_PREV_STATION_TIME] = @e_prev_station_time, [S_PREV_STATION_TIME] = @s_prev_station_time, [LAND] = @land, [AIRB] = @airb, [TEN_MILES_TIME] = @ten_miles_time, 
                                    [ORG3] = @org3, [DES3] = @des3, [ORG_ICAO] = @org_icao, [DES_ICAO] = @des_icao, [VIA1] = @via1, [VIA_ICAO] = @via_icao, [PUBLIC_FLT] = @public_flt, 
                                    [PUBLIC_FLC] = @public_flc, [PUBLIC_TIME] = @public_time, [SECURE_STAND_IS_REQUIRED] = @secure_stand_is_required, [STOD] = @stod, [STPO] = @stpo, 
                                    [OPERATIONTYPE_CODE2] = @operationtype_code2, [FIRSTBAG_TIME2] = @firstbag_time2, [LASTBAG_TIME2] = @lastbag_time2, [OPERATIONTYPE_ROLE1] = @operationtype_role1, 
                                    [OPERATIONTYPE_ROLE2] = @operationtype_role2, [UPDATE_TIME] = @update_time, [CUSTOM_STATUS] = @custom_status, [SUB_AIRLINE] = @sub_airline, [LTD] = @ltd, 
                                    [LTA] = @lta, [AIRLINE_TERMINAL] = @airline_terminal, [GATE_PLAN_CLOSE_TIME1] = @gate_plan_close_time1, [GATE_PLAN_OPEN_TIME1] = @gate_plan_open_time1, 
                                    [GATE_PLAN_CLOSE_TIME2] = @gate_plan_close_time2, [GATE_PLAN_OPEN_TIME2] = @gate_plan_open_time2, [USEC] = @usec,  [DRCT]=@drct， [USEU] = @useu, [TYPU] = @typu, [LSTU] = @lstu, [JFNO] = @jfno, [CTRL] = @ctrl ,[DRCT] = @drct
                            WHERE     ID = @id";

            SqlParameter[] para = new SqlParameter[239];
            para[0] = new SqlParameter("@id", id);
            para[1] = new SqlParameter("@urno", urno);
            para[2] = new SqlParameter("@carrier_iata", carrier_iata);
            para[3] = new SqlParameter("@carrier_icao", carrier_icao);
            para[4] = new SqlParameter("@fl_number", fl_number);
            para[5] = new SqlParameter("@fl_suffix", fl_suffix);
            para[6] = new SqlParameter("@flt", flt);
            para[7] = new SqlParameter("@flr", flr);
            para[8] = new SqlParameter("@sdt", sdt);
            para[9] = new SqlParameter("@sdp", sdp);
            para[10] = new SqlParameter("@linkedfl_flt", linkedfl_flt);
            para[11] = new SqlParameter("@linkedfl_carrier", linkedfl_carrier);
            para[12] = new SqlParameter("@linkedfl_number", linkedfl_number);
            para[13] = new SqlParameter("@linkedfl_suffix", linkedfl_suffix);
            para[14] = new SqlParameter("@linkedfl_sdt", linkedfl_sdt);
            para[15] = new SqlParameter("@linkedfl_flr", linkedfl_flr);
            para[16] = new SqlParameter("@linkfl_id", linkfl_id);
            para[17] = new SqlParameter("@masterfl_carrier", masterfl_carrier);
            para[18] = new SqlParameter("@masterfl_number", masterfl_number);
            para[19] = new SqlParameter("@masterfl_suffix", masterfl_suffix);
            para[20] = new SqlParameter("@mfdi", mfdi);
            para[21] = new SqlParameter("@masterfl_flr", masterfl_flr);
            para[22] = new SqlParameter("@masterfl_id", masterfl_id);
            para[23] = new SqlParameter("@aircraft_callsign", aircraft_callsign);
            para[24] = new SqlParameter("@aircraft_owner", aircraft_owner);
            para[25] = new SqlParameter("@aircraft_paxcap", aircraft_paxcap);
            para[26] = new SqlParameter("@regn", regn);
            para[27] = new SqlParameter("@atc5", atc5);
            para[28] = new SqlParameter("@aircraft_type", aircraft_type);
            para[29] = new SqlParameter("@aircraft_operator", aircraft_operator);
            para[30] = new SqlParameter("@aircraft_terminal", aircraft_terminal);
            para[31] = new SqlParameter("@airport_iata", airport_iata);
            para[32] = new SqlParameter("@brc1", brc1);
            para[33] = new SqlParameter("@reclaim_role1", reclaim_role1);
            para[34] = new SqlParameter("@brod", brod);
            para[35] = new SqlParameter("@brcd", brcd);
            para[36] = new SqlParameter("@exitdoor1", exitdoor1);
            para[37] = new SqlParameter("@src2", src2);
            para[38] = new SqlParameter("@reclaim_role2", reclaim_role2);
            para[39] = new SqlParameter("@sbro", sbro);
            para[40] = new SqlParameter("@sbrc", sbrc);
            para[41] = new SqlParameter("@exitdoor2", exitdoor2);
            para[42] = new SqlParameter("@makeup_id1", makeup_id1);
            para[43] = new SqlParameter("@makeup_role1", makeup_role1);
            para[44] = new SqlParameter("@makeup_open_time1", makeup_open_time1);
            para[45] = new SqlParameter("@makeup_close_time1", makeup_close_time1);
            para[46] = new SqlParameter("@makeup_id2", makeup_id2);
            para[47] = new SqlParameter("@makeup_role2", makeup_role2);
            para[48] = new SqlParameter("@makeup_open_time2", makeup_open_time2);
            para[49] = new SqlParameter("@makeup_close_time2", makeup_close_time2);
            para[50] = new SqlParameter("@isbusrequired", isbusrequired);
            para[51] = new SqlParameter("@cc_type1", cc_type1);
            para[52] = new SqlParameter("@ckif", ckif);
            para[53] = new SqlParameter("@cc_role1", cc_role1);
            para[54] = new SqlParameter("@cc_clusterid1", cc_clusterid1);
            para[55] = new SqlParameter("@codt", codt);
            para[56] = new SqlParameter("@ccdt", ccdt);
            para[57] = new SqlParameter("@cc_type2", cc_type2);
            para[58] = new SqlParameter("@scdr", scdr);
            para[59] = new SqlParameter("@cc_role2", cc_role2);
            para[60] = new SqlParameter("@cc_clusterid2", cc_clusterid2);
            para[61] = new SqlParameter("@scodt", scodt);
            para[62] = new SqlParameter("@sccdt", sccdt);
            para[63] = new SqlParameter("@sgcd", sgcd);
            para[64] = new SqlParameter("@sgod", sgod);
            para[65] = new SqlParameter("@gate_bording_status2", gate_bording_status2);
            para[66] = new SqlParameter("@gate_role2", gate_role2);
            para[67] = new SqlParameter("@sgn", sgn);
            para[68] = new SqlParameter("@gcdt", gcdt);
            para[69] = new SqlParameter("@godt", godt);
            para[70] = new SqlParameter("@gbs", gbs);
            para[71] = new SqlParameter("@gate_role1", gate_role1);
            para[72] = new SqlParameter("@geno", geno);
            para[73] = new SqlParameter("@term", term);
            para[74] = new SqlParameter("@remark_code1", remark_code1);
            para[75] = new SqlParameter("@remark_type1", remark_type1);
            para[76] = new SqlParameter("@remark_code2", remark_code2);
            para[77] = new SqlParameter("@remark_type2", remark_type2);
            para[78] = new SqlParameter("@remark_code3", remark_code3);
            para[79] = new SqlParameter("@remark_type3", remark_type3);
            para[80] = new SqlParameter("@remark_code4", remark_code4);
            para[81] = new SqlParameter("@remark_type4", remark_type4);
            para[82] = new SqlParameter("@runway_id", runway_id);
            para[83] = new SqlParameter("@s_info_type1", s_info_type1);
            para[84] = new SqlParameter("@s_info_text1", s_info_text1);
            para[85] = new SqlParameter("@s_info_type2", s_info_type2);
            para[86] = new SqlParameter("@s_info_text2", s_info_text2);
            para[87] = new SqlParameter("@s_info_type3", s_info_type3);
            para[88] = new SqlParameter("@s_info_text3", s_info_text3);
            para[89] = new SqlParameter("@s_info_type4", s_info_type4);
            para[90] = new SqlParameter("@s_info_text4", s_info_text4);
            para[91] = new SqlParameter("@s_info_type5", s_info_type5);
            para[92] = new SqlParameter("@s_info_text5", s_info_text5);
            para[93] = new SqlParameter("@account_code", account_code);
            para[94] = new SqlParameter("@fl_classificationcode", fl_classificationcode);
            para[95] = new SqlParameter("@fl_statuscode", fl_statuscode);
            para[96] = new SqlParameter("@css", css);
            para[97] = new SqlParameter("@daia", daia);
            para[98] = new SqlParameter("@fl_cancelcode", fl_cancelcode);
            para[99] = new SqlParameter("@fl_operates_overnight", fl_operates_overnight);
            para[100] = new SqlParameter("@ttyp", ttyp);
            para[101] = new SqlParameter("@fl_servicetype", fl_servicetype);
            para[102] = new SqlParameter("@flti", flti);
            para[103] = new SqlParameter("@fl_transitcode", fl_transitcode);
            para[104] = new SqlParameter("@handlingagent1", handlingagent1);
            para[105] = new SqlParameter("@handling_service1", handling_service1);
            para[106] = new SqlParameter("@handlingagent2", handlingagent2);
            para[107] = new SqlParameter("@handling_service2", handling_service2);
            para[108] = new SqlParameter("@handlingagent3", handlingagent3);
            para[109] = new SqlParameter("@handling_service3", handling_service3);
            para[110] = new SqlParameter("@handlingagent4", handlingagent4);
            para[111] = new SqlParameter("@handling_service4", handling_service4);
            para[112] = new SqlParameter("@handlingagent5", handlingagent5);
            para[113] = new SqlParameter("@handling_service5", handling_service5);
            para[114] = new SqlParameter("@irr_number1", irr_number1);
            para[115] = new SqlParameter("@irr_code1", irr_code1);
            para[116] = new SqlParameter("@irr_duration1", irr_duration1);
            para[117] = new SqlParameter("@irr_number2", irr_number2);
            para[118] = new SqlParameter("@irr_code2", irr_code2);
            para[119] = new SqlParameter("@irr_duration2", irr_duration2);
            para[120] = new SqlParameter("@isgvf", isgvf);
            para[121] = new SqlParameter("@isreturnfl", isreturnfl);
            para[122] = new SqlParameter("@istransferfl", istransferfl);
            para[123] = new SqlParameter("@newfl_reason", newfl_reason);
            para[124] = new SqlParameter("@operationtype_code1", operationtype_code1);
            para[125] = new SqlParameter("@transfer_fl1", transfer_fl1);
            para[126] = new SqlParameter("@transfer_fl2", transfer_fl2);
            para[127] = new SqlParameter("@transfer_fl3", transfer_fl3);
            para[128] = new SqlParameter("@transfer_fl4", transfer_fl4);
            para[129] = new SqlParameter("@transfer_fl5", transfer_fl5);
            para[130] = new SqlParameter("@transfer_fl6", transfer_fl6);
            para[131] = new SqlParameter("@transfer_fl7", transfer_fl7);
            para[132] = new SqlParameter("@transfer_fl8", transfer_fl8);
            para[133] = new SqlParameter("@transfer_fl9", transfer_fl9);
            para[134] = new SqlParameter("@transfer_fl10", transfer_fl10);
            para[135] = new SqlParameter("@transfer_fl11", transfer_fl11);
            para[136] = new SqlParameter("@transfer_fl12", transfer_fl12);
            para[137] = new SqlParameter("@transfer_fl13", transfer_fl13);
            para[138] = new SqlParameter("@transfer_fl14", transfer_fl14);
            para[139] = new SqlParameter("@transfer_fl15", transfer_fl15);
            para[140] = new SqlParameter("@transfer_fl16", transfer_fl16);
            para[141] = new SqlParameter("@transfer_fl17", transfer_fl17);
            para[142] = new SqlParameter("@transfer_fl18", transfer_fl18);
            para[143] = new SqlParameter("@transfer_fl19", transfer_fl19);
            para[144] = new SqlParameter("@transfer_fl20", transfer_fl20);
            para[145] = new SqlParameter("@sharefl_flt1", sharefl_flt1);
            para[146] = new SqlParameter("@sharefl_fln1", sharefl_fln1);
            para[147] = new SqlParameter("@sharefl_flt2", sharefl_flt2);
            para[148] = new SqlParameter("@sharefl_fln2", sharefl_fln2);
            para[149] = new SqlParameter("@sharefl_flt3", sharefl_flt3);
            para[150] = new SqlParameter("@sharefl_fln3", sharefl_fln3);
            para[151] = new SqlParameter("@sharefl_flt4", sharefl_flt4);
            para[152] = new SqlParameter("@sharefl_fln4", sharefl_fln4);
            para[153] = new SqlParameter("@sharefl_flt5", sharefl_flt5);
            para[154] = new SqlParameter("@sharefl_fln5", sharefl_fln5);
            para[155] = new SqlParameter("@sharefl_flt6", sharefl_flt6);
            para[156] = new SqlParameter("@sharefl_fln6", sharefl_fln6);
            para[157] = new SqlParameter("@total_bagcount", total_bagcount);
            para[158] = new SqlParameter("@total_bagweight", total_bagweight);
            para[159] = new SqlParameter("@total_freightweight", total_freightweight);
            para[160] = new SqlParameter("@total_mailweight", total_mailweight);
            para[161] = new SqlParameter("@total_loadweight", total_loadweight);
            para[162] = new SqlParameter("@adult_paxcount", adult_paxcount);
            para[163] = new SqlParameter("@bussiness_paxcount", bussiness_paxcount);
            para[164] = new SqlParameter("@child_paxcount", child_paxcount);
            para[165] = new SqlParameter("@domesitec_paxcount", domesitec_paxcount);
            para[166] = new SqlParameter("@infant_paxcount", infant_paxcount);
            para[167] = new SqlParameter("@international_paxcount", international_paxcount);
            para[168] = new SqlParameter("@local_paxcount", local_paxcount);
            para[169] = new SqlParameter("@nontransfer_paxcount", nontransfer_paxcount);
            para[170] = new SqlParameter("@total_paxcount", total_paxcount);
            para[171] = new SqlParameter("@transfer_paxcount", transfer_paxcount);
            para[172] = new SqlParameter("@transit_paxcount", transit_paxcount);
            para[173] = new SqlParameter("@whellchair_paxcount", whellchair_paxcount);
            para[174] = new SqlParameter("@total_crewcount", total_crewcount);
            para[175] = new SqlParameter("@economy_paxcount", economy_paxcount);
            para[176] = new SqlParameter("@firstclass_paxcount", firstclass_paxcount);
            para[177] = new SqlParameter("@transfer_bagcount", transfer_bagcount);
            para[178] = new SqlParameter("@transfer_bagweight", transfer_bagweight);
            para[179] = new SqlParameter("@transfer_freightweight", transfer_freightweight);
            para[180] = new SqlParameter("@transfer_mailweight", transfer_mailweight);
            para[181] = new SqlParameter("@transit_bagcount", transit_bagcount);
            para[182] = new SqlParameter("@transit_bagweight", transit_bagweight);
            para[183] = new SqlParameter("@transit_freightweight", transit_freightweight);
            para[184] = new SqlParameter("@transit_mailweight", transit_mailweight);
            para[185] = new SqlParameter("@offblock_time", offblock_time);
            para[186] = new SqlParameter("@onblock_time", onblock_time);
            para[187] = new SqlParameter("@edta", edta);
            para[188] = new SqlParameter("@edtd", edtd);
            para[189] = new SqlParameter("@e_fl_duration", e_fl_duration);
            para[190] = new SqlParameter("@firstbag_time", firstbag_time);
            para[191] = new SqlParameter("@lastbag_time", lastbag_time);
            para[192] = new SqlParameter("@finalapproach_time", finalapproach_time);
            para[193] = new SqlParameter("@lastknown_time", lastknown_time);
            para[194] = new SqlParameter("@lastknown_source", lastknown_source);
            para[195] = new SqlParameter("@next_info_time", next_info_time);
            para[196] = new SqlParameter("@a_next_station_time", a_next_station_time);
            para[197] = new SqlParameter("@e_next_station_time", e_next_station_time);
            para[198] = new SqlParameter("@s_next_station_time", s_next_station_time);
            para[199] = new SqlParameter("@a_prev_station_time", a_prev_station_time);
            para[200] = new SqlParameter("@e_prev_station_time", e_prev_station_time);
            para[201] = new SqlParameter("@s_prev_station_time", s_prev_station_time);
            para[202] = new SqlParameter("@land", land);
            para[203] = new SqlParameter("@airb", airb);
            para[204] = new SqlParameter("@ten_miles_time", ten_miles_time);
            para[205] = new SqlParameter("@org3", org3);
            para[206] = new SqlParameter("@des3", des3);
            para[207] = new SqlParameter("@org_icao", org_icao);
            para[208] = new SqlParameter("@des_icao", des_icao);
            para[209] = new SqlParameter("@via1", via1);
            para[210] = new SqlParameter("@via_icao", via_icao);
            para[211] = new SqlParameter("@public_flt", public_flt);
            para[212] = new SqlParameter("@public_flc", public_flc);
            para[213] = new SqlParameter("@public_time", public_time);
            para[214] = new SqlParameter("@secure_stand_is_required", secure_stand_is_required);
            para[215] = new SqlParameter("@stod", stod);
            para[216] = new SqlParameter("@stpo", stpo);
            para[217] = new SqlParameter("@operationtype_code2", operationtype_code2);
            para[218] = new SqlParameter("@firstbag_time2", firstbag_time2);
            para[219] = new SqlParameter("@lastbag_time2", lastbag_time2);
            para[220] = new SqlParameter("@operationtype_role1", operationtype_role1);
            para[221] = new SqlParameter("@operationtype_role2", operationtype_role2);
            para[222] = new SqlParameter("@update_time", update_time);
            para[223] = new SqlParameter("@custom_status", custom_status);
            para[224] = new SqlParameter("@sub_airline", sub_airline);
            para[225] = new SqlParameter("@ltd", ltd);
            para[226] = new SqlParameter("@lta", lta);
            para[227] = new SqlParameter("@airline_terminal", airline_terminal);
            para[228] = new SqlParameter("@gate_plan_close_time1", gate_plan_close_time1);
            para[229] = new SqlParameter("@gate_plan_open_time1", gate_plan_open_time1);
            para[230] = new SqlParameter("@gate_plan_close_time2", gate_plan_close_time2);
            para[231] = new SqlParameter("@gate_plan_open_time2", gate_plan_open_time2);
            para[232] = new SqlParameter("@usec", usec);
            para[233] = new SqlParameter("@useu", useu);
            para[234] = new SqlParameter("@typu", typu);
            para[235] = new SqlParameter("@lstu", lstu);
            para[236] = new SqlParameter("@jfno", jfno);
            para[237] = new SqlParameter("@ctrl", ctrl);
            para[238] = new SqlParameter("@drct", drct);


            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void UpdateAOCData(
                Guid id,
                string urno, string carrier_iata, string carrier_icao, string fl_number, string fl_suffix, string flt, string flr, string sdt, string sdp, string linkedfl_flt,
                string linkedfl_carrier, string linkedfl_number, string linkedfl_suffix, string linkedfl_sdt, string linkedfl_flr, string linkfl_id, string masterfl_carrier,
                string masterfl_number, string masterfl_suffix, string mfdi, string masterfl_flr, string masterfl_id, string aircraft_callsign, string aircraft_owner,
                string aircraft_paxcap, string regn, string atc5, string aircraft_type, string aircraft_operator, string aircraft_terminal, string airport_iata,
                string brc1, string reclaim_role1, string brod, string brcd, string exitdoor1, string src2, string reclaim_role2, string sbro, string sbrc, string exitdoor2,
                string makeup_id1, string makeup_role1, string makeup_open_time1, string makeup_close_time1, string makeup_id2, string makeup_role2, string makeup_open_time2,
                string makeup_close_time2, string isbusrequired, string cc_type1, string ckif, string cc_role1, string cc_clusterid1, string codt, string ccdt, string cc_type2,
                string scdr, string cc_role2, string cc_clusterid2, string scodt, string sccdt, string sgcd, string sgod, string gate_bording_status2, string gate_role2, string sgn,
                string gcdt, string godt, string gbs, string gate_role1, string geno, string term, string remark_code1, string remark_type1, string remark_code2,
                string remark_type2, string remark_code3, string remark_type3, string remark_code4, string remark_type4, string runway_id, string s_info_type1, string s_info_text1,
                string s_info_type2, string s_info_text2, string s_info_type3, string s_info_text3, string s_info_type4, string s_info_text4, string s_info_type5, string s_info_text5,
                string account_code, string fl_classificationcode, string fl_statuscode, string css, string daia, string fl_cancelcode, string fl_operates_overnight, string ttyp,
                string fl_servicetype, string flti, string fl_transitcode, string handlingagent1, string handling_service1, string handlingagent2, string handling_service2, string handlingagent3,
                string handling_service3, string handlingagent4, string handling_service4, string handlingagent5, string handling_service5, string irr_number1, string irr_code1,
                string irr_duration1, string irr_number2, string irr_code2, string irr_duration2, string isgvf, string isreturnfl, string istransferfl, string newfl_reason, string operationtype_code1,
                string transfer_fl1, string transfer_fl2, string transfer_fl3, string transfer_fl4, string transfer_fl5, string transfer_fl6, string transfer_fl7, string transfer_fl8, string transfer_fl9,
                string transfer_fl10, string transfer_fl11, string transfer_fl12, string transfer_fl13, string transfer_fl14, string transfer_fl15, string transfer_fl16, string transfer_fl17,
                string transfer_fl18, string transfer_fl19, string transfer_fl20, string sharefl_flt1, string sharefl_fln1, string sharefl_flt2, string sharefl_fln2, string sharefl_flt3,
                string sharefl_fln3, string sharefl_flt4, string sharefl_fln4, string sharefl_flt5, string sharefl_fln5, string sharefl_flt6, string sharefl_fln6, string total_bagcount,
                string total_bagweight, string total_freightweight, string total_mailweight, string total_loadweight, string adult_paxcount, string bussiness_paxcount, string child_paxcount,
                string domesitec_paxcount, string infant_paxcount, string international_paxcount, string local_paxcount, string nontransfer_paxcount, string total_paxcount,
                string transfer_paxcount, string transit_paxcount, string whellchair_paxcount, string total_crewcount, string economy_paxcount, string firstclass_paxcount,
                string transfer_bagcount, string transfer_bagweight, string transfer_freightweight, string transfer_mailweight, string transit_bagcount, string transit_bagweight,
                string transit_freightweight, string transit_mailweight, string offblock_time, string onblock_time, string edta, string edtd, string e_fl_duration, string firstbag_time,
                string lastbag_time, string finalapproach_time, string lastknown_time, string lastknown_source, string next_info_time, string a_next_station_time, string e_next_station_time,
                string s_next_station_time, string a_prev_station_time, string e_prev_station_time, string s_prev_station_time, string land, string airb, string ten_miles_time,
                string org3, string des3, string org_icao, string des_icao, string via1, string via_icao, string public_flt, string public_flc, string public_time, string secure_stand_is_required,
                string stod, string stpo, string operationtype_code2, string firstbag_time2, string lastbag_time2, string operationtype_role1, string operationtype_role2,
                string update_time, string custom_status, string sub_airline, string ltd, string lta, string airline_terminal, string gate_plan_close_time1, string gate_plan_open_time1,
                string gate_plan_close_time2, string gate_plan_open_time2, string usec, string typc, DateTime cdat, string useu, string typu, DateTime lstu, string jfno, int ctrl, string drct,
                SqlTransaction trans
            )
        {
            string sql = @"UPDATE  [AOCFQS] SET
                                    [URNO] = @urno, [CARRIER_IATA] = @carrier_iata, [CARRIER_ICAO] = @carrier_icao, [FL_NUMBER] = @fl_number, [FL_SUFFIX] = @fl_suffix, [FLT] = @flt, 
                                    [FLR] = @flr, [SDT] = @sdt, [SDP] = @sdp, [LINKEDFL_FLT] = @linkedfl_flt, [LINKEDFL_CARRIER] = @linkedfl_carrier, [LINKEDFL_NUMBER] = @linkedfl_number, 
                                    [LINKEDFL_SUFFIX] = @linkedfl_suffix, [LINKEDFL_SDT] = @linkedfl_sdt, [LINKEDFL_FLR] = @linkedfl_flr, [LINKFL_ID] = @linkfl_id, [MASTERFL_CARRIER] = @masterfl_carrier, 
                                    [MASTERFL_NUMBER] = @masterfl_number, [MASTERFL_SUFFIX] = @masterfl_suffix, [MFDI] = @mfdi, [MASTERFL_FLR] = @masterfl_flr, 
                                    [MASTERFL_ID] = @masterfl_id, [AIRCRAFT_CALLSIGN] = @aircraft_callsign, [AIRCRAFT_OWNER] = @aircraft_owner, [AIRCRAFT_PAXCAP] = @aircraft_paxcap, 
                                    [REGN] = @regn, [ATC5] = @atc5, [AIRCRAFT_TYPE] = @aircraft_type, [AIRCRAFT_OPERATOR] = @aircraft_operator, 
                                    [AIRCRAFT_TERMINAL] = @aircraft_terminal, [AIRPORT_IATA] = @airport_iata, [BRC1] = @brc1, [RECLAIM_ROLE1] = @reclaim_role1, [BROD] = @brod, [BRCD] = @brcd, 
                                    [EXITDOOR1] = @exitdoor1, [SRC2] = @src2, [RECLAIM_ROLE2] = @reclaim_role2, [SBRO] = @sbro, [SBRC] = @sbrc, [EXITDOOR2] = @exitdoor2, [MAKEUP_ID1] = @makeup_id1, 
                                    [MAKEUP_ROLE1] = @makeup_role1, [MAKEUP_OPEN_TIME1] = @makeup_open_time1, [MAKEUP_CLOSE_TIME1] = @makeup_close_time1, [MAKEUP_ID2] = @makeup_id2, 
                                    [MAKEUP_ROLE2] = @makeup_role2, [MAKEUP_OPEN_TIME2] = @makeup_open_time2, [MAKEUP_CLOSE_TIME2] = @makeup_close_time2, [ISBUSREQUIRED] = @isbusrequired, 
                                    [CC_TYPE1] = @cc_type1, [CKIF] = @ckif, [CC_ROLE1] = @cc_role1, [CC_CLUSTERID1] = @cc_clusterid1, [CODT] = @codt, [CCDT] = @ccdt, [CC_TYPE2] = @cc_type2, 
                                    [SCDR] = @scdr, [CC_ROLE2] = @cc_role2, [CC_CLUSTERID2] = @cc_clusterid2, [SCODT] = @scodt, [SCCDT] = @sccdt, [SGCD] = @sgcd, [SGOD] = @sgod, 
                                    [GATE_BORDING_STATUS2] = @gate_bording_status2, [GATE_ROLE2] = @gate_role2, [SGN] = @sgn, [GCDT] = @gcdt, [GODT] = @godt, [GBS] = @gbs, [GATE_ROLE1] = @gate_role1, 
                                    [GENO] = @geno, [TERM] = @term, [REMARK_CODE1] = @remark_code1, [REMARK_TYPE1] = @remark_type1, [REMARK_CODE2] = @remark_code2, 
                                    [REMARK_TYPE2] = @remark_type2, [REMARK_CODE3] = @remark_code3, [REMARK_TYPE3] = @remark_type3, [REMARK_CODE4] = @remark_code4, [REMARK_TYPE4] = @remark_type4, 
                                    [RUNWAY_ID] = @runway_id, [S_INFO_TYPE1] = @s_info_type1, [S_INFO_TEXT1] = @s_info_text1, [S_INFO_TYPE2] = @s_info_type2, [S_INFO_TEXT2] = @s_info_text2, 
                                    [S_INFO_TYPE3] = @s_info_type3, [S_INFO_TEXT3] = @s_info_text3, [S_INFO_TYPE4] = @s_info_type4, [S_INFO_TEXT4] = @s_info_text4, [S_INFO_TYPE5] = @s_info_type5, 
                                    [S_INFO_TEXT5] = @s_info_text5, [ACCOUNT_CODE] = @account_code, [FL_CLASSIFICATIONCODE] = @fl_classificationcode, [FL_STATUSCODE] = @fl_statuscode, [CSS] = @css, 
                                    [DAIA] = @daia, [FL_CANCELCODE] = @fl_cancelcode, [FL_OPERATES_OVERNIGHT] = @fl_operates_overnight, [TTYP] = @ttyp, [FL_SERVICETYPE] = @fl_servicetype, 
                                    [FLTI] = @flti, [FL_TRANSITCODE] = @fl_transitcode, [HANDLINGAGENT1] = @handlingagent1, [HANDLING_SERVICE1] = @handling_service1, [HANDLINGAGENT2] = @handlingagent2, 
                                    [HANDLING_SERVICE2] = @handling_service2, [HANDLINGAGENT3] = @handlingagent3, [HANDLING_SERVICE3] = @handling_service3, [HANDLINGAGENT4] = @handlingagent4, 
                                    [HANDLING_SERVICE4] = @handling_service4, [HANDLINGAGENT5] = @handlingagent5, [HANDLING_SERVICE5] = @handling_service5, [IRR_NUMBER1] = @irr_number1, 
                                    [IRR_CODE1] = @irr_code1, [IRR_DURATION1] = @irr_duration1, [IRR_NUMBER2] = @irr_number2, [IRR_CODE2] = @irr_code2, [IRR_DURATION2] = @irr_duration2, [ISGVF] = @isgvf, 
                                    [ISRETURNFL] = @isreturnfl, [ISTRANSFERFL] = @istransferfl, [NEWFL_REASON] = @newfl_reason, [OPERATIONTYPE_CODE1] = @operationtype_code1, [TRANSFER_FL1] = @transfer_fl1, 
                                    [TRANSFER_FL2] = @transfer_fl2, [TRANSFER_FL3] = @transfer_fl3, [TRANSFER_FL4] = @transfer_fl4, [TRANSFER_FL5] = @transfer_fl5, [TRANSFER_FL6] = @transfer_fl6, 
                                    [TRANSFER_FL7] = @transfer_fl7, [TRANSFER_FL8] = @transfer_fl8, [TRANSFER_FL9] = @transfer_fl9, [TRANSFER_FL10] = @transfer_fl10, [TRANSFER_FL11] = @transfer_fl11, 
                                    [TRANSFER_FL12] = @transfer_fl12, [TRANSFER_FL13] = @transfer_fl13, [TRANSFER_FL14] = @transfer_fl14, [TRANSFER_FL15] = @transfer_fl15, [TRANSFER_FL16] = @transfer_fl16, 
                                    [TRANSFER_FL17] = @transfer_fl17, [TRANSFER_FL18] = @transfer_fl18, [TRANSFER_FL19] = @transfer_fl19, [TRANSFER_FL20] = @transfer_fl20, [SHAREFL_FLT1] = @sharefl_flt1, 
                                    [SHAREFL_FLN1] = @sharefl_fln1, [SHAREFL_FLT2] = @sharefl_flt2, [SHAREFL_FLN2] = @sharefl_fln2, [SHAREFL_FLT3] = @sharefl_flt3, [SHAREFL_FLN3] = @sharefl_fln3, 
                                    [SHAREFL_FLT4] = @sharefl_flt4, [SHAREFL_FLN4] = @sharefl_fln4, [SHAREFL_FLT5] = @sharefl_flt5, [SHAREFL_FLN5] = @sharefl_fln5, [SHAREFL_FLT6] = @sharefl_flt6, 
                                    [SHAREFL_FLN6] = @sharefl_fln6, [TOTAL_BAGCOUNT] = @total_bagcount, [TOTAL_BAGWEIGHT] = @total_bagweight, [TOTAL_FREIGHTWEIGHT] = @total_freightweight, 
                                    [TOTAL_MAILWEIGHT] = @total_mailweight, [TOTAL_LOADWEIGHT] = @total_loadweight, [ADULT_PAXCOUNT] = @adult_paxcount, [BUSSINESS_PAXCOUNT] = @bussiness_paxcount, 
                                    [CHILD_PAXCOUNT] = @child_paxcount, [DOMESITEC_PAXCOUNT] = @domesitec_paxcount, [INFANT_PAXCOUNT] = @infant_paxcount, 
                                    [INTERNATIONAL_PAXCOUNT] = @international_paxcount, [LOCAL_PAXCOUNT] = @local_paxcount, [NONTRANSFER_PAXCOUNT] = @nontransfer_paxcount, 
                                    [TOTAL_PAXCOUNT] = @total_paxcount, [TRANSFER_PAXCOUNT] = @transfer_paxcount, [TRANSIT_PAXCOUNT] = @transit_paxcount, 
                                    [WHELLCHAIR_PAXCOUNT] = @whellchair_paxcount, [TOTAL_CREWCOUNT] = @total_crewcount, [ECONOMY_PAXCOUNT] = @economy_paxcount, 
                                    [FIRSTCLASS_PAXCOUNT] = @firstclass_paxcount, [TRANSFER_BAGCOUNT] = @transfer_bagcount, [TRANSFER_BAGWEIGHT] = @transfer_bagweight, 
                                    [TRANSFER_FREIGHTWEIGHT] = @transfer_freightweight, [TRANSFER_MAILWEIGHT] = @transfer_mailweight, [TRANSIT_BAGCOUNT] = @transit_bagcount, 
                                    [TRANSIT_BAGWEIGHT] = @transit_bagweight, [TRANSIT_FREIGHTWEIGHT] = @transit_freightweight, [TRANSIT_MAILWEIGHT] = @transit_mailweight, 
                                    [OFFBLOCK_TIME] = @offblock_time, [ONBLOCK_TIME] = @onblock_time, [EDTA] = @edta, [EDTD] = @edtd, [E_FL_DURATION] = @e_fl_duration, 
                                    [FIRSTBAG_TIME] = @firstbag_time, [LASTBAG_TIME] = @lastbag_time, [FINALAPPROACH_TIME] = @finalapproach_time, [LASTKNOWN_TIME] = @lastknown_time, 
                                    [LASTKNOWN_SOURCE] = @lastknown_source, [NEXT_INFO_TIME] = @next_info_time, [A_NEXT_STATION_TIME] = @a_next_station_time, 
                                    [E_NEXT_STATION_TIME] = @e_next_station_time, [S_NEXT_STATION_TIME] = @s_next_station_time, [A_PREV_STATION_TIME] = @a_prev_station_time, 
                                    [E_PREV_STATION_TIME] = @e_prev_station_time, [S_PREV_STATION_TIME] = @s_prev_station_time, [LAND] = @land, [AIRB] = @airb, [TEN_MILES_TIME] = @ten_miles_time, 
                                    [ORG3] = @org3, [DES3] = @des3, [ORG_ICAO] = @org_icao, [DES_ICAO] = @des_icao, [VIA1] = @via1, [VIA_ICAO] = @via_icao, [PUBLIC_FLT] = @public_flt, 
                                    [PUBLIC_FLC] = @public_flc, [PUBLIC_TIME] = @public_time, [SECURE_STAND_IS_REQUIRED] = @secure_stand_is_required, [STOD] = @stod, [STPO] = @stpo, 
                                    [OPERATIONTYPE_CODE2] = @operationtype_code2, [FIRSTBAG_TIME2] = @firstbag_time2, [LASTBAG_TIME2] = @lastbag_time2, [OPERATIONTYPE_ROLE1] = @operationtype_role1, 
                                    [OPERATIONTYPE_ROLE2] = @operationtype_role2, [UPDATE_TIME] = @update_time, [CUSTOM_STATUS] = @custom_status, [SUB_AIRLINE] = @sub_airline, [LTD] = @ltd, 
                                    [LTA] = @lta, [AIRLINE_TERMINAL] = @airline_terminal, [GATE_PLAN_CLOSE_TIME1] = @gate_plan_close_time1, [GATE_PLAN_OPEN_TIME1] = @gate_plan_open_time1, 
                                    [GATE_PLAN_CLOSE_TIME2] = @gate_plan_close_time2, [GATE_PLAN_OPEN_TIME2] = @gate_plan_open_time2, [USEC] = @usec,  [USEU] = @useu, [TYPU] = @typu, [LSTU] = @lstu, [JFNO] = @jfno, [CTRL] = @ctrl ,[DRCT] = @drct
                            WHERE     ID = @id";

            SqlParameter[] para = new SqlParameter[239];
            para[0] = new SqlParameter("@id", id);
            para[1] = new SqlParameter("@urno", urno);
            para[2] = new SqlParameter("@carrier_iata", carrier_iata);
            para[3] = new SqlParameter("@carrier_icao", carrier_icao);
            para[4] = new SqlParameter("@fl_number", fl_number);
            para[5] = new SqlParameter("@fl_suffix", fl_suffix);
            para[6] = new SqlParameter("@flt", flt);
            para[7] = new SqlParameter("@flr", flr);
            para[8] = new SqlParameter("@sdt", sdt);
            para[9] = new SqlParameter("@sdp", sdp);
            para[10] = new SqlParameter("@linkedfl_flt", linkedfl_flt);
            para[11] = new SqlParameter("@linkedfl_carrier", linkedfl_carrier);
            para[12] = new SqlParameter("@linkedfl_number", linkedfl_number);
            para[13] = new SqlParameter("@linkedfl_suffix", linkedfl_suffix);
            para[14] = new SqlParameter("@linkedfl_sdt", linkedfl_sdt);
            para[15] = new SqlParameter("@linkedfl_flr", linkedfl_flr);
            para[16] = new SqlParameter("@linkfl_id", linkfl_id);
            para[17] = new SqlParameter("@masterfl_carrier", masterfl_carrier);
            para[18] = new SqlParameter("@masterfl_number", masterfl_number);
            para[19] = new SqlParameter("@masterfl_suffix", masterfl_suffix);
            para[20] = new SqlParameter("@mfdi", mfdi);
            para[21] = new SqlParameter("@masterfl_flr", masterfl_flr);
            para[22] = new SqlParameter("@masterfl_id", masterfl_id);
            para[23] = new SqlParameter("@aircraft_callsign", aircraft_callsign);
            para[24] = new SqlParameter("@aircraft_owner", aircraft_owner);
            para[25] = new SqlParameter("@aircraft_paxcap", aircraft_paxcap);
            para[26] = new SqlParameter("@regn", regn);
            para[27] = new SqlParameter("@atc5", atc5);
            para[28] = new SqlParameter("@aircraft_type", aircraft_type);
            para[29] = new SqlParameter("@aircraft_operator", aircraft_operator);
            para[30] = new SqlParameter("@aircraft_terminal", aircraft_terminal);
            para[31] = new SqlParameter("@airport_iata", airport_iata);
            para[32] = new SqlParameter("@brc1", brc1);
            para[33] = new SqlParameter("@reclaim_role1", reclaim_role1);
            para[34] = new SqlParameter("@brod", brod);
            para[35] = new SqlParameter("@brcd", brcd);
            para[36] = new SqlParameter("@exitdoor1", exitdoor1);
            para[37] = new SqlParameter("@src2", src2);
            para[38] = new SqlParameter("@reclaim_role2", reclaim_role2);
            para[39] = new SqlParameter("@sbro", sbro);
            para[40] = new SqlParameter("@sbrc", sbrc);
            para[41] = new SqlParameter("@exitdoor2", exitdoor2);
            para[42] = new SqlParameter("@makeup_id1", makeup_id1);
            para[43] = new SqlParameter("@makeup_role1", makeup_role1);
            para[44] = new SqlParameter("@makeup_open_time1", makeup_open_time1);
            para[45] = new SqlParameter("@makeup_close_time1", makeup_close_time1);
            para[46] = new SqlParameter("@makeup_id2", makeup_id2);
            para[47] = new SqlParameter("@makeup_role2", makeup_role2);
            para[48] = new SqlParameter("@makeup_open_time2", makeup_open_time2);
            para[49] = new SqlParameter("@makeup_close_time2", makeup_close_time2);
            para[50] = new SqlParameter("@isbusrequired", isbusrequired);
            para[51] = new SqlParameter("@cc_type1", cc_type1);
            para[52] = new SqlParameter("@ckif", ckif);
            para[53] = new SqlParameter("@cc_role1", cc_role1);
            para[54] = new SqlParameter("@cc_clusterid1", cc_clusterid1);
            para[55] = new SqlParameter("@codt", codt);
            para[56] = new SqlParameter("@ccdt", ccdt);
            para[57] = new SqlParameter("@cc_type2", cc_type2);
            para[58] = new SqlParameter("@scdr", scdr);
            para[59] = new SqlParameter("@cc_role2", cc_role2);
            para[60] = new SqlParameter("@cc_clusterid2", cc_clusterid2);
            para[61] = new SqlParameter("@scodt", scodt);
            para[62] = new SqlParameter("@sccdt", sccdt);
            para[63] = new SqlParameter("@sgcd", sgcd);
            para[64] = new SqlParameter("@sgod", sgod);
            para[65] = new SqlParameter("@gate_bording_status2", gate_bording_status2);
            para[66] = new SqlParameter("@gate_role2", gate_role2);
            para[67] = new SqlParameter("@sgn", sgn);
            para[68] = new SqlParameter("@gcdt", gcdt);
            para[69] = new SqlParameter("@godt", godt);
            para[70] = new SqlParameter("@gbs", gbs);
            para[71] = new SqlParameter("@gate_role1", gate_role1);
            para[72] = new SqlParameter("@geno", geno);
            para[73] = new SqlParameter("@term", term);
            para[74] = new SqlParameter("@remark_code1", remark_code1);
            para[75] = new SqlParameter("@remark_type1", remark_type1);
            para[76] = new SqlParameter("@remark_code2", remark_code2);
            para[77] = new SqlParameter("@remark_type2", remark_type2);
            para[78] = new SqlParameter("@remark_code3", remark_code3);
            para[79] = new SqlParameter("@remark_type3", remark_type3);
            para[80] = new SqlParameter("@remark_code4", remark_code4);
            para[81] = new SqlParameter("@remark_type4", remark_type4);
            para[82] = new SqlParameter("@runway_id", runway_id);
            para[83] = new SqlParameter("@s_info_type1", s_info_type1);
            para[84] = new SqlParameter("@s_info_text1", s_info_text1);
            para[85] = new SqlParameter("@s_info_type2", s_info_type2);
            para[86] = new SqlParameter("@s_info_text2", s_info_text2);
            para[87] = new SqlParameter("@s_info_type3", s_info_type3);
            para[88] = new SqlParameter("@s_info_text3", s_info_text3);
            para[89] = new SqlParameter("@s_info_type4", s_info_type4);
            para[90] = new SqlParameter("@s_info_text4", s_info_text4);
            para[91] = new SqlParameter("@s_info_type5", s_info_type5);
            para[92] = new SqlParameter("@s_info_text5", s_info_text5);
            para[93] = new SqlParameter("@account_code", account_code);
            para[94] = new SqlParameter("@fl_classificationcode", fl_classificationcode);
            para[95] = new SqlParameter("@fl_statuscode", fl_statuscode);
            para[96] = new SqlParameter("@css", css);
            para[97] = new SqlParameter("@daia", daia);
            para[98] = new SqlParameter("@fl_cancelcode", fl_cancelcode);
            para[99] = new SqlParameter("@fl_operates_overnight", fl_operates_overnight);
            para[100] = new SqlParameter("@ttyp", ttyp);
            para[101] = new SqlParameter("@fl_servicetype", fl_servicetype);
            para[102] = new SqlParameter("@flti", flti);
            para[103] = new SqlParameter("@fl_transitcode", fl_transitcode);
            para[104] = new SqlParameter("@handlingagent1", handlingagent1);
            para[105] = new SqlParameter("@handling_service1", handling_service1);
            para[106] = new SqlParameter("@handlingagent2", handlingagent2);
            para[107] = new SqlParameter("@handling_service2", handling_service2);
            para[108] = new SqlParameter("@handlingagent3", handlingagent3);
            para[109] = new SqlParameter("@handling_service3", handling_service3);
            para[110] = new SqlParameter("@handlingagent4", handlingagent4);
            para[111] = new SqlParameter("@handling_service4", handling_service4);
            para[112] = new SqlParameter("@handlingagent5", handlingagent5);
            para[113] = new SqlParameter("@handling_service5", handling_service5);
            para[114] = new SqlParameter("@irr_number1", irr_number1);
            para[115] = new SqlParameter("@irr_code1", irr_code1);
            para[116] = new SqlParameter("@irr_duration1", irr_duration1);
            para[117] = new SqlParameter("@irr_number2", irr_number2);
            para[118] = new SqlParameter("@irr_code2", irr_code2);
            para[119] = new SqlParameter("@irr_duration2", irr_duration2);
            para[120] = new SqlParameter("@isgvf", isgvf);
            para[121] = new SqlParameter("@isreturnfl", isreturnfl);
            para[122] = new SqlParameter("@istransferfl", istransferfl);
            para[123] = new SqlParameter("@newfl_reason", newfl_reason);
            para[124] = new SqlParameter("@operationtype_code1", operationtype_code1);
            para[125] = new SqlParameter("@transfer_fl1", transfer_fl1);
            para[126] = new SqlParameter("@transfer_fl2", transfer_fl2);
            para[127] = new SqlParameter("@transfer_fl3", transfer_fl3);
            para[128] = new SqlParameter("@transfer_fl4", transfer_fl4);
            para[129] = new SqlParameter("@transfer_fl5", transfer_fl5);
            para[130] = new SqlParameter("@transfer_fl6", transfer_fl6);
            para[131] = new SqlParameter("@transfer_fl7", transfer_fl7);
            para[132] = new SqlParameter("@transfer_fl8", transfer_fl8);
            para[133] = new SqlParameter("@transfer_fl9", transfer_fl9);
            para[134] = new SqlParameter("@transfer_fl10", transfer_fl10);
            para[135] = new SqlParameter("@transfer_fl11", transfer_fl11);
            para[136] = new SqlParameter("@transfer_fl12", transfer_fl12);
            para[137] = new SqlParameter("@transfer_fl13", transfer_fl13);
            para[138] = new SqlParameter("@transfer_fl14", transfer_fl14);
            para[139] = new SqlParameter("@transfer_fl15", transfer_fl15);
            para[140] = new SqlParameter("@transfer_fl16", transfer_fl16);
            para[141] = new SqlParameter("@transfer_fl17", transfer_fl17);
            para[142] = new SqlParameter("@transfer_fl18", transfer_fl18);
            para[143] = new SqlParameter("@transfer_fl19", transfer_fl19);
            para[144] = new SqlParameter("@transfer_fl20", transfer_fl20);
            para[145] = new SqlParameter("@sharefl_flt1", sharefl_flt1);
            para[146] = new SqlParameter("@sharefl_fln1", sharefl_fln1);
            para[147] = new SqlParameter("@sharefl_flt2", sharefl_flt2);
            para[148] = new SqlParameter("@sharefl_fln2", sharefl_fln2);
            para[149] = new SqlParameter("@sharefl_flt3", sharefl_flt3);
            para[150] = new SqlParameter("@sharefl_fln3", sharefl_fln3);
            para[151] = new SqlParameter("@sharefl_flt4", sharefl_flt4);
            para[152] = new SqlParameter("@sharefl_fln4", sharefl_fln4);
            para[153] = new SqlParameter("@sharefl_flt5", sharefl_flt5);
            para[154] = new SqlParameter("@sharefl_fln5", sharefl_fln5);
            para[155] = new SqlParameter("@sharefl_flt6", sharefl_flt6);
            para[156] = new SqlParameter("@sharefl_fln6", sharefl_fln6);
            para[157] = new SqlParameter("@total_bagcount", total_bagcount);
            para[158] = new SqlParameter("@total_bagweight", total_bagweight);
            para[159] = new SqlParameter("@total_freightweight", total_freightweight);
            para[160] = new SqlParameter("@total_mailweight", total_mailweight);
            para[161] = new SqlParameter("@total_loadweight", total_loadweight);
            para[162] = new SqlParameter("@adult_paxcount", adult_paxcount);
            para[163] = new SqlParameter("@bussiness_paxcount", bussiness_paxcount);
            para[164] = new SqlParameter("@child_paxcount", child_paxcount);
            para[165] = new SqlParameter("@domesitec_paxcount", domesitec_paxcount);
            para[166] = new SqlParameter("@infant_paxcount", infant_paxcount);
            para[167] = new SqlParameter("@international_paxcount", international_paxcount);
            para[168] = new SqlParameter("@local_paxcount", local_paxcount);
            para[169] = new SqlParameter("@nontransfer_paxcount", nontransfer_paxcount);
            para[170] = new SqlParameter("@total_paxcount", total_paxcount);
            para[171] = new SqlParameter("@transfer_paxcount", transfer_paxcount);
            para[172] = new SqlParameter("@transit_paxcount", transit_paxcount);
            para[173] = new SqlParameter("@whellchair_paxcount", whellchair_paxcount);
            para[174] = new SqlParameter("@total_crewcount", total_crewcount);
            para[175] = new SqlParameter("@economy_paxcount", economy_paxcount);
            para[176] = new SqlParameter("@firstclass_paxcount", firstclass_paxcount);
            para[177] = new SqlParameter("@transfer_bagcount", transfer_bagcount);
            para[178] = new SqlParameter("@transfer_bagweight", transfer_bagweight);
            para[179] = new SqlParameter("@transfer_freightweight", transfer_freightweight);
            para[180] = new SqlParameter("@transfer_mailweight", transfer_mailweight);
            para[181] = new SqlParameter("@transit_bagcount", transit_bagcount);
            para[182] = new SqlParameter("@transit_bagweight", transit_bagweight);
            para[183] = new SqlParameter("@transit_freightweight", transit_freightweight);
            para[184] = new SqlParameter("@transit_mailweight", transit_mailweight);
            para[185] = new SqlParameter("@offblock_time", offblock_time);
            para[186] = new SqlParameter("@onblock_time", onblock_time);
            para[187] = new SqlParameter("@edta", edta);
            para[188] = new SqlParameter("@edtd", edtd);
            para[189] = new SqlParameter("@e_fl_duration", e_fl_duration);
            para[190] = new SqlParameter("@firstbag_time", firstbag_time);
            para[191] = new SqlParameter("@lastbag_time", lastbag_time);
            para[192] = new SqlParameter("@finalapproach_time", finalapproach_time);
            para[193] = new SqlParameter("@lastknown_time", lastknown_time);
            para[194] = new SqlParameter("@lastknown_source", lastknown_source);
            para[195] = new SqlParameter("@next_info_time", next_info_time);
            para[196] = new SqlParameter("@a_next_station_time", a_next_station_time);
            para[197] = new SqlParameter("@e_next_station_time", e_next_station_time);
            para[198] = new SqlParameter("@s_next_station_time", s_next_station_time);
            para[199] = new SqlParameter("@a_prev_station_time", a_prev_station_time);
            para[200] = new SqlParameter("@e_prev_station_time", e_prev_station_time);
            para[201] = new SqlParameter("@s_prev_station_time", s_prev_station_time);
            para[202] = new SqlParameter("@land", land);
            para[203] = new SqlParameter("@airb", airb);
            para[204] = new SqlParameter("@ten_miles_time", ten_miles_time);
            para[205] = new SqlParameter("@org3", org3);
            para[206] = new SqlParameter("@des3", des3);
            para[207] = new SqlParameter("@org_icao", org_icao);
            para[208] = new SqlParameter("@des_icao", des_icao);
            para[209] = new SqlParameter("@via1", via1);
            para[210] = new SqlParameter("@via_icao", via_icao);
            para[211] = new SqlParameter("@public_flt", public_flt);
            para[212] = new SqlParameter("@public_flc", public_flc);
            para[213] = new SqlParameter("@public_time", public_time);
            para[214] = new SqlParameter("@secure_stand_is_required", secure_stand_is_required);
            para[215] = new SqlParameter("@stod", stod);
            para[216] = new SqlParameter("@stpo", stpo);
            para[217] = new SqlParameter("@operationtype_code2", operationtype_code2);
            para[218] = new SqlParameter("@firstbag_time2", firstbag_time2);
            para[219] = new SqlParameter("@lastbag_time2", lastbag_time2);
            para[220] = new SqlParameter("@operationtype_role1", operationtype_role1);
            para[221] = new SqlParameter("@operationtype_role2", operationtype_role2);
            para[222] = new SqlParameter("@update_time", update_time);
            para[223] = new SqlParameter("@custom_status", custom_status);
            para[224] = new SqlParameter("@sub_airline", sub_airline);
            para[225] = new SqlParameter("@ltd", ltd);
            para[226] = new SqlParameter("@lta", lta);
            para[227] = new SqlParameter("@airline_terminal", airline_terminal);
            para[228] = new SqlParameter("@gate_plan_close_time1", gate_plan_close_time1);
            para[229] = new SqlParameter("@gate_plan_open_time1", gate_plan_open_time1);
            para[230] = new SqlParameter("@gate_plan_close_time2", gate_plan_close_time2);
            para[231] = new SqlParameter("@gate_plan_open_time2", gate_plan_open_time2);
            para[232] = new SqlParameter("@usec", usec);
            para[233] = new SqlParameter("@useu", useu);
            para[234] = new SqlParameter("@typu", typu);
            para[235] = new SqlParameter("@lstu", lstu);
            para[236] = new SqlParameter("@jfno", jfno);
            para[237] = new SqlParameter("@ctrl", ctrl);
            para[238] = new SqlParameter("@drct", drct);

            if (trans != null)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, para);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
            }
        }

        public static void InsertAOCData(
                string urno, string carrier_iata, string carrier_icao, string fl_number, string fl_suffix, string flt, string flr, string sdt, string sdp, string linkedfl_flt,
                string linkedfl_carrier, string linkedfl_number, string linkedfl_suffix, string linkedfl_sdt, string linkedfl_flr, string linkfl_id, string masterfl_carrier,
                string masterfl_number, string masterfl_suffix, string mfdi, string masterfl_flr, string masterfl_id, string aircraft_callsign, string aircraft_owner,
                string aircraft_paxcap, string regn, string atc5, string aircraft_type, string aircraft_operator, string aircraft_terminal, string airport_iata,
                string brc1, string reclaim_role1, string brod, string brcd, string exitdoor1, string src2, string reclaim_role2, string sbro, string sbrc, string exitdoor2,
                string makeup_id1, string makeup_role1, string makeup_open_time1, string makeup_close_time1, string makeup_id2, string makeup_role2, string makeup_open_time2,
                string makeup_close_time2, string isbusrequired, string cc_type1, string ckif, string cc_role1, string cc_clusterid1, string codt, string ccdt, string cc_type2,
                string scdr, string cc_role2, string cc_clusterid2, string scodt, string sccdt, string sgcd, string sgod, string gate_bording_status2, string gate_role2, string sgn,
                string gcdt, string godt, string gbs, string gate_role1, string geno, string term, string remark_code1, string remark_type1, string remark_code2,
                string remark_type2, string remark_code3, string remark_type3, string remark_code4, string remark_type4, string runway_id, string s_info_type1, string s_info_text1,
                string s_info_type2, string s_info_text2, string s_info_type3, string s_info_text3, string s_info_type4, string s_info_text4, string s_info_type5, string s_info_text5,
                string account_code, string fl_classificationcode, string fl_statuscode, string css, string daia, string fl_cancelcode, string fl_operates_overnight, string ttyp,
                string fl_servicetype, string flti, string fl_transitcode, string handlingagent1, string handling_service1, string handlingagent2, string handling_service2, string handlingagent3,
                string handling_service3, string handlingagent4, string handling_service4, string handlingagent5, string handling_service5, string irr_number1, string irr_code1,
                string irr_duration1, string irr_number2, string irr_code2, string irr_duration2, string isgvf, string isreturnfl, string istransferfl, string newfl_reason, string operationtype_code1,
                string transfer_fl1, string transfer_fl2, string transfer_fl3, string transfer_fl4, string transfer_fl5, string transfer_fl6, string transfer_fl7, string transfer_fl8, string transfer_fl9,
                string transfer_fl10, string transfer_fl11, string transfer_fl12, string transfer_fl13, string transfer_fl14, string transfer_fl15, string transfer_fl16, string transfer_fl17,
                string transfer_fl18, string transfer_fl19, string transfer_fl20, string sharefl_flt1, string sharefl_fln1, string sharefl_flt2, string sharefl_fln2, string sharefl_flt3,
                string sharefl_fln3, string sharefl_flt4, string sharefl_fln4, string sharefl_flt5, string sharefl_fln5, string sharefl_flt6, string sharefl_fln6, string total_bagcount,
                string total_bagweight, string total_freightweight, string total_mailweight, string total_loadweight, string adult_paxcount, string bussiness_paxcount, string child_paxcount,
                string domesitec_paxcount, string infant_paxcount, string international_paxcount, string local_paxcount, string nontransfer_paxcount, string total_paxcount,
                string transfer_paxcount, string transit_paxcount, string whellchair_paxcount, string total_crewcount, string economy_paxcount, string firstclass_paxcount,
                string transfer_bagcount, string transfer_bagweight, string transfer_freightweight, string transfer_mailweight, string transit_bagcount, string transit_bagweight,
                string transit_freightweight, string transit_mailweight, string offblock_time, string onblock_time, string edta, string edtd, string e_fl_duration, string firstbag_time,
                string lastbag_time, string finalapproach_time, string lastknown_time, string lastknown_source, string next_info_time, string a_next_station_time, string e_next_station_time,
                string s_next_station_time, string a_prev_station_time, string e_prev_station_time, string s_prev_station_time, string land, string airb, string ten_miles_time,
                string org3, string des3, string org_icao, string des_icao, string via1, string via_icao, string public_flt, string public_flc, string public_time, string secure_stand_is_required,
                string stod, string stpo, string operationtype_code2, string firstbag_time2, string lastbag_time2, string operationtype_role1, string operationtype_role2,
                string update_time, string custom_status, string sub_airline, string ltd, string lta, string airline_terminal, string gate_plan_close_time1, string gate_plan_open_time1,
                string gate_plan_close_time2, string gate_plan_open_time2, string usec, string typc, DateTime cdat, string useu, string typu, DateTime lstu, string jfno, int ctrl, string drct
            )
        {
            string sql = @"INSERT INTO [AOCFQS] (
                                    [URNO], [CARRIER_IATA], [CARRIER_ICAO], [FL_NUMBER], [FL_SUFFIX], [FLT], [FLR], [SDT], [SDP], [LINKEDFL_FLT], 
                                    [LINKEDFL_CARRIER], [LINKEDFL_NUMBER], [LINKEDFL_SUFFIX], [LINKEDFL_SDT], [LINKEDFL_FLR], [LINKFL_ID], [MASTERFL_CARRIER], 
                                    [MASTERFL_NUMBER], [MASTERFL_SUFFIX], [MFDI], [MASTERFL_FLR], [MASTERFL_ID], [AIRCRAFT_CALLSIGN], [AIRCRAFT_OWNER], 
                                    [AIRCRAFT_PAXCAP], [REGN], [ATC5], [AIRCRAFT_TYPE], [AIRCRAFT_OPERATOR], [AIRCRAFT_TERMINAL], [AIRPORT_IATA], 
                                    [BRC1], [RECLAIM_ROLE1], [BROD], [BRCD], [EXITDOOR1], [SRC2], [RECLAIM_ROLE2], [SBRO], [SBRC], [EXITDOOR2], [MAKEUP_ID1], [MAKEUP_ROLE1], 
                                    [MAKEUP_OPEN_TIME1], [MAKEUP_CLOSE_TIME1], [MAKEUP_ID2], [MAKEUP_ROLE2], [MAKEUP_OPEN_TIME2], [MAKEUP_CLOSE_TIME2], [ISBUSREQUIRED], 
                                    [CC_TYPE1], [CKIF], [CC_ROLE1], [CC_CLUSTERID1], [CODT], [CCDT], [CC_TYPE2], [SCDR], [CC_ROLE2], [CC_CLUSTERID2], [SCODT], [SCCDT], [SGCD], 
                                    [SGOD], [GATE_BORDING_STATUS2], [GATE_ROLE2], [SGN], [GCDT], [GODT], [GBS], [GATE_ROLE1], [GENO], [TERM], [REMARK_CODE1], 
                                    [REMARK_TYPE1], [REMARK_CODE2], [REMARK_TYPE2], [REMARK_CODE3], [REMARK_TYPE3], [REMARK_CODE4], [REMARK_TYPE4], [RUNWAY_ID], 
                                    [S_INFO_TYPE1], [S_INFO_TEXT1], [S_INFO_TYPE2], [S_INFO_TEXT2], [S_INFO_TYPE3], [S_INFO_TEXT3], [S_INFO_TYPE4], [S_INFO_TEXT4], 
                                    [S_INFO_TYPE5], [S_INFO_TEXT5], [ACCOUNT_CODE], [FL_CLASSIFICATIONCODE], [FL_STATUSCODE], [CSS], [DAIA], [FL_CANCELCODE], [FL_OPERATES_OVERNIGHT], 
                                    [TTYP], [FL_SERVICETYPE], [FLTI], [FL_TRANSITCODE], [HANDLINGAGENT1], [HANDLING_SERVICE1], [HANDLINGAGENT2], [HANDLING_SERVICE2], [HANDLINGAGENT3], 
                                    [HANDLING_SERVICE3], [HANDLINGAGENT4], [HANDLING_SERVICE4], [HANDLINGAGENT5], [HANDLING_SERVICE5], [IRR_NUMBER1], [IRR_CODE1], [IRR_DURATION1], 
                                    [IRR_NUMBER2], [IRR_CODE2], [IRR_DURATION2], [ISGVF], [ISRETURNFL], [ISTRANSFERFL], [NEWFL_REASON], [OPERATIONTYPE_CODE1], [TRANSFER_FL1], 
                                    [TRANSFER_FL2], [TRANSFER_FL3], [TRANSFER_FL4], [TRANSFER_FL5], [TRANSFER_FL6], [TRANSFER_FL7], [TRANSFER_FL8], [TRANSFER_FL9], [TRANSFER_FL10], 
                                    [TRANSFER_FL11], [TRANSFER_FL12], [TRANSFER_FL13], [TRANSFER_FL14], [TRANSFER_FL15], [TRANSFER_FL16], [TRANSFER_FL17], [TRANSFER_FL18], [TRANSFER_FL19], 
                                    [TRANSFER_FL20], [SHAREFL_FLT1], [SHAREFL_FLN1], [SHAREFL_FLT2], [SHAREFL_FLN2], [SHAREFL_FLT3], [SHAREFL_FLN3], [SHAREFL_FLT4], [SHAREFL_FLN4], 
                                    [SHAREFL_FLT5], [SHAREFL_FLN5], [SHAREFL_FLT6], [SHAREFL_FLN6], [TOTAL_BAGCOUNT], [TOTAL_BAGWEIGHT], [TOTAL_FREIGHTWEIGHT], [TOTAL_MAILWEIGHT], 
                                    [TOTAL_LOADWEIGHT], [ADULT_PAXCOUNT], [BUSSINESS_PAXCOUNT], [CHILD_PAXCOUNT], [DOMESITEC_PAXCOUNT], [INFANT_PAXCOUNT], [INTERNATIONAL_PAXCOUNT], 
                                    [LOCAL_PAXCOUNT], [NONTRANSFER_PAXCOUNT], [TOTAL_PAXCOUNT], [TRANSFER_PAXCOUNT], [TRANSIT_PAXCOUNT], [WHELLCHAIR_PAXCOUNT], [TOTAL_CREWCOUNT], 
                                    [ECONOMY_PAXCOUNT], [FIRSTCLASS_PAXCOUNT], [TRANSFER_BAGCOUNT], [TRANSFER_BAGWEIGHT], [TRANSFER_FREIGHTWEIGHT], [TRANSFER_MAILWEIGHT], 
                                    [TRANSIT_BAGCOUNT], [TRANSIT_BAGWEIGHT], [TRANSIT_FREIGHTWEIGHT], [TRANSIT_MAILWEIGHT], [OFFBLOCK_TIME], [ONBLOCK_TIME], [EDTA], [EDTD], [E_FL_DURATION], 
                                    [FIRSTBAG_TIME], [LASTBAG_TIME], [FINALAPPROACH_TIME], [LASTKNOWN_TIME], [LASTKNOWN_SOURCE], [NEXT_INFO_TIME], [A_NEXT_STATION_TIME], 
                                    [E_NEXT_STATION_TIME], [S_NEXT_STATION_TIME], [A_PREV_STATION_TIME], [E_PREV_STATION_TIME], [S_PREV_STATION_TIME], [LAND], [AIRB], [TEN_MILES_TIME], 
                                    [ORG3], [DES3], [ORG_ICAO], [DES_ICAO], [VIA1], [VIA_ICAO], [PUBLIC_FLT], [PUBLIC_FLC], [PUBLIC_TIME], [SECURE_STAND_IS_REQUIRED], [STOD], [STPO], 
                                    [OPERATIONTYPE_CODE2], [FIRSTBAG_TIME2], [LASTBAG_TIME2], [OPERATIONTYPE_ROLE1], [OPERATIONTYPE_ROLE2], [UPDATE_TIME], [CUSTOM_STATUS], 
                                    [SUB_AIRLINE], [LTD], [LTA], [AIRLINE_TERMINAL], [GATE_PLAN_CLOSE_TIME1], [GATE_PLAN_OPEN_TIME1], [GATE_PLAN_CLOSE_TIME2], [GATE_PLAN_OPEN_TIME2], 
                                    [USEC], [TYPC], [CDAT], [USEU], [JFNO], [CTRL], [DRCT]) 
                               VALUES (
                                    @urno, @carrier_iata, @carrier_icao, @fl_number, @fl_suffix, @flt, @flr, @sdt, @sdp, @linkedfl_flt, @linkedfl_carrier, @linkedfl_number, @linkedfl_suffix, @linkedfl_sdt,
                                    @linkedfl_flr, @linkfl_id, @masterfl_carrier, @masterfl_number, @masterfl_suffix, @mfdi, @masterfl_flr, @masterfl_id, @aircraft_callsign, @aircraft_owner, @aircraft_paxcap, 
                                    @regn, @atc5, @aircraft_type, @aircraft_operator, @aircraft_terminal, @airport_iata, @brc1, @reclaim_role1, @brod, @brcd, @exitdoor1, @src2, @reclaim_role2, 
                                    @sbro, @sbrc, @exitdoor2, @makeup_id1, @makeup_role1, @makeup_open_time1, @makeup_close_time1, @makeup_id2, @makeup_role2, @makeup_open_time2, @makeup_close_time2, 
                                    @isbusrequired, @cc_type1, @ckif, @cc_role1, @cc_clusterid1, @codt, @ccdt, @cc_type2, @scdr, @cc_role2, @cc_clusterid2, @scodt, @sccdt, @sgcd, @sgod, 
                                    @gate_bording_status2, @gate_role2, @sgn, @gcdt, @godt, @gbs, @gate_role1, @geno, @term, @remark_code1, @remark_type1, @remark_code2, 
                                    @remark_type2, @remark_code3, @remark_type3, @remark_code4, @remark_type4, @runway_id, @s_info_type1, @s_info_text1, @s_info_type2, @s_info_text2, 
                                    @s_info_type3, @s_info_text3, @s_info_type4, @s_info_text4, @s_info_type5, @s_info_text5, @account_code, @fl_classificationcode, @fl_statuscode, @css, @daia, 
                                    @fl_cancelcode, @fl_operates_overnight, @ttyp, @fl_servicetype, @flti, @fl_transitcode, @handlingagent1, @handling_service1, @handlingagent2, @handling_service2, 
                                    @handlingagent3, @handling_service3, @handlingagent4, @handling_service4, @handlingagent5, @handling_service5, @irr_number1, @irr_code1, @irr_duration1, @irr_number2, 
                                    @irr_code2, @irr_duration2, @isgvf, @isreturnfl, @istransferfl, @newfl_reason, @operationtype_code1, @transfer_fl1, @transfer_fl2, @transfer_fl3, @transfer_fl4, @transfer_fl5, 
                                    @transfer_fl6, @transfer_fl7, @transfer_fl8, @transfer_fl9, @transfer_fl10, @transfer_fl11, @transfer_fl12, @transfer_fl13, @transfer_fl14, @transfer_fl15, @transfer_fl16, 
                                    @transfer_fl17, @transfer_fl18, @transfer_fl19, @transfer_fl20, @sharefl_flt1, @sharefl_fln1, @sharefl_flt2, @sharefl_fln2, @sharefl_flt3, @sharefl_fln3, @sharefl_flt4, 
                                    @sharefl_fln4, @sharefl_flt5, @sharefl_fln5, @sharefl_flt6, @sharefl_fln6, @total_bagcount, @total_bagweight, @total_freightweight, @total_mailweight, @total_loadweight, 
                                    @adult_paxcount, @bussiness_paxcount, @child_paxcount, @domesitec_paxcount, @infant_paxcount, @international_paxcount, @local_paxcount, @nontransfer_paxcount, 
                                    @total_paxcount, @transfer_paxcount, @transit_paxcount, @whellchair_paxcount, @total_crewcount, @economy_paxcount, @firstclass_paxcount, @transfer_bagcount, 
                                    @transfer_bagweight, @transfer_freightweight, @transfer_mailweight, @transit_bagcount, @transit_bagweight, @transit_freightweight, @transit_mailweight, @offblock_time, 
                                    @onblock_time, @edta, @edtd, @e_fl_duration, @firstbag_time, @lastbag_time, @finalapproach_time, @lastknown_time, @lastknown_source, @next_info_time, @a_next_station_time, 
                                    @e_next_station_time, @s_next_station_time, @a_prev_station_time, @e_prev_station_time, @s_prev_station_time, @land, @airb, @ten_miles_time, @org3, @des3, @org_icao, 
                                    @des_icao, @via1, @via_icao, @public_flt, @public_flc, @public_time, @secure_stand_is_required, @stod, @stpo, @operationtype_code2, @firstbag_time2, @lastbag_time2, 
                                    @operationtype_role1, @operationtype_role2, @update_time, @custom_status, @sub_airline, @ltd, @lta, @airline_terminal, @gate_plan_close_time1, @gate_plan_open_time1, 
                                    @gate_plan_close_time2, @gate_plan_open_time2, @usec, @typc, @cdat, @useu, @jfno, @ctrl, @drct)";

            SqlParameter[] para = new SqlParameter[239];
            para[0] = new SqlParameter();
            para[1] = new SqlParameter("@urno", urno);
            para[2] = new SqlParameter("@carrier_iata", carrier_iata);
            para[3] = new SqlParameter("@carrier_icao", carrier_icao);
            para[4] = new SqlParameter("@fl_number", fl_number);
            para[5] = new SqlParameter("@fl_suffix", fl_suffix);
            para[6] = new SqlParameter("@flt", flt);
            para[7] = new SqlParameter("@flr", flr);
            para[8] = new SqlParameter("@sdt", sdt);
            para[9] = new SqlParameter("@sdp", sdp);
            para[10] = new SqlParameter("@linkedfl_flt", linkedfl_flt);
            para[11] = new SqlParameter("@linkedfl_carrier", linkedfl_carrier);
            para[12] = new SqlParameter("@linkedfl_number", linkedfl_number);
            para[13] = new SqlParameter("@linkedfl_suffix", linkedfl_suffix);
            para[14] = new SqlParameter("@linkedfl_sdt", linkedfl_sdt);
            para[15] = new SqlParameter("@linkedfl_flr", linkedfl_flr);
            para[16] = new SqlParameter("@linkfl_id", linkfl_id);
            para[17] = new SqlParameter("@masterfl_carrier", masterfl_carrier);
            para[18] = new SqlParameter("@masterfl_number", masterfl_number);
            para[19] = new SqlParameter("@masterfl_suffix", masterfl_suffix);
            para[20] = new SqlParameter("@mfdi", mfdi);
            para[21] = new SqlParameter("@masterfl_flr", masterfl_flr);
            para[22] = new SqlParameter("@masterfl_id", masterfl_id);
            para[23] = new SqlParameter("@aircraft_callsign", aircraft_callsign);
            para[24] = new SqlParameter("@aircraft_owner", aircraft_owner);
            para[25] = new SqlParameter("@aircraft_paxcap", aircraft_paxcap);
            para[26] = new SqlParameter("@regn", regn);
            para[27] = new SqlParameter("@atc5", atc5);
            para[28] = new SqlParameter("@aircraft_type", aircraft_type);
            para[29] = new SqlParameter("@aircraft_operator", aircraft_operator);
            para[30] = new SqlParameter("@aircraft_terminal", aircraft_terminal);
            para[31] = new SqlParameter("@airport_iata", airport_iata);
            para[32] = new SqlParameter("@brc1", brc1);
            para[33] = new SqlParameter("@reclaim_role1", reclaim_role1);
            para[34] = new SqlParameter("@brod", brod);
            para[35] = new SqlParameter("@brcd", brcd);
            para[36] = new SqlParameter("@exitdoor1", exitdoor1);
            para[37] = new SqlParameter("@src2", src2);
            para[38] = new SqlParameter("@reclaim_role2", reclaim_role2);
            para[39] = new SqlParameter("@sbro", sbro);
            para[40] = new SqlParameter("@sbrc", sbrc);
            para[41] = new SqlParameter("@exitdoor2", exitdoor2);
            para[42] = new SqlParameter("@makeup_id1", makeup_id1);
            para[43] = new SqlParameter("@makeup_role1", makeup_role1);
            para[44] = new SqlParameter("@makeup_open_time1", makeup_open_time1);
            para[45] = new SqlParameter("@makeup_close_time1", makeup_close_time1);
            para[46] = new SqlParameter("@makeup_id2", makeup_id2);
            para[47] = new SqlParameter("@makeup_role2", makeup_role2);
            para[48] = new SqlParameter("@makeup_open_time2", makeup_open_time2);
            para[49] = new SqlParameter("@makeup_close_time2", makeup_close_time2);
            para[50] = new SqlParameter("@isbusrequired", isbusrequired);
            para[51] = new SqlParameter("@cc_type1", cc_type1);
            para[52] = new SqlParameter("@ckif", ckif);
            para[53] = new SqlParameter("@cc_role1", cc_role1);
            para[54] = new SqlParameter("@cc_clusterid1", cc_clusterid1);
            para[55] = new SqlParameter("@codt", codt);
            para[56] = new SqlParameter("@ccdt", ccdt);
            para[57] = new SqlParameter("@cc_type2", cc_type2);
            para[58] = new SqlParameter("@scdr", scdr);
            para[59] = new SqlParameter("@cc_role2", cc_role2);
            para[60] = new SqlParameter("@cc_clusterid2", cc_clusterid2);
            para[61] = new SqlParameter("@scodt", scodt);
            para[62] = new SqlParameter("@sccdt", sccdt);
            para[63] = new SqlParameter("@sgcd", sgcd);
            para[64] = new SqlParameter("@sgod", sgod);
            para[65] = new SqlParameter("@gate_bording_status2", gate_bording_status2);
            para[66] = new SqlParameter("@gate_role2", gate_role2);
            para[67] = new SqlParameter("@sgn", sgn);
            para[68] = new SqlParameter("@gcdt", gcdt);
            para[69] = new SqlParameter("@godt", godt);
            para[70] = new SqlParameter("@gbs", gbs);
            para[71] = new SqlParameter("@gate_role1", gate_role1);
            para[72] = new SqlParameter("@geno", geno);
            para[73] = new SqlParameter("@term", term);
            para[74] = new SqlParameter("@remark_code1", remark_code1);
            para[75] = new SqlParameter("@remark_type1", remark_type1);
            para[76] = new SqlParameter("@remark_code2", remark_code2);
            para[77] = new SqlParameter("@remark_type2", remark_type2);
            para[78] = new SqlParameter("@remark_code3", remark_code3);
            para[79] = new SqlParameter("@remark_type3", remark_type3);
            para[80] = new SqlParameter("@remark_code4", remark_code4);
            para[81] = new SqlParameter("@remark_type4", remark_type4);
            para[82] = new SqlParameter("@runway_id", runway_id);
            para[83] = new SqlParameter("@s_info_type1", s_info_type1);
            para[84] = new SqlParameter("@s_info_text1", s_info_text1);
            para[85] = new SqlParameter("@s_info_type2", s_info_type2);
            para[86] = new SqlParameter("@s_info_text2", s_info_text2);
            para[87] = new SqlParameter("@s_info_type3", s_info_type3);
            para[88] = new SqlParameter("@s_info_text3", s_info_text3);
            para[89] = new SqlParameter("@s_info_type4", s_info_type4);
            para[90] = new SqlParameter("@s_info_text4", s_info_text4);
            para[91] = new SqlParameter("@s_info_type5", s_info_type5);
            para[92] = new SqlParameter("@s_info_text5", s_info_text5);
            para[93] = new SqlParameter("@account_code", account_code);
            para[94] = new SqlParameter("@fl_classificationcode", fl_classificationcode);
            para[95] = new SqlParameter("@fl_statuscode", fl_statuscode);
            para[96] = new SqlParameter("@css", css);
            para[97] = new SqlParameter("@daia", daia);
            para[98] = new SqlParameter("@fl_cancelcode", fl_cancelcode);
            para[99] = new SqlParameter("@fl_operates_overnight", fl_operates_overnight);
            para[100] = new SqlParameter("@ttyp", ttyp);
            para[101] = new SqlParameter("@fl_servicetype", fl_servicetype);
            para[102] = new SqlParameter("@flti", flti);
            para[103] = new SqlParameter("@fl_transitcode", fl_transitcode);
            para[104] = new SqlParameter("@handlingagent1", handlingagent1);
            para[105] = new SqlParameter("@handling_service1", handling_service1);
            para[106] = new SqlParameter("@handlingagent2", handlingagent2);
            para[107] = new SqlParameter("@handling_service2", handling_service2);
            para[108] = new SqlParameter("@handlingagent3", handlingagent3);
            para[109] = new SqlParameter("@handling_service3", handling_service3);
            para[110] = new SqlParameter("@handlingagent4", handlingagent4);
            para[111] = new SqlParameter("@handling_service4", handling_service4);
            para[112] = new SqlParameter("@handlingagent5", handlingagent5);
            para[113] = new SqlParameter("@handling_service5", handling_service5);
            para[114] = new SqlParameter("@irr_number1", irr_number1);
            para[115] = new SqlParameter("@irr_code1", irr_code1);
            para[116] = new SqlParameter("@irr_duration1", irr_duration1);
            para[117] = new SqlParameter("@irr_number2", irr_number2);
            para[118] = new SqlParameter("@irr_code2", irr_code2);
            para[119] = new SqlParameter("@irr_duration2", irr_duration2);
            para[120] = new SqlParameter("@isgvf", isgvf);
            para[121] = new SqlParameter("@isreturnfl", isreturnfl);
            para[122] = new SqlParameter("@istransferfl", istransferfl);
            para[123] = new SqlParameter("@newfl_reason", newfl_reason);
            para[124] = new SqlParameter("@operationtype_code1", operationtype_code1);
            para[125] = new SqlParameter("@transfer_fl1", transfer_fl1);
            para[126] = new SqlParameter("@transfer_fl2", transfer_fl2);
            para[127] = new SqlParameter("@transfer_fl3", transfer_fl3);
            para[128] = new SqlParameter("@transfer_fl4", transfer_fl4);
            para[129] = new SqlParameter("@transfer_fl5", transfer_fl5);
            para[130] = new SqlParameter("@transfer_fl6", transfer_fl6);
            para[131] = new SqlParameter("@transfer_fl7", transfer_fl7);
            para[132] = new SqlParameter("@transfer_fl8", transfer_fl8);
            para[133] = new SqlParameter("@transfer_fl9", transfer_fl9);
            para[134] = new SqlParameter("@transfer_fl10", transfer_fl10);
            para[135] = new SqlParameter("@transfer_fl11", transfer_fl11);
            para[136] = new SqlParameter("@transfer_fl12", transfer_fl12);
            para[137] = new SqlParameter("@transfer_fl13", transfer_fl13);
            para[138] = new SqlParameter("@transfer_fl14", transfer_fl14);
            para[139] = new SqlParameter("@transfer_fl15", transfer_fl15);
            para[140] = new SqlParameter("@transfer_fl16", transfer_fl16);
            para[141] = new SqlParameter("@transfer_fl17", transfer_fl17);
            para[142] = new SqlParameter("@transfer_fl18", transfer_fl18);
            para[143] = new SqlParameter("@transfer_fl19", transfer_fl19);
            para[144] = new SqlParameter("@transfer_fl20", transfer_fl20);
            para[145] = new SqlParameter("@sharefl_flt1", sharefl_flt1);
            para[146] = new SqlParameter("@sharefl_fln1", sharefl_fln1);
            para[147] = new SqlParameter("@sharefl_flt2", sharefl_flt2);
            para[148] = new SqlParameter("@sharefl_fln2", sharefl_fln2);
            para[149] = new SqlParameter("@sharefl_flt3", sharefl_flt3);
            para[150] = new SqlParameter("@sharefl_fln3", sharefl_fln3);
            para[151] = new SqlParameter("@sharefl_flt4", sharefl_flt4);
            para[152] = new SqlParameter("@sharefl_fln4", sharefl_fln4);
            para[153] = new SqlParameter("@sharefl_flt5", sharefl_flt5);
            para[154] = new SqlParameter("@sharefl_fln5", sharefl_fln5);
            para[155] = new SqlParameter("@sharefl_flt6", sharefl_flt6);
            para[156] = new SqlParameter("@sharefl_fln6", sharefl_fln6);
            para[157] = new SqlParameter("@total_bagcount", total_bagcount);
            para[158] = new SqlParameter("@total_bagweight", total_bagweight);
            para[159] = new SqlParameter("@total_freightweight", total_freightweight);
            para[160] = new SqlParameter("@total_mailweight", total_mailweight);
            para[161] = new SqlParameter("@total_loadweight", total_loadweight);
            para[162] = new SqlParameter("@adult_paxcount", adult_paxcount);
            para[163] = new SqlParameter("@bussiness_paxcount", bussiness_paxcount);
            para[164] = new SqlParameter("@child_paxcount", child_paxcount);
            para[165] = new SqlParameter("@domesitec_paxcount", domesitec_paxcount);
            para[166] = new SqlParameter("@infant_paxcount", infant_paxcount);
            para[167] = new SqlParameter("@international_paxcount", international_paxcount);
            para[168] = new SqlParameter("@local_paxcount", local_paxcount);
            para[169] = new SqlParameter("@nontransfer_paxcount", nontransfer_paxcount);
            para[170] = new SqlParameter("@total_paxcount", total_paxcount);
            para[171] = new SqlParameter("@transfer_paxcount", transfer_paxcount);
            para[172] = new SqlParameter("@transit_paxcount", transit_paxcount);
            para[173] = new SqlParameter("@whellchair_paxcount", whellchair_paxcount);
            para[174] = new SqlParameter("@total_crewcount", total_crewcount);
            para[175] = new SqlParameter("@economy_paxcount", economy_paxcount);
            para[176] = new SqlParameter("@firstclass_paxcount", firstclass_paxcount);
            para[177] = new SqlParameter("@transfer_bagcount", transfer_bagcount);
            para[178] = new SqlParameter("@transfer_bagweight", transfer_bagweight);
            para[179] = new SqlParameter("@transfer_freightweight", transfer_freightweight);
            para[180] = new SqlParameter("@transfer_mailweight", transfer_mailweight);
            para[181] = new SqlParameter("@transit_bagcount", transit_bagcount);
            para[182] = new SqlParameter("@transit_bagweight", transit_bagweight);
            para[183] = new SqlParameter("@transit_freightweight", transit_freightweight);
            para[184] = new SqlParameter("@transit_mailweight", transit_mailweight);
            para[185] = new SqlParameter("@offblock_time", offblock_time);
            para[186] = new SqlParameter("@onblock_time", onblock_time);
            para[187] = new SqlParameter("@edta", edta);
            para[188] = new SqlParameter("@edtd", edtd);
            para[189] = new SqlParameter("@e_fl_duration", e_fl_duration);
            para[190] = new SqlParameter("@firstbag_time", firstbag_time);
            para[191] = new SqlParameter("@lastbag_time", lastbag_time);
            para[192] = new SqlParameter("@finalapproach_time", finalapproach_time);
            para[193] = new SqlParameter("@lastknown_time", lastknown_time);
            para[194] = new SqlParameter("@lastknown_source", lastknown_source);
            para[195] = new SqlParameter("@next_info_time", next_info_time);
            para[196] = new SqlParameter("@a_next_station_time", a_next_station_time);
            para[197] = new SqlParameter("@e_next_station_time", e_next_station_time);
            para[198] = new SqlParameter("@s_next_station_time", s_next_station_time);
            para[199] = new SqlParameter("@a_prev_station_time", a_prev_station_time);
            para[200] = new SqlParameter("@e_prev_station_time", e_prev_station_time);
            para[201] = new SqlParameter("@s_prev_station_time", s_prev_station_time);
            para[202] = new SqlParameter("@land", land);
            para[203] = new SqlParameter("@airb", airb);
            para[204] = new SqlParameter("@ten_miles_time", ten_miles_time);
            para[205] = new SqlParameter("@org3", org3);
            para[206] = new SqlParameter("@des3", des3);
            para[207] = new SqlParameter("@org_icao", org_icao);
            para[208] = new SqlParameter("@des_icao", des_icao);
            para[209] = new SqlParameter("@via1", via1);
            para[210] = new SqlParameter("@via_icao", via_icao);
            para[211] = new SqlParameter("@public_flt", public_flt);
            para[212] = new SqlParameter("@public_flc", public_flc);
            para[213] = new SqlParameter("@public_time", public_time);
            para[214] = new SqlParameter("@secure_stand_is_required", secure_stand_is_required);
            para[215] = new SqlParameter("@stod", stod);
            para[216] = new SqlParameter("@stpo", stpo);
            para[217] = new SqlParameter("@operationtype_code2", operationtype_code2);
            para[218] = new SqlParameter("@firstbag_time2", firstbag_time2);
            para[219] = new SqlParameter("@lastbag_time2", lastbag_time2);
            para[220] = new SqlParameter("@operationtype_role1", operationtype_role1);
            para[221] = new SqlParameter("@operationtype_role2", operationtype_role2);
            para[222] = new SqlParameter("@update_time", update_time);
            para[223] = new SqlParameter("@custom_status", custom_status);
            para[224] = new SqlParameter("@sub_airline", sub_airline);
            para[225] = new SqlParameter("@ltd", ltd);
            para[226] = new SqlParameter("@lta", lta);
            para[227] = new SqlParameter("@airline_terminal", airline_terminal);
            para[228] = new SqlParameter("@gate_plan_close_time1", gate_plan_close_time1);
            para[229] = new SqlParameter("@gate_plan_open_time1", gate_plan_open_time1);
            para[230] = new SqlParameter("@gate_plan_close_time2", gate_plan_close_time2);
            para[231] = new SqlParameter("@gate_plan_open_time2", gate_plan_open_time2);
            para[232] = new SqlParameter("@usec", usec);
            para[233] = new SqlParameter("@typc", typc);
            para[234] = new SqlParameter("@cdat", cdat);
            para[235] = new SqlParameter("@useu", useu);
            para[236] = new SqlParameter("@jfno", jfno);
            para[237] = new SqlParameter("@ctrl", ctrl);
            para[238] = new SqlParameter("@drct", drct);


            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void InsertAOCData(
                string urno, string carrier_iata, string carrier_icao, string fl_number, string fl_suffix, string flt, string flr, string sdt, string sdp, string linkedfl_flt,
                string linkedfl_carrier, string linkedfl_number, string linkedfl_suffix, string linkedfl_sdt, string linkedfl_flr, string linkfl_id, string masterfl_carrier,
                string masterfl_number, string masterfl_suffix, string mfdi, string masterfl_flr, string masterfl_id, string aircraft_callsign, string aircraft_owner,
                string aircraft_paxcap, string regn, string atc5, string aircraft_type, string aircraft_operator, string aircraft_terminal, string airport_iata,
                string brc1, string reclaim_role1, string brod, string brcd, string exitdoor1, string src2, string reclaim_role2, string sbro, string sbrc, string exitdoor2,
                string makeup_id1, string makeup_role1, string makeup_open_time1, string makeup_close_time1, string makeup_id2, string makeup_role2, string makeup_open_time2,
                string makeup_close_time2, string isbusrequired, string cc_type1, string ckif, string cc_role1, string cc_clusterid1, string codt, string ccdt, string cc_type2,
                string scdr, string cc_role2, string cc_clusterid2, string scodt, string sccdt, string sgcd, string sgod, string gate_bording_status2, string gate_role2, string sgn,
                string gcdt, string godt, string gbs, string gate_role1, string geno, string term, string remark_code1, string remark_type1, string remark_code2,
                string remark_type2, string remark_code3, string remark_type3, string remark_code4, string remark_type4, string runway_id, string s_info_type1, string s_info_text1,
                string s_info_type2, string s_info_text2, string s_info_type3, string s_info_text3, string s_info_type4, string s_info_text4, string s_info_type5, string s_info_text5,
                string account_code, string fl_classificationcode, string fl_statuscode, string css, string daia, string fl_cancelcode, string fl_operates_overnight, string ttyp,
                string fl_servicetype, string flti, string fl_transitcode, string handlingagent1, string handling_service1, string handlingagent2, string handling_service2, string handlingagent3,
                string handling_service3, string handlingagent4, string handling_service4, string handlingagent5, string handling_service5, string irr_number1, string irr_code1,
                string irr_duration1, string irr_number2, string irr_code2, string irr_duration2, string isgvf, string isreturnfl, string istransferfl, string newfl_reason, string operationtype_code1,
                string transfer_fl1, string transfer_fl2, string transfer_fl3, string transfer_fl4, string transfer_fl5, string transfer_fl6, string transfer_fl7, string transfer_fl8, string transfer_fl9,
                string transfer_fl10, string transfer_fl11, string transfer_fl12, string transfer_fl13, string transfer_fl14, string transfer_fl15, string transfer_fl16, string transfer_fl17,
                string transfer_fl18, string transfer_fl19, string transfer_fl20, string sharefl_flt1, string sharefl_fln1, string sharefl_flt2, string sharefl_fln2, string sharefl_flt3,
                string sharefl_fln3, string sharefl_flt4, string sharefl_fln4, string sharefl_flt5, string sharefl_fln5, string sharefl_flt6, string sharefl_fln6, string total_bagcount,
                string total_bagweight, string total_freightweight, string total_mailweight, string total_loadweight, string adult_paxcount, string bussiness_paxcount, string child_paxcount,
                string domesitec_paxcount, string infant_paxcount, string international_paxcount, string local_paxcount, string nontransfer_paxcount, string total_paxcount,
                string transfer_paxcount, string transit_paxcount, string whellchair_paxcount, string total_crewcount, string economy_paxcount, string firstclass_paxcount,
                string transfer_bagcount, string transfer_bagweight, string transfer_freightweight, string transfer_mailweight, string transit_bagcount, string transit_bagweight,
                string transit_freightweight, string transit_mailweight, string offblock_time, string onblock_time, string edta, string edtd, string e_fl_duration, string firstbag_time,
                string lastbag_time, string finalapproach_time, string lastknown_time, string lastknown_source, string next_info_time, string a_next_station_time, string e_next_station_time,
                string s_next_station_time, string a_prev_station_time, string e_prev_station_time, string s_prev_station_time, string land, string airb, string ten_miles_time,
                string org3, string des3, string org_icao, string des_icao, string via1, string via_icao, string public_flt, string public_flc, string public_time, string secure_stand_is_required,
                string stod, string stpo, string operationtype_code2, string firstbag_time2, string lastbag_time2, string operationtype_role1, string operationtype_role2,
                string update_time, string custom_status, string sub_airline, string ltd, string lta, string airline_terminal, string gate_plan_close_time1, string gate_plan_open_time1,
                string gate_plan_close_time2, string gate_plan_open_time2, string usec, string typc, DateTime cdat, string useu, string typu, DateTime lstu, string jfno, int ctrl, string drct,
                SqlTransaction trans
            )
        {
            string sql = @"INSERT INTO [AOCFQS] (
                                    [URNO], [CARRIER_IATA], [CARRIER_ICAO], [FL_NUMBER], [FL_SUFFIX], [FLT], [FLR], [SDT], [SDP], [LINKEDFL_FLT], 
                                    [LINKEDFL_CARRIER], [LINKEDFL_NUMBER], [LINKEDFL_SUFFIX], [LINKEDFL_SDT], [LINKEDFL_FLR], [LINKFL_ID], [MASTERFL_CARRIER], 
                                    [MASTERFL_NUMBER], [MASTERFL_SUFFIX], [MFDI], [MASTERFL_FLR], [MASTERFL_ID], [AIRCRAFT_CALLSIGN], [AIRCRAFT_OWNER], 
                                    [AIRCRAFT_PAXCAP], [REGN], [ATC5], [AIRCRAFT_TYPE], [AIRCRAFT_OPERATOR], [AIRCRAFT_TERMINAL], [AIRPORT_IATA], 
                                    [BRC1], [RECLAIM_ROLE1], [BROD], [BRCD], [EXITDOOR1], [SRC2], [RECLAIM_ROLE2], [SBRO], [SBRC], [EXITDOOR2], [MAKEUP_ID1], [MAKEUP_ROLE1], 
                                    [MAKEUP_OPEN_TIME1], [MAKEUP_CLOSE_TIME1], [MAKEUP_ID2], [MAKEUP_ROLE2], [MAKEUP_OPEN_TIME2], [MAKEUP_CLOSE_TIME2], [ISBUSREQUIRED], 
                                    [CC_TYPE1], [CKIF], [CC_ROLE1], [CC_CLUSTERID1], [CODT], [CCDT], [CC_TYPE2], [SCDR], [CC_ROLE2], [CC_CLUSTERID2], [SCODT], [SCCDT], [SGCD], 
                                    [SGOD], [GATE_BORDING_STATUS2], [GATE_ROLE2], [SGN], [GCDT], [GODT], [GBS], [GATE_ROLE1], [GENO], [TERM], [REMARK_CODE1], 
                                    [REMARK_TYPE1], [REMARK_CODE2], [REMARK_TYPE2], [REMARK_CODE3], [REMARK_TYPE3], [REMARK_CODE4], [REMARK_TYPE4], [RUNWAY_ID], 
                                    [S_INFO_TYPE1], [S_INFO_TEXT1], [S_INFO_TYPE2], [S_INFO_TEXT2], [S_INFO_TYPE3], [S_INFO_TEXT3], [S_INFO_TYPE4], [S_INFO_TEXT4], 
                                    [S_INFO_TYPE5], [S_INFO_TEXT5], [ACCOUNT_CODE], [FL_CLASSIFICATIONCODE], [FL_STATUSCODE], [CSS], [DAIA], [FL_CANCELCODE], [FL_OPERATES_OVERNIGHT], 
                                    [TTYP], [FL_SERVICETYPE], [FLTI], [FL_TRANSITCODE], [HANDLINGAGENT1], [HANDLING_SERVICE1], [HANDLINGAGENT2], [HANDLING_SERVICE2], [HANDLINGAGENT3], 
                                    [HANDLING_SERVICE3], [HANDLINGAGENT4], [HANDLING_SERVICE4], [HANDLINGAGENT5], [HANDLING_SERVICE5], [IRR_NUMBER1], [IRR_CODE1], [IRR_DURATION1], 
                                    [IRR_NUMBER2], [IRR_CODE2], [IRR_DURATION2], [ISGVF], [ISRETURNFL], [ISTRANSFERFL], [NEWFL_REASON], [OPERATIONTYPE_CODE1], [TRANSFER_FL1], 
                                    [TRANSFER_FL2], [TRANSFER_FL3], [TRANSFER_FL4], [TRANSFER_FL5], [TRANSFER_FL6], [TRANSFER_FL7], [TRANSFER_FL8], [TRANSFER_FL9], [TRANSFER_FL10], 
                                    [TRANSFER_FL11], [TRANSFER_FL12], [TRANSFER_FL13], [TRANSFER_FL14], [TRANSFER_FL15], [TRANSFER_FL16], [TRANSFER_FL17], [TRANSFER_FL18], [TRANSFER_FL19], 
                                    [TRANSFER_FL20], [SHAREFL_FLT1], [SHAREFL_FLN1], [SHAREFL_FLT2], [SHAREFL_FLN2], [SHAREFL_FLT3], [SHAREFL_FLN3], [SHAREFL_FLT4], [SHAREFL_FLN4], 
                                    [SHAREFL_FLT5], [SHAREFL_FLN5], [SHAREFL_FLT6], [SHAREFL_FLN6], [TOTAL_BAGCOUNT], [TOTAL_BAGWEIGHT], [TOTAL_FREIGHTWEIGHT], [TOTAL_MAILWEIGHT], 
                                    [TOTAL_LOADWEIGHT], [ADULT_PAXCOUNT], [BUSSINESS_PAXCOUNT], [CHILD_PAXCOUNT], [DOMESITEC_PAXCOUNT], [INFANT_PAXCOUNT], [INTERNATIONAL_PAXCOUNT], 
                                    [LOCAL_PAXCOUNT], [NONTRANSFER_PAXCOUNT], [TOTAL_PAXCOUNT], [TRANSFER_PAXCOUNT], [TRANSIT_PAXCOUNT], [WHELLCHAIR_PAXCOUNT], [TOTAL_CREWCOUNT], 
                                    [ECONOMY_PAXCOUNT], [FIRSTCLASS_PAXCOUNT], [TRANSFER_BAGCOUNT], [TRANSFER_BAGWEIGHT], [TRANSFER_FREIGHTWEIGHT], [TRANSFER_MAILWEIGHT], 
                                    [TRANSIT_BAGCOUNT], [TRANSIT_BAGWEIGHT], [TRANSIT_FREIGHTWEIGHT], [TRANSIT_MAILWEIGHT], [OFFBLOCK_TIME], [ONBLOCK_TIME], [EDTA], [EDTD], [E_FL_DURATION], 
                                    [FIRSTBAG_TIME], [LASTBAG_TIME], [FINALAPPROACH_TIME], [LASTKNOWN_TIME], [LASTKNOWN_SOURCE], [NEXT_INFO_TIME], [A_NEXT_STATION_TIME], 
                                    [E_NEXT_STATION_TIME], [S_NEXT_STATION_TIME], [A_PREV_STATION_TIME], [E_PREV_STATION_TIME], [S_PREV_STATION_TIME], [LAND], [AIRB], [TEN_MILES_TIME], 
                                    [ORG3], [DES3], [ORG_ICAO], [DES_ICAO], [VIA1], [VIA_ICAO], [PUBLIC_FLT], [PUBLIC_FLC], [PUBLIC_TIME], [SECURE_STAND_IS_REQUIRED], [STOD], [STPO], 
                                    [OPERATIONTYPE_CODE2], [FIRSTBAG_TIME2], [LASTBAG_TIME2], [OPERATIONTYPE_ROLE1], [OPERATIONTYPE_ROLE2], [UPDATE_TIME], [CUSTOM_STATUS], 
                                    [SUB_AIRLINE], [LTD], [LTA], [AIRLINE_TERMINAL], [GATE_PLAN_CLOSE_TIME1], [GATE_PLAN_OPEN_TIME1], [GATE_PLAN_CLOSE_TIME2], [GATE_PLAN_OPEN_TIME2], 
                                    [USEC], [TYPC], [CDAT], [USEU], [JFNO], [CTRL], [DRCT]) 
                               VALUES (
                                    @urno, @carrier_iata, @carrier_icao, @fl_number, @fl_suffix, @flt, @flr, @sdt, @sdp, @linkedfl_flt, @linkedfl_carrier, @linkedfl_number, @linkedfl_suffix, @linkedfl_sdt,
                                    @linkedfl_flr, @linkfl_id, @masterfl_carrier, @masterfl_number, @masterfl_suffix, @mfdi, @masterfl_flr, @masterfl_id, @aircraft_callsign, @aircraft_owner, @aircraft_paxcap, 
                                    @regn, @atc5, @aircraft_type, @aircraft_operator, @aircraft_terminal, @airport_iata, @brc1, @reclaim_role1, @brod, @brcd, @exitdoor1, @src2, @reclaim_role2, 
                                    @sbro, @sbrc, @exitdoor2, @makeup_id1, @makeup_role1, @makeup_open_time1, @makeup_close_time1, @makeup_id2, @makeup_role2, @makeup_open_time2, @makeup_close_time2, 
                                    @isbusrequired, @cc_type1, @ckif, @cc_role1, @cc_clusterid1, @codt, @ccdt, @cc_type2, @scdr, @cc_role2, @cc_clusterid2, @scodt, @sccdt, @sgcd, @sgod, 
                                    @gate_bording_status2, @gate_role2, @sgn, @gcdt, @godt, @gbs, @gate_role1, @geno, @term, @remark_code1, @remark_type1, @remark_code2, 
                                    @remark_type2, @remark_code3, @remark_type3, @remark_code4, @remark_type4, @runway_id, @s_info_type1, @s_info_text1, @s_info_type2, @s_info_text2, 
                                    @s_info_type3, @s_info_text3, @s_info_type4, @s_info_text4, @s_info_type5, @s_info_text5, @account_code, @fl_classificationcode, @fl_statuscode, @css, @daia, 
                                    @fl_cancelcode, @fl_operates_overnight, @ttyp, @fl_servicetype, @flti, @fl_transitcode, @handlingagent1, @handling_service1, @handlingagent2, @handling_service2, 
                                    @handlingagent3, @handling_service3, @handlingagent4, @handling_service4, @handlingagent5, @handling_service5, @irr_number1, @irr_code1, @irr_duration1, @irr_number2, 
                                    @irr_code2, @irr_duration2, @isgvf, @isreturnfl, @istransferfl, @newfl_reason, @operationtype_code1, @transfer_fl1, @transfer_fl2, @transfer_fl3, @transfer_fl4, @transfer_fl5, 
                                    @transfer_fl6, @transfer_fl7, @transfer_fl8, @transfer_fl9, @transfer_fl10, @transfer_fl11, @transfer_fl12, @transfer_fl13, @transfer_fl14, @transfer_fl15, @transfer_fl16, 
                                    @transfer_fl17, @transfer_fl18, @transfer_fl19, @transfer_fl20, @sharefl_flt1, @sharefl_fln1, @sharefl_flt2, @sharefl_fln2, @sharefl_flt3, @sharefl_fln3, @sharefl_flt4, 
                                    @sharefl_fln4, @sharefl_flt5, @sharefl_fln5, @sharefl_flt6, @sharefl_fln6, @total_bagcount, @total_bagweight, @total_freightweight, @total_mailweight, @total_loadweight, 
                                    @adult_paxcount, @bussiness_paxcount, @child_paxcount, @domesitec_paxcount, @infant_paxcount, @international_paxcount, @local_paxcount, @nontransfer_paxcount, 
                                    @total_paxcount, @transfer_paxcount, @transit_paxcount, @whellchair_paxcount, @total_crewcount, @economy_paxcount, @firstclass_paxcount, @transfer_bagcount, 
                                    @transfer_bagweight, @transfer_freightweight, @transfer_mailweight, @transit_bagcount, @transit_bagweight, @transit_freightweight, @transit_mailweight, @offblock_time, 
                                    @onblock_time, @edta, @edtd, @e_fl_duration, @firstbag_time, @lastbag_time, @finalapproach_time, @lastknown_time, @lastknown_source, @next_info_time, @a_next_station_time, 
                                    @e_next_station_time, @s_next_station_time, @a_prev_station_time, @e_prev_station_time, @s_prev_station_time, @land, @airb, @ten_miles_time, @org3, @des3, @org_icao, 
                                    @des_icao, @via1, @via_icao, @public_flt, @public_flc, @public_time, @secure_stand_is_required, @stod, @stpo, @operationtype_code2, @firstbag_time2, @lastbag_time2, 
                                    @operationtype_role1, @operationtype_role2, @update_time, @custom_status, @sub_airline, @ltd, @lta, @airline_terminal, @gate_plan_close_time1, @gate_plan_open_time1, 
                                    @gate_plan_close_time2, @gate_plan_open_time2, @usec, @typc, @cdat, @useu, @jfno, @ctrl, @drct)";

            SqlParameter[] para = new SqlParameter[239];
            para[0] = new SqlParameter();
            para[1] = new SqlParameter("@urno", urno);
            para[2] = new SqlParameter("@carrier_iata", carrier_iata);
            para[3] = new SqlParameter("@carrier_icao", carrier_icao);
            para[4] = new SqlParameter("@fl_number", fl_number);
            para[5] = new SqlParameter("@fl_suffix", fl_suffix);
            para[6] = new SqlParameter("@flt", flt);
            para[7] = new SqlParameter("@flr", flr);
            para[8] = new SqlParameter("@sdt", sdt);
            para[9] = new SqlParameter("@sdp", sdp);
            para[10] = new SqlParameter("@linkedfl_flt", linkedfl_flt);
            para[11] = new SqlParameter("@linkedfl_carrier", linkedfl_carrier);
            para[12] = new SqlParameter("@linkedfl_number", linkedfl_number);
            para[13] = new SqlParameter("@linkedfl_suffix", linkedfl_suffix);
            para[14] = new SqlParameter("@linkedfl_sdt", linkedfl_sdt);
            para[15] = new SqlParameter("@linkedfl_flr", linkedfl_flr);
            para[16] = new SqlParameter("@linkfl_id", linkfl_id);
            para[17] = new SqlParameter("@masterfl_carrier", masterfl_carrier);
            para[18] = new SqlParameter("@masterfl_number", masterfl_number);
            para[19] = new SqlParameter("@masterfl_suffix", masterfl_suffix);
            para[20] = new SqlParameter("@mfdi", mfdi);
            para[21] = new SqlParameter("@masterfl_flr", masterfl_flr);
            para[22] = new SqlParameter("@masterfl_id", masterfl_id);
            para[23] = new SqlParameter("@aircraft_callsign", aircraft_callsign);
            para[24] = new SqlParameter("@aircraft_owner", aircraft_owner);
            para[25] = new SqlParameter("@aircraft_paxcap", aircraft_paxcap);
            para[26] = new SqlParameter("@regn", regn);
            para[27] = new SqlParameter("@atc5", atc5);
            para[28] = new SqlParameter("@aircraft_type", aircraft_type);
            para[29] = new SqlParameter("@aircraft_operator", aircraft_operator);
            para[30] = new SqlParameter("@aircraft_terminal", aircraft_terminal);
            para[31] = new SqlParameter("@airport_iata", airport_iata);
            para[32] = new SqlParameter("@brc1", brc1);
            para[33] = new SqlParameter("@reclaim_role1", reclaim_role1);
            para[34] = new SqlParameter("@brod", brod);
            para[35] = new SqlParameter("@brcd", brcd);
            para[36] = new SqlParameter("@exitdoor1", exitdoor1);
            para[37] = new SqlParameter("@src2", src2);
            para[38] = new SqlParameter("@reclaim_role2", reclaim_role2);
            para[39] = new SqlParameter("@sbro", sbro);
            para[40] = new SqlParameter("@sbrc", sbrc);
            para[41] = new SqlParameter("@exitdoor2", exitdoor2);
            para[42] = new SqlParameter("@makeup_id1", makeup_id1);
            para[43] = new SqlParameter("@makeup_role1", makeup_role1);
            para[44] = new SqlParameter("@makeup_open_time1", makeup_open_time1);
            para[45] = new SqlParameter("@makeup_close_time1", makeup_close_time1);
            para[46] = new SqlParameter("@makeup_id2", makeup_id2);
            para[47] = new SqlParameter("@makeup_role2", makeup_role2);
            para[48] = new SqlParameter("@makeup_open_time2", makeup_open_time2);
            para[49] = new SqlParameter("@makeup_close_time2", makeup_close_time2);
            para[50] = new SqlParameter("@isbusrequired", isbusrequired);
            para[51] = new SqlParameter("@cc_type1", cc_type1);
            para[52] = new SqlParameter("@ckif", ckif);
            para[53] = new SqlParameter("@cc_role1", cc_role1);
            para[54] = new SqlParameter("@cc_clusterid1", cc_clusterid1);
            para[55] = new SqlParameter("@codt", codt);
            para[56] = new SqlParameter("@ccdt", ccdt);
            para[57] = new SqlParameter("@cc_type2", cc_type2);
            para[58] = new SqlParameter("@scdr", scdr);
            para[59] = new SqlParameter("@cc_role2", cc_role2);
            para[60] = new SqlParameter("@cc_clusterid2", cc_clusterid2);
            para[61] = new SqlParameter("@scodt", scodt);
            para[62] = new SqlParameter("@sccdt", sccdt);
            para[63] = new SqlParameter("@sgcd", sgcd);
            para[64] = new SqlParameter("@sgod", sgod);
            para[65] = new SqlParameter("@gate_bording_status2", gate_bording_status2);
            para[66] = new SqlParameter("@gate_role2", gate_role2);
            para[67] = new SqlParameter("@sgn", sgn);
            para[68] = new SqlParameter("@gcdt", gcdt);
            para[69] = new SqlParameter("@godt", godt);
            para[70] = new SqlParameter("@gbs", gbs);
            para[71] = new SqlParameter("@gate_role1", gate_role1);
            para[72] = new SqlParameter("@geno", geno);
            para[73] = new SqlParameter("@term", term);
            para[74] = new SqlParameter("@remark_code1", remark_code1);
            para[75] = new SqlParameter("@remark_type1", remark_type1);
            para[76] = new SqlParameter("@remark_code2", remark_code2);
            para[77] = new SqlParameter("@remark_type2", remark_type2);
            para[78] = new SqlParameter("@remark_code3", remark_code3);
            para[79] = new SqlParameter("@remark_type3", remark_type3);
            para[80] = new SqlParameter("@remark_code4", remark_code4);
            para[81] = new SqlParameter("@remark_type4", remark_type4);
            para[82] = new SqlParameter("@runway_id", runway_id);
            para[83] = new SqlParameter("@s_info_type1", s_info_type1);
            para[84] = new SqlParameter("@s_info_text1", s_info_text1);
            para[85] = new SqlParameter("@s_info_type2", s_info_type2);
            para[86] = new SqlParameter("@s_info_text2", s_info_text2);
            para[87] = new SqlParameter("@s_info_type3", s_info_type3);
            para[88] = new SqlParameter("@s_info_text3", s_info_text3);
            para[89] = new SqlParameter("@s_info_type4", s_info_type4);
            para[90] = new SqlParameter("@s_info_text4", s_info_text4);
            para[91] = new SqlParameter("@s_info_type5", s_info_type5);
            para[92] = new SqlParameter("@s_info_text5", s_info_text5);
            para[93] = new SqlParameter("@account_code", account_code);
            para[94] = new SqlParameter("@fl_classificationcode", fl_classificationcode);
            para[95] = new SqlParameter("@fl_statuscode", fl_statuscode);
            para[96] = new SqlParameter("@css", css);
            para[97] = new SqlParameter("@daia", daia);
            para[98] = new SqlParameter("@fl_cancelcode", fl_cancelcode);
            para[99] = new SqlParameter("@fl_operates_overnight", fl_operates_overnight);
            para[100] = new SqlParameter("@ttyp", ttyp);
            para[101] = new SqlParameter("@fl_servicetype", fl_servicetype);
            para[102] = new SqlParameter("@flti", flti);
            para[103] = new SqlParameter("@fl_transitcode", fl_transitcode);
            para[104] = new SqlParameter("@handlingagent1", handlingagent1);
            para[105] = new SqlParameter("@handling_service1", handling_service1);
            para[106] = new SqlParameter("@handlingagent2", handlingagent2);
            para[107] = new SqlParameter("@handling_service2", handling_service2);
            para[108] = new SqlParameter("@handlingagent3", handlingagent3);
            para[109] = new SqlParameter("@handling_service3", handling_service3);
            para[110] = new SqlParameter("@handlingagent4", handlingagent4);
            para[111] = new SqlParameter("@handling_service4", handling_service4);
            para[112] = new SqlParameter("@handlingagent5", handlingagent5);
            para[113] = new SqlParameter("@handling_service5", handling_service5);
            para[114] = new SqlParameter("@irr_number1", irr_number1);
            para[115] = new SqlParameter("@irr_code1", irr_code1);
            para[116] = new SqlParameter("@irr_duration1", irr_duration1);
            para[117] = new SqlParameter("@irr_number2", irr_number2);
            para[118] = new SqlParameter("@irr_code2", irr_code2);
            para[119] = new SqlParameter("@irr_duration2", irr_duration2);
            para[120] = new SqlParameter("@isgvf", isgvf);
            para[121] = new SqlParameter("@isreturnfl", isreturnfl);
            para[122] = new SqlParameter("@istransferfl", istransferfl);
            para[123] = new SqlParameter("@newfl_reason", newfl_reason);
            para[124] = new SqlParameter("@operationtype_code1", operationtype_code1);
            para[125] = new SqlParameter("@transfer_fl1", transfer_fl1);
            para[126] = new SqlParameter("@transfer_fl2", transfer_fl2);
            para[127] = new SqlParameter("@transfer_fl3", transfer_fl3);
            para[128] = new SqlParameter("@transfer_fl4", transfer_fl4);
            para[129] = new SqlParameter("@transfer_fl5", transfer_fl5);
            para[130] = new SqlParameter("@transfer_fl6", transfer_fl6);
            para[131] = new SqlParameter("@transfer_fl7", transfer_fl7);
            para[132] = new SqlParameter("@transfer_fl8", transfer_fl8);
            para[133] = new SqlParameter("@transfer_fl9", transfer_fl9);
            para[134] = new SqlParameter("@transfer_fl10", transfer_fl10);
            para[135] = new SqlParameter("@transfer_fl11", transfer_fl11);
            para[136] = new SqlParameter("@transfer_fl12", transfer_fl12);
            para[137] = new SqlParameter("@transfer_fl13", transfer_fl13);
            para[138] = new SqlParameter("@transfer_fl14", transfer_fl14);
            para[139] = new SqlParameter("@transfer_fl15", transfer_fl15);
            para[140] = new SqlParameter("@transfer_fl16", transfer_fl16);
            para[141] = new SqlParameter("@transfer_fl17", transfer_fl17);
            para[142] = new SqlParameter("@transfer_fl18", transfer_fl18);
            para[143] = new SqlParameter("@transfer_fl19", transfer_fl19);
            para[144] = new SqlParameter("@transfer_fl20", transfer_fl20);
            para[145] = new SqlParameter("@sharefl_flt1", sharefl_flt1);
            para[146] = new SqlParameter("@sharefl_fln1", sharefl_fln1);
            para[147] = new SqlParameter("@sharefl_flt2", sharefl_flt2);
            para[148] = new SqlParameter("@sharefl_fln2", sharefl_fln2);
            para[149] = new SqlParameter("@sharefl_flt3", sharefl_flt3);
            para[150] = new SqlParameter("@sharefl_fln3", sharefl_fln3);
            para[151] = new SqlParameter("@sharefl_flt4", sharefl_flt4);
            para[152] = new SqlParameter("@sharefl_fln4", sharefl_fln4);
            para[153] = new SqlParameter("@sharefl_flt5", sharefl_flt5);
            para[154] = new SqlParameter("@sharefl_fln5", sharefl_fln5);
            para[155] = new SqlParameter("@sharefl_flt6", sharefl_flt6);
            para[156] = new SqlParameter("@sharefl_fln6", sharefl_fln6);
            para[157] = new SqlParameter("@total_bagcount", total_bagcount);
            para[158] = new SqlParameter("@total_bagweight", total_bagweight);
            para[159] = new SqlParameter("@total_freightweight", total_freightweight);
            para[160] = new SqlParameter("@total_mailweight", total_mailweight);
            para[161] = new SqlParameter("@total_loadweight", total_loadweight);
            para[162] = new SqlParameter("@adult_paxcount", adult_paxcount);
            para[163] = new SqlParameter("@bussiness_paxcount", bussiness_paxcount);
            para[164] = new SqlParameter("@child_paxcount", child_paxcount);
            para[165] = new SqlParameter("@domesitec_paxcount", domesitec_paxcount);
            para[166] = new SqlParameter("@infant_paxcount", infant_paxcount);
            para[167] = new SqlParameter("@international_paxcount", international_paxcount);
            para[168] = new SqlParameter("@local_paxcount", local_paxcount);
            para[169] = new SqlParameter("@nontransfer_paxcount", nontransfer_paxcount);
            para[170] = new SqlParameter("@total_paxcount", total_paxcount);
            para[171] = new SqlParameter("@transfer_paxcount", transfer_paxcount);
            para[172] = new SqlParameter("@transit_paxcount", transit_paxcount);
            para[173] = new SqlParameter("@whellchair_paxcount", whellchair_paxcount);
            para[174] = new SqlParameter("@total_crewcount", total_crewcount);
            para[175] = new SqlParameter("@economy_paxcount", economy_paxcount);
            para[176] = new SqlParameter("@firstclass_paxcount", firstclass_paxcount);
            para[177] = new SqlParameter("@transfer_bagcount", transfer_bagcount);
            para[178] = new SqlParameter("@transfer_bagweight", transfer_bagweight);
            para[179] = new SqlParameter("@transfer_freightweight", transfer_freightweight);
            para[180] = new SqlParameter("@transfer_mailweight", transfer_mailweight);
            para[181] = new SqlParameter("@transit_bagcount", transit_bagcount);
            para[182] = new SqlParameter("@transit_bagweight", transit_bagweight);
            para[183] = new SqlParameter("@transit_freightweight", transit_freightweight);
            para[184] = new SqlParameter("@transit_mailweight", transit_mailweight);
            para[185] = new SqlParameter("@offblock_time", offblock_time);
            para[186] = new SqlParameter("@onblock_time", onblock_time);
            para[187] = new SqlParameter("@edta", edta);
            para[188] = new SqlParameter("@edtd", edtd);
            para[189] = new SqlParameter("@e_fl_duration", e_fl_duration);
            para[190] = new SqlParameter("@firstbag_time", firstbag_time);
            para[191] = new SqlParameter("@lastbag_time", lastbag_time);
            para[192] = new SqlParameter("@finalapproach_time", finalapproach_time);
            para[193] = new SqlParameter("@lastknown_time", lastknown_time);
            para[194] = new SqlParameter("@lastknown_source", lastknown_source);
            para[195] = new SqlParameter("@next_info_time", next_info_time);
            para[196] = new SqlParameter("@a_next_station_time", a_next_station_time);
            para[197] = new SqlParameter("@e_next_station_time", e_next_station_time);
            para[198] = new SqlParameter("@s_next_station_time", s_next_station_time);
            para[199] = new SqlParameter("@a_prev_station_time", a_prev_station_time);
            para[200] = new SqlParameter("@e_prev_station_time", e_prev_station_time);
            para[201] = new SqlParameter("@s_prev_station_time", s_prev_station_time);
            para[202] = new SqlParameter("@land", land);
            para[203] = new SqlParameter("@airb", airb);
            para[204] = new SqlParameter("@ten_miles_time", ten_miles_time);
            para[205] = new SqlParameter("@org3", org3);
            para[206] = new SqlParameter("@des3", des3);
            para[207] = new SqlParameter("@org_icao", org_icao);
            para[208] = new SqlParameter("@des_icao", des_icao);
            para[209] = new SqlParameter("@via1", via1);
            para[210] = new SqlParameter("@via_icao", via_icao);
            para[211] = new SqlParameter("@public_flt", public_flt);
            para[212] = new SqlParameter("@public_flc", public_flc);
            para[213] = new SqlParameter("@public_time", public_time);
            para[214] = new SqlParameter("@secure_stand_is_required", secure_stand_is_required);
            para[215] = new SqlParameter("@stod", stod);
            para[216] = new SqlParameter("@stpo", stpo);
            para[217] = new SqlParameter("@operationtype_code2", operationtype_code2);
            para[218] = new SqlParameter("@firstbag_time2", firstbag_time2);
            para[219] = new SqlParameter("@lastbag_time2", lastbag_time2);
            para[220] = new SqlParameter("@operationtype_role1", operationtype_role1);
            para[221] = new SqlParameter("@operationtype_role2", operationtype_role2);
            para[222] = new SqlParameter("@update_time", update_time);
            para[223] = new SqlParameter("@custom_status", custom_status);
            para[224] = new SqlParameter("@sub_airline", sub_airline);
            para[225] = new SqlParameter("@ltd", ltd);
            para[226] = new SqlParameter("@lta", lta);
            para[227] = new SqlParameter("@airline_terminal", airline_terminal);
            para[228] = new SqlParameter("@gate_plan_close_time1", gate_plan_close_time1);
            para[229] = new SqlParameter("@gate_plan_open_time1", gate_plan_open_time1);
            para[230] = new SqlParameter("@gate_plan_close_time2", gate_plan_close_time2);
            para[231] = new SqlParameter("@gate_plan_open_time2", gate_plan_open_time2);
            para[232] = new SqlParameter("@usec", usec);
            para[233] = new SqlParameter("@typc", typc);
            para[234] = new SqlParameter("@cdat", cdat);
            para[235] = new SqlParameter("@useu", useu);
            para[236] = new SqlParameter("@jfno", jfno);
            para[237] = new SqlParameter("@ctrl", ctrl);
            para[238] = new SqlParameter("@drct", drct);
            if (trans != null)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, para);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
            }
        }

        public static void DeleteAOCData(Guid aGuid)
        {
            string sql = "DELETE FROM [AOCFQS] WHERE ID = @aGuid";

            SqlParameter[] para = { new SqlParameter("@aGuid", aGuid) };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void DeleteAOCData(Guid aGuid, SqlTransaction trans)
        {
            string sql = "DELETE FROM [AOCFQS] WHERE ID = @aGuid";

            SqlParameter[] para = { new SqlParameter("@aGuid", aGuid) };

            if (trans != null)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, para);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
            }
        }

        //按照日期删除
        public static void DeleteAOCData(DateTime dateTimeStart, DateTime dateTimeEnd, SqlTransaction trans)
        {
            //string sql = "DELETE FROM [AOCFQS] WHERE (STOD BETWEEN @dateTimeStart AND @dateTimeEnd) OR (SDT BETWEEN @dateTimeStart AND @dateTimeEnd)";
            string sql = "DELETE FROM [AOCFQS] WHERE (STOD BETWEEN @dateTimeStart AND @dateTimeEnd) ";
            //SqlParameter[] para = { new SqlParameter("@dateTimeStart", dateTimeStart), new SqlParameter("@dateTimeEnd", dateTimeEnd) };
            SqlParameter[] para = { new SqlParameter("@dateTimeStart", dateTimeStart.ToString("yyyyMMddHHmmss")), new SqlParameter("@dateTimeEnd", dateTimeEnd.ToString("yyyyMMddHHmmss")) };
            if (trans != null)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, para);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
            }
        }

        public static void DeleteAOCData( DateTime dateTimeEnd, SqlTransaction trans)
        {
            //string sql = "DELETE FROM [AOCFQS] WHERE STOD <@dateTimeEnd OR SDT <@dateTimeEnd";
            string sql = "DELETE FROM [AOCFQS] WHERE STOD <@dateTimeEnd";

            //SqlParameter[] para = { new SqlParameter("@dateTimeStart", dateTimeStart), new SqlParameter("@dateTimeEnd", dateTimeEnd) };
            SqlParameter[] para = { new SqlParameter("@dateTimeEnd", dateTimeEnd.ToString("yyyyMMddHHmmss")) };
            if (trans != null)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, para);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
            }
        }



        public static DataTable GetAOCDatas()
        {
            string sql = @"SELECT [ID], [URNO], [CARRIER_IATA], [CARRIER_ICAO], [FL_NUMBER], [FL_SUFFIX], [FLT], [FLR], [SDT], [SDP], [LINKEDFL_FLT], 
                                [LINKEDFL_CARRIER], [LINKEDFL_NUMBER], [LINKEDFL_SUFFIX], [LINKEDFL_SDT], [LINKEDFL_FLR], [LINKFL_ID], [MASTERFL_CARRIER], 
                                [MASTERFL_NUMBER], [MASTERFL_SUFFIX], [MFDI], [MASTERFL_FLR], [MASTERFL_ID], [AIRCRAFT_CALLSIGN], [AIRCRAFT_OWNER], 
                                [AIRCRAFT_PAXCAP], [REGN], [ATC5], [AIRCRAFT_TYPE], [AIRCRAFT_OPERATOR], [AIRCRAFT_TERMINAL], [AIRPORT_IATA], 
                                [BRC1], [RECLAIM_ROLE1], [BROD], [BRCD], [EXITDOOR1], [SRC2], [RECLAIM_ROLE2], [SBRO], [SBRC], [EXITDOOR2], [MAKEUP_ID1], [MAKEUP_ROLE1], 
                                [MAKEUP_OPEN_TIME1], [MAKEUP_CLOSE_TIME1], [MAKEUP_ID2], [MAKEUP_ROLE2], [MAKEUP_OPEN_TIME2], [MAKEUP_CLOSE_TIME2], [ISBUSREQUIRED], 
                                [CC_TYPE1], [CKIF], [CC_ROLE1], [CC_CLUSTERID1], [CODT], [CCDT], [CC_TYPE2], [SCDR], [CC_ROLE2], [CC_CLUSTERID2], [SCODT], [SCCDT], [SGCD], 
                                [SGOD], [GATE_BORDING_STATUS2], [GATE_ROLE2], [SGN], [GCDT], [GODT], [GBS], [GATE_ROLE1], [GENO], [TERM], [REMARK_CODE1], 
                                [REMARK_TYPE1], [REMARK_CODE2], [REMARK_TYPE2], [REMARK_CODE3], [REMARK_TYPE3], [REMARK_CODE4], [REMARK_TYPE4], [RUNWAY_ID], 
                                [S_INFO_TYPE1], [S_INFO_TEXT1], [S_INFO_TYPE2], [S_INFO_TEXT2], [S_INFO_TYPE3], [S_INFO_TEXT3], [S_INFO_TYPE4], [S_INFO_TEXT4], 
                                [S_INFO_TYPE5], [S_INFO_TEXT5], [ACCOUNT_CODE], [FL_CLASSIFICATIONCODE], [FL_STATUSCODE], [CSS], [DAIA], [FL_CANCELCODE], [FL_OPERATES_OVERNIGHT], 
                                [TTYP], [FL_SERVICETYPE], [FLTI], [FL_TRANSITCODE], [HANDLINGAGENT1], [HANDLING_SERVICE1], [HANDLINGAGENT2], [HANDLING_SERVICE2], [HANDLINGAGENT3], 
                                [HANDLING_SERVICE3], [HANDLINGAGENT4], [HANDLING_SERVICE4], [HANDLINGAGENT5], [HANDLING_SERVICE5], [IRR_NUMBER1], [IRR_CODE1], [IRR_DURATION1], 
                                [IRR_NUMBER2], [IRR_CODE2], [IRR_DURATION2], [ISGVF], [ISRETURNFL], [ISTRANSFERFL], [NEWFL_REASON], [OPERATIONTYPE_CODE1], [TRANSFER_FL1], 
                                [TRANSFER_FL2], [TRANSFER_FL3], [TRANSFER_FL4], [TRANSFER_FL5], [TRANSFER_FL6], [TRANSFER_FL7], [TRANSFER_FL8], [TRANSFER_FL9], [TRANSFER_FL10], 
                                [TRANSFER_FL11], [TRANSFER_FL12], [TRANSFER_FL13], [TRANSFER_FL14], [TRANSFER_FL15], [TRANSFER_FL16], [TRANSFER_FL17], [TRANSFER_FL18], [TRANSFER_FL19], 
                                [TRANSFER_FL20], [SHAREFL_FLT1], [SHAREFL_FLN1], [SHAREFL_FLT2], [SHAREFL_FLN2], [SHAREFL_FLT3], [SHAREFL_FLN3], [SHAREFL_FLT4], [SHAREFL_FLN4], 
                                [SHAREFL_FLT5], [SHAREFL_FLN5], [SHAREFL_FLT6], [SHAREFL_FLN6], [TOTAL_BAGCOUNT], [TOTAL_BAGWEIGHT], [TOTAL_FREIGHTWEIGHT], [TOTAL_MAILWEIGHT], 
                                [TOTAL_LOADWEIGHT], [ADULT_PAXCOUNT], [BUSSINESS_PAXCOUNT], [CHILD_PAXCOUNT], [DOMESITEC_PAXCOUNT], [INFANT_PAXCOUNT], [INTERNATIONAL_PAXCOUNT], 
                                [LOCAL_PAXCOUNT], [NONTRANSFER_PAXCOUNT], [TOTAL_PAXCOUNT], [TRANSFER_PAXCOUNT], [TRANSIT_PAXCOUNT], [WHELLCHAIR_PAXCOUNT], [TOTAL_CREWCOUNT], 
                                [ECONOMY_PAXCOUNT], [FIRSTCLASS_PAXCOUNT], [TRANSFER_BAGCOUNT], [TRANSFER_BAGWEIGHT], [TRANSFER_FREIGHTWEIGHT], [TRANSFER_MAILWEIGHT], 
                                [TRANSIT_BAGCOUNT], [TRANSIT_BAGWEIGHT], [TRANSIT_FREIGHTWEIGHT], [TRANSIT_MAILWEIGHT], [OFFBLOCK_TIME], [ONBLOCK_TIME], [EDTA], [EDTD], [E_FL_DURATION], 
                                [FIRSTBAG_TIME], [LASTBAG_TIME], [FINALAPPROACH_TIME], [LASTKNOWN_TIME], [LASTKNOWN_SOURCE], [NEXT_INFO_TIME], [A_NEXT_STATION_TIME], 
                                [E_NEXT_STATION_TIME], [S_NEXT_STATION_TIME], [A_PREV_STATION_TIME], [E_PREV_STATION_TIME], [S_PREV_STATION_TIME], [LAND], [AIRB], [TEN_MILES_TIME], 
                                [ORG3], [DES3], [ORG_ICAO], [DES_ICAO], [VIA1], [VIA_ICAO], [PUBLIC_FLT], [PUBLIC_FLC], [PUBLIC_TIME], [SECURE_STAND_IS_REQUIRED], [STOD], [STPO], 
                                [OPERATIONTYPE_CODE2], [FIRSTBAG_TIME2], [LASTBAG_TIME2], [OPERATIONTYPE_ROLE1], [OPERATIONTYPE_ROLE2], [UPDATE_TIME], [CUSTOM_STATUS], 
                                [SUB_AIRLINE], [LTD], [LTA], [AIRLINE_TERMINAL], [GATE_PLAN_CLOSE_TIME1], [GATE_PLAN_OPEN_TIME1], [GATE_PLAN_CLOSE_TIME2], [GATE_PLAN_OPEN_TIME2], 
                                [USEC], [TYPC], [CDAT], [USEU], [TYPU], [LSTU], [JFNO], [CTRL], [DRCT]
                              FROM [AOCFQS]
                              Order By CDAT DESC, LSTU DESC";

            DataSet ds = SqlHelper.ExecuteDataset(ConnectStringMsSql.GetConnection(), CommandType.Text, sql);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }
    }
}
