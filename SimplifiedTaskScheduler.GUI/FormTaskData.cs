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
    public partial class FormTaskData : Form
    {
        public Base.Data.TaskData TaskData { get; set; }
        public FormTaskData()
        {
            InitializeComponent();
        }

        private void FormTaskData_Load(object sender, EventArgs e)
        {
            this.SetAppIcon();
            chkEnabled.Checked = TaskData.IsEnabled;
            txtName.Text = TaskData.Name;
            txtDescription.Text = TaskData.Description;

            txtCommand.Text = TaskData.ActioningData.Command;
            txtCommandArguments.Text = TaskData.ActioningData.Parameters;
            txtStartIn.Text = TaskData.ActioningData.StartIn;
            chkRunAsOtherUser.Checked = TaskData.ActioningData.RunAsOther;
            txtDomainName.Text = TaskData.ActioningData.Domain;
            txtUserName.Text = TaskData.ActioningData.UserName;
            txtPassword.Text = TaskData.ActioningData.Password;
            grpOtherUser.Enabled = TaskData.ActioningData.RunAsOther;
            nudHours.Value = 1m * TaskData.ActioningData.StopIfIdleHours;
            nudMinutes.Value = 1m * TaskData.ActioningData.StopIfIdleMinutes;
            nudSeconds.Value = 1m * TaskData.ActioningData.StopIfIdleSeconds;

            dtpStartDate.Value = TaskData.SchedulingData.StartDateTime;
            dtpStartTime.Value = TaskData.SchedulingData.StartDateTime;
            dtpExpiryDate.Value = TaskData.SchedulingData.ExpiryDateTime;
            dtpExpiryTime.Value = TaskData.SchedulingData.ExpiryDateTime;
            nudDaysBetween.Value = TaskData.SchedulingData.DaysBetweenRepetitions;
            //nudWeeksBetween.Value = TaskData.SchedulingData.WeeksBetweenRepetitions;
            Base.Data.EWeekDay weekDay = TaskData.SchedulingData.WeeksDays;
            if ((weekDay & Base.Data.EWeekDay.Monday) == Base.Data.EWeekDay.Monday)
            {
                chklWeekDays.SetItemChecked(0, true);
            }
            if ((weekDay & Base.Data.EWeekDay.Tuesday) == Base.Data.EWeekDay.Tuesday)
            {
                chklWeekDays.SetItemChecked(1, true);
            }
            if ((weekDay & Base.Data.EWeekDay.Wednesday) == Base.Data.EWeekDay.Wednesday)
            {
                chklWeekDays.SetItemChecked(2, true);
            }
            if ((weekDay & Base.Data.EWeekDay.Thursday) == Base.Data.EWeekDay.Thursday)
            {
                chklWeekDays.SetItemChecked(3, true);
            }
            if ((weekDay & Base.Data.EWeekDay.Friday) == Base.Data.EWeekDay.Friday)
            {
                chklWeekDays.SetItemChecked(4, true);
            }
            if ((weekDay & Base.Data.EWeekDay.Saturday) == Base.Data.EWeekDay.Saturday)
            {
                chklWeekDays.SetItemChecked(5, true);
            }
            if ((weekDay & Base.Data.EWeekDay.Sunday) == Base.Data.EWeekDay.Sunday)
            {
                chklWeekDays.SetItemChecked(6, true);
            }
            cbostartType.Items.Add("Run once");
            cbostartType.Items.Add("Run once every few days");
            cbostartType.Items.Add("Weekly plan");
            switch (TaskData.SchedulingData.ScheduleType)
            {
                case Base.Data.EScheduleType.RunOnce:
                    cbostartType.SelectedItem = "Run once";
                    break;
                case Base.Data.EScheduleType.OnceEveryFewDays:
                    cbostartType.SelectedItem = "Run once every few days";
                    break;
                case Base.Data.EScheduleType.WeeklyBase:
                    cbostartType.SelectedItem = "Weekly plan";
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void CbostartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = (string)cbostartType.SelectedItem;
            switch (selectedItem)
            {
                case "Run once":
                    lblExpiryDateTime.Visible = false;
                    dtpExpiryDate.Visible = false;
                    dtpExpiryTime.Visible = false;
                    lblDaysBetween.Visible = false;
                    nudDaysBetween.Visible = false;
                    lblweeksBetween.Visible = false;
                    //nudWeeksBetween.Visible = false;
                    lblWeekDays.Visible = false;
                    chklWeekDays.Visible = false;
                    break;
                case "Run once every few days":
                    lblExpiryDateTime.Visible = true;
                    dtpExpiryDate.Visible = true;
                    dtpExpiryTime.Visible = true;
                    lblDaysBetween.Visible = true;
                    nudDaysBetween.Visible = true;
                    lblweeksBetween.Visible = false;
                    //nudWeeksBetween.Visible = false;
                    lblWeekDays.Visible = false;
                    chklWeekDays.Visible = false;
                    break;
                case "Weekly plan":
                    lblExpiryDateTime.Visible = true;
                    dtpExpiryDate.Visible = true;
                    dtpExpiryTime.Visible = true;
                    lblDaysBetween.Visible = false;
                    nudDaysBetween.Visible = false;
                    lblweeksBetween.Visible = false;
                    //nudWeeksBetween.Visible = true;
                    lblWeekDays.Visible = true;
                    chklWeekDays.Visible = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            TaskData.IsEnabled = chkEnabled.Checked;
            TaskData.Name = txtName.Text;
            TaskData.Description = txtDescription.Text;

            TaskData.ActioningData.Command = txtCommand.Text;
            TaskData.ActioningData.Parameters = txtCommandArguments.Text;
            TaskData.ActioningData.StartIn = txtStartIn.Text;
            TaskData.ActioningData.RunAsOther = chkRunAsOtherUser.Checked;
            if (TaskData.ActioningData.RunAsOther)
            {
                TaskData.ActioningData.Domain = txtDomainName.Text;
                TaskData.ActioningData.UserName = txtUserName.Text;
                TaskData.ActioningData.Password = txtPassword.Text;
            }
            else {
                TaskData.ActioningData.Domain = null;
                TaskData.ActioningData.UserName = null;
                TaskData.ActioningData.Password = null;
            }
            TaskData.ActioningData.StopIfIdleHours = (int)nudHours.Value;
            TaskData.ActioningData.StopIfIdleMinutes= (int)nudMinutes.Value;
            TaskData.ActioningData.StopIfIdleSeconds = (int)nudSeconds.Value;

            TaskData.SchedulingData.StartDateTime = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day,
                dtpStartTime.Value.Hour, dtpStartTime.Value.Minute, dtpStartTime.Value.Second, 0);
            TaskData.SchedulingData.ExpiryDateTime = new DateTime(dtpExpiryDate.Value.Year, dtpExpiryDate.Value.Month, dtpExpiryDate.Value.Day,
                dtpExpiryTime.Value.Hour, dtpExpiryTime.Value.Minute, dtpExpiryTime.Value.Second, 0);
            TaskData.SchedulingData.DaysBetweenRepetitions = (int)nudDaysBetween.Value;
            //TaskData.SchedulingData.WeeksBetweenRepetitions = (int)nudWeeksBetween.Value;
            string selectedItem = (string)cbostartType.SelectedItem;
            switch (selectedItem)
            {
                case "Run once":
                    TaskData.SchedulingData.ScheduleType = Base.Data.EScheduleType.RunOnce;
                    break;
                case "Run once every few days":
                    TaskData.SchedulingData.ScheduleType = Base.Data.EScheduleType.OnceEveryFewDays;
                    break;
                case "Weekly plan":
                    TaskData.SchedulingData.ScheduleType = Base.Data.EScheduleType.WeeklyBase;
                    break;
                default:
                    throw new NotImplementedException();
            }

            Base.Data.EWeekDay weekDay = Base.Data.EWeekDay.None;
            if (chklWeekDays.GetItemChecked(0)) weekDay = weekDay | Base.Data.EWeekDay.Monday;
            if (chklWeekDays.GetItemChecked(1)) weekDay = weekDay | Base.Data.EWeekDay.Tuesday;
            if (chklWeekDays.GetItemChecked(2)) weekDay = weekDay | Base.Data.EWeekDay.Wednesday;
            if (chklWeekDays.GetItemChecked(3)) weekDay = weekDay | Base.Data.EWeekDay.Thursday;
            if (chklWeekDays.GetItemChecked(4)) weekDay = weekDay | Base.Data.EWeekDay.Friday;
            if (chklWeekDays.GetItemChecked(5)) weekDay = weekDay | Base.Data.EWeekDay.Saturday;
            if (chklWeekDays.GetItemChecked(6)) weekDay = weekDay | Base.Data.EWeekDay.Sunday;
            TaskData.SchedulingData.WeeksDays = weekDay;
        }

        private void ChkRunAsOtherUser_CheckedChanged(object sender, EventArgs e)
        {
            grpOtherUser.Enabled = chkRunAsOtherUser.Checked;
        }
    }
}
