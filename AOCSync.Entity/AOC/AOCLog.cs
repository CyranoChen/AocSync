using System;
using System.Collections.Generic;
using System.Data;

namespace AOCSync.Entity
{
    public class AOCLog
    {
        public AOCLog() { }

        public AOCLog(DataRow dr)
        {
            InitLog(dr);
        }

        private void InitLog(DataRow dr)
        {
            if (dr != null)
            {
                LogID = Convert.ToInt32(dr["ID"]);
                EventType = (LogType)Enum.Parse(typeof(LogType), dr["EventType"].ToString());
                Message = dr["Message"].ToString();
                ErrorStackTrace = dr["ErrorStackTrace"].ToString();
                EventDate = (DateTime)(dr["EventDate"]);
                ErrorParam = dr["ErrorParam"].ToString();
            }
            else
                throw new Exception("Unable to init LogEvent.");
        }

        public void Select()
        {
            DataRow dr = DataAccess.Log.GetLogEventByID(LogID);

            if (dr != null)
                InitLog(dr);
        }

        public void Update()
        {
            DataAccess.Log.UpdateLogEvent(LogID, EventType.ToString(), Message, ErrorStackTrace, ErrorParam);
        }

        public void Insert()
        {
            DataAccess.Log.InsertLogEvent(EventType.ToString(), Message, ErrorStackTrace, ErrorParam);
        }

        public void Delete()
        {
            DataAccess.Log.DeleteLogEvent(LogID);
        }

        public static List<AOCLog> GetLogs()
        {
            DataTable dt = DataAccess.Log.GetLogEvents();
            List<AOCLog> list = new List<AOCLog>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new AOCLog(dr));
                }
            }

            return list;
        }

        /// <summary>
        /// 插入LOG表
        /// </summary>
        /// <param name="let">LOG类型</param>
        /// <param name="message">LOG信息</param>
        /// <param name="errorStackTrace">异常堆栈</param>
        /// <param name="errorParam">出现异常时，使用的参数或方法</param>
        public static void Logging(LogType let, string message, string errorStackTrace, string errorParam)
        {
            AOCLog l = new AOCLog();
            l.EventType = let;
            l.Message = message;
            l.ErrorStackTrace = errorStackTrace;
            l.ErrorParam = errorParam;
            l.Insert();
        }

        /// <summary>
        /// 生成同步成功消息 CallCenter
        /// </summary>
        /// <param name="nameFunction">同步的方法信息</param>
        /// <param name="dateTime">时间点</param>
        /// <param name="countList">同步数据总数数量</param>
        /// <param name="countInsert">Insert数量</param>
        /// <param name="countUpdate">Update数量</param>
        /// <returns></returns>
        public static string GenerateSuccessMSGForCallCenterSync(string nameFunction, DateTime dateTime, int countList, int countInsert, int countUpdate)
        {
            string msgSuccess = string.Format("CallCenterSync Success:Function={0},CheckPointTime={1},CountList={2},CountInsert={3},CountUpdate={4}", nameFunction, dateTime.ToString(), countList.ToString(), countInsert.ToString(), countUpdate.ToString());

            return msgSuccess;
        }

        /// <summary>
        /// 生成同步失败参数 CallCenter
        /// </summary>
        /// <param name="nameFunction">同步的方法信息</param>
        /// <param name="paramsFunction">同步的方法参数信息</param>
        /// <returns></returns>
        public static string GenerateParamsErroForCallCenterSync(string nameFunction, params object[] paramsFunction)
        {
            string msgErro = string.Format("CallCenterSync Error:Function={0}", nameFunction);

            for (int indexFunctionParas = 0; indexFunctionParas < paramsFunction.Length; indexFunctionParas++)
            {
                msgErro += string.Format(",Param[{0}]={1}", indexFunctionParas.ToString(), paramsFunction[indexFunctionParas].ToString());
            }

            return msgErro;
        }

        /// <summary>
        /// 记录执行成功消息
        /// </summary>
        /// <param name="msgSuccess"></param>
        public static void logSuccess(string msgSuccess)
        {
            Logging(LogType.Success, msgSuccess, string.Empty, string.Empty);
        }

        /// <summary>
        /// 记录执行失败消息
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="paramsErro"></param>
        public static void logErro(Exception exp, string paramsErro)
        {
            Logging(LogType.Error, exp.Message, exp.StackTrace, paramsErro);
        }
        /// <summary>
        /// 记录执行失败消息
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="paramsErro"></param>
        public static void logErro(string msgErro)
        {
            Logging(LogType.Error, string.Empty, string.Empty, msgErro);
        }

        /// <summary>
        /// 生成同步成功消息 CallCenter
        /// </summary>
        /// <param name="nameFunction">同步的方法信息</param>
        /// <param name="dateTime">时间点</param>
        /// <param name="countList">同步数据总数数量</param>
        /// <param name="countInsert">Insert数量</param>
        /// <param name="countUpdate">Update数量</param>
        /// <returns></returns>
        public static string GenerateSuccessMSGForFlightQuerySystemSync(string nameFunction, DateTime dateTime, int countList, int countInsert, int countUpdate)
        {
            string msgSuccess = string.Format("FlightQuerySystem Success:Function={0},CheckPointTime={1},CountList={2},CountInsert={3},CountUpdate={4},", nameFunction, dateTime.ToString(), countList.ToString(), countInsert.ToString(), countUpdate.ToString());

            return msgSuccess;
        }

        /// <summary>
        /// 生成同步失败参数 CallCenter
        /// </summary>
        /// <param name="nameFunction">同步的方法信息</param>
        /// <param name="paramsFunction">同步的方法参数信息</param>
        /// <returns></returns>
        public static string GenerateParamsErroForFlightQuerySystemSync(string nameFunction, params object[] paramsFunction)
        {
            string msgErro = string.Format("FlightQuerySystem Error:Function={0}", nameFunction);

            for (int indexFunctionParas = 0; indexFunctionParas < paramsFunction.Length; indexFunctionParas++)
            {
                msgErro += string.Format(",Param[{0}]={1}", indexFunctionParas.ToString(), paramsFunction[indexFunctionParas].ToString());
            }

            return msgErro;
        }


        #region Members and Properties

        private int logID;
        private LogType eventType;
        private string message;
        private string errorStackTrace;
        private DateTime eventDate;
        private string errorParam;

        public int LogID
        {
            get { return logID; }
            set { logID = value; }
        }

        public LogType EventType
        {
            get { return eventType; }
            set { eventType = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string ErrorStackTrace
        {
            get { return errorStackTrace; }
            set { errorStackTrace = value; }
        }

        public DateTime EventDate
        {
            get { return eventDate; }
            set { eventDate = value; }
        }

        public string ErrorParam
        {
            get { return errorParam; }
            set { errorParam = value; }
        }

        #endregion
    }

    public enum LogType
    {
        Success,
        Error
    }
}
