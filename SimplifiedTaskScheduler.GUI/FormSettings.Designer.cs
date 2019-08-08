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
            this.SuspendLayout();
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(10, 11);
            this.chkStartWithWindows.Margin = new System.Windows.Forms.Padding(2);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(117, 17);
            this.chkStartWithWindows.TabIndex = 0;
            this.chkStartWithWindows.Text = "Start with Windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarning.Location = new System.Drawing.Point(10, 33);
            this.lblWarning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(392, 51);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "This application can execute scheduled tasks only when it is running.\r\n\r\nNo sched" +
    "uled task will be executed while this application is not started!";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(285, 137);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 19);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(346, 137);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkShowProgressNotifications
            // 
            this.chkShowProgressNotifications.AutoSize = true;
            this.chkShowProgressNotifications.Location = new System.Drawing.Point(10, 86);
            this.chkShowProgressNotifications.Margin = new System.Windows.Forms.Padding(2);
            this.chkShowProgressNotifications.Name = "chkShowProgressNotifications";
            this.chkShowProgressNotifications.Size = new System.Drawing.Size(249, 17);
            this.chkShowProgressNotifications.TabIndex = 17;
            this.chkShowProgressNotifications.Text = "Show notification for normal progress messages";
            this.chkShowProgressNotifications.UseVisualStyleBackColor = true;
            // 
            // cboShowNotificationsOnTop
            // 
            this.chkKeepNotificationsOnTop.AutoSize = true;
            this.chkKeepNotificationsOnTop.Location = new System.Drawing.Point(10, 110);
            this.chkKeepNotificationsOnTop.Margin = new System.Windows.Forms.Padding(2);
            this.chkKeepNotificationsOnTop.Name = "cboShowNotificationsOnTop";
            this.chkKeepNotificationsOnTop.Size = new System.Drawing.Size(212, 17);
            this.chkKeepNotificationsOnTop.TabIndex = 18;
            this.chkKeepNotificationsOnTop.Text = "Keep notification window always on top";
            this.chkKeepNotificationsOnTop.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(411, 166);
            this.Controls.Add(this.chkKeepNotificationsOnTop);
            this.Controls.Add(this.chkShowProgressNotifications);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.chkStartWithWindows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
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
    }
}