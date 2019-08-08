using SimplifiedTaskScheduler.Base;
using SimplifiedTaskScheduler.Base.Data;
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
    public partial class FormTasksList : Form
    {
        private TaskData _taskData=null;
        private TaskFolder _taskFolder=null;
        private delegate void UpdateTaskInfoCallback(string taskId);
        private delegate void ExitedCallback(int exitCode, string text, string taskId);
        private delegate void AppendTextCallback(string text, string taskId);
        private bool _listViewChangedProgramatically = false;
         public FormTasksList()
        {
            InitializeComponent();
        }

        #region PURE GUI
        private void SplitTreeList_Panel1_Resize(object sender, EventArgs e)
        {
            tvwFolders.Left = 0;
            tvwFolders.Top = 0;
            tvwFolders.Width = splitTreeList.Panel1.ClientRectangle.Width - tvwFolders.Left * 2;
            tvwFolders.Height = splitTreeList.Panel1.ClientRectangle.Height - tvwFolders.Top * 2;
        }
        private void SplitTreeList_Panel2_Resize(object sender, EventArgs e)
        {
        }
        private void FormTasksList_Load(object sender, EventArgs e)
        {
            this.SetAppIcon();
            tvwFolders.MouseDown += TvwFolders_MouseDown;
            //Add column header
            lstTasks.Columns.Add("Name", 150);
            lstTasks.Columns.Add("Next Run Time", 150);
            lstTasks.Columns.Add("Command", 150);
            lstTasks.Columns.Add("Status", 150);
            lstTasks.Columns.Add("Enabled", 150);
            lstTasks.Columns.Add("Last Run Time", 150);

            SplitTreeList_Panel1_Resize(this, EventArgs.Empty);
            SplitTreeList_Panel2_Resize(this, EventArgs.Empty);
            SplitListDetail_Panel1_Resize(this, EventArgs.Empty);
            SplitListDetail_Panel2_Resize(this, EventArgs.Empty);

            // Now we may browse for the source file and ask controller to load tasks list from it
            CreateUIFolders();

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            this.Text += " v." + version;
        }
        private void SplitListDetail_Panel1_Resize(object sender, EventArgs e)
        {
            lstTasks.Left = 0;
            lstTasks.Top = 0;
            lstTasks.Width = splitListDetail.Panel1.ClientRectangle.Width - lstTasks.Left * 2;
            lstTasks.Height = splitListDetail.Panel1.ClientRectangle.Height - lstTasks.Top * 2;

        }
        private void SplitListDetail_Panel2_Resize(object sender, EventArgs e)
        {
            tabTask.Left = 0;
            tabTask.Top = 0;
            tabTask.Width = splitListDetail.Panel2.ClientRectangle.Width - tabTask.Left * 2;
            tabTask.Height = splitListDetail.Panel2.ClientRectangle.Height - tabTask.Top * 2;
        }
        private void AutoSizeColumnList(ListView listView)
        {
            //Prevents flickering
            listView.BeginUpdate();

            Dictionary<int, int> columnSize = new Dictionary<int, int>();

            //Auto size using header
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //Grab column size based on header
            foreach (ColumnHeader colHeader in listView.Columns)
                columnSize.Add(colHeader.Index, colHeader.Width);

            //Auto size using data
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            //Grab comumn size based on data and set max width
            foreach (ColumnHeader colHeader in listView.Columns)
            {
                int nColWidth;
                if (columnSize.TryGetValue(colHeader.Index, out nColWidth))
                    colHeader.Width = Math.Max(nColWidth, colHeader.Width);
                else
                    //Default to 50
                    colHeader.Width = Math.Max(50, colHeader.Width);
            }

            listView.EndUpdate();
        }
        private void MnuTasks_Opening(object sender, CancelEventArgs e)
        {
            mnuTasksDelete.Enabled = _taskData != null;
            mnuTasksEdit.Enabled = _taskData != null;
            mnuTasksToggleEnabled.Enabled = _taskData != null;
            mnuTasksClearLog.Enabled = _taskData != null;
            if (mnuTasksToggleEnabled.Enabled) mnuTasksToggleEnabled.Checked = _taskData.IsEnabled;
            else mnuTasksToggleEnabled.Checked = false;
            mnuTasksRun.Enabled = _taskData != null;
            mnuTasksStop.Enabled = _taskData != null;
            mnuTasksAddNew.Enabled = _taskFolder != null;
        }
        private void MnuFolders_Opening(object sender, CancelEventArgs e)
        {
            mnuFoldersDelete.Enabled = _taskFolder != null;
            mnuFoldersRename.Enabled = _taskFolder != null;
            mnuFoldersAdd.Enabled = _taskFolder != null;
        }
        private void LstTasks_Resize(object sender, EventArgs e)
        {
            AutoSizeColumnList(lstTasks);
        }
        private void TaskData_Exited(object sender, Base.Events.TaskExitedEventArgs e)
        {
            OnExited(e.ExitCode, e.Data, e.TaskId);
        }
        private void TaskData_OutputDataReceived(object sender, Base.Events.TaskDataReceivedEventArgs e)
        {
            AppendText(e.Data, e.TaskId);
        }
        private void TvwFolders_MouseDown(object sender, MouseEventArgs e)
        {
            var node = tvwFolders.GetNodeAt(e.X, e.Y);
            OnTaskFolderNoteSelected(node);
        }
        private void LstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnTaskItemSelected();
        }
        #endregion

        private void AppendText(string text, string taskId)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtOutput.InvokeRequired)
            {
                //if (GetWantsToStop()) return;
                AppendTextCallback d = new AppendTextCallback(AppendText);
                this?.Invoke(d, new object[] { text, taskId });
            }
            else
            {
                if (_taskData == null) return;
                if (_taskData.Id != taskId) return;
                txtOutput.AppendText(text);
            }
        }
        private void OnExited(int exitCode, string text, string taskId)
        {
            if (this.lstTasks.InvokeRequired)
            {
                ExitedCallback d = new ExitedCallback(OnExited);
                this.Invoke(d, new object[] { exitCode, text, taskId });
            }
            else
            {
                if (_taskData == null) return;
                if (_taskData.Id != taskId) return;
                txtOutput.AppendText(text);
            }
        }
        private void UpdateTaskDisplay(string taskId)
        {
            if (this.lstTasks.InvokeRequired)
            {
                UpdateTaskInfoCallback d = new UpdateTaskInfoCallback(UpdateTaskDisplay);
                this.Invoke(d, new object[] { taskId });
            }
            else
            {
                if (_taskData == null) return;
                if (_taskData.Id != taskId) return;
                lstTasks.SelectedItems[0].Text = _taskData.Name;
                lstTasks.SelectedItems[0].Tag = _taskData.Id;
                lstTasks.SelectedItems[0].SubItems[1].Text = GetNextOccurenceText(_taskData);
                lstTasks.SelectedItems[0].SubItems[2].Text = _taskData.ActioningData.Command;
                lstTasks.SelectedItems[0].SubItems[3].Text = _taskData.DebugData.TaskStatus.ToString();
                lstTasks.SelectedItems[0].SubItems[4].Text = _taskData.IsEnabled.ToString();
                lstTasks.SelectedItems[0].SubItems[5].Text = GetLastRunText(_taskData);
                AutoSizeColumnList(lstTasks);
                ShowDetailsForTask();
            }
        }
        private void OnTaskFolderNoteSelected(TreeNode node)
        {
            tvwFolders.SelectedNode = node;
            if (tvwFolders.SelectedNode == null)
            {
                _taskFolder = null;
                _listViewChangedProgramatically = true;
                lstTasks.Items.Clear();
                _listViewChangedProgramatically = false;
                OnTaskItemSelected();
                return;
            }
            string id = tvwFolders.SelectedNode.Name;
            if (id != _taskFolder?.Id)
            {
                TaskFolder folder = FindClickedFolder(id);
                _taskFolder = folder;
                _listViewChangedProgramatically = true;
                lstTasks.Items.Clear();
                for (int i = 0; i < folder.Tasks.Count; i++)
                {
                    var x = lstTasks.Items.Add(folder.Tasks[i].Name);
                    x.Tag = folder.Tasks[i].Id;
                    x.SubItems.Add(GetNextOccurenceText(folder.Tasks[i]));
                    x.SubItems.Add(folder.Tasks[i].ActioningData.Command);
                    x.SubItems.Add(folder.Tasks[i].DebugData.TaskStatus.ToString());
                    x.SubItems.Add(folder.Tasks[i].IsEnabled.ToString());
                    x.SubItems.Add(GetLastRunText(folder.Tasks[i]));
                }
                AutoSizeColumnList(lstTasks);
                _listViewChangedProgramatically = false;
                OnTaskItemSelected();
            }
        }
        private string GetNextOccurenceText(TaskData taskData) {
            return taskData.NextOccurence?.ToShortDateString() + " " + taskData.NextOccurence?.ToShortTimeString();
        }
        private string GetLastRunText(TaskData taskData)
        {
            return taskData.DebugData.DateStarted?.ToShortDateString() + " " + taskData.DebugData.DateStarted?.ToShortTimeString();
        }
        private void CreateUIFolders()
        {
            CreateUIFolders(Accessor.Instance.Tasks, null);
            tvwFolders.ExpandAll();
        }
        private void CreateUIFolders(TaskFolder folder, TreeNode parent)
        {
            TreeNode child;
            if (parent == null)
                child = tvwFolders.Nodes.Add(folder.Id, folder.Name);
            else
                child = parent.Nodes.Add(folder.Id, folder.Name);
            for (int i = 0; i < folder.SubFolders.Count; i++)
            {
                CreateUIFolders(folder.SubFolders[i], child);
            }
        }
        private TaskFolder FindClickedFolder(string id) {
            return Controller.Instance.GetFolderById(id);
        }
        private TaskData FindClickedTask(string id)
        {
            return Controller.Instance.GetTaskBeId(id);
        }

        private void RunTaskNow(TaskData taskData)
        {
            taskData.DebugData.Runner.Run();
            UpdateTaskDisplay(taskData.Id);
            //UpdateDisplayedTaskStatus();
            tabTask.SelectedTab = tbpOutput;
        }
        private void KillTaskNow(TaskData taskData)
        {
            taskData.DebugData.Runner.Kill();
            //UpdateDisplayedTaskStatus();
        }
        private void OnTaskItemSelected()
        {

            if (_listViewChangedProgramatically)
            {
                _taskData.DebugData.Runner.OutputDataReceived -= TaskData_OutputDataReceived;
                _taskData.DebugData.Runner.ErrorDataReceived -= TaskData_OutputDataReceived;
                _taskData.DebugData.Runner.Exited -= TaskData_Exited;
                _taskData.DebugData.Runner.StatusChanged -= Runner_StatusChanged;
                _taskData.DebugData.Runner.TaskNotification -= Runner_TaskNotification; ;
                _taskData.DebugData.Runner.ManagementDataReceived -= Runner_ManagementDataReceived;
                _taskData = null;
                ShowDetailsForNoTask();
                return;
            }
            if (lstTasks.SelectedIndices == null || lstTasks.SelectedIndices.Count == 0)
            {
                if (_taskData != null)
                {
                    _taskData.DebugData.Runner.OutputDataReceived -= TaskData_OutputDataReceived;
                    _taskData.DebugData.Runner.ErrorDataReceived -= TaskData_OutputDataReceived;
                    _taskData.DebugData.Runner.Exited -= TaskData_Exited;
                    _taskData.DebugData.Runner.StatusChanged -= Runner_StatusChanged;
                    _taskData.DebugData.Runner.TaskNotification -= Runner_TaskNotification; ;
                    _taskData.DebugData.Runner.ManagementDataReceived -= Runner_ManagementDataReceived;
                    _taskData = null;
                    ShowDetailsForNoTask();
                }
                return;
            }
            string id = (string)(lstTasks.SelectedItems[0].Tag);
            if (_taskData != null && _taskData.Id != id)
            {
                _taskData.DebugData.Runner.OutputDataReceived -= TaskData_OutputDataReceived;
                _taskData.DebugData.Runner.ErrorDataReceived -= TaskData_OutputDataReceived;
                _taskData.DebugData.Runner.Exited -= TaskData_Exited;
                _taskData.DebugData.Runner.StatusChanged -= Runner_StatusChanged;
                _taskData.DebugData.Runner.TaskNotification -= Runner_TaskNotification; ;
                _taskData.DebugData.Runner.ManagementDataReceived -= Runner_ManagementDataReceived;
                _taskData = null;
                ShowDetailsForNoTask();
            }
            TaskData taskData = FindClickedTask(id);
            _taskData = taskData;
            ShowDetailsForTask();
            _taskData.DebugData.Runner.OutputDataReceived += TaskData_OutputDataReceived;
            _taskData.DebugData.Runner.ErrorDataReceived += TaskData_OutputDataReceived;
            _taskData.DebugData.Runner.Exited += TaskData_Exited;
            _taskData.DebugData.Runner.StatusChanged += Runner_StatusChanged;
            _taskData.DebugData.Runner.TaskNotification += Runner_TaskNotification; ;
            _taskData.DebugData.Runner.ManagementDataReceived += Runner_ManagementDataReceived;
        }

        private void Runner_ManagementDataReceived(object sender, Base.Events.TaskDataReceivedEventArgs e)
        {
            AppendText(e.Data, e.TaskId);
        }

        private void Runner_TaskNotification(object sender, Base.Events.TaskNotificationEventArgs e)
        {
        }

        private void Runner_StatusChanged(object sender, Base.Events.TaskStatusChangedEventArgs e)
        {
            UpdateTaskDisplay(e.TaskId);
        }
        private void ShowDetailsForNoTask() {
            txtOutput.Text = "";
            txtDetails.Text = "";
        }
        private void ShowDetailsForTask()
        {
            txtOutput.Text = _taskData.DebugData.Output;
            txtDetails.Text = _taskData.Description;
        }
        private void MnuTasksRun_Click(object sender, EventArgs e)
        {
            string id = (string)(lstTasks.SelectedItems[0].Tag);
            TaskData taskData = FindClickedTask(id);
            if (taskData.DebugData.Runner.IsRunning())
            {
                MessageBox.Show("Selected task is already running!","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RunTaskNow(taskData);
            }
        }
        private void MnuTasksStop_Click(object sender, EventArgs e)
        {
            string id = (string)(lstTasks.SelectedItems[0].Tag);
            TaskData taskData = FindClickedTask(id);
            if (taskData.DebugData.Runner.IsRunning())
            {
                KillTaskNow(taskData);
            }
            else
            {
                //MessageBox.Show("Selected task is not currently running! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                KillTaskNow(taskData);
            }
        }
        private void MnuTasksToggleEnabled_Click(object sender, EventArgs e)
        {
            string id = (string)(lstTasks.SelectedItems[0].Tag);
            TaskData taskData = FindClickedTask(id);
            taskData.IsEnabled = !taskData.IsEnabled;
            UpdateTaskDisplay(id);
        }
        private void MnuTasksDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this task?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;
            string taskId = (string)(lstTasks.SelectedItems[0].Tag);
            string folderId = (string)(tvwFolders.SelectedNode.Name);
            Controller.Instance.DeleteTask(taskId, folderId);
            lstTasks.Items.Remove(lstTasks.SelectedItems[0]);
            //OnTaskFolderNoteSelected
        }
        private void MnuFoldersDelete_Click(object sender, EventArgs e)
        {
            var node = tvwFolders.SelectedNode;
            var parentNode = tvwFolders.SelectedNode.Parent;
            if (parentNode == null)
            {
                MessageBox.Show("You can't delete the root folder!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this folder and all contained tasks?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;
            string folderId = (string)(node.Name);
            string parentFolderId = parentNode.Name;
            Controller.Instance.DeleteFolder(folderId, parentFolderId);
            parentNode.Nodes.Remove(node);
            tvwFolders.SelectedNode = parentNode;
            OnTaskFolderNoteSelected(tvwFolders.SelectedNode);
        }

        private void MnuFoldersRename_Click(object sender, EventArgs e)
        {
            FormTaskFolder frm = new FormTaskFolder();
            string folderId = (string)(tvwFolders.SelectedNode.Name);
            frm.FolderName = _taskFolder.Name;
            DialogResult dr = frm.ShowDialog(this);
            if (dr != DialogResult.OK) return;
            _taskFolder.Name = frm.FolderName;
            tvwFolders.SelectedNode.Text = _taskFolder.Name;
        }

        private void MnuFoldersAdd_Click(object sender, EventArgs e)
        {
            var parentNode = tvwFolders.SelectedNode;
            if (parentNode == null) return;
            FormTaskFolder frm = new FormTaskFolder();
            frm.FolderName = "";
            DialogResult dr = frm.ShowDialog(this);
            if (dr != DialogResult.OK) return;
            string folderName = frm.FolderName;
            TaskFolder taskFolder = Controller.Instance.AddChildFolder(_taskFolder.Id);
            taskFolder.Name = folderName;
            CreateUIFolders(taskFolder, parentNode);
            parentNode.ExpandAll();
        }

        private void MnuTasksEdit_Click(object sender, EventArgs e)
        {
            FormTaskData frm = new FormTaskData();
            frm.TaskData = _taskData;
            DialogResult dr = frm.ShowDialog(this);
            if (dr != DialogResult.OK) return;
            UpdateTaskDisplay(_taskData.Id);
            //_taskFolder.Name = frm.FolderName;
            //tvwFolders.SelectedNode.Text = _taskFolder.Name;
        }

        private void MnuTasksAddNew_Click(object sender, EventArgs e)
        {
            FormTaskData frm = new FormTaskData();
            frm.TaskData = Controller.Instance.CreateNewTask();
            DialogResult dr = frm.ShowDialog(this);
            if (dr != DialogResult.OK) return;
            //_taskFolder.Tasks.Add(frm.TaskData);
            Controller.Instance.AddChildTask(_taskFolder.Id, frm.TaskData);


            TaskFolder folder = _taskFolder;
            string id = _taskFolder.Id;
            _listViewChangedProgramatically = true;
            lstTasks.Items.Clear();
            for (int i = 0; i < folder.Tasks.Count; i++)
            {
                var x = lstTasks.Items.Add(folder.Tasks[i].Name);
                x.Tag = folder.Tasks[i].Id;
                x.SubItems.Add(GetNextOccurenceText(folder.Tasks[i]));
                x.SubItems.Add(folder.Tasks[i].ActioningData.Command);
                x.SubItems.Add(folder.Tasks[i].DebugData.TaskStatus.ToString());
                x.SubItems.Add(folder.Tasks[i].IsEnabled.ToString());
                x.SubItems.Add(GetLastRunText(folder.Tasks[i]));
            }
            AutoSizeColumnList(lstTasks);
            _listViewChangedProgramatically = false;
            OnTaskItemSelected();
        }

        private void FormTasksList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_taskData != null)
            {
                //SetWantsToStop();
                _taskData.DebugData.Runner.OutputDataReceived -= TaskData_OutputDataReceived;
                _taskData.DebugData.Runner.ErrorDataReceived -= TaskData_OutputDataReceived;
                _taskData.DebugData.Runner.Exited -= TaskData_Exited;
                _taskData.DebugData.Runner.StatusChanged -= Runner_StatusChanged;
                _taskData.DebugData.Runner.TaskNotification -= Runner_TaskNotification; ;
                _taskData.DebugData.Runner.ManagementDataReceived -= Runner_ManagementDataReceived;
                _taskData = null;
            }
            Controller.Instance.SaveData("");
        }

        private void MnuTasksClearLog_Click(object sender, EventArgs e)
        {
            string id = (string)(lstTasks.SelectedItems[0].Tag);
            TaskData taskData = FindClickedTask(id);
            taskData.DebugData.Output = string.Empty;
            UpdateTaskDisplay(id);
        }
    }
}
