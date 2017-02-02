using System;
using System.Collections.Generic;
using System.Windows.Forms;

using AOCSync.Entity;

namespace AOCSync.ControlPanel
{
    public partial class AOCUserForm : Form
    {
        private AOCUserData _aocUserData;

        public AOCUserForm()
        {
            InitializeComponent();
        }

        private void AOCUserForm_Load(object sender, EventArgs e)
        {
            InitDGVAOCUser();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AOCUserDetailForm aocUserDetail = new AOCUserDetailForm();
            if (DialogResult.OK == aocUserDetail.ShowDialog())
            {
                btnRefresh_Click(null,null);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_aocUserData != null)
            {
                AOCUserDetailForm aocUserDetail = new AOCUserDetailForm(_aocUserData);
                
                if (DialogResult.OK == aocUserDetail.ShowDialog())
                {
                    btnRefresh_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("Please select one row");
            }
        }

        private void dgvAOCUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                AOCUserData aocUserData = dgvAOCUser.Rows[e.RowIndex].DataBoundItem as AOCUserData;
                _aocUserData = aocUserData;
            }
            else
            {
                return;
            }
        }

        private void dgvAOCUser_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvAOCUser_CellMouseClick(sender, e);
            btnUpdate_Click(null, null);
        }

        private void InitDGVAOCUser()
        {
            List<AOCUserData> aocUserDataList = AOCUserData.GetAOCUserDatasAll();

            dgvAOCUser.DataSource = aocUserDataList;
            dgvAOCUser.ClearSelection();
             _aocUserData = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_aocUserData != null)
            {
                if (DialogResult.OK == MessageBox.Show("Are you sure to delete this USER?", "Warn", MessageBoxButtons.OKCancel))
                {
                    try
                    {
                        _aocUserData.Delete();
                        InitDGVAOCUser();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Delete User Error:{0}", ex.Message));
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select one row");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AOCUserData.Cache.RefreshCache();

            InitDGVAOCUser();
        }       

    }
}