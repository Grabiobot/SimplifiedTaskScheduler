﻿using System;
using System.Windows.Forms;

namespace SimplifiedTaskScheduler.GUI
{
    public partial class FormMain : Form
    {
        private bool _canOpenNewCloseMessage = true;
        private bool _canOpenNewListForm = true;
        private bool _canOpenNewsettingsForm = true;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.SetAppIcon();
            timerEnabled.Enabled = true;
            timerTick.Enabled = false;
            mnuIconManageTasks.Font = new System.Drawing.Font(mnuIconManageTasks.Font, System.Drawing.FontStyle.Bold);

            Controller.Instance.LoadData("");
            Scheduler.TasksScheduler.Instance.ReBuildQueue(Base.Accessor.Instance.Tasks);

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            string product = fvi.ProductName;
            notifyIcon1.Text = product+ " v." + version;
            NotificationManager.Instance.ShowNotification("Application started...", "", product + " v." + version, Base.Events.ENotificationType.TaskStart);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        private void MnuIconExit_Click(object sender, EventArgs e)
        {
            if (!_canOpenNewCloseMessage) return;
            _canOpenNewCloseMessage = false;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            string product = fvi.ProductName;
            string title = product + " v." + version;
            _canOpenNewListForm = false;

            DialogResult dr = MessageBox.Show(@"Are you sure that you want to quit?

The application can execute scheduled tasks only while running!
Quitting it will prevent scheduled tasks to be executed until you start it again.
", title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            _canOpenNewListForm = true;
            _canOpenNewCloseMessage = true;
            if (dr != DialogResult.Yes) return;
            Controller.Instance.SaveData("");
            Application.Exit();
        }

        private void MnuIconManageTasks_Click(object sender, EventArgs e)
        {
            if (!_canOpenNewListForm) return;
            Form frm = new FormTasksList();
            frm.FormClosed += Frm_FormClosed;
            _canOpenNewListForm = false;
            frm.ShowDialog(this);
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _canOpenNewListForm = true;
            ((Form)sender).FormClosed -= Frm_FormClosed;
        }

        private void TimerTick_Tick(object sender, EventArgs e)
        {
            Scheduler.TasksScheduler.Instance.Cleanup(Base.Accessor.Instance.Tasks);
            Controller.Instance.SaveData(""); //Save after closing idle tasks
            Scheduler.TasksScheduler.Instance.ReBuildQueue(Base.Accessor.Instance.Tasks);
            Scheduler.TasksScheduler.Instance.RunNext();
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            MnuIconManageTasks_Click(sender, e);
        }

        private void Frm_FormSettingsClosed(object sender, FormClosedEventArgs e)
        {
            _canOpenNewsettingsForm = true;
            ((Form)sender).FormClosed -= Frm_FormSettingsClosed;
        }

        private void MnuIconSettings_Click(object sender, EventArgs e)
        {
            if (!_canOpenNewsettingsForm) return;
            Form frm = new FormSettings();
            frm.FormClosed += Frm_FormSettingsClosed;
            _canOpenNewsettingsForm = false;
            frm.ShowDialog(this);
        }

        private int _delauyedTicks = 0;

        private void TimerEnabled_Tick(object sender, EventArgs e)
        {
            _delauyedTicks++;
            if (_delauyedTicks >= SettingsManager.CurrentSettings.DelayedStartOfTasks) {
                timerEnabled.Enabled = false;
                timerTick.Enabled = true;
                _delauyedTicks = SettingsManager.CurrentSettings.DelayedStartOfTasks;
            }
        }
    }
}
