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
