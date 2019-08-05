namespace SimplifiedTaskScheduler.GUI
{
    partial class FormTaskData
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.txtCommandArguments = new System.Windows.Forms.TextBox();
            this.chkRunAsOtherUser = new System.Windows.Forms.CheckBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.nudDaysBetween = new System.Windows.Forms.NumericUpDown();
            this.cbostartType = new System.Windows.Forms.ComboBox();
            this.tabTaskData = new System.Windows.Forms.TabControl();
            this.tbpDetails = new System.Windows.Forms.TabPage();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tbpCommand = new System.Windows.Forms.TabPage();
            this.grpOtherUser = new System.Windows.Forms.GroupBox();
            this.lblPasswordLabel = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblDomainName = new System.Windows.Forms.Label();
            this.txtDomainName = new System.Windows.Forms.TextBox();
            this.lblStartIn = new System.Windows.Forms.Label();
            this.txtStartIn = new System.Windows.Forms.TextBox();
            this.lblCommandArguments = new System.Windows.Forms.Label();
            this.lblCommand = new System.Windows.Forms.Label();
            this.tbpSchedule = new System.Windows.Forms.TabPage();
            this.lblWeekDays = new System.Windows.Forms.Label();
            this.chklWeekDays = new System.Windows.Forms.CheckedListBox();
            this.lblweeksBetween = new System.Windows.Forms.Label();
            this.nudWeeksBetween = new System.Windows.Forms.NumericUpDown();
            this.lblDaysBetween = new System.Windows.Forms.Label();
            this.dtpExpiryTime = new System.Windows.Forms.DateTimePicker();
            this.lblExpiryDateTime = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartType = new System.Windows.Forms.Label();
            this.lblStartDateTime = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDaysBetween)).BeginInit();
            this.tabTaskData.SuspendLayout();
            this.tbpDetails.SuspendLayout();
            this.tbpCommand.SuspendLayout();
            this.grpOtherUser.SuspendLayout();
            this.tbpSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeeksBetween)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(99, 64);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(794, 502);
            this.txtDescription.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(99, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(794, 22);
            this.txtName.TabIndex = 1;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(6, 6);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(82, 21);
            this.chkEnabled.TabIndex = 2;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Location = new System.Drawing.Point(141, 6);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(752, 22);
            this.txtCommand.TabIndex = 3;
            // 
            // txtCommandArguments
            // 
            this.txtCommandArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommandArguments.Location = new System.Drawing.Point(141, 34);
            this.txtCommandArguments.Name = "txtCommandArguments";
            this.txtCommandArguments.Size = new System.Drawing.Size(752, 22);
            this.txtCommandArguments.TabIndex = 4;
            // 
            // chkRunAsOtherUser
            // 
            this.chkRunAsOtherUser.AutoSize = true;
            this.chkRunAsOtherUser.Location = new System.Drawing.Point(12, 90);
            this.chkRunAsOtherUser.Name = "chkRunAsOtherUser";
            this.chkRunAsOtherUser.Size = new System.Drawing.Size(144, 21);
            this.chkRunAsOtherUser.TabIndex = 5;
            this.chkRunAsOtherUser.Text = "Run as other user";
            this.chkRunAsOtherUser.UseVisualStyleBackColor = true;
            this.chkRunAsOtherUser.CheckedChanged += new System.EventHandler(this.ChkRunAsOtherUser_CheckedChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.Location = new System.Drawing.Point(120, 5);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(637, 22);
            this.dtpStartDate.TabIndex = 6;
            // 
            // nudDaysBetween
            // 
            this.nudDaysBetween.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDaysBetween.Location = new System.Drawing.Point(118, 91);
            this.nudDaysBetween.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudDaysBetween.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDaysBetween.Name = "nudDaysBetween";
            this.nudDaysBetween.Size = new System.Drawing.Size(767, 22);
            this.nudDaysBetween.TabIndex = 8;
            this.nudDaysBetween.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbostartType
            // 
            this.cbostartType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbostartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbostartType.FormattingEnabled = true;
            this.cbostartType.Location = new System.Drawing.Point(120, 33);
            this.cbostartType.Name = "cbostartType";
            this.cbostartType.Size = new System.Drawing.Size(765, 24);
            this.cbostartType.TabIndex = 9;
            this.cbostartType.SelectedIndexChanged += new System.EventHandler(this.CbostartType_SelectedIndexChanged);
            // 
            // tabTaskData
            // 
            this.tabTaskData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTaskData.Controls.Add(this.tbpDetails);
            this.tabTaskData.Controls.Add(this.tbpCommand);
            this.tabTaskData.Controls.Add(this.tbpSchedule);
            this.tabTaskData.Location = new System.Drawing.Point(12, 12);
            this.tabTaskData.Name = "tabTaskData";
            this.tabTaskData.SelectedIndex = 0;
            this.tabTaskData.Size = new System.Drawing.Size(907, 601);
            this.tabTaskData.TabIndex = 12;
            // 
            // tbpDetails
            // 
            this.tbpDetails.Controls.Add(this.lblDescription);
            this.tbpDetails.Controls.Add(this.lblName);
            this.tbpDetails.Controls.Add(this.chkEnabled);
            this.tbpDetails.Controls.Add(this.txtName);
            this.tbpDetails.Controls.Add(this.txtDescription);
            this.tbpDetails.Location = new System.Drawing.Point(4, 25);
            this.tbpDetails.Name = "tbpDetails";
            this.tbpDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDetails.Size = new System.Drawing.Size(899, 572);
            this.tbpDetails.TabIndex = 0;
            this.tbpDetails.Text = "Details";
            this.tbpDetails.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 67);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 17);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // tbpCommand
            // 
            this.tbpCommand.Controls.Add(this.grpOtherUser);
            this.tbpCommand.Controls.Add(this.lblStartIn);
            this.tbpCommand.Controls.Add(this.txtStartIn);
            this.tbpCommand.Controls.Add(this.lblCommandArguments);
            this.tbpCommand.Controls.Add(this.lblCommand);
            this.tbpCommand.Controls.Add(this.txtCommand);
            this.tbpCommand.Controls.Add(this.chkRunAsOtherUser);
            this.tbpCommand.Controls.Add(this.txtCommandArguments);
            this.tbpCommand.Location = new System.Drawing.Point(4, 25);
            this.tbpCommand.Name = "tbpCommand";
            this.tbpCommand.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCommand.Size = new System.Drawing.Size(899, 572);
            this.tbpCommand.TabIndex = 1;
            this.tbpCommand.Text = "Command";
            this.tbpCommand.UseVisualStyleBackColor = true;
            // 
            // grpOtherUser
            // 
            this.grpOtherUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOtherUser.Controls.Add(this.lblPasswordLabel);
            this.grpOtherUser.Controls.Add(this.lblPassword);
            this.grpOtherUser.Controls.Add(this.txtPassword);
            this.grpOtherUser.Controls.Add(this.lblUserName);
            this.grpOtherUser.Controls.Add(this.txtUserName);
            this.grpOtherUser.Controls.Add(this.lblDomainName);
            this.grpOtherUser.Controls.Add(this.txtDomainName);
            this.grpOtherUser.Location = new System.Drawing.Point(12, 117);
            this.grpOtherUser.Name = "grpOtherUser";
            this.grpOtherUser.Size = new System.Drawing.Size(876, 198);
            this.grpOtherUser.TabIndex = 14;
            this.grpOtherUser.TabStop = false;
            // 
            // lblPasswordLabel
            // 
            this.lblPasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPasswordLabel.Location = new System.Drawing.Point(20, 22);
            this.lblPasswordLabel.Name = "lblPasswordLabel";
            this.lblPasswordLabel.Size = new System.Drawing.Size(850, 80);
            this.lblPasswordLabel.TabIndex = 20;
            this.lblPasswordLabel.Text = "Warning!\r\nPasswords are stored and handled INSECURELY!\r\nIt is recommended not to " +
    "use these options unless you are very sure about the safety of your environment." +
    "";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(17, 164);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 17);
            this.lblPassword.TabIndex = 18;
            this.lblPassword.Text = "Domain:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(152, 161);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(718, 22);
            this.txtPassword.TabIndex = 19;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(17, 136);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(77, 17);
            this.lblUserName.TabIndex = 16;
            this.lblUserName.Text = "Username:";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(152, 133);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(718, 22);
            this.txtUserName.TabIndex = 17;
            // 
            // lblDomainName
            // 
            this.lblDomainName.AutoSize = true;
            this.lblDomainName.Location = new System.Drawing.Point(17, 108);
            this.lblDomainName.Name = "lblDomainName";
            this.lblDomainName.Size = new System.Drawing.Size(60, 17);
            this.lblDomainName.TabIndex = 14;
            this.lblDomainName.Text = "Domain:";
            // 
            // txtDomainName
            // 
            this.txtDomainName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDomainName.Location = new System.Drawing.Point(152, 105);
            this.txtDomainName.Name = "txtDomainName";
            this.txtDomainName.Size = new System.Drawing.Size(718, 22);
            this.txtDomainName.TabIndex = 15;
            // 
            // lblStartIn
            // 
            this.lblStartIn.AutoSize = true;
            this.lblStartIn.Location = new System.Drawing.Point(9, 66);
            this.lblStartIn.Name = "lblStartIn";
            this.lblStartIn.Size = new System.Drawing.Size(57, 17);
            this.lblStartIn.TabIndex = 7;
            this.lblStartIn.Text = "Start in:";
            // 
            // txtStartIn
            // 
            this.txtStartIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartIn.Location = new System.Drawing.Point(141, 62);
            this.txtStartIn.Name = "txtStartIn";
            this.txtStartIn.Size = new System.Drawing.Size(752, 22);
            this.txtStartIn.TabIndex = 6;
            // 
            // lblCommandArguments
            // 
            this.lblCommandArguments.AutoSize = true;
            this.lblCommandArguments.Location = new System.Drawing.Point(9, 38);
            this.lblCommandArguments.Name = "lblCommandArguments";
            this.lblCommandArguments.Size = new System.Drawing.Size(80, 17);
            this.lblCommandArguments.TabIndex = 5;
            this.lblCommandArguments.Text = "Arguments:";
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(6, 9);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(75, 17);
            this.lblCommand.TabIndex = 0;
            this.lblCommand.Text = "Command:";
            // 
            // tbpSchedule
            // 
            this.tbpSchedule.Controls.Add(this.lblWeekDays);
            this.tbpSchedule.Controls.Add(this.chklWeekDays);
            this.tbpSchedule.Controls.Add(this.lblweeksBetween);
            this.tbpSchedule.Controls.Add(this.nudWeeksBetween);
            this.tbpSchedule.Controls.Add(this.lblDaysBetween);
            this.tbpSchedule.Controls.Add(this.dtpExpiryTime);
            this.tbpSchedule.Controls.Add(this.lblExpiryDateTime);
            this.tbpSchedule.Controls.Add(this.dtpExpiryDate);
            this.tbpSchedule.Controls.Add(this.nudDaysBetween);
            this.tbpSchedule.Controls.Add(this.cbostartType);
            this.tbpSchedule.Controls.Add(this.dtpStartTime);
            this.tbpSchedule.Controls.Add(this.lblStartType);
            this.tbpSchedule.Controls.Add(this.lblStartDateTime);
            this.tbpSchedule.Controls.Add(this.dtpStartDate);
            this.tbpSchedule.Location = new System.Drawing.Point(4, 25);
            this.tbpSchedule.Name = "tbpSchedule";
            this.tbpSchedule.Size = new System.Drawing.Size(899, 572);
            this.tbpSchedule.TabIndex = 2;
            this.tbpSchedule.Text = "Schedule";
            this.tbpSchedule.UseVisualStyleBackColor = true;
            // 
            // lblWeekDays
            // 
            this.lblWeekDays.AutoSize = true;
            this.lblWeekDays.Location = new System.Drawing.Point(3, 119);
            this.lblWeekDays.Name = "lblWeekDays";
            this.lblWeekDays.Size = new System.Drawing.Size(89, 17);
            this.lblWeekDays.TabIndex = 15;
            this.lblWeekDays.Text = "Weeks days:";
            // 
            // chklWeekDays
            // 
            this.chklWeekDays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklWeekDays.FormattingEnabled = true;
            this.chklWeekDays.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.chklWeekDays.Location = new System.Drawing.Point(118, 119);
            this.chklWeekDays.Name = "chklWeekDays";
            this.chklWeekDays.Size = new System.Drawing.Size(767, 429);
            this.chklWeekDays.TabIndex = 14;
            // 
            // lblweeksBetween
            // 
            this.lblweeksBetween.AutoSize = true;
            this.lblweeksBetween.Location = new System.Drawing.Point(3, 522);
            this.lblweeksBetween.Name = "lblweeksBetween";
            this.lblweeksBetween.Size = new System.Drawing.Size(112, 17);
            this.lblweeksBetween.TabIndex = 13;
            this.lblweeksBetween.Text = "Weeks between:";
            this.lblweeksBetween.Visible = false;
            // 
            // nudWeeksBetween
            // 
            this.nudWeeksBetween.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWeeksBetween.Location = new System.Drawing.Point(118, 520);
            this.nudWeeksBetween.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudWeeksBetween.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWeeksBetween.Name = "nudWeeksBetween";
            this.nudWeeksBetween.Size = new System.Drawing.Size(767, 22);
            this.nudWeeksBetween.TabIndex = 12;
            this.nudWeeksBetween.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWeeksBetween.Visible = false;
            // 
            // lblDaysBetween
            // 
            this.lblDaysBetween.AutoSize = true;
            this.lblDaysBetween.Location = new System.Drawing.Point(3, 93);
            this.lblDaysBetween.Name = "lblDaysBetween";
            this.lblDaysBetween.Size = new System.Drawing.Size(101, 17);
            this.lblDaysBetween.TabIndex = 11;
            this.lblDaysBetween.Text = "Days between:";
            // 
            // dtpExpiryTime
            // 
            this.dtpExpiryTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpExpiryTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpExpiryTime.Location = new System.Drawing.Point(763, 63);
            this.dtpExpiryTime.Name = "dtpExpiryTime";
            this.dtpExpiryTime.ShowUpDown = true;
            this.dtpExpiryTime.Size = new System.Drawing.Size(122, 22);
            this.dtpExpiryTime.TabIndex = 10;
            // 
            // lblExpiryDateTime
            // 
            this.lblExpiryDateTime.AutoSize = true;
            this.lblExpiryDateTime.Location = new System.Drawing.Point(3, 65);
            this.lblExpiryDateTime.Name = "lblExpiryDateTime";
            this.lblExpiryDateTime.Size = new System.Drawing.Size(51, 17);
            this.lblExpiryDateTime.TabIndex = 8;
            this.lblExpiryDateTime.Text = "Expire:";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpExpiryDate.Location = new System.Drawing.Point(120, 63);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(637, 22);
            this.dtpExpiryDate.TabIndex = 9;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(763, 5);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(122, 22);
            this.dtpStartTime.TabIndex = 7;
            // 
            // lblStartType
            // 
            this.lblStartType.AutoSize = true;
            this.lblStartType.Location = new System.Drawing.Point(3, 36);
            this.lblStartType.Name = "lblStartType";
            this.lblStartType.Size = new System.Drawing.Size(73, 17);
            this.lblStartType.TabIndex = 1;
            this.lblStartType.Text = "Start type:";
            // 
            // lblStartDateTime
            // 
            this.lblStartDateTime.AutoSize = true;
            this.lblStartDateTime.Location = new System.Drawing.Point(3, 7);
            this.lblStartDateTime.Name = "lblStartDateTime";
            this.lblStartDateTime.Size = new System.Drawing.Size(42, 17);
            this.lblStartDateTime.TabIndex = 0;
            this.lblStartDateTime.Text = "Start:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(763, 619);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(844, 619);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormTaskData
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(931, 654);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabTaskData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTaskData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task Data";
            this.Load += new System.EventHandler(this.FormTaskData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDaysBetween)).EndInit();
            this.tabTaskData.ResumeLayout(false);
            this.tbpDetails.ResumeLayout(false);
            this.tbpDetails.PerformLayout();
            this.tbpCommand.ResumeLayout(false);
            this.tbpCommand.PerformLayout();
            this.grpOtherUser.ResumeLayout(false);
            this.grpOtherUser.PerformLayout();
            this.tbpSchedule.ResumeLayout(false);
            this.tbpSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeeksBetween)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.TextBox txtCommandArguments;
        private System.Windows.Forms.CheckBox chkRunAsOtherUser;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.NumericUpDown nudDaysBetween;
        private System.Windows.Forms.ComboBox cbostartType;
        private System.Windows.Forms.TabControl tabTaskData;
        private System.Windows.Forms.TabPage tbpDetails;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabPage tbpCommand;
        private System.Windows.Forms.GroupBox grpOtherUser;
        private System.Windows.Forms.Label lblPasswordLabel;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblDomainName;
        private System.Windows.Forms.TextBox txtDomainName;
        private System.Windows.Forms.Label lblStartIn;
        private System.Windows.Forms.TextBox txtStartIn;
        private System.Windows.Forms.Label lblCommandArguments;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.TabPage tbpSchedule;
        private System.Windows.Forms.Label lblWeekDays;
        private System.Windows.Forms.CheckedListBox chklWeekDays;
        private System.Windows.Forms.Label lblweeksBetween;
        private System.Windows.Forms.NumericUpDown nudWeeksBetween;
        private System.Windows.Forms.Label lblDaysBetween;
        private System.Windows.Forms.DateTimePicker dtpExpiryTime;
        private System.Windows.Forms.Label lblExpiryDateTime;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblStartType;
        private System.Windows.Forms.Label lblStartDateTime;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}