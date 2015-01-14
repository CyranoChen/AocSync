namespace AOCSync.ControlPanel
{
    partial class AOCSyncTestForm
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
            this.dtpCallCenterTime = new System.Windows.Forms.DateTimePicker();
            this.btnCCSHATest = new System.Windows.Forms.Button();
            this.rtbMsgTextBox = new System.Windows.Forms.RichTextBox();
            this.btnCCPVGTest = new System.Windows.Forms.Button();
            this.dgvAOC = new System.Windows.Forms.DataGridView();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefreshAOC = new System.Windows.Forms.Button();
            this.btnDAY = new System.Windows.Forms.Button();
            this.gbITVArea = new System.Windows.Forms.GroupBox();
            this.btnFQCCTest = new System.Windows.Forms.Button();
            this.btnFQSPVGTest = new System.Windows.Forms.Button();
            this.btnSHATransError = new System.Windows.Forms.Button();
            this.gbDAYArea = new System.Windows.Forms.GroupBox();
            this.btnFQSDAY = new System.Windows.Forms.Button();
            this.gbUserArea = new System.Windows.Forms.GroupBox();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnDataDayTest = new System.Windows.Forms.Button();
            this.gbDATArea = new System.Windows.Forms.GroupBox();
            this.btnftpitv = new System.Windows.Forms.Button();
            this.btnftpday = new System.Windows.Forms.Button();
            this.btnDataITVTest = new System.Windows.Forms.Button();
            this.btnRefreshAOCFQS = new System.Windows.Forms.Button();
            this.dgAOCFQS = new System.Windows.Forms.DataGridView();
            this.NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butCCToHIS = new System.Windows.Forms.Button();
            this.butFQSToHIS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAOC)).BeginInit();
            this.gbITVArea.SuspendLayout();
            this.gbDAYArea.SuspendLayout();
            this.gbUserArea.SuspendLayout();
            this.gbDATArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAOCFQS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpCallCenterTime
            // 
            this.dtpCallCenterTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCallCenterTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCallCenterTime.Location = new System.Drawing.Point(12, 13);
            this.dtpCallCenterTime.Name = "dtpCallCenterTime";
            this.dtpCallCenterTime.Size = new System.Drawing.Size(159, 20);
            this.dtpCallCenterTime.TabIndex = 0;
            // 
            // btnCCSHATest
            // 
            this.btnCCSHATest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCCSHATest.Location = new System.Drawing.Point(250, 13);
            this.btnCCSHATest.Name = "btnCCSHATest";
            this.btnCCSHATest.Size = new System.Drawing.Size(75, 25);
            this.btnCCSHATest.TabIndex = 1;
            this.btnCCSHATest.Text = "同步CC虹桥客班";
            this.btnCCSHATest.UseVisualStyleBackColor = true;
            this.btnCCSHATest.Click += new System.EventHandler(this.btnCCSHATest_Click);
            // 
            // rtbMsgTextBox
            // 
            this.rtbMsgTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMsgTextBox.Location = new System.Drawing.Point(13, 197);
            this.rtbMsgTextBox.Name = "rtbMsgTextBox";
            this.rtbMsgTextBox.Size = new System.Drawing.Size(692, 155);
            this.rtbMsgTextBox.TabIndex = 2;
            this.rtbMsgTextBox.Text = "";
            // 
            // btnCCPVGTest
            // 
            this.btnCCPVGTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCCPVGTest.Location = new System.Drawing.Point(331, 13);
            this.btnCCPVGTest.Name = "btnCCPVGTest";
            this.btnCCPVGTest.Size = new System.Drawing.Size(75, 25);
            this.btnCCPVGTest.TabIndex = 3;
            this.btnCCPVGTest.Text = "同步CC浦东客班";
            this.btnCCPVGTest.UseVisualStyleBackColor = true;
            this.btnCCPVGTest.Click += new System.EventHandler(this.btnCCPVGTest_Click);
            // 
            // dgvAOC
            // 
            this.dgvAOC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAOC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO});
            this.dgvAOC.Location = new System.Drawing.Point(13, 359);
            this.dgvAOC.Name = "dgvAOC";
            this.dgvAOC.RowHeadersVisible = false;
            this.dgvAOC.RowTemplate.Height = 23;
            this.dgvAOC.Size = new System.Drawing.Size(692, 293);
            this.dgvAOC.TabIndex = 4;
            // 
            // NO
            // 
            this.NO.HeaderText = "NO";
            this.NO.Name = "NO";
            // 
            // btnRefreshAOC
            // 
            this.btnRefreshAOC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshAOC.Location = new System.Drawing.Point(592, 11);
            this.btnRefreshAOC.Name = "btnRefreshAOC";
            this.btnRefreshAOC.Size = new System.Drawing.Size(109, 25);
            this.btnRefreshAOC.TabIndex = 5;
            this.btnRefreshAOC.Text = "刷新AOC_CC表";
            this.btnRefreshAOC.UseVisualStyleBackColor = true;
            this.btnRefreshAOC.Click += new System.EventHandler(this.btnRefreshAOC_Click);
            // 
            // btnDAY
            // 
            this.btnDAY.Location = new System.Drawing.Point(171, 13);
            this.btnDAY.Name = "btnDAY";
            this.btnDAY.Size = new System.Drawing.Size(97, 25);
            this.btnDAY.TabIndex = 6;
            this.btnDAY.Text = "CC按日同步";
            this.btnDAY.UseVisualStyleBackColor = true;
            this.btnDAY.Click += new System.EventHandler(this.btnDAY_Click);
            // 
            // gbITVArea
            // 
            this.gbITVArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbITVArea.Controls.Add(this.btnFQCCTest);
            this.gbITVArea.Controls.Add(this.btnFQSPVGTest);
            this.gbITVArea.Controls.Add(this.btnSHATransError);
            this.gbITVArea.Controls.Add(this.btnCCSHATest);
            this.gbITVArea.Controls.Add(this.btnCCPVGTest);
            this.gbITVArea.Location = new System.Drawing.Point(293, 95);
            this.gbITVArea.Name = "gbITVArea";
            this.gbITVArea.Size = new System.Drawing.Size(412, 44);
            this.gbITVArea.TabIndex = 7;
            this.gbITVArea.TabStop = false;
            this.gbITVArea.Text = "轮询同步";
            // 
            // btnFQCCTest
            // 
            this.btnFQCCTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFQCCTest.Location = new System.Drawing.Point(169, 13);
            this.btnFQCCTest.Name = "btnFQCCTest";
            this.btnFQCCTest.Size = new System.Drawing.Size(75, 25);
            this.btnFQCCTest.TabIndex = 6;
            this.btnFQCCTest.Text = "同步CC";
            this.btnFQCCTest.UseVisualStyleBackColor = true;
            this.btnFQCCTest.Click += new System.EventHandler(this.btnFQCCTest_Click);
            // 
            // btnFQSPVGTest
            // 
            this.btnFQSPVGTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFQSPVGTest.Location = new System.Drawing.Point(87, 13);
            this.btnFQSPVGTest.Name = "btnFQSPVGTest";
            this.btnFQSPVGTest.Size = new System.Drawing.Size(75, 25);
            this.btnFQSPVGTest.TabIndex = 5;
            this.btnFQSPVGTest.Text = "同步FQS";
            this.btnFQSPVGTest.UseVisualStyleBackColor = true;
            this.btnFQSPVGTest.Click += new System.EventHandler(this.btnFQSPVGTest_Click);
            // 
            // btnSHATransError
            // 
            this.btnSHATransError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSHATransError.Location = new System.Drawing.Point(6, 13);
            this.btnSHATransError.Name = "btnSHATransError";
            this.btnSHATransError.Size = new System.Drawing.Size(75, 25);
            this.btnSHATransError.TabIndex = 4;
            this.btnSHATransError.Text = "Trans测试";
            this.btnSHATransError.UseVisualStyleBackColor = true;
            this.btnSHATransError.Click += new System.EventHandler(this.btnSHATransError_Click);
            // 
            // gbDAYArea
            // 
            this.gbDAYArea.Controls.Add(this.btnFQSDAY);
            this.gbDAYArea.Controls.Add(this.btnDAY);
            this.gbDAYArea.Location = new System.Drawing.Point(13, 95);
            this.gbDAYArea.Name = "gbDAYArea";
            this.gbDAYArea.Size = new System.Drawing.Size(274, 44);
            this.gbDAYArea.TabIndex = 7;
            this.gbDAYArea.TabStop = false;
            this.gbDAYArea.Text = "按日同步";
            // 
            // btnFQSDAY
            // 
            this.btnFQSDAY.Location = new System.Drawing.Point(70, 13);
            this.btnFQSDAY.Name = "btnFQSDAY";
            this.btnFQSDAY.Size = new System.Drawing.Size(97, 25);
            this.btnFQSDAY.TabIndex = 9;
            this.btnFQSDAY.Text = "FQS按日同步";
            this.btnFQSDAY.UseVisualStyleBackColor = true;
            this.btnFQSDAY.Click += new System.EventHandler(this.btnFQSDAY_Click);
            // 
            // gbUserArea
            // 
            this.gbUserArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUserArea.Controls.Add(this.btnUser);
            this.gbUserArea.Location = new System.Drawing.Point(12, 43);
            this.gbUserArea.Name = "gbUserArea";
            this.gbUserArea.Size = new System.Drawing.Size(693, 44);
            this.gbUserArea.TabIndex = 8;
            this.gbUserArea.TabStop = false;
            this.gbUserArea.Text = "配置区域";
            // 
            // btnUser
            // 
            this.btnUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUser.Location = new System.Drawing.Point(531, 13);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(158, 25);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "用户管理";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnDataDayTest
            // 
            this.btnDataDayTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataDayTest.Location = new System.Drawing.Point(34, 13);
            this.btnDataDayTest.Name = "btnDataDayTest";
            this.btnDataDayTest.Size = new System.Drawing.Size(100, 25);
            this.btnDataDayTest.TabIndex = 9;
            this.btnDataDayTest.Text = "按日DAT文件";
            this.btnDataDayTest.UseVisualStyleBackColor = true;
            this.btnDataDayTest.Click += new System.EventHandler(this.btnDataDayTest_Click);
            // 
            // gbDATArea
            // 
            this.gbDATArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDATArea.Controls.Add(this.btnftpitv);
            this.gbDATArea.Controls.Add(this.btnftpday);
            this.gbDATArea.Controls.Add(this.btnDataITVTest);
            this.gbDATArea.Controls.Add(this.btnDataDayTest);
            this.gbDATArea.Location = new System.Drawing.Point(13, 146);
            this.gbDATArea.Name = "gbDATArea";
            this.gbDATArea.Size = new System.Drawing.Size(458, 44);
            this.gbDATArea.TabIndex = 8;
            this.gbDATArea.TabStop = false;
            this.gbDATArea.Text = "DAT文件";
            // 
            // btnftpitv
            // 
            this.btnftpitv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnftpitv.Location = new System.Drawing.Point(352, 13);
            this.btnftpitv.Name = "btnftpitv";
            this.btnftpitv.Size = new System.Drawing.Size(100, 25);
            this.btnftpitv.TabIndex = 12;
            this.btnftpitv.Text = "同步上传DAT";
            this.btnftpitv.UseVisualStyleBackColor = true;
            this.btnftpitv.Click += new System.EventHandler(this.btnftpitv_Click);
            // 
            // btnftpday
            // 
            this.btnftpday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnftpday.Location = new System.Drawing.Point(246, 13);
            this.btnftpday.Name = "btnftpday";
            this.btnftpday.Size = new System.Drawing.Size(100, 25);
            this.btnftpday.TabIndex = 11;
            this.btnftpday.Text = "按日上传DAT";
            this.btnftpday.UseVisualStyleBackColor = true;
            this.btnftpday.Click += new System.EventHandler(this.btnftpday_Click);
            // 
            // btnDataITVTest
            // 
            this.btnDataITVTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataITVTest.Location = new System.Drawing.Point(140, 13);
            this.btnDataITVTest.Name = "btnDataITVTest";
            this.btnDataITVTest.Size = new System.Drawing.Size(100, 25);
            this.btnDataITVTest.TabIndex = 10;
            this.btnDataITVTest.Text = "同步DAT文件";
            this.btnDataITVTest.UseVisualStyleBackColor = true;
            this.btnDataITVTest.Click += new System.EventHandler(this.btnDataITVTest_Click);
            // 
            // btnRefreshAOCFQS
            // 
            this.btnRefreshAOCFQS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshAOCFQS.Location = new System.Drawing.Point(477, 11);
            this.btnRefreshAOCFQS.Name = "btnRefreshAOCFQS";
            this.btnRefreshAOCFQS.Size = new System.Drawing.Size(109, 25);
            this.btnRefreshAOCFQS.TabIndex = 9;
            this.btnRefreshAOCFQS.Text = "刷新AOC_FQS表";
            this.btnRefreshAOCFQS.UseVisualStyleBackColor = true;
            this.btnRefreshAOCFQS.Click += new System.EventHandler(this.btnRefreshAOCFQS_Click);
            // 
            // dgAOCFQS
            // 
            this.dgAOCFQS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAOCFQS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAOCFQS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUM});
            this.dgAOCFQS.Location = new System.Drawing.Point(13, 359);
            this.dgAOCFQS.Name = "dgAOCFQS";
            this.dgAOCFQS.RowHeadersVisible = false;
            this.dgAOCFQS.RowTemplate.Height = 23;
            this.dgAOCFQS.Size = new System.Drawing.Size(692, 293);
            this.dgAOCFQS.TabIndex = 10;
            // 
            // NUM
            // 
            this.NUM.HeaderText = "NO";
            this.NUM.Name = "NUM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butCCToHIS);
            this.groupBox1.Controls.Add(this.butFQSToHIS);
            this.groupBox1.Location = new System.Drawing.Point(477, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 44);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "移动至历史库";
            // 
            // butCCToHIS
            // 
            this.butCCToHIS.Location = new System.Drawing.Point(112, 13);
            this.butCCToHIS.Name = "butCCToHIS";
            this.butCCToHIS.Size = new System.Drawing.Size(100, 25);
            this.butCCToHIS.TabIndex = 1;
            this.butCCToHIS.Text = "CC";
            this.butCCToHIS.UseVisualStyleBackColor = true;
            this.butCCToHIS.Click += new System.EventHandler(this.butCCToHIS_Click);
            // 
            // butFQSToHIS
            // 
            this.butFQSToHIS.Location = new System.Drawing.Point(6, 13);
            this.butFQSToHIS.Name = "butFQSToHIS";
            this.butFQSToHIS.Size = new System.Drawing.Size(100, 25);
            this.butFQSToHIS.TabIndex = 0;
            this.butFQSToHIS.Text = "FQS";
            this.butFQSToHIS.UseVisualStyleBackColor = true;
            this.butFQSToHIS.Click += new System.EventHandler(this.butFQSToHIS_Click);
            // 
            // AOCSyncTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 664);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgAOCFQS);
            this.Controls.Add(this.btnRefreshAOCFQS);
            this.Controls.Add(this.gbDATArea);
            this.Controls.Add(this.gbUserArea);
            this.Controls.Add(this.gbDAYArea);
            this.Controls.Add(this.btnRefreshAOC);
            this.Controls.Add(this.gbITVArea);
            this.Controls.Add(this.dgvAOC);
            this.Controls.Add(this.rtbMsgTextBox);
            this.Controls.Add(this.dtpCallCenterTime);
            this.Name = "AOCSyncTestForm";
            this.Text = "CallCenterTimeTestForm";
            this.Load += new System.EventHandler(this.CallCenterWithDatepickForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAOC)).EndInit();
            this.gbITVArea.ResumeLayout(false);
            this.gbDAYArea.ResumeLayout(false);
            this.gbUserArea.ResumeLayout(false);
            this.gbDATArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAOCFQS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpCallCenterTime;
        private System.Windows.Forms.Button btnCCSHATest;
        private System.Windows.Forms.RichTextBox rtbMsgTextBox;
        private System.Windows.Forms.Button btnCCPVGTest;
        private System.Windows.Forms.DataGridView dgvAOC;
        private System.Windows.Forms.Button btnRefreshAOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.Button btnDAY;
        private System.Windows.Forms.GroupBox gbITVArea;
        private System.Windows.Forms.GroupBox gbDAYArea;
        private System.Windows.Forms.Button btnSHATransError;
        private System.Windows.Forms.GroupBox gbUserArea;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnDataDayTest;
        private System.Windows.Forms.GroupBox gbDATArea;
        private System.Windows.Forms.Button btnFQSDAY;
        private System.Windows.Forms.Button btnFQSPVGTest;
        private System.Windows.Forms.Button btnRefreshAOCFQS;
        private System.Windows.Forms.DataGridView dgAOCFQS;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUM;
        private System.Windows.Forms.Button btnFQCCTest;
        private System.Windows.Forms.Button btnDataITVTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butCCToHIS;
        private System.Windows.Forms.Button butFQSToHIS;
        private System.Windows.Forms.Button btnftpitv;
        private System.Windows.Forms.Button btnftpday;
    }
}

