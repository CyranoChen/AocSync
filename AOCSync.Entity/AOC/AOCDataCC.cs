using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

using AOCSync.Entity.AOCEnum;
using AOCSync.Entity.Tools;

namespace AOCSync.Entity
{
    public class AOCDataCC : IComparable
    {
        public AOCDataCC() { }

        public AOCDataCC(DataRow dr)
        {
            initAoc(dr);
        }

        private void initAoc(DataRow dr)
        {
            if (dr == null)
            {
                throw new Exception("Unable to init AOCData.");
            }

            try
            {
                AOCID = new Guid(dr["ID"].ToString());


                STOD = dr["STOD"].ToString();
                TTYP = dr["TTYP"].ToString();
                URNO = dr["URNO"].ToString();
                ORG3 = dr["ORG3"].ToString();
                DES3 = dr["DES3"].ToString();
                LAND = dr["LAND"].ToString();
                AIRB = dr["AIRB"].ToString();
                ATC5 = dr["ATC5"].ToString();
                VIA1 = dr["VIA1"].ToString();
                JFNO = dr["JFNO"].ToString();
                CKIF = dr["CKIF"].ToString();
                FLTI = dr["FLTI"].ToString();
                TERM = dr["TERM"].ToString();
                STPO = dr["STPO"].ToString();
                GENO = dr["GENO"].ToString();
                DAIA = dr["DAIA"].ToString();
                CSS = dr["CSS"].ToString();
                EDTA = dr["EDTA"].ToString();
                EDTD = dr["EDTD"].ToString();
                SP = dr["SP"].ToString();
                CDR = dr["CDR"].ToString();
                CODT = dr["CODT"].ToString();
                CCDT = dr["CCDT"].ToString();
                SCDR = dr["SCDR"].ToString();
                SCODT = dr["SCODT"].ToString();
                SCCDT = dr["SCCDT"].ToString();
                BRC1 = dr["BRC1"].ToString();
                BROD = dr["BROD"].ToString();
                BRCD = dr["BRCD"].ToString();
                SRC2 = dr["SRC2"].ToString();
                SBRO = dr["SBRO"].ToString();
                SBRC = dr["SBRC"].ToString();
                GN = dr["GN"].ToString();
                GBS = dr["GBS"].ToString();
                GODT = dr["GODT"].ToString();
                GCDT = dr["GCDT"].ToString();
                SGN = dr["SGN"].ToString();
                SGOD = dr["SGOD"].ToString();
                MFDI = dr["MFDI"].ToString();
                POCC = dr["POCC"].ToString();
                SGCD = dr["SGCD"].ToString();
                ASIA = dr["ASIA"].ToString();
                APTIATA = dr["APTIATA"].ToString();
                REGN = dr["REGN"].ToString();
                DRCT = dr["DRCT"].ToString();
                USEC = dr["USEC"].ToString();
                TYPC = dr["TYPC"].ToString();
                CDAT = TextTool.GenerateDateTimeByObject(dr["CDAT"]);
                USEU = dr["USEU"].ToString();
                TYPU = dr["TYPU"].ToString();
                LSTU = TextTool.GenerateDateTimeByObject(dr["LSTU"]);
                REMP = dr["REMP"].ToString();
                FLNO = dr["FLNO"].ToString();
                //补全CC的字段
                ACTUALOFFBLOCKSDATETIME = dr["ACTUALOFFBLOCKSDATETIME"].ToString();
                ACTUALONBLOCKSDATETIME = dr["ACTUALONBLOCKSDATETIME"].ToString();
                AIRCRAFTTERMINALCODE = dr["AIRCRAFTTERMINALCODE"].ToString();
                BAGGAGERECLAIMCAROUSELROLE = dr["BAGGAGERECLAIMCAROUSELROLE"].ToString();
                ESTIMATEDFLIGHTDURATION = dr["ESTIMATEDFLIGHTDURATION"].ToString();
                FIRSTBAGDATETIME = dr["FIRSTBAGDATETIME"].ToString();
                LASTBAGDATETIME = dr["LASTBAGDATETIME"].ToString();
                LATESTKNOWNDATETIME = dr["LATESTKNOWNDATETIME"].ToString();
                LATESTKNOWNDATETIMESOURCE = dr["LATESTKNOWNDATETIMESOURCE"].ToString();
                NEXTSTATIONACTUALDATETIME = dr["NEXTSTATIONACTUALDATETIME"].ToString();
                NEXTSTATIONESTIMATEDDATETIME = dr["NEXTSTATIONESTIMATEDDATETIME"].ToString();
                NEXTSTATIONSCHEDULEDDATETIME = dr["NEXTSTATIONSCHEDULEDDATETIME"].ToString();
                OCCURDATETIME = dr["OCCURDATETIME"].ToString();
                PREVIOUSAIRBORNEDATETIME = dr["PREVIOUSAIRBORNEDATETIME"].ToString();
                PREVIOUSESTIMATEDDATETIME = dr["PREVIOUSESTIMATEDDATETIME"].ToString();
                PREVIOUSSCHEDULEDDATETIME = dr["PREVIOUSSCHEDULEDDATETIME"].ToString();
                SCHEDULEDDATE = dr["SCHEDULEDDATE"].ToString();
                SDBAGRECLAIMCAROUSELROLE = dr["SDBAGRECLAIMCAROUSELROLE"].ToString();
                SDFIRSTBAGDATETIME = dr["SDFIRSTBAGDATETIME"].ToString();
                SDLASTBAGDATETIME = dr["SDLASTBAGDATETIME"].ToString();
                SUPPLEMENTARYINFORMATION = dr["SUPPLEMENTARYINFORMATION"].ToString();
                SUPPLEMENTARYINFORMATIONTEXT = dr["SUPPLEMENTARYINFORMATIONTEXT"].ToString();
                CARRIERIATACODE = dr["CARRIERIATACODE"].ToString();
                CARRIERICAOCODE = dr["CARRIERICAOCODE"].ToString();
                FLIGHTCANCELCODE = dr["FLIGHTCANCELCODE"].ToString();
                FLIGHTFLAG = dr["FLIGHTFLAG"].ToString();
                FLIGHTNUMBER = dr["FLIGHTNUMBER"].ToString();
                FLIGHTREPEATCOUNT = dr["FLIGHTREPEATCOUNT"].ToString();
                FLIGHTSERVICETYPEIATACODE = dr["FLIGHTSERVICETYPEIATACODE"].ToString();
                FLIGHTSTATUSCODE = dr["FLIGHTSTATUSCODE"].ToString();
                FLIGHTSUFFIX = dr["FLIGHTSUFFIX"].ToString();
                FLIGHTTRANSITCODE = dr["FLIGHTTRANSITCODE"].ToString();
                ISGENERALAVIATIONFLIGHT = dr["ISGENERALAVIATIONFLIGHT"].ToString();
                ISRETURNFLIGHT = dr["ISRETURNFLIGHT"].ToString();
                NEWFLIGHTREASON = dr["NEWFLIGHTREASON"].ToString();
                TRANSFERFLIGHTIDENTITY = dr["TRANSFERFLIGHTIDENTITY"].ToString();
                //补全CC的字段
            }
            catch
            {
                throw new Exception("Init AocData Failed");
            }
        }

