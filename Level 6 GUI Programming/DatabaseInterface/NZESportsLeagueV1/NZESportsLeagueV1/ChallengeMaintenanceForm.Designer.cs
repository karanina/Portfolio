namespace NZESportsLeagueV1
{
    partial class ChallengeMaintenanceForm
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
            this.lstChallengeID = new System.Windows.Forms.ListBox();
            this.lblChallengeID = new System.Windows.Forms.Label();
            this.lblChallengeName = new System.Windows.Forms.Label();
            this.lblEventID = new System.Windows.Forms.Label();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.txtChallengeID = new System.Windows.Forms.TextBox();
            this.txtChallengeName = new System.Windows.Forms.TextBox();
            this.txtEventID = new System.Windows.Forms.TextBox();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAddChallenge = new System.Windows.Forms.Button();
            this.btnUpdateChallenge = new System.Windows.Forms.Button();
            this.btnDeleteChallenge = new System.Windows.Forms.Button();
            this.btnChallengeFinished = new System.Windows.Forms.Button();
            this.btnChallengeComplete = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pnlAddChallenge = new System.Windows.Forms.Panel();
            this.datAddStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnAddCancel = new System.Windows.Forms.Button();
            this.btnSaveAddChallenge = new System.Windows.Forms.Button();
            this.numAddCapacity = new System.Windows.Forms.NumericUpDown();
            this.comAddEventStatus = new System.Windows.Forms.ComboBox();
            this.comAddEventName = new System.Windows.Forms.ComboBox();
            this.comAddEventID = new System.Windows.Forms.ComboBox();
            this.txtAddChallengeName = new System.Windows.Forms.TextBox();
            this.lblAddCapacity = new System.Windows.Forms.Label();
            this.lblAddStatus = new System.Windows.Forms.Label();
            this.lblAddStartTime = new System.Windows.Forms.Label();
            this.lblAddEvent = new System.Windows.Forms.Label();
            this.lblAddChallengeName = new System.Windows.Forms.Label();
            this.pnlUpdateChallenge = new System.Windows.Forms.Panel();
            this.numUpdateCapacity = new System.Windows.Forms.NumericUpDown();
            this.datUpdateStartTime = new System.Windows.Forms.DateTimePicker();
            this.txtUpdateEventName = new System.Windows.Forms.TextBox();
            this.txtUpdateChallengeID = new System.Windows.Forms.TextBox();
            this.lblUpdateChallengeID = new System.Windows.Forms.Label();
            this.btnCancelUpdate = new System.Windows.Forms.Button();
            this.btnSaveUpdateChallenge = new System.Windows.Forms.Button();
            this.comUpdateStatus = new System.Windows.Forms.ComboBox();
            this.txtUpdateChallengeName = new System.Windows.Forms.TextBox();
            this.lblUpdateCapacity = new System.Windows.Forms.Label();
            this.lblUpdateStatus = new System.Windows.Forms.Label();
            this.lblUpdateStartTime = new System.Windows.Forms.Label();
            this.lblUpdateEvent = new System.Windows.Forms.Label();
            this.lblUpdateChallengeName = new System.Windows.Forms.Label();
            this.datStartTime = new System.Windows.Forms.DateTimePicker();
            this.pnlAddChallenge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAddCapacity)).BeginInit();
            this.pnlUpdateChallenge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lstChallengeID
            // 
            this.lstChallengeID.FormattingEnabled = true;
            this.lstChallengeID.Location = new System.Drawing.Point(27, 31);
            this.lstChallengeID.Name = "lstChallengeID";
            this.lstChallengeID.Size = new System.Drawing.Size(120, 212);
            this.lstChallengeID.TabIndex = 0;
            this.lstChallengeID.SelectedIndexChanged += new System.EventHandler(this.lstChallengeID_SelectedIndexChanged);
            // 
            // lblChallengeID
            // 
            this.lblChallengeID.AutoSize = true;
            this.lblChallengeID.Location = new System.Drawing.Point(186, 31);
            this.lblChallengeID.Name = "lblChallengeID";
            this.lblChallengeID.Size = new System.Drawing.Size(71, 13);
            this.lblChallengeID.TabIndex = 1;
            this.lblChallengeID.Text = "Challenge ID:";
            // 
            // lblChallengeName
            // 
            this.lblChallengeName.AutoSize = true;
            this.lblChallengeName.Location = new System.Drawing.Point(168, 62);
            this.lblChallengeName.Name = "lblChallengeName";
            this.lblChallengeName.Size = new System.Drawing.Size(88, 13);
            this.lblChallengeName.TabIndex = 2;
            this.lblChallengeName.Text = "Challenge Name:";
            // 
            // lblEventID
            // 
            this.lblEventID.AutoSize = true;
            this.lblEventID.Location = new System.Drawing.Point(204, 95);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(52, 13);
            this.lblEventID.TabIndex = 3;
            this.lblEventID.Text = "Event ID:";
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Location = new System.Drawing.Point(188, 127);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(69, 13);
            this.lblEventName.TabIndex = 4;
            this.lblEventName.Text = "Event Name:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(199, 160);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(58, 13);
            this.lblStartTime.TabIndex = 5;
            this.lblStartTime.Text = "Start Time:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(217, 193);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:";
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(206, 226);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(51, 13);
            this.lblCapacity.TabIndex = 7;
            this.lblCapacity.Text = "Capacity:";
            // 
            // txtChallengeID
            // 
            this.txtChallengeID.Location = new System.Drawing.Point(263, 28);
            this.txtChallengeID.Name = "txtChallengeID";
            this.txtChallengeID.ReadOnly = true;
            this.txtChallengeID.Size = new System.Drawing.Size(50, 20);
            this.txtChallengeID.TabIndex = 8;
            // 
            // txtChallengeName
            // 
            this.txtChallengeName.Location = new System.Drawing.Point(263, 59);
            this.txtChallengeName.MaxLength = 40;
            this.txtChallengeName.Name = "txtChallengeName";
            this.txtChallengeName.ReadOnly = true;
            this.txtChallengeName.Size = new System.Drawing.Size(228, 20);
            this.txtChallengeName.TabIndex = 9;
            // 
            // txtEventID
            // 
            this.txtEventID.Location = new System.Drawing.Point(263, 92);
            this.txtEventID.Name = "txtEventID";
            this.txtEventID.ReadOnly = true;
            this.txtEventID.Size = new System.Drawing.Size(30, 20);
            this.txtEventID.TabIndex = 10;
            // 
            // txtEventName
            // 
            this.txtEventName.Location = new System.Drawing.Point(263, 124);
            this.txtEventName.MaxLength = 40;
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.ReadOnly = true;
            this.txtEventName.Size = new System.Drawing.Size(228, 20);
            this.txtEventName.TabIndex = 11;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(263, 190);
            this.txtStatus.MaxLength = 9;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(125, 20);
            this.txtStatus.TabIndex = 13;
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(263, 223);
            this.txtCapacity.MaxLength = 40;
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.ReadOnly = true;
            this.txtCapacity.Size = new System.Drawing.Size(50, 20);
            this.txtCapacity.TabIndex = 14;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(27, 264);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(106, 23);
            this.btnPrevious.TabIndex = 15;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(146, 264);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(106, 23);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnAddChallenge
            // 
            this.btnAddChallenge.Location = new System.Drawing.Point(266, 264);
            this.btnAddChallenge.Name = "btnAddChallenge";
            this.btnAddChallenge.Size = new System.Drawing.Size(106, 23);
            this.btnAddChallenge.TabIndex = 17;
            this.btnAddChallenge.Text = "Add Challenge";
            this.btnAddChallenge.UseVisualStyleBackColor = true;
            this.btnAddChallenge.Click += new System.EventHandler(this.btnAddChallenge_Click);
            // 
            // btnUpdateChallenge
            // 
            this.btnUpdateChallenge.Location = new System.Drawing.Point(385, 264);
            this.btnUpdateChallenge.Name = "btnUpdateChallenge";
            this.btnUpdateChallenge.Size = new System.Drawing.Size(106, 23);
            this.btnUpdateChallenge.TabIndex = 18;
            this.btnUpdateChallenge.Text = "Update Challenge";
            this.btnUpdateChallenge.UseVisualStyleBackColor = true;
            this.btnUpdateChallenge.Click += new System.EventHandler(this.btnUpdateChallenge_Click);
            // 
            // btnDeleteChallenge
            // 
            this.btnDeleteChallenge.Location = new System.Drawing.Point(505, 264);
            this.btnDeleteChallenge.Name = "btnDeleteChallenge";
            this.btnDeleteChallenge.Size = new System.Drawing.Size(106, 23);
            this.btnDeleteChallenge.TabIndex = 19;
            this.btnDeleteChallenge.Text = "Delete Challenge";
            this.btnDeleteChallenge.UseVisualStyleBackColor = true;
            this.btnDeleteChallenge.Click += new System.EventHandler(this.btnDeleteChallenge_Click);
            // 
            // btnChallengeFinished
            // 
            this.btnChallengeFinished.Location = new System.Drawing.Point(27, 307);
            this.btnChallengeFinished.Name = "btnChallengeFinished";
            this.btnChallengeFinished.Size = new System.Drawing.Size(225, 23);
            this.btnChallengeFinished.TabIndex = 20;
            this.btnChallengeFinished.Text = "Mark Challenge as Finished";
            this.btnChallengeFinished.UseVisualStyleBackColor = true;
            this.btnChallengeFinished.Click += new System.EventHandler(this.btnMarkChallengeFinished_Click);
            // 
            // btnChallengeComplete
            // 
            this.btnChallengeComplete.Location = new System.Drawing.Point(266, 307);
            this.btnChallengeComplete.Name = "btnChallengeComplete";
            this.btnChallengeComplete.Size = new System.Drawing.Size(225, 23);
            this.btnChallengeComplete.TabIndex = 21;
            this.btnChallengeComplete.Text = "Mark Challenge as Complete";
            this.btnChallengeComplete.UseVisualStyleBackColor = true;
            this.btnChallengeComplete.Click += new System.EventHandler(this.btnMarkChallengeCompleted_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(505, 307);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(106, 23);
            this.btnReturn.TabIndex = 22;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pnlAddChallenge
            // 
            this.pnlAddChallenge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddChallenge.Controls.Add(this.datAddStartTime);
            this.pnlAddChallenge.Controls.Add(this.btnAddCancel);
            this.pnlAddChallenge.Controls.Add(this.btnSaveAddChallenge);
            this.pnlAddChallenge.Controls.Add(this.numAddCapacity);
            this.pnlAddChallenge.Controls.Add(this.comAddEventStatus);
            this.pnlAddChallenge.Controls.Add(this.comAddEventName);
            this.pnlAddChallenge.Controls.Add(this.comAddEventID);
            this.pnlAddChallenge.Controls.Add(this.txtAddChallengeName);
            this.pnlAddChallenge.Controls.Add(this.lblAddCapacity);
            this.pnlAddChallenge.Controls.Add(this.lblAddStatus);
            this.pnlAddChallenge.Controls.Add(this.lblAddStartTime);
            this.pnlAddChallenge.Controls.Add(this.lblAddEvent);
            this.pnlAddChallenge.Controls.Add(this.lblAddChallengeName);
            this.pnlAddChallenge.Location = new System.Drawing.Point(168, 28);
            this.pnlAddChallenge.Name = "pnlAddChallenge";
            this.pnlAddChallenge.Size = new System.Drawing.Size(380, 215);
            this.pnlAddChallenge.TabIndex = 23;
            this.pnlAddChallenge.Visible = false;
            // 
            // datAddStartTime
            // 
            this.datAddStartTime.CustomFormat = "HH:mm";
            this.datAddStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datAddStartTime.Location = new System.Drawing.Point(126, 81);
            this.datAddStartTime.Name = "datAddStartTime";
            this.datAddStartTime.Size = new System.Drawing.Size(100, 20);
            this.datAddStartTime.TabIndex = 26;
            this.datAddStartTime.Value = new System.DateTime(2020, 9, 2, 21, 17, 4, 0);
            // 
            // btnAddCancel
            // 
            this.btnAddCancel.Location = new System.Drawing.Point(255, 175);
            this.btnAddCancel.Name = "btnAddCancel";
            this.btnAddCancel.Size = new System.Drawing.Size(106, 23);
            this.btnAddCancel.TabIndex = 12;
            this.btnAddCancel.Text = "Cancel";
            this.btnAddCancel.UseVisualStyleBackColor = true;
            this.btnAddCancel.Click += new System.EventHandler(this.btnCancelAddChallenge_Click);
            // 
            // btnSaveAddChallenge
            // 
            this.btnSaveAddChallenge.Location = new System.Drawing.Point(16, 175);
            this.btnSaveAddChallenge.Name = "btnSaveAddChallenge";
            this.btnSaveAddChallenge.Size = new System.Drawing.Size(106, 23);
            this.btnSaveAddChallenge.TabIndex = 11;
            this.btnSaveAddChallenge.Text = "Save Challenge";
            this.btnSaveAddChallenge.UseVisualStyleBackColor = true;
            this.btnSaveAddChallenge.Click += new System.EventHandler(this.btnSaveAddChallenge_Click);
            // 
            // numAddCapacity
            // 
            this.numAddCapacity.Location = new System.Drawing.Point(126, 145);
            this.numAddCapacity.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numAddCapacity.Name = "numAddCapacity";
            this.numAddCapacity.Size = new System.Drawing.Size(50, 20);
            this.numAddCapacity.TabIndex = 10;
            this.numAddCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comAddEventStatus
            // 
            this.comAddEventStatus.FormattingEnabled = true;
            this.comAddEventStatus.Items.AddRange(new object[] {
            "Scheduled",
            "Completed",
            "Finished"});
            this.comAddEventStatus.Location = new System.Drawing.Point(126, 113);
            this.comAddEventStatus.MaxLength = 9;
            this.comAddEventStatus.Name = "comAddEventStatus";
            this.comAddEventStatus.Size = new System.Drawing.Size(100, 21);
            this.comAddEventStatus.TabIndex = 9;
            // 
            // comAddEventName
            // 
            this.comAddEventName.FormattingEnabled = true;
            this.comAddEventName.Location = new System.Drawing.Point(188, 49);
            this.comAddEventName.MaxLength = 40;
            this.comAddEventName.Name = "comAddEventName";
            this.comAddEventName.Size = new System.Drawing.Size(173, 21);
            this.comAddEventName.TabIndex = 8;
            // 
            // comAddEventID
            // 
            this.comAddEventID.FormattingEnabled = true;
            this.comAddEventID.Location = new System.Drawing.Point(126, 49);
            this.comAddEventID.Name = "comAddEventID";
            this.comAddEventID.Size = new System.Drawing.Size(56, 21);
            this.comAddEventID.TabIndex = 7;
            // 
            // txtAddChallengeName
            // 
            this.txtAddChallengeName.Location = new System.Drawing.Point(126, 17);
            this.txtAddChallengeName.MaxLength = 40;
            this.txtAddChallengeName.Name = "txtAddChallengeName";
            this.txtAddChallengeName.Size = new System.Drawing.Size(179, 20);
            this.txtAddChallengeName.TabIndex = 5;
            // 
            // lblAddCapacity
            // 
            this.lblAddCapacity.AutoSize = true;
            this.lblAddCapacity.Location = new System.Drawing.Point(71, 147);
            this.lblAddCapacity.Name = "lblAddCapacity";
            this.lblAddCapacity.Size = new System.Drawing.Size(51, 13);
            this.lblAddCapacity.TabIndex = 4;
            this.lblAddCapacity.Text = "Capacity:";
            // 
            // lblAddStatus
            // 
            this.lblAddStatus.AutoSize = true;
            this.lblAddStatus.Location = new System.Drawing.Point(82, 116);
            this.lblAddStatus.Name = "lblAddStatus";
            this.lblAddStatus.Size = new System.Drawing.Size(40, 13);
            this.lblAddStatus.TabIndex = 3;
            this.lblAddStatus.Text = "Status:";
            // 
            // lblAddStartTime
            // 
            this.lblAddStartTime.AutoSize = true;
            this.lblAddStartTime.Location = new System.Drawing.Point(64, 84);
            this.lblAddStartTime.Name = "lblAddStartTime";
            this.lblAddStartTime.Size = new System.Drawing.Size(58, 13);
            this.lblAddStartTime.TabIndex = 2;
            this.lblAddStartTime.Text = "Start Time:";
            // 
            // lblAddEvent
            // 
            this.lblAddEvent.AutoSize = true;
            this.lblAddEvent.Location = new System.Drawing.Point(84, 52);
            this.lblAddEvent.Name = "lblAddEvent";
            this.lblAddEvent.Size = new System.Drawing.Size(38, 13);
            this.lblAddEvent.TabIndex = 1;
            this.lblAddEvent.Text = "Event:";
            // 
            // lblAddChallengeName
            // 
            this.lblAddChallengeName.AutoSize = true;
            this.lblAddChallengeName.Location = new System.Drawing.Point(34, 20);
            this.lblAddChallengeName.Name = "lblAddChallengeName";
            this.lblAddChallengeName.Size = new System.Drawing.Size(88, 13);
            this.lblAddChallengeName.TabIndex = 0;
            this.lblAddChallengeName.Text = "Challenge Name:";
            // 
            // pnlUpdateChallenge
            // 
            this.pnlUpdateChallenge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdateChallenge.Controls.Add(this.numUpdateCapacity);
            this.pnlUpdateChallenge.Controls.Add(this.datUpdateStartTime);
            this.pnlUpdateChallenge.Controls.Add(this.txtUpdateEventName);
            this.pnlUpdateChallenge.Controls.Add(this.txtUpdateChallengeID);
            this.pnlUpdateChallenge.Controls.Add(this.lblUpdateChallengeID);
            this.pnlUpdateChallenge.Controls.Add(this.btnCancelUpdate);
            this.pnlUpdateChallenge.Controls.Add(this.btnSaveUpdateChallenge);
            this.pnlUpdateChallenge.Controls.Add(this.comUpdateStatus);
            this.pnlUpdateChallenge.Controls.Add(this.txtUpdateChallengeName);
            this.pnlUpdateChallenge.Controls.Add(this.lblUpdateCapacity);
            this.pnlUpdateChallenge.Controls.Add(this.lblUpdateStatus);
            this.pnlUpdateChallenge.Controls.Add(this.lblUpdateStartTime);
            this.pnlUpdateChallenge.Controls.Add(this.lblUpdateEvent);
            this.pnlUpdateChallenge.Controls.Add(this.lblUpdateChallengeName);
            this.pnlUpdateChallenge.Location = new System.Drawing.Point(168, 12);
            this.pnlUpdateChallenge.Name = "pnlUpdateChallenge";
            this.pnlUpdateChallenge.Size = new System.Drawing.Size(380, 246);
            this.pnlUpdateChallenge.TabIndex = 24;
            this.pnlUpdateChallenge.Visible = false;
            // 
            // numUpdateCapacity
            // 
            this.numUpdateCapacity.Location = new System.Drawing.Point(126, 175);
            this.numUpdateCapacity.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numUpdateCapacity.Name = "numUpdateCapacity";
            this.numUpdateCapacity.Size = new System.Drawing.Size(50, 20);
            this.numUpdateCapacity.TabIndex = 28;
            this.numUpdateCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // datUpdateStartTime
            // 
            this.datUpdateStartTime.CustomFormat = "hh:mm:ss tt";
            this.datUpdateStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datUpdateStartTime.Location = new System.Drawing.Point(126, 111);
            this.datUpdateStartTime.Name = "datUpdateStartTime";
            this.datUpdateStartTime.Size = new System.Drawing.Size(100, 20);
            this.datUpdateStartTime.TabIndex = 27;
            this.datUpdateStartTime.Value = new System.DateTime(2020, 9, 2, 21, 17, 51, 0);
            // 
            // txtUpdateEventName
            // 
            this.txtUpdateEventName.Location = new System.Drawing.Point(126, 79);
            this.txtUpdateEventName.MaxLength = 40;
            this.txtUpdateEventName.Name = "txtUpdateEventName";
            this.txtUpdateEventName.ReadOnly = true;
            this.txtUpdateEventName.Size = new System.Drawing.Size(235, 20);
            this.txtUpdateEventName.TabIndex = 15;
            // 
            // txtUpdateChallengeID
            // 
            this.txtUpdateChallengeID.Location = new System.Drawing.Point(126, 14);
            this.txtUpdateChallengeID.Name = "txtUpdateChallengeID";
            this.txtUpdateChallengeID.ReadOnly = true;
            this.txtUpdateChallengeID.Size = new System.Drawing.Size(50, 20);
            this.txtUpdateChallengeID.TabIndex = 14;
            // 
            // lblUpdateChallengeID
            // 
            this.lblUpdateChallengeID.AutoSize = true;
            this.lblUpdateChallengeID.Location = new System.Drawing.Point(51, 17);
            this.lblUpdateChallengeID.Name = "lblUpdateChallengeID";
            this.lblUpdateChallengeID.Size = new System.Drawing.Size(71, 13);
            this.lblUpdateChallengeID.TabIndex = 13;
            this.lblUpdateChallengeID.Text = "Challenge ID:";
            // 
            // btnCancelUpdate
            // 
            this.btnCancelUpdate.Location = new System.Drawing.Point(255, 205);
            this.btnCancelUpdate.Name = "btnCancelUpdate";
            this.btnCancelUpdate.Size = new System.Drawing.Size(106, 23);
            this.btnCancelUpdate.TabIndex = 12;
            this.btnCancelUpdate.Text = "Cancel";
            this.btnCancelUpdate.UseVisualStyleBackColor = true;
            this.btnCancelUpdate.Click += new System.EventHandler(this.btnCancelUpdateChallenge_Click);
            // 
            // btnSaveUpdateChallenge
            // 
            this.btnSaveUpdateChallenge.Location = new System.Drawing.Point(16, 205);
            this.btnSaveUpdateChallenge.Name = "btnSaveUpdateChallenge";
            this.btnSaveUpdateChallenge.Size = new System.Drawing.Size(106, 23);
            this.btnSaveUpdateChallenge.TabIndex = 11;
            this.btnSaveUpdateChallenge.Text = "Save Challenge";
            this.btnSaveUpdateChallenge.UseVisualStyleBackColor = true;
            this.btnSaveUpdateChallenge.Click += new System.EventHandler(this.btnSaveUpdateChallenge_Click);
            // 
            // comUpdateStatus
            // 
            this.comUpdateStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comUpdateStatus.Enabled = false;
            this.comUpdateStatus.FormattingEnabled = true;
            this.comUpdateStatus.Items.AddRange(new object[] {
            "Scheduled",
            "Completed",
            "Finished"});
            this.comUpdateStatus.Location = new System.Drawing.Point(126, 143);
            this.comUpdateStatus.MaxLength = 9;
            this.comUpdateStatus.Name = "comUpdateStatus";
            this.comUpdateStatus.Size = new System.Drawing.Size(121, 21);
            this.comUpdateStatus.TabIndex = 9;
            // 
            // txtUpdateChallengeName
            // 
            this.txtUpdateChallengeName.Location = new System.Drawing.Point(126, 47);
            this.txtUpdateChallengeName.MaxLength = 40;
            this.txtUpdateChallengeName.Name = "txtUpdateChallengeName";
            this.txtUpdateChallengeName.Size = new System.Drawing.Size(235, 20);
            this.txtUpdateChallengeName.TabIndex = 5;
            // 
            // lblUpdateCapacity
            // 
            this.lblUpdateCapacity.AutoSize = true;
            this.lblUpdateCapacity.Location = new System.Drawing.Point(71, 177);
            this.lblUpdateCapacity.Name = "lblUpdateCapacity";
            this.lblUpdateCapacity.Size = new System.Drawing.Size(51, 13);
            this.lblUpdateCapacity.TabIndex = 4;
            this.lblUpdateCapacity.Text = "Capacity:";
            // 
            // lblUpdateStatus
            // 
            this.lblUpdateStatus.AutoSize = true;
            this.lblUpdateStatus.Location = new System.Drawing.Point(82, 146);
            this.lblUpdateStatus.Name = "lblUpdateStatus";
            this.lblUpdateStatus.Size = new System.Drawing.Size(40, 13);
            this.lblUpdateStatus.TabIndex = 3;
            this.lblUpdateStatus.Text = "Status:";
            // 
            // lblUpdateStartTime
            // 
            this.lblUpdateStartTime.AutoSize = true;
            this.lblUpdateStartTime.Location = new System.Drawing.Point(64, 114);
            this.lblUpdateStartTime.Name = "lblUpdateStartTime";
            this.lblUpdateStartTime.Size = new System.Drawing.Size(58, 13);
            this.lblUpdateStartTime.TabIndex = 2;
            this.lblUpdateStartTime.Text = "Start Time:";
            // 
            // lblUpdateEvent
            // 
            this.lblUpdateEvent.AutoSize = true;
            this.lblUpdateEvent.Location = new System.Drawing.Point(53, 82);
            this.lblUpdateEvent.Name = "lblUpdateEvent";
            this.lblUpdateEvent.Size = new System.Drawing.Size(69, 13);
            this.lblUpdateEvent.TabIndex = 1;
            this.lblUpdateEvent.Text = "Event Name:";
            // 
            // lblUpdateChallengeName
            // 
            this.lblUpdateChallengeName.AutoSize = true;
            this.lblUpdateChallengeName.Location = new System.Drawing.Point(34, 50);
            this.lblUpdateChallengeName.Name = "lblUpdateChallengeName";
            this.lblUpdateChallengeName.Size = new System.Drawing.Size(88, 13);
            this.lblUpdateChallengeName.TabIndex = 0;
            this.lblUpdateChallengeName.Text = "Challenge Name:";
            // 
            // datStartTime
            // 
            this.datStartTime.CustomFormat = "HH:mm";
            this.datStartTime.Enabled = false;
            this.datStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datStartTime.Location = new System.Drawing.Point(263, 154);
            this.datStartTime.Name = "datStartTime";
            this.datStartTime.Size = new System.Drawing.Size(100, 20);
            this.datStartTime.TabIndex = 12;
            this.datStartTime.Value = new System.DateTime(2020, 9, 2, 21, 16, 20, 0);
            // 
            // ChallengeMaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 354);
            this.Controls.Add(this.pnlUpdateChallenge);
            this.Controls.Add(this.pnlAddChallenge);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnChallengeComplete);
            this.Controls.Add(this.btnChallengeFinished);
            this.Controls.Add(this.btnDeleteChallenge);
            this.Controls.Add(this.btnUpdateChallenge);
            this.Controls.Add(this.btnAddChallenge);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.txtCapacity);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtEventName);
            this.Controls.Add(this.txtEventID);
            this.Controls.Add(this.txtChallengeName);
            this.Controls.Add(this.txtChallengeID);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.lblEventID);
            this.Controls.Add(this.lblChallengeName);
            this.Controls.Add(this.lblChallengeID);
            this.Controls.Add(this.lstChallengeID);
            this.Controls.Add(this.datStartTime);
            this.Name = "ChallengeMaintenanceForm";
            this.Text = "Challenge Maintenance Form";
            this.pnlAddChallenge.ResumeLayout(false);
            this.pnlAddChallenge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAddCapacity)).EndInit();
            this.pnlUpdateChallenge.ResumeLayout(false);
            this.pnlUpdateChallenge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstChallengeID;
        private System.Windows.Forms.Label lblChallengeID;
        private System.Windows.Forms.Label lblChallengeName;
        private System.Windows.Forms.Label lblEventID;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox txtChallengeID;
        private System.Windows.Forms.TextBox txtChallengeName;
        private System.Windows.Forms.TextBox txtEventID;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAddChallenge;
        private System.Windows.Forms.Button btnUpdateChallenge;
        private System.Windows.Forms.Button btnDeleteChallenge;
        private System.Windows.Forms.Button btnChallengeFinished;
        private System.Windows.Forms.Button btnChallengeComplete;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Panel pnlAddChallenge;
        private System.Windows.Forms.Label lblAddCapacity;
        private System.Windows.Forms.Label lblAddStatus;
        private System.Windows.Forms.Label lblAddStartTime;
        private System.Windows.Forms.Label lblAddEvent;
        private System.Windows.Forms.Label lblAddChallengeName;
        private System.Windows.Forms.Button btnSaveAddChallenge;
        private System.Windows.Forms.NumericUpDown numAddCapacity;
        private System.Windows.Forms.ComboBox comAddEventStatus;
        private System.Windows.Forms.ComboBox comAddEventName;
        private System.Windows.Forms.ComboBox comAddEventID;
        private System.Windows.Forms.TextBox txtAddChallengeName;
        private System.Windows.Forms.Button btnAddCancel;
        private System.Windows.Forms.Panel pnlUpdateChallenge;
        private System.Windows.Forms.Button btnCancelUpdate;
        private System.Windows.Forms.Button btnSaveUpdateChallenge;
        private System.Windows.Forms.ComboBox comUpdateStatus;
        private System.Windows.Forms.TextBox txtUpdateChallengeName;
        private System.Windows.Forms.Label lblUpdateCapacity;
        private System.Windows.Forms.Label lblUpdateStatus;
        private System.Windows.Forms.Label lblUpdateStartTime;
        private System.Windows.Forms.Label lblUpdateEvent;
        private System.Windows.Forms.Label lblUpdateChallengeName;
        private System.Windows.Forms.Label lblUpdateChallengeID;
        private System.Windows.Forms.TextBox txtUpdateEventName;
        private System.Windows.Forms.TextBox txtUpdateChallengeID;
        private System.Windows.Forms.DateTimePicker datStartTime;
        private System.Windows.Forms.DateTimePicker datAddStartTime;
        private System.Windows.Forms.DateTimePicker datUpdateStartTime;
        private System.Windows.Forms.NumericUpDown numUpdateCapacity;
    }
}