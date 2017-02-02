using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

using AOCSync.Entity;

namespace AOCSync.ControlPanel
{
    public partial class AOCUserDetailForm : Form
    {
        enum AOCUserType
        {
            Insert,
            Update
        }

        private AOCUserData _aocUserData;
        private string ColumnsCount;//字段总数
        private string SelectColumnsCount;//已选字段数
        public AOCUserDetailForm()
        {
            InitializeComponent();
        }

        public AOCUserDetailForm(AOCUserData aocUserData)
            : this()
        {
            _aocUserData = aocUserData;
        }

        private void AOCUserDetailForm_Load(object sender, EventArgs e)
        {
            InitListView();
            if (_aocUserData == null)
            {
                this.Text = "新增用户";
                btnConfirm.Text = "新增";
                SelectColumnsCount = "已选0个字段";
                ddlFTPMode.Text = "PORT"; //FTPMode初始值
            }
            else
            {
                this.Text = "用户详情";
                btnConfirm.Text = "保存";
                InitAOCUserControls();
            }
            label11.Text=SelectColumnsCount + "/" + ColumnsCount;

        }

        #region Form Control Function

        private void InitAOCUserControls()
        {
            SetUserName();
            SetFTPIP();
            SetFTPLogName();
            SetFTPPassWord();
            SetFTPRemoteDir();
            SetFTPMode();
            SetExportColumns();
            SetIsPack();
            SetITVTime();
            SetAirportIATA();
            SetFlightNature();
            SetFTPPort();
            SetUserPassword();
            SetIsEnable();
        }

