using System;
using System.Collections.Generic;
using System.Text;

using AOCSync.Entity;

namespace AOCSync.Client
{
    class WorkCallCenterITV:IWork
    {
        public void Execute(object state)
        {
            DateTime dateTime;
            string msgOut = string.Empty;
            if (state is DateTime)
            {
                Lock.CC = false;
                dateTime = (DateTime)state;                
                //dateTime = DateTime.Parse("2013-07-21");
                Console.WriteLine(string.Format("WorkCallCenterITV start:{0}", DateTime.Now.ToString()));
                ////BLCallCenterSyncTOAOC.SyncCallCenterSHAToAOCITV(dateTime, out msgOut);
                //BLCallCenterSyncTOAOC.SyncCallCenterToAOCITV(dateTime, out msgOut);
                BLCallCenterSyncTOAOC.SyncCallCenterToAOCSimpleITV(dateTime, out msgOut);
                Console.WriteLine(string.Format("WorkCallCenterITV over:{0}{1}", DateTime.Now.ToString(), msgOut));
                Lock.CC = true;
            }
            else
            {
                Console.WriteLine("WorkCallCenterITV getTimeError");
                AOCLog.logErro("WorkCallCenterITV getTimeError");
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
