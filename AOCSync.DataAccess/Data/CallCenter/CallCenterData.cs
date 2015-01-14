using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

using Microsoft.ApplicationBlocks.Data;

namespace AOCSync.DataAccess
{
    public class CallCenterData
    {
        public static DataRow GetCallCenterDataByID(string ccID)
        {
            //            string sql = @"SELECT BASE.FLIGHTDATAID,
            //                                    BASE.SCHEDULEDDATETIME,
            //                                    BASE.FLIGHTNATURECODE,
            //                                    BASE.PORTOFCALLIATACODE,
            //                                    BASE.WHEELSUPDOWNDATETIME,
            //                                    BASE.FLIGHTSECTORCODE,
            //                                    BASE.DIVERTAIRPORTIATACODE,
            //                                    BASE.CODESHARESTATUS,
            //                                    BASE.ESTIMATEDDATETIME,
            //                                    BASE.FLIGHTIDENTITY,
            //                                    BASE.AIRPORTIATACODE,
            //                                    BASE.FLIGHTDIRECTION,
            //                                    BASE.OPERATIONTYPECODE,
            //                                    BASE.MASTERFLIGHTDATAID,
            //                                    ATTACH.AIRCRAFTSUBTYPEIATACODE,
            //                                    ATTACH.CHECKINDESKRANGE,
            //                                    ATTACH.PASSENGERTERMINALCODE,
            //                                    ATTACH.STANDPOSITION,
            //                                    ATTACH.GATENUMBER,
            //                                    ATTACH.CHECKINOPENDATETIME,
            //                                    ATTACH.CHECKINCLOSEDDATETIME,
            //                                    ATTACH.SDCHECKINDESKRANGE,
            //                                    ATTACH.SDCHECKINOPENDATETIME,
            //                                    ATTACH.SDCHECKINCLOSEDDATETIME,
            //                                    ATTACH.BAGGAGERECLAIMCAROUSELID,
            //                                    ATTACH.BAGGAGERECLAIMOPENDATETIME,
            //                                    ATTACH.BAGGAGERECLAIMCLOSEDDATETIME,
            //                                    ATTACH.SDBAGRECLAIMCAROUSELID,
            //                                    ATTACH.SDBAGRECLAIMOPENDATETIME,
            //                                    ATTACH.SDBAGRECLAIMCLOSEDDATETIME,
            //                                    ATTACH.GATEBOARDINGSTATUS,
            //                                    ATTACH.GATEOPENDATETIME,
            //                                    ATTACH.GATECLOSEDDATETIME,
            //                                    ATTACH.SDGATENUMBER,
            //                                    ATTACH.SDGATEOPENDATETIME,
            //                                    ATTACH.SDGATECLOSEDDATETIME
            //                               FROM T_FQ_FLIGHTBASEDATA BASE
            //                               LEFT JOIN T_FQ_FLIGHTATTACHDATA ATTACH ON BASE.FLIGHTDATAID =
            //                                                                         ATTACH.FLIGHTDATAID
            //                              WHERE BASE.FLIGHTDATAID = :varccID";
                            string sql = @"SELECT BASE.FlightDataId,
                                                    BASE.FlightIdentity,
                                                    BASE.CarrierIATACode,
                                                    BASE.FlightNumber,
                                                    BASE.FlightSuffix,
                                                    BASE.FlightDirection,
                                                    BASE.FlightRepeatCount,
                                                    BASE.CarrierICAOCode,
                                                    BASE.AirportIATACode,
                                                    BASE.CodeShareStatus,
                                                    BASE.FlightCancelCode,
                                                    BASE.DivertAirportIATACode,
                                                    BASE.FlightNatureCode,
                                                    BASE.FlightServiceTypeIATACode,
                                                    BASE.FlightStatusCode,
                                                    BASE.FlightSectorCode,
                                                    BASE.IsReturnFlight,
                                                    BASE.IsGeneralAviationFlight,
                                                    BASE.FlightTransitCode,
                                                    BASE.NewFlightReason,
                                                    BASE.OperationTypeCode,
                                                    BASE.TransferFlightIdentity,
                                                    BASE.EstimatedDateTime,
                                                    BASE.ScheduledDateTime,
                                                    BASE.WheelsUpDownDateTime,
                                                    BASE.PortOfCallIATACode,
                                                    BASE.FlightFlag,
                                                    BASE.MasterFlightDataId,
                                                    ATTACH.OccurDateTime,
                                                    ATTACH.AirportIATACode,
                                                    ATTACH.ScheduledDate,
                                                    ATTACH.AircraftTerminalCode,
                                                    ATTACH.PassengerTerminalCode,
                                                    ATTACH.StandPosition,
                                                    ATTACH.BaggageReclaimCarouselID,
                                                    ATTACH.BaggageReclaimcarouselRole,
                                                    ATTACH.BaggageReclaimOpenDateTime,
                                                    ATTACH.BaggageReclaimClosedDatetime,
                                                    ATTACH.SdBagReclaimCarouselID,
                                                    ATTACH.SdBagReclaimcarouselRole,
                                                    ATTACH.SdBagReclaimOpenDateTime,
                                                    ATTACH.SdBagReclaimClosedDatetime,
                                                    ATTACH.SdFirstBagDateTime,
                                                    ATTACH.SdLastBagDateTime,
                                                    ATTACH.CheckinDeskRange,
                                                    ATTACH.CheckinOpenDateTime,
                                                    ATTACH.CheckinClosedDateTime,
                                                    ATTACH.SdCheckinDeskRange,
                                                    ATTACH.SdCheckinOpenDateTime,
                                                    ATTACH.SdCheckinClosedDateTime,
                                                    ATTACH.GateNumber,
                                                    ATTACH.GateBoardingStatus,
                                                    ATTACH.GateOpenDateTime,
                                                    ATTACH.GateClosedDateTime,
                                                    ATTACH.SdGateNumber,
                                                    ATTACH.SdGateOpenDateTime,
                                                    ATTACH.SdGateClosedDateTime,
                                                    ATTACH.SupplementaryInformation,
                                                    ATTACH.SupplementaryInformationText,
                                                    ATTACH.ActualOffBlocksDateTime,
                                                    ATTACH.ActualOnBlocksDateTime,
                                                    ATTACH.EstimatedFlightDuration,
                                                    ATTACH.NextStationActualDateTime,
                                                    ATTACH.NextStationEstimatedDateTime,
                                                    ATTACH.NextStationScheduledDateTime,
                                                    ATTACH.PreviousAirborneDateTime,
                                                    ATTACH.PreviousEstimatedDateTime,
                                                    ATTACH.PreviousScheduledDateTime,
                                                    ATTACH.FirstBagDateTime,
                                                    ATTACH.LastBagDateTime,
                                                    ATTACH.LatestKnownDateTime,
                                                    ATTACH.LatestKnownDateTimeSource,
                                                    ATTACH.AircraftSubtypeIATACode
                                                    FROM T_FQ_FLIGHTBASEDATA BASE
                               LEFT JOIN T_FQ_FLIGHTATTACHDATA ATTACH ON BASE.FLIGHTDATAID =
                                                                         ATTACH.FLIGHTDATAID
                              WHERE BASE.FLIGHTDATAID = :varccID";
            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("varccID", ccID);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.getStrConnectionCallCenter(), sql, para);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0];
            }
        }

        public static DataTable GetCallCenterDatas()
        {
//            string sql = @"SELECT BASE.FLIGHTDATAID,
//                                    BASE.SCHEDULEDDATETIME,
//                                    BASE.FLIGHTNATURECODE,
//                                    BASE.PORTOFCALLIATACODE,
//                                    BASE.WHEELSUPDOWNDATETIME,
//                                    BASE.FLIGHTSECTORCODE,
//                                    BASE.DIVERTAIRPORTIATACODE,
//                                    BASE.CODESHARESTATUS,
//                                    BASE.ESTIMATEDDATETIME,
//                                    BASE.FLIGHTIDENTITY,
//                                    BASE.AIRPORTIATACODE,
//                                    BASE.FLIGHTDIRECTION,
//                                    BASE.OPERATIONTYPECODE,
//                                    BASE.MASTERFLIGHTDATAID,
//                                    ATTACH.AIRCRAFTSUBTYPEIATACODE,
//                                    ATTACH.CHECKINDESKRANGE,
//                                    ATTACH.PASSENGERTERMINALCODE,
//                                    ATTACH.STANDPOSITION,
//                                    ATTACH.GATENUMBER,
//                                    ATTACH.CHECKINOPENDATETIME,
//                                    ATTACH.CHECKINCLOSEDDATETIME,
//                                    ATTACH.SDCHECKINDESKRANGE,
//                                    ATTACH.SDCHECKINOPENDATETIME,
//                                    ATTACH.SDCHECKINCLOSEDDATETIME,
//                                    ATTACH.BAGGAGERECLAIMCAROUSELID,
//                                    ATTACH.BAGGAGERECLAIMOPENDATETIME,
//                                    ATTACH.BAGGAGERECLAIMCLOSEDDATETIME,
//                                    ATTACH.SDBAGRECLAIMCAROUSELID,
//                                    ATTACH.SDBAGRECLAIMOPENDATETIME,
//                                    ATTACH.SDBAGRECLAIMCLOSEDDATETIME,
//                                    ATTACH.GATEBOARDINGSTATUS,
//                                    ATTACH.GATEOPENDATETIME,
//                                    ATTACH.GATECLOSEDDATETIME,
//                                    ATTACH.SDGATENUMBER,
//                                    ATTACH.SDGATEOPENDATETIME,
//                                    ATTACH.SDGATECLOSEDDATETIME
//                               FROM T_FQ_FLIGHTBASEDATA BASE
//                               LEFT JOIN T_FQ_FLIGHTATTACHDATA ATTACH ON BASE.FLIGHTDATAID =
//                                                                         ATTACH.FLIGHTDATAID
//                            ";
            string sql = @"SELECT BASE.FlightDataId,
                                    BASE.FlightIdentity,
                                    BASE.CarrierIATACode,
                                    BASE.FlightNumber,
                                    BASE.FlightSuffix,
                                    BASE.FlightDirection,
                                    BASE.FlightRepeatCount,
                                    BASE.CarrierICAOCode,
                                    BASE.AirportIATACode,
                                    BASE.CodeShareStatus,
                                    BASE.FlightCancelCode,
                                    BASE.DivertAirportIATACode,
                                    BASE.FlightNatureCode,
                                    BASE.FlightServiceTypeIATACode,
                                    BASE.FlightStatusCode,
                                    BASE.FlightSectorCode,
                                    BASE.IsReturnFlight,
                                    BASE.IsGeneralAviationFlight,
                                    BASE.FlightTransitCode,
                                    BASE.NewFlightReason,
                                    BASE.OperationTypeCode,
                                    BASE.TransferFlightIdentity,
                                    BASE.EstimatedDateTime,
                                    BASE.ScheduledDateTime,
                                    BASE.WheelsUpDownDateTime,
                                    BASE.PortOfCallIATACode,
                                    BASE.FlightFlag,
                                    BASE.MasterFlightDataId,
                                    ATTACH.OccurDateTime,
                                    ATTACH.AirportIATACode,
                                    ATTACH.ScheduledDate,
                                    ATTACH.AircraftTerminalCode,
                                    ATTACH.PassengerTerminalCode,
                                    ATTACH.StandPosition,
                                    ATTACH.BaggageReclaimCarouselID,
                                    ATTACH.BaggageReclaimcarouselRole,
                                    ATTACH.BaggageReclaimOpenDateTime,
                                    ATTACH.BaggageReclaimClosedDatetime,
                                    ATTACH.SdBagReclaimCarouselID,
                                    ATTACH.SdBagReclaimcarouselRole,
                                    ATTACH.SdBagReclaimOpenDateTime,
                                    ATTACH.SdBagReclaimClosedDatetime,
                                    ATTACH.SdFirstBagDateTime,
                                    ATTACH.SdLastBagDateTime,
                                    ATTACH.CheckinDeskRange,
                                    ATTACH.CheckinOpenDateTime,
                                    ATTACH.CheckinClosedDateTime,
                                    ATTACH.SdCheckinDeskRange,
                                    ATTACH.SdCheckinOpenDateTime,
                                    ATTACH.SdCheckinClosedDateTime,
                                    ATTACH.GateNumber,
                                    ATTACH.GateBoardingStatus,
                                    ATTACH.GateOpenDateTime,
                                    ATTACH.GateClosedDateTime,
                                    ATTACH.SdGateNumber,
                                    ATTACH.SdGateOpenDateTime,
                                    ATTACH.SdGateClosedDateTime,
                                    ATTACH.SupplementaryInformation,
                                    ATTACH.SupplementaryInformationText,
                                    ATTACH.ActualOffBlocksDateTime,
                                    ATTACH.ActualOnBlocksDateTime,
                                    ATTACH.EstimatedFlightDuration,
                                    ATTACH.NextStationActualDateTime,
                                    ATTACH.NextStationEstimatedDateTime,
                                    ATTACH.NextStationScheduledDateTime,
                                    ATTACH.PreviousAirborneDateTime,
                                    ATTACH.PreviousEstimatedDateTime,
                                    ATTACH.PreviousScheduledDateTime,
                                    ATTACH.FirstBagDateTime,
                                    ATTACH.LastBagDateTime,
                                    ATTACH.LatestKnownDateTime,
                                    ATTACH.LatestKnownDateTimeSource,
                                    ATTACH.AircraftSubtypeIATACode
                               FROM T_FQ_FLIGHTBASEDATA BASE
                               LEFT JOIN T_FQ_FLIGHTATTACHDATA ATTACH ON BASE.FLIGHTDATAID =
                                                                         ATTACH.FLIGHTDATAID
                            ";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.getStrConnectionCallCenter(), sql);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }

        public static DataTable GetCallCenterDatasByDateDiff(DateTime dateTimeStart, DateTime dateTimeEnd)
        {
//            string sql = @"SELECT BASE.FLIGHTDATAID,
//                                    BASE.SCHEDULEDDATETIME,
//                                    BASE.FLIGHTNATURECODE,
//                                    BASE.PORTOFCALLIATACODE,
//                                    BASE.WHEELSUPDOWNDATETIME,
//                                    BASE.FLIGHTSECTORCODE,
//                                    BASE.DIVERTAIRPORTIATACODE,
//                                    BASE.CODESHARESTATUS,
//                                    BASE.ESTIMATEDDATETIME,
//                                    BASE.FLIGHTIDENTITY,
//                                    BASE.AIRPORTIATACODE,
//                                    BASE.FLIGHTDIRECTION,
//                                    BASE.OPERATIONTYPECODE,
//                                    BASE.MASTERFLIGHTDATAID,
//                                    ATTACH.AIRCRAFTSUBTYPEIATACODE,
//                                    ATTACH.CHECKINDESKRANGE,
//                                    ATTACH.PASSENGERTERMINALCODE,
//                                    ATTACH.STANDPOSITION,
//                                    ATTACH.GATENUMBER,
//                                    ATTACH.CHECKINOPENDATETIME,
//                                    ATTACH.CHECKINCLOSEDDATETIME,
//                                    ATTACH.SDCHECKINDESKRANGE,
//                                    ATTACH.SDCHECKINOPENDATETIME,
//                                    ATTACH.SDCHECKINCLOSEDDATETIME,
//                                    ATTACH.BAGGAGERECLAIMCAROUSELID,
//                                    ATTACH.BAGGAGERECLAIMOPENDATETIME,
//                                    ATTACH.BAGGAGERECLAIMCLOSEDDATETIME,
//                                    ATTACH.SDBAGRECLAIMCAROUSELID,
//                                    ATTACH.SDBAGRECLAIMOPENDATETIME,
//                                    ATTACH.SDBAGRECLAIMCLOSEDDATETIME,
//                                    ATTACH.GATEBOARDINGSTATUS,
//                                    ATTACH.GATEOPENDATETIME,
//                                    ATTACH.GATECLOSEDDATETIME,
//                                    ATTACH.SDGATENUMBER,
//                                    ATTACH.SDGATEOPENDATETIME,
//                                    ATTACH.SDGATECLOSEDDATETIME
//                               FROM T_FQ_FLIGHTBASEDATA BASE
//                               LEFT JOIN T_FQ_FLIGHTATTACHDATA ATTACH ON BASE.FLIGHTDATAID =
//                                                                         ATTACH.FLIGHTDATAID
//                              WHERE (BASE.SCHEDULEDDATETIME BETWEEN :varSCHEDULEDDATETIMEBEFORE AND :varSCHEDULEDDATETIMEAFTER)
//                            ";
            string sql = @"SELECT BASE.FlightDataId,
                                    BASE.FlightIdentity,
                                    BASE.CarrierIATACode,
                                    BASE.FlightNumber,
                                    BASE.FlightSuffix,
                                    BASE.FlightDirection,
                                    BASE.FlightRepeatCount,
                                    BASE.CarrierICAOCode,
                                    BASE.AirportIATACode,
                                    BASE.CodeShareStatus,
                                    BASE.FlightCancelCode,
                                    BASE.DivertAirportIATACode,
                                    BASE.FlightNatureCode,
                                    BASE.FlightServiceTypeIATACode,
                                    BASE.FlightStatusCode,
                                    BASE.FlightSectorCode,
                                    BASE.IsReturnFlight,
                                    BASE.IsGeneralAviationFlight,
                                    BASE.FlightTransitCode,
                                    BASE.NewFlightReason,
                                    BASE.OperationTypeCode,
                                    BASE.TransferFlightIdentity,
                                    BASE.EstimatedDateTime,
                                    BASE.ScheduledDateTime,
                                    BASE.WheelsUpDownDateTime,
                                    BASE.PortOfCallIATACode,
                                    BASE.FlightFlag,
                                    BASE.MasterFlightDataId,
                                    ATTACH.OccurDateTime,
                                    ATTACH.AirportIATACode,
                                    ATTACH.ScheduledDate,
                                    ATTACH.AircraftTerminalCode,
                                    ATTACH.PassengerTerminalCode,
                                    ATTACH.StandPosition,
                                    ATTACH.BaggageReclaimCarouselID,
                                    ATTACH.BaggageReclaimcarouselRole,
                                    ATTACH.BaggageReclaimOpenDateTime,
                                    ATTACH.BaggageReclaimClosedDatetime,
                                    ATTACH.SdBagReclaimCarouselID,
                                    ATTACH.SdBagReclaimcarouselRole,
                                    ATTACH.SdBagReclaimOpenDateTime,
                                    ATTACH.SdBagReclaimClosedDatetime,
                                    ATTACH.SdFirstBagDateTime,
                                    ATTACH.SdLastBagDateTime,
                                    ATTACH.CheckinDeskRange,
                                    ATTACH.CheckinOpenDateTime,
                                    ATTACH.CheckinClosedDateTime,
                                    ATTACH.SdCheckinDeskRange,
                                    ATTACH.SdCheckinOpenDateTime,
                                    ATTACH.SdCheckinClosedDateTime,
                                    ATTACH.GateNumber,
                                    ATTACH.GateBoardingStatus,
                                    ATTACH.GateOpenDateTime,
                                    ATTACH.GateClosedDateTime,
                                    ATTACH.SdGateNumber,
                                    ATTACH.SdGateOpenDateTime,
                                    ATTACH.SdGateClosedDateTime,
                                    ATTACH.SupplementaryInformation,
                                    ATTACH.SupplementaryInformationText,
                                    ATTACH.ActualOffBlocksDateTime,
                                    ATTACH.ActualOnBlocksDateTime,
                                    ATTACH.EstimatedFlightDuration,
                                    ATTACH.NextStationActualDateTime,
                                    ATTACH.NextStationEstimatedDateTime,
                                    ATTACH.NextStationScheduledDateTime,
                                    ATTACH.PreviousAirborneDateTime,
                                    ATTACH.PreviousEstimatedDateTime,
                                    ATTACH.PreviousScheduledDateTime,
                                    ATTACH.FirstBagDateTime,
                                    ATTACH.LastBagDateTime,
                                    ATTACH.LatestKnownDateTime,
                                    ATTACH.LatestKnownDateTimeSource,
                                    ATTACH.AircraftSubtypeIATACode
                               FROM T_FQ_FLIGHTBASEDATA BASE
                               LEFT JOIN T_FQ_FLIGHTATTACHDATA ATTACH ON BASE.FLIGHTDATAID =
                                                                         ATTACH.FLIGHTDATAID
                              WHERE (BASE.SCHEDULEDDATETIME BETWEEN :varSCHEDULEDDATETIMEBEFORE AND :varSCHEDULEDDATETIMEAFTER)
                            ";

            OracleParameter[] para = new OracleParameter[2];
            para[0] = new OracleParameter("varSCHEDULEDDATETIMEBEFORE", dateTimeStart.ToString("yyyyMMddHHmmss"));
            para[1] = new OracleParameter("varSCHEDULEDDATETIMEAFTER", dateTimeEnd.ToString("yyyyMMddHHmmss"));

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.getStrConnectionCallCenter(), sql, para);

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
