using System;
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

namespace AOCSync.DataAccess
{
    public class AOCDataCCHIS
    {
        public static void InsertAOCDataCCHIS(
                string id, string stod, string ttyp, string urno, string org3,
                string des3, string land, string airb, string atc5, string via1,
                string jfno, string ckif, string flti, string term, string stpo,
                string geno, string daia, string css, string edta, string edtd,
                string sp, string cdr, string codt, string ccdt, string scdr,
                string scodt, string sccdt, string brc1, string brod, string brcd,
                string src2, string sbro, string sbrc, string gn, string gbs,
                string godt, string gcdt, string sgn, string sgod, string mfdi,
                string pocc, string sgcd, string asia, string APTIATA, string regn,
                string drct, string usec, string typc, DateTime cdat, string useu,
                string typu, DateTime lstu, string remp, string flno,
               string actualoffblocksdatetime
             , string actualonblocksdatetime
             , string aircraftterminalcode
             , string baggagereclaimcarouselrole
             , string estimatedflightduration
             , string firstbagdatetime
             , string lastbagdatetime
             , string latestknowndatetime
             , string latestknowndatetimesource
             , string nextstationactualdatetime
             , string nextstationestimateddatetime
             , string nextstationscheduleddatetime
             , string occurdatetime
             , string previousairbornedatetime
             , string previousestimateddatetime
             , string previousscheduleddatetime
             , string scheduleddate
             , string sdbagreclaimcarouselrole
             , string sdfirstbagdatetime
             , string sdlastbagdatetime
             , string supplementaryinformation
             , string supplementaryinformationtext
             , string carrieriatacode
             , string carriericaocode
             , string flightcancelcode
             , string flightflag
             , string flightnumber
             , string flightrepeatcount
             , string flightservicetypeiatacode
             , string flightstatuscode
             , string flightsuffix
             , string flighttransitcode
             , string isgeneralaviationflight
             , string isreturnflight
             , string newflightreason
             , string transferflightidentity
             , SqlTransaction trans
            )
        {
            string sql = @"INSERT INTO [AOCHIS] (
                                    ID,     URNO,   STOD,   TTYP,       ORG3, 
                                    DES3,   LAND,   AIRB,   ATC5,       VIA1, 
                                    JFNO,   CKIF,   FLTI,   TERM,       STPO, 
                                    GENO,   DAIA,   CSS,    EDTA,       EDTD, 
                                    SP,     CDR,    CODT,   CCDT,       SCDR, 
                                    SCODT,  SCCDT,  BRC1,   BROD,       BRCD,
                                    SRC2,   SBRO,   SBRC,   GN,         GBS, 
                                    GODT,   GCDT,   SGN,    SGOD,       MFDI, 
                                    POCC,   SGCD,   ASIA,   APTIATA,    REGN, 
                                    DRCT,   USEC,   TYPC,   CDAT,       USEU,
                                    TYPU,   LSTU,   REMP,   FLNO
                                    ,ACTUALOFFBLOCKSDATETIME              
                                    ,ACTUALONBLOCKSDATETIME               
                                    ,AIRCRAFTTERMINALCODE                 
                                    ,BAGGAGERECLAIMCAROUSELROLE           
                                    ,ESTIMATEDFLIGHTDURATION              
                                    ,FIRSTBAGDATETIME                     
                                    ,LASTBAGDATETIME                      
                                    ,LATESTKNOWNDATETIME                  
                                    ,LATESTKNOWNDATETIMESOURCE            
                                    ,NEXTSTATIONACTUALDATETIME            
                                    ,NEXTSTATIONESTIMATEDDATETIME         
                                    ,NEXTSTATIONSCHEDULEDDATETIME         
                                    ,OCCURDATETIME                        
                                    ,PREVIOUSAIRBORNEDATETIME             
                                    ,PREVIOUSESTIMATEDDATETIME            
                                    ,PREVIOUSSCHEDULEDDATETIME            
                                    ,SCHEDULEDDATE                        
                                    ,SDBAGRECLAIMCAROUSELROLE             
                                    ,SDFIRSTBAGDATETIME                   
                                    ,SDLASTBAGDATETIME                    
                                    ,SUPPLEMENTARYINFORMATION             
                                    ,SUPPLEMENTARYINFORMATIONTEXT         
                                    ,CARRIERIATACODE                      
                                    ,CARRIERICAOCODE                      
                                    ,FLIGHTCANCELCODE                     
                                    ,FLIGHTFLAG                           
                                    ,FLIGHTNUMBER                         
                                    ,FLIGHTREPEATCOUNT                    
                                    ,FLIGHTSERVICETYPEIATACODE            
                                    ,FLIGHTSTATUSCODE                     
                                    ,FLIGHTSUFFIX                         
                                    ,FLIGHTTRANSITCODE                    
                                    ,ISGENERALAVIATIONFLIGHT              
                                    ,ISRETURNFLIGHT                       
                                    ,NEWFLIGHTREASON                      
                                    ,TRANSFERFLIGHTIDENTITY               ) 
                               VALUES (
                                    @ID,    @URNO,  @STOD,  @TTYP,      @ORG3,  
                                    @DES3,  @LAND,  @AIRB,  @ATC5,      @VIA1,  
                                    @JFNO,  @CKIF,  @FLTI,  @TERM,      @STPO, 
                                    @GENO,  @DAIA,  @CSS,   @EDTA,      @EDTD, 
                                    @SP,    @CDR,   @CODT,  @CCDT,      @SCDR,  
                                    @SCODT, @SCCDT, @BRC1,  @BROD,      @BRCD, 
                                    @SRC2,  @SBRO,  @SBRC,  @GN,        @GBS,  
                                    @GODT,  @GCDT,  @SGN,   @SGOD,      @MFDI,  
                                    @POCC,  @SGCD,  @ASIA,  @APTIATA,   @REGN,  
                                    @DRCT,  @USEC,  @TYPC,  @CDAT,      @USEU,
                                    @TYPU,  @LSTU, @REMP,  @FLNO
                                            ,@ACTUALOFFBLOCKSDATETIME               
                                    ,@ACTUALONBLOCKSDATETIME                
                                    ,@AIRCRAFTTERMINALCODE                  
                                    ,@BAGGAGERECLAIMCAROUSELROLE            
                                    ,@ESTIMATEDFLIGHTDURATION               
                                    ,@FIRSTBAGDATETIME                      
                                    ,@LASTBAGDATETIME                       
                                    ,@LATESTKNOWNDATETIME                   
                                    ,@LATESTKNOWNDATETIMESOURCE             
                                    ,@NEXTSTATIONACTUALDATETIME             
                                    ,@NEXTSTATIONESTIMATEDDATETIME          
                                    ,@NEXTSTATIONSCHEDULEDDATETIME          
                                    ,@OCCURDATETIME                         
                                    ,@PREVIOUSAIRBORNEDATETIME              
                                    ,@PREVIOUSESTIMATEDDATETIME             
                                    ,@PREVIOUSSCHEDULEDDATETIME             
                                    ,@SCHEDULEDDATE                         
                                    ,@SDBAGRECLAIMCAROUSELROLE              
                                    ,@SDFIRSTBAGDATETIME                    
                                    ,@SDLASTBAGDATETIME                     
                                    ,@SUPPLEMENTARYINFORMATION              
                                    ,@SUPPLEMENTARYINFORMATIONTEXT          
                                    ,@CARRIERIATACODE                       
                                    ,@CARRIERICAOCODE                       
                                    ,@FLIGHTCANCELCODE                      
                                    ,@FLIGHTFLAG                            
                                    ,@FLIGHTNUMBER                          
                                    ,@FLIGHTREPEATCOUNT                     
                                    ,@FLIGHTSERVICETYPEIATACODE             
                                    ,@FLIGHTSTATUSCODE                      
                                    ,@FLIGHTSUFFIX                          
                                    ,@FLIGHTTRANSITCODE                     
                                    ,@ISGENERALAVIATIONFLIGHT               
                                    ,@ISRETURNFLIGHT                        
                                    ,@NEWFLIGHTREASON                       
                                    ,@TRANSFERFLIGHTIDENTITY                
                                     )";

