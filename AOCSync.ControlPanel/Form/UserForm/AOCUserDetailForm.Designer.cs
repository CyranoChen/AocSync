namespace AOCSync.ControlPanel
{
    partial class AOCUserDetailForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listViewExportColumns = new System.Windows.Forms.ListView();
            this.tbFTPPassWord = new System.Windows.Forms.TextBox();
            this.tbFTPLogName = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbListViewAllSelect = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbUserPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbPackSelect = new System.Windows.Forms.CheckBox();
            this.lblFlightNature = new System.Windows.Forms.Label();
            this.tbITVTime = new System.Windows.Forms.TextBox();
            this.lblITVTime = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.cbFlightPAX = new System.Windows.Forms.CheckBox();
            this.cbFlightCGO = new System.Windows.Forms.CheckBox();
            this.cbFlightSPE = new System.Windows.Forms.CheckBox();
            this.lblAirportIATA = new System.Windows.Forms.Label();
            this.cbPVG = new System.Windows.Forms.CheckBox();
            this.cbSHA = new System.Windows.Forms.CheckBox();
            this.tbFTPRemoteDir = new System.Windows.Forms.TextBox();
            this.ddlFTPMode = new System.Windows.Forms.ComboBox();
            this.lblFTPMode = new System.Windows.Forms.Label();
            this.lblFTPRemoteDir = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbFTPPort = new AOCSync.ControlPanel.NumberTextBox();
            this.tbFTPIP4 = new AOCSync.ControlPanel.NumberTextBox();
            this.tbFTPIP3 = new AOCSync.ControlPanel.NumberTextBox();
            this.tbFTPIP2 = new AOCSync.ControlPanel.NumberTextBox();
            this.tbFTPIP1 = new AOCSync.ControlPanel.NumberTextBox();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(233, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 34;
            this.label8.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = ".";
            // 
            // listViewExportColumns
            // 
            this.listViewExportColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewExportColumns.CheckBoxes = true;
            this.listViewExportColumns.Location = new System.Drawing.Point(9, 174);
            this.listViewExportColumns.Name = "listViewExportColumns";
            this.listViewExportColumns.Size = new System.Drawing.Size(567, 336);
            this.listViewExportColumns.TabIndex = 60;
            this.listViewExportColumns.UseCompatibleStateImageBehavior = false;
            this.listViewExportColumns.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewExportColumns_ItemChecked);
            // 
            // tbFTPPassWord
            // 
            this.tbFTPPassWord.Location = new System.Drawing.Point(404, 68);
            this.tbFTPPassWord.MaxLength = 30;
            this.tbFTPPassWord.Name = "tbFTPPassWord";
            this.tbFTPPassWord.Size = new System.Drawing.Size(172, 21);
            this.tbFTPPassWord.TabIndex = 40;
            // 
            // tbFTPLogName
            // 
            this.tbFTPLogName.Location = new System.Drawing.Point(104, 68);
            this.tbFTPLogName.MaxLength = 30;
            this.tbFTPLogName.Name = "tbFTPLogName";
            this.tbFTPLogName.Size = new System.Drawing.Size(172, 21);
            this.tbFTPLogName.TabIndex = 30;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(104, 10);
            this.tbUserName.MaxLength = 30;
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(172, 21);
            this.tbUserName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "ExportColumns:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "FTPIP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "FTPPassWord:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "FTPLogName:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserName:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(404, 516);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 70;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(501, 516);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 80;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbListViewAllSelect
            // 
            this.cbListViewAllSelect.AutoSize = true;
            this.cbListViewAllSelect.Location = new System.Drawing.Point(404, 120);
            this.cbListViewAllSelect.Name = "cbListViewAllSelect";
            this.cbListViewAllSelect.Size = new System.Drawing.Size(48, 16);
            this.cbListViewAllSelect.TabIndex = 20;
            this.cbListViewAllSelect.Text = "全选";
            this.cbListViewAllSelect.UseVisualStyleBackColor = true;
            this.cbListViewAllSelect.CheckedChanged += new System.EventHandler(this.cbListViewAllSelect_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 72;
            this.label9.Text = "UserPassword:";
            // 
            // tbUserPassword
            // 
            this.tbUserPassword.Location = new System.Drawing.Point(404, 10);
            this.tbUserPassword.MaxLength = 30;
            this.tbUserPassword.Name = "tbUserPassword";
            this.tbUserPassword.Size = new System.Drawing.Size(172, 21);
            this.tbUserPassword.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(315, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 74;
            this.label10.Text = "FTPPort:";
            // 
            // cbPackSelect
            // 
            this.cbPackSelect.AutoSize = true;
            this.cbPackSelect.Location = new System.Drawing.Point(462, 120);
            this.cbPackSelect.Name = "cbPackSelect";
            this.cbPackSelect.Size = new System.Drawing.Size(114, 16);
            this.cbPackSelect.TabIndex = 81;
            this.cbPackSelect.Text = "是否打包上传FTP";
            this.cbPackSelect.UseVisualStyleBackColor = true;
            // 
            // lblFlightNature
            // 
            this.lblFlightNature.AutoSize = true;
            this.lblFlightNature.Location = new System.Drawing.Point(9, 148);
            this.lblFlightNature.Name = "lblFlightNature";
            this.lblFlightNature.Size = new System.Drawing.Size(83, 12);
            this.lblFlightNature.TabIndex = 82;
            this.lblFlightNature.Text = "FlightNature:";
            // 
            // tbITVTime
            // 
            this.tbITVTime.Location = new System.Drawing.Point(104, 116);
            this.tbITVTime.MaxLength = 30;
            this.tbITVTime.Name = "tbITVTime";
            this.tbITVTime.Size = new System.Drawing.Size(122, 21);
            this.tbITVTime.TabIndex = 83;
            // 
            // lblITVTime
            // 
            this.lblITVTime.AutoSize = true;
            this.lblITVTime.Location = new System.Drawing.Point(8, 121);
            this.lblITVTime.Name = "lblITVTime";
            this.lblITVTime.Size = new System.Drawing.Size(53, 12);
            this.lblITVTime.TabIndex = 84;
            this.lblITVTime.Text = "ITVTime:";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Location = new System.Drawing.Point(232, 119);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(53, 12);
            this.lbltime.TabIndex = 85;
            this.lbltime.Text = "（分钟）";
            // 
            // cbFlightPAX
            // 
            this.cbFlightPAX.AutoSize = true;
            this.cbFlightPAX.Checked = true;
            this.cbFlightPAX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFlightPAX.Location = new System.Drawing.Point(105, 144);
            this.cbFlightPAX.Name = "cbFlightPAX";
            this.cbFlightPAX.Size = new System.Drawing.Size(36, 16);
            this.cbFlightPAX.TabIndex = 86;
            this.cbFlightPAX.Text = "客";
            this.cbFlightPAX.UseVisualStyleBackColor = true;
            // 
            // cbFlightCGO
            // 
            this.cbFlightCGO.AutoSize = true;
            this.cbFlightCGO.Checked = true;
            this.cbFlightCGO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFlightCGO.Location = new System.Drawing.Point(150, 144);
            this.cbFlightCGO.Name = "cbFlightCGO";
            this.cbFlightCGO.Size = new System.Drawing.Size(36, 16);
            this.cbFlightCGO.TabIndex = 87;
            this.cbFlightCGO.Text = "货";
            this.cbFlightCGO.UseVisualStyleBackColor = true;
            // 
            // cbFlightSPE
            // 
            this.cbFlightSPE.AutoSize = true;
            this.cbFlightSPE.Checked = true;
            this.cbFlightSPE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFlightSPE.Location = new System.Drawing.Point(192, 144);
            this.cbFlightSPE.Name = "cbFlightSPE";
            this.cbFlightSPE.Size = new System.Drawing.Size(48, 16);
            this.cbFlightSPE.TabIndex = 88;
            this.cbFlightSPE.Text = "特殊";
            this.cbFlightSPE.UseVisualStyleBackColor = true;
            // 
            // lblAirportIATA
            // 
            this.lblAirportIATA.AutoSize = true;
            this.lblAirportIATA.Location = new System.Drawing.Point(321, 145);
            this.lblAirportIATA.Name = "lblAirportIATA";
            this.lblAirportIATA.Size = new System.Drawing.Size(77, 12);
            this.lblAirportIATA.TabIndex = 89;
            this.lblAirportIATA.Text = "AirportIATA:";
            // 
            // cbPVG
            // 
            this.cbPVG.AutoSize = true;
            this.cbPVG.Checked = true;
            this.cbPVG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPVG.Location = new System.Drawing.Point(404, 144);
            this.cbPVG.Name = "cbPVG";
            this.cbPVG.Size = new System.Drawing.Size(48, 16);
            this.cbPVG.TabIndex = 90;
            this.cbPVG.Text = "浦东";
            this.cbPVG.UseVisualStyleBackColor = true;
            // 
            // cbSHA
            // 
            this.cbSHA.AutoSize = true;
            this.cbSHA.Checked = true;
            this.cbSHA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSHA.Location = new System.Drawing.Point(462, 144);
            this.cbSHA.Name = "cbSHA";
            this.cbSHA.Size = new System.Drawing.Size(48, 16);
            this.cbSHA.TabIndex = 91;
            this.cbSHA.Text = "虹桥";
            this.cbSHA.UseVisualStyleBackColor = true;
            // 
            // tbFTPRemoteDir
            // 
            this.tbFTPRemoteDir.Location = new System.Drawing.Point(104, 92);
            this.tbFTPRemoteDir.MaxLength = 30;
            this.tbFTPRemoteDir.Name = "tbFTPRemoteDir";
            this.tbFTPRemoteDir.Size = new System.Drawing.Size(172, 21);
            this.tbFTPRemoteDir.TabIndex = 92;
            // 
            // ddlFTPMode
            // 
            this.ddlFTPMode.DisplayMember = "PASV, PORT";
            this.ddlFTPMode.FormattingEnabled = true;
            this.ddlFTPMode.Items.AddRange(new object[] {
            "PORT",
            "PASV"});
            this.ddlFTPMode.Location = new System.Drawing.Point(404, 93);
            this.ddlFTPMode.Name = "ddlFTPMode";
            this.ddlFTPMode.Size = new System.Drawing.Size(172, 20);
            this.ddlFTPMode.TabIndex = 93;
            // 
            // lblFTPMode
            // 
            this.lblFTPMode.AutoSize = true;
            this.lblFTPMode.Location = new System.Drawing.Point(315, 98);
            this.lblFTPMode.Name = "lblFTPMode";
            this.lblFTPMode.Size = new System.Drawing.Size(53, 12);
            this.lblFTPMode.TabIndex = 94;
            this.lblFTPMode.Text = "FTPMode:";
            // 
            // lblFTPRemoteDir
            // 
            this.lblFTPRemoteDir.AutoSize = true;
            this.lblFTPRemoteDir.Location = new System.Drawing.Point(9, 98);
            this.lblFTPRemoteDir.Name = "lblFTPRemoteDir";
            this.lblFTPRemoteDir.Size = new System.Drawing.Size(83, 12);
            this.lblFTPRemoteDir.TabIndex = 95;
            this.lblFTPRemoteDir.Text = "FTPRemoteDir:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 514);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 12);
            this.label11.TabIndex = 96;
            // 
            // tbFTPPort
            // 
            this.tbFTPPort.Location = new System.Drawing.Point(404, 37);
            this.tbFTPPort.MaxLength = 10;
            this.tbFTPPort.Name = "tbFTPPort";
            this.tbFTPPort.Size = new System.Drawing.Size(172, 21);
            this.tbFTPPort.TabIndex = 25;
            // 
            // tbFTPIP4
            // 
            this.tbFTPIP4.Location = new System.Drawing.Point(247, 37);
            this.tbFTPIP4.MaxLength = 3;
            this.tbFTPIP4.Name = "tbFTPIP4";
            this.tbFTPIP4.Size = new System.Drawing.Size(27, 21);
            this.tbFTPIP4.TabIndex = 24;
            // 
            // tbFTPIP3
            // 
            this.tbFTPIP3.Location = new System.Drawing.Point(200, 37);
            this.tbFTPIP3.MaxLength = 3;
            this.tbFTPIP3.Name = "tbFTPIP3";
            this.tbFTPIP3.Size = new System.Drawing.Size(27, 21);
            this.tbFTPIP3.TabIndex = 23;
            // 
            // tbFTPIP2
            // 
            this.tbFTPIP2.Location = new System.Drawing.Point(150, 37);
            this.tbFTPIP2.MaxLength = 3;
            this.tbFTPIP2.Name = "tbFTPIP2";
            this.tbFTPIP2.Size = new System.Drawing.Size(27, 21);
            this.tbFTPIP2.TabIndex = 22;
            // 
            // tbFTPIP1
            // 
            this.tbFTPIP1.Location = new System.Drawing.Point(102, 37);
            this.tbFTPIP1.MaxLength = 3;
            this.tbFTPIP1.Name = "tbFTPIP1";
            this.tbFTPIP1.Size = new System.Drawing.Size(27, 21);
            this.tbFTPIP1.TabIndex = 21;
            // 
            // AOCUserDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 541);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblFTPRemoteDir);
            this.Controls.Add(this.lblFTPMode);
            this.Controls.Add(this.ddlFTPMode);
            this.Controls.Add(this.tbFTPRemoteDir);
            this.Controls.Add(this.cbSHA);
            this.Controls.Add(this.cbPVG);
            this.Controls.Add(this.lblAirportIATA);
            this.Controls.Add(this.cbFlightSPE);
            this.Controls.Add(this.cbFlightCGO);
            this.Controls.Add(this.cbFlightPAX);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.lblITVTime);
            this.Controls.Add(this.tbITVTime);
            this.Controls.Add(this.lblFlightNature);
            this.Controls.Add(this.cbPackSelect);
            this.Controls.Add(this.tbFTPPort);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbUserPassword);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbFTPIP4);
            this.Controls.Add(this.tbFTPIP3);
            this.Controls.Add(this.tbFTPIP2);
            this.Controls.Add(this.tbFTPIP1);
            this.Controls.Add(this.cbListViewAllSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listViewExportColumns);
            this.Controls.Add(this.tbFTPPassWord);
            this.Controls.Add(this.tbFTPLogName);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AOCUserDetailForm";
            this.Text = "用户详情";
            this.Load += new System.EventHandler(this.AOCUserDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listViewExportColumns;
        private System.Windows.Forms.TextBox tbFTPPassWord;
        private System.Windows.Forms.TextBox tbFTPLogName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbListViewAllSelect;
        private NumberTextBox tbFTPIP1;
        private NumberTextBox tbFTPIP2;
        private NumberTextBox tbFTPIP3;
        private NumberTextBox tbFTPIP4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbUserPassword;
        private System.Windows.Forms.Label label10;
        private NumberTextBox tbFTPPort;
        private System.Windows.Forms.CheckBox cbPackSelect;
        private System.Windows.Forms.Label lblFlightNature;
        private System.Windows.Forms.TextBox tbITVTime;
        private System.Windows.Forms.Label lblITVTime;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.CheckBox cbFlightPAX;
        private System.Windows.Forms.CheckBox cbFlightCGO;
        private System.Windows.Forms.CheckBox cbFlightSPE;
        private System.Windows.Forms.Label lblAirportIATA;
        private System.Windows.Forms.CheckBox cbPVG;
        private System.Windows.Forms.CheckBox cbSHA;
        private System.Windows.Forms.TextBox tbFTPRemoteDir;
        private System.Windows.Forms.ComboBox ddlFTPMode;
        private System.Windows.Forms.Label lblFTPMode;
        private System.Windows.Forms.Label lblFTPRemoteDir;
        private System.Windows.Forms.Label label11;
    }
}