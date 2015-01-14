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
            //��ȫCC���ֶ�
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
            //��ȫCC���ֶ�
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
        /// ��������ļƻ�����ʱ��
        /// </summary>        
        public string STOD
        {
            set { stod = value; }
            get { return stod; }
        }
        /// <summary>
        /// �ͻ�������
        /// </summary>        
        public string TTYP
        {
            set { ttyp = value; }
            get { return ttyp; }
        }
        /// <summary>
        /// ����Ψһ��ʶ
        /// </summary>        
        public string URNO
        {
            set { urno = value; }
            get { return urno; }
        }
        /// <summary>
        /// ���ﺽ���ǰվ��������
        /// </summary>        
        public string ORG3
        {
            set { org3 = value; }
            get { return org3; }
        }
        /// <summary>
        /// ���������Ŀ�Ļ���
        /// </summary>        
        public string DES3
        {
            set { des3 = value; }
            get { return des3; }
        }
        /// <summary>
        /// ʵ�ʵ���ʱ��
        /// </summary>        
        public string LAND
        {
            set { land = value; }
            get { return land; }
        }
        /// <summary>
        /// ʵ�ʳ���ʱ��
        /// </summary>        
        public string AIRB
        {
            set { airb = value; }
            get { return airb; }
        }
        /// <summary>
        /// ����
        /// </summary>        
        public string ATC5
        {
            set { atc5 = value; }
            get { return atc5; }
        }
        /// <summary>
        /// ��ͣ����
        /// </summary>        
        public string VIA1
        {
            set { via1 = value; }
            get { return via1; }
        }
        /// <summary>
        /// ��������
        /// </summary>        
        public string JFNO
        {
            set { jfno = value; }
            get { return jfno; }
        }
        /// <summary>
        /// ��Ʊ��̨
        /// </summary>        
        public string CKIF
        {
            set { ckif = value; }
            get { return ckif; }
        }
        /// <summary>
        /// ���δ��루D��ʾ���ڣ�I��ʾ���ʣ�R��ʾ����M��ʾ��ϣ�
        /// </summary>        
        public string FLTI
        {
            set { flti = value; }
            get { return flti; }
        }
        /// <summary>
        /// ���¥
        /// </summary>        
        public string TERM
        {
            set { term = value; }
            get { return term; }
        }
        /// <summary>
        /// ͣ��λ
        /// </summary>        
        public string STPO
        {
            set { stpo = value; }
            get { return stpo; }
        }
        /// <summary>
        /// �ǻ���
        /// </summary>        
        public string GENO
        {
            set { geno = value; }
            get { return geno; }
        }
        /// <summary>
        /// ��ת��������
        /// </summary>        
        public string DAIA
        {
            set { daia = value; }
            get { return daia; }
        }
        /// <summary>
        /// ���빲��״̬
        /// </summary>        
        public string CSS
        {
            set { css = value; }
            get { return css; }
        }
        /// <summary>
        /// ���������Ԥ�Ƴ���ʱ��
        /// </summary>        
        public string EDTA
        {
            set { edta = value; }
            get { return edta; }
        }
        /// <summary>
        /// ���ﺽ���Ԥ�Ƶ���ʱ��
        /// </summary>        
        public string EDTD
        {
            set { edtd = value; }
            get { return edtd; }
        }
        /// <summary>
        /// ͣ��λ
        /// </summary>        
        public string SP
        {
            set { sp = value; }
            get { return sp; }
        }
        /// <summary>
        /// ��Ʊ��̨
        /// </summary>        
        public string CDR
        {
            set { cdr = value; }
            get { return cdr; }
        }
        /// <summary>
        /// ��Ʊ��ʼʱ��
        /// </summary>        
        public string CODT
        {
            set { codt = value; }
            get { return codt; }
        }
        /// <summary>
        /// ��Ʊ����ʱ��
        /// </summary>        
        public string CCDT
        {
            set { ccdt = value; }
            get { return ccdt; }
        }
        /// <summary>
        /// �Ӱ�Ʊ��̨
        /// </summary>        
        public string SCDR
        {
            set { scdr = value; }
            get { return scdr; }
        }
        /// <summary>
        /// �Ӱ�Ʊ��̨��ʼʱ��
        /// </summary>        
        public string SCODT
        {
            set { scodt = value; }
            get { return scodt; }
        }
        /// <summary>
        /// �Ӱ�Ʊ��̨����ʱ��
        /// </summary>        
        public string SCCDT
        {
            set { sccdt = value; }
            get { return sccdt; }
        }
        /// <summary>
        /// ������ȡת�̴���
        /// </summary>        
        public string BRC1
        {
            set { brc1 = value; }
            get { return brc1; }
        }
        /// <summary>
        /// ������ȡת�̿�ʼʱ��
        /// </summary>        
        public string BROD
        {
            set { brod = value; }
            get { return brod; }
        }
        /// <summary>
        /// ������ȡת�̽���ʱ��
        /// </summary>        
        public string BRCD
        {
            set { brcd = value; }
            get { return brcd; }
        }
        /// <summary>
        /// ��������ȡת�̴���
        /// </summary>        
        public string SRC2
        {
            set { src2 = value; }
            get { return src2; }
        }
        /// <summary>
        /// ��������ȡת�̿�ʼʱ��
        /// </summary>        
        public string SBRO
        {
            set { sbro = value; }
            get { return sbro; }
        }
        /// <summary>
        /// ��������ȡת�̽���ʱ��
        /// </summary>        
        public string SBRC
        {
            set { sbrc = value; }
            get { return sbrc; }
        }
        /// <summary>
        /// �ǻ���
        /// </summary>        
        public string GN
        {
            set { gn = value; }
            get { return gn; }
        }
        /// <summary>
        /// �ǻ���״̬
        /// </summary>        
        public string GBS
        {
            set { gbs = value; }
            get { return gbs; }
        }
        /// <summary>
        /// �ǻ��ſ���ʱ��
        /// </summary>        
        public string GODT
        {
            set { godt = value; }
            get { return godt; }
        }
        /// <summary>
        /// �ǻ��Źر�ʱ��
        /// </summary>        
        public string GCDT
        {
            set { gcdt = value; }
            get { return gcdt; }
        }
        /// <summary>
        /// �ӵǻ���
        /// </summary>        
        public string SGN
        {
            set { sgn = value; }
            get { return sgn; }
        }
        /// <summary>
        /// �ӵǻ��ſ���ʱ��
        /// </summary>        
        public string SGOD
        {
            set { sgod = value; }
            get { return sgod; }
        }
        /// <summary>
        /// �����
        /// </summary>        
        public string MFDI
        {
            set { mfdi = value; }
            get { return mfdi; }
        }
        /// <summary>
        /// ��ͣ����
        /// </summary>        
        public string POCC
        {
            set { pocc = value; }
            get { return pocc; }
        }
        /// <summary>
        /// �ӵǻ��Źر�ʱ��
        /// </summary>        
        public string SGCD
        {
            set { sgcd = value; }
            get { return sgcd; }
        }
        /// <summary>
        /// ����
        /// </summary>        
        public string ASIA
        {
            set { asia = value; }
            get { return asia; }
        }
        /// <summary>
        /// ����������� PVG�ֶ� SHS����
        /// </summary>        
        public string APTIATA
        {
            set { aptIata = value; }
            get { return aptIata; }
        }
        /// <summary>
        /// ����ע���
        /// </summary>        
        public string REGN
        {
            set { regn = value; }
            get { return regn; }
        }
        /// <summary>
        /// ����۱�־λ,A���ۣ�D���
        /// </summary>        
        public string DRCT
        {
            set { drct = value; }
            get { return drct; }
        }
        /// <summary>
        /// ������
        /// </summary>        
        public string USEC
        {
            set { usec = value; }
            get { return usec; }
        }
        /// <summary>
        /// ��������,ITV(��ѯ),DAY(��)
        /// </summary>        
        public string TYPC
        {
            set { typc = value; }
            get { return typc; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>        
        public DateTime CDAT
        {
            set { cdat = value; }
            get { return cdat; }
        }
        /// <summary>
        /// ������
        /// </summary>        
        public string USEU
        {
            set { useu = value; }
            get { return useu; }
        }
        /// <summary>
        /// ��������,ITV(��ѯ),DAY(��)
        /// </summary>        
        public string TYPU
        {
            set { typu = value; }
            get { return typu; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>        
        public DateTime LSTU
        {
            set { lstu = value; }
            get { return lstu; }
        }
        /// <summary>
        /// ����״̬ (�հ׼�REGΪ����������ȡ����)
        /// </summary>  
        public string REMP
        {
            get { return remp; }
            set { remp = value; }
        }

        /// <summary>
        /// ��ǰ�����
        /// </summary>  
        public string FLNO
        {
            get { return flno; }
            set { flno = value; }
        }
        //��ȫCC���ֶ�
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
        ////��ȫCC���ֶ�
        #endregion

       
    }
}
