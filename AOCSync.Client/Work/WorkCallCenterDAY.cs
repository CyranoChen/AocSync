using System;

using AOCSync.Entity;

namespace AOCSync.Client
{
    class WorkCallCenterDAY:IWork
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

                Console.WriteLine(string.Format("WorkCallCenterDAY start:{0}", DateTime.Now.ToString()));
                BLCallCenterSyncTOAOC.SyncCallCenterToAOCSimpleDAY(dateTime, out msgOut);
                Console.WriteLine(string.Format("WorkCallCenterDAY over:{0},{1}", DateTime.Now.ToString(), msgOut));
                Lock.CC = true;
                Lock.CanDayFtpCC = true;
            }
            else
            {
                Console.WriteLine("WorkCallCenterDAY getTimeError");
                AOCLog.logErro("WorkCallCenterDAY getTimeError");
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
