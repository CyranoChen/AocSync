using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AOCSync.Entity.Tools;

namespace AOCSync.Entity
{
    public class AOCUserData
    {
        public LogInfo loginfo;
        public AOCUserData() { }

        public AOCUserData(DataRow dr)
        {
            InitUser(dr);
        }

        private void InitUser(DataRow dr)
        {
            if (dr != null)
            {
                UserID = Convert.ToInt32(dr["ID"]);
                UserName = dr["UserName"].ToString();
                FTPIP = dr["FTPIP"].ToString();
                FTPLogName = dr["FTPLogName"].ToString();
                FTPPassword = dr["FTPPassWord"].ToString();
                FTPRemoteDir = dr["FTPRemoteDir"].ToString();
                FTPMode = dr["FTPMode"].ToString();
                ExportColumns = dr["ExportColumns"].ToString();
                IsPack = dr["IsPack"].ToString();
                ITVTime = Convert.ToInt32(dr["ITVTime"]);
                AirportIATA = Convert.ToInt32(dr["AirportIATA"]);
                FlightNature = dr["FlightNature"].ToString();
                loginfo = new LogInfo(UserName+".log"); 
                FTPPort=dr["FTPPort"].ToString();
            }
            else
            {
                throw new Exception("Unable to init AOCUser.");
            }
        }

        public void Select()
        {
            DataRow dr = DataAccess.User.GetUserByID(UserID);

            if (dr != null)
            {
                InitUser(dr);
            }
        }

        public void Update()
        {
            DataAccess.User.UpdateUser(UserID, UserName, UserPassword, FTPIP, FTPPort, FTPLogName, FTPPassword, FTPRemoteDir, FTPMode, IsPack, ITVTime, AirportIATA, FlightNature, ExportColumns);
        }

        public void Update(SqlTransaction trans)
        {
            DataAccess.User.UpdateUser(UserID, UserName, UserPassword, FTPIP, FTPPort, FTPLogName, FTPPassword, FTPRemoteDir, FTPMode, IsPack, ITVTime, AirportIATA, FlightNature, ExportColumns, trans);
        }

        public void Insert()
        {
            DataAccess.User.InsertUser(UserName, UserPassword, FTPIP, FTPPort, FTPLogName, FTPPassword, FTPRemoteDir, FTPMode, IsPack, ITVTime, AirportIATA, FlightNature, ExportColumns);
        }

        public void Insert(SqlTransaction trans)
        {
            DataAccess.User.InsertUser(UserName, UserPassword, FTPIP, FTPPort, FTPLogName, FTPPassword, FTPRemoteDir, FTPMode, IsPack, ITVTime, AirportIATA, FlightNature, ExportColumns, trans);
        }

        public void Delete()
        {
            DataAccess.User.DeleteUser(UserID);
        }

        public void Delete(SqlTransaction trans)
        {
            DataAccess.User.DeleteUser(UserID, trans);
        }

        public static List<AOCUserData> GetAOCUserDatas()
        {
            DataTable dt = DataAccess.User.GetUsers();
            List<AOCUserData> list = new List<AOCUserData>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new AOCUserData(dr));
                }
            }

            return list;
        }

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
                AOCUserList = GetAOCUserDatas();
            }

            public static AOCUserData Load(int userID)
            {
                return AOCUserList.Find(delegate(AOCUserData aocUserInList) { return aocUserInList.UserID.Equals(userID); });
            }

            public static List<AOCUserData> AOCUserList;
        }

        #region members and propertis
        private int userID;
        private string userName;
        private string userPassword;
        private string ftpIP;
        private string ftpPort;
        private string ftpName;
        private string ftpPassword;
        private string ftpRemoteDir;
        private string ftpMode;
        private string exportColumns;
        private string isPack;
        private int iTVTime;
        private int airportIATA;
        private string flightNature;
       

     
        public int UserID
        {
            set { userID = value; }
            get { return userID; }
        }

        public string UserName
        {
            set { userName = value; }
            get { return userName; }
        }

        public string UserPassword
        {
            set { userPassword = value; }
            get { return userPassword; }
        }

        public string FTPIP
        {
            set { ftpIP = value; }
            get { return ftpIP; }
        }

        public string FTPPort
        {
            set { ftpPort = value; }
            get { return ftpPort; }
        }

        public string FTPLogName
        {
            set { ftpName = value; }
            get { return ftpName; }
        }

        public string FTPPassword
        {
            set { ftpPassword = value; }
            get { return ftpPassword; }
        }

        public string FTPRemoteDir
        {
            get { return ftpRemoteDir; }
            set { ftpRemoteDir = value; }
        }

        public string FTPMode
        {
            get { return ftpMode; }
            set { ftpMode = value; }
        }

        public string ExportColumns
        {
            set { exportColumns = value; }
            get { return exportColumns; }
        }
        public string IsPack
        {
            set { isPack = value; }
            get { return isPack; }
        }
        public int ITVTime
        {
            get { return iTVTime; }
            set { iTVTime = value; }
        }
      
        public int AirportIATA
        {
            get { return airportIATA; }
            set { airportIATA = value; }
        }


        public string FlightNature
        {
            get { return flightNature; }
            set { flightNature = value; }
        }
        #endregion
    }
}