            SqlParameter[] para = new SqlParameter[103];
            para[0] = new SqlParameter("@ID", id);
            para[1] = new SqlParameter("@URNO", urno);
            para[2] = new SqlParameter("@STOD", stod);
            para[3] = new SqlParameter("@TTYP", ttyp);
            para[4] = new SqlParameter("@ORG3", org3);
            para[5] = new SqlParameter("@DES3", des3);
            para[6] = new SqlParameter("@LAND", land);
            para[7] = new SqlParameter("@AIRB", airb);
            para[8] = new SqlParameter("@ATC5", atc5);
            para[9] = new SqlParameter("@VIA1", via1);
            para[10] = new SqlParameter("@JFNO", jfno);
            para[11] = new SqlParameter("@CKIF", ckif);
            para[12] = new SqlParameter("@FLTI", flti);
            para[13] = new SqlParameter("@TERM", term);
            para[14] = new SqlParameter("@STPO", stpo);
            para[15] = new SqlParameter("@GENO", geno);
            para[16] = new SqlParameter("@DAIA", daia);
            para[17] = new SqlParameter("@CSS", css);
            para[18] = new SqlParameter("@EDTA", edta);
            para[19] = new SqlParameter("@EDTD", edtd);
            para[20] = new SqlParameter("@SP", sp);
            para[21] = new SqlParameter("@CDR", cdr);
            para[22] = new SqlParameter("@CODT", codt);
            para[23] = new SqlParameter("@CCDT", ccdt);
            para[24] = new SqlParameter("@SCDR", scdr);
            para[25] = new SqlParameter("@SCODT", scodt);
            para[26] = new SqlParameter("@SCCDT", sccdt);
            para[27] = new SqlParameter("@BRC1", brc1);
            para[28] = new SqlParameter("@BROD", brod);
            para[29] = new SqlParameter("@BRCD", brcd);
            para[30] = new SqlParameter("@SRC2", src2);
            para[31] = new SqlParameter("@SBRO", sbro);
            para[32] = new SqlParameter("@SBRC", sbrc);
            para[33] = new SqlParameter("@GN", gn);
            para[34] = new SqlParameter("@GBS", gbs);
            para[35] = new SqlParameter("@GODT", godt);
            para[36] = new SqlParameter("@GCDT", gcdt);
            para[37] = new SqlParameter("@SGN", sgn);
            para[38] = new SqlParameter("@SGOD", sgod);
            para[39] = new SqlParameter("@MFDI", mfdi);
            para[40] = new SqlParameter("@POCC", pocc);
            para[41] = new SqlParameter("@SGCD", sgcd);
            para[42] = new SqlParameter("@ASIA", asia);
            para[43] = new SqlParameter("@APTIATA", APTIATA);
            para[44] = new SqlParameter("@REGN", regn);
            para[45] = new SqlParameter("@DRCT", drct);
            para[46] = new SqlParameter("@USEC", usec);
            para[47] = new SqlParameter("@TYPC", typc);
            para[48] = new SqlParameter("@CDAT", cdat);
            para[49] = new SqlParameter("@USEU", useu);
            para[50] = new SqlParameter("@TYPU", typu);
            para[51] = new SqlParameter("@LSTU", lstu);
            para[52] = new SqlParameter("@REMP", remp);
            para[53] = new SqlParameter("@FLNO", flno);
            para[55] = new SqlParameter("@ACTUALOFFBLOCKSDATETIME", actualoffblocksdatetime);
            para[56] = new SqlParameter("@ACTUALONBLOCKSDATETIME", actualonblocksdatetime);
            para[57] = new SqlParameter("@AIRCRAFTTERMINALCODE", aircraftterminalcode);
            para[59] = new SqlParameter("@BAGGAGERECLAIMCAROUSELROLE", baggagereclaimcarouselrole);
            para[71] = new SqlParameter("@ESTIMATEDFLIGHTDURATION", estimatedflightduration);
            para[72] = new SqlParameter("@FIRSTBAGDATETIME", firstbagdatetime);
            para[73] = new SqlParameter("@LASTBAGDATETIME", lastbagdatetime);
            para[74] = new SqlParameter("@LATESTKNOWNDATETIME", latestknowndatetime);
            para[75] = new SqlParameter("@LATESTKNOWNDATETIMESOURCE", latestknowndatetimesource);
            para[76] = new SqlParameter("@NEXTSTATIONACTUALDATETIME", nextstationactualdatetime);
            para[77] = new SqlParameter("@NEXTSTATIONESTIMATEDDATETIME", nextstationestimateddatetime);
            para[78] = new SqlParameter("@NEXTSTATIONSCHEDULEDDATETIME", nextstationscheduleddatetime);
            para[79] = new SqlParameter("@OCCURDATETIME", occurdatetime);
            para[80] = new SqlParameter("@PREVIOUSAIRBORNEDATETIME", previousairbornedatetime);
            para[81] = new SqlParameter("@PREVIOUSESTIMATEDDATETIME", previousestimateddatetime);
            para[82] = new SqlParameter("@PREVIOUSSCHEDULEDDATETIME", previousscheduleddatetime);
            para[83] = new SqlParameter("@SCHEDULEDDATE", scheduleddate);
            para[84] = new SqlParameter("@SDBAGRECLAIMCAROUSELROLE", sdbagreclaimcarouselrole);
            para[85] = new SqlParameter("@SDFIRSTBAGDATETIME", sdfirstbagdatetime);
            para[86] = new SqlParameter("@SDLASTBAGDATETIME", sdlastbagdatetime);
            para[87] = new SqlParameter("@SUPPLEMENTARYINFORMATION", supplementaryinformation);
            para[88] = new SqlParameter("@SUPPLEMENTARYINFORMATIONTEXT", supplementaryinformationtext);
            para[89] = new SqlParameter("@CARRIERIATACODE", carrieriatacode);
            para[90] = new SqlParameter("@CARRIERICAOCODE", carriericaocode);
            para[91] = new SqlParameter("@FLIGHTCANCELCODE", flightcancelcode);
            para[92] = new SqlParameter("@FLIGHTFLAG", flightflag);
            para[93] = new SqlParameter("@FLIGHTNUMBER", flightnumber);
            para[94] = new SqlParameter("@FLIGHTREPEATCOUNT", flightrepeatcount);
            para[95] = new SqlParameter("@FLIGHTSERVICETYPEIATACODE", flightservicetypeiatacode);
            para[96] = new SqlParameter("@FLIGHTSTATUSCODE", flightstatuscode);
            para[97] = new SqlParameter("@FLIGHTSUFFIX", flightsuffix);
            para[98] = new SqlParameter("@FLIGHTTRANSITCODE", flighttransitcode);
            para[99] = new SqlParameter("@ISGENERALAVIATIONFLIGHT", isgeneralaviationflight);
            para[100] = new SqlParameter("@ISRETURNFLIGHT", isreturnflight);
            para[101] = new SqlParameter("@NEWFLIGHTREASON", newflightreason);
            para[102] = new SqlParameter("@TRANSFERFLIGHTIDENTITY", transferflightidentity);

            if (trans != null)
            {
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, para);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
            }
        }

    }
}
