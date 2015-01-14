using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using AOCSync.Entity;

namespace AOCSync.Client
{
    public class Lock
    {
        public static bool CC; //CC�����
        public static bool FQS;//FQS�����
        public static bool CanDayFtpCC;//CCDAY��ɱ�־
        public static bool CanDayFtpFQS;//FQSDAY��ɱ�־
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
            //���а��������¼�����
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

            //���а���ѯ���е��¼�����
            Event eventCallCenterITV = new EventCallCenterIterval();
            Event eventFlightQuerySystemITV = new EventFlightQuerySystemIterval();

            List<Event> elITV = new List<Event>();

            elITV.Add(eventCallCenterITV);
            elITV.Add(eventFlightQuerySystemITV);

            emITV.EventsList = elITV;

            //���û���������ѯ���е��¼�����
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
                Thread.Sleep(EventManager.TimerMinutesInterval * 10000); //ÿ10����ִ��һ��
            }
        }

        private static void StartUserITVSync()
        {
            while (true)
            {
                emUserITV.Execute();
                Thread.Sleep(EventManager.TimerMinutesInterval * 10000); //ÿ10����ִ��һ��
            }
        }

        private static void StartDAYSync()
        {
            while (true)
            {
                emDay.Execute();
                //Thread.Sleep(EventManager.TimerMinutesInterval * 1000 * 3600); //ÿ��ִ��һ��
                Thread.Sleep(EventManager.TimerMinutesInterval * 1000 * 60); //Ϊ���� ����12��ͬ����1159������ʵ��ȴҪ��1259��ִ�е�����������޸�
            }
        }

    }
}