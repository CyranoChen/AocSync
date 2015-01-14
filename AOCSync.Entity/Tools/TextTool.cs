using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace AOCSync.Entity.Tools
{
    public class TextTool
    {
        /// <summary>
        /// 字符型时间类型，精确到毫秒
        /// </summary>
        public static string DATEFORMAT = "yyyyMMddHHmmss";
        /// <summary>
        /// 字符型时间类型，精确到日
        /// </summary>
        public static string DATEFORMATDAY = "yyyyMMdd";

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="obj">Object类时间</param>
        /// <returns></returns>
        public static DateTime GenerateDateTimeByObject(object obj)
        {
            DateTime dtTemp;
            if (DateTime.TryParse(obj.ToString(), out dtTemp))
            {
                return dtTemp;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// 获取当前使用的方法名，参数
        /// </summary>
        /// <returns></returns>
        public static string GetFunctionInfo()
        {
            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();
            return method.ToString();
        }
    }
}
