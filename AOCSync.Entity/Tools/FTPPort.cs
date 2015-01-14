using System;
using System.IO;
using System.Net;

namespace AOCSync.Entity.Tools
{
    /*
     * Author : Eric
     * Remark : FTPClient Class to Upload and Download Files
     */
    public class FTPClientPort
    {
        //add by march 20140408 记录FTP过程中的日志
        public LogInfo loginfo;
        //add by march 20140408 记录FTP过程中的日志

        private string FileName;
        //private string FilePath;
        private string UserName;
        private string Password;
        private string ftpServerIP;
        private string ftpPort;
        private string MsgSyncOut;
        /************************************************/
        /* Constructor(For Upload & download)                      */
        /************************************************/
        public FTPClientPort(string ftpsvr, string ftpport, string filename, string username, string password)
        {
            //add by march 20140408 记录FTP过程中的日志
            loginfo = new LogInfo(username + ".log");
            //add by march 20140408 记录FTP过程中的日志

            ftpServerIP = ftpsvr;
            ftpPort = ftpport;
            if (string.IsNullOrEmpty(ftpPort))
                ftpPort = "21";
            FileName = filename;
            UserName = username;
            if (string.IsNullOrEmpty(UserName))
                UserName = "anonymous";
            Password = password;
            if (string.IsNullOrEmpty(Password))
                Password = "anonymous";

        }

        /************************************************/
        /* Constructor(For Download)                    */
        /************************************************/
        //public FTP(string ftpsvr, string filename, string filepath, string username, string password)
        //{
        //    ftpServerIP = ftpsvr;
        //    FileName = filename;
        //    FilePath = filepath;
        //    UserName = username;
        //    Password = password;
        //}

        //public void Upload()           //上传

        //创建目录
        public void MakeDir(string dirName)
        {
            try
            {
                string uri = "ftp://" + ftpServerIP + "/" + dirName;
                FtpWebRequest reqFTP;
                // 根据uri创建FtpWebRequest对象

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                // 指定数据传输类型

                reqFTP.UseBinary = true;

                // ftp用户名和密码

                reqFTP.Credentials = new NetworkCredential(this.UserName, this.Password);

                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();

                response.Close();
            }
            catch { }
        }

        public bool Upload(AOCUserData aocUserData)
        {
            DateTime DTstart = DateTime.Now;
            loginfo.WriteLine(string.Format("+++++FTP Upload Begin At: {0} +++++",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            try
            {
                FileInfo fileInf = new FileInfo(this.FileName);
                string _ftpRemoteDir;
                if (!string.IsNullOrEmpty(aocUserData.FTPRemoteDir))
                {
                    _ftpRemoteDir = aocUserData.FTPRemoteDir + "/";

                }
                else
                {
                    //_ftpRemoteDir = aocUserData.UserName;
                    _ftpRemoteDir = "";
                }
                string uri = "ftp://" + this.ftpServerIP + ":" + this.ftpPort + "/" + _ftpRemoteDir  + fileInf.Name;

                FtpWebRequest reqFTP;
            
                // 根据uri创建FtpWebRequest对象 
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + this.ftpServerIP + ":" + this.ftpPort + "/" + _ftpRemoteDir  + fileInf.Name));

                // 指定数据传输类型
                reqFTP.UseBinary = true;

                // ftp用户名和密码 
                reqFTP.Credentials = new NetworkCredential(this.UserName, this.Password);

                // 默认为true，连接不会被关闭 
                // 在一个命令之后被执行 
                reqFTP.KeepAlive = false;

                // 指定执行什么命令 
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;


                // 上传文件时通知服务器文件的大小 
                reqFTP.ContentLength = fileInf.Length;

                // 缓冲大小设置为2kb 
                int buffLength = 2048;

                byte[] buff = new byte[buffLength];
                int contentLen;

                // 打开一个文件流 (System.IO.FileStream) 去读上传的文件 
                FileStream fs = fileInf.OpenRead();
                try
                {
                    // 把上传的文件写入流 
                    Stream strm = reqFTP.GetRequestStream();

                    // 每次读文件流的2kb 
                    contentLen = fs.Read(buff, 0, buffLength);

                    // 流内容没有结束 
                    while (contentLen != 0)
                    {
                        // 把内容从file stream 写入 upload stream 
                        strm.Write(buff, 0, contentLen);

                        contentLen = fs.Read(buff, 0, buffLength);
                    }
                    // 关闭两个流 
                    strm.Close();
                    fs.Close();

                    loginfo.WriteLine(string.Format("+++++FTP Upload End At: {0} +++++", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                    TimeSpan TStemp = DateTime.Now.Subtract(DTstart);
                    loginfo.WriteLine(string.Format("+++++FTP Upload Cost:{0}s +++++", TStemp.TotalSeconds.ToString()));

                    return true;
                }
                catch (System.Exception ex)
                {
                    loginfo.WriteLine(string.Format("+++++FTP upload Error {0}", ex.ToString()));
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                loginfo.WriteLine(string.Format("+++++FTP Error {0}",ex.ToString()));
            }
            return false;
           
            
        }


        //下载
        public bool Download()
        {
            FtpWebRequest reqFTP;

            DateTime DTstart = DateTime.Now;
            //log.Info("+++++FTP Download Begin At: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "+++++");

            try
            {
                FileStream outputStream = new FileStream(this.FileName, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + this.ftpServerIP + ":" + this.ftpPort + "/" + this.FileName));

                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;

                reqFTP.UseBinary = true;

                reqFTP.Credentials = new NetworkCredential(this.UserName, this.Password);

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();

                Stream ftpStream = response.GetResponseStream();

                long cl = response.ContentLength;

                int bufferSize = 2048;

                int readCount;

                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);

                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);

                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();

                outputStream.Close();

                response.Close();

                //log.Info("+++++FTP Download End At: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "+++++");

                //TimeSpan TStemp = DateTime.Now.Subtract(DTstart);
                // log.Info("+++++FTP Download Cost:" + TStemp.TotalSeconds.ToString() + "s" + "+++++");
                return true;
            }
            catch (Exception ex)
            {
                MsgSyncOut = ex.Message + "上传未成功\r\n";
                //DisplayErroMessage(EnumErrMsg.CustomDownloadFtpFileFault);
                //WriteLog(EnumErrMsg.CustomDownloadFtpFileFault, ex);
                return false;
            }
        }
    }
}
