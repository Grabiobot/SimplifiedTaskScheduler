using System;
using System.Windows.Forms;

namespace SimplifiedTaskScheduler.GUI
{
    public partial class FormTaskFolder : Form
    {
        public string FolderName { get; set; }

        public FormTaskFolder()
        {
            InitializeComponent();
        }

        private void FormTaskFolder_Load(object sender, EventArgs e)
        {
            this.SetAppIcon();
            txtFolderName.Text = FolderName;
            txtFolderName.SelectionStart = 0;
            txtFolderName.SelectionLength = FolderName.Length;
            txtFolderName.Focus();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            FolderName = txtFolderName.Text;
        }
    }
}
