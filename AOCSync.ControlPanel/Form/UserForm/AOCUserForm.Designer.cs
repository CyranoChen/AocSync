namespace AOCSync.ControlPanel
{
    partial class AOCUserForm
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
            this.dgvAOCUser = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.gbControlArea = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAOCUser)).BeginInit();
            this.gbControlArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAOCUser
            // 
            this.dgvAOCUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAOCUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAOCUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAOCUser.Location = new System.Drawing.Point(12, 51);
            this.dgvAOCUser.MultiSelect = false;
            this.dgvAOCUser.Name = "dgvAOCUser";
            this.dgvAOCUser.ReadOnly = true;
            this.dgvAOCUser.RowHeadersVisible = false;
            this.dgvAOCUser.RowTemplate.Height = 23;
            this.dgvAOCUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAOCUser.Size = new System.Drawing.Size(640, 407);
            this.dgvAOCUser.TabIndex = 0;
            this.dgvAOCUser.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAOCUser_CellMouseClick);
            this.dgvAOCUser.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAOCUser_CellMouseDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(396, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(457, 11);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(55, 23);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(578, 11);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(55, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "刷新";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbControlArea
            // 
            this.gbControlArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControlArea.Controls.Add(this.btnDelete);
            this.gbControlArea.Controls.Add(this.btnAdd);
            this.gbControlArea.Controls.Add(this.btnReset);
            this.gbControlArea.Controls.Add(this.btnUpdate);
            this.gbControlArea.Location = new System.Drawing.Point(12, 5);
            this.gbControlArea.Name = "gbControlArea";
            this.gbControlArea.Size = new System.Drawing.Size(640, 40);
            this.gbControlArea.TabIndex = 14;
            this.gbControlArea.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(517, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // AOCUserForm
            // 
            this.ClientSize = new System.Drawing.Size(664, 462);
            this.Controls.Add(this.gbControlArea);
            this.Controls.Add(this.dgvAOCUser);
            this.Name = "AOCUserForm";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.AOCUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAOCUser)).EndInit();
            this.gbControlArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAOCUser;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox gbControlArea;
        private System.Windows.Forms.Button btnDelete;
    }
}