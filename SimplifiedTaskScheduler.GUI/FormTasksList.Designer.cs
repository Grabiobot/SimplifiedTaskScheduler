namespace SimplifiedTaskScheduler.GUI
{
    partial class FormTasksList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitTreeList = new System.Windows.Forms.SplitContainer();
            this.tvwFolders = new System.Windows.Forms.TreeView();
            this.mnuFolders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuFoldersAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFoldersRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFoldersDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitListDetail = new System.Windows.Forms.SplitContainer();
            this.lstTasks = new System.Windows.Forms.ListView();
            this.mnuTasks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuTasksRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTasksStop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTasksSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTasksToggleEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTasksEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTasksDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTasksSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTasksAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTasksClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tabTask = new System.Windows.Forms.TabControl();
            this.tbpDetails = new System.Windows.Forms.TabPage();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.tbpOutput = new System.Windows.Forms.TabPage();
            this.txtOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitTreeList)).BeginInit();
            this.splitTreeList.Panel1.SuspendLayout();
            this.splitTreeList.Panel2.SuspendLayout();
            this.splitTreeList.SuspendLayout();
            this.mnuFolders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitListDetail)).BeginInit();
            this.splitListDetail.Panel1.SuspendLayout();
            this.splitListDetail.Panel2.SuspendLayout();
            this.splitListDetail.SuspendLayout();
            this.mnuTasks.SuspendLayout();
            this.tabTask.SuspendLayout();
            this.tbpDetails.SuspendLayout();
            this.tbpOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitTreeList
            // 
            this.splitTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTreeList.Location = new System.Drawing.Point(0, 0);
            this.splitTreeList.Margin = new System.Windows.Forms.Padding(2);
            this.splitTreeList.Name = "splitTreeList";
            // 
            // splitTreeList.Panel1
            // 
            this.splitTreeList.Panel1.Controls.Add(this.tvwFolders);
            this.splitTreeList.Panel1.Resize += new System.EventHandler(this.SplitTreeList_Panel1_Resize);
            // 
            // splitTreeList.Panel2
            // 
            this.splitTreeList.Panel2.Controls.Add(this.splitListDetail);
            this.splitTreeList.Panel2.Resize += new System.EventHandler(this.SplitTreeList_Panel2_Resize);
            this.splitTreeList.Size = new System.Drawing.Size(936, 536);
            this.splitTreeList.SplitterDistance = 310;
            this.splitTreeList.SplitterWidth = 9;
            this.splitTreeList.TabIndex = 0;
            // 
            // tvwFolders
            // 
            this.tvwFolders.ContextMenuStrip = this.mnuFolders;
            this.tvwFolders.Location = new System.Drawing.Point(22, 10);
            this.tvwFolders.Margin = new System.Windows.Forms.Padding(2);
            this.tvwFolders.Name = "tvwFolders";
            this.tvwFolders.Size = new System.Drawing.Size(145, 341);
            this.tvwFolders.TabIndex = 0;
            // 
            // mnuFolders
            // 
            this.mnuFolders.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuFolders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFoldersAdd,
            this.mnuFoldersRename,
            this.mnuFoldersDelete});
            this.mnuFolders.Name = "mnuFolders";
            this.mnuFolders.Size = new System.Drawing.Size(126, 70);
            this.mnuFolders.Opening += new System.ComponentModel.CancelEventHandler(this.MnuFolders_Opening);
            // 
            // mnuFoldersAdd
            // 
            this.mnuFoldersAdd.Name = "mnuFoldersAdd";
            this.mnuFoldersAdd.Size = new System.Drawing.Size(125, 22);
            this.mnuFoldersAdd.Text = "Add child";
            this.mnuFoldersAdd.Click += new System.EventHandler(this.MnuFoldersAdd_Click);
            // 
            // mnuFoldersRename
            // 
            this.mnuFoldersRename.Name = "mnuFoldersRename";
            this.mnuFoldersRename.Size = new System.Drawing.Size(125, 22);
            this.mnuFoldersRename.Text = "Rename";
            this.mnuFoldersRename.Click += new System.EventHandler(this.MnuFoldersRename_Click);
            // 
            // mnuFoldersDelete
            // 
            this.mnuFoldersDelete.Name = "mnuFoldersDelete";
            this.mnuFoldersDelete.Size = new System.Drawing.Size(125, 22);
            this.mnuFoldersDelete.Text = "Delete";
            this.mnuFoldersDelete.Click += new System.EventHandler(this.MnuFoldersDelete_Click);
            // 
            // splitListDetail
            // 
            this.splitListDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitListDetail.Location = new System.Drawing.Point(0, 0);
            this.splitListDetail.Margin = new System.Windows.Forms.Padding(2);
            this.splitListDetail.Name = "splitListDetail";
            this.splitListDetail.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitListDetail.Panel1
            // 
            this.splitListDetail.Panel1.Controls.Add(this.lstTasks);
            this.splitListDetail.Panel1.Resize += new System.EventHandler(this.SplitListDetail_Panel1_Resize);
            // 
            // splitListDetail.Panel2
            // 
            this.splitListDetail.Panel2.Controls.Add(this.tabTask);
            this.splitListDetail.Panel2.Resize += new System.EventHandler(this.SplitListDetail_Panel2_Resize);
            this.splitListDetail.Size = new System.Drawing.Size(617, 536);
            this.splitListDetail.SplitterDistance = 209;
            this.splitListDetail.SplitterWidth = 10;
            this.splitListDetail.TabIndex = 0;
            // 
            // lstTasks
            // 
            this.lstTasks.ContextMenuStrip = this.mnuTasks;
            this.lstTasks.FullRowSelect = true;
            this.lstTasks.GridLines = true;
            this.lstTasks.HideSelection = false;
            this.lstTasks.Location = new System.Drawing.Point(28, 10);
            this.lstTasks.Margin = new System.Windows.Forms.Padding(2);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(326, 106);
            this.lstTasks.TabIndex = 1;
            this.lstTasks.UseCompatibleStateImageBehavior = false;
            this.lstTasks.View = System.Windows.Forms.View.Details;
            this.lstTasks.SelectedIndexChanged += new System.EventHandler(this.LstTasks_SelectedIndexChanged);
            this.lstTasks.Resize += new System.EventHandler(this.LstTasks_Resize);
            // 
            // mnuTasks
            // 
            this.mnuTasks.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTasksRun,
            this.mnuTasksStop,
            this.mnuTasksSeparator1,
            this.mnuTasksToggleEnabled,
            this.mnuTasksClearLog,
            this.mnuTasksEdit,
            this.mnuTasksDelete,
            this.mnuTasksSeparator2,
            this.mnuTasksAddNew});
            this.mnuTasks.Name = "mnuTasks";
            this.mnuTasks.Size = new System.Drawing.Size(181, 192);
            this.mnuTasks.Opening += new System.ComponentModel.CancelEventHandler(this.MnuTasks_Opening);
            // 
            // mnuTasksRun
            // 
            this.mnuTasksRun.Name = "mnuTasksRun";
            this.mnuTasksRun.Size = new System.Drawing.Size(180, 22);
            this.mnuTasksRun.Text = "Run";
            this.mnuTasksRun.Click += new System.EventHandler(this.MnuTasksRun_Click);
            // 
            // mnuTasksStop
            // 
            this.mnuTasksStop.Name = "mnuTasksStop";
            this.mnuTasksStop.Size = new System.Drawing.Size(180, 22);
            this.mnuTasksStop.Text = "Kill";
            this.mnuTasksStop.Click += new System.EventHandler(this.MnuTasksStop_Click);
            // 
            // mnuTasksSeparator1
            // 
            this.mnuTasksSeparator1.Name = "mnuTasksSeparator1";
            this.mnuTasksSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuTasksToggleEnabled
            // 
            this.mnuTasksToggleEnabled.Name = "mnuTasksToggleEnabled";
            this.mnuTasksToggleEnabled.Size = new System.Drawing.Size(180, 22);
            this.mnuTasksToggleEnabled.Text = "Enable";
            this.mnuTasksToggleEnabled.Click += new System.EventHandler(this.MnuTasksToggleEnabled_Click);
            // 
            // mnuTasksEdit
            // 
            this.mnuTasksEdit.Name = "mnuTasksEdit";
            this.mnuTasksEdit.Size = new System.Drawing.Size(180, 22);
            this.mnuTasksEdit.Text = "Edit";
            this.mnuTasksEdit.Click += new System.EventHandler(this.MnuTasksEdit_Click);
            // 
            // mnuTasksDelete
            // 
            this.mnuTasksDelete.Name = "mnuTasksDelete";
            this.mnuTasksDelete.Size = new System.Drawing.Size(180, 22);
            this.mnuTasksDelete.Text = "Delete";
            this.mnuTasksDelete.Click += new System.EventHandler(this.MnuTasksDelete_Click);
            // 
            // mnuTasksSeparator2
            // 
            this.mnuTasksSeparator2.Name = "mnuTasksSeparator2";
            this.mnuTasksSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuTasksAddNew
            // 
            this.mnuTasksAddNew.Name = "mnuTasksAddNew";
            this.mnuTasksAddNew.Size = new System.Drawing.Size(180, 22);
            this.mnuTasksAddNew.Text = "Add new";
            this.mnuTasksAddNew.Click += new System.EventHandler(this.MnuTasksAddNew_Click);
            // 
            // mnuTasksClearLog
            // 
            this.mnuTasksClearLog.Name = "mnuTasksClearLog";
            this.mnuTasksClearLog.Size = new System.Drawing.Size(180, 22);
            this.mnuTasksClearLog.Text = "Clear log";
            this.mnuTasksClearLog.Click += new System.EventHandler(this.MnuTasksClearLog_Click);
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.tbpDetails);
            this.tabTask.Controls.Add(this.tbpOutput);
            this.tabTask.Location = new System.Drawing.Point(23, 20);
            this.tabTask.Margin = new System.Windows.Forms.Padding(2);
            this.tabTask.Name = "tabTask";
            this.tabTask.SelectedIndex = 0;
            this.tabTask.Size = new System.Drawing.Size(334, 183);
            this.tabTask.TabIndex = 0;
            // 
            // tbpDetails
            // 
            this.tbpDetails.Controls.Add(this.txtDetails);
            this.tbpDetails.Location = new System.Drawing.Point(4, 22);
            this.tbpDetails.Margin = new System.Windows.Forms.Padding(2);
            this.tbpDetails.Name = "tbpDetails";
            this.tbpDetails.Padding = new System.Windows.Forms.Padding(2);
            this.tbpDetails.Size = new System.Drawing.Size(326, 157);
            this.tbpDetails.TabIndex = 0;
            this.tbpDetails.Text = "Description";
            this.tbpDetails.UseVisualStyleBackColor = true;
            // 
            // txtDetails
            // 
            this.txtDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetails.Location = new System.Drawing.Point(2, 2);
            this.txtDetails.Margin = new System.Windows.Forms.Padding(2);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDetails.Size = new System.Drawing.Size(322, 153);
            this.txtDetails.TabIndex = 1;
            // 
            // tbpOutput
            // 
            this.tbpOutput.Controls.Add(this.txtOutput);
            this.tbpOutput.Location = new System.Drawing.Point(4, 22);
            this.tbpOutput.Margin = new System.Windows.Forms.Padding(2);
            this.tbpOutput.Name = "tbpOutput";
            this.tbpOutput.Padding = new System.Windows.Forms.Padding(2);
            this.tbpOutput.Size = new System.Drawing.Size(326, 157);
            this.tbpOutput.TabIndex = 1;
            this.tbpOutput.Text = "Output";
            this.tbpOutput.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(2, 2);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(322, 153);
            this.txtOutput.TabIndex = 0;
            // 
            // FormTasksList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 536);
            this.Controls.Add(this.splitTreeList);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormTasksList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simplified Tasks Scheduler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTasksList_FormClosing);
            this.Load += new System.EventHandler(this.FormTasksList_Load);
            this.splitTreeList.Panel1.ResumeLayout(false);
            this.splitTreeList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTreeList)).EndInit();
            this.splitTreeList.ResumeLayout(false);
            this.mnuFolders.ResumeLayout(false);
            this.splitListDetail.Panel1.ResumeLayout(false);
            this.splitListDetail.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitListDetail)).EndInit();
            this.splitListDetail.ResumeLayout(false);
            this.mnuTasks.ResumeLayout(false);
            this.tabTask.ResumeLayout(false);
            this.tbpDetails.ResumeLayout(false);
            this.tbpDetails.PerformLayout();
            this.tbpOutput.ResumeLayout(false);
            this.tbpOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitTreeList;
        private System.Windows.Forms.TreeView tvwFolders;
        private System.Windows.Forms.ListView lstTasks;
        private System.Windows.Forms.SplitContainer splitListDetail;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TabControl tabTask;
        private System.Windows.Forms.TabPage tbpDetails;
        private System.Windows.Forms.TabPage tbpOutput;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.ContextMenuStrip mnuFolders;
        private System.Windows.Forms.ToolStripMenuItem mnuFoldersAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuFoldersRename;
        private System.Windows.Forms.ToolStripMenuItem mnuFoldersDelete;
        private System.Windows.Forms.ContextMenuStrip mnuTasks;
        private System.Windows.Forms.ToolStripMenuItem mnuTasksRun;
        private System.Windows.Forms.ToolStripMenuItem mnuTasksStop;
        private System.Windows.Forms.ToolStripSeparator mnuTasksSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuTasksToggleEnabled;
        private System.Windows.Forms.ToolStripMenuItem mnuTasksEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuTasksDelete;
        private System.Windows.Forms.ToolStripSeparator mnuTasksSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuTasksAddNew;
        private System.Windows.Forms.ToolStripMenuItem mnuTasksClearLog;
    }
}