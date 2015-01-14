using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using AOCSync.Entity;

namespace AOCSync.Client
{
    public class Lock
    {
        public static bool CC; //CC库的锁
        public static bool FQS;//FQS库的锁
        public static bool CanDayFtpCC;//CCDAY完成标志
        public static bool CanDayFtpFQS;//FQSDAY完成标志
    }
    class Program
    {
        
        static EventManager emDay = new EventManager();
        static EventManager emITV = new EventManager();
        static EventManager emUserITV = new EventManager();

        static void Main(string[] args)
        {
            Lock.CC = true;
            Lock.FQS = true;
            Lock.CanDayFtpCC = false;
            Lock.CanDayFtpFQS = false;
            //所有按日运行事件声明
            Event eventCallCenterDAY = new EventCallCenterDAY();
            Event eventFlightQuerySystemDAY = new EventFlightQuerySystemDAY();
            Event eventFTPDAY = new EventFTPDAY();
            Event eventHISDAY = new EventHISDAY();

            List<Event> elDay = new List<Event>();

            elDay.Add(eventCallCenterDAY);
            elDay.Add(eventFlightQuerySystemDAY);
            elDay.Add(eventFTPDAY);
            elDay.Add(eventHISDAY);

            emDay.EventsList = elDay;

            //所有按轮询运行的事件声明
            Event eventCallCenterITV = new EventCallCenterIterval();
            Event eventFlightQuerySystemITV = new EventFlightQuerySystemIterval();

            List<Event> elITV = new List<Event>();

            elITV.Add(eventCallCenterITV);
            elITV.Add(eventFlightQuerySystemITV);

            emITV.EventsList = elITV;

            //按用户定义间隔轮询运行的事件声明
            List<Event> elUserITV = new List<Event>();
            List<AOCUserData> userList = AOCUserData.Cache.AOCUserList;

            if (userList.Count > 0)
            {
                foreach (AOCUserData aocUserData in userList)
                {
                    elUserITV.Add(new EventFTPIterval(aocUserData));

                }
            }

      

            emUserITV.EventsList = elUserITV;


            ThreadStart thdStartITV = new ThreadStart(StartITVSync);
            Thread thdITV = new Thread(thdStartITV);
            thdITV.Start();

            ThreadStart thdStartUserITV = new ThreadStart(StartUserITVSync);
            Thread thdUserITV = new Thread(thdStartUserITV);
            thdUserITV.Start();


            ThreadStart thdStartDAY = new ThreadStart(StartDAYSync);
            Thread thdDAY = new Thread(thdStartDAY);
            thdDAY.Start();
        }

        private static void StartITVSync()
        {
            while (true)
            {
                emITV.Execute();
                Thread.Sleep(EventManager.TimerMinutesInterval * 10000); //每10秒钟执行一次
            }
        }

        private static void StartUserITVSync()
        {
            while (true)
            {
                emUserITV.Execute();
                Thread.Sleep(EventManager.TimerMinutesInterval * 10000); //每10秒钟执行一次
            }
        }

        private static void StartDAYSync()
        {
            while (true)
            {
                emDay.Execute();
                //Thread.Sleep(EventManager.TimerMinutesInterval * 1000 * 3600); //每天执行一次
                Thread.Sleep(EventManager.TimerMinutesInterval * 1000 * 60); //为避免 设置12点同步，1159启动，实际却要到1259才执行的情况，所以修改
            }
        }

    }
}