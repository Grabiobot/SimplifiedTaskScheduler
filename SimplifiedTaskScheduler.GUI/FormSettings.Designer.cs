namespace SimplifiedTaskScheduler.GUI
{
    partial class FormSettings
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
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkShowProgressNotifications = new System.Windows.Forms.CheckBox();
            this.chkKeepNotificationsOnTop = new System.Windows.Forms.CheckBox();
            this.lblDelayedStartOfTasks = new System.Windows.Forms.Label();
            this.nudDelayedStartOfTasks = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelayedStartOfTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(13, 14);
            this.chkStartWithWindows.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(148, 21);
            this.chkStartWithWindows.TabIndex = 0;
            this.chkStartWithWindows.Text = "Start with Windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarning.Location = new System.Drawing.Point(13, 41);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(523, 63);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "This application can execute scheduled tasks only when it is running.\r\n\r\nNo sched" +
    "uled task will be executed while this application is not started!";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(380, 207);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(461, 207);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkShowProgressNotifications
            // 
            this.chkShowProgressNotifications.AutoSize = true;
            this.chkShowProgressNotifications.Location = new System.Drawing.Point(13, 106);
            this.chkShowProgressNotifications.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkShowProgressNotifications.Name = "chkShowProgressNotifications";
            this.chkShowProgressNotifications.Size = new System.Drawing.Size(332, 21);
            this.chkShowProgressNotifications.TabIndex = 17;
            this.chkShowProgressNotifications.Text = "Show notification for normal progress messages";
            this.chkShowProgressNotifications.UseVisualStyleBackColor = true;
            // 
            // chkKeepNotificationsOnTop
            // 
            this.chkKeepNotificationsOnTop.AutoSize = true;
            this.chkKeepNotificationsOnTop.Location = new System.Drawing.Point(13, 135);
            this.chkKeepNotificationsOnTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkKeepNotificationsOnTop.Name = "chkKeepNotificationsOnTop";
            this.chkKeepNotificationsOnTop.Size = new System.Drawing.Size(274, 21);
            this.chkKeepNotificationsOnTop.TabIndex = 18;
            this.chkKeepNotificationsOnTop.Text = "Keep notification window always on top";
            this.chkKeepNotificationsOnTop.UseVisualStyleBackColor = true;
            // 
            // lblDelayedStartOfTasks
            // 
            this.lblDelayedStartOfTasks.AutoSize = true;
            this.lblDelayedStartOfTasks.Location = new System.Drawing.Point(10, 167);
            this.lblDelayedStartOfTasks.Name = "lblDelayedStartOfTasks";
            this.lblDelayedStartOfTasks.Size = new System.Drawing.Size(180, 17);
            this.lblDelayedStartOfTasks.TabIndex = 19;
            this.lblDelayedStartOfTasks.Text = "Delay tasks start (seconds)";
            // 
            // nudDelayedStartOfTasks
            // 
            this.nudDelayedStartOfTasks.Location = new System.Drawing.Point(196, 165);
            this.nudDelayedStartOfTasks.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.nudDelayedStartOfTasks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDelayedStartOfTasks.Name = "nudDelayedStartOfTasks";
            this.nudDelayedStartOfTasks.Size = new System.Drawing.Size(120, 22);
            this.nudDelayedStartOfTasks.TabIndex = 20;
            this.nudDelayedStartOfTasks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(548, 242);
            this.Controls.Add(this.nudDelayedStartOfTasks);
            this.Controls.Add(this.lblDelayedStartOfTasks);
            this.Controls.Add(this.chkKeepNotificationsOnTop);
            this.Controls.Add(this.chkShowProgressNotifications);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.chkStartWithWindows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDelayedStartOfTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkShowProgressNotifications;
        private System.Windows.Forms.CheckBox chkKeepNotificationsOnTop;
        private System.Windows.Forms.Label lblDelayedStartOfTasks;
        private System.Windows.Forms.NumericUpDown nudDelayedStartOfTasks;
    }
}