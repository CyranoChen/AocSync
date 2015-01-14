using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace AOCSync.Entity.Tools
{
    public class DataFileTool
    {
        /// <summary>
        /// ÿ��DAT���ݶ�������ͳһ��ǩ��Ϣ
        /// </summary>
        private const string DATAFILEDATESTANDARD = "   000000000000000000000000000";

        /// <summary>
        /// ��ָ���û�����DAT�ļ�
        /// </summary>
        /// <param name="listAOC">AOC�������б�</param>
        /// <param name="aocUser">AOC�û�</param>
        /// <param name="dateTimeCheckPoint">ʱ���,����ͬ�����ݶ�������һʱ��</param>
        /// <returns></returns>
        public static bool MakeDataFile(List<AOCDataCC> listAOC, AOCUserData aocUser, DateTime dateTimeCheckPoint, string filenametype)
        {
            //����DAT�ļ�����
            List<string> dataContentList = GenerateDataFileContent(listAOC, aocUser, dateTimeCheckPoint);
            //�����ļ�·��
            string filePath = GenerateDataFilePath(aocUser);
            //�����ļ���
            string fileName = GenerateDataFileName(filenametype, dateTimeCheckPoint);

            //�����ļ�
            return FileMakerTool.GenerateFile(filePath, fileName, dataContentList);
        }
        public static bool MakeDataFile(List<AOCCONBINE> listAOC, AOCUserData aocUser, DateTime dateTimeCheckPoint,string filenametype)
        {
            aocUser.loginfo.WriteLine("in MakeDataFile");
            bool ret = false;
            if (listAOC.Count>0)
            {
            //����DAT�ļ�����
            List<string> dataContentList = GenerateDataFileContent(listAOC, aocUser, dateTimeCheckPoint);
            //�����ļ�·��
            string filePath = GenerateDataFilePath(aocUser);
            //�����ļ���(����)
            string fileName = GenerateDataFileName( filenametype, dateTimeCheckPoint);

            //�����ļ�
            ret= FileMakerTool.GenerateFile(filePath, fileName, dataContentList);
            }
            else
            {
                Console.Write("no date to make file\r\n");
                aocUser.loginfo.WriteLine("no date to make file");               
            }
            aocUser.loginfo.WriteLine("leave MakeDataFile");  
            return ret;
        }

        /// <summary>
        /// ����DAT�ļ�����
        /// </summary>
        /// <param name="listAOC">AOC�������б�</param>
        /// <param name="aocUser">AOC�û�</param>
        /// <param name="dateTime">ʱ��㣬����ͬ�����ݶ�������һʱ��</param>
        /// <returns></returns>
        private static List<string> GenerateDataFileContent(List<AOCDataCC> listAOC, AOCUserData aocUser, DateTime dateTime)
        {
            //��ʼ��ͬ��ʱ���ַ��������ڸ�ÿ��DAT���ݴ�ʱ���ǩ
            string strDateTime = dateTime.ToString(TextTool.DATEFORMAT);
            //��������DAT���ݣ���ǩ+AOC����
            string dataResult = string.Empty;
            //����AOCDAT����
            string dataOneAOCData = string.Empty;
            //DAT���ݼ��ϣ�����ת���õ� ����DAT�������� ͳһ���������
            List<string> dataResultList = new List<string>();
            //AOC�û����Լ��ϣ���ȡ���û���Ҫͬ��AOC�е��ļ�������
            List<PropertyInfo> myAOCUserPropertiesList = GetAOCUserProperties(aocUser);

            //����ִ��,��ÿ��AOC���ݸ����û�������ת����DAT���ݣ�������DAT���ݼ���
            for (int i = 0; i < listAOC.Count; i++)
            {
                //ת��
                dataOneAOCData = GetDataByAOCData(myAOCUserPropertiesList, listAOC[i]);
                dataResult = string.Format("{0}{1}{2}", strDateTime, DATAFILEDATESTANDARD, dataOneAOCData);

                //���뼯��
                dataResultList.Add(dataResult);
            }
            return dataResultList;
        }
        private static List<string> GenerateDataFileContent(List<AOCCONBINE> listAOC, AOCUserData aocUser, DateTime dateTime)
        {
            aocUser.loginfo.WriteLine("in GenerateDataFileContent");
            //��ʼ��ͬ��ʱ���ַ��������ڸ�ÿ��DAT���ݴ�ʱ���ǩ
            string strDateTime = dateTime.ToString(TextTool.DATEFORMAT);
            //��������DAT���ݣ���ǩ+AOC����
            string dataResult = string.Empty;
            //����AOCDAT����
            string dataOneAOCData = string.Empty;
            //DAT���ݼ��ϣ�����ת���õ� ����DAT�������� ͳһ���������
            List<string> dataResultList = new List<string>();
            //AOC�û����Լ��ϣ���ȡ���û���Ҫͬ��AOC�е��ļ�������
            List<PropertyInfo> myAOCUserPropertiesList = GetAOCUserProperties(aocUser);

            //����ִ��,��ÿ��AOC���ݸ����û�������ת����DAT���ݣ�������DAT���ݼ���
            for (int i = 0; i < listAOC.Count; i++)
            {
                //ת��
                dataOneAOCData = GetDataByAOCData(myAOCUserPropertiesList, listAOC[i]);
                dataResult = string.Format("{0}{1}{2}", strDateTime, DATAFILEDATESTANDARD, dataOneAOCData);

                //���뼯��
                dataResultList.Add(dataResult);
            }
            aocUser.loginfo.WriteLine("leave GenerateDataFileContent");
            return dataResultList;
        }

        /// <summary>
        /// ��ȡ�ļ���
        /// </summary>
        /// <param name="aocUser">AOC�û�</param>
        /// <param name="dateTimeCheckPoint">ʱ���</param>
        /// <returns></returns>
        private static string GenerateDataFileName( string filenametype, DateTime dateTimeCheckPoint)
        {
            string path = string.Format("{0}{1}{2}.dat", filenametype, "_atc", dateTimeCheckPoint.ToString(TextTool.DATEFORMAT));
            return path;
        }

        /// <summary>
        /// �����ļ�·�������·��
        /// </summary>
        /// <returns></returns>
        private static string GenerateDataFilePath(AOCUserData aocUser)
        {
            return "DAT/" + aocUser.UserName;
        }

        /// <summary>
        /// return AOC properties of one user
        /// </summary>
        /// <param name="aocUser"></param>
        /// <returns></returns>
        private static List<PropertyInfo> GetAOCUserProperties(AOCUserData aocUser)
        {
            if (string.IsNullOrEmpty(aocUser.ExportColumns) || (aocUser.ExportColumns.Contains(",") == false))
            {
                return null;
            }

            string[] exportColumns = aocUser.ExportColumns.Split(',');
            List<PropertyInfo> AOCUserProperties = new List<PropertyInfo>();
            List<PropertyInfo> AOCCONBINEDataPropertiesList = AOCCONBINE.GetAOCCONBINEProperties();
            foreach (string columns in exportColumns)
            {
                if (AOCCONBINEDataPropertiesList.Exists(delegate(PropertyInfo propertyInList) { return propertyInList.Name.Equals(columns); }))
                {
                    PropertyInfo propertyAOC = AOCCONBINEDataPropertiesList.Find(delegate(PropertyInfo propertyInList) { return propertyInList.Name.Equals(columns); });
                    AOCUserProperties.Add(propertyAOC);                    
                }
            }

            return AOCUserProperties;
        }

        /// <summary>
        /// ������AOC����ת��ΪDAT��������
        /// </summary>
        /// <param name="aocUserPropertyList">���е������м���</param>
        /// <param name="aocData">����AOC����</param>
        /// <returns></returns>
        private static string GetDataByAOCData(List<PropertyInfo> aocUserPropertyList, AOCDataCC aocData)
        {
            //����������ǩ������DAT���ݸ�ʽ�ο���
            //#ADID#A#FLNO#SC4865#REMP##STOA#20130728180000#STOD##TTYP#PAX#URNO#6701861#ORG3#YNT#DES3#SHA#LAND##AIRB##ATC5#733#VIA1##JFNO##CKIF# #CKIT# #FLTI#D#TERM#2#STPO# #GENO# #DAIA# #CSS#01#EDTA##EDTD##SP# #CDR# #CODT# #CCDT# #SCDR# #SCODT# #SCCDT# #BRC1# #BROD# #BRCD# #SRC2# #SBRO# #SBRC# #GN# #GBS# #GODT# #GCDT# #SGN# #SGOD# #MFDI#SC4865#POCC##SGCD# #ASIA#733
            string result = string.Empty;
            string propertyValue = string.Empty;

            foreach (PropertyInfo property in aocUserPropertyList)
            {
                propertyValue = aocData.GetType().GetProperty(property.Name).GetValue(aocData, null).ToString();
                result += string.Format("#{0}#{1}", property.Name, propertyValue);
            }

            return result;
        }
        private static string GetDataByAOCData(List<PropertyInfo> aocUserPropertyList, AOCCONBINE aocData)
        {
            //����������ǩ������DAT���ݸ�ʽ�ο���
            //#ADID#A#FLNO#SC4865#REMP##STOA#20130728180000#STOD##TTYP#PAX#URNO#6701861#ORG3#YNT#DES3#SHA#LAND##AIRB##ATC5#733#VIA1##JFNO##CKIF# #CKIT# #FLTI#D#TERM#2#STPO# #GENO# #DAIA# #CSS#01#EDTA##EDTD##SP# #CDR# #CODT# #CCDT# #SCDR# #SCODT# #SCCDT# #BRC1# #BROD# #BRCD# #SRC2# #SBRO# #SBRC# #GN# #GBS# #GODT# #GCDT# #SGN# #SGOD# #MFDI#SC4865#POCC##SGCD# #ASIA#733
            string result = string.Empty;
            string propertyValue = string.Empty;
            string propertyShowName = string.Empty;
            foreach (PropertyInfo property in aocUserPropertyList)
            {
                propertyValue = aocData.GetType().GetProperty(property.Name).GetValue(aocData, null).ToString();
                propertyShowName = AOCCONBINE.ShowName(property.Name.ToString());
                if (string.IsNullOrEmpty(propertyShowName))
                {
                    propertyShowName = property.Name;
                }
                result += string.Format("#{0}#{1}", propertyShowName, propertyValue);
            }

            return result;
        }

    }
}
