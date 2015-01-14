using System;
using System.Collections.Generic;
using AOCSync.Entity;
using AOCSync.Entity.Tools;
using System.IO;
namespace AOCSync.Client
{
    class WorkFTPDAY : IWork
    {
        public void Execute(object state)
        {

            string msgOut = string.Empty;
            if (state is DateTime)   
            {
                DateTime dateTime = (DateTime)state;
                //AOCUserData aocUserData = new AOCUserData();

                foreach (AOCUserData aocUserData in AOCUserData.Cache.AOCUserList)
                {
                    Console.WriteLine(string.Format("WorkFTPDAY start:{0} on user {1}",DateTime.Now.ToString(),aocUserData.UserName));
                    BLOutput.FTPDAY(dateTime, out msgOut, aocUserData);
                    Console.WriteLine(string.Format("WorkFTPDAY over:{0}{1}",DateTime.Now.ToString(), msgOut));
                }
            }
            else
            {
                msgOut = "No date to make file";
                Console.WriteLine(string.Format("WorkFTPDAY over:{0}", msgOut));
            }
            Lock.CanDayFtpCC = false;
            Lock.CanDayFtpFQS = false;
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

