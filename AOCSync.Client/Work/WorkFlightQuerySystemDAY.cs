using System;

using AOCSync.Entity;

namespace AOCSync.Client
{
    class WorkFlightQuerySystemDAY : IWork
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
                Console.WriteLine(string.Format("WorkFlightQuerySystemDAY start:{0}", DateTime.Now.ToString()));
                BLFlightQuerySystemSyncTOAOC.SyncFlightQuerySystemToAOCFQSSimpleDAY(dateTime, out msgOut);
                Console.WriteLine(string.Format("WorkFlightQuerySystemDAY over:{0}{1}",DateTime.Now.ToString(), msgOut));
                Lock.FQS = true;               
                Lock.CanDayFtpFQS = true;
            }
            else
            {
                Console.WriteLine("WorkFlightQuerySystemDAY getTimeError");
                AOCLog.logErro("WorkFlightQuerySystemDAY getTimeError");
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
