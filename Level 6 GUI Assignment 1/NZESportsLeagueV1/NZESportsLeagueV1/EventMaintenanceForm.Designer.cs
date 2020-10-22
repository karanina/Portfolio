namespace NZESportsLeagueV1
{
    partial class EventMaintenanceForm
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
            this.lstEventName = new System.Windows.Forms.ListBox();
            this.lblEventID = new System.Windows.Forms.Label();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblEventArenaID = new System.Windows.Forms.Label();
            this.lblEventArenaName = new System.Windows.Forms.Label();
            this.lblEventStatus = new System.Windows.Forms.Label();
            this.lblEventCapacity = new System.Windows.Forms.Label();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.txtEventID = new System.Windows.Forms.TextBox();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.txtEventArenaID = new System.Windows.Forms.TextBox();
            this.txtEventArenaName = new System.Windows.Forms.TextBox();
            this.txtEventStatus = new System.Windows.Forms.TextBox();
            this.txtEventCapacity = new System.Windows.Forms.TextBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnUpdateEvent = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pnlAddEvent = new System.Windows.Forms.Panel();
            this.btnCancelAddEvent = new System.Windows.Forms.Button();
            this.btnSaveAddEvent = new System.Windows.Forms.Button();
            this.datAddEventDate = new System.Windows.Forms.DateTimePicker();
            this.numAddEventCapacity = new System.Windows.Forms.NumericUpDown();
            this.comAddEventStatus = new System.Windows.Forms.ComboBox();
            this.comAddEventArenaName = new System.Windows.Forms.ComboBox();
            this.comAddEventArenaID = new System.Windows.Forms.ComboBox();
            this.txtAddEventName = new System.Windows.Forms.TextBox();
            this.lblAddEventDate = new System.Windows.Forms.Label();
            this.lblAddEventCapacity = new System.Windows.Forms.Label();
            this.lblAddEventStatus = new System.Windows.Forms.Label();
            this.lblAddEventArena = new System.Windows.Forms.Label();
            this.lblAddEventName = new System.Windows.Forms.Label();
            this.pnlUpdateEvent = new System.Windows.Forms.Panel();
            this.lblUpdateEventArenaName = new System.Windows.Forms.Label();
            this.txtUpdateEventArenaName = new System.Windows.Forms.TextBox();
            this.txtUpdateEventArenaID = new System.Windows.Forms.TextBox();
            this.txtUpdateEventID = new System.Windows.Forms.TextBox();
            this.lblUpdateEventID = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.datUpdateEventDate = new System.Windows.Forms.DateTimePicker();
            this.numUpdateEventCapacity = new System.Windows.Forms.NumericUpDown();
            this.comUpdateEventStatus = new System.Windows.Forms.ComboBox();
            this.txtUpdateEventName = new System.Windows.Forms.TextBox();
            this.lblUpdateEventDate = new System.Windows.Forms.Label();
            this.lblUpdateEventCapacity = new System.Windows.Forms.Label();
            this.lblUpdateEventStatus = new System.Windows.Forms.Label();
            this.lblUpdateEventArenaID = new System.Windows.Forms.Label();
            this.lblUpdateEventName = new System.Windows.Forms.Label();
            this.datEventDate = new System.Windows.Forms.DateTimePicker();
            this.pnlAddEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAddEventCapacity)).BeginInit();
            this.pnlUpdateEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateEventCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lstEventName
            // 
            this.lstEventName.FormattingEnabled = true;
            this.lstEventName.Location = new System.Drawing.Point(29, 31);
            this.lstEventName.Name = "lstEventName";
            this.lstEventName.Size = new System.Drawing.Size(156, 251);
            this.lstEventName.TabIndex = 0;
            this.lstEventName.SelectedIndexChanged += new System.EventHandler(this.lstEventName_SelectedIndexChanged);
            // 
            // lblEventID
            // 
            this.lblEventID.AutoSize = true;
            this.lblEventID.Location = new System.Drawing.Point(225, 31);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(52, 13);
            this.lblEventID.TabIndex = 1;
            this.lblEventID.Text = "Event ID:";
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Location = new System.Drawing.Point(208, 71);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(69, 13);
            this.lblEventName.TabIndex = 2;
            this.lblEventName.Text = "Event Name:";
            // 
            // lblEventArenaID
            // 
            this.lblEventArenaID.AutoSize = true;
            this.lblEventArenaID.Location = new System.Drawing.Point(225, 111);
            this.lblEventArenaID.Name = "lblEventArenaID";
            this.lblEventArenaID.Size = new System.Drawing.Size(52, 13);
            this.lblEventArenaID.TabIndex = 3;
            this.lblEventArenaID.Text = "Arena ID:";
            // 
            // lblEventArenaName
            // 
            this.lblEventArenaName.AutoSize = true;
            this.lblEventArenaName.Location = new System.Drawing.Point(208, 152);
            this.lblEventArenaName.Name = "lblEventArenaName";
            this.lblEventArenaName.Size = new System.Drawing.Size(69, 13);
            this.lblEventArenaName.TabIndex = 4;
            this.lblEventArenaName.Text = "Arena Name:";
            // 
            // lblEventStatus
            // 
            this.lblEventStatus.AutoSize = true;
            this.lblEventStatus.Location = new System.Drawing.Point(237, 193);
            this.lblEventStatus.Name = "lblEventStatus";
            this.lblEventStatus.Size = new System.Drawing.Size(40, 13);
            this.lblEventStatus.TabIndex = 5;
            this.lblEventStatus.Text = "Status:";
            // 
            // lblEventCapacity
            // 
            this.lblEventCapacity.AutoSize = true;
            this.lblEventCapacity.Location = new System.Drawing.Point(226, 230);
            this.lblEventCapacity.Name = "lblEventCapacity";
            this.lblEventCapacity.Size = new System.Drawing.Size(51, 13);
            this.lblEventCapacity.TabIndex = 6;
            this.lblEventCapacity.Text = "Capacity:";
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.Location = new System.Drawing.Point(213, 269);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Size = new System.Drawing.Size(64, 13);
            this.lblEventDate.TabIndex = 7;
            this.lblEventDate.Text = "Event Date:";
            // 
            // txtEventID
            // 
            this.txtEventID.Location = new System.Drawing.Point(283, 28);
            this.txtEventID.Name = "txtEventID";
            this.txtEventID.ReadOnly = true;
            this.txtEventID.Size = new System.Drawing.Size(48, 20);
            this.txtEventID.TabIndex = 8;
            // 
            // txtEventName
            // 
            this.txtEventName.Location = new System.Drawing.Point(283, 68);
            this.txtEventName.MaxLength = 40;
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.ReadOnly = true;
            this.txtEventName.Size = new System.Drawing.Size(225, 20);
            this.txtEventName.TabIndex = 9;
            // 
            // txtEventArenaID
            // 
            this.txtEventArenaID.Location = new System.Drawing.Point(283, 108);
            this.txtEventArenaID.Name = "txtEventArenaID";
            this.txtEventArenaID.ReadOnly = true;
            this.txtEventArenaID.Size = new System.Drawing.Size(48, 20);
            this.txtEventArenaID.TabIndex = 10;
            // 
            // txtEventArenaName
            // 
            this.txtEventArenaName.Location = new System.Drawing.Point(283, 149);
            this.txtEventArenaName.Name = "txtEventArenaName";
            this.txtEventArenaName.ReadOnly = true;
            this.txtEventArenaName.Size = new System.Drawing.Size(225, 20);
            this.txtEventArenaName.TabIndex = 11;
            // 
            // txtEventStatus
            // 
            this.txtEventStatus.Location = new System.Drawing.Point(283, 190);
            this.txtEventStatus.MaxLength = 11;
            this.txtEventStatus.Name = "txtEventStatus";
            this.txtEventStatus.ReadOnly = true;
            this.txtEventStatus.Size = new System.Drawing.Size(128, 20);
            this.txtEventStatus.TabIndex = 12;
            // 
            // txtEventCapacity
            // 
            this.txtEventCapacity.Location = new System.Drawing.Point(283, 227);
            this.txtEventCapacity.MaxLength = 5000;
            this.txtEventCapacity.Name = "txtEventCapacity";
            this.txtEventCapacity.ReadOnly = true;
            this.txtEventCapacity.Size = new System.Drawing.Size(100, 20);
            this.txtEventCapacity.TabIndex = 13;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(29, 307);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(91, 23);
            this.btnPrevious.TabIndex = 15;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(149, 307);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(91, 23);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(271, 307);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(91, 23);
            this.btnAddEvent.TabIndex = 17;
            this.btnAddEvent.Text = "Add Event";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnUpdateEvent
            // 
            this.btnUpdateEvent.Location = new System.Drawing.Point(394, 307);
            this.btnUpdateEvent.Name = "btnUpdateEvent";
            this.btnUpdateEvent.Size = new System.Drawing.Size(91, 23);
            this.btnUpdateEvent.TabIndex = 18;
            this.btnUpdateEvent.Text = "Update Event";
            this.btnUpdateEvent.UseVisualStyleBackColor = true;
            this.btnUpdateEvent.Click += new System.EventHandler(this.btnUpdateEvent_Click);
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Location = new System.Drawing.Point(515, 307);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(91, 23);
            this.btnDeleteEvent.TabIndex = 19;
            this.btnDeleteEvent.Text = "Delete Event";
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(515, 352);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(91, 23);
            this.btnReturn.TabIndex = 20;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pnlAddEvent
            // 
            this.pnlAddEvent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddEvent.Controls.Add(this.btnCancelAddEvent);
            this.pnlAddEvent.Controls.Add(this.btnSaveAddEvent);
            this.pnlAddEvent.Controls.Add(this.datAddEventDate);
            this.pnlAddEvent.Controls.Add(this.numAddEventCapacity);
            this.pnlAddEvent.Controls.Add(this.comAddEventStatus);
            this.pnlAddEvent.Controls.Add(this.comAddEventArenaName);
            this.pnlAddEvent.Controls.Add(this.comAddEventArenaID);
            this.pnlAddEvent.Controls.Add(this.txtAddEventName);
            this.pnlAddEvent.Controls.Add(this.lblAddEventDate);
            this.pnlAddEvent.Controls.Add(this.lblAddEventCapacity);
            this.pnlAddEvent.Controls.Add(this.lblAddEventStatus);
            this.pnlAddEvent.Controls.Add(this.lblAddEventArena);
            this.pnlAddEvent.Controls.Add(this.lblAddEventName);
            this.pnlAddEvent.Location = new System.Drawing.Point(211, 28);
            this.pnlAddEvent.Name = "pnlAddEvent";
            this.pnlAddEvent.Size = new System.Drawing.Size(352, 258);
            this.pnlAddEvent.TabIndex = 21;
            this.pnlAddEvent.Visible = false;
            // 
            // btnCancelAddEvent
            // 
            this.btnCancelAddEvent.Location = new System.Drawing.Point(238, 214);
            this.btnCancelAddEvent.Name = "btnCancelAddEvent";
            this.btnCancelAddEvent.Size = new System.Drawing.Size(91, 23);
            this.btnCancelAddEvent.TabIndex = 12;
            this.btnCancelAddEvent.Text = "Cancel";
            this.btnCancelAddEvent.UseVisualStyleBackColor = true;
            this.btnCancelAddEvent.Click += new System.EventHandler(this.btnCancelAddEvent_Click);
            // 
            // btnSaveAddEvent
            // 
            this.btnSaveAddEvent.Location = new System.Drawing.Point(22, 214);
            this.btnSaveAddEvent.Name = "btnSaveAddEvent";
            this.btnSaveAddEvent.Size = new System.Drawing.Size(91, 23);
            this.btnSaveAddEvent.TabIndex = 11;
            this.btnSaveAddEvent.Text = "Save Meeting";
            this.btnSaveAddEvent.UseVisualStyleBackColor = true;
            this.btnSaveAddEvent.Click += new System.EventHandler(this.btnSaveMeeting_Click);
            // 
            // datAddEventDate
            // 
            this.datAddEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datAddEventDate.Location = new System.Drawing.Point(119, 171);
            this.datAddEventDate.Name = "datAddEventDate";
            this.datAddEventDate.Size = new System.Drawing.Size(130, 20);
            this.datAddEventDate.TabIndex = 10;
            // 
            // numAddEventCapacity
            // 
            this.numAddEventCapacity.Location = new System.Drawing.Point(119, 135);
            this.numAddEventCapacity.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numAddEventCapacity.Name = "numAddEventCapacity";
            this.numAddEventCapacity.Size = new System.Drawing.Size(120, 20);
            this.numAddEventCapacity.TabIndex = 9;
            this.numAddEventCapacity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // comAddEventStatus
            // 
            this.comAddEventStatus.FormattingEnabled = true;
            this.comAddEventStatus.Items.AddRange(new object[] {
            "Confirmed",
            "Unconfirmed",
            "Cancelled"});
            this.comAddEventStatus.Location = new System.Drawing.Point(119, 98);
            this.comAddEventStatus.MaxLength = 11;
            this.comAddEventStatus.Name = "comAddEventStatus";
            this.comAddEventStatus.Size = new System.Drawing.Size(121, 21);
            this.comAddEventStatus.TabIndex = 8;
            // 
            // comAddEventArenaName
            // 
            this.comAddEventArenaName.FormattingEnabled = true;
            this.comAddEventArenaName.Location = new System.Drawing.Point(184, 57);
            this.comAddEventArenaName.Name = "comAddEventArenaName";
            this.comAddEventArenaName.Size = new System.Drawing.Size(121, 21);
            this.comAddEventArenaName.TabIndex = 7;
            // 
            // comAddEventArenaID
            // 
            this.comAddEventArenaID.FormattingEnabled = true;
            this.comAddEventArenaID.Location = new System.Drawing.Point(119, 57);
            this.comAddEventArenaID.Name = "comAddEventArenaID";
            this.comAddEventArenaID.Size = new System.Drawing.Size(52, 21);
            this.comAddEventArenaID.TabIndex = 6;
            // 
            // txtAddEventName
            // 
            this.txtAddEventName.Location = new System.Drawing.Point(119, 22);
            this.txtAddEventName.MaxLength = 40;
            this.txtAddEventName.Name = "txtAddEventName";
            this.txtAddEventName.Size = new System.Drawing.Size(186, 20);
            this.txtAddEventName.TabIndex = 5;
            // 
            // lblAddEventDate
            // 
            this.lblAddEventDate.AutoSize = true;
            this.lblAddEventDate.Location = new System.Drawing.Point(49, 177);
            this.lblAddEventDate.Name = "lblAddEventDate";
            this.lblAddEventDate.Size = new System.Drawing.Size(64, 13);
            this.lblAddEventDate.TabIndex = 4;
            this.lblAddEventDate.Text = "Event Date:";
            // 
            // lblAddEventCapacity
            // 
            this.lblAddEventCapacity.AutoSize = true;
            this.lblAddEventCapacity.Location = new System.Drawing.Point(62, 137);
            this.lblAddEventCapacity.Name = "lblAddEventCapacity";
            this.lblAddEventCapacity.Size = new System.Drawing.Size(51, 13);
            this.lblAddEventCapacity.TabIndex = 3;
            this.lblAddEventCapacity.Text = "Capacity:";
            // 
            // lblAddEventStatus
            // 
            this.lblAddEventStatus.AutoSize = true;
            this.lblAddEventStatus.Location = new System.Drawing.Point(69, 101);
            this.lblAddEventStatus.Name = "lblAddEventStatus";
            this.lblAddEventStatus.Size = new System.Drawing.Size(40, 13);
            this.lblAddEventStatus.TabIndex = 2;
            this.lblAddEventStatus.Text = "Status:";
            // 
            // lblAddEventArena
            // 
            this.lblAddEventArena.AutoSize = true;
            this.lblAddEventArena.Location = new System.Drawing.Point(71, 60);
            this.lblAddEventArena.Name = "lblAddEventArena";
            this.lblAddEventArena.Size = new System.Drawing.Size(38, 13);
            this.lblAddEventArena.TabIndex = 1;
            this.lblAddEventArena.Text = "Arena:";
            // 
            // lblAddEventName
            // 
            this.lblAddEventName.AutoSize = true;
            this.lblAddEventName.Location = new System.Drawing.Point(40, 25);
            this.lblAddEventName.Name = "lblAddEventName";
            this.lblAddEventName.Size = new System.Drawing.Size(69, 13);
            this.lblAddEventName.TabIndex = 0;
            this.lblAddEventName.Text = "Event Name:";
            // 
            // pnlUpdateEvent
            // 
            this.pnlUpdateEvent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdateEvent.Controls.Add(this.lblUpdateEventArenaName);
            this.pnlUpdateEvent.Controls.Add(this.txtUpdateEventArenaName);
            this.pnlUpdateEvent.Controls.Add(this.txtUpdateEventArenaID);
            this.pnlUpdateEvent.Controls.Add(this.txtUpdateEventID);
            this.pnlUpdateEvent.Controls.Add(this.lblUpdateEventID);
            this.pnlUpdateEvent.Controls.Add(this.btnCancel);
            this.pnlUpdateEvent.Controls.Add(this.btnSaveChanges);
            this.pnlUpdateEvent.Controls.Add(this.datUpdateEventDate);
            this.pnlUpdateEvent.Controls.Add(this.numUpdateEventCapacity);
            this.pnlUpdateEvent.Controls.Add(this.comUpdateEventStatus);
            this.pnlUpdateEvent.Controls.Add(this.txtUpdateEventName);
            this.pnlUpdateEvent.Controls.Add(this.lblUpdateEventDate);
            this.pnlUpdateEvent.Controls.Add(this.lblUpdateEventCapacity);
            this.pnlUpdateEvent.Controls.Add(this.lblUpdateEventStatus);
            this.pnlUpdateEvent.Controls.Add(this.lblUpdateEventArenaID);
            this.pnlUpdateEvent.Controls.Add(this.lblUpdateEventName);
            this.pnlUpdateEvent.Location = new System.Drawing.Point(211, 13);
            this.pnlUpdateEvent.Name = "pnlUpdateEvent";
            this.pnlUpdateEvent.Size = new System.Drawing.Size(395, 288);
            this.pnlUpdateEvent.TabIndex = 22;
            this.pnlUpdateEvent.Visible = false;
            // 
            // lblUpdateEventArenaName
            // 
            this.lblUpdateEventArenaName.AutoSize = true;
            this.lblUpdateEventArenaName.Location = new System.Drawing.Point(44, 119);
            this.lblUpdateEventArenaName.Name = "lblUpdateEventArenaName";
            this.lblUpdateEventArenaName.Size = new System.Drawing.Size(69, 13);
            this.lblUpdateEventArenaName.TabIndex = 17;
            this.lblUpdateEventArenaName.Text = "Arena Name:";
            // 
            // txtUpdateEventArenaName
            // 
            this.txtUpdateEventArenaName.Location = new System.Drawing.Point(119, 114);
            this.txtUpdateEventArenaName.Name = "txtUpdateEventArenaName";
            this.txtUpdateEventArenaName.ReadOnly = true;
            this.txtUpdateEventArenaName.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateEventArenaName.TabIndex = 16;
            // 
            // txtUpdateEventArenaID
            // 
            this.txtUpdateEventArenaID.Location = new System.Drawing.Point(119, 81);
            this.txtUpdateEventArenaID.Name = "txtUpdateEventArenaID";
            this.txtUpdateEventArenaID.ReadOnly = true;
            this.txtUpdateEventArenaID.Size = new System.Drawing.Size(52, 20);
            this.txtUpdateEventArenaID.TabIndex = 15;
            // 
            // txtUpdateEventID
            // 
            this.txtUpdateEventID.Location = new System.Drawing.Point(119, 17);
            this.txtUpdateEventID.Name = "txtUpdateEventID";
            this.txtUpdateEventID.ReadOnly = true;
            this.txtUpdateEventID.Size = new System.Drawing.Size(52, 20);
            this.txtUpdateEventID.TabIndex = 14;
            // 
            // lblUpdateEventID
            // 
            this.lblUpdateEventID.AutoSize = true;
            this.lblUpdateEventID.Location = new System.Drawing.Point(61, 20);
            this.lblUpdateEventID.Name = "lblUpdateEventID";
            this.lblUpdateEventID.Size = new System.Drawing.Size(52, 13);
            this.lblUpdateEventID.TabIndex = 13;
            this.lblUpdateEventID.Text = "Event ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(284, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancelUpdateEvent_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(17, 248);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(91, 23);
            this.btnSaveChanges.TabIndex = 11;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // datUpdateEventDate
            // 
            this.datUpdateEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datUpdateEventDate.Location = new System.Drawing.Point(119, 214);
            this.datUpdateEventDate.Name = "datUpdateEventDate";
            this.datUpdateEventDate.Size = new System.Drawing.Size(130, 20);
            this.datUpdateEventDate.TabIndex = 10;
            // 
            // numUpdateEventCapacity
            // 
            this.numUpdateEventCapacity.Location = new System.Drawing.Point(119, 182);
            this.numUpdateEventCapacity.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numUpdateEventCapacity.Name = "numUpdateEventCapacity";
            this.numUpdateEventCapacity.Size = new System.Drawing.Size(120, 20);
            this.numUpdateEventCapacity.TabIndex = 9;
            this.numUpdateEventCapacity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // comUpdateEventStatus
            // 
            this.comUpdateEventStatus.FormattingEnabled = true;
            this.comUpdateEventStatus.Items.AddRange(new object[] {
            "Confirmed",
            "Unconfirmed",
            "Cancelled"});
            this.comUpdateEventStatus.Location = new System.Drawing.Point(119, 148);
            this.comUpdateEventStatus.MaxLength = 11;
            this.comUpdateEventStatus.Name = "comUpdateEventStatus";
            this.comUpdateEventStatus.Size = new System.Drawing.Size(121, 21);
            this.comUpdateEventStatus.TabIndex = 8;
            // 
            // txtUpdateEventName
            // 
            this.txtUpdateEventName.Location = new System.Drawing.Point(119, 49);
            this.txtUpdateEventName.MaxLength = 40;
            this.txtUpdateEventName.Name = "txtUpdateEventName";
            this.txtUpdateEventName.Size = new System.Drawing.Size(256, 20);
            this.txtUpdateEventName.TabIndex = 5;
            // 
            // lblUpdateEventDate
            // 
            this.lblUpdateEventDate.AutoSize = true;
            this.lblUpdateEventDate.Location = new System.Drawing.Point(49, 219);
            this.lblUpdateEventDate.Name = "lblUpdateEventDate";
            this.lblUpdateEventDate.Size = new System.Drawing.Size(64, 13);
            this.lblUpdateEventDate.TabIndex = 4;
            this.lblUpdateEventDate.Text = "Event Date:";
            // 
            // lblUpdateEventCapacity
            // 
            this.lblUpdateEventCapacity.AutoSize = true;
            this.lblUpdateEventCapacity.Location = new System.Drawing.Point(62, 184);
            this.lblUpdateEventCapacity.Name = "lblUpdateEventCapacity";
            this.lblUpdateEventCapacity.Size = new System.Drawing.Size(51, 13);
            this.lblUpdateEventCapacity.TabIndex = 3;
            this.lblUpdateEventCapacity.Text = "Capacity:";
            // 
            // lblUpdateEventStatus
            // 
            this.lblUpdateEventStatus.AutoSize = true;
            this.lblUpdateEventStatus.Location = new System.Drawing.Point(73, 152);
            this.lblUpdateEventStatus.Name = "lblUpdateEventStatus";
            this.lblUpdateEventStatus.Size = new System.Drawing.Size(40, 13);
            this.lblUpdateEventStatus.TabIndex = 2;
            this.lblUpdateEventStatus.Text = "Status:";
            // 
            // lblUpdateEventArenaID
            // 
            this.lblUpdateEventArenaID.AutoSize = true;
            this.lblUpdateEventArenaID.Location = new System.Drawing.Point(61, 84);
            this.lblUpdateEventArenaID.Name = "lblUpdateEventArenaID";
            this.lblUpdateEventArenaID.Size = new System.Drawing.Size(52, 13);
            this.lblUpdateEventArenaID.TabIndex = 1;
            this.lblUpdateEventArenaID.Text = "Arena ID:";
            // 
            // lblUpdateEventName
            // 
            this.lblUpdateEventName.AutoSize = true;
            this.lblUpdateEventName.Location = new System.Drawing.Point(44, 52);
            this.lblUpdateEventName.Name = "lblUpdateEventName";
            this.lblUpdateEventName.Size = new System.Drawing.Size(69, 13);
            this.lblUpdateEventName.TabIndex = 0;
            this.lblUpdateEventName.Text = "Event Name:";
            // 
            // datEventDate
            // 
            this.datEventDate.Enabled = false;
            this.datEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datEventDate.Location = new System.Drawing.Point(283, 263);
            this.datEventDate.Name = "datEventDate";
            this.datEventDate.Size = new System.Drawing.Size(128, 20);
            this.datEventDate.TabIndex = 23;
            // 
            // EventMaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 401);
            this.Controls.Add(this.pnlUpdateEvent);
            this.Controls.Add(this.pnlAddEvent);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnDeleteEvent);
            this.Controls.Add(this.btnUpdateEvent);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.txtEventCapacity);
            this.Controls.Add(this.txtEventStatus);
            this.Controls.Add(this.txtEventArenaName);
            this.Controls.Add(this.txtEventArenaID);
            this.Controls.Add(this.txtEventName);
            this.Controls.Add(this.txtEventID);
            this.Controls.Add(this.lblEventDate);
            this.Controls.Add(this.lblEventCapacity);
            this.Controls.Add(this.lblEventStatus);
            this.Controls.Add(this.lblEventArenaName);
            this.Controls.Add(this.lblEventArenaID);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.lblEventID);
            this.Controls.Add(this.lstEventName);
            this.Controls.Add(this.datEventDate);
            this.Name = "EventMaintenanceForm";
            this.Text = "Event Maintenance";
            this.pnlAddEvent.ResumeLayout(false);
            this.pnlAddEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAddEventCapacity)).EndInit();
            this.pnlUpdateEvent.ResumeLayout(false);
            this.pnlUpdateEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateEventCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstEventName;
        private System.Windows.Forms.Label lblEventID;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label lblEventArenaID;
        private System.Windows.Forms.Label lblEventArenaName;
        private System.Windows.Forms.Label lblEventStatus;
        private System.Windows.Forms.Label lblEventCapacity;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.TextBox txtEventID;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.TextBox txtEventArenaID;
        private System.Windows.Forms.TextBox txtEventArenaName;
        private System.Windows.Forms.TextBox txtEventStatus;
        private System.Windows.Forms.TextBox txtEventCapacity;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnUpdateEvent;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Panel pnlAddEvent;
        private System.Windows.Forms.Label lblAddEventDate;
        private System.Windows.Forms.Label lblAddEventCapacity;
        private System.Windows.Forms.Label lblAddEventStatus;
        private System.Windows.Forms.Label lblAddEventArena;
        private System.Windows.Forms.Label lblAddEventName;
        private System.Windows.Forms.ComboBox comAddEventStatus;
        private System.Windows.Forms.ComboBox comAddEventArenaName;
        private System.Windows.Forms.ComboBox comAddEventArenaID;
        private System.Windows.Forms.TextBox txtAddEventName;
        private System.Windows.Forms.Button btnCancelAddEvent;
        private System.Windows.Forms.Button btnSaveAddEvent;
        private System.Windows.Forms.DateTimePicker datAddEventDate;
        private System.Windows.Forms.NumericUpDown numAddEventCapacity;
        private System.Windows.Forms.Panel pnlUpdateEvent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.DateTimePicker datUpdateEventDate;
        private System.Windows.Forms.NumericUpDown numUpdateEventCapacity;
        private System.Windows.Forms.ComboBox comUpdateEventStatus;
        private System.Windows.Forms.TextBox txtUpdateEventName;
        private System.Windows.Forms.Label lblUpdateEventDate;
        private System.Windows.Forms.Label lblUpdateEventCapacity;
        private System.Windows.Forms.Label lblUpdateEventStatus;
        private System.Windows.Forms.Label lblUpdateEventArenaID;
        private System.Windows.Forms.Label lblUpdateEventName;
        private System.Windows.Forms.TextBox txtUpdateEventID;
        private System.Windows.Forms.Label lblUpdateEventID;
        private System.Windows.Forms.Label lblUpdateEventArenaName;
        private System.Windows.Forms.TextBox txtUpdateEventArenaName;
        private System.Windows.Forms.TextBox txtUpdateEventArenaID;
        private System.Windows.Forms.DateTimePicker datEventDate;
    }
}