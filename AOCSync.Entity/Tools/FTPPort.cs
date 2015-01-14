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
        //add by march 20140408 ��¼FTP�����е���־
        public LogInfo loginfo;
        //add by march 20140408 ��¼FTP�����е���־

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
            //add by march 20140408 ��¼FTP�����е���־
            loginfo = new LogInfo(username + ".log");
            //add by march 20140408 ��¼FTP�����е���־

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

        //public void Upload()           //�ϴ�

        //����Ŀ¼
        public void MakeDir(string dirName)
        {
            try
            {
                string uri = "ftp://" + ftpServerIP + "/" + dirName;
                FtpWebRequest reqFTP;
                // ����uri����FtpWebRequest����

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                // ָ�����ݴ�������

                reqFTP.UseBinary = true;

                // ftp�û���������

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
            
                // ����uri����FtpWebRequest���� 
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + this.ftpServerIP + ":" + this.ftpPort + "/" + _ftpRemoteDir  + fileInf.Name));

                // ָ�����ݴ�������
                reqFTP.UseBinary = true;

                // ftp�û��������� 
                reqFTP.Credentials = new NetworkCredential(this.UserName, this.Password);

                // Ĭ��Ϊtrue�����Ӳ��ᱻ�ر� 
                // ��һ������֮��ִ�� 
                reqFTP.KeepAlive = false;

                // ָ��ִ��ʲô���� 
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;


                // �ϴ��ļ�ʱ֪ͨ�������ļ��Ĵ�С 
                reqFTP.ContentLength = fileInf.Length;

                // �����С����Ϊ2kb 
                int buffLength = 2048;

                byte[] buff = new byte[buffLength];
                int contentLen;

                // ��һ���ļ��� (System.IO.FileStream) ȥ���ϴ����ļ� 
                FileStream fs = fileInf.OpenRead();
                try
                {
                    // ���ϴ����ļ�д���� 
                    Stream strm = reqFTP.GetRequestStream();

                    // ÿ�ζ��ļ�����2kb 
                    contentLen = fs.Read(buff, 0, buffLength);

                    // ������û�н��� 
                    while (contentLen != 0)
                    {
                        // �����ݴ�file stream д�� upload stream 
                        strm.Write(buff, 0, contentLen);

                        contentLen = fs.Read(buff, 0, buffLength);
                    }
                    // �ر������� 
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


        //����
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
                MsgSyncOut = ex.Message + "�ϴ�δ�ɹ�\r\n";
                //DisplayErroMessage(EnumErrMsg.CustomDownloadFtpFileFault);
                //WriteLog(EnumErrMsg.CustomDownloadFtpFileFault, ex);
                return false;
            }
        }
    }
}
