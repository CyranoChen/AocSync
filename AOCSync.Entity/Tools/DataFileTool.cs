using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace AOCSync.Entity.Tools
{
    public class DataFileTool
    {
        /// <summary>
        /// 每条DAT数据都包含的统一标签信息
        /// </summary>
        private const string DATAFILEDATESTANDARD = "   000000000000000000000000000";

        /// <summary>
        /// 给指定用户生成DAT文件
        /// </summary>
        /// <param name="listAOC">AOC库数据列表</param>
        /// <param name="aocUser">AOC用户</param>
        /// <param name="dateTimeCheckPoint">时间点,此批同步数据都是用这一时间</param>
        /// <returns></returns>
        public static bool MakeDataFile(List<AOCDataCC> listAOC, AOCUserData aocUser, DateTime dateTimeCheckPoint, string filenametype)
        {
            //生成DAT文件内容
            List<string> dataContentList = GenerateDataFileContent(listAOC, aocUser, dateTimeCheckPoint);
            //生成文件路径
            string filePath = GenerateDataFilePath(aocUser);
            //生成文件名
            string fileName = GenerateDataFileName(filenametype, dateTimeCheckPoint);

            //生成文件
            return FileMakerTool.GenerateFile(filePath, fileName, dataContentList);
        }
        public static bool MakeDataFile(List<AOCCONBINE> listAOC, AOCUserData aocUser, DateTime dateTimeCheckPoint,string filenametype)
        {
            aocUser.loginfo.WriteLine("in MakeDataFile");
            bool ret = false;
            if (listAOC.Count>0)
            {
            //生成DAT文件内容
            List<string> dataContentList = GenerateDataFileContent(listAOC, aocUser, dateTimeCheckPoint);
            //生成文件路径
            string filePath = GenerateDataFilePath(aocUser);
            //生成文件名(增加)
            string fileName = GenerateDataFileName( filenametype, dateTimeCheckPoint);

            //生成文件
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
        /// 生成DAT文件内容
        /// </summary>
        /// <param name="listAOC">AOC库数据列表</param>
        /// <param name="aocUser">AOC用户</param>
        /// <param name="dateTime">时间点，此批同步数据都是用这一时间</param>
        /// <returns></returns>
        private static List<string> GenerateDataFileContent(List<AOCDataCC> listAOC, AOCUserData aocUser, DateTime dateTime)
        {
            //初始化同步时间字符串，用于给每行DAT数据打时间标签
            string strDateTime = dateTime.ToString(TextTool.DATEFORMAT);
            //单条完整DAT数据，标签+AOC数据
            string dataResult = string.Empty;
            //单条AOCDAT数据
            string dataOneAOCData = string.Empty;
            //DAT内容集合，所有转换好的 完整DAT单行数据 统一放入此容器
            List<string> dataResultList = new List<string>();
            //AOC用户属性集合，获取该用户需要同步AOC中的哪几列数据
            List<PropertyInfo> myAOCUserPropertiesList = GetAOCUserProperties(aocUser);

            //逐行执行,将每条AOC数据根据用户列需求转换成DAT数据，并放入DAT内容集合
            for (int i = 0; i < listAOC.Count; i++)
            {
                //转换
                dataOneAOCData = GetDataByAOCData(myAOCUserPropertiesList, listAOC[i]);
                dataResult = string.Format("{0}{1}{2}", strDateTime, DATAFILEDATESTANDARD, dataOneAOCData);

                //放入集合
                dataResultList.Add(dataResult);
            }
            return dataResultList;
        }
        private static List<string> GenerateDataFileContent(List<AOCCONBINE> listAOC, AOCUserData aocUser, DateTime dateTime)
        {
            aocUser.loginfo.WriteLine("in GenerateDataFileContent");
            //初始化同步时间字符串，用于给每行DAT数据打时间标签
            string strDateTime = dateTime.ToString(TextTool.DATEFORMAT);
            //单条完整DAT数据，标签+AOC数据
            string dataResult = string.Empty;
            //单条AOCDAT数据
            string dataOneAOCData = string.Empty;
            //DAT内容集合，所有转换好的 完整DAT单行数据 统一放入此容器
            List<string> dataResultList = new List<string>();
            //AOC用户属性集合，获取该用户需要同步AOC中的哪几列数据
            List<PropertyInfo> myAOCUserPropertiesList = GetAOCUserProperties(aocUser);

            //逐行执行,将每条AOC数据根据用户列需求转换成DAT数据，并放入DAT内容集合
            for (int i = 0; i < listAOC.Count; i++)
            {
                //转换
                dataOneAOCData = GetDataByAOCData(myAOCUserPropertiesList, listAOC[i]);
                dataResult = string.Format("{0}{1}{2}", strDateTime, DATAFILEDATESTANDARD, dataOneAOCData);

                //放入集合
                dataResultList.Add(dataResult);
            }
            aocUser.loginfo.WriteLine("leave GenerateDataFileContent");
            return dataResultList;
        }

        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="aocUser">AOC用户</param>
        /// <param name="dateTimeCheckPoint">时间点</param>
        /// <returns></returns>
        private static string GenerateDataFileName( string filenametype, DateTime dateTimeCheckPoint)
        {
            string path = string.Format("{0}{1}{2}.dat", filenametype, "_atc", dateTimeCheckPoint.ToString(TextTool.DATEFORMAT));
            return path;
        }

        /// <summary>
        /// 生成文件路径，相对路径
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
        /// 将单条AOC数据转换为DAT类型数据
        /// </summary>
        /// <param name="aocUserPropertyList">所有导出的列集合</param>
        /// <param name="aocData">单条AOC数据</param>
        /// <returns></returns>
        private static string GetDataByAOCData(List<PropertyInfo> aocUserPropertyList, AOCDataCC aocData)
        {
            //单条不含标签的完整DAT数据格式参考：
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
            //单条不含标签的完整DAT数据格式参考：
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
