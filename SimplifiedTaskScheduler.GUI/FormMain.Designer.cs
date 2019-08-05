namespace SimplifiedTaskScheduler.GUI
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuIconManageTasks = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIconExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.mnuIconSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIconSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.mnuIcon;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
            // 
            // mnuIcon
            // 
            this.mnuIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIconManageTasks,
            this.mnuIconSettings,
            this.mnuIconSeparator1,
            this.mnuIconExit});
            this.mnuIcon.Name = "mnuIcon";
            this.mnuIcon.Size = new System.Drawing.Size(211, 110);
            // 
            // mnuIconManageTasks
            // 
            this.mnuIconManageTasks.Name = "mnuIconManageTasks";
            this.mnuIconManageTasks.Size = new System.Drawing.Size(210, 24);
            this.mnuIconManageTasks.Text = "Manage tasks";
            this.mnuIconManageTasks.Click += new System.EventHandler(this.MnuIconManageTasks_Click);
            // 
            // mnuIconExit
            // 
            this.mnuIconExit.Name = "mnuIconExit";
            this.mnuIconExit.Size = new System.Drawing.Size(210, 24);
            this.mnuIconExit.Text = "Exit";
            this.mnuIconExit.Click += new System.EventHandler(this.MnuIconExit_Click);
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 10000;
            this.timerTick.Tick += new System.EventHandler(this.TimerTick_Tick);
            // 
            // mnuIconSettings
            // 
            this.mnuIconSettings.Name = "mnuIconSettings";
            this.mnuIconSettings.Size = new System.Drawing.Size(210, 24);
            this.mnuIconSettings.Text = "Settings";
            this.mnuIconSettings.Click += new System.EventHandler(this.MnuIconSettings_Click);
            // 
            // mnuIconSeparator1
            // 
            this.mnuIconSeparator1.Name = "mnuIconSeparator1";
            this.mnuIconSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.mnuIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip mnuIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuIconManageTasks;
        private System.Windows.Forms.ToolStripMenuItem mnuIconExit;
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.ToolStripMenuItem mnuIconSettings;
        private System.Windows.Forms.ToolStripSeparator mnuIconSeparator1;
    }
}