using System;
using System.Collections.Generic;
using System.Text;
using AOCSync.Entity;

namespace AOCSync.Client
{
    class WorkFlightQuerySystemITV : IWork
    {
        public void Execute(object state)
        {
            DateTime dateTime;
            string msgOut = string.Empty;
            if (state is DateTime)
            {
                Lock.FQS = false;
                dateTime = (DateTime)state;
                //dateTime = DateTime.Parse("2013-07-21");
                Console.WriteLine(string.Format("WorkFlightQuerySystemITV start:{0}", DateTime.Now.ToString()));
                //BLFlightQuerySystemSyncTOAOC.SyncFlightQuerySystemToAOCFQSITV(dateTime, out msgOut);
                BLFlightQuerySystemSyncTOAOC.SyncFlightQuerySystemToAOCFQSSimpleITV(dateTime, out msgOut);
                Console.WriteLine(string.Format("WorkFlightQuerySystemITV over:{0}{1}",DateTime.Now.ToString(), msgOut));
                Lock.FQS = true;
            }
            else
            {
                Console.WriteLine("WorkFlightQuerySystemITV getTimeError");
                AOCLog.logErro("WorkFlightQuerySystemITV getTimeError");
            }
        }


        private int _userid;
        public int UserID
        {
            get { return this._userid; }
            set { this._userid = value; }
        }

        //public int UserID
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
