using System;
using System.Collections.Generic;
using System.Data;

using AOCSync.Entity.AOCEnum;


namespace AOCSync.Entity
{
    class AOCCTRLData
    {
        public AOCCTRLData() { }

        public AOCCTRLData(DataRow dr)
        {
            initAOCCTRL(dr);
        }

        private void initAOCCTRL(DataRow dr)
        {
            if (dr == null)
            {
                throw new Exception("Unable to init AOCCTRLData.");
            }
            DB = dr["DB"].ToString();
            ITV = (Int64)dr["ITV"];
            DAY = (Int64)dr["DAY"];
        }

        public void Select()
        {
            DataRow dr = DataAccess.AOC_CTRL.GetAOCCTRLDataByDB(DB);

            if (dr != null)
            {
                initAOCCTRL(dr);
            }
            else
            {
                throw new Exception(string.Format("Unable to select AOCCTRLData by DB:{0}", DB.ToString()));
            }
        }

        public void Update()
        {
            DataAccess.AOC_CTRL.UpdateAOCCTRLData(DB, ITV, DAY);
        }

        public static List<AOCCTRLData> GetAOCCTRLData()
        {
            DataTable dt = DataAccess.AOC_CTRL.GetAOCCTRLData();
            List<AOCCTRLData> list = new List<AOCCTRLData>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new AOCCTRLData(dr));
                }
            }

            return list;
        }

        /// <summary>
        /// AOCCTRLDataCache
        /// </summary>
        public static class Cache
        {
            static Cache()
            {
                InitCache();
            }

            public static void RefreshCache()
            {
                InitCache();
            }

            private static void InitCache()
            {
                AOCCTRLDataList = GetAOCCTRLData();
            }

            public static AOCCTRLData Load(string db)
            {
                return AOCCTRLDataList.Find(delegate(AOCCTRLData aocCtrl) { return aocCtrl.DB.Equals(db); });
            }

            public static List<AOCCTRLData> AOCCTRLDataList;
        }

        public static Int64 getCTRLNumberITVOfCallCenter()
        {
            Cache.RefreshCache();
            if (Cache.AOCCTRLDataList.Exists(delegate(AOCCTRLData aocCtrl) { return aocCtrl.DB.Equals(EnumDataBaseSource.CC.ToString()); }))
            {
                AOCCTRLData aocCtrlData = new AOCCTRLData();
                aocCtrlData.ITV = Cache.AOCCTRLDataList.Find(delegate(AOCCTRLData aocCtrl) { return aocCtrl.DB.Equals(EnumDataBaseSource.CC.ToString()); }).ITV;
                return aocCtrlData.ITV;
            }
            else
            {
                return int.MinValue;
            }
        }


        #region AOCCTRL COLUMNS
        private string db;
        private Int64 itv;
        private Int64 day;

        public string DB
        {
            set { db = value; }
            get { return db; }
        }

        public Int64 ITV
        {
            set { itv = value; }
            get { return itv; }
        }

        public Int64 DAY
        {
            set { day = value; }
            get { return day; }
        }

        #endregion
    }
}
