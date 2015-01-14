using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using AOCSync.Entity;
using AOCSync.Entity.Tools;

namespace AOCSync.Client
{
    class WorkFTPITV : IWork
    {
        public void Execute(object state)
        {
            DateTime dateTime;
            string msgOut = string.Empty;
            if (state is DateTime)
            {
                //AOCUserData aocUserData = new AOCUserData();
                dateTime = (DateTime)state;
                //DateTime dateTime = DateTime.Parse("2013-07-21");

                //Modify to Implement Interface by AocUser Configuration
                AOCUserData user=AOCUserData.Cache.Load(this.UserID);
                Console.WriteLine(string.Format("WorkFTPITV start:{0} on user {1}",DateTime.Now.ToString(),user.UserName));
                BLOutput.FTPITV(dateTime, out msgOut,user );

                //foreach (AOCUserData aocUserData in AOCUserData.Cache.AOCUserList)
                //{
                //    BLOutput.FTPITV(dateTime, out msgOut, aocUserData);
                //}
            }
            else
            {
                msgOut = "No date to make file";
            }
            Console.WriteLine(string.Format("WorkFTPITV over:{0}{1}",DateTime.Now.ToString(), msgOut));

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
