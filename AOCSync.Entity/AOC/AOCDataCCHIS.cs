using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace AOCSync.Entity
{
    public class AOCDataCCHIS
    {
        public AOCDataCCHIS() { }

        public void Insert()
        {
           Insert(null);
        }
        public void Insert(SqlTransaction trans)
        {
            DataAccess.AOCDataCCHIS.InsertAOCDataCCHIS(AOCHISID, STOD, TTYP, URNO, ORG3,
                                                DES3, LAND, AIRB, ATC5, VIA1,
                                                JFNO, CKIF, FLTI, TERM, STPO,
                                                GENO, DAIA, CSS, EDTA, EDTD,
                                                SP, CDR, CODT, CCDT, SCDR,
                                                SCODT, SCCDT, BRC1, BROD, BRCD,
                                                SRC2, SBRO, SBRC, GN, GBS,
                                                GODT, GCDT, SGN, SGOD, MFDI,
                                                POCC, SGCD, ASIA, APTIATA, REGN,
                                                DRCT, USEC, TYPC, CDAT, USEU,
                                                TYPU, LSTU, REMP, FLNO
                                             , ACTUALOFFBLOCKSDATETIME
                                             , ACTUALONBLOCKSDATETIME
                                             , AIRCRAFTTERMINALCODE
                                             , BAGGAGERECLAIMCAROUSELROLE
                                             , ESTIMATEDFLIGHTDURATION
                                             , FIRSTBAGDATETIME
                                             , LASTBAGDATETIME
                                             , LATESTKNOWNDATETIME
                                             , LATESTKNOWNDATETIMESOURCE
                                             , NEXTSTATIONACTUALDATETIME
                                             , NEXTSTATIONESTIMATEDDATETIME
                                             , NEXTSTATIONSCHEDULEDDATETIME
                                             , OCCURDATETIME
                                             , PREVIOUSAIRBORNEDATETIME
                                             , PREVIOUSESTIMATEDDATETIME
                                             , PREVIOUSSCHEDULEDDATETIME
                                             , SCHEDULEDDATE
                                             , SDBAGRECLAIMCAROUSELROLE
                                             , SDFIRSTBAGDATETIME
                                             , SDLASTBAGDATETIME
                                             , SUPPLEMENTARYINFORMATION
                                             , SUPPLEMENTARYINFORMATIONTEXT
                                             , CARRIERIATACODE
                                             , CARRIERICAOCODE
                                             , FLIGHTCANCELCODE
                                             , FLIGHTFLAG
                                             , FLIGHTNUMBER
                                             , FLIGHTREPEATCOUNT
                                             , FLIGHTSERVICETYPEIATACODE
                                             , FLIGHTSTATUSCODE
                                             , FLIGHTSUFFIX
                                             , FLIGHTTRANSITCODE
                                             , ISGENERALAVIATIONFLIGHT
                                             , ISRETURNFLIGHT
                                             , NEWFLIGHTREASON
                                             , TRANSFERFLIGHTIDENTITY               
                                             ,trans);
        }
        public static void GenerateAOCDataCCHISByAOCData(List<AOCDataCC> aocDataList, SqlTransaction trans)
        {
            foreach (AOCDataCC aocData in aocDataList)
            {
                GenerateAOCDataCCHISByAOCDataCC(aocData, trans);
            }
        }
        private static void GenerateAOCDataCCHISByAOCDataCC(AOCDataCC aocData, SqlTransaction trans)
        {
           AOCDataCCHIS aocHisData = new AOCDataCCHIS();
           aocHisData.TransferToAOCDataCCHISByAOCDataCC(aocData);
           aocHisData.Insert(trans);           
        }
       

        public void TransferToAOCDataCCHISByAOCDataCC(AOCDataCC aocData)
        {
            AOCHISID = aocData.AOCID.ToString();
            STOD = aocData.STOD;
            TTYP = aocData.TTYP;
            URNO = aocData.URNO;
            ORG3 = aocData.ORG3;
            DES3 = aocData.DES3;
            LAND = aocData.LAND;
            AIRB = aocData.AIRB;
            ATC5 = aocData.ATC5;
            VIA1 = aocData.VIA1;
            JFNO = aocData.JFNO;
            CKIF = aocData.CKIF;
            FLTI = aocData.FLTI;
            TERM = aocData.TERM;
            STPO = aocData.STPO;
            GENO = aocData.GENO;
            DAIA = aocData.DAIA;
            CSS = aocData.CSS;
            EDTA = aocData.EDTA;
            EDTD = aocData.EDTD;
            SP = aocData.SP;
            CDR = aocData.CDR;
            CODT = aocData.CODT;
            CCDT = aocData.CCDT;
            SCDR = aocData.SCDR;
            SCODT = aocData.SCODT;
            SCCDT = aocData.SCCDT;
            BRC1 = aocData.BRC1;
            BROD = aocData.BROD;
            BRCD = aocData.BRCD;
            SRC2 = aocData.SRC2;
            SBRO = aocData.SBRO;
            SBRC = aocData.SBRC;
            GN = aocData.GN;
            GBS = aocData.GBS;
            GODT = aocData.GODT;
            GCDT = aocData.GCDT;
            SGN = aocData.SGN;
            SGOD = aocData.SGOD;
            MFDI = aocData.MFDI;
            POCC = aocData.POCC;
            SGCD = aocData.SGCD;
            ASIA = aocData.ASIA;
            APTIATA = aocData.APTIATA;
            REGN = aocData.REGN;
            DRCT = aocData.DRCT;
            USEC = aocData.USEC;
            TYPC = aocData.TYPC;
            CDAT = aocData.CDAT;
            USEU = aocData.USEU;
            TYPU = aocData.TYPU;
            REMP = aocData.REMP;
            FLNO = aocData.FLNO;
            
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
            //补全CC的字段
            ACTUALOFFBLOCKSDATETIME = aocData.ACTUALOFFBLOCKSDATETIME;
            ACTUALONBLOCKSDATETIME = aocData.ACTUALONBLOCKSDATETIME;
            AIRCRAFTTERMINALCODE = aocData.AIRCRAFTTERMINALCODE;
            BAGGAGERECLAIMCAROUSELROLE = aocData.BAGGAGERECLAIMCAROUSELROLE;
            ESTIMATEDFLIGHTDURATION = aocData.ESTIMATEDFLIGHTDURATION;
            FIRSTBAGDATETIME = aocData.FIRSTBAGDATETIME;
            LASTBAGDATETIME = aocData.LASTBAGDATETIME;
            LATESTKNOWNDATETIME = aocData.LATESTKNOWNDATETIME;
            LATESTKNOWNDATETIMESOURCE = aocData.LATESTKNOWNDATETIMESOURCE;
            NEXTSTATIONACTUALDATETIME = aocData.NEXTSTATIONACTUALDATETIME;
            NEXTSTATIONESTIMATEDDATETIME = aocData.NEXTSTATIONESTIMATEDDATETIME;
            NEXTSTATIONSCHEDULEDDATETIME = aocData.NEXTSTATIONSCHEDULEDDATETIME;
            OCCURDATETIME = aocData.OCCURDATETIME;
            PREVIOUSAIRBORNEDATETIME = aocData.PREVIOUSAIRBORNEDATETIME;
            PREVIOUSESTIMATEDDATETIME = aocData.PREVIOUSESTIMATEDDATETIME;
            PREVIOUSSCHEDULEDDATETIME = aocData.PREVIOUSSCHEDULEDDATETIME;
            SCHEDULEDDATE = aocData.SCHEDULEDDATE;
            SDBAGRECLAIMCAROUSELROLE = aocData.SDBAGRECLAIMCAROUSELROLE;
            SDFIRSTBAGDATETIME = aocData.SDFIRSTBAGDATETIME;
            SDLASTBAGDATETIME = aocData.SDLASTBAGDATETIME;
            SUPPLEMENTARYINFORMATION = aocData.SUPPLEMENTARYINFORMATION;
            SUPPLEMENTARYINFORMATIONTEXT = aocData.SUPPLEMENTARYINFORMATIONTEXT;
            CARRIERIATACODE = aocData.CARRIERIATACODE;
            CARRIERICAOCODE = aocData.CARRIERICAOCODE;
            FLIGHTCANCELCODE = aocData.FLIGHTCANCELCODE;
            FLIGHTFLAG = aocData.FLIGHTFLAG;
            FLIGHTNUMBER = aocData.FLIGHTNUMBER;
            FLIGHTREPEATCOUNT = aocData.FLIGHTREPEATCOUNT;
            FLIGHTSERVICETYPEIATACODE = aocData.FLIGHTSERVICETYPEIATACODE;
            FLIGHTSTATUSCODE = aocData.FLIGHTSTATUSCODE;
            FLIGHTSUFFIX = aocData.FLIGHTSUFFIX;
            FLIGHTTRANSITCODE = aocData.FLIGHTTRANSITCODE;
            ISGENERALAVIATIONFLIGHT = aocData.ISGENERALAVIATIONFLIGHT;
            ISRETURNFLIGHT = aocData.ISRETURNFLIGHT;
            NEWFLIGHTREASON = aocData.NEWFLIGHTREASON;
            TRANSFERFLIGHTIDENTITY = aocData.TRANSFERFLIGHTIDENTITY;
            //补全CC的字段
        }

        #region AOCCCHIS COLUMNS

        private string aocHisID;
        private string stod;
        private string ttyp;
        private string urno;
        private string org3;
        private string des3;
        private string land;
        private string airb;
        private string atc5;
        private string via1;
        private string jfno;
        private string ckif;
        private string flti;
        private string term;
        private string stpo;
        private string geno;
        private string daia;
        private string css;
        private string edta;
        private string edtd;
        private string sp;
        private string cdr;
        private string codt;
        private string ccdt;
        private string scdr;
        private string scodt;
        private string sccdt;
        private string brc1;
        private string brod;
        private string brcd;
        private string src2;
        private string sbro;
        private string sbrc;
        private string gn;
        private string gbs;
        private string godt;
        private string gcdt;
        private string sgn;
        private string sgod;
        private string mfdi;
        private string pocc;
        private string sgcd;
        private string asia;
        private string aptIata;
        private string regn;
        private string drct;
        private string usec;
        private string typc;
        private DateTime cdat;
        private string useu;
        private string typu;
        private DateTime lstu;
        private string remp;
        private string flno;

        /// <summary>
        /// AOCHIS ID
        /// </summary>        
        public string AOCHISID
        {
            set { aocHisID = value; }
            get { return aocHisID; }
        }
        /// <summary>
        /// 出发航班的计划出发时间
        /// </summary>        
        public string STOD
        {
            set { stod = value; }
            get { return stod; }
        }
        /// <summary>
        /// 客货班性质
        /// </summary>        
        public string TTYP
        {
            set { ttyp = value; }
            get { return ttyp; }
        }
        /// <summary>
        /// 航班唯一标识
        /// </summary>        
        public string URNO
        {
            set { urno = value; }
            get { return urno; }
        }
        /// <summary>
        /// 到达航班的前站出发机场
        /// </summary>        
        public string ORG3
        {
            set { org3 = value; }
            get { return org3; }
        }
        /// <summary>
        /// 出发航班的目的机场
        /// </summary>        
        public string DES3
        {
            set { des3 = value; }
            get { return des3; }
        }
        /// <summary>
        /// 实际到达时间
        /// </summary>        
        public string LAND
        {
            set { land = value; }
            get { return land; }
        }
        /// <summary>
        /// 实际出发时间
        /// </summary>        
        public string AIRB
        {
            set { airb = value; }
            get { return airb; }
        }
        /// <summary>
        /// 机型
        /// </summary>        
        public string ATC5
        {
            set { atc5 = value; }
            get { return atc5; }
        }
        /// <summary>
        /// 经停机场
        /// </summary>        
        public string VIA1
        {
            set { via1 = value; }
            get { return via1; }
        }
        /// <summary>
        /// 暂无类型
        /// </summary>        
        public string JFNO
        {
            set { jfno = value; }
            get { return jfno; }
        }
        /// <summary>
        /// 办票柜台
        /// </summary>        
        public string CKIF
        {
            set { ckif = value; }
            get { return ckif; }
        }
        /// <summary>
        /// 航段代码（D表示国内，I表示国际，R表示区域，M表示混合）
        /// </summary>        
        public string FLTI
        {
            set { flti = value; }
            get { return flti; }
        }
        /// <summary>
        /// 候机楼
        /// </summary>        
        public string TERM
        {
            set { term = value; }
            get { return term; }
        }
        /// <summary>
        /// 停机位
        /// </summary>        
        public string STPO
        {
            set { stpo = value; }
            get { return stpo; }
        }
        /// <summary>
        /// 登机门
        /// </summary>        
        public string GENO
        {
            set { geno = value; }
            get { return geno; }
        }
        /// <summary>
        /// 中转机场代码
        /// </summary>        
        public string DAIA
        {
            set { daia = value; }
            get { return daia; }
        }
        /// <summary>
        /// 代码共享状态
        /// </summary>        
        public string CSS
        {
            set { css = value; }
            get { return css; }
        }
        /// <summary>
        /// 出发航班的预计出发时间
        /// </summary>        
        public string EDTA
        {
            set { edta = value; }
            get { return edta; }
        }
        /// <summary>
        /// 到达航班的预计到达时间
        /// </summary>        
        public string EDTD
        {
            set { edtd = value; }
            get { return edtd; }
        }
        /// <summary>
        /// 停机位
        /// </summary>        
        public string SP
        {
            set { sp = value; }
            get { return sp; }
        }
        /// <summary>
        /// 办票柜台
        /// </summary>        
        public string CDR
        {
            set { cdr = value; }
            get { return cdr; }
        }
        /// <summary>
        /// 办票开始时间
        /// </summary>        
        public string CODT
        {
            set { codt = value; }
            get { return codt; }
        }
        /// <summary>
        /// 办票结束时间
        /// </summary>        
        public string CCDT
        {
            set { ccdt = value; }
            get { return ccdt; }
        }
        /// <summary>
        /// 从办票柜台
        /// </summary>        
        public string SCDR
        {
            set { scdr = value; }
            get { return scdr; }
        }
        /// <summary>
        /// 从办票柜台开始时间
        /// </summary>        
        public string SCODT
        {
            set { scodt = value; }
            get { return scodt; }
        }
        /// <summary>
        /// 从办票柜台结束时间
        /// </summary>        
        public string SCCDT
        {
            set { sccdt = value; }
            get { return sccdt; }
        }
        /// <summary>
        /// 行李提取转盘代码
        /// </summary>        
        public string BRC1
        {
            set { brc1 = value; }
            get { return brc1; }
        }
        /// <summary>
        /// 行李提取转盘开始时间
        /// </summary>        
        public string BROD
        {
            set { brod = value; }
            get { return brod; }
        }
        /// <summary>
        /// 行李提取转盘结束时间
        /// </summary>        
        public string BRCD
        {
            set { brcd = value; }
            get { return brcd; }
        }
        /// <summary>
        /// 从行李提取转盘代码
        /// </summary>        
        public string SRC2
        {
            set { src2 = value; }
            get { return src2; }
        }
        /// <summary>
        /// 从行李提取转盘开始时间
        /// </summary>        
        public string SBRO
        {
            set { sbro = value; }
            get { return sbro; }
        }
        /// <summary>
        /// 从行李提取转盘结束时间
        /// </summary>        
        public string SBRC
        {
            set { sbrc = value; }
            get { return sbrc; }
        }
        /// <summary>
        /// 登机门
        /// </summary>        
        public string GN
        {
            set { gn = value; }
            get { return gn; }
        }
        /// <summary>
        /// 登机门状态
        /// </summary>        
        public string GBS
        {
            set { gbs = value; }
            get { return gbs; }
        }
        /// <summary>
        /// 登机门开放时间
        /// </summary>        
        public string GODT
        {
            set { godt = value; }
            get { return godt; }
        }
        /// <summary>
        /// 登机门关闭时间
        /// </summary>        
        public string GCDT
        {
            set { gcdt = value; }
            get { return gcdt; }
        }
        /// <summary>
        /// 从登机门
        /// </summary>        
        public string SGN
        {
            set { sgn = value; }
            get { return sgn; }
        }
        /// <summary>
        /// 从登机门开放时间
        /// </summary>        
        public string SGOD
        {
            set { sgod = value; }
            get { return sgod; }
        }
        /// <summary>
        /// 航班号
        /// </summary>        
        public string MFDI
        {
            set { mfdi = value; }
            get { return mfdi; }
        }
        /// <summary>
        /// 经停机场
        /// </summary>        
        public string POCC
        {
            set { pocc = value; }
            get { return pocc; }
        }
        /// <summary>
        /// 从登机门关闭时间
        /// </summary>        
        public string SGCD
        {
            set { sgcd = value; }
            get { return sgcd; }
        }
        /// <summary>
        /// 机型
        /// </summary>        
        public string ASIA
        {
            set { asia = value; }
            get { return asia; }
        }
        /// <summary>
        /// 航班归属机场 PVG浦东 SHS虹桥
        /// </summary>        
        public string APTIATA
        {
            set { aptIata = value; }
            get { return aptIata; }
        }
        /// <summary>
        /// 航班注册号
        /// </summary>        
        public string REGN
        {
            set { regn = value; }
            get { return regn; }
        }
        /// <summary>
        /// 进离港标志位,A进港，D离港
        /// </summary>        
        public string DRCT
        {
            set { drct = value; }
            get { return drct; }
        }
        /// <summary>
        /// 创建人
        /// </summary>        
        public string USEC
        {
            set { usec = value; }
            get { return usec; }
        }
        /// <summary>
        /// 创建类型,ITV(轮询),DAY(日)
        /// </summary>        
        public string TYPC
        {
            set { typc = value; }
            get { return typc; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>        
        public DateTime CDAT
        {
            set { cdat = value; }
            get { return cdat; }
        }
        /// <summary>
        /// 更新人
        /// </summary>        
        public string USEU
        {
            set { useu = value; }
            get { return useu; }
        }
        /// <summary>
        /// 更新类型,ITV(轮询),DAY(日)
        /// </summary>        
        public string TYPU
        {
            set { typu = value; }
            get { return typu; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>        
        public DateTime LSTU
        {
            set { lstu = value; }
            get { return lstu; }
        }
        /// <summary>
        /// 航班状态 (空白及REG为正常，延误、取消等)
        /// </summary>  
        public string REMP
        {
            get { return remp; }
            set { remp = value; }
        }

        /// <summary>
        /// 当前航班号
        /// </summary>  
        public string FLNO
        {
            get { return flno; }
            set { flno = value; }
        }
        //补全CC的字段
        private string actualoffblocksdatetime;
        private string actualonblocksdatetime;
        private string aircraftterminalcode;
        private string baggagereclaimcarouselrole;
        private string estimatedflightduration;
        private string firstbagdatetime;
        private string lastbagdatetime;
        private string latestknowndatetime;
        private string latestknowndatetimesource;
        private string nextstationactualdatetime;
        private string nextstationestimateddatetime;
        private string nextstationscheduleddatetime;
        private string occurdatetime;
        private string previousairbornedatetime;
        private string previousestimateddatetime;
        private string previousscheduleddatetime;
        private string scheduleddate;
        private string sdbagreclaimcarouselrole;
        private string sdfirstbagdatetime;
        private string sdlastbagdatetime;
        private string supplementaryinformation;
        private string supplementaryinformationtext;
        private string carrieriatacode;
        private string carriericaocode;
        private string flightcancelcode;
        private string flightflag;
        private string flightnumber;
        private string flightrepeatcount;
        private string flightservicetypeiatacode;
        private string flightstatuscode;
        private string flightsuffix;
        private string flighttransitcode;
        private string isgeneralaviationflight;
        private string isreturnflight;
        private string newflightreason;
        private string transferflightidentity;
        public string ACTUALOFFBLOCKSDATETIME { set { actualoffblocksdatetime = value; } get { return actualoffblocksdatetime; } }
        public string ACTUALONBLOCKSDATETIME { set { actualonblocksdatetime = value; } get { return actualonblocksdatetime; } }
        public string AIRCRAFTTERMINALCODE { set { aircraftterminalcode = value; } get { return aircraftterminalcode; } }
        public string BAGGAGERECLAIMCAROUSELROLE { set { baggagereclaimcarouselrole = value; } get { return baggagereclaimcarouselrole; } }
        public string ESTIMATEDFLIGHTDURATION { set { estimatedflightduration = value; } get { return estimatedflightduration; } }
        public string FIRSTBAGDATETIME { set { firstbagdatetime = value; } get { return firstbagdatetime; } }
        public string LASTBAGDATETIME { set { lastbagdatetime = value; } get { return lastbagdatetime; } }
        public string LATESTKNOWNDATETIME { set { latestknowndatetime = value; } get { return latestknowndatetime; } }
        public string LATESTKNOWNDATETIMESOURCE { set { latestknowndatetimesource = value; } get { return latestknowndatetimesource; } }
        public string NEXTSTATIONACTUALDATETIME { set { nextstationactualdatetime = value; } get { return nextstationactualdatetime; } }
        public string NEXTSTATIONESTIMATEDDATETIME { set { nextstationestimateddatetime = value; } get { return nextstationestimateddatetime; } }
        public string NEXTSTATIONSCHEDULEDDATETIME { set { nextstationscheduleddatetime = value; } get { return nextstationscheduleddatetime; } }
        public string OCCURDATETIME { set { occurdatetime = value; } get { return occurdatetime; } }
        public string PREVIOUSAIRBORNEDATETIME { set { previousairbornedatetime = value; } get { return previousairbornedatetime; } }
        public string PREVIOUSESTIMATEDDATETIME { set { previousestimateddatetime = value; } get { return previousestimateddatetime; } }
        public string PREVIOUSSCHEDULEDDATETIME { set { previousscheduleddatetime = value; } get { return previousscheduleddatetime; } }
        public string SCHEDULEDDATE { set { scheduleddate = value; } get { return scheduleddate; } }
        public string SDBAGRECLAIMCAROUSELROLE { set { sdbagreclaimcarouselrole = value; } get { return sdbagreclaimcarouselrole; } }
        public string SDFIRSTBAGDATETIME { set { sdfirstbagdatetime = value; } get { return sdfirstbagdatetime; } }
        public string SDLASTBAGDATETIME { set { sdlastbagdatetime = value; } get { return sdlastbagdatetime; } }
        public string SUPPLEMENTARYINFORMATION { set { supplementaryinformation = value; } get { return supplementaryinformation; } }
        public string SUPPLEMENTARYINFORMATIONTEXT { set { supplementaryinformationtext = value; } get { return supplementaryinformationtext; } }
        public string CARRIERIATACODE { set { carrieriatacode = value; } get { return carrieriatacode; } }
        public string CARRIERICAOCODE { set { carriericaocode = value; } get { return carriericaocode; } }
        public string FLIGHTCANCELCODE { set { flightcancelcode = value; } get { return flightcancelcode; } }
        public string FLIGHTFLAG { set { flightflag = value; } get { return flightflag; } }
        public string FLIGHTNUMBER { set { flightnumber = value; } get { return flightnumber; } }
        public string FLIGHTREPEATCOUNT { set { flightrepeatcount = value; } get { return flightrepeatcount; } }
        public string FLIGHTSERVICETYPEIATACODE { set { flightservicetypeiatacode = value; } get { return flightservicetypeiatacode; } }
        public string FLIGHTSTATUSCODE { set { flightstatuscode = value; } get { return flightstatuscode; } }
        public string FLIGHTSUFFIX { set { flightsuffix = value; } get { return flightsuffix; } }
        public string FLIGHTTRANSITCODE { set { flighttransitcode = value; } get { return flighttransitcode; } }
        public string ISGENERALAVIATIONFLIGHT { set { isgeneralaviationflight = value; } get { return isgeneralaviationflight; } }
        public string ISRETURNFLIGHT { set { isreturnflight = value; } get { return isreturnflight; } }
        public string NEWFLIGHTREASON { set { newflightreason = value; } get { return newflightreason; } }
        public string TRANSFERFLIGHTIDENTITY { set { transferflightidentity = value; } get { return transferflightidentity; } }
        ////补全CC的字段
        #endregion

       
    }
}
