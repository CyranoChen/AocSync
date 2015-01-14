using System;
using System.Collections.Generic;
using System.IO;

using AOCSync.Entity;
using AOCSync.Entity.Tools;

namespace AOCSync.Client
{
    class WorkHISDAY : IWork
    {
        public void Execute(object state)
        {
            if (state is DateTime)
            {
                DateTime dateTime = (DateTime)state;
                string msgOut = string.Empty;
                Console.WriteLine(string.Format("WorkHISDAY time:{0}", dateTime.ToString()));
                Console.WriteLine("WorkHISDAY start move cc");
                BLMoveToHIS.MoveCCToHis(dateTime, out msgOut);
                Console.WriteLine("WorkHISDAY move cc end");
                Console.WriteLine("WorkHISDAY start move FQS");
                BLMoveToHIS.MoveFQSToHis(dateTime, out msgOut);
                Console.WriteLine("WorkHISDAY move FQS end");
                Console.WriteLine(string.Format("WorkHISDAY over:{0}", msgOut));

                ////DateTime dateTime = DateTime.Parse("2013-07-21");

                //DateTime dateTimeEnd  = dateTime.Date;
                //DateTime dateTimeStart = dateTime.Date.AddHours(AOCConfig.INTERVALEVENTHISTORYBEFORE);//
                //string dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
                //string dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");



                // DateTime t1 = DateTime.Now;
                // List<AOCDataCC> aocDataCCList = AOCDataCC.Cache.AOCDataList.FindAll(delegate(AOCDataCC aocdataInList)
                //{
                //    return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0;
                //}
                //    );



                //AOCDataCCHIS.GenerateAOCDataCCHISByAOCData(aocDataCCList);
                //AOCDataCC.Cache.RefreshCache();
                //Console.Write("\nmove to CCHIS USE ");
                //Console.Write(DateTime.Now - t1);


                //t1 = DateTime.Now;
                //dtStart = dateTimeStart.ToString();
                //dtEnd = dateTimeEnd.ToString();
                //List<AOCDataFQS> aocDataFQSList = AOCDataFQS.Cache.AOCDataList.FindAll(delegate(AOCDataFQS aocdataInList)
                //{

                //    if (!string.IsNullOrEmpty(aocdataInList.STOD))
                //    {
                //        dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
                //        dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");

                //        return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0;
                //    }
                //    else
                //    {
                //        return aocdataInList.SDT.CompareTo(dtStart) >= 0 && aocdataInList.SDT.CompareTo(dtEnd) <= 0;
                //    }
                //}
                //    );




                //AOCDataFQSHIS.GenerateAOCDataFQSHISByAOCDataFQS(aocDataFQSList);
                //AOCDataFQS.Cache.RefreshCache();
                //Console.Write("\nmove to FQSHIS USE ");
                //Console.Write(DateTime.Now - t1);

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


