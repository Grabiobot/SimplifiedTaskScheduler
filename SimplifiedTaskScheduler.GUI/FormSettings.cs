using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplifiedTaskScheduler.GUI
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            this.SetAppIcon();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            string product = fvi.ProductName;
            this.Text ="Settings - "+ product + " v." + version;
            chkStartWithWindows.Checked = SettingsManager.CurrentSettings.StartWithWindows;
            chkShowProgressNotifications.Checked = SettingsManager.CurrentSettings.ShowProgressNotifications;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            SettingsManager.CurrentSettings.StartWithWindows = chkStartWithWindows.Checked;
            SettingsManager.CurrentSettings.ShowProgressNotifications = chkShowProgressNotifications.Checked;
            SettingsManager.ApplyStartWithWindows(SettingsManager.CurrentSettings.StartWithWindows);
        }
    }
}