        private void InitListView()
        {
            List<string> exportColumnsList = InitAOCProperties();
            ColumnsCount = string.Format("共{0}个字段", exportColumnsList.Count);
            listViewExportColumns.Items.Clear();
            listViewExportColumns.CheckBoxes = true;
            listViewExportColumns.View = View.List;
            string text=string.Empty;
            foreach (string strColumns in exportColumnsList)
            {
                text = AOCCONBINE.ShowName(strColumns) + "|" + strColumns;
                listViewExportColumns.Items.Add(strColumns, text, strColumns);
            }
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsNull = true;

                foreach (ListViewItem listItem in listViewExportColumns.Items)
                {
                    if (listItem.Checked == true)
                    {
                        IsNull = false;
                    }
                }
                if (IsNull == true)
                {
                    //MessageBox.Show("必须选一个或以上字段");
                    throw new Exception("必须选一个或以上字段");

                }
                else
                {
                    PackgeAOCUser();

                    if (btnConfirm.Text == "新增")
                    {

                        InsertAOCUser();
                    }
                    else if (btnConfirm.Text == "保存")
                    {

                        UpdateAOCUser();
                    }
                    AOCUserData.Cache.RefreshCache();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Data Error:{0}", ex.Message));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbListViewAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            bool listViewItemAllCheck = cbListViewAllSelect.Checked;

            foreach (ListViewItem listItem in listViewExportColumns.Items)
            {
                listItem.Checked = listViewItemAllCheck;
            }
        }

        #endregion

        #region Form Private Function
        private List<string> InitAOCProperties()
        {
            List<string> exportColumnsList = new List<string>();
            //Type typeAOC = typeof(AOCDataCC);
            Type typeAOCCONBINE = typeof(AOCCONBINE);
            PropertyInfo[] propertiesAOCFQS = typeAOCCONBINE.GetProperties();
            
            foreach (PropertyInfo aocfqsInfo in propertiesAOCFQS)
            {
                exportColumnsList.Add(aocfqsInfo.Name);
            }
            exportColumnsList.Sort();
            return exportColumnsList;
        }

        private void InsertAOCUser()
        {
            string functionInfo = AOCSync.Entity.Tools.TextTool.GetFunctionInfo();

            _aocUserData.Insert();
        }

        private void PackgeAOCUser()
        {
            if (_aocUserData == null)
            {
                _aocUserData = new AOCUserData();
            }
            _aocUserData.UserName = GetUserName();
            _aocUserData.UserPassword = GetUserPassword();
            _aocUserData.FTPIP = GetFTPIP();
            _aocUserData.FTPPort = GetFTPPort();
            _aocUserData.FTPLogName = GetFTPLogName();
            _aocUserData.FTPPassword = GetFTPPassWord();
            _aocUserData.FTPRemoteDir = GetFTPRemoteDir();
            _aocUserData.FTPMode = GetFTPMode();
            _aocUserData.ExportColumns = GetExportColumns();
            _aocUserData.IsPack = GetIsPack();
            _aocUserData.ITVTime = GetITVTime();
            _aocUserData.AirportIATA = GetAirportIATA();
            _aocUserData.FlightNature = GetFlightNature();
            _aocUserData.IsEnable = GetIsEnable();
        }

        private void UpdateAOCUser()
        {
            string functionInfo = AOCSync.Entity.Tools.TextTool.GetFunctionInfo();

            _aocUserData.Update();
        }

        private void SetUserName()
        {
            tbUserName.Text = _aocUserData.UserName;
        }

        private string GetUserName()
        {
            if (!string.IsNullOrEmpty(tbUserName.Text.Trim()))
            {
                return tbUserName.Text.Trim();
            }
            else
            {
                throw new Exception("UserName不能为空");
            }
        }

        private void SetUserPassword()
        {
            tbUserPassword.Text = _aocUserData.UserPassword;
        }

        private string GetUserPassword()
        {
            return tbUserPassword.Text.Trim();
        }

        private void SetFTPIP()
        {
            if (_aocUserData.FTPIP.Contains(".") == false)
            {
                return;
            }

            string[] IPSplit = _aocUserData.FTPIP.Split('.');
            TextBox[] tbIPs = new TextBox[] { tbFTPIP1, tbFTPIP2, tbFTPIP3, tbFTPIP4 };

            for (int index = 0; index < IPSplit.Length; index++)
            {
                tbIPs[index].Text = IPSplit[index];
            }
        }

        private string GetFTPIP()
        {
            if (!string.IsNullOrEmpty(tbFTPIP1.Text.Trim()) && !string.IsNullOrEmpty(tbFTPIP2.Text.Trim()) && !string.IsNullOrEmpty(tbFTPIP3.Text.Trim()) && !string.IsNullOrEmpty(tbFTPIP4.Text.Trim()))
            {
                return string.Format("{0}.{1}.{2}.{3}", tbFTPIP1.Text, tbFTPIP2.Text, tbFTPIP3.Text, tbFTPIP4.Text);
            }
            else
            {
                throw new Exception("ip错误");
            }
        }

        private void SetFTPPort()
        {
            tbFTPPort.Text = _aocUserData.FTPPort;
        }

        private string GetFTPPort()
        {
            return tbFTPPort.Text;
        }

        private void SetFTPLogName()
        {
            tbFTPLogName.Text = _aocUserData.FTPLogName;
        }

        private string GetFTPLogName()
        {
            return tbFTPLogName.Text;
        }

        private void SetFTPPassWord()
        {
            tbFTPPassWord.Text = _aocUserData.FTPPassword;
        }

        private string GetFTPPassWord()
        {
            return tbFTPPassWord.Text;
        }

        private void SetFTPRemoteDir()
        {
            tbFTPRemoteDir.Text = _aocUserData.FTPRemoteDir;
        }

        private string GetFTPRemoteDir()
        {
            return tbFTPRemoteDir.Text.Trim();
        }

        private void SetFTPMode()
        {
            ddlFTPMode.Text = _aocUserData.FTPMode;
        }

        private string GetFTPMode()
        {
            return ddlFTPMode.SelectedItem.ToString();
        }

        private void SetExportColumns()
        {
            SetExportColumnsToListViewExportColumns(_aocUserData.ExportColumns);
        }

        private string GetExportColumns()
        {
            return GetExportColumnsFromListViewExportColumns();
        }

        private string GetExportColumnsFromListViewExportColumns()
        {
            string strExportColumnsResult = string.Empty;
            string splitSymbol = ",";

            foreach (ListViewItem lvItem in listViewExportColumns.Items)
            {
                if (lvItem.Checked)
                {
                    strExportColumnsResult += string.Format("{0}{1}", lvItem.Name.ToString(), splitSymbol);
                }
                else
                {
                    //Nothing to do
                }
            }

            if (strExportColumnsResult.EndsWith(splitSymbol))
            {
                strExportColumnsResult = strExportColumnsResult.Remove(strExportColumnsResult.Length - splitSymbol.Length);
            }

            return strExportColumnsResult;
        }

        private void SetExportColumnsToListViewExportColumns(string userExportColumns)
        {
            char splitSymbol = ',';
            string msgErro = string.Empty;
            InitListView();
           
            string[] exportColumns = userExportColumns.Split(splitSymbol);
            SelectColumnsCount = string.Format("已选{0}个字段", exportColumns.Length);
            foreach (string strColumn in exportColumns)
            {
                if (listViewExportColumns.Items.ContainsKey(strColumn))
                {
                    listViewExportColumns.Items[strColumn].Checked = true;
                }
            }
        }

        private void SetIsPack()
        {
            cbPackSelect.Checked = bool.Parse(_aocUserData.IsPack);

        }
        private string GetIsPack()
        {
            return cbPackSelect.Checked.ToString();
        }
        private void SetIsEnable()
        {
            CKEnable.Checked = _aocUserData.IsEnable;
        }
        private bool GetIsEnable()
        {
            return CKEnable.Checked;
        }

        private int GetITVTime()
        {
            if (!string.IsNullOrEmpty(tbITVTime.Text.Trim()))
            {
                return Convert.ToInt16(tbITVTime.Text.Trim());
            }
            else
            {
                return AOCConfig.INTERVALEVENT / 60 / 1000;
            }
        }

        private string SetITVTime()
        {
            return tbITVTime.Text = _aocUserData.ITVTime.ToString();
        }

        private int GetAirportIATA()
        {
            if (cbPVG != null && cbSHA != null)
            {
                if (cbPVG.Checked && !cbSHA.Checked)
                {
                    return 1;
                }
                else if (!cbPVG.Checked && cbSHA.Checked)
                {
                    return 2;
                }
                else if (cbPVG.Checked && cbSHA.Checked)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else { return -1; };
        }

        private void SetAirportIATA()
        {
            int _iata = _aocUserData.AirportIATA;

            if (_iata >= 0 && _iata < 3)
            {
                if (_iata == 0)
                {
                    cbPVG.Checked = true;
                    cbSHA.Checked = true;
                }
                else if (_iata == 1)
                {
                    cbPVG.Checked = true;
                    cbSHA.Checked = false;
                }
                else if (_iata == 2)
                {
                    cbPVG.Checked = false;
                    cbSHA.Checked = true;
                }
            }
            else
            {
                cbPVG.Checked = false;
                cbSHA.Checked = false;
            }
        }

        private string GetFlightNature()
        {
            string _retValue = string.Empty;

            if (cbFlightPAX != null && cbFlightCGO != null && cbFlightSPE != null)
            {
                _retValue = string.Format("{0},{1},{2}", cbFlightPAX.Checked ? "1" : "0", cbFlightCGO.Checked ? "1" : "0", cbFlightSPE.Checked ? "1" : "0");

                return _retValue;
            }
            else { return _retValue; };
        }

        private void SetFlightNature()
        {
            if (!string.IsNullOrEmpty(_aocUserData.FlightNature))
            {
                string[] _fn = _aocUserData.FlightNature.Split(',');

                cbFlightPAX.Checked = _fn[0].Equals("1") ? true : false;
                cbFlightCGO.Checked = _fn[1].Equals("1") ? true : false;
                cbFlightSPE.Checked = _fn[2].Equals("1") ? true : false;
            }
            else
            {
                cbFlightPAX.Checked = false;
                cbFlightCGO.Checked = false;
                cbFlightSPE.Checked = false;
            }
        }

        #endregion  

        private void listViewExportColumns_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            SelectColumnsCount =string.Format("已选{0}个字段", listViewExportColumns.CheckedItems.Count);
            label11.Text = SelectColumnsCount + "/" + ColumnsCount;
        }


    }
}