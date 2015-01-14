using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace AOCSync.Entity.Tools
{
    public class LogInfo
    {
        string logFile;      
        /// <summary> 
        /// 不带参数的构造函数 
        /// </summary> 
        public LogInfo()
        {
            this.logFile = "log.log";       
            if (!Directory.Exists("./log"))
            {
                Directory.CreateDirectory("./log");
            }
        } 
        /// <summary> 
        /// 带参数的构造函数 
        /// </summary> /// 
        /// <param name="logFile">            </param> 
        public LogInfo(string logFile)
        { 
            this.logFile = logFile;
            if (!Directory.Exists("./log"))
            {
                Directory.CreateDirectory("./log");
            }
        }
        /// <summary>
        /// /// 追加一条信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void Write(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                           
                using (StreamWriter sw = new StreamWriter("./log/"+DateTime.Now.ToString("yyyyMMdd") + logFile, true, Encoding.UTF8))
            { sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text); }

            }
        }
        /// <summary> /// 追加一条信息 
        /// </summary> /// <param name="logFile"></param> /// <param name="text"></param> 
        public void Write(string logFile, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                using (StreamWriter sw = new StreamWriter("./log/" + DateTime.Now.ToString("yyyyMMdd") + logFile, true, Encoding.UTF8))
                { sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text); }
            }
        }
        /// <summary> /// 追加一行信息 /// </summary> /// <param name="text"></param> 
        public void WriteLine(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text += "\r\n"; using (StreamWriter sw = new StreamWriter("./log/" + DateTime.Now.ToString("yyyyMMdd") + logFile, true, Encoding.UTF8))
                { sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text); }
            }
        }
        /// <summary> /// 追加一行信息 /// </summary> /// <param name="logFile"></param> /// <param name="text"></param> 
        public void WriteLine(string logFile, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text += "\r\n"; using (StreamWriter sw = new StreamWriter("./log/" + DateTime.Now.ToString("yyyyMMdd") + logFile, true, Encoding.UTF8))
                { sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text); }
            }
        }
    }
}