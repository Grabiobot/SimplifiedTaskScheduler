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
    public partial class FormNotification : Form
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public Base.Events.ENotificationType NotificationType { get; set; }
        public FormNotification()
        {
            InitializeComponent();
        }

        private void FormNotification_Shown(object sender, EventArgs e)
        {
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
                    this.BackColor = Color.MediumSeaGreen; // Also good: DarkOliveGreen
                    break;
                case Base.Events.ENotificationType.TaskError:
                    this.BackColor = Color.LightCoral; // Also good:  MediumVioletRed or PaleVioletRed
                    break;
                case Base.Events.ENotificationType.TaskKilled:
                    this.BackColor = Color.LightSteelBlue;
                    break;
                case Base.Events.ENotificationType.TaskIdleKilled:
                    this.BackColor = Color.MediumSeaGreen;
                    break;
                case Base.Events.ENotificationType.TaskOutput:
                    this.BackColor = Color.LightSteelBlue;
                    break;
                case Base.Events.ENotificationType.TaskExit:
                    this.BackColor = Color.MediumSeaGreen; 
                    break;
                case Base.Events.ENotificationType.TaskCrash:
                    this.BackColor = Color.LightCoral;
                    break;
                default:
                    throw new NotFiniteNumberException();
            }
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
