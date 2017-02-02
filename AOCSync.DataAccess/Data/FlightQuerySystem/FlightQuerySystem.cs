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
                        substr(FLIGHT_DIRECTION,0,1) as DRCT,
                        FLIGHT_IDENTITY as FLT,
                        FLIGHT_STATUS_CODE as OPERATIONTYPE_CODE1,
                        to_char(to_date(SCHEDULED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as STOD,
                        flight_nature_code as TTYP, 
                        to_char(to_date(WHEELS_DOWN_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as LAND,
                        to_char(to_date(WHEELS_UP_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as AIRB,
                        AIRCRAFT_SUBTYPE_IATA_CODE as ATC5,
                        STAND_POSITION as STPO,
                        GATE_NUMBER_P as GENO,
                        to_char(to_date(ESTIMATED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as EDTA,
                        to_char(to_date(ESTIMATED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as EDTD,
                        BAGGAGE_RECLAIM_CAROUSEL_ID_P as BRC1,
                        to_char(to_date(BAGGAGE_RECKAIM_OPEN_DT_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as BROD,
                        to_char(to_date(BAGGAGE_RECLAIM_CLOSE_DT_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as BRCD,
                        BAGGAGE_RECLAIM_CAROUSEL_ID_S as SRC2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ID2
                        to_char(to_date(BAGGAGE_RECKAIM_OPEN_DT_S,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SBRO, --T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME2
                        to_char(to_date(BAGGAGE_RECLAIM_CLOSE_DT_S,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SBRC,
                        GATE_BOARDING_STATUS_P as GBS,
                        to_char(to_date(GATE_OPEN_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as GODT,
                        to_char(to_date(GATE_CLOSE_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as GCDT,
                        GATE_NUMBER_S as SGN,
                        to_char(to_date(GATE_OPEN_DATE_TIME_S,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SGOD,
                        to_char(to_date(GATE_CLOSE_DATE_TIME_S,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SGCD,
                        AIRCRAFT_REGISTRATION as REGN,
                        ID as URNO,
                        decode(flight_direction,'Arrival',substr(port_of_call_iata_code, -3, 3),'PVG') as ORG3,
                        decode(flight_direction,'Arrival','PVG',substr(port_of_call_iata_code, 1, 3)) as DES3,
                        decode(flight_direction,'Arrival',substr(port_of_call_iata_code ,5),substr(port_of_call_iata_code ,1,length(port_of_call_iata_code) - 4)) as VIA1,
                        CHECKIN_DESK_RANGE_P as CKIF,
                        FLIGHT_SECTOR_CODE as FLTI,
                        PASSENGER_TERMINAL_CODE as TERM,
                        DIVERT_AIRPORT_IATA_CODE as DAIA,
                        CODE_SHARE_STATUS as CSS,
                        to_char(to_date(checkin_Open_Date_Time_p,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as CODT,
                        to_char(to_date(checkin_close_Date_Time_p,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as CCDT,
                        CHECKIN_DESK_RANGE_S as SCDR,
                        to_char(to_date(checkin_Open_Date_Time_s,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SCODT,
                        to_char(to_date(checkin_close_Date_Time_s,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SCCDT,
                        Master_Flight_Identity as MFDI,
                        
                        aircraft_terminal_code as ACTM,
                        airline_terminal_code as ATERM,
                        aircraft_type_icao_code as ACTP,
                        IATA_CARRIER_IATA_CODE as CIATA,
                        ICAO_CARRIER_ICAO_CODE as CICAO,
                        --checkin_close_Date_Time_p as CCDT,
                        --CHECKIN_DESK_RANGE_P as CKIF,
                       -- checkin_Open_Date_Time_p as CODT,
                        ESTIMATED_FLIGHT_DURATION as EFLDT,
                        FLIGHT_OPERATES_OVERNIGHT as FLOPON,
                        --GATE_BOARDING_STATUS_P as GBS,
                        --GATE_CLOSE_DATE_TIME_P as GCDT,
                        --GATE_OPEN_DATE_TIME_P as GODT,
                        LINKED_FLIGHT_IDENTITY as LNKFL,
                        decode(flight_direction,'Arrival',substr(port_of_call_icao_code, -4, 4),'ZSPD') as OICAO,
                        decode(flight_direction,'Arrival','ZSPD',substr(port_of_call_iata_code, 1, 4)) as DICAO,
                        NVL(public_flight_identity, FLIGHT_IDENTITY) as PFLT,
                         to_char(to_date(SCHEDULED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SDT, 
                        --to_char(UPDATE_TIME ,'yyyymmddhh24miss') as UPT, 

                        to_char(to_date(previous_station_estimated_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as EPST, 
                        to_char(to_date(previous_station_scheduled_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SPST, 
                        to_char(to_date(latest_known_date_time,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as LTA, 
                        to_char(to_date(latest_known_date_time,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as LTD, 
                        to_char(to_date(next_station_estimated_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as ENST, 
                        to_char(to_date(next_station_scheduled_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SNST, 
                        to_char(to_date(GATE_CLOSE_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as GPCT1, 
                        to_char(to_date(GATE_OPEN_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as GPOT1, 
                        to_char(to_date(previous_station_airborne_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as APST, 
                        to_char(to_date(next_station_actual_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as ANST, 
                        
                        AIRPORT_IATA_CODE as AIRPORT_IATA, 
                        flight_status_code||' '||to_char(to_date(latest_known_date_time,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as CUSTOM_STATUS 

                        from spia_fqs.FLATTER_AFDS 
                        WHERE ID = :varfqsID ";

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
                        substr(FLIGHT_DIRECTION,0,1) as DRCT,
                        FLIGHT_IDENTITY as FLT,
                        FLIGHT_STATUS_CODE as OPERATIONTYPE_CODE1,
                        to_char(to_date(SCHEDULED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as STOD,
                        flight_nature_code as TTYP, 
                        to_char(to_date(WHEELS_DOWN_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as LAND,
                        to_char(to_date(WHEELS_UP_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as AIRB,
                        AIRCRAFT_SUBTYPE_IATA_CODE as ATC5,
                        STAND_POSITION as STPO,
                        GATE_NUMBER_P as GENO,
                        to_char(to_date(ESTIMATED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as EDTA,
                        to_char(to_date(ESTIMATED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as EDTD,
                        BAGGAGE_RECLAIM_CAROUSEL_ID_P as BRC1,
                        to_char(to_date(BAGGAGE_RECKAIM_OPEN_DT_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as BROD,
                        to_char(to_date(BAGGAGE_RECLAIM_CLOSE_DT_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as BRCD,
                        BAGGAGE_RECLAIM_CAROUSEL_ID_S as SRC2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ID2
                        to_char(to_date(BAGGAGE_RECKAIM_OPEN_DT_S,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SBRO, --T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME2
                        to_char(to_date(BAGGAGE_RECLAIM_CLOSE_DT_S,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SBRC,
                        GATE_BOARDING_STATUS_P as GBS,
                        to_char(to_date(GATE_OPEN_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as GODT,
                        to_char(to_date(GATE_CLOSE_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as GCDT,
                        GATE_NUMBER_S as SGN,
                        to_char(to_date(GATE_OPEN_DATE_TIME_S,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SGOD,
                        to_char(to_date(GATE_CLOSE_DATE_TIME_S,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SGCD,
                        AIRCRAFT_REGISTRATION as REGN,
                        ID as URNO,
                        decode(flight_direction,'Arrival',substr(port_of_call_iata_code, -3, 3),'PVG') as ORG3,
                        decode(flight_direction,'Arrival','PVG',substr(port_of_call_iata_code, 1, 3)) as DES3,
                        decode(flight_direction,'Arrival',substr(port_of_call_iata_code ,5),substr(port_of_call_iata_code ,1,length(port_of_call_iata_code) - 4)) as VIA1,
                        CHECKIN_DESK_RANGE_P as CKIF,
                        FLIGHT_SECTOR_CODE as FLTI,
                        PASSENGER_TERMINAL_CODE as TERM,
                        DIVERT_AIRPORT_IATA_CODE as DAIA,
                        CODE_SHARE_STATUS as CSS,
                        to_char(to_date(checkin_Open_Date_Time_p,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as CODT,
                        to_char(to_date(checkin_close_Date_Time_p,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as CCDT,
                        CHECKIN_DESK_RANGE_S as SCDR,
                        to_char(to_date(checkin_Open_Date_Time_s,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SCODT,
                        to_char(to_date(checkin_close_Date_Time_s,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SCCDT,
                        Master_Flight_Identity as MFDI,

                        aircraft_terminal_code as ACTM,
                        airline_terminal_code as ATERM,
                        aircraft_type_icao_code as ACTP,
                        IATA_CARRIER_IATA_CODE as CIATA,
                        ICAO_CARRIER_ICAO_CODE as CICAO,
                        --checkin_close_Date_Time_p as CCDT,
                        --CHECKIN_DESK_RANGE_P as CKIF,
                       -- checkin_Open_Date_Time_p as CODT,
                        ESTIMATED_FLIGHT_DURATION as EFLDT,
                        FLIGHT_OPERATES_OVERNIGHT as FLOPON,
                        --GATE_BOARDING_STATUS_P as GBS,
                        --GATE_CLOSE_DATE_TIME_P as GCDT,
                        --GATE_OPEN_DATE_TIME_P as GODT,
                        LINKED_FLIGHT_IDENTITY as LNKFL,
                        decode(flight_direction,'Arrival',substr(port_of_call_icao_code, -4, 4),'ZSPD') as OICAO,
                        decode(flight_direction,'Arrival','ZSPD',substr(port_of_call_iata_code, 1, 4)) as DICAO,
                        NVL(public_flight_identity, FLIGHT_IDENTITY) as PFLT,
                         to_char(to_date(SCHEDULED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SDT, 
                        --to_char(UPDATE_TIME ,'yyyymmddhh24miss') as UPT, 

                        to_char(to_date(previous_station_estimated_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as EPST, 
                        to_char(to_date(previous_station_scheduled_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SPST, 
                        to_char(to_date(latest_known_date_time,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as LTA, 
                        to_char(to_date(latest_known_date_time,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as LTD, 
                        to_char(to_date(next_station_estimated_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as ENST, 
                        to_char(to_date(next_station_scheduled_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SNST, 
                        to_char(to_date(GATE_CLOSE_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as GPCT1, 
                        to_char(to_date(GATE_OPEN_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as GPOT1, 
                        to_char(to_date(previous_station_airborne_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as APST, 
                        to_char(to_date(next_station_actual_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as ANST, 
                        
                        AIRPORT_IATA_CODE as AIRPORT_IATA, 
                        flight_status_code||' '||to_char(to_date(latest_known_date_time,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as CUSTOM_STATUS 

                        from spia_fqs.FLATTER_AFDS
                        
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
                        substr(FLIGHT_DIRECTION,0,1) as DRCT,
                        FLIGHT_IDENTITY as FLT,
                        FLIGHT_STATUS_CODE as OPERATIONTYPE_CODE1,
                        to_char(to_date(SCHEDULED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as STOD,
                        flight_nature_code as TTYP, 
                        to_char(to_date(WHEELS_DOWN_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as LAND,
                        to_char(to_date(WHEELS_UP_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as AIRB,
                        AIRCRAFT_SUBTYPE_IATA_CODE as ATC5,
                        STAND_POSITION as STPO,
                        GATE_NUMBER_P as GENO,
                        to_char(to_date(ESTIMATED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as EDTA,
                        to_char(to_date(ESTIMATED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as EDTD,
                        BAGGAGE_RECLAIM_CAROUSEL_ID_P as BRC1,
                        to_char(to_date(BAGGAGE_RECKAIM_OPEN_DT_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as BROD,
                        to_char(to_date(BAGGAGE_RECLAIM_CLOSE_DT_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as BRCD,
                        BAGGAGE_RECLAIM_CAROUSEL_ID_S as SRC2, --T_FQS_AF_FL_ARRIVALS.RECLAIM_ID2
                        to_char(to_date(BAGGAGE_RECKAIM_OPEN_DT_S,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SBRO, --T_FQS_AF_FL_ARRIVALS.RECLAIM_OPEN_TIME2
                        to_char(to_date(BAGGAGE_RECLAIM_CLOSE_DT_S,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SBRC,
                        GATE_BOARDING_STATUS_P as GBS,
                        to_char(to_date(GATE_OPEN_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as GODT,
                        to_char(to_date(GATE_CLOSE_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as GCDT,
                        GATE_NUMBER_S as SGN,
                        to_char(to_date(GATE_OPEN_DATE_TIME_S,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SGOD,
                        to_char(to_date(GATE_CLOSE_DATE_TIME_S,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SGCD,
                        AIRCRAFT_REGISTRATION as REGN,
                        ID as URNO,
                        decode(flight_direction,'Arrival',substr(port_of_call_iata_code, -3, 3),'PVG') as ORG3,
                        decode(flight_direction,'Arrival','PVG',substr(port_of_call_iata_code, 1, 3)) as DES3,
                        decode(flight_direction,'Arrival',substr(port_of_call_iata_code ,5),substr(port_of_call_iata_code ,1,length(port_of_call_iata_code) - 4)) as VIA1,
                        CHECKIN_DESK_RANGE_P as CKIF,
                        FLIGHT_SECTOR_CODE as FLTI,
                        PASSENGER_TERMINAL_CODE as TERM,
                        DIVERT_AIRPORT_IATA_CODE as DAIA,
                        CODE_SHARE_STATUS as CSS,
                        to_char(to_date(checkin_Open_Date_Time_p,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as CODT,
                        to_char(to_date(checkin_close_Date_Time_p,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as CCDT,
                        CHECKIN_DESK_RANGE_S as SCDR,
                        to_char(to_date(checkin_Open_Date_Time_s,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SCODT,
                        to_char(to_date(checkin_close_Date_Time_s,'yyyy-mm-dd,hh24:mi:ss'),'yyyymmddhh24miss') as SCCDT,
                        Master_Flight_Identity as MFDI,

                        aircraft_terminal_code as ACTM,
                        airline_terminal_code as ATERM,
                        aircraft_type_icao_code as ACTP,
                        IATA_CARRIER_IATA_CODE as CIATA,
                        ICAO_CARRIER_ICAO_CODE as CICAO,
                        --checkin_close_Date_Time_p as CCDT,
                        --CHECKIN_DESK_RANGE_P as CKIF,
                       -- checkin_Open_Date_Time_p as CODT,
                        ESTIMATED_FLIGHT_DURATION as EFLDT,
                        FLIGHT_OPERATES_OVERNIGHT as FLOPON,
                        --GATE_BOARDING_STATUS_P as GBS,
                        --GATE_CLOSE_DATE_TIME_P as GCDT,
                        --GATE_OPEN_DATE_TIME_P as GODT,
                        LINKED_FLIGHT_IDENTITY as LNKFL,
                        decode(flight_direction,'Arrival',substr(port_of_call_icao_code, -4, 4),'ZSPD') as OICAO,
                        decode(flight_direction,'Arrival','ZSPD',substr(port_of_call_iata_code, 1, 4)) as DICAO,
                        NVL(public_flight_identity, FLIGHT_IDENTITY) as PFLT,
                        --scheduled_date_time as SDT
                         to_char(to_date(SCHEDULED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SDT, 
                        --to_char(UPDATE_TIME ,'yyyymmddhh24miss') as UPT, 

                        to_char(to_date(previous_station_estimated_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as EPST, 
                        to_char(to_date(previous_station_scheduled_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SPST, 
                        to_char(to_date(latest_known_date_time,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as LTA, 
                        to_char(to_date(latest_known_date_time,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as LTD, 
                        to_char(to_date(next_station_estimated_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as ENST, 
                        to_char(to_date(next_station_scheduled_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as SNST, 
                        to_char(to_date(GATE_CLOSE_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as GPCT1, 
                        to_char(to_date(GATE_OPEN_DATE_TIME_P,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as GPOT1, 
                        to_char(to_date(previous_station_airborne_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as APST, 
                        to_char(to_date(next_station_actual_dt,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as ANST, 
                        
                        AIRPORT_IATA_CODE as AIRPORT_IATA, 
                        flight_status_code||' '||to_char(to_date(latest_known_date_time,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') as CUSTOM_STATUS 

                        from spia_fqs.FLATTER_AFDS 
                        WHERE 
                         (to_char(to_date(SCHEDULED_DATE_TIME,'yyyy-mm-dd,hh24:mi:ss'), 'yyyymmddhh24miss') BETWEEN  :varSCHEDULEDDATETIMEBEFORE3 AND :varSCHEDULEDDATETIMEAFTER3) 
                         and SCHEDULED_DATE_TIME is not null
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
            OracleParameter[] para = new OracleParameter[2];
            // para[0] = new OracleParameter("varSCHEDULEDDATETIMEBEFORE1", dateTimeStart.ToString("yyyyMMddHHmmss"));
            //para[1] = new OracleParameter("varSCHEDULEDDATETIMEAFTER1", dateTimeEnd.ToString("yyyyMMddHHmmss"));
            para[0] = new OracleParameter("varSCHEDULEDDATETIMEBEFORE3", dateTimeStart.ToString("yyyyMMddHHmmss"));
            para[1] = new OracleParameter("varSCHEDULEDDATETIMEAFTER3", dateTimeEnd.ToString("yyyyMMddHHmmss"));

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
