using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace AOCSync.Entity
{
    public static class AOCConfig
    {
        //defalut values
        private static int _intervalEventDefault = 5 * 60 * 1000;//ms
        private static int _intervalEventDailyDefault = 4 * 60;//total minutes form midnight
        private static int _intervalEventHistoryDefault = 5 * 60;//total minutes from midnight
        private static int _intervalEventBeforeDefault = -12;//hour
        private static int _intervalEventAfterDefault = 12;//hour
        private static int _intervalEventDailyAfterDefault = 6 * 24;//hour
        private static int _intervalEventHistoryBeforeDefault = -3 * 24;//hour

        /// <summary>
        /// 轮询同步 间隔时间 毫秒
        /// </summary>
        public static int INTERVALEVENT
        {
            get
            {
                return GetIntervalEvent();
            }
        }
        /// <summary>
        /// 每日同步 同步时间 从午夜0时起所经过的分钟
        /// </summary>
        public static int INTERVALEVENTDAILY
        {
            get { return GetIntervalEventDaily(); }
        }
        /// <summary>
        /// 历史同步 同步时间 整点
        /// </summary>
        public static int INTERVALEVENTHISTORY
        {
            get { return GetIntervalEventHistory(); }
        }
        /// <summary>
        /// 轮询同步 时间范围 当前时间往前 负数 小时
        /// </summary>
        public static int INTERVALEVENTBEFORE
        {
            get { return GetIntervalEventBefore(); }
        }
        /// <summary>
        /// 轮询同步 时间范围 当前时间往后 小时
        /// </summary>
        public static int INTERVALEVENTAFTER
        {
            get { return GetIntervalEventAfter(); }
        }
        /// <summary>
        /// 每日同步 时间范围 当天往后 小时
        /// </summary>
        public static int INTERVALEVENTDAILYAFTER
        {
            get { return GetIntervalEventDailyAfter(); }
        }
        /// <summary>
        /// 历史同步 时间范围 当天往前 负数 天
        /// </summary>
        public static int INTERVALEVENTHISTORYBEFORE
        {
            get { return GetIntervalEventHistoryBefore(); }
        }


        /// <summary>
        /// million seconds of intervalEvent in App.config
        /// </summary>
        /// <returns></returns>
        public static int GetIntervalEvent()
        {
            try
            {
                string intervalEventStr = ConfigurationManager.AppSettings.GetValues("IntervalEvent")[0].ToString();
                int intervalEvent = int.MinValue;
                //parse to int
                if (int.TryParse(intervalEventStr, out intervalEvent))
                {
                    return intervalEvent * 60 * 1000;
                }
                else
                {
                    throw new Exception("GetIntervalEvent Error");
                }
            }
            catch (Exception exp)
            {
                AOCLog.logErro(exp, "GetIntervalEvent()");
                return _intervalEventDefault;
            }
        }
        /// <summary>
        /// o'clock of intervalEventDaily in App.config
        /// </summary>
        /// <returns></returns>
        public static int GetIntervalEventDaily()
        {
            try
            {
                string intervalEventDailyStr = ConfigurationManager.AppSettings.GetValues("IntervalEventDaily")[0].ToString();
                int intervalEventDaily = int.MinValue;

                //parse to int
                if (int.TryParse(intervalEventDailyStr, out intervalEventDaily))
                {
                    return (intervalEventDaily * 60);
                }
                else
                {
                    throw new Exception("GetIntervalEvent Error");
                }
            }
            catch (Exception exp)
            {
                AOCLog.logErro(exp, string.Format("GetIntervalEventDaily parse error:{0}", exp.Message));
                return _intervalEventDailyDefault;
            }
        }
        /// <summary>
        /// o'clock of intervalEventHistory in App.config
        /// </summary>
        /// <returns></returns>
        public static int GetIntervalEventHistory()
        {
            try
            {
                string intervalEventHistoryStr = ConfigurationManager.AppSettings.GetValues("IntervalEventHistory")[0].ToString();
                int intervalEventHistory = int.MinValue;
                //parse to int
                if (int.TryParse(intervalEventHistoryStr, out intervalEventHistory))
                {
                    return (intervalEventHistory * 60);
                }
                else
                {
                    throw new Exception("GetIntervalEventHistory Error");
                }
            }
            catch (Exception exp)
            {
                AOCLog.logErro(exp, string.Format("GetIntervalEventHistory parse error:{0}", exp.Message));
                return _intervalEventHistoryDefault;
            }
        }
        /// <summary>
        /// hours*-1 of intervalEventBefore in App.config
        /// </summary>
        /// <returns></returns>
        public static int GetIntervalEventBefore()
        {
            try
            {
                string intervalEventBeforeStr = ConfigurationManager.AppSettings.GetValues("IntervalEventBefore")[0].ToString();
                int intervalEventBefore = int.MinValue;

                //parse to int
                if (int.TryParse(intervalEventBeforeStr, out intervalEventBefore))
                {
                    return (intervalEventBefore * -1);
                }
                else
                {
                    throw new Exception("GetIntervalEventBefore Error");
                }
            }
            catch (Exception exp)
            {
                AOCLog.logErro(exp, string.Format("GetIntervalEventBefore parse error:{0}", exp.Message));
                return _intervalEventBeforeDefault;
            }
        }
        /// <summary>
        /// hours of intervalEventAfter in App.config
        /// </summary>
        /// <returns></returns>
        public static int GetIntervalEventAfter()
        {
            try
            {
                string intervalEventAfterStr = ConfigurationManager.AppSettings.GetValues("IntervalEventAfter")[0].ToString();
                int intervalEventAfter = int.MinValue;
                //parse to int
                if (int.TryParse(intervalEventAfterStr, out intervalEventAfter))
                {
                    return intervalEventAfter;
                }
                else
                {
                    throw new Exception("GetIntervalEventAfter Error");
                }
            }
            catch (Exception exp)
            {
                AOCLog.logErro(exp, string.Format("GetIntervalEventAfter parse error:{0}", exp.Message));
                return _intervalEventAfterDefault;
            }
        }
        /// <summary>
        /// hours of intervalEventDailyAfter in App.config
        /// day to hour
        /// </summary>
        /// <returns></returns>
        public static int GetIntervalEventDailyAfter()
        {
            try
            {
                string intervalEventDailyAfterStr = ConfigurationManager.AppSettings.GetValues("IntervalEventDailyAfter")[0].ToString();
                int intervalEventDailyAfter = int.MinValue;

                //parse to int
                if (int.TryParse(intervalEventDailyAfterStr, out intervalEventDailyAfter))
                {
                    return intervalEventDailyAfter * 24;
                }
                else
                {
                    throw new Exception("GetIntervalEventDailyAfter() Error");
                }
            }
            catch (Exception exp)
            {
                AOCLog.logErro(exp, string.Format("GetIntervalEventDailyAfter parse error:{0}", exp.Message));
                return _intervalEventDailyAfterDefault;
            }
        }
        /// <summary>
        /// hours*-1 of intervalEventHistoryBefore in App.config
        /// day to hour
        /// </summary>
        /// <returns></returns>
        public static int GetIntervalEventHistoryBefore()
        {
            try
            {
                string intervalEventHistoryBeforeStr = ConfigurationManager.AppSettings.GetValues("IntervalEventHistoryBefore")[0].ToString();
                int intervalEventHistoryBefore = int.MinValue;

                //parse to int
                if (int.TryParse(intervalEventHistoryBeforeStr, out intervalEventHistoryBefore))
                {
                    return (intervalEventHistoryBefore * -1);
                }
                else
                {
                    throw new Exception("GetIntervalEventHistoryBefore Error");
                }
            }
            catch (Exception exp)
            {
                AOCLog.logErro(exp, string.Format("GetIntervalEventHistoryBefore parse error:{0}", exp.Message));
                return _intervalEventHistoryBeforeDefault;
            }
        }
    }
}
