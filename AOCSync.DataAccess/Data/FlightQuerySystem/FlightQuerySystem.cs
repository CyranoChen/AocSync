using System;
using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;

namespace AOCSync.DataAccess
{
    public class FlightQuerySystem
    {
        //TODO:COMPLETE ALL SQLS
        public static DataRow GetFlightQuerySystemDataByID(string fqsID)
        {
            string sql = @"select 
                        'D' as DRCT,
                        FD_ID as URNO,--.FD_ID
                        CARRIER_IATA, 
                        CARRIER_ICAO, 
                        FL_NUMBER, 
                        FL_SUFFIX, 
                        FLT,
                        FLR, 
                        to_char(SDT,'yyyymmddhh24miss') as SDT,
                        NULL as SDP,--T_FQS_AF_FL_ARRIVALS
                        LINKEDFL_FLT, 
                        LINKEDFL_CARRIER, 
                        LINKEDFL_NUMBER, 
                        LINKEDFL_SUFFIX, 
                        LINKEDFL_SDT, 
                        LINKEDFL_FLR,
                        LINKFL_ID,
                        MASTERFL_CARRIER,
                        MASTERFL_NUMBER,
                        MASTERFL_SUFFIX, 
                        MASTERFL_FLT as MFDI, 
                        MASTERFL_FLR, 
                        NULL as MASTERFL_ID, --T_FQS_AF_FL_ARRIVALS
                        AIRCRAFT_CALLSIGN, 
                        AIRCRAFT_OWNER, 
                        AIRCRAFT_PAXCAP, 
                        AIRCRAFT_REGISTRATION as REGN, 
                        AIRCRAFT_SUBTYPE as ATC5,
                        AIRCRAFT_TYPE, 
                        AIRCRAFT_OPERATOR, 
                        AIRCRAFT_TERMINAL, 
                        AIRPORT_IATA, 
                        NULL as BRC1,--T_FQS_AF_FL_ARRIVALS.RECLAIM_ID1
                        NULL as RECLAIM_ROLE1, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE1
                        NULL as BROD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME1
                        NULL as BRCD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME1
                        NULL as EXITDOOR1, --T_FQS_AF_FL_ARRIVALS.EXITDOOR1
                        NULL as SRC2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ID2
                        NULL as RECLAIM_ROLE2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE2
                        NULL as SBRO, --T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME2
                        NULL as SBRC, --T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME2
                        NULL as EXITDOOR2, --T_FQS_AF_FL_ARRIVALS.EXITDOOR2
                        MAKEUP_ID1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID1
                        MAKEUP_ROLE1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE1
                        to_char(MAKEUP_OPEN_TIME1,'yyyymmddhh24miss') as MAKEUP_OPEN_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME1
                        to_char(MAKEUP_CLOSE_TIME1,'yyyymmddhh24miss') as MAKEUP_CLOSE_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME1
                        MAKEUP_ID2,  --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID2
                        MAKEUP_ROLE2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE2
                        to_char(MAKEUP_OPEN_TIME2,'yyyymmddhh24miss') as MAKEUP_OPEN_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME2
                        to_char(MAKEUP_CLOSE_TIME2,'yyyymmddhh24miss') as MAKEUP_CLOSE_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME2
                        ISBUSREQUIRED, 
                        CC_TYPE1, 
                        CC_RANGE1 as CKIF,--.CC_RANGE1
                        CC_ROLE1, 
                        CC_CLUSTERID1, 
                        to_char(CC_OPEN_TIME1,'yyyymmddhh24miss') as CODT,--.CC_OPEN_TIME1
                        to_char(CC_CLOSE_TIME1,'yyyymmddhh24miss') as CCDT ,--.CC_CLOSE_TIME1
                        CC_TYPE2, 
                        CC_RANGE2 as SCDR,--.CC_RANGE2
                        CC_ROLE2, 
                        CC_CLUSTERID2, 
                        to_char(CC_OPEN_TIME2,'yyyymmddhh24miss') as CC_OPEN_TIME2 as SCODT,--.CC_OPEN_TIME2
                        to_char(CC_CLOSE_TIME2,'yyyymmddhh24miss') as CC_CLOSE_TIME2 as SCCDT,--.CC_CLOSE_TIME2
                        to_char(GATE_CLOSE_TIME2,'yyyymmddhh24miss') as SGCD,--.GATE_CLOSE_TIME2
                        to_char(GATE_OPEN_TIME2,'yyyymmddhh24miss') as SGOD,--.GATE_OPEN_TIME2
                        GATE_BORDING_STATUS2, 
                        GATE_ROLE2,
                        GATE_NUMBER2 as GN,--.GATE_NUMBER2
                        to_char(GATE_CLOSE_TIME1,'yyyymmddhh24miss') as GCDT,--.GATE_CLOSE_TIME1
                        to_char(GATE_OPEN_TIME1,'yyyymmddhh24miss') as GODT,--.GATE_OPEN_TIME1
                        GATE_BORDING_STATUS1 as GBS,--.GATE_BORDING_STATUS1
                        GATE_ROLE1, 
                        GATE_NUMBER1 as GENO ,--.GATE_NUMBER1
                        PASSENGER_TERMINAL as TERM, 
                        REMARK_CODE1, 
                        REMARK_TYPE1, 
                        REMARK_CODE2, 
                        REMARK_TYPE2, 
                        REMARK_CODE3, 
                        REMARK_TYPE3, 
                        REMARK_CODE4 , 
                        REMARK_TYPE4, 
                        RUNWAY_ID , 
                        S_INFO_TYPE1, 
                        S_INFO_TEXT1, 
                        S_INFO_TYPE2, 
                        S_INFO_TEXT2, 
                        S_INFO_TYPE3, 
                        S_INFO_TEXT3, 
                        S_INFO_TYPE4, 
                        S_INFO_TEXT4, 
                        S_INFO_TYPE5, 
                        S_INFO_TEXT5, 
                        ACCOUNT_CODE, 
                        CODESHARE_STATUS as CSS, 
                        DEVERT_AIRPORT as DAIA, 
                        FL_CANCELCODE,--.FL_CANCELCODE
                        FL_CLASSIFICATIONCODE,--.FL_CLASSIFICATIONCODE
                        FL_NATURECODE as TTYP, 
                        FL_OPERATES_OVERNIGHT, 
                        FL_SECTORCODE as FLTI,--.FL_SECTORCODE
                        FL_SERVICETYPE, 
                        FL_STATUSCODE,--.FL_STATUSCODE 
                        FL_TRANSITCODE, 
                        HANDLINGAGENT1, 
                        HANDLING_SERVICE1, 
                        HANDLINGAGENT2, 
                        HANDLING_SERVICE2, 
                        HANDLINGAGENT3, 
                        HANDLING_SERVICE3, 
                        HANDLINGAGENT4, 
                        HANDLING_SERVICE4, 
                        HANDLINGAGENT5, 
                        HANDLING_SERVICE5, 
                        IRR_NUMBER1, 
                        IRR_CODE1, 
                        IRR_DURATION1, 
                        IRR_NUMBER2, 
                        IRR_CODE2, 
                        IRR_DURATION2, 
                        ISGVF, 
                        ISRETURNFL, 
                        ISTRANSFERFL, 
                        NEWFL_REASON, 
                        OPERATIONTYPE_CODE1, 
                        TRANSFER_FL1, 
                        TRANSFER_FL2, 
                        TRANSFER_FL3, 
                        TRANSFER_FL4, 
                        TRANSFER_FL5, 
                        TRANSFER_FL6, 
                        TRANSFER_FL7, 
                        TRANSFER_FL8, 
                        TRANSFER_FL9, 
                        TRANSFER_FL10, 
                        TRANSFER_FL11, 
                        TRANSFER_FL12, 
                        TRANSFER_FL13, 
                        TRANSFER_FL14, 
                        TRANSFER_FL15, 
                        TRANSFER_FL16, 
                        TRANSFER_FL17, 
                        TRANSFER_FL18, 
                        TRANSFER_FL19, 
                        TRANSFER_FL20, 
                        SHAREFL_FLT1 , 
                        SHAREFL_FLN1 , 
                        SHAREFL_FLT2 , 
                        SHAREFL_FLN2 , 
                        SHAREFL_FLT3 , 
                        SHAREFL_FLN3 , 
                        SHAREFL_FLT4 , 
                        SHAREFL_FLN4 , 
                        SHAREFL_FLT5 , 
                        SHAREFL_FLN5 , 
                        SHAREFL_FLT6 , 
                        SHAREFL_FLN6 , 
                        TOTAL_BAGCOUNT, 
                        TOTAL_BAGWEIGHT , 
                        TOTAL_FREIGHTWEIGHT, 
                        TOTAL_MAILWEIGHT, 
                        TOTAL_LOADWEIGHT, 
                        ADULT_PAXCOUNT, 
                        BUSSINESS_PAXCOUNT, 
                        CHILD_PAXCOUNT, 
                        DOMESITEC_PAXCOUNT, 
                        INFANT_PAXCOUNT, 
                        INTERNATIONAL_PAXCOUNT, 
                        LOCAL_PAXCOUNT, 
                        NONTRANSFER_PAXCOUNT, 
                        TOTAL_PAXCOUNT, 
                        TRANSFER_PAXCOUNT, 
                        TRANSIT_PAXCOUNT, 
                        WHELLCHAIR_PAXCOUNT, 
                        TOTAL_CREWCOUNT, 
                        ECONOMY_PAXCOUNT, 
                        FIRSTCLASS_PAXCOUNT, 
                        TRANSFER_BAGCOUNT, 
                        TRANSFER_BAGWEIGHT, 
                        TRANSFER_FREIGHTWEIGHT, 
                        TRANSFER_MAILWEIGHT, 
                        TRANSIT_BAGCOUNT, 
                        TRANSIT_BAGWEIGHT, 
                        TRANSIT_FREIGHTWEIGHT, 
                        TRANSIT_MAILWEIGHT, 
                        to_char(OFFBLOCK_TIME,'yyyymmddhh24miss') as OFFBLOCK_TIME , 
                        to_char(ONBLOCK_TIME,'yyyymmddhh24miss') as ONBLOCK_TIME, 
                        NULL as EDTA,--T_FQS_AF_FL_ARRIVALS.EDT
                        to_char(EDT,'yyyymmddhh24miss') as EDTD,--T_FQS_AF_FL_DEPARTURES.EDT
                        E_FL_DURATION, 
                        to_char(FIRSTBAG_TIME,'yyyymmddhh24miss') as FIRSTBAG_TIME, 
                        to_char(LASTBAG_TIME,'yyyymmddhh24miss') as LASTBAG_TIME, 
                        to_char(FINALAPPROACH_TIME,'yyyymmddhh24miss') as FINALAPPROACH_TIME, 
                        to_char(LASTKNOWN_TIME,'yyyymmddhh24miss') as LASTKNOWN_TIME, 
                        LASTKNOWN_SOURCE, 
                        to_char(NEXT_INFO_TIME,'yyyymmddhh24miss') as NEXT_INFO_TIME, 
                        to_char(A_NEXT_STATION_TIME, 'yyyymmddhh24miss') as  A_NEXT_STATION_TIME,
                        to_char(E_NEXT_STATION_TIME, 'yyyymmddhh24miss') as  E_NEXT_STATION_TIME,
                        to_char(S_NEXT_STATION_TIME, 'yyyymmddhh24miss') as  S_NEXT_STATION_TIME,
                        to_char(A_PREV_STATION_TIME, 'yyyymmddhh24miss') as  A_PREV_STATION_TIME,
                        to_char(E_PREV_STATION_TIME, 'yyyymmddhh24miss') as  E_PREV_STATION_TIME,
                        to_char(S_PREV_STATION_TIME, 'yyyymmddhh24miss') as  S_PREV_STATION_TIME,
                        to_char(WHEELDOWN_TIME, 'yyyymmddhh24miss') as LAND,--.WHEELDOWN_TIME
                        to_char(WHEELUP_TIME, 'yyyymmddhh24miss') as AIRB,--.WHEELUP_TIME
                        to_char(TEN_MILES_TIME, 'yyyymmddhh24miss') as TEN_MILES_TIME, 
                        NULL as ORG3,
                        DES_IATA as DES3,
                        ORG_ICAO,
                        DES_ICAO, 
                        VIA_IATA1,--VIA1
                        VIA_IATA2,--VIA1
                        VIA_IATA3,--VIA1
                        VIA_IATA4,--VIA1
                        VIA_IATA5,--VIA1
                        VIA_IATA6,--VIA1
                        VIA_ICAO1,--VIA_ICAO
                        VIA_ICAO2,--VIA_ICAO
                        VIA_ICAO3,--VIA_ICAO
                        VIA_ICAO4,--VIA_ICAO
                        VIA_ICAO5,--VIA_ICAO
                        VIA_ICAO6,--VIA_ICAO
                        PUBLIC_FLT, 
                        PUBLIC_FLC, 
                        to_char(PUBLIC_TIME, 'yyyymmddhh24miss') as PUBLIC_TIME, 
                        SECURE_STAND_IS_REQUIRED, 
                        STAND_POSITION as STPO,--.STAND_POSITION
                        to_char(SDT_TIME, 'yyyymmddhh24miss') as STOD, 
                        OPERATIONTYPE_CODE2, 
                        NULL as FIRSTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        NULL as LASTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        OPERATIONTYPE_ROLE1, 
                        OPERATIONTYPE_ROLE2, 
                        to_char(UPDATE_TIME, 'yyyymmddhh24miss') as UPDATE_TIME, 
                        CUSTOM_STATUS, 
                        SUB_AIRLINE, 
                        to_char(LTD, 'yyyymmddhh24miss') as LTD,--T_FQS_AF_FL_DEPARTURES
                        NULL as LTA,--T_FQS_AF_FL_ARRIVALS
                        AIRLINE_TERMINAL, 
                        to_char(GATE_PLAN_CLOSE_TIME1,  'yyyymmddhh24miss') as       GATE_PLAN_CLOSE_TIME1,
                        to_char(GATE_PLAN_OPEN_TIME1,   'yyyymmddhh24miss') as       GATE_PLAN_OPEN_TIME1, 
                        to_char(GATE_PLAN_CLOSE_TIME2,  'yyyymmddhh24miss') as       GATE_PLAN_CLOSE_TIME2,
                        to_char(GATE_PLAN_OPEN_TIME2,    'yyyymmddhh24miss') as       GATE_PLAN_OPEN_TIME2 
                        from T_FQS_AF_FL_DEPARTURES 
                        WHERE FD_ID = :varfqsID

                        union

                        select 
                        'A' as DRCT,
                        FA_ID as URNO,--.FD_ID
                        CARRIER_IATA, 
                        CARRIER_ICAO, 
                        FL_NUMBER , 
                        FL_SUFFIX , 
                        FLT,
                        FLR, 
                        to_char(SDT,'yyyymmddhh24miss') as SDT,
                        SDP,--T_FQS_AF_FL_ARRIVALS
                        LINKEDFL_FLT, 
                        LINKEDFL_CARRIER, 
                        LINKEDFL_NUMBER, 
                        LINKEDFL_SUFFIX, 
                        LINKEDFL_SDT, 
                        LINKEDFL_FLR,
                        LINKFL_ID,
                        MASTERFL_CARRIER,
                        MASTERFL_NUMBER,
                        MASTERFL_SUFFIX, 
                        MASTERFL_FLT as MFDI, 
                        MASTERFL_FLR, 
                        MASTERFL_ID, --T_FQS_AF_FL_ARRIVALS
                        AIRCRAFT_CALLSIGN, 
                        AIRCRAFT_OWNER, 
                        AIRCRAFT_PAXCAP, 
                        AIRCRAFT_REGISTRATION as REGN, 
                        AIRCRAFT_SUBTYPE as ATC5,
                        AIRCRAFT_TYPE, 
                        AIRCRAFT_OPERATOR, 
                        AIRCRAFT_TERMINAL, 
                        AIRPORT_IATA, 
                        RECLAIM_ID1 as BRC1,--T_FQS_AF_FL_ARRIVALS.RECLAIM_ID1
                        RECLAIM_ROLE1 as RECLAIM_ROLE1, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE1
                        to_char(RECLAIM_OPEN_TIME1, 'yyyymmddhh24miss') as BROD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME1
                        to_char(RECLAIM_CLOSE_TIME1, 'yyyymmddhh24miss') as BRCD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME1
                        EXITDOOR1, --T_FQS_AF_FL_ARRIVALS.EXITDOOR1
                        RECLAIM_ID2 as SRC2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ID2
                        RECLAIM_ROLE2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE2
                        to_char(RECLAIM_OPEN_TIME2, 'yyyymmddhh24miss') as SBRO, --T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME2
                        to_char(RECLAIM_CLOSE_TIME2, 'yyyymmddhh24miss') as SBRC, --T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME2
                        EXITDOOR2, --T_FQS_AF_FL_ARRIVALS.EXITDOOR2
                        NULL as MAKEUP_ID1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID1
                        NULL as MAKEUP_ROLE1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE1
                        NULL as MAKEUP_OPEN_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME1
                        NULL as MAKEUP_CLOSE_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME1
                        NULL as MAKEUP_ID2,  --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID2
                        NULL as MAKEUP_ROLE2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE2
                        NULL as MAKEUP_OPEN_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME2
                        NULL as MAKEUP_CLOSE_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME2
                        ISBUSREQUIRED, 
                        CC_TYPE1, 
                        CC_RANGE1 as CKIF,--.CC_RANGE1
                        CC_ROLE1, 
                        CC_CLUSTERID1, 
                        to_char(CC_OPEN_TIME1, 'yyyymmddhh24miss') as CODT,--.CC_OPEN_TIME1
                        to_char(CC_CLOSE_TIME1, 'yyyymmddhh24miss') as CCDT ,--.CC_CLOSE_TIME1
                        CC_TYPE2, 
                        CC_RANGE2 as SCDR,--.CC_RANGE2
                        CC_ROLE2, 
                        CC_CLUSTERID2, 
                        to_char(CC_OPEN_TIME2, 'yyyymmddhh24miss') as SCODT,--.CC_OPEN_TIME2
                        to_char(CC_CLOSE_TIME2, 'yyyymmddhh24miss') as SCCDT,--.CC_CLOSE_TIME2
                        to_char(GATE_CLOSE_TIME2, 'yyyymmddhh24miss')  as SGCD,--.GATE_CLOSE_TIME2
                        to_char(GATE_OPEN_TIME2, 'yyyymmddhh24miss')  as SGOD,--.GATE_OPEN_TIME2
                        GATE_BORDING_STATUS2, 
                        GATE_ROLE2,
                        GATE_NUMBER2 as SGN,--.GATE_NUMBER2
                        to_char(GATE_CLOSE_TIME1, 'yyyymmddhh24miss')  as GCDT,--.GATE_CLOSE_TIME1
                        to_char(GATE_OPEN_TIME1, 'yyyymmddhh24miss')  as GODT,--.GATE_OPEN_TIME1
                        GATE_BORDING_STATUS1 as GBS,--.GATE_BORDING_STATUS1
                        GATE_ROLE1, 
                        GATE_NUMBER1 as GENO ,--.GATE_NUMBER1
                        PASSENGER_TERMINAL as TERM, 
                        REMARK_CODE1, 
                        REMARK_TYPE1, 
                        REMARK_CODE2, 
                        REMARK_TYPE2, 
                        REMARK_CODE3, 
                        REMARK_TYPE3, 
                        REMARK_CODE4 , 
                        REMARK_TYPE4, 
                        RUNWAY_ID , 
                        S_INFO_TYPE1, 
                        S_INFO_TEXT1, 
                        S_INFO_TYPE2, 
                        S_INFO_TEXT2, 
                        S_INFO_TYPE3, 
                        S_INFO_TEXT3, 
                        S_INFO_TYPE4, 
                        S_INFO_TEXT4, 
                        S_INFO_TYPE5, 
                        S_INFO_TEXT5, 
                        ACCOUNT_CODE, 
                        CODESHARE_STATUS as CSS, 
                        DEVERT_AIRPORT as DAIA, 
                        FL_CANCELCODE,--.FL_CANCELCODE
                        FL_CLASSIFICATIONCODE,--.FL_CLASSIFICATIONCODE
                        FL_NATURECODE as TTYP, 
                        FL_OPERATES_OVERNIGHT, 
                        FL_SECTORCODE as FLTI,--.FL_SECTORCODE
                        FL_SERVICETYPE, 
                        FL_STATUSCODE,--.FL_STATUSCODE 
                        FL_TRANSITCODE, 
                        HANDLINGAGENT1, 
                        HANDLING_SERVICE1, 
                        HANDLINGAGENT2, 
                        HANDLING_SERVICE2, 
                        HANDLINGAGENT3, 
                        HANDLING_SERVICE3, 
                        HANDLINGAGENT4, 
                        HANDLING_SERVICE4, 
                        HANDLINGAGENT5, 
                        HANDLING_SERVICE5, 
                        IRR_NUMBER1, 
                        IRR_CODE1, 
                        IRR_DURATION1, 
                        IRR_NUMBER2, 
                        IRR_CODE2, 
                        IRR_DURATION2, 
                        ISGVF, 
                        ISRETURNFL, 
                        ISTRANSFERFL, 
                        NEWFL_REASON, 
                        OPERATIONTYPE_CODE1, 
                        TRANSFER_FL1, 
                        TRANSFER_FL2, 
                        TRANSFER_FL3, 
                        TRANSFER_FL4, 
                        TRANSFER_FL5, 
                        TRANSFER_FL6, 
                        TRANSFER_FL7, 
                        TRANSFER_FL8, 
                        TRANSFER_FL9, 
                        TRANSFER_FL10, 
                        TRANSFER_FL11, 
                        TRANSFER_FL12, 
                        TRANSFER_FL13, 
                        TRANSFER_FL14, 
                        TRANSFER_FL15, 
                        TRANSFER_FL16, 
                        TRANSFER_FL17, 
                        TRANSFER_FL18, 
                        TRANSFER_FL19, 
                        TRANSFER_FL20, 
                        SHAREFL_FLT1 , 
                        SHAREFL_FLN1 , 
                        SHAREFL_FLT2 , 
                        SHAREFL_FLN2 , 
                        SHAREFL_FLT3 , 
                        SHAREFL_FLN3 , 
                        SHAREFL_FLT4 , 
                        SHAREFL_FLN4 , 
                        SHAREFL_FLT5 , 
                        SHAREFL_FLN5 , 
                        SHAREFL_FLT6 , 
                        SHAREFL_FLN6 , 
                        TOTAL_BAGCOUNT, 
                        TOTAL_BAGWEIGHT , 
                        TOTAL_FREIGHTWEIGHT, 
                        TOTAL_MAILWEIGHT, 
                        TOTAL_LOADWEIGHT, 
                        ADULT_PAXCOUNT, 
                        BUSSINESS_PAXCOUNT, 
                        CHILD_PAXCOUNT, 
                        DOMESITEC_PAXCOUNT, 
                        INFANT_PAXCOUNT, 
                        INTERNATIONAL_PAXCOUNT, 
                        LOCAL_PAXCOUNT, 
                        NONTRANSFER_PAXCOUNT, 
                        TOTAL_PAXCOUNT, 
                        TRANSFER_PAXCOUNT, 
                        TRANSIT_PAXCOUNT, 
                        WHELLCHAIR_PAXCOUNT, 
                        TOTAL_CREWCOUNT, 
                        ECONOMY_PAXCOUNT, 
                        FIRSTCLASS_PAXCOUNT, 
                        TRANSFER_BAGCOUNT, 
                        TRANSFER_BAGWEIGHT, 
                        TRANSFER_FREIGHTWEIGHT, 
                        TRANSFER_MAILWEIGHT, 
                        TRANSIT_BAGCOUNT, 
                        TRANSIT_BAGWEIGHT, 
                        TRANSIT_FREIGHTWEIGHT, 
                        TRANSIT_MAILWEIGHT, 
                        to_char(OFFBLOCK_TIME, 'yyyymmddhh24miss') as OFFBLOCK_TIME , 
                        to_char(ONBLOCK_TIME, 'yyyymmddhh24miss') as ONBLOCK_TIME, 
                        to_char(EDT,'yyyymmddhh24miss') as EDTA,--T_FQS_AF_FL_ARRIVALS.EDT
                        NULL as EDTD,--T_FQS_AF_FL_DEPARTURES.EDT
                        E_FL_DURATION, 
                        to_char(FIRSTBAG_TIME1, 'yyyymmddhh24miss') as FIRSTBAG_TIME, 
                        to_char(LASTBAG_TIME1, 'yyyymmddhh24miss') as  LASTBAG_TIME, 
                        to_char(FINALAPPROACH_TIME, 'yyyymmddhh24miss') as FINALAPPROACH_TIME, 
                        to_char(LASTKNOWN_TIME, 'yyyymmddhh24miss') as LASTKNOWN_TIME, 
                        LASTKNOWN_SOURCE, 
                        to_char(NEXT_INFO_TIME,        'yyyymmddhh24miss') as            NEXT_INFO_TIME, 
                        to_char(A_NEXT_STATION_TIME,   'yyyymmddhh24miss') as            A_NEXT_STATION_TIME, 
                        to_char(E_NEXT_STATION_TIME,   'yyyymmddhh24miss') as            E_NEXT_STATION_TIME, 
                        to_char(S_NEXT_STATION_TIME,   'yyyymmddhh24miss') as            S_NEXT_STATION_TIME, 
                        to_char(A_PREV_STATION_TIME,   'yyyymmddhh24miss') as            A_PREV_STATION_TIME, 
                        to_char(E_PREV_STATION_TIME,   'yyyymmddhh24miss') as            E_PREV_STATION_TIME, 
                        to_char(S_PREV_STATION_TIME,   'yyyymmddhh24miss') as            S_PREV_STATION_TIME, 
                        to_char(WHEELDOWN_TIME,   'yyyymmddhh24miss') as LAND,--.WHEELDOWN_TIME
                        to_char(WHEELUP_TIME,   'yyyymmddhh24miss') as AIRB,--.WHEELUP_TIME
                        to_char(TEN_MILES_TIME,   'yyyymmddhh24miss') as TEN_MILES_TIME, 
                        ORG_IATA as ORG3,
                        NULL as DES3,
                        ORG_ICAO,
                        DES_ICAO, 
                        VIA_IATA1,--VIA1
                        VIA_IATA2,--VIA1
                        VIA_IATA3,--VIA1
                        VIA_IATA4,--VIA1
                        VIA_IATA5,--VIA1
                        VIA_IATA6,--VIA1
                        VIA_ICAO1,--VIA_ICAO
                        VIA_ICAO2,--VIA_ICAO
                        VIA_ICAO3,--VIA_ICAO
                        VIA_ICAO4,--VIA_ICAO
                        VIA_ICAO5,--VIA_ICAO
                        VIA_ICAO6,--VIA_ICAO
                        PUBLIC_FLT, 
                        PUBLIC_FLC, 
                        to_char(PUBLIC_TIME,   'yyyymmddhh24miss') as PUBLIC_TIME, 
                        SECURE_STAND_IS_REQUIRED, 
                        STAND_POSITION as STPO,--.STAND_POSITION
                        to_char(SDT_TIME,   'yyyymmddhh24miss') as STOD, 
                        OPERATIONTYPE_CODE2, 
                        to_char(FIRSTBAG_TIME2,   'yyyymmddhh24miss') as FIRSTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        to_char(LASTBAG_TIME2,   'yyyymmddhh24miss') as LASTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        OPERATIONTYPE_ROLE1, 
                        OPERATIONTYPE_ROLE2, 
                        to_char(UPDATE_TIME,   'yyyymmddhh24miss') as UPDATE_TIME, 
                        CUSTOM_STATUS, 
                        SUB_AIRLINE, 
                        NULL as LTD,--T_FQS_AF_FL_DEPARTURES
                        to_char(LTA,   'yyyymmddhh24miss') as LTA,--T_FQS_AF_FL_ARRIVALS
                        AIRLINE_TERMINAL, 
                        to_char(GATE_PLAN_CLOSE_TIME1, 'yyyymmddhh24miss') as GATE_PLAN_CLOSE_TIME1, 
                        to_char(GATE_PLAN_OPEN_TIME1,  'yyyymmddhh24miss') as GATE_PLAN_OPEN_TIME1, 
                        to_char(GATE_PLAN_CLOSE_TIME2, 'yyyymmddhh24miss') as GATE_PLAN_CLOSE_TIME2, 
                        to_char(GATE_PLAN_OPEN_TIME2,   'yyyymmddhh24miss') as GATE_PLAN_OPEN_TIME2 
                        from T_FQS_AF_FL_ARRIVALS                        
                        WHERE FA_ID = :varfqsID
                        ";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("varfqsID", fqsID);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.getStrConnectionFlightQuerySystem(), sql, para);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static DataTable GetFlightQuerySystemDatas()
        {
            string sql = @"select 
                        'D' as DRCT,
                        FD_ID as URNO,--.FD_ID
                        CARRIER_IATA, 
                        CARRIER_ICAO, 
                        FL_NUMBER , 
                        FL_SUFFIX , 
                        FLT,
                        FLR, 
                        to_char(SDT,'yyyymmddhh24miss') as SDT,
                        NULL as SDP,--T_FQS_AF_FL_ARRIVALS
                        LINKEDFL_FLT, 
                        LINKEDFL_CARRIER, 
                        LINKEDFL_NUMBER, 
                        LINKEDFL_SUFFIX, 
                        LINKEDFL_SDT, 
                        LINKEDFL_FLR,
                        LINKFL_ID,
                        MASTERFL_CARRIER,
                        MASTERFL_NUMBER,
                        MASTERFL_SUFFIX, 
                        MASTERFL_FLT as MFDI, 
                        MASTERFL_FLR, 
                        NULL as MASTERFL_ID, --T_FQS_AF_FL_ARRIVALS
                        AIRCRAFT_CALLSIGN, 
                        AIRCRAFT_OWNER, 
                        AIRCRAFT_PAXCAP, 
                        AIRCRAFT_REGISTRATION as REGN, 
                        AIRCRAFT_SUBTYPE as ATC5,
                        AIRCRAFT_TYPE, 
                        AIRCRAFT_OPERATOR, 
                        AIRCRAFT_TERMINAL, 
                        AIRPORT_IATA, 
                        NULL as BRC1,--T_FQS_AF_FL_ARRIVALS.RECLAIM_ID1
                        NULL as RECLAIM_ROLE1, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE1
                        NULL as BROD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME1
                        NULL as BRCD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME1
                        NULL as EXITDOOR1, --T_FQS_AF_FL_ARRIVALS.EXITDOOR1
                        NULL as SRC2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ID2
                        NULL as RECLAIM_ROLE2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE2
                        NULL as SBRO, --T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME2
                        NULL as SBRC, --T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME2
                        NULL as EXITDOOR2, --T_FQS_AF_FL_ARRIVALS.EXITDOOR2
                        MAKEUP_ID1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID1
                        MAKEUP_ROLE1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE1
                        to_char(MAKEUP_OPEN_TIME1, 'yyyymmddhh24miss') as MAKEUP_OPEN_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME1
                        to_char(MAKEUP_CLOSE_TIME1, 'yyyymmddhh24miss') as MAKEUP_CLOSE_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME1
                        MAKEUP_ID2,  --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID2
                        MAKEUP_ROLE2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE2
                        to_char(MAKEUP_OPEN_TIME2, 'yyyymmddhh24miss') as MAKEUP_OPEN_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME2
                        to_char(MAKEUP_CLOSE_TIME2, 'yyyymmddhh24miss') as MAKEUP_CLOSE_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME2
                        ISBUSREQUIRED, 
                        CC_TYPE1, 
                        CC_RANGE1 as CKIF,--.CC_RANGE1
                        CC_ROLE1, 
                        CC_CLUSTERID1, 
                        to_char(CC_OPEN_TIME1, 'yyyymmddhh24miss') as CODT,--.CC_OPEN_TIME1
                        to_char(CC_CLOSE_TIME1, 'yyyymmddhh24miss') as CCDT ,--.CC_CLOSE_TIME1
                        CC_TYPE2, 
                        CC_RANGE2 as SCDR,--.CC_RANGE2
                        CC_ROLE2, 
                        CC_CLUSTERID2, 
                        to_char(CC_OPEN_TIME2, 'yyyymmddhh24miss') as SCODT,--.CC_OPEN_TIME2
                        to_char(CC_CLOSE_TIME2, 'yyyymmddhh24miss') as SCCDT,--.CC_CLOSE_TIME2
                        to_char(GATE_CLOSE_TIME2, 'yyyymmddhh24miss') as SGCD,--.GATE_CLOSE_TIME2
                        to_char(GATE_OPEN_TIME2, 'yyyymmddhh24miss') as SGOD,--.GATE_OPEN_TIME2
                        GATE_BORDING_STATUS2, 
                        GATE_ROLE2,
                        GATE_NUMBER2 as SGN,--.GATE_NUMBER2
                        to_char(GATE_CLOSE_TIME1, 'yyyymmddhh24miss') as GCDT,--.GATE_CLOSE_TIME1
                        to_char(GATE_OPEN_TIME1, 'yyyymmddhh24miss') as GODT,--.GATE_OPEN_TIME1
                        GATE_BORDING_STATUS1 as GBS,--.GATE_BORDING_STATUS1
                        GATE_ROLE1, 
                        GATE_NUMBER1 as GENO ,--.GATE_NUMBER1
                        PASSENGER_TERMINAL as TERM, 
                        REMARK_CODE1, 
                        REMARK_TYPE1, 
                        REMARK_CODE2, 
                        REMARK_TYPE2, 
                        REMARK_CODE3, 
                        REMARK_TYPE3, 
                        REMARK_CODE4 , 
                        REMARK_TYPE4, 
                        RUNWAY_ID , 
                        S_INFO_TYPE1, 
                        S_INFO_TEXT1, 
                        S_INFO_TYPE2, 
                        S_INFO_TEXT2, 
                        S_INFO_TYPE3, 
                        S_INFO_TEXT3, 
                        S_INFO_TYPE4, 
                        S_INFO_TEXT4, 
                        S_INFO_TYPE5, 
                        S_INFO_TEXT5, 
                        ACCOUNT_CODE, 
                        CODESHARE_STATUS as CSS, 
                        DEVERT_AIRPORT as DAIA, 
                        FL_CANCELCODE,--.FL_CANCELCODE
                        FL_CLASSIFICATIONCODE,--.FL_CLASSIFICATIONCODE
                        FL_NATURECODE as TTYP, 
                        FL_OPERATES_OVERNIGHT, 
                        FL_SECTORCODE as FLTI,--.FL_SECTORCODE
                        FL_SERVICETYPE, 
                        FL_STATUSCODE,--.FL_STATUSCODE 
                        FL_TRANSITCODE, 
                        HANDLINGAGENT1, 
                        HANDLING_SERVICE1, 
                        HANDLINGAGENT2, 
                        HANDLING_SERVICE2, 
                        HANDLINGAGENT3, 
                        HANDLING_SERVICE3, 
                        HANDLINGAGENT4, 
                        HANDLING_SERVICE4, 
                        HANDLINGAGENT5, 
                        HANDLING_SERVICE5, 
                        IRR_NUMBER1, 
                        IRR_CODE1, 
                        IRR_DURATION1, 
                        IRR_NUMBER2, 
                        IRR_CODE2, 
                        IRR_DURATION2, 
                        ISGVF, 
                        ISRETURNFL, 
                        ISTRANSFERFL, 
                        NEWFL_REASON, 
                        OPERATIONTYPE_CODE1, 
                        TRANSFER_FL1, 
                        TRANSFER_FL2, 
                        TRANSFER_FL3, 
                        TRANSFER_FL4, 
                        TRANSFER_FL5, 
                        TRANSFER_FL6, 
                        TRANSFER_FL7, 
                        TRANSFER_FL8, 
                        TRANSFER_FL9, 
                        TRANSFER_FL10, 
                        TRANSFER_FL11, 
                        TRANSFER_FL12, 
                        TRANSFER_FL13, 
                        TRANSFER_FL14, 
                        TRANSFER_FL15, 
                        TRANSFER_FL16, 
                        TRANSFER_FL17, 
                        TRANSFER_FL18, 
                        TRANSFER_FL19, 
                        TRANSFER_FL20, 
                        SHAREFL_FLT1 , 
                        SHAREFL_FLN1 , 
                        SHAREFL_FLT2 , 
                        SHAREFL_FLN2 , 
                        SHAREFL_FLT3 , 
                        SHAREFL_FLN3 , 
                        SHAREFL_FLT4 , 
                        SHAREFL_FLN4 , 
                        SHAREFL_FLT5 , 
                        SHAREFL_FLN5 , 
                        SHAREFL_FLT6 , 
                        SHAREFL_FLN6 , 
                        TOTAL_BAGCOUNT, 
                        TOTAL_BAGWEIGHT , 
                        TOTAL_FREIGHTWEIGHT, 
                        TOTAL_MAILWEIGHT, 
                        TOTAL_LOADWEIGHT, 
                        ADULT_PAXCOUNT, 
                        BUSSINESS_PAXCOUNT, 
                        CHILD_PAXCOUNT, 
                        DOMESITEC_PAXCOUNT, 
                        INFANT_PAXCOUNT, 
                        INTERNATIONAL_PAXCOUNT, 
                        LOCAL_PAXCOUNT, 
                        NONTRANSFER_PAXCOUNT, 
                        TOTAL_PAXCOUNT, 
                        TRANSFER_PAXCOUNT, 
                        TRANSIT_PAXCOUNT, 
                        WHELLCHAIR_PAXCOUNT, 
                        TOTAL_CREWCOUNT, 
                        ECONOMY_PAXCOUNT, 
                        FIRSTCLASS_PAXCOUNT, 
                        TRANSFER_BAGCOUNT, 
                        TRANSFER_BAGWEIGHT, 
                        TRANSFER_FREIGHTWEIGHT, 
                        TRANSFER_MAILWEIGHT, 
                        TRANSIT_BAGCOUNT, 
                        TRANSIT_BAGWEIGHT, 
                        TRANSIT_FREIGHTWEIGHT, 
                        TRANSIT_MAILWEIGHT, 
                        to_char(OFFBLOCK_TIME, 'yyyymmddhh24miss') as OFFBLOCK_TIME , 
                        to_char(ONBLOCK_TIME, 'yyyymmddhh24miss') as ONBLOCK_TIME, 
                        NULL as EDTA,--T_FQS_AF_FL_ARRIVALS.EDT
                        to_char(EDT,'yyyymmddhh24miss') as EDTD,--T_FQS_AF_FL_DEPARTURES.EDT
                        E_FL_DURATION, 
                        to_char(FIRSTBAG_TIME, 'yyyymmddhh24miss') as FIRSTBAG_TIME, 
                        to_char(LASTBAG_TIME, 'yyyymmddhh24miss') as LASTBAG_TIME, 
                        to_char(FINALAPPROACH_TIME, 'yyyymmddhh24miss') as FINALAPPROACH_TIME, 
                        to_char(LASTKNOWN_TIME, 'yyyymmddhh24miss') as LASTKNOWN_TIME, 
                        LASTKNOWN_SOURCE, 
                        to_char(NEXT_INFO_TIME, 'yyyymmddhh24miss') as NEXT_INFO_TIME, 
                        to_char(A_NEXT_STATION_TIME, 'yyyymmddhh24miss') as A_NEXT_STATION_TIME, 
                        to_char(E_NEXT_STATION_TIME, 'yyyymmddhh24miss') as E_NEXT_STATION_TIME, 
                        to_char(S_NEXT_STATION_TIME, 'yyyymmddhh24miss') as S_NEXT_STATION_TIME, 
                        to_char(A_PREV_STATION_TIME, 'yyyymmddhh24miss') as A_PREV_STATION_TIME, 
                        to_char(E_PREV_STATION_TIME, 'yyyymmddhh24miss') as E_PREV_STATION_TIME, 
                        to_char(S_PREV_STATION_TIME, 'yyyymmddhh24miss') as S_PREV_STATION_TIME, 
                        to_char(WHEELDOWN_TIME, 'yyyymmddhh24miss') as LAND,--.WHEELDOWN_TIME
                        to_char(WHEELUP_TIME, 'yyyymmddhh24miss') as AIRB,--.WHEELUP_TIME
                        to_char(TEN_MILES_TIME, 'yyyymmddhh24miss') as TEN_MILES_TIME, 
                        NULL as ORG3,
                        DES_IATA as DES3,
                        ORG_ICAO,
                        DES_ICAO, 
                        VIA_IATA1,--VIA1
                        VIA_IATA2,--VIA1
                        VIA_IATA3,--VIA1
                        VIA_IATA4,--VIA1
                        VIA_IATA5,--VIA1
                        VIA_IATA6,--VIA1
                        VIA_ICAO1,--VIA_ICAO
                        VIA_ICAO2,--VIA_ICAO
                        VIA_ICAO3,--VIA_ICAO
                        VIA_ICAO4,--VIA_ICAO
                        VIA_ICAO5,--VIA_ICAO
                        VIA_ICAO6,--VIA_ICAO
                        PUBLIC_FLT, 
                        PUBLIC_FLC, 
                        to_char(PUBLIC_TIME, 'yyyymmddhh24miss') as PUBLIC_TIME, 
                        SECURE_STAND_IS_REQUIRED, 
                        STAND_POSITION as STPO,--.STAND_POSITION
                        to_char(SDT_TIME, 'yyyymmddhh24miss') as STOD, 
                        OPERATIONTYPE_CODE2, 
                        NULL as FIRSTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        NULL as LASTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        OPERATIONTYPE_ROLE1, 
                        OPERATIONTYPE_ROLE2, 
                        to_char(UPDATE_TIME, 'yyyymmddhh24miss') as UPDATE_TIME, 
                        CUSTOM_STATUS, 
                        SUB_AIRLINE, 
                        to_char(LTD, 'yyyymmddhh24miss') as LTD,--T_FQS_AF_FL_DEPARTURES
                        NULL as LTA,--T_FQS_AF_FL_ARRIVALS
                        AIRLINE_TERMINAL, 
                        to_char(GATE_PLAN_CLOSE_TIME1,   'yyyymmddhh24miss') as     GATE_PLAN_CLOSE_TIME1, 
                        to_char(GATE_PLAN_OPEN_TIME1,    'yyyymmddhh24miss') as    GATE_PLAN_OPEN_TIME1, 
                        to_char(GATE_PLAN_CLOSE_TIME2,   'yyyymmddhh24miss') as    GATE_PLAN_CLOSE_TIME2, 
                        to_char(GATE_PLAN_OPEN_TIME2,     'yyyymmddhh24miss') as    GATE_PLAN_OPEN_TIME2 
                        from T_FQS_AF_FL_DEPARTURES 

                        union
                        select 
                        'A' as DRCT,
                        FA_ID as URNO,--.FD_ID
                        CARRIER_IATA, 
                        CARRIER_ICAO, 
                        FL_NUMBER , 
                        FL_SUFFIX , 
                        FLT,
                        FLR, 
                        to_char(SDT,'yyyymmddhh24miss') as SDT,
                        SDP,--T_FQS_AF_FL_ARRIVALS
                        LINKEDFL_FLT, 
                        LINKEDFL_CARRIER, 
                        LINKEDFL_NUMBER, 
                        LINKEDFL_SUFFIX, 
                        LINKEDFL_SDT, 
                        LINKEDFL_FLR,
                        LINKFL_ID,
                        MASTERFL_CARRIER,
                        MASTERFL_NUMBER,
                        MASTERFL_SUFFIX, 
                        MASTERFL_FLT as MFDI, 
                        MASTERFL_FLR, 
                        MASTERFL_ID, --T_FQS_AF_FL_ARRIVALS
                        AIRCRAFT_CALLSIGN, 
                        AIRCRAFT_OWNER, 
                        AIRCRAFT_PAXCAP, 
                        AIRCRAFT_REGISTRATION as REGN, 
                        AIRCRAFT_SUBTYPE as ATC5,
                        AIRCRAFT_TYPE, 
                        AIRCRAFT_OPERATOR, 
                        AIRCRAFT_TERMINAL, 
                        AIRPORT_IATA, 
                        RECLAIM_ID1 as BRC1,--T_FQS_AF_FL_ARRIVALS.RECLAIM_ID1
                        RECLAIM_ROLE1 as RECLAIM_ROLE1, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE1
                        to_char(RECLAIM_OPEN_TIME1, 'yyyymmddhh24miss') as BROD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME1
                        to_char(RECLAIM_CLOSE_TIME1, 'yyyymmddhh24miss') as BRCD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME1
                        EXITDOOR1, --T_FQS_AF_FL_ARRIVALS.EXITDOOR1
                        RECLAIM_ID2 as SRC2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ID2
                        RECLAIM_ROLE2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE2
                        to_char(RECLAIM_OPEN_TIME2, 'yyyymmddhh24miss') as SBRO, --T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME2
                        to_char(RECLAIM_CLOSE_TIME2, 'yyyymmddhh24miss') as SBRC, --T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME2
                        EXITDOOR2, --T_FQS_AF_FL_ARRIVALS.EXITDOOR2
                        NULL as MAKEUP_ID1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID1
                        NULL as MAKEUP_ROLE1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE1
                        NULL as MAKEUP_OPEN_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME1
                        NULL as MAKEUP_CLOSE_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME1
                        NULL as MAKEUP_ID2,  --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID2
                        NULL as MAKEUP_ROLE2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE2
                        NULL as MAKEUP_OPEN_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME2
                        NULL as MAKEUP_CLOSE_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME2
                        ISBUSREQUIRED, 
                        CC_TYPE1, 
                        CC_RANGE1 as CKIF,--.CC_RANGE1
                        CC_ROLE1, 
                        CC_CLUSTERID1, 
                        to_char(CC_OPEN_TIME1, 'yyyymmddhh24miss') as CODT,--.CC_OPEN_TIME1
                        to_char(CC_CLOSE_TIME1, 'yyyymmddhh24miss') as CCDT ,--.CC_CLOSE_TIME1
                        CC_TYPE2, 
                        CC_RANGE2 as SCDR,--.CC_RANGE2
                        CC_ROLE2, 
                        CC_CLUSTERID2, 
                        to_char(CC_OPEN_TIME2, 'yyyymmddhh24miss') as SCODT,--.CC_OPEN_TIME2
                        to_char(CC_CLOSE_TIME2, 'yyyymmddhh24miss') as SCCDT,--.CC_CLOSE_TIME2
                        to_char(GATE_CLOSE_TIME2, 'yyyymmddhh24miss') as SGCD,--.GATE_CLOSE_TIME2
                        to_char(GATE_OPEN_TIME2, 'yyyymmddhh24miss') as SGOD,--.GATE_OPEN_TIME2
                        GATE_BORDING_STATUS2, 
                        GATE_ROLE2,
                        GATE_NUMBER2 as SGN,--.GATE_NUMBER2
                        to_char(GATE_CLOSE_TIME1, 'yyyymmddhh24miss') as GCDT,--.GATE_CLOSE_TIME1
                        to_char(GATE_OPEN_TIME1, 'yyyymmddhh24miss') as GODT,--.GATE_OPEN_TIME1
                        GATE_BORDING_STATUS1 as GBS,--.GATE_BORDING_STATUS1
                        GATE_ROLE1, 
                        GATE_NUMBER1 as GENO ,--.GATE_NUMBER1
                        PASSENGER_TERMINAL as TERM, 
                        REMARK_CODE1, 
                        REMARK_TYPE1, 
                        REMARK_CODE2, 
                        REMARK_TYPE2, 
                        REMARK_CODE3, 
                        REMARK_TYPE3, 
                        REMARK_CODE4 , 
                        REMARK_TYPE4, 
                        RUNWAY_ID , 
                        S_INFO_TYPE1, 
                        S_INFO_TEXT1, 
                        S_INFO_TYPE2, 
                        S_INFO_TEXT2, 
                        S_INFO_TYPE3, 
                        S_INFO_TEXT3, 
                        S_INFO_TYPE4, 
                        S_INFO_TEXT4, 
                        S_INFO_TYPE5, 
                        S_INFO_TEXT5, 
                        ACCOUNT_CODE, 
                        CODESHARE_STATUS as CSS, 
                        DEVERT_AIRPORT as DAIA, 
                        FL_CANCELCODE,--.FL_CANCELCODE
                        FL_CLASSIFICATIONCODE,--.FL_CLASSIFICATIONCODE
                        FL_NATURECODE as TTYP, 
                        FL_OPERATES_OVERNIGHT, 
                        FL_SECTORCODE as FLTI,--.FL_SECTORCODE
                        FL_SERVICETYPE, 
                        FL_STATUSCODE,--.FL_STATUSCODE 
                        FL_TRANSITCODE, 
                        HANDLINGAGENT1, 
                        HANDLING_SERVICE1, 
                        HANDLINGAGENT2, 
                        HANDLING_SERVICE2, 
                        HANDLINGAGENT3, 
                        HANDLING_SERVICE3, 
                        HANDLINGAGENT4, 
                        HANDLING_SERVICE4, 
                        HANDLINGAGENT5, 
                        HANDLING_SERVICE5, 
                        IRR_NUMBER1, 
                        IRR_CODE1, 
                        IRR_DURATION1, 
                        IRR_NUMBER2, 
                        IRR_CODE2, 
                        IRR_DURATION2, 
                        ISGVF, 
                        ISRETURNFL, 
                        ISTRANSFERFL, 
                        NEWFL_REASON, 
                        OPERATIONTYPE_CODE1, 
                        TRANSFER_FL1, 
                        TRANSFER_FL2, 
                        TRANSFER_FL3, 
                        TRANSFER_FL4, 
                        TRANSFER_FL5, 
                        TRANSFER_FL6, 
                        TRANSFER_FL7, 
                        TRANSFER_FL8, 
                        TRANSFER_FL9, 
                        TRANSFER_FL10, 
                        TRANSFER_FL11, 
                        TRANSFER_FL12, 
                        TRANSFER_FL13, 
                        TRANSFER_FL14, 
                        TRANSFER_FL15, 
                        TRANSFER_FL16, 
                        TRANSFER_FL17, 
                        TRANSFER_FL18, 
                        TRANSFER_FL19, 
                        TRANSFER_FL20, 
                        SHAREFL_FLT1 , 
                        SHAREFL_FLN1 , 
                        SHAREFL_FLT2 , 
                        SHAREFL_FLN2 , 
                        SHAREFL_FLT3 , 
                        SHAREFL_FLN3 , 
                        SHAREFL_FLT4 , 
                        SHAREFL_FLN4 , 
                        SHAREFL_FLT5 , 
                        SHAREFL_FLN5 , 
                        SHAREFL_FLT6 , 
                        SHAREFL_FLN6 , 
                        TOTAL_BAGCOUNT, 
                        TOTAL_BAGWEIGHT , 
                        TOTAL_FREIGHTWEIGHT, 
                        TOTAL_MAILWEIGHT, 
                        TOTAL_LOADWEIGHT, 
                        ADULT_PAXCOUNT, 
                        BUSSINESS_PAXCOUNT, 
                        CHILD_PAXCOUNT, 
                        DOMESITEC_PAXCOUNT, 
                        INFANT_PAXCOUNT, 
                        INTERNATIONAL_PAXCOUNT, 
                        LOCAL_PAXCOUNT, 
                        NONTRANSFER_PAXCOUNT, 
                        TOTAL_PAXCOUNT, 
                        TRANSFER_PAXCOUNT, 
                        TRANSIT_PAXCOUNT, 
                        WHELLCHAIR_PAXCOUNT, 
                        TOTAL_CREWCOUNT, 
                        ECONOMY_PAXCOUNT, 
                        FIRSTCLASS_PAXCOUNT, 
                        TRANSFER_BAGCOUNT, 
                        TRANSFER_BAGWEIGHT, 
                        TRANSFER_FREIGHTWEIGHT, 
                        TRANSFER_MAILWEIGHT, 
                        TRANSIT_BAGCOUNT, 
                        TRANSIT_BAGWEIGHT, 
                        TRANSIT_FREIGHTWEIGHT, 
                        TRANSIT_MAILWEIGHT, 
                        to_char(OFFBLOCK_TIME, 'yyyymmddhh24miss') as OFFBLOCK_TIME, 
                        to_char(ONBLOCK_TIME, 'yyyymmddhh24miss') as ONBLOCK_TIME, 
                        to_char(EDT, 'yyyymmddhh24miss') as EDTA,--T_FQS_AF_FL_ARRIVALS.EDT
                        NULL as EDTD,--T_FQS_AF_FL_DEPARTURES.EDT
                        E_FL_DURATION, 
                        to_char(FIRSTBAG_TIME1, 'yyyymmddhh24miss') as FIRSTBAG_TIME, 
                        to_char(LASTBAG_TIME1, 'yyyymmddhh24miss') as  LASTBAG_TIME, 
                        to_char(FINALAPPROACH_TIME, 'yyyymmddhh24miss') as FINALAPPROACH_TIME, 
                        to_char(LASTKNOWN_TIME, 'yyyymmddhh24miss') as LASTKNOWN_TIME, 
                        LASTKNOWN_SOURCE, 
                        to_char(NEXT_INFO_TIME,        'yyyymmddhh24miss') as              NEXT_INFO_TIME, 
                        to_char(A_NEXT_STATION_TIME,   'yyyymmddhh24miss') as              A_NEXT_STATION_TIME, 
                        to_char(E_NEXT_STATION_TIME,   'yyyymmddhh24miss') as              E_NEXT_STATION_TIME, 
                        to_char(S_NEXT_STATION_TIME,   'yyyymmddhh24miss') as              S_NEXT_STATION_TIME, 
                        to_char(A_PREV_STATION_TIME,   'yyyymmddhh24miss') as              A_PREV_STATION_TIME, 
                        to_char(E_PREV_STATION_TIME,   'yyyymmddhh24miss') as              E_PREV_STATION_TIME, 
                        to_char(S_PREV_STATION_TIME,   'yyyymmddhh24miss') as               S_PREV_STATION_TIME, 
                        to_char(WHEELDOWN_TIME, 'yyyymmddhh24miss') as LAND,--.WHEELDOWN_TIME
                        to_char(WHEELUP_TIME, 'yyyymmddhh24miss') as AIRB,--.WHEELUP_TIME
                        to_char(TEN_MILES_TIME, 'yyyymmddhh24miss') as  TEN_MILES_TIME, 
                        ORG_IATA as ORG3,
                        NULL as DES3,
                        ORG_ICAO,
                        DES_ICAO, 
                        VIA_IATA1,--VIA1
                        VIA_IATA2,--VIA1
                        VIA_IATA3,--VIA1
                        VIA_IATA4,--VIA1
                        VIA_IATA5,--VIA1
                        VIA_IATA6,--VIA1
                        VIA_ICAO1,--VIA_ICAO
                        VIA_ICAO2,--VIA_ICAO
                        VIA_ICAO3,--VIA_ICAO
                        VIA_ICAO4,--VIA_ICAO
                        VIA_ICAO5,--VIA_ICAO
                        VIA_ICAO6,--VIA_ICAO
                        PUBLIC_FLT, 
                        PUBLIC_FLC, 
                        to_char(PUBLIC_TIME, 'yyyymmddhh24miss') as PUBLIC_TIME, 
                        SECURE_STAND_IS_REQUIRED, 
                        STAND_POSITION as STPO,--.STAND_POSITION
                        to_char(SDT_TIME, 'yyyymmddhh24miss') as STOD, 
                        OPERATIONTYPE_CODE2, 
                        to_char(FIRSTBAG_TIME2, 'yyyymmddhh24miss') as FIRSTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        to_char(LASTBAG_TIME2, 'yyyymmddhh24miss') as LASTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        OPERATIONTYPE_ROLE1, 
                        OPERATIONTYPE_ROLE2, 
                        to_char(UPDATE_TIME, 'yyyymmddhh24miss') as UPDATE_TIME , 
                        CUSTOM_STATUS, 
                        SUB_AIRLINE, 
                        NULL as LTD,--T_FQS_AF_FL_DEPARTURES
                        to_char(LTA,   'yyyymmddhh24miss') as LTA,--T_FQS_AF_FL_ARRIVALS
                        AIRLINE_TERMINAL, 
                        to_char(GATE_PLAN_CLOSE_TIME1,   'yyyymmddhh24miss') as  GATE_PLAN_CLOSE_TIME1, 
                        to_char(GATE_PLAN_OPEN_TIME1,    'yyyymmddhh24miss') as  GATE_PLAN_OPEN_TIME1, 
                        to_char(GATE_PLAN_CLOSE_TIME2,   'yyyymmddhh24miss') as  GATE_PLAN_CLOSE_TIME2, 
                        to_char(GATE_PLAN_OPEN_TIME2,    'yyyymmddhh24miss') as   GATE_PLAN_OPEN_TIME2 
                        from T_FQS_AF_FL_ARRIVALS
                        
                        ";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.getStrConnectionFlightQuerySystem(), sql);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }

        public static DataTable GetFlightQuerySystemDatasByDateDiff(DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            string sql = @"select 
                        'D' as DRCT,
                        FD_ID as URNO,--.FD_ID
                        CARRIER_IATA, 
                        CARRIER_ICAO, 
                        FL_NUMBER , 
                        FL_SUFFIX , 
                        FLT,
                        FLR, 
                        to_char(SDT,'yyyymmddhh24miss') as SDT,
                        NULL as SDP,--T_FQS_AF_FL_ARRIVALS
                        LINKEDFL_FLT, 
                        LINKEDFL_CARRIER, 
                        LINKEDFL_NUMBER, 
                        LINKEDFL_SUFFIX, 
                        LINKEDFL_SDT, 
                        LINKEDFL_FLR,
                        LINKFL_ID,
                        MASTERFL_CARRIER,
                        MASTERFL_NUMBER,
                        MASTERFL_SUFFIX, 
                        MASTERFL_FLT as MFDI, 
                        MASTERFL_FLR, 
                        NULL as MASTERFL_ID, --T_FQS_AF_FL_ARRIVALS
                        AIRCRAFT_CALLSIGN, 
                        AIRCRAFT_OWNER, 
                        AIRCRAFT_PAXCAP, 
                        AIRCRAFT_REGISTRATION as REGN, 
                        AIRCRAFT_SUBTYPE as ATC5,
                        AIRCRAFT_TYPE, 
                        AIRCRAFT_OPERATOR, 
                        AIRCRAFT_TERMINAL, 
                        AIRPORT_IATA, 
                        NULL as BRC1,--T_FQS_AF_FL_ARRIVALS.RECLAIM_ID1
                        NULL as RECLAIM_ROLE1, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE1
                        NULL as BROD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME1
                        NULL as BRCD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME1
                        NULL as EXITDOOR1, --T_FQS_AF_FL_ARRIVALS.EXITDOOR1
                        NULL as SRC2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ID2
                        NULL as RECLAIM_ROLE2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE2
                        NULL as SBRO, --T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME2
                        NULL as SBRC, --T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME2
                        NULL as EXITDOOR2, --T_FQS_AF_FL_ARRIVALS.EXITDOOR2
                        MAKEUP_ID1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID1
                        MAKEUP_ROLE1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE1
                        to_char(MAKEUP_OPEN_TIME1, 'yyyymmddhh24miss') as MAKEUP_OPEN_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME1
                        to_char(MAKEUP_CLOSE_TIME1, 'yyyymmddhh24miss') as MAKEUP_CLOSE_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME1
                        MAKEUP_ID2,  --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID2
                        MAKEUP_ROLE2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE2
                        to_char(MAKEUP_OPEN_TIME2, 'yyyymmddhh24miss') as MAKEUP_OPEN_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME2
                        to_char(MAKEUP_CLOSE_TIME2, 'yyyymmddhh24miss') as MAKEUP_CLOSE_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME2
                        ISBUSREQUIRED, 
                        CC_TYPE1, 
                        CC_RANGE1 as CKIF,--.CC_RANGE1
                        CC_ROLE1, 
                        CC_CLUSTERID1, 
                        to_char(CC_OPEN_TIME1, 'yyyymmddhh24miss') as CODT,--.CC_OPEN_TIME1
                        to_char(CC_CLOSE_TIME1, 'yyyymmddhh24miss') as CCDT ,--.CC_CLOSE_TIME1
                        CC_TYPE2, 
                        CC_RANGE2 as SCDR,--.CC_RANGE2
                        CC_ROLE2, 
                        CC_CLUSTERID2, 
                        to_char(CC_OPEN_TIME2, 'yyyymmddhh24miss') as SCODT,--.CC_OPEN_TIME2
                        to_char(CC_CLOSE_TIME2, 'yyyymmddhh24miss') as SCCDT,--.CC_CLOSE_TIME2
                        to_char(GATE_CLOSE_TIME2, 'yyyymmddhh24miss') as SGCD,--.GATE_CLOSE_TIME2
                        to_char(GATE_OPEN_TIME2, 'yyyymmddhh24miss') as SGOD,--.GATE_OPEN_TIME2
                        GATE_BORDING_STATUS2, 
                        GATE_ROLE2,
                        GATE_NUMBER2 as SGN,--.GATE_NUMBER2
                        to_char(GATE_CLOSE_TIME1, 'yyyymmddhh24miss') as GCDT,--.GATE_CLOSE_TIME1
                        to_char(GATE_OPEN_TIME1, 'yyyymmddhh24miss') as GODT,--.GATE_OPEN_TIME1
                        GATE_BORDING_STATUS1 as GBS,--.GATE_BORDING_STATUS1
                        GATE_ROLE1, 
                        GATE_NUMBER1 as GENO ,--.GATE_NUMBER1
                        PASSENGER_TERMINAL as TERM, 
                        REMARK_CODE1, 
                        REMARK_TYPE1, 
                        REMARK_CODE2, 
                        REMARK_TYPE2, 
                        REMARK_CODE3, 
                        REMARK_TYPE3, 
                        REMARK_CODE4 , 
                        REMARK_TYPE4, 
                        RUNWAY_ID , 
                        S_INFO_TYPE1, 
                        S_INFO_TEXT1, 
                        S_INFO_TYPE2, 
                        S_INFO_TEXT2, 
                        S_INFO_TYPE3, 
                        S_INFO_TEXT3, 
                        S_INFO_TYPE4, 
                        S_INFO_TEXT4, 
                        S_INFO_TYPE5, 
                        S_INFO_TEXT5, 
                        ACCOUNT_CODE, 
                        CODESHARE_STATUS as CSS, 
                        DEVERT_AIRPORT as DAIA, 
                        FL_CANCELCODE,--.FL_CANCELCODE
                        FL_CLASSIFICATIONCODE,--.FL_CLASSIFICATIONCODE
                        FL_NATURECODE as TTYP, 
                        FL_OPERATES_OVERNIGHT, 
                        FL_SECTORCODE as FLTI,--.FL_SECTORCODE
                        FL_SERVICETYPE, 
                        FL_STATUSCODE,--.FL_STATUSCODE 
                        FL_TRANSITCODE, 
                        HANDLINGAGENT1, 
                        HANDLING_SERVICE1, 
                        HANDLINGAGENT2, 
                        HANDLING_SERVICE2, 
                        HANDLINGAGENT3, 
                        HANDLING_SERVICE3, 
                        HANDLINGAGENT4, 
                        HANDLING_SERVICE4, 
                        HANDLINGAGENT5, 
                        HANDLING_SERVICE5, 
                        IRR_NUMBER1, 
                        IRR_CODE1, 
                        IRR_DURATION1, 
                        IRR_NUMBER2, 
                        IRR_CODE2, 
                        IRR_DURATION2, 
                        ISGVF, 
                        ISRETURNFL, 
                        ISTRANSFERFL, 
                        NEWFL_REASON, 
                        OPERATIONTYPE_CODE1, 
                        TRANSFER_FL1, 
                        TRANSFER_FL2, 
                        TRANSFER_FL3, 
                        TRANSFER_FL4, 
                        TRANSFER_FL5, 
                        TRANSFER_FL6, 
                        TRANSFER_FL7, 
                        TRANSFER_FL8, 
                        TRANSFER_FL9, 
                        TRANSFER_FL10, 
                        TRANSFER_FL11, 
                        TRANSFER_FL12, 
                        TRANSFER_FL13, 
                        TRANSFER_FL14, 
                        TRANSFER_FL15, 
                        TRANSFER_FL16, 
                        TRANSFER_FL17, 
                        TRANSFER_FL18, 
                        TRANSFER_FL19, 
                        TRANSFER_FL20, 
                        SHAREFL_FLT1 , 
                        SHAREFL_FLN1 , 
                        SHAREFL_FLT2 , 
                        SHAREFL_FLN2 , 
                        SHAREFL_FLT3 , 
                        SHAREFL_FLN3 , 
                        SHAREFL_FLT4 , 
                        SHAREFL_FLN4 , 
                        SHAREFL_FLT5 , 
                        SHAREFL_FLN5 , 
                        SHAREFL_FLT6 , 
                        SHAREFL_FLN6 , 
                        TOTAL_BAGCOUNT, 
                        TOTAL_BAGWEIGHT , 
                        TOTAL_FREIGHTWEIGHT, 
                        TOTAL_MAILWEIGHT, 
                        TOTAL_LOADWEIGHT, 
                        ADULT_PAXCOUNT, 
                        BUSSINESS_PAXCOUNT, 
                        CHILD_PAXCOUNT, 
                        DOMESITEC_PAXCOUNT, 
                        INFANT_PAXCOUNT, 
                        INTERNATIONAL_PAXCOUNT, 
                        LOCAL_PAXCOUNT, 
                        NONTRANSFER_PAXCOUNT, 
                        TOTAL_PAXCOUNT, 
                        TRANSFER_PAXCOUNT, 
                        TRANSIT_PAXCOUNT, 
                        WHELLCHAIR_PAXCOUNT, 
                        TOTAL_CREWCOUNT, 
                        ECONOMY_PAXCOUNT, 
                        FIRSTCLASS_PAXCOUNT, 
                        TRANSFER_BAGCOUNT, 
                        TRANSFER_BAGWEIGHT, 
                        TRANSFER_FREIGHTWEIGHT, 
                        TRANSFER_MAILWEIGHT, 
                        TRANSIT_BAGCOUNT, 
                        TRANSIT_BAGWEIGHT, 
                        TRANSIT_FREIGHTWEIGHT, 
                        TRANSIT_MAILWEIGHT, 
                        to_char(OFFBLOCK_TIME, 'yyyymmddhh24miss') as OFFBLOCK_TIME , 
                        to_char(ONBLOCK_TIME, 'yyyymmddhh24miss') as ONBLOCK_TIME, 
                        NULL as EDTA,--T_FQS_AF_FL_ARRIVALS.EDT
                        to_char(EDT,'yyyymmddhh24miss') as EDTD,--T_FQS_AF_FL_DEPARTURES.EDT
                        E_FL_DURATION, 
                        to_char(FIRSTBAG_TIME, 'yyyymmddhh24miss') as FIRSTBAG_TIME, 
                        to_char(LASTBAG_TIME, 'yyyymmddhh24miss') as LASTBAG_TIME, 
                        to_char(FINALAPPROACH_TIME, 'yyyymmddhh24miss') as FINALAPPROACH_TIME, 
                        to_char(LASTKNOWN_TIME, 'yyyymmddhh24miss') as LASTKNOWN_TIME, 
                        LASTKNOWN_SOURCE, 
                        to_char(NEXT_INFO_TIME, 'yyyymmddhh24miss') as NEXT_INFO_TIME, 
                        to_char(A_NEXT_STATION_TIME, 'yyyymmddhh24miss') as A_NEXT_STATION_TIME, 
                        to_char(E_NEXT_STATION_TIME, 'yyyymmddhh24miss') as E_NEXT_STATION_TIME, 
                        to_char(S_NEXT_STATION_TIME, 'yyyymmddhh24miss') as S_NEXT_STATION_TIME, 
                        to_char(A_PREV_STATION_TIME, 'yyyymmddhh24miss') as A_PREV_STATION_TIME, 
                        to_char(E_PREV_STATION_TIME, 'yyyymmddhh24miss') as E_PREV_STATION_TIME, 
                        to_char(S_PREV_STATION_TIME, 'yyyymmddhh24miss') as S_PREV_STATION_TIME, 
                        to_char(WHEELDOWN_TIME, 'yyyymmddhh24miss') as LAND,--.WHEELDOWN_TIME
                        to_char(WHEELUP_TIME, 'yyyymmddhh24miss') as AIRB,--.WHEELUP_TIME
                        to_char(TEN_MILES_TIME, 'yyyymmddhh24miss') as TEN_MILES_TIME, 
                        NULL as ORG3,
                        DES_IATA as DES3,
                        ORG_ICAO,
                        DES_ICAO, 
                        VIA_IATA1,--VIA1
                        VIA_IATA2,--VIA1
                        VIA_IATA3,--VIA1
                        VIA_IATA4,--VIA1
                        VIA_IATA5,--VIA1
                        VIA_IATA6,--VIA1
                        VIA_ICAO1,--VIA_ICAO
                        VIA_ICAO2,--VIA_ICAO
                        VIA_ICAO3,--VIA_ICAO
                        VIA_ICAO4,--VIA_ICAO
                        VIA_ICAO5,--VIA_ICAO
                        VIA_ICAO6,--VIA_ICAO
                        PUBLIC_FLT, 
                        PUBLIC_FLC, 
                        to_char(PUBLIC_TIME, 'yyyymmddhh24miss') as PUBLIC_TIME, 
                        SECURE_STAND_IS_REQUIRED, 
                        STAND_POSITION as STPO,--.STAND_POSITION
                        to_char(SDT_TIME, 'yyyymmddhh24miss') as STOD, 
                        OPERATIONTYPE_CODE2, 
                        NULL as FIRSTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        NULL as LASTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        OPERATIONTYPE_ROLE1, 
                        OPERATIONTYPE_ROLE2, 
                        to_char(UPDATE_TIME, 'yyyymmddhh24miss') as UPDATE_TIME, 
                        CUSTOM_STATUS, 
                        SUB_AIRLINE, 
                        to_char(LTD, 'yyyymmddhh24miss') as LTD,--T_FQS_AF_FL_DEPARTURES
                        NULL as LTA,--T_FQS_AF_FL_ARRIVALS
                        AIRLINE_TERMINAL, 
                        to_char(GATE_PLAN_CLOSE_TIME1,   'yyyymmddhh24miss') as     GATE_PLAN_CLOSE_TIME1, 
                        to_char(GATE_PLAN_OPEN_TIME1,    'yyyymmddhh24miss') as    GATE_PLAN_OPEN_TIME1, 
                        to_char(GATE_PLAN_CLOSE_TIME2,   'yyyymmddhh24miss') as    GATE_PLAN_CLOSE_TIME2, 
                        to_char(GATE_PLAN_OPEN_TIME2,     'yyyymmddhh24miss') as    GATE_PLAN_OPEN_TIME2 
                        from T_FQS_AF_FL_DEPARTURES 
                        WHERE                     
                        (to_char(SDT_TIME,'yyyymmddhh24miss') BETWEEN  :varSCHEDULEDDATETIMEBEFORE1 AND :varSCHEDULEDDATETIMEAFTER1 )
                        and SDT_TIME is not null
                        union

                        select 
                        'A' as DRCT,
                        FA_ID as URNO,--.FD_ID
                        CARRIER_IATA, 
                        CARRIER_ICAO, 
                        FL_NUMBER , 
                        FL_SUFFIX , 
                        FLT,
                        FLR, 
                        to_char(SDT,'yyyymmddhh24miss') as SDT,
                        SDP,--T_FQS_AF_FL_ARRIVALS
                        LINKEDFL_FLT, 
                        LINKEDFL_CARRIER, 
                        LINKEDFL_NUMBER, 
                        LINKEDFL_SUFFIX, 
                        LINKEDFL_SDT, 
                        LINKEDFL_FLR,
                        LINKFL_ID,
                        MASTERFL_CARRIER,
                        MASTERFL_NUMBER,
                        MASTERFL_SUFFIX, 
                        MASTERFL_FLT as MFDI, 
                        MASTERFL_FLR, 
                        MASTERFL_ID, --T_FQS_AF_FL_ARRIVALS
                        AIRCRAFT_CALLSIGN, 
                        AIRCRAFT_OWNER, 
                        AIRCRAFT_PAXCAP, 
                        AIRCRAFT_REGISTRATION as REGN, 
                        AIRCRAFT_SUBTYPE as ATC5,
                        AIRCRAFT_TYPE, 
                        AIRCRAFT_OPERATOR, 
                        AIRCRAFT_TERMINAL, 
                        AIRPORT_IATA, 
                        RECLAIM_ID1 as BRC1,--T_FQS_AF_FL_ARRIVALS.RECLAIM_ID1
                        RECLAIM_ROLE1 as RECLAIM_ROLE1, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE1
                        to_char(RECLAIM_OPEN_TIME1, 'yyyymmddhh24miss') as BROD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME1
                        to_char(RECLAIM_CLOSE_TIME1, 'yyyymmddhh24miss') as BRCD,--T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME1
                        EXITDOOR1, --T_FQS_AF_FL_ARRIVALS.EXITDOOR1
                        RECLAIM_ID2 as SRC2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ID2
                        RECLAIM_ROLE2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ROLE2
                        to_char(RECLAIM_OPEN_TIME2, 'yyyymmddhh24miss') as SBRO, --T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME2
                        to_char(RECLAIM_CLOSE_TIME2, 'yyyymmddhh24miss') as SBRC, --T_FQS_AF_FL_ARRIVALS.RECLAIM_CLOSE_TIME2
                        EXITDOOR2, --T_FQS_AF_FL_ARRIVALS.EXITDOOR2
                        NULL as MAKEUP_ID1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID1
                        NULL as MAKEUP_ROLE1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE1
                        NULL as MAKEUP_OPEN_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME1
                        NULL as MAKEUP_CLOSE_TIME1, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME1
                        NULL as MAKEUP_ID2,  --T_FQS_AF_FL_DEPARTURES.MAKEUP_ID2
                        NULL as MAKEUP_ROLE2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_ROLE2
                        NULL as MAKEUP_OPEN_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_OPEN_TIME2
                        NULL as MAKEUP_CLOSE_TIME2, --T_FQS_AF_FL_DEPARTURES.MAKEUP_CLOSE_TIME2
                        ISBUSREQUIRED, 
                        CC_TYPE1, 
                        CC_RANGE1 as CKIF,--.CC_RANGE1
                        CC_ROLE1, 
                        CC_CLUSTERID1, 
                        to_char(CC_OPEN_TIME1, 'yyyymmddhh24miss') as CODT,--.CC_OPEN_TIME1
                        to_char(CC_CLOSE_TIME1, 'yyyymmddhh24miss') as CCDT ,--.CC_CLOSE_TIME1
                        CC_TYPE2, 
                        CC_RANGE2 as SCDR,--.CC_RANGE2
                        CC_ROLE2, 
                        CC_CLUSTERID2, 
                        to_char(CC_OPEN_TIME2, 'yyyymmddhh24miss') as SCODT,--.CC_OPEN_TIME2
                        to_char(CC_CLOSE_TIME2, 'yyyymmddhh24miss') as SCCDT,--.CC_CLOSE_TIME2
                        to_char(GATE_CLOSE_TIME2, 'yyyymmddhh24miss') as SGCD,--.GATE_CLOSE_TIME2
                        to_char(GATE_OPEN_TIME2, 'yyyymmddhh24miss') as SGOD,--.GATE_OPEN_TIME2
                        GATE_BORDING_STATUS2, 
                        GATE_ROLE2,
                        GATE_NUMBER2 as SGN,--.GATE_NUMBER2
                        to_char(GATE_CLOSE_TIME1, 'yyyymmddhh24miss') as GCDT,--.GATE_CLOSE_TIME1
                        to_char(GATE_OPEN_TIME1, 'yyyymmddhh24miss') as GODT,--.GATE_OPEN_TIME1
                        GATE_BORDING_STATUS1 as GBS,--.GATE_BORDING_STATUS1
                        GATE_ROLE1, 
                        GATE_NUMBER1 as GENO ,--.GATE_NUMBER1
                        PASSENGER_TERMINAL as TERM, 
                        REMARK_CODE1, 
                        REMARK_TYPE1, 
                        REMARK_CODE2, 
                        REMARK_TYPE2, 
                        REMARK_CODE3, 
                        REMARK_TYPE3, 
                        REMARK_CODE4 , 
                        REMARK_TYPE4, 
                        RUNWAY_ID , 
                        S_INFO_TYPE1, 
                        S_INFO_TEXT1, 
                        S_INFO_TYPE2, 
                        S_INFO_TEXT2, 
                        S_INFO_TYPE3, 
                        S_INFO_TEXT3, 
                        S_INFO_TYPE4, 
                        S_INFO_TEXT4, 
                        S_INFO_TYPE5, 
                        S_INFO_TEXT5, 
                        ACCOUNT_CODE, 
                        CODESHARE_STATUS as CSS, 
                        DEVERT_AIRPORT as DAIA, 
                        FL_CANCELCODE,--.FL_CANCELCODE
                        FL_CLASSIFICATIONCODE,--.FL_CLASSIFICATIONCODE
                        FL_NATURECODE as TTYP, 
                        FL_OPERATES_OVERNIGHT, 
                        FL_SECTORCODE as FLTI,--.FL_SECTORCODE
                        FL_SERVICETYPE, 
                        FL_STATUSCODE,--.FL_STATUSCODE 
                        FL_TRANSITCODE, 
                        HANDLINGAGENT1, 
                        HANDLING_SERVICE1, 
                        HANDLINGAGENT2, 
                        HANDLING_SERVICE2, 
                        HANDLINGAGENT3, 
                        HANDLING_SERVICE3, 
                        HANDLINGAGENT4, 
                        HANDLING_SERVICE4, 
                        HANDLINGAGENT5, 
                        HANDLING_SERVICE5, 
                        IRR_NUMBER1, 
                        IRR_CODE1, 
                        IRR_DURATION1, 
                        IRR_NUMBER2, 
                        IRR_CODE2, 
                        IRR_DURATION2, 
                        ISGVF, 
                        ISRETURNFL, 
                        ISTRANSFERFL, 
                        NEWFL_REASON, 
                        OPERATIONTYPE_CODE1, 
                        TRANSFER_FL1, 
                        TRANSFER_FL2, 
                        TRANSFER_FL3, 
                        TRANSFER_FL4, 
                        TRANSFER_FL5, 
                        TRANSFER_FL6, 
                        TRANSFER_FL7, 
                        TRANSFER_FL8, 
                        TRANSFER_FL9, 
                        TRANSFER_FL10, 
                        TRANSFER_FL11, 
                        TRANSFER_FL12, 
                        TRANSFER_FL13, 
                        TRANSFER_FL14, 
                        TRANSFER_FL15, 
                        TRANSFER_FL16, 
                        TRANSFER_FL17, 
                        TRANSFER_FL18, 
                        TRANSFER_FL19, 
                        TRANSFER_FL20, 
                        SHAREFL_FLT1 , 
                        SHAREFL_FLN1 , 
                        SHAREFL_FLT2 , 
                        SHAREFL_FLN2 , 
                        SHAREFL_FLT3 , 
                        SHAREFL_FLN3 , 
                        SHAREFL_FLT4 , 
                        SHAREFL_FLN4 , 
                        SHAREFL_FLT5 , 
                        SHAREFL_FLN5 , 
                        SHAREFL_FLT6 , 
                        SHAREFL_FLN6 , 
                        TOTAL_BAGCOUNT, 
                        TOTAL_BAGWEIGHT , 
                        TOTAL_FREIGHTWEIGHT, 
                        TOTAL_MAILWEIGHT, 
                        TOTAL_LOADWEIGHT, 
                        ADULT_PAXCOUNT, 
                        BUSSINESS_PAXCOUNT, 
                        CHILD_PAXCOUNT, 
                        DOMESITEC_PAXCOUNT, 
                        INFANT_PAXCOUNT, 
                        INTERNATIONAL_PAXCOUNT, 
                        LOCAL_PAXCOUNT, 
                        NONTRANSFER_PAXCOUNT, 
                        TOTAL_PAXCOUNT, 
                        TRANSFER_PAXCOUNT, 
                        TRANSIT_PAXCOUNT, 
                        WHELLCHAIR_PAXCOUNT, 
                        TOTAL_CREWCOUNT, 
                        ECONOMY_PAXCOUNT, 
                        FIRSTCLASS_PAXCOUNT, 
                        TRANSFER_BAGCOUNT, 
                        TRANSFER_BAGWEIGHT, 
                        TRANSFER_FREIGHTWEIGHT, 
                        TRANSFER_MAILWEIGHT, 
                        TRANSIT_BAGCOUNT, 
                        TRANSIT_BAGWEIGHT, 
                        TRANSIT_FREIGHTWEIGHT, 
                        TRANSIT_MAILWEIGHT, 
                        to_char(OFFBLOCK_TIME, 'yyyymmddhh24miss') as OFFBLOCK_TIME, 
                        to_char(ONBLOCK_TIME, 'yyyymmddhh24miss') as ONBLOCK_TIME, 
                        to_char(EDT, 'yyyymmddhh24miss') as EDTA,--T_FQS_AF_FL_ARRIVALS.EDT
                        NULL as EDTD,--T_FQS_AF_FL_DEPARTURES.EDT
                        E_FL_DURATION, 
                        to_char(FIRSTBAG_TIME1, 'yyyymmddhh24miss') as FIRSTBAG_TIME, 
                        to_char(LASTBAG_TIME1, 'yyyymmddhh24miss') as  LASTBAG_TIME, 
                        to_char(FINALAPPROACH_TIME, 'yyyymmddhh24miss') as FINALAPPROACH_TIME, 
                        to_char(LASTKNOWN_TIME, 'yyyymmddhh24miss') as LASTKNOWN_TIME, 
                        LASTKNOWN_SOURCE, 
                        to_char(NEXT_INFO_TIME,        'yyyymmddhh24miss') as              NEXT_INFO_TIME, 
                        to_char(A_NEXT_STATION_TIME,   'yyyymmddhh24miss') as              A_NEXT_STATION_TIME, 
                        to_char(E_NEXT_STATION_TIME,   'yyyymmddhh24miss') as              E_NEXT_STATION_TIME, 
                        to_char(S_NEXT_STATION_TIME,   'yyyymmddhh24miss') as              S_NEXT_STATION_TIME, 
                        to_char(A_PREV_STATION_TIME,   'yyyymmddhh24miss') as              A_PREV_STATION_TIME, 
                        to_char(E_PREV_STATION_TIME,   'yyyymmddhh24miss') as              E_PREV_STATION_TIME, 
                        to_char(S_PREV_STATION_TIME,   'yyyymmddhh24miss') as               S_PREV_STATION_TIME, 
                        to_char(WHEELDOWN_TIME, 'yyyymmddhh24miss') as LAND,--.WHEELDOWN_TIME
                        to_char(WHEELUP_TIME, 'yyyymmddhh24miss') as AIRB,--.WHEELUP_TIME
                        to_char(TEN_MILES_TIME, 'yyyymmddhh24miss') as  TEN_MILES_TIME, 
                        ORG_IATA as ORG3,
                        NULL as DES3,
                        ORG_ICAO,
                        DES_ICAO, 
                        VIA_IATA1,--VIA1
                        VIA_IATA2,--VIA1
                        VIA_IATA3,--VIA1
                        VIA_IATA4,--VIA1
                        VIA_IATA5,--VIA1
                        VIA_IATA6,--VIA1
                        VIA_ICAO1,--VIA_ICAO
                        VIA_ICAO2,--VIA_ICAO
                        VIA_ICAO3,--VIA_ICAO
                        VIA_ICAO4,--VIA_ICAO
                        VIA_ICAO5,--VIA_ICAO
                        VIA_ICAO6,--VIA_ICAO
                        PUBLIC_FLT, 
                        PUBLIC_FLC, 
                        to_char(PUBLIC_TIME, 'yyyymmddhh24miss') as PUBLIC_TIME, 
                        SECURE_STAND_IS_REQUIRED, 
                        STAND_POSITION as STPO,--.STAND_POSITION
                        to_char(SDT_TIME, 'yyyymmddhh24miss') as STOD, 
                        OPERATIONTYPE_CODE2, 
                        to_char(FIRSTBAG_TIME2, 'yyyymmddhh24miss') as FIRSTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        to_char(LASTBAG_TIME2, 'yyyymmddhh24miss') as LASTBAG_TIME2,--T_FQS_AF_FL_ARRIVALS
                        OPERATIONTYPE_ROLE1, 
                        OPERATIONTYPE_ROLE2, 
                        to_char(UPDATE_TIME, 'yyyymmddhh24miss') as UPDATE_TIME , 
                        CUSTOM_STATUS, 
                        SUB_AIRLINE, 
                        NULL as LTD,--T_FQS_AF_FL_DEPARTURES
                        to_char(LTA,   'yyyymmddhh24miss') as LTA,--T_FQS_AF_FL_ARRIVALS
                        AIRLINE_TERMINAL, 
                        to_char(GATE_PLAN_CLOSE_TIME1,   'yyyymmddhh24miss') as  GATE_PLAN_CLOSE_TIME1, 
                        to_char(GATE_PLAN_OPEN_TIME1,    'yyyymmddhh24miss') as  GATE_PLAN_OPEN_TIME1, 
                        to_char(GATE_PLAN_CLOSE_TIME2,   'yyyymmddhh24miss') as  GATE_PLAN_CLOSE_TIME2, 
                        to_char(GATE_PLAN_OPEN_TIME2,    'yyyymmddhh24miss') as   GATE_PLAN_OPEN_TIME2 
                        from T_FQS_AF_FL_ARRIVALS
                        WHERE 
                         (to_char(SDT_TIME, 'yyyymmddhh24miss') BETWEEN  :varSCHEDULEDDATETIMEBEFORE3 AND :varSCHEDULEDDATETIMEAFTER3) 
                         and SDT_TIME is not null
                    ";

            //OracleParameter[] para = new OracleParameter[8];
            //para[0] = new OracleParameter("varSCHEDULEDDATETIMEBEFORE", dateTimeStart);//.ToString("yyyyMMddHHmmss"));
            //para[1] = new OracleParameter("varSCHEDULEDDATETIMEAFTER", dateTimeEnd);//.ToString("yyyyMMddHHmmss"));
            //para[2] = new OracleParameter("varSCHEDULEDDATETIMEBEFORE1", dateTimeStart);//.ToString("yyyyMMddHHmmss"));
            //para[3] = new OracleParameter("varSCHEDULEDDATETIMEAFTER1", dateTimeEnd);//.ToString("yyyyMMddHHmmss"));
            //para[4] = new OracleParameter("varSCHEDULEDDATETIMEBEFORE2", dateTimeStart);//.ToString("yyyyMMddHHmmss"));
            //para[5] = new OracleParameter("varSCHEDULEDDATETIMEAFTER2", dateTimeEnd);//.ToString("yyyyMMddHHmmss"));
            //para[6] = new OracleParameter("varSCHEDULEDDATETIMEBEFORE3", dateTimeStart);//.ToString("yyyyMMddHHmmss"));
            //para[7] = new OracleParameter("varSCHEDULEDDATETIMEAFTER3", dateTimeEnd);//.ToString("yyyyMMddHHmmss"));
            OracleParameter[] para = new OracleParameter[4];
            para[0] = new OracleParameter("varSCHEDULEDDATETIMEBEFORE1", dateTimeStart.ToString("yyyyMMddHHmmss"));
            para[1] = new OracleParameter("varSCHEDULEDDATETIMEAFTER1", dateTimeEnd.ToString("yyyyMMddHHmmss"));
            para[2] = new OracleParameter("varSCHEDULEDDATETIMEBEFORE3", dateTimeStart.ToString("yyyyMMddHHmmss"));
            para[3] = new OracleParameter("varSCHEDULEDDATETIMEAFTER3", dateTimeEnd.ToString("yyyyMMddHHmmss"));

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.getStrConnectionFlightQuerySystem(), sql, para);

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
