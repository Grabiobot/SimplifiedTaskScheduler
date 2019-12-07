using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplifiedTaskScheduler.GUI
{
    public partial class FormNotification : Form
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public Base.Events.ENotificationType NotificationType { get; set; }

        public FormNotification()
        {
            InitializeComponent();
        }

        public void StopTimer()
        {
            timer1.Stop();
        }

        public void UpdateContent() {
            timer1.Stop();
            timer1.Interval = 5000;
            timer1.Enabled = true;
            lblText.Text = Message;
            lblTitle.Text = Title;
            lblText.Font = new System.Drawing.Font(lblText.Font.Name, lblText.Font.Size * 1.0f, FontStyle.Regular);
            lblTitle.Font = new System.Drawing.Font(lblText.Font.Name, lblText.Font.Size * 1.5f, FontStyle.Bold);
            switch (NotificationType)
            {
                case Base.Events.ENotificationType.TaskStart:
                    BackColor = Color.MediumSeaGreen;
                    break;
                case Base.Events.ENotificationType.TaskError:
                    BackColor = Color.LightCoral;
                    break;
                case Base.Events.ENotificationType.TaskKilled:
                    BackColor = Color.LightSteelBlue;
                    break;
                case Base.Events.ENotificationType.TaskIdleKilled:
                    BackColor = Color.MediumSeaGreen;
                    break;
                case Base.Events.ENotificationType.TaskOutput:
                    BackColor = Color.LightSteelBlue;
                    break;
                case Base.Events.ENotificationType.TaskExit:
                    BackColor = Color.MediumSeaGreen;
                    break;
                case Base.Events.ENotificationType.TaskCrash:
                    BackColor = Color.LightCoral;
                    break;
                default:
                    throw new NotFiniteNumberException();
            }
        }

        private void FormNotification_Shown(object sender, EventArgs e)
        {
            UpdateContent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void FormNotification_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
