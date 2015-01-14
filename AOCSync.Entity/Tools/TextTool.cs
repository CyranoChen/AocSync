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
        /// �ַ���ʱ�����ͣ���ȷ������
        /// </summary>
        public static string DATEFORMAT = "yyyyMMddHHmmss";
        /// <summary>
        /// �ַ���ʱ�����ͣ���ȷ����
        /// </summary>
        public static string DATEFORMATDAY = "yyyyMMdd";

        /// <summary>
        /// ��ȡʱ��
        /// </summary>
        /// <param name="obj">Object��ʱ��</param>
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
        /// ��ȡ��ǰʹ�õķ�����������
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
