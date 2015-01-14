using System;
using System.Collections.Generic;
using System.Windows.Forms;

using AOCSync.Entity;
using AOCSync.Entity.Tools;

namespace AOCSync.ControlPanel
{
    public partial class AOCSyncTestForm : Form
    {

        public AOCSyncTestForm()
        {
            InitializeComponent();
        }

        #region 刷新数据

        private void btnRefreshAOCFQS_Click(object sender, EventArgs e)
        {
            AOCDataFQS.Cache.RefreshCache();
            rtbMsgTextBox.Clear();
            loadAOCFQS();
        }

        private void btnRefreshAOC_Click(object sender, EventArgs e)
        {
            AOCDataCC.Cache.RefreshCache();
            rtbMsgTextBox.Clear();
            loadAOC();
        }

        #endregion

        #region 用户管理

        private void btnUser_Click(object sender, EventArgs e)
        {
            AOCUserForm aocUserForm = new AOCUserForm();
            aocUserForm.Show();
        }

        #endregion

        #region 按日同步

        /// <summary>
        /// fqs按日同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFQSDAY_Click(object sender, EventArgs e)
        {
            DateTime checkPointTime = dtpCallCenterTime.Value;
            string msg = string.Empty;

            InitRtbMsgTextBox((sender as Button).Text);

            try
            {
                DateTime t1 = DateTime.Now;

                //该方法算法需要优化
                //BLFlightQuerySystemSyncTOAOC.SyncFlightQuerySystemToAOCFQSDAY(checkPointTime, out msg);

                BLFlightQuerySystemSyncTOAOC.SyncFlightQuerySystemToAOCFQSSimpleDAY(checkPointTime, out msg);


                Console.Write("\nSyncFlightQuerySystemToAOCFQSDAY USE ");
                Console.Write(DateTime.Now - t1);
                rtbMsgTextBox.Text += string.Format("{0}\r\n{1}\r\n", msg, DateTime.Now.ToString());
                loadAOCFQS();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// cc按日同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDAY_Click(object sender, EventArgs e)
        {
            DateTime checkPointTime = dtpCallCenterTime.Value;
            string msg = string.Empty;

            InitRtbMsgTextBox((sender as Button).Text);

            try
            {
                DateTime t1 = DateTime.Now;
                //该方法已被优化
                // BLCallCenterSyncTOAOC.SyncCallCenterToAOCDAY(checkPointTime, out msg);
                BLCallCenterSyncTOAOC.SyncCallCenterToAOCSimpleDAY(checkPointTime, out msg);

                Console.Write("\nSyncCallCenterToAOCDAY USE ");
                Console.Write(DateTime.Now - t1);
                rtbMsgTextBox.Text += string.Format("{0}\r\n{1}\r\n", msg, DateTime.Now.ToString());
                loadAOC();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        #endregion

        #region 轮询同步

        private void btnSHATransError_Click(object sender, EventArgs e)
        {
            DateTime checkPointTime = dtpCallCenterTime.Value;
            string msg = string.Empty;

            InitRtbMsgTextBox(string.Format("{0}:{1}", (sender as Button).Text, checkPointTime.ToString()));

            try
            {
                SyncCallCenterSHAToAOCITVError(checkPointTime, out msg);
                rtbMsgTextBox.Text += string.Format("{0}\r\n{1}\r\n", msg, DateTime.Now.ToString());
                loadAOC();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnFQSPVGTest_Click(object sender, EventArgs e)
        {
            DateTime checkPointTime = dtpCallCenterTime.Value;
            string msg = string.Empty;

            InitRtbMsgTextBox(string.Format("{0}:{1}", (sender as Button).Text, checkPointTime.ToString()));

            try
            {
                DateTime t1 = DateTime.Now;
                //BLCallCenterSyncTOAOC.SyncCallCenterSHAToAOCITV(checkPointTime, out msg);
          //    BLFlightQuerySystemSyncTOAOC.SyncFlightQuerySystemToAOCFQSITV(checkPointTime, out msg);
                BLFlightQuerySystemSyncTOAOC.SyncFlightQuerySystemToAOCFQSSimpleITV(checkPointTime, out msg);
                
                Console.Write("\nSyncFlightQuerySystemToAOCFQSITV USE ");
                Console.Write(DateTime.Now - t1);
                rtbMsgTextBox.Text += string.Format("{0}\r\n{1}\r\n", msg, DateTime.Now.ToString());
                loadAOCFQS();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnFQCCTest_Click(object sender, EventArgs e)
        {
            DateTime checkPointTime = dtpCallCenterTime.Value;
            string msg = string.Empty;

            InitRtbMsgTextBox(string.Format("{0}:{1}", (sender as Button).Text, checkPointTime.ToString()));

            try
            {
                DateTime t1 = DateTime.Now;
            // BLCallCenterSyncTOAOC.SyncCallCenterToAOCITV(checkPointTime, out msg);
                BLCallCenterSyncTOAOC.SyncCallCenterToAOCSimpleITV(checkPointTime, out msg);
                Console.Write("\nSyncCallCenterToAOCITV USE ");
                Console.Write(DateTime.Now - t1);
                rtbMsgTextBox.Text += string.Format("{0}\r\n{1}\r\n", msg, DateTime.Now.ToString());
                loadAOC();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnCCSHATest_Click(object sender, EventArgs e)
        {

            DateTime checkPointTime = dtpCallCenterTime.Value;
            string msg = string.Empty;

            InitRtbMsgTextBox(string.Format("{0}:{1}", (sender as Button).Text, checkPointTime.ToString()));

            try
            {
                DateTime t1 = DateTime.Now;
               // BLCallCenterSyncTOAOC.SyncCallCenterSHAToAOCITV(checkPointTime, out msg);
                BLCallCenterSyncTOAOC.SyncCallCenterSHAToAOCSimpleITV(checkPointTime, out msg);
                
                Console.Write("\nSyncCallCenterSHAToAOCITV USE ");
                Console.Write(DateTime.Now - t1);
                rtbMsgTextBox.Text += string.Format("{0}\r\n{1}\r\n", msg, DateTime.Now.ToString());
                loadAOC();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnCCPVGTest_Click(object sender, EventArgs e)
        {
            DateTime checkPointTime = dtpCallCenterTime.Value;
            string msg = string.Empty;

            InitRtbMsgTextBox(string.Format("{0}:{1}", (sender as Button).Text, checkPointTime.ToString()));

            try
            {
                DateTime t1 = DateTime.Now;
              // BLCallCenterSyncTOAOC.SyncCallCenterPVGToAOCITV(checkPointTime, out msg);
                BLCallCenterSyncTOAOC.SyncCallCenterPVGToAOCSimpleITV(checkPointTime, out msg);
                Console.Write("\nSyncCallCenterPVGToAOCITV USE ");
                Console.Write(DateTime.Now - t1);
                rtbMsgTextBox.Text += string.Format("{0}\r\n{1}\r\n", msg, DateTime.Now.ToString());
                loadAOC();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        #endregion

        #region DAT文件

        private void btnDataDayTest_Click(object sender, EventArgs e)
        {
            string msgOut = string.Empty;
            DateTime dateTime = dtpCallCenterTime.Value;
            BLOutput.DATDAY(dateTime, out msgOut);
            MessageBox.Show(msgOut);    
        }

        private void btnDataITVTest_Click(object sender, EventArgs e)
        {
            string msgOut = string.Empty;
            DateTime dateTime = dtpCallCenterTime.Value;
            BLOutput.DATITV(dateTime, out msgOut);
            MessageBox.Show(msgOut); 
        }

        private void btnftpday_Click(object sender, EventArgs e)
        {
            string msgOut = string.Empty;
            string MsgOut = string.Empty;
            DateTime dateTime = dtpCallCenterTime.Value;

            foreach (AOCUserData aocUserData in AOCUserData.Cache.AOCUserList)
            {
                BLOutput.FTPDAY(dateTime, out MsgOut, aocUserData);
                msgOut += MsgOut;
            }
            MessageBox.Show(msgOut);
        }

        private void btnftpitv_Click(object sender, EventArgs e)
        {
            string msgOut = string.Empty;
            DateTime dateTime = dtpCallCenterTime.Value;
            string MsgOut = string.Empty;
            foreach (AOCUserData aocUserData in AOCUserData.Cache.AOCUserList)
            {
                BLOutput.FTPITV(dateTime, out MsgOut, aocUserData);
                msgOut += MsgOut;
            }
           MessageBox.Show(msgOut);
        }

        #endregion

        #region 移动至历史库


        private void butFQSToHIS_Click(object sender, EventArgs e)
        {

            //DateTime t1 = DateTime.Now;

            DateTime dateTime = dtpCallCenterTime.Value;
            string msgOut = string.Empty;  
            BLMoveToHIS.MoveFQSToHis(dateTime, out msgOut);
            rtbMsgTextBox.Text += msgOut;
            ////DateTime dateTime = DateTime.Parse("2013-07-21");

            ////DateTime dateTimeEnd  = dateTime.Date;
            ////结束时间减去当天时间1秒
            //// dateTimeEnd.AddHours(0 - (double.Parse(dateTimeEnd.Hour.ToString()) * 3600)).AddMinutes(0 - (double.Parse(dateTimeEnd.Minute.ToString()) * 60)).AddSeconds(0 - double.Parse(dateTimeEnd.Second.ToString())).AddSeconds(-1);

            //// DateTime dateTimeStart = dateTime.Date.AddDays(AOCConfig.INTERVALEVENTHISTORYBEFORE);//
            //DateTime dateTimeEnd = dateTime.Date.AddDays(AOCConfig.INTERVALEVENTHISTORYBEFORE);

            //// string dtStart = dateTimeStart.ToString();
            //DateTime dateTimeStart = DateTime.MinValue;

            //List<AOCDataFQS> aocDataFQSList = AOCDataFQS.Cache.AOCDataList.FindAll(delegate(AOCDataFQS aocdataInList)
            //{
            //    DateTime dt = new DateTime();

            //    if (!string.IsNullOrEmpty(aocdataInList.STOD) && DateTime.TryParse(aocdataInList.STOD, out dt))
            //    {
            //        string dtStart = dateTimeStart.ToString("yyyyMMddHHmmss");
            //        string dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");
            //        return aocdataInList.STOD.CompareTo(dtStart) >= 0 && aocdataInList.STOD.CompareTo(dtEnd) <= 0;
            //    }
            //    else if (!string.IsNullOrEmpty(aocdataInList.SDT))
            //    {
            //        return DateTime.Parse(aocdataInList.SDT).CompareTo(dateTimeEnd) < 0;
            //    }
            //    else
            //    {
            //        return true;

            //    }
            //}
            //    );

            //AOCDataFQSHIS.GenerateAOCDataFQSHISByAOCDataFQS(aocDataFQSList);
            //AOCDataFQS.Cache.RefreshCache();
            //MessageBox.Show("完成 ");

            //Console.Write("\nmove to FQSHIS USE ");
            //Console.Write(DateTime.Now - t1);

        }

        private void butCCToHIS_Click(object sender, EventArgs e)
        {


            //DateTime t1 = DateTime.Now;

            DateTime dateTime = dtpCallCenterTime.Value;
          
            string msgOut = string.Empty;
            BLMoveToHIS.MoveCCToHis(dateTime, out msgOut);
            rtbMsgTextBox.Text += msgOut;
            //DateTime dateTime = DateTime.Parse("2013-07-21");
            //DateTime dateTimeEnd = dateTime.Date;
            //结束时间减去当天时间1秒

            //DateTime dateTimeEnd = dateTime.Date.AddDays(AOCConfig.INTERVALEVENTHISTORYBEFORE);
            //string dtEnd = dateTimeEnd.ToString("yyyyMMddHHmmss");

            //List<AOCDataCC> aocDataCCList = AOCDataCC.Cache.AOCDataList.FindAll(delegate(AOCDataCC aocdataInList)
            //{
            //    return aocdataInList.STOD.CompareTo(dtEnd) < 0;
            //}
            //    );

            //AOCDataCCHIS.GenerateAOCDataCCHISByAOCData(aocDataCCList);
            //AOCDataCC.Cache.RefreshCache();
            //MessageBox.Show("完成 ");
            //Console.Write("\nmove to CCHIS USE ");
            //Console.Write(DateTime.Now - t1);

        }


        #endregion

        private void CallCenterWithDatepickForm_Load(object sender, EventArgs e)
        {
            //btnRefreshAOC_Click(null, null);
        }

        private void InitRtbMsgTextBox(string msg)
        {
            rtbMsgTextBox.Clear();
            rtbMsgTextBox.Text = string.Format("START {0}\r\n", msg);
        }

        private void loadAOC()
        {
            dgvAOC.DataSource = AOCDataCC.Cache.AOCDataList;

            for (int rowIndex = 0; rowIndex < dgvAOC.Rows.Count; rowIndex++)
            {
                dgvAOC["NO", rowIndex].Value = (rowIndex + 1);
            }
            dgvAOC.Visible = true;
            dgAOCFQS.Visible = false;
        }

        private void loadAOCFQS()
        {
            dgAOCFQS.DataSource = AOCDataFQS.Cache.AOCDataList;

            for (int rowIndex = 0; rowIndex < dgAOCFQS.Rows.Count; rowIndex++)
            {
                dgAOCFQS["NUM", rowIndex].Value = (rowIndex + 1);
            }
            dgvAOC.Visible = false;
            dgAOCFQS.Visible = true;
        }

        private void SyncCallCenterSHAToAOCITVError(DateTime dateTimeCheckPoint, out string msgSyncOut)
        {
            msgSyncOut = string.Empty;
            int countList = int.MinValue;
            int countInsert = int.MinValue;
            int countUpdate = int.MinValue;
            string msgSync = string.Empty;
            string nameFunction = TextTool.GetFunctionInfo();
            DateTime dateTimeStart = dateTimeCheckPoint.AddHours(AOCConfig.INTERVALEVENTBEFORE);
            DateTime dateTimeEnd = dateTimeCheckPoint.AddHours(AOCConfig.INTERVALEVENTAFTER);

            try
            {
                List<CallCenterData> ccDataList = CallCenterData.GetCallCenterData(dateTimeStart, dateTimeEnd).FindAll(delegate(CallCenterData callCenterData)
                {
                    return callCenterData.AIRPORTIATACODE.Equals(AOCSync.Entity.AOCEnum.EnumAOCSync.SHA.ToString());
                });

                if (ccDataList != null && ccDataList.Count > 0)
                {
                    ccDataList[4].CHECKINOPENDATETIME = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                    BLCallCenterSyncTOAOC.GenerateAOCDataByCallCenterDataITV(ccDataList, out countList, out countInsert, out countUpdate);

                    msgSync = AOCLog.GenerateSuccessMSGForCallCenterSync(nameFunction, dateTimeCheckPoint, countList, countInsert, countUpdate);
                    msgSyncOut += msgSync;

                    AOCLog.logSuccess(msgSync);

                    //更新AOC航班缓存
                    msgSyncOut += "\r\nstart refreshing Cache\r\n";
                    AOCDataCC.Cache.RefreshCache();
                }
                else
                {
                    throw new Exception(string.Format("{0} Error", nameFunction));
                }
            }
            catch (Exception ex)
            {
                msgSync = AOCLog.GenerateParamsErroForCallCenterSync(nameFunction, dateTimeCheckPoint.ToString(), string.Empty);
                msgSyncOut += ex.Message.ToString();
                AOCLog.logErro(ex, msgSync);
            }
        } 
    }
}