        public void Select()
        {
            DataRow dr = DataAccess.AOCDataCC.GetAOCDataByID(AOCID);

            if (dr != null)
            {
                initAoc(dr);
            }
        }

        public void Update()
        {
            DataAccess.AOCDataCC.UpdateAOCData(AOCID, STOD, TTYP, URNO, ORG3,
                                             DES3, LAND, AIRB, ATC5, VIA1,
                                             JFNO, CKIF, FLTI, TERM, STPO,
                                             GENO, DAIA, CSS, EDTA, EDTD,
                                             SP, CDR, CODT, CCDT, SCDR,
                                             SCODT, SCCDT, BRC1, BROD, BRCD,
                                             SRC2, SBRO, SBRC, GN, GBS,
                                             GODT, GCDT, SGN, SGOD, MFDI,
                                             POCC, SGCD, ASIA, APTIATA, REGN,
                                             DRCT, USEU, TYPU, LSTU, REMP, FLNO
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
                                             );
        }

        public void Update(SqlTransaction trans)
        {
            DataAccess.AOCDataCC.UpdateAOCData(AOCID, STOD, TTYP, URNO, ORG3,
                                             DES3, LAND, AIRB, ATC5, VIA1,
                                             JFNO, CKIF, FLTI, TERM, STPO,
                                             GENO, DAIA, CSS, EDTA, EDTD,
                                             SP, CDR, CODT, CCDT, SCDR,
                                             SCODT, SCCDT, BRC1, BROD, BRCD,
                                             SRC2, SBRO, SBRC, GN, GBS,
                                             GODT, GCDT, SGN, SGOD, MFDI,
                                             POCC, SGCD, ASIA, APTIATA, REGN,
                                             DRCT, USEU, TYPU, LSTU, REMP, FLNO
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
                                             , trans);
        }

        public void Insert()
        {
            DataAccess.AOCDataCC.InsertAOCData(STOD, TTYP, URNO, ORG3, DES3,
                                             LAND, AIRB, ATC5, VIA1, JFNO,
                                             CKIF, FLTI, TERM, STPO, GENO,
                                             DAIA, CSS, EDTA, EDTD, SP,
                                             CDR, CODT, CCDT, SCDR, SCODT,
                                             SCCDT, BRC1, BROD, BRCD, SRC2,
                                             SBRO, SBRC, GN, GBS, GODT,
                                             GCDT, SGN, SGOD, MFDI, POCC,
                                             SGCD, ASIA, APTIATA, REGN, DRCT,
                                             USEC, TYPC, CDAT, REMP, FLNO
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
                                             );
        }

