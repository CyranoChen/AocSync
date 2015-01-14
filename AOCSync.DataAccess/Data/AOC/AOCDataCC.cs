using System;
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

namespace AOCSync.DataAccess
{
    public class AOCDataCC
    {
        public static DataRow GetAOCDataByID(Guid aGuid)
        {
//            string sql = @"SELECT ID,   STOD,   TTYP, URNO,    ORG3,   DES3,   LAND,   AIRB,   ATC5,   VIA1, 
//                                  JFNO, CKIF,   FLTI, TERM,    STPO,   GENO,   DAIA,   CSS,    EDTA,   EDTD, 
//                                  SP,   CDR,    CODT, CCDT,    SCDR,   SCODT,  SCCDT,  BRC1,   BROD,   BRCD, 
//                                  SRC2, SBRO,   SBRC, GN,      GBS,    GODT,   GCDT,   SGN,    SGOD,   MFDI, 
//                                  POCC, SGCD,   ASIA, APTIATA, REGN,   DRCT,   USEC,   TYPC,   CDAT,   USEU,   
//                                  TYPU, LSTU, REMP, FLNO
//                            FROM [AOC] 
//                            WHERE ID = @aGuid";
            string sql = @"SELECT ID,   STOD,   TTYP, URNO,    ORG3,   DES3,   LAND,   AIRB,   ATC5,   VIA1, 
                                              JFNO, CKIF,   FLTI, TERM,    STPO,   GENO,   DAIA,   CSS,    EDTA,   EDTD, 
                                              SP,   CDR,    CODT, CCDT,    SCDR,   SCODT,  SCCDT,  BRC1,   BROD,   BRCD, 
                                              SRC2, SBRO,   SBRC, GN,      GBS,    GODT,   GCDT,   SGN,    SGOD,   MFDI, 
                                              POCC, SGCD,   ASIA, APTIATA, REGN,   DRCT,   USEC,   TYPC,   CDAT,   USEU,   
                                              TYPU, LSTU, REMP, FLNO
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
                                             ,TRANSFERFLIGHTIDENTITY               
                                        FROM [AOC] 
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
            Guid aGuid, 
            string stod, string ttyp, string urno, string org3, string des3, 
            string land, string airb, string atc5, string via1, string jfno, 
            string ckif, string flti, string term, string stpo, string geno, 
            string daia, string css, string edta, string edtd, string sp, 
            string cdr, string codt, string ccdt, string scdr, string scodt, 
            string sccdt, string brc1, string brod, string brcd, string src2, 
            string sbro, string sbrc, string gn, string gbs, string godt, 
            string gcdt, string sgn, string sgod, string mfdi, string pocc, 
            string sgcd, string asia, string aptiata, string regn, string drct, 
            string useu, string typu, DateTime lstu, string remp, string flno
            , string actualoffblocksdatetime              
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
            )
        {
//            string sql = @"UPDATE [AOC]
//                    SET       STOD=@STOD,   TTYP=@TTYP,         URNO=@URNO,         ORG3=@ORG3,      DES3=@DES3,      
//                              LAND=@LAND,   AIRB=@AIRB,         ATC5=@ATC5,         VIA1=@VIA1,      JFNO=@JFNO,      
//                              CKIF=@CKIF,   FLTI=@FLTI,         TERM=@TERM,         STPO=@STPO,      GENO=@GENO,      
//                              DAIA=@DAIA,   CSS=@CSS,           EDTA=@EDTA,         EDTD=@EDTD,      SP=@SP,          
//                              CDR=@CDR,     CODT=@CODT,         CCDT=@CCDT,         SCDR=@SCDR,      SCODT=@SCODT,    
//                              SCCDT=@SCCDT, BRC1=@BRC1,         BROD=@BROD,         BRCD=@BRCD,      SRC2=@SRC2,      
//                              SBRO=@SBRO,   SBRC=@SBRC,         GN=@GN,             GBS=@GBS,        GODT=@GODT,      
//                              GCDT=@GCDT,   SGN=@SGN,           SGOD=@SGOD,         MFDI=@MFDI,      POCC=@POCC,     
//                              SGCD=@SGCD,   ASIA=@ASIA,         APTIATA=@APTIATA,   REGN=@REGN,      DRCT=@DRCT,      
//                              USEU=@USEU,   TYPU=@TYPU,         LSTU=@LSTU,          REMP=@REMP,       FLNO=@FLNO
//                    WHERE     ID = @aGuid";
            string sql = @"UPDATE [AOC]
                    SET       STOD=@STOD,   TTYP=@TTYP,         URNO=@URNO,         ORG3=@ORG3,      DES3=@DES3,      
                              LAND=@LAND,   AIRB=@AIRB,         ATC5=@ATC5,         VIA1=@VIA1,      JFNO=@JFNO,      
                              CKIF=@CKIF,   FLTI=@FLTI,         TERM=@TERM,         STPO=@STPO,      GENO=@GENO,      
                              DAIA=@DAIA,   CSS=@CSS,           EDTA=@EDTA,         EDTD=@EDTD,      SP=@SP,          
                              CDR=@CDR,     CODT=@CODT,         CCDT=@CCDT,         SCDR=@SCDR,      SCODT=@SCODT,    
                              SCCDT=@SCCDT, BRC1=@BRC1,         BROD=@BROD,         BRCD=@BRCD,      SRC2=@SRC2,      
                              SBRO=@SBRO,   SBRC=@SBRC,         GN=@GN,             GBS=@GBS,        GODT=@GODT,      
                              GCDT=@GCDT,   SGN=@SGN,           SGOD=@SGOD,         MFDI=@MFDI,      POCC=@POCC,     
                              SGCD=@SGCD,   ASIA=@ASIA,         APTIATA=@APTIATA,   REGN=@REGN,      DRCT=@DRCT,      
                              USEU=@USEU,   TYPU=@TYPU,         LSTU=@LSTU,          REMP=@REMP,       FLNO=@FLNO
                             ,ACTUALOFFBLOCKSDATETIME              =@ACTUALOFFBLOCKSDATETIME              
                             ,ACTUALONBLOCKSDATETIME               =@ACTUALONBLOCKSDATETIME               
                             ,AIRCRAFTTERMINALCODE                 =@AIRCRAFTTERMINALCODE                 
                             ,BAGGAGERECLAIMCAROUSELROLE           =@BAGGAGERECLAIMCAROUSELROLE           
                             ,ESTIMATEDFLIGHTDURATION              =@ESTIMATEDFLIGHTDURATION              
                             ,FIRSTBAGDATETIME                     =@FIRSTBAGDATETIME                     
                             ,LASTBAGDATETIME                      =@LASTBAGDATETIME                      
                             ,LATESTKNOWNDATETIME                  =@LATESTKNOWNDATETIME                  
                             ,LATESTKNOWNDATETIMESOURCE            =@LATESTKNOWNDATETIMESOURCE            
                             ,NEXTSTATIONACTUALDATETIME            =@NEXTSTATIONACTUALDATETIME            
                             ,NEXTSTATIONESTIMATEDDATETIME         =@NEXTSTATIONESTIMATEDDATETIME         
                             ,NEXTSTATIONSCHEDULEDDATETIME         =@NEXTSTATIONSCHEDULEDDATETIME         
                             ,OCCURDATETIME                        =@OCCURDATETIME                        
                             ,PREVIOUSAIRBORNEDATETIME             =@PREVIOUSAIRBORNEDATETIME             
                             ,PREVIOUSESTIMATEDDATETIME            =@PREVIOUSESTIMATEDDATETIME            
                             ,PREVIOUSSCHEDULEDDATETIME            =@PREVIOUSSCHEDULEDDATETIME            
                             ,SCHEDULEDDATE                        =@SCHEDULEDDATE                        
                             ,SDBAGRECLAIMCAROUSELROLE             =@SDBAGRECLAIMCAROUSELROLE             
                             ,SDFIRSTBAGDATETIME                   =@SDFIRSTBAGDATETIME                   
                             ,SDLASTBAGDATETIME                    =@SDLASTBAGDATETIME                    
                             ,SUPPLEMENTARYINFORMATION             =@SUPPLEMENTARYINFORMATION             
                             ,SUPPLEMENTARYINFORMATIONTEXT         =@SUPPLEMENTARYINFORMATIONTEXT         
                             ,CARRIERIATACODE                      =@CARRIERIATACODE                      
                             ,CARRIERICAOCODE                      =@CARRIERICAOCODE                      
                             ,FLIGHTCANCELCODE                     =@FLIGHTCANCELCODE                     
                             ,FLIGHTFLAG                           =@FLIGHTFLAG                           
                             ,FLIGHTNUMBER                         =@FLIGHTNUMBER                         
                             ,FLIGHTREPEATCOUNT                    =@FLIGHTREPEATCOUNT                    
                             ,FLIGHTSERVICETYPEIATACODE            =@FLIGHTSERVICETYPEIATACODE            
                             ,FLIGHTSTATUSCODE                     =@FLIGHTSTATUSCODE                     
                             ,FLIGHTSUFFIX                         =@FLIGHTSUFFIX                         
                             ,FLIGHTTRANSITCODE                    =@FLIGHTTRANSITCODE                    
                             ,ISGENERALAVIATIONFLIGHT              =@ISGENERALAVIATIONFLIGHT              
                             ,ISRETURNFLIGHT                       =@ISRETURNFLIGHT                       
                             ,NEWFLIGHTREASON                      =@NEWFLIGHTREASON                      
                             ,TRANSFERFLIGHTIDENTITY               =@TRANSFERFLIGHTIDENTITY               
                    WHERE     ID = @aGuid";


            SqlParameter[] para ={
            new SqlParameter("@aGuid", aGuid)
             ,new SqlParameter("@URNO",urno)
             ,new SqlParameter("@STOD", stod)
             ,new SqlParameter("@TTYP", ttyp)
             ,new SqlParameter("@ORG3", org3)
             ,new SqlParameter("@DES3", des3)
             ,new SqlParameter("@LAND", land)
             ,new SqlParameter("@AIRB", airb)
             ,new SqlParameter("@ATC5", atc5)
             ,new SqlParameter("@VIA1", via1)
             ,new SqlParameter("@JFNO", jfno)
             ,new SqlParameter("@CKIF", ckif)
             ,new SqlParameter("@FLTI", flti)
             ,new SqlParameter("@TERM", term)
             ,new SqlParameter("@STPO", stpo)
             ,new SqlParameter("@GENO", geno)
             ,new SqlParameter("@DAIA", daia)
             ,new SqlParameter("@CSS", css)
             ,new SqlParameter("@EDTA", edta)
             ,new SqlParameter("@EDTD", edtd)
             ,new SqlParameter("@SP", sp)
             ,new SqlParameter("@CDR", cdr)
             ,new SqlParameter("@CODT", codt)
             ,new SqlParameter("@CCDT", ccdt)
             ,new SqlParameter("@SCDR", scdr)
             ,new SqlParameter("@SCODT", scodt)
             ,new SqlParameter("@SCCDT", sccdt)
             ,new SqlParameter("@BRC1", brc1)
             ,new SqlParameter("@BROD", brod)
             ,new SqlParameter("@BRCD", brcd)
             ,new SqlParameter("@SRC2", src2)
             ,new SqlParameter("@SBRO", sbro)
             ,new SqlParameter("@SBRC", sbrc)
             ,new SqlParameter("@GN", gn)
             ,new SqlParameter("@GBS", gbs)
             ,new SqlParameter("@GODT", godt)
             ,new SqlParameter("@GCDT", gcdt)
             ,new SqlParameter("@SGN", sgn)
             ,new SqlParameter("@SGOD", sgod)
             ,new SqlParameter("@MFDI", mfdi)
             ,new SqlParameter("@POCC", pocc)
             ,new SqlParameter("@SGCD", sgcd)
             ,new SqlParameter("@ASIA", asia)
             ,new SqlParameter("@APTIATA", aptiata)
             ,new SqlParameter("@REGN", regn)
             ,new SqlParameter("@DRCT", drct)
             ,new SqlParameter("@USEU", useu)
             ,new SqlParameter("@TYPU", typu)
             ,new SqlParameter("@LSTU", lstu)
             ,new SqlParameter("@REMP", remp)
             ,new SqlParameter("@FLNO", flno)
             ,new SqlParameter("@ACTUALOFFBLOCKSDATETIME",actualoffblocksdatetime)
             ,new SqlParameter("@ACTUALONBLOCKSDATETIME",actualonblocksdatetime)
             ,new SqlParameter("@AIRCRAFTTERMINALCODE",aircraftterminalcode)
             ,new SqlParameter("@BAGGAGERECLAIMCAROUSELROLE",baggagereclaimcarouselrole)
             ,new SqlParameter("@ESTIMATEDFLIGHTDURATION",estimatedflightduration)
             ,new SqlParameter("@FIRSTBAGDATETIME",firstbagdatetime)
             ,new SqlParameter("@LASTBAGDATETIME",lastbagdatetime)
             ,new SqlParameter("@LATESTKNOWNDATETIME",latestknowndatetime)
             ,new SqlParameter("@LATESTKNOWNDATETIMESOURCE",latestknowndatetimesource)
             ,new SqlParameter("@NEXTSTATIONACTUALDATETIME",nextstationactualdatetime)
             ,new SqlParameter("@NEXTSTATIONESTIMATEDDATETIME",nextstationestimateddatetime)
             ,new SqlParameter("@NEXTSTATIONSCHEDULEDDATETIME",nextstationscheduleddatetime)
             ,new SqlParameter("@OCCURDATETIME",occurdatetime)
             ,new SqlParameter("@PREVIOUSAIRBORNEDATETIME",previousairbornedatetime)
             ,new SqlParameter("@PREVIOUSESTIMATEDDATETIME",previousestimateddatetime)
             ,new SqlParameter("@PREVIOUSSCHEDULEDDATETIME",previousscheduleddatetime)
             ,new SqlParameter("@SCHEDULEDDATE",scheduleddate)
             ,new SqlParameter("@SDBAGRECLAIMCAROUSELROLE",sdbagreclaimcarouselrole)
             ,new SqlParameter("@SDFIRSTBAGDATETIME",sdfirstbagdatetime)
             ,new SqlParameter("@SDLASTBAGDATETIME",sdlastbagdatetime)
             ,new SqlParameter("@SUPPLEMENTARYINFORMATION",supplementaryinformation)
             ,new SqlParameter("@SUPPLEMENTARYINFORMATIONTEXT",supplementaryinformationtext)
             ,new SqlParameter("@CARRIERIATACODE",carrieriatacode)
             ,new SqlParameter("@CARRIERICAOCODE",carriericaocode)
             ,new SqlParameter("@FLIGHTCANCELCODE",flightcancelcode)
             ,new SqlParameter("@FLIGHTFLAG",flightflag)
             ,new SqlParameter("@FLIGHTNUMBER",flightnumber)
             ,new SqlParameter("@FLIGHTREPEATCOUNT",flightrepeatcount)
             ,new SqlParameter("@FLIGHTSERVICETYPEIATACODE",flightservicetypeiatacode)
             ,new SqlParameter("@FLIGHTSTATUSCODE",flightstatuscode)
             ,new SqlParameter("@FLIGHTSUFFIX",flightsuffix)
             ,new SqlParameter("@FLIGHTTRANSITCODE",flighttransitcode)
             ,new SqlParameter("@ISGENERALAVIATIONFLIGHT",isgeneralaviationflight)
             ,new SqlParameter("@ISRETURNFLIGHT",isreturnflight)
             ,new SqlParameter("@NEWFLIGHTREASON",newflightreason)
             ,new SqlParameter("@TRANSFERFLIGHTIDENTITY",transferflightidentity)
            };
            
            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void UpdateAOCData(
            Guid aGuid,
            string stod, string ttyp, string urno, string org3, string des3,
            string land, string airb, string atc5, string via1, string jfno,
            string ckif, string flti, string term, string stpo, string geno,
            string daia, string css, string edta, string edtd, string sp,
            string cdr, string codt, string ccdt, string scdr, string scodt,
            string sccdt, string brc1, string brod, string brcd, string src2,
            string sbro, string sbrc, string gn, string gbs, string godt,
            string gcdt, string sgn, string sgod, string mfdi, string pocc,
            string sgcd, string asia, string aptiata, string regn, string drct,
            string useu, string typu, DateTime lstu, string remp, string flno
             , string actualoffblocksdatetime              
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
             , string transferflightidentity,
            SqlTransaction trans)
        {
//            string sql = @"UPDATE  [AOC]
//                    SET       STOD=@STOD,   TTYP=@TTYP,         URNO=@URNO,         ORG3=@ORG3,      DES3=@DES3,      
//                              LAND=@LAND,   AIRB=@AIRB,         ATC5=@ATC5,         VIA1=@VIA1,      JFNO=@JFNO,      
//                              CKIF=@CKIF,   FLTI=@FLTI,         TERM=@TERM,         STPO=@STPO,      GENO=@GENO,      
//                              DAIA=@DAIA,   CSS=@CSS,           EDTA=@EDTA,         EDTD=@EDTD,      SP=@SP,          
//                              CDR=@CDR,     CODT=@CODT,         CCDT=@CCDT,         SCDR=@SCDR,      SCODT=@SCODT,    
//                              SCCDT=@SCCDT, BRC1=@BRC1,         BROD=@BROD,         BRCD=@BRCD,      SRC2=@SRC2,      
//                              SBRO=@SBRO,   SBRC=@SBRC,         GN=@GN,             GBS=@GBS,        GODT=@GODT,      
//                              GCDT=@GCDT,   SGN=@SGN,           SGOD=@SGOD,         MFDI=@MFDI,      POCC=@POCC,     
//                              SGCD=@SGCD,   ASIA=@ASIA,         APTIATA=@APTIATA,   REGN=@REGN,      DRCT=@DRCT,      
//                              USEU=@USEU,   TYPU=@TYPU,         LSTU=@LSTU,       REMP=@REMP,       FLNO=@FLNO
//                    WHERE     ID = @aGuid";
              string sql = @"UPDATE  [AOC]
                    SET       STOD=@STOD,   TTYP=@TTYP,         URNO=@URNO,         ORG3=@ORG3,      DES3=@DES3,      
                              LAND=@LAND,   AIRB=@AIRB,         ATC5=@ATC5,         VIA1=@VIA1,      JFNO=@JFNO,      
                              CKIF=@CKIF,   FLTI=@FLTI,         TERM=@TERM,         STPO=@STPO,      GENO=@GENO,      
                              DAIA=@DAIA,   CSS=@CSS,           EDTA=@EDTA,         EDTD=@EDTD,      SP=@SP,          
                              CDR=@CDR,     CODT=@CODT,         CCDT=@CCDT,         SCDR=@SCDR,      SCODT=@SCODT,    
                              SCCDT=@SCCDT, BRC1=@BRC1,         BROD=@BROD,         BRCD=@BRCD,      SRC2=@SRC2,      
                              SBRO=@SBRO,   SBRC=@SBRC,         GN=@GN,             GBS=@GBS,        GODT=@GODT,      
                              GCDT=@GCDT,   SGN=@SGN,           SGOD=@SGOD,         MFDI=@MFDI,      POCC=@POCC,     
                              SGCD=@SGCD,   ASIA=@ASIA,         APTIATA=@APTIATA,   REGN=@REGN,      DRCT=@DRCT,      
                              USEU=@USEU,   TYPU=@TYPU,         LSTU=@LSTU,       REMP=@REMP,       FLNO=@FLNO
                             ,ACTUALOFFBLOCKSDATETIME              =@ACTUALOFFBLOCKSDATETIME              
                             ,ACTUALONBLOCKSDATETIME               =@ACTUALONBLOCKSDATETIME               
                             ,AIRCRAFTTERMINALCODE                 =@AIRCRAFTTERMINALCODE                 
                             ,BAGGAGERECLAIMCAROUSELROLE           =@BAGGAGERECLAIMCAROUSELROLE           
                             ,ESTIMATEDFLIGHTDURATION              =@ESTIMATEDFLIGHTDURATION              
                             ,FIRSTBAGDATETIME                     =@FIRSTBAGDATETIME                     
                             ,LASTBAGDATETIME                      =@LASTBAGDATETIME                      
                             ,LATESTKNOWNDATETIME                  =@LATESTKNOWNDATETIME                  
                             ,LATESTKNOWNDATETIMESOURCE            =@LATESTKNOWNDATETIMESOURCE            
                             ,NEXTSTATIONACTUALDATETIME            =@NEXTSTATIONACTUALDATETIME            
                             ,NEXTSTATIONESTIMATEDDATETIME         =@NEXTSTATIONESTIMATEDDATETIME         
                             ,NEXTSTATIONSCHEDULEDDATETIME         =@NEXTSTATIONSCHEDULEDDATETIME         
                             ,OCCURDATETIME                        =@OCCURDATETIME                        
                             ,PREVIOUSAIRBORNEDATETIME             =@PREVIOUSAIRBORNEDATETIME             
                             ,PREVIOUSESTIMATEDDATETIME            =@PREVIOUSESTIMATEDDATETIME            
                             ,PREVIOUSSCHEDULEDDATETIME            =@PREVIOUSSCHEDULEDDATETIME            
                             ,SCHEDULEDDATE                        =@SCHEDULEDDATE                        
                             ,SDBAGRECLAIMCAROUSELROLE             =@SDBAGRECLAIMCAROUSELROLE             
                             ,SDFIRSTBAGDATETIME                   =@SDFIRSTBAGDATETIME                   
                             ,SDLASTBAGDATETIME                    =@SDLASTBAGDATETIME                    
                             ,SUPPLEMENTARYINFORMATION             =@SUPPLEMENTARYINFORMATION             
                             ,SUPPLEMENTARYINFORMATIONTEXT         =@SUPPLEMENTARYINFORMATIONTEXT         
                             ,CARRIERIATACODE                      =@CARRIERIATACODE                      
                             ,CARRIERICAOCODE                      =@CARRIERICAOCODE                      
                             ,FLIGHTCANCELCODE                     =@FLIGHTCANCELCODE                     
                             ,FLIGHTFLAG                           =@FLIGHTFLAG                           
                             ,FLIGHTNUMBER                         =@FLIGHTNUMBER                         
                             ,FLIGHTREPEATCOUNT                    =@FLIGHTREPEATCOUNT                    
                             ,FLIGHTSERVICETYPEIATACODE            =@FLIGHTSERVICETYPEIATACODE            
                             ,FLIGHTSTATUSCODE                     =@FLIGHTSTATUSCODE                     
                             ,FLIGHTSUFFIX                         =@FLIGHTSUFFIX                         
                             ,FLIGHTTRANSITCODE                    =@FLIGHTTRANSITCODE                    
                             ,ISGENERALAVIATIONFLIGHT              =@ISGENERALAVIATIONFLIGHT              
                             ,ISRETURNFLIGHT                       =@ISRETURNFLIGHT                       
                             ,NEWFLIGHTREASON                      =@NEWFLIGHTREASON                      
                             ,TRANSFERFLIGHTIDENTITY               =@TRANSFERFLIGHTIDENTITY   
                      WHERE     ID = @aGuid";
              SqlParameter[] para ={
            new SqlParameter("@aGuid", aGuid)
             ,new SqlParameter("@URNO",urno)
             ,new SqlParameter("@STOD", stod)
             ,new SqlParameter("@TTYP", ttyp)
             ,new SqlParameter("@ORG3", org3)
             ,new SqlParameter("@DES3", des3)
             ,new SqlParameter("@LAND", land)
             ,new SqlParameter("@AIRB", airb)
             ,new SqlParameter("@ATC5", atc5)
             ,new SqlParameter("@VIA1", via1)
             ,new SqlParameter("@JFNO", jfno)
             ,new SqlParameter("@CKIF", ckif)
             ,new SqlParameter("@FLTI", flti)
             ,new SqlParameter("@TERM", term)
             ,new SqlParameter("@STPO", stpo)
             ,new SqlParameter("@GENO", geno)
             ,new SqlParameter("@DAIA", daia)
             ,new SqlParameter("@CSS", css)
             ,new SqlParameter("@EDTA", edta)
             ,new SqlParameter("@EDTD", edtd)
             ,new SqlParameter("@SP", sp)
             ,new SqlParameter("@CDR", cdr)
             ,new SqlParameter("@CODT", codt)
             ,new SqlParameter("@CCDT", ccdt)
             ,new SqlParameter("@SCDR", scdr)
             ,new SqlParameter("@SCODT", scodt)
             ,new SqlParameter("@SCCDT", sccdt)
             ,new SqlParameter("@BRC1", brc1)
             ,new SqlParameter("@BROD", brod)
             ,new SqlParameter("@BRCD", brcd)
             ,new SqlParameter("@SRC2", src2)
             ,new SqlParameter("@SBRO", sbro)
             ,new SqlParameter("@SBRC", sbrc)
             ,new SqlParameter("@GN", gn)
             ,new SqlParameter("@GBS", gbs)
             ,new SqlParameter("@GODT", godt)
             ,new SqlParameter("@GCDT", gcdt)
             ,new SqlParameter("@SGN", sgn)
             ,new SqlParameter("@SGOD", sgod)
             ,new SqlParameter("@MFDI", mfdi)
             ,new SqlParameter("@POCC", pocc)
             ,new SqlParameter("@SGCD", sgcd)
             ,new SqlParameter("@ASIA", asia)
             ,new SqlParameter("@APTIATA", aptiata)
             ,new SqlParameter("@REGN", regn)
             ,new SqlParameter("@DRCT", drct)
             ,new SqlParameter("@USEU", useu)
             ,new SqlParameter("@TYPU", typu)
             ,new SqlParameter("@LSTU", lstu)
             ,new SqlParameter("@REMP", remp)
             ,new SqlParameter("@FLNO", flno)
             ,new SqlParameter("@ACTUALOFFBLOCKSDATETIME",actualoffblocksdatetime)
             ,new SqlParameter("@ACTUALONBLOCKSDATETIME",actualonblocksdatetime)
             ,new SqlParameter("@AIRCRAFTTERMINALCODE",aircraftterminalcode)
             ,new SqlParameter("@BAGGAGERECLAIMCAROUSELROLE",baggagereclaimcarouselrole)
             ,new SqlParameter("@ESTIMATEDFLIGHTDURATION",estimatedflightduration)
             ,new SqlParameter("@FIRSTBAGDATETIME",firstbagdatetime)
             ,new SqlParameter("@LASTBAGDATETIME",lastbagdatetime)
             ,new SqlParameter("@LATESTKNOWNDATETIME",latestknowndatetime)
             ,new SqlParameter("@LATESTKNOWNDATETIMESOURCE",latestknowndatetimesource)
             ,new SqlParameter("@NEXTSTATIONACTUALDATETIME",nextstationactualdatetime)
             ,new SqlParameter("@NEXTSTATIONESTIMATEDDATETIME",nextstationestimateddatetime)
             ,new SqlParameter("@NEXTSTATIONSCHEDULEDDATETIME",nextstationscheduleddatetime)
             ,new SqlParameter("@OCCURDATETIME",occurdatetime)
             ,new SqlParameter("@PREVIOUSAIRBORNEDATETIME",previousairbornedatetime)
             ,new SqlParameter("@PREVIOUSESTIMATEDDATETIME",previousestimateddatetime)
             ,new SqlParameter("@PREVIOUSSCHEDULEDDATETIME",previousscheduleddatetime)
             ,new SqlParameter("@SCHEDULEDDATE",scheduleddate)
             ,new SqlParameter("@SDBAGRECLAIMCAROUSELROLE",sdbagreclaimcarouselrole)
             ,new SqlParameter("@SDFIRSTBAGDATETIME",sdfirstbagdatetime)
             ,new SqlParameter("@SDLASTBAGDATETIME",sdlastbagdatetime)
             ,new SqlParameter("@SUPPLEMENTARYINFORMATION",supplementaryinformation)
             ,new SqlParameter("@SUPPLEMENTARYINFORMATIONTEXT",supplementaryinformationtext)
             ,new SqlParameter("@CARRIERIATACODE",carrieriatacode)
             ,new SqlParameter("@CARRIERICAOCODE",carriericaocode)
             ,new SqlParameter("@FLIGHTCANCELCODE",flightcancelcode)
             ,new SqlParameter("@FLIGHTFLAG",flightflag)
             ,new SqlParameter("@FLIGHTNUMBER",flightnumber)
             ,new SqlParameter("@FLIGHTREPEATCOUNT",flightrepeatcount)
             ,new SqlParameter("@FLIGHTSERVICETYPEIATACODE",flightservicetypeiatacode)
             ,new SqlParameter("@FLIGHTSTATUSCODE",flightstatuscode)
             ,new SqlParameter("@FLIGHTSUFFIX",flightsuffix)
             ,new SqlParameter("@FLIGHTTRANSITCODE",flighttransitcode)
             ,new SqlParameter("@ISGENERALAVIATIONFLIGHT",isgeneralaviationflight)
             ,new SqlParameter("@ISRETURNFLIGHT",isreturnflight)
             ,new SqlParameter("@NEWFLIGHTREASON",newflightreason)
             ,new SqlParameter("@TRANSFERFLIGHTIDENTITY",transferflightidentity)
            };

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
                string stod, string ttyp, string urno,string org3, string des3, 
                string land, string airb, string atc5, string via1, string jfno, 
                string ckif, string flti, string term, string stpo, string geno, 
                string daia, string css, string edta, string edtd, string sp, 
                string cdr, string codt, string ccdt, string scdr, string scodt, 
                string sccdt, string brc1, string brod, string brcd, string src2, 
                string sbro, string sbrc, string gn, string gbs, string godt, 
                string gcdt, string sgn, string sgod, string mfdi, string pocc, 
                string sgcd, string asia, string aptiata, string regn, string drct, 
                string usec, string typc, DateTime cdat, string remp, string flno
             , string actualoffblocksdatetime              
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
            )
        {
            string sql = @"INSERT INTO [AOC] (
                                            URNO,   STOD,   TTYP,       ORG3, 
                                    DES3,   LAND,   AIRB,   ATC5,       VIA1, 
                                    JFNO,   CKIF,   FLTI,   TERM,       STPO, 
                                    GENO,   DAIA,   CSS,    EDTA,       EDTD, 
                                    SP,     CDR,    CODT,   CCDT,       SCDR, 
                                    SCODT,  SCCDT,  BRC1,   BROD,       BRCD,
                                    SRC2,   SBRO,   SBRC,   GN,         GBS, 
                                    GODT,   GCDT,   SGN,    SGOD,       MFDI, 
                                    POCC,   SGCD,   ASIA,   APTIATA,    REGN, 
                                    DRCT,   USEC,   TYPC,   CDAT,    REMP,  FLNO
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
                                    ,TRANSFERFLIGHTIDENTITY               
                                    ) 
                               VALUES (
                                            @URNO,  @STOD,  @TTYP,      @ORG3,  
                                    @DES3,  @LAND,  @AIRB,  @ATC5,      @VIA1,  
                                    @JFNO,  @CKIF,  @FLTI,  @TERM,      @STPO, 
                                    @GENO,  @DAIA,  @CSS,   @EDTA,      @EDTD, 
                                    @SP,    @CDR,   @CODT,  @CCDT,      @SCDR,  
                                    @SCODT, @SCCDT, @BRC1,  @BROD,      @BRCD, 
                                    @SRC2,  @SBRO,  @SBRC,  @GN,        @GBS,  
                                    @GODT,  @GCDT,  @SGN,   @SGOD,      @MFDI,  
                                    @POCC,  @SGCD,  @ASIA,  @APTIATA,   @REGN,  
                                    @DRCT,  @USEC,  @TYPC,  @CDAT,  @REMP,  @FLNO
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


            SqlParameter[] para ={ 
            new SqlParameter()
            , new SqlParameter("@URNO", urno)
            , new SqlParameter("@STOD", stod)
            , new SqlParameter("@TTYP", ttyp)
            , new SqlParameter("@ORG3", org3)
            , new SqlParameter("@DES3", des3)
            , new SqlParameter("@LAND", land)
            , new SqlParameter("@AIRB", airb)
            , new SqlParameter("@ATC5", atc5)
            , new SqlParameter("@VIA1", via1)
            , new SqlParameter("@JFNO", jfno)
            , new SqlParameter("@CKIF", ckif)
            , new SqlParameter("@FLTI", flti)
            , new SqlParameter("@TERM", term)
            , new SqlParameter("@STPO", stpo)
            , new SqlParameter("@GENO", geno)
            , new SqlParameter("@DAIA", daia)
            , new SqlParameter("@CSS", css)
            , new SqlParameter("@EDTA", edta)
            , new SqlParameter("@EDTD", edtd)
            , new SqlParameter("@SP", sp)
            , new SqlParameter("@CDR", cdr)
            , new SqlParameter("@CODT", codt)
            , new SqlParameter("@CCDT", ccdt)
            , new SqlParameter("@SCDR", scdr)
            , new SqlParameter("@SCODT", scodt)
            , new SqlParameter("@SCCDT", sccdt)
            , new SqlParameter("@BRC1", brc1)
            , new SqlParameter("@BROD", brod)
            , new SqlParameter("@BRCD", brcd)
            , new SqlParameter("@SRC2", src2)
            , new SqlParameter("@SBRO", sbro)
            , new SqlParameter("@SBRC", sbrc)
            , new SqlParameter("@GN", gn)
            , new SqlParameter("@GBS", gbs)
            , new SqlParameter("@GODT", godt)
            , new SqlParameter("@GCDT", gcdt)
            , new SqlParameter("@SGN", sgn)
            , new SqlParameter("@SGOD", sgod)
            , new SqlParameter("@MFDI", mfdi)
            , new SqlParameter("@POCC", pocc)
            , new SqlParameter("@SGCD", sgcd)
            , new SqlParameter("@ASIA", asia)
            , new SqlParameter("@APTIATA", aptiata)
            , new SqlParameter("@REGN", regn)
            , new SqlParameter("@DRCT", drct)
            , new SqlParameter("@USEC", usec)
            , new SqlParameter("@TYPC", typc)
            , new SqlParameter("@CDAT", cdat)
            , new SqlParameter("@REMP", remp)
            , new SqlParameter("@FLNO", flno)
            , new SqlParameter("@ACTUALOFFBLOCKSDATETIME", actualoffblocksdatetime)
            , new SqlParameter("@ACTUALONBLOCKSDATETIME", actualonblocksdatetime)
            , new SqlParameter("@AIRCRAFTTERMINALCODE", aircraftterminalcode)
            , new SqlParameter("@BAGGAGERECLAIMCAROUSELROLE", baggagereclaimcarouselrole)
            , new SqlParameter("@ESTIMATEDFLIGHTDURATION", estimatedflightduration)
            , new SqlParameter("@FIRSTBAGDATETIME", firstbagdatetime)
            , new SqlParameter("@LASTBAGDATETIME", lastbagdatetime)
            , new SqlParameter("@LATESTKNOWNDATETIME", latestknowndatetime)
            , new SqlParameter("@LATESTKNOWNDATETIMESOURCE", latestknowndatetimesource)
            , new SqlParameter("@NEXTSTATIONACTUALDATETIME", nextstationactualdatetime)
            , new SqlParameter("@NEXTSTATIONESTIMATEDDATETIME", nextstationestimateddatetime)
            , new SqlParameter("@NEXTSTATIONSCHEDULEDDATETIME", nextstationscheduleddatetime)
            , new SqlParameter("@OCCURDATETIME", occurdatetime)
            , new SqlParameter("@PREVIOUSAIRBORNEDATETIME", previousairbornedatetime)
            , new SqlParameter("@PREVIOUSESTIMATEDDATETIME", previousestimateddatetime)
            , new SqlParameter("@PREVIOUSSCHEDULEDDATETIME", previousscheduleddatetime)
            , new SqlParameter("@SCHEDULEDDATE", scheduleddate)
            , new SqlParameter("@SDBAGRECLAIMCAROUSELROLE", sdbagreclaimcarouselrole)
            , new SqlParameter("@SDFIRSTBAGDATETIME", sdfirstbagdatetime)
            , new SqlParameter("@SDLASTBAGDATETIME", sdlastbagdatetime)
            , new SqlParameter("@SUPPLEMENTARYINFORMATION", supplementaryinformation)
            , new SqlParameter("@SUPPLEMENTARYINFORMATIONTEXT", supplementaryinformationtext)
            , new SqlParameter("@CARRIERIATACODE", carrieriatacode)
            , new SqlParameter("@CARRIERICAOCODE", carriericaocode)
            , new SqlParameter("@FLIGHTCANCELCODE", flightcancelcode)
            , new SqlParameter("@FLIGHTFLAG", flightflag)
            , new SqlParameter("@FLIGHTNUMBER", flightnumber)
            , new SqlParameter("@FLIGHTREPEATCOUNT", flightrepeatcount)
            , new SqlParameter("@FLIGHTSERVICETYPEIATACODE", flightservicetypeiatacode)
            , new SqlParameter("@FLIGHTSTATUSCODE", flightstatuscode)
            , new SqlParameter("@FLIGHTSUFFIX", flightsuffix)
            , new SqlParameter("@FLIGHTTRANSITCODE", flighttransitcode)
            , new SqlParameter("@ISGENERALAVIATIONFLIGHT", isgeneralaviationflight)
            , new SqlParameter("@ISRETURNFLIGHT", isreturnflight)
            , new SqlParameter("@NEWFLIGHTREASON", newflightreason)
            , new SqlParameter("@TRANSFERFLIGHTIDENTITY", transferflightidentity)
            };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void InsertAOCData(
                string stod, string ttyp, string urno, string org3, string des3,
                string land, string airb, string atc5, string via1, string jfno,
                string ckif, string flti, string term, string stpo, string geno,
                string daia, string css, string edta, string edtd, string sp,
                string cdr, string codt, string ccdt, string scdr, string scodt,
                string sccdt, string brc1, string brod, string brcd, string src2,
                string sbro, string sbrc, string gn, string gbs, string godt,
                string gcdt, string sgn, string sgod, string mfdi, string pocc,
                string sgcd, string asia, string aptiata, string regn, string drct,
                string usec, string typc, DateTime cdat, string remp, string flno
             , string actualoffblocksdatetime              
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
             ,SqlTransaction trans
            )
        {
            string sql = @"INSERT INTO [AOC] (
                                            URNO,   STOD,   TTYP,       ORG3, 
                                    DES3,   LAND,   AIRB,   ATC5,       VIA1, 
                                    JFNO,   CKIF,   FLTI,   TERM,       STPO, 
                                    GENO,   DAIA,   CSS,    EDTA,       EDTD, 
                                    SP,     CDR,    CODT,   CCDT,       SCDR, 
                                    SCODT,  SCCDT,  BRC1,   BROD,       BRCD,
                                    SRC2,   SBRO,   SBRC,   GN,         GBS, 
                                    GODT,   GCDT,   SGN,    SGOD,       MFDI, 
                                    POCC,   SGCD,   ASIA,   APTIATA,    REGN, 
                                    DRCT,   USEC,   TYPC,   CDAT,   REMP,   FLNO
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
                                    ,TRANSFERFLIGHTIDENTITY               
                                    ) 
                               VALUES (
                                            @URNO,  @STOD,  @TTYP,      @ORG3,  
                                    @DES3,  @LAND,  @AIRB,  @ATC5,      @VIA1,  
                                    @JFNO,  @CKIF,  @FLTI,  @TERM,      @STPO, 
                                    @GENO,  @DAIA,  @CSS,   @EDTA,      @EDTD, 
                                    @SP,    @CDR,   @CODT,  @CCDT,      @SCDR,  
                                    @SCODT, @SCCDT, @BRC1,  @BROD,      @BRCD, 
                                    @SRC2,  @SBRO,  @SBRC,  @GN,        @GBS,  
                                    @GODT,  @GCDT,  @SGN,   @SGOD,      @MFDI,  
                                    @POCC,  @SGCD,  @ASIA,  @APTIATA,   @REGN,  
                                    @DRCT,  @USEC,  @TYPC,  @CDAT,  @REMP, @FLNO
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

            SqlParameter[] para = {
            new SqlParameter()
            ,new SqlParameter("@URNO", urno)
            ,new SqlParameter("@STOD", stod)
            ,new SqlParameter("@TTYP", ttyp)
            ,new SqlParameter("@ORG3", org3)
            ,new SqlParameter("@DES3", des3)
            ,new SqlParameter("@LAND", land)
            ,new SqlParameter("@AIRB", airb)
            ,new SqlParameter("@ATC5", atc5)
            ,new SqlParameter("@VIA1", via1)
            ,new SqlParameter("@JFNO", jfno)
            ,new SqlParameter("@CKIF", ckif)
            ,new SqlParameter("@FLTI", flti)
            ,new SqlParameter("@TERM", term)
            ,new SqlParameter("@STPO", stpo)
            ,new SqlParameter("@GENO", geno)
            ,new SqlParameter("@DAIA", daia)
            ,new SqlParameter("@CSS", css)
            ,new SqlParameter("@EDTA", edta)
            ,new SqlParameter("@EDTD", edtd)
            ,new SqlParameter("@SP", sp)
            ,new SqlParameter("@CDR", cdr)
            ,new SqlParameter("@CODT", codt)
            ,new SqlParameter("@CCDT", ccdt)
            ,new SqlParameter("@SCDR", scdr)
            ,new SqlParameter("@SCODT", scodt)
            ,new SqlParameter("@SCCDT", sccdt)
            ,new SqlParameter("@BRC1", brc1)
            ,new SqlParameter("@BROD", brod)
            ,new SqlParameter("@BRCD", brcd)
            ,new SqlParameter("@SRC2", src2)
            ,new SqlParameter("@SBRO", sbro)
            ,new SqlParameter("@SBRC", sbrc)
            ,new SqlParameter("@GN", gn)
            ,new SqlParameter("@GBS", gbs)
            ,new SqlParameter("@GODT", godt)
            ,new SqlParameter("@GCDT", gcdt)
            ,new SqlParameter("@SGN", sgn)
            ,new SqlParameter("@SGOD", sgod)
            ,new SqlParameter("@MFDI", mfdi)
            ,new SqlParameter("@POCC", pocc)
            ,new SqlParameter("@SGCD", sgcd)
            ,new SqlParameter("@ASIA", asia)
            ,new SqlParameter("@APTIATA", aptiata)
            ,new SqlParameter("@REGN", regn)
            ,new SqlParameter("@DRCT", drct)
            ,new SqlParameter("@USEC", usec)
            ,new SqlParameter("@TYPC", typc)
            ,new SqlParameter("@CDAT", cdat)
            ,new SqlParameter("@REMP", remp)
            ,new SqlParameter("@FLNO", flno)
            ,new SqlParameter("@ACTUALOFFBLOCKSDATETIME", actualoffblocksdatetime)
            ,new SqlParameter("@ACTUALONBLOCKSDATETIME", actualonblocksdatetime)
            ,new SqlParameter("@AIRCRAFTTERMINALCODE", aircraftterminalcode)
            ,new SqlParameter("@BAGGAGERECLAIMCAROUSELROLE", baggagereclaimcarouselrole)
            ,new SqlParameter("@ESTIMATEDFLIGHTDURATION", estimatedflightduration)
            ,new SqlParameter("@FIRSTBAGDATETIME", firstbagdatetime)
            ,new SqlParameter("@LASTBAGDATETIME", lastbagdatetime)
            ,new SqlParameter("@LATESTKNOWNDATETIME", latestknowndatetime)
            ,new SqlParameter("@LATESTKNOWNDATETIMESOURCE", latestknowndatetimesource)
            ,new SqlParameter("@NEXTSTATIONACTUALDATETIME", nextstationactualdatetime)
            ,new SqlParameter("@NEXTSTATIONESTIMATEDDATETIME", nextstationestimateddatetime)
            ,new SqlParameter("@NEXTSTATIONSCHEDULEDDATETIME", nextstationscheduleddatetime)
            ,new SqlParameter("@OCCURDATETIME", occurdatetime)
            ,new SqlParameter("@PREVIOUSAIRBORNEDATETIME", previousairbornedatetime)
            ,new SqlParameter("@PREVIOUSESTIMATEDDATETIME", previousestimateddatetime)
            ,new SqlParameter("@PREVIOUSSCHEDULEDDATETIME", previousscheduleddatetime)
            ,new SqlParameter("@SCHEDULEDDATE", scheduleddate)
            ,new SqlParameter("@SDBAGRECLAIMCAROUSELROLE", sdbagreclaimcarouselrole)
            ,new SqlParameter("@SDFIRSTBAGDATETIME", sdfirstbagdatetime)
            ,new SqlParameter("@SDLASTBAGDATETIME", sdlastbagdatetime)
            ,new SqlParameter("@SUPPLEMENTARYINFORMATION", supplementaryinformation)
            ,new SqlParameter("@SUPPLEMENTARYINFORMATIONTEXT", supplementaryinformationtext)
            ,new SqlParameter("@CARRIERIATACODE", carrieriatacode)
            ,new SqlParameter("@CARRIERICAOCODE", carriericaocode)
            ,new SqlParameter("@FLIGHTCANCELCODE", flightcancelcode)
            ,new SqlParameter("@FLIGHTFLAG", flightflag)
            ,new SqlParameter("@FLIGHTNUMBER", flightnumber)
            ,new SqlParameter("@FLIGHTREPEATCOUNT", flightrepeatcount)
            ,new SqlParameter("@FLIGHTSERVICETYPEIATACODE", flightservicetypeiatacode)
            ,new SqlParameter("@FLIGHTSTATUSCODE", flightstatuscode)
            ,new SqlParameter("@FLIGHTSUFFIX", flightsuffix)
            ,new SqlParameter("@FLIGHTTRANSITCODE", flighttransitcode)
            ,new SqlParameter("@ISGENERALAVIATIONFLIGHT", isgeneralaviationflight)
            ,new SqlParameter("@ISRETURNFLIGHT", isreturnflight)
            ,new SqlParameter("@NEWFLIGHTREASON", newflightreason)
            ,new SqlParameter("@TRANSFERFLIGHTIDENTITY", transferflightidentity)
            };

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
            string sql = "DELETE FROM [AOC] WHERE ID = @aGuid";

            SqlParameter[] para = { new SqlParameter("@aGuid", aGuid) };

            SqlHelper.ExecuteNonQuery(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);
        }

        public static void DeleteAOCData(Guid aGuid,SqlTransaction trans)
        {
            string sql = "DELETE FROM [AOC] WHERE ID = @aGuid";

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
            string sql = "DELETE FROM [AOC] WHERE STOD BETWEEN @dateTimeStart AND @dateTimeEnd";

            //SqlParameter[] para = { new SqlParameter("@dateTimeStart", dateTimeStart), new SqlParameter("@dateTimeEnd", dateTimeEnd) );
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

        //按照日期删除
        public static void DeleteAOCData(DateTime dateTimeEnd, SqlTransaction trans)
        {
            string sql = "DELETE FROM [AOC] WHERE STOD <@dateTimeEnd";

            //SqlParameter[] para = { new SqlParameter("@dateTimeStart", dateTimeStart), new SqlParameter("@dateTimeEnd", dateTimeEnd) );
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


        //按照日期删除虹桥
        public static void DeleteAOSHACData(DateTime dateTimeStart, DateTime dateTimeEnd, SqlTransaction trans)
        {
            string sql = "DELETE FROM [AOC] WHERE STOD BETWEEN @dateTimeStart AND @dateTimeEnd AND APTIATA='SHA' ";

            //SqlParameter[] para = { new SqlParameter("@dateTimeStart", dateTimeStart), new SqlParameter("@dateTimeEnd", dateTimeEnd) );
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


        //按照日期删除浦东
        public static void DeleteAOPVGCData(DateTime dateTimeStart, DateTime dateTimeEnd, SqlTransaction trans)
        {
            string sql = "DELETE FROM [AOC] WHERE STOD BETWEEN @dateTimeStart AND @dateTimeEnd AND APTIATA='PVG' ";

            //SqlParameter[] para = { new SqlParameter("@dateTimeStart", dateTimeStart), new SqlParameter("@dateTimeEnd", dateTimeEnd) );
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

        public static DataTable GetAOCDatas()
        {
            string sql = @"SELECT     ID,   STOD,   TTYP, URNO,    ORG3,   DES3,   LAND,   AIRB,   ATC5,   VIA1, 
                                      JFNO, CKIF,   FLTI, TERM,    STPO,   GENO,   DAIA,   CSS,    EDTA,   EDTD, 
                                      SP,   CDR,    CODT, CCDT,    SCDR,   SCODT,  SCCDT,  BRC1,   BROD,   BRCD, 
                                      SRC2, SBRO,   SBRC, GN,      GBS,    GODT,   GCDT,   SGN,    SGOD,   MFDI, 
                                      POCC, SGCD,   ASIA, APTIATA, REGN,   DRCT,   USEC,   TYPC,   CDAT,   USEU,   
                                      TYPU, LSTU, REMP, FLNO
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
                                             ,TRANSFERFLIGHTIDENTITY               
                            FROM   [AOC]
                            ORDER BY CDAT DESC, LSTU DESC";

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

        public static DataTable GetCombineAOCDatasDaily(DateTime date)
        {
            string sql = @"SELECT ID, STOD, TTYP, URNO, ORG3, DES3, LAND, AIRB, ATC5, VIA1, JFNO, CKIF, FLTI, TERM, STPO, GENO, DAIA, CSS, EDTA, EDTD, SP, CDR, CODT, CCDT, 
                      SCDR, SCODT, SCCDT, BRC1, BROD, BRCD, SRC2, SBRO, SBRC, GN, GBS, GODT, GCDT, SGN, SGOD, MFDI, POCC, SGCD, ASIA, APTIATA, REGN, 
                      DRCT, USEC, TYPC, CDAT, USEU, TYPU, LSTU, REMP, FLNO, CTRL
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
                                             ,TRANSFERFLIGHTIDENTITY                
                      FROM         dbo.AOC
                      WHERE     (URNO IN
                          (SELECT DISTINCT A.URNO
                            FROM          dbo.AOC AS A INNER JOIN
                                                   dbo.AOCFQS AS B ON A.DRCT = B.DRCT AND A.MFDI = B.MFDI
                            WHERE     (A.APTIATA = 'PVG') AND (A.STOD LIKE @stod) AND (CAST(B.SDT AS datetime) BETWEEN @sdtStart AND @sdtEnd)))";

            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@stod", string.Format("{0}%", date.ToString("yyyyMMdd")));
            para[1] = new SqlParameter("@sdtStart", date);
            para[2] = new SqlParameter("@sdtEnd", date.AddDays(1));

            DataSet ds = SqlHelper.ExecuteDataset(ConnectStringMsSql.GetConnection(), CommandType.Text, sql, para);

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