        public void Insert(SqlTransaction trans)
        {
            DataAccess.AOCDataCC.InsertAOCData(STOD, TTYP, URNO, ORG3, DES3,
                                             LAND, AIRB, ATC5, VIA1, JFNO,
                                             CKIF, FLTI, TERM, STPO, GENO,
                                             DAIA, CSS, EDTA, EDTD, SP,
                                             CDR, CODT, CCDT, SCDR, SCODT,
                                             SCCDT, BRC1, BROD, BRCD, SRC2,
                                             SBRO, SBRC, GN, GBS, GODT,
                                             GCDT, SGN, SGOD, MFDI, POCC,
                                             SGCD, ASIA, APTIATA, REGN, DRCT,
                                             USEC, TYPC, CDAT, REMP, FLNO
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
                                             , trans);
        }

        public void Delete()
        {
            DataAccess.AOCDataCC.DeleteAOCData(AOCID);
        }

        public void Delete(SqlTransaction trans)
        {
            DataAccess.AOCDataCC.DeleteAOCData(AOCID, trans);
        }

        public static void DeleteAOCDataCCByDateTime(DateTime dateTimeStart, DateTime dateTimeEnd, SqlTransaction trans)
        {
            DataAccess.AOCDataCC.DeleteAOCData(dateTimeStart, dateTimeEnd, trans);
        }
        public static void DeleteAOCDataCCByDateTime( DateTime dateTimeEnd, SqlTransaction trans)
        {
            DataAccess.AOCDataCC.DeleteAOCData(dateTimeEnd, trans);
        }
        public static void DeleteAOCPVGDataCCByDateTime(DateTime dateTimeStart, DateTime dateTimeEnd, SqlTransaction trans)
        {
            DataAccess.AOCDataCC.DeleteAOPVGCData(dateTimeStart, dateTimeEnd, trans);
        }

        public static void DeleteAOCSHADataCCByDateTime(DateTime dateTimeStart, DateTime dateTimeEnd, SqlTransaction trans)
        {
            DataAccess.AOCDataCC.DeleteAOSHACData(dateTimeStart, dateTimeEnd, trans);
        }

        public static List<AOCDataCC> GetAOCDatas()
        {
            DataTable dt = DataAccess.AOCDataCC.GetAOCDatas();
            List<AOCDataCC> list = new List<AOCDataCC>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new AOCDataCC(dr));
                }
            }

            return list;
        }

        public static List<AOCDataCC> GetCombineAOCDatasDaily(DateTime date)
        {
            DataTable dt = DataAccess.AOCDataCC.GetCombineAOCDatasDaily(date);
            List<AOCDataCC> list = new List<AOCDataCC>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new AOCDataCC(dr));
                }
            }

            return list;
        }

        /// <summary>
        /// 获取AOC的所有属性
        /// </summary>
        /// <returns></returns>
        public static List<PropertyInfo> GetAOCProperties()
        {
            List<PropertyInfo> aocDataPropertiesList = new List<PropertyInfo>();
            Type typeAOC = typeof(AOCDataCC);

            foreach (PropertyInfo AOCProperty in typeAOC.GetProperties())
            {
                aocDataPropertiesList.Add(AOCProperty);
            }

            return aocDataPropertiesList;
        }

        /// <summary>
        /// AOCDataCache
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
                AOCDataList = GetAOCDatas();
                AOCDataPropertiesList = GetAOCProperties();
            }

            public static AOCDataCC Load(int aid)
            {
                return AOCDataList.Find(delegate(AOCDataCC a) { return a.AOCID.Equals(aid); });
            }

            /// <summary>
            /// AOC数据列表
            /// </summary>
            public static List<AOCDataCC> AOCDataList;

            /// <summary>
            /// AOC属性列表
            /// </summary>
            public static List<PropertyInfo> AOCDataPropertiesList;
        }

        #region AOC CC COLUMNS

        private Guid aocID;
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
        /// AOC数据库ID
        /// </summary>        
        public Guid AOCID
        {
            set { aocID = value; }
            get { return aocID; }
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
        /// 出发航班的预计到达时间
        /// </summary>        
        public string EDTA
        {
            set { edta = value; }
            get { return edta; }
        }
        /// <summary>
        /// 到达航班的预计出发时间
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

        #region 实现比较接口的CompareTo方法
        public int CompareTo(object obj)
        {
            int res = 0;
            try
            {
                AOCDataCC sObj = (AOCDataCC)obj;
                res = this.FLNO.CompareTo(sObj.FLNO);//当前航班号
                if (res == 0)
                {
                    res = this.STOD.CompareTo(sObj.STOD);//日期
                    if (res == 0)
                    {
                        res = this.DRCT.CompareTo(sObj.DRCT);//进出港
                        if (res == 0)
                        {
                            res = this.APTIATA.CompareTo(sObj.APTIATA);//所属机场                            
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception("比较异常", ex.InnerException);
            }
            return res;
        }
        #endregion

    }
}
