namespace NZESportsLeagueV1
{
    partial class CompetitorMaintenanceForm
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
            this.lstUserName = new System.Windows.Forms.ListBox();
            this.lblCompetitorID = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtCompetitorID = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAddCompetitor = new System.Windows.Forms.Button();
            this.btnUpdateCompetitor = new System.Windows.Forms.Button();
            this.btnDeleteCompetitor = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pnlAddCompetitor = new System.Windows.Forms.Panel();
            this.pnlUpdateCompetitor = new System.Windows.Forms.Panel();
            this.datUpdateDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.btnCancelUpdateCompetitor = new System.Windows.Forms.Button();
            this.btnSaveUpdateCompetitor = new System.Windows.Forms.Button();
            this.txtUpdateEmail = new System.Windows.Forms.TextBox();
            this.txtUpdateLastName = new System.Windows.Forms.TextBox();
            this.txtUpdateFirstName = new System.Windows.Forms.TextBox();
            this.txtUpdateUserName = new System.Windows.Forms.TextBox();
            this.lblUpdateEmail = new System.Windows.Forms.Label();
            this.lblUpdateDateOfBirth = new System.Windows.Forms.Label();
            this.lblUpdateGender = new System.Windows.Forms.Label();
            this.lblUpdateLastName = new System.Windows.Forms.Label();
            this.lblUpdateFirstName = new System.Windows.Forms.Label();
            this.lblUpdateUserName = new System.Windows.Forms.Label();
            this.datAddDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.btnCancelAddCompetitor = new System.Windows.Forms.Button();
            this.btnSaveAddCompetitor = new System.Windows.Forms.Button();
            this.txtAddEmail = new System.Windows.Forms.TextBox();
            this.txtAddLastName = new System.Windows.Forms.TextBox();
            this.txtAddFirstName = new System.Windows.Forms.TextBox();
            this.txtAddUserName = new System.Windows.Forms.TextBox();
            this.lblAddEmail = new System.Windows.Forms.Label();
            this.lblAddDateOfBirth = new System.Windows.Forms.Label();
            this.lblAddGender = new System.Windows.Forms.Label();
            this.lblAddLastName = new System.Windows.Forms.Label();
            this.lblAddFirstName = new System.Windows.Forms.Label();
            this.lblAddUserName = new System.Windows.Forms.Label();
            this.datDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.comAddGender = new System.Windows.Forms.ComboBox();
            this.comUpdateGender = new System.Windows.Forms.ComboBox();
            this.pnlAddCompetitor.SuspendLayout();
            this.pnlUpdateCompetitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUserName
            // 
            this.lstUserName.FormattingEnabled = true;
            this.lstUserName.Location = new System.Drawing.Point(24, 27);
            this.lstUserName.Name = "lstUserName";
            this.lstUserName.Size = new System.Drawing.Size(174, 238);
            this.lstUserName.TabIndex = 0;
            // 
            // lblCompetitorID
            // 
            this.lblCompetitorID.AutoSize = true;
            this.lblCompetitorID.Location = new System.Drawing.Point(241, 27);
            this.lblCompetitorID.Name = "lblCompetitorID";
            this.lblCompetitorID.Size = new System.Drawing.Size(74, 13);
            this.lblCompetitorID.TabIndex = 1;
            this.lblCompetitorID.Text = "Competitor ID:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(257, 64);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "UserName:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(255, 101);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(254, 138);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(270, 175);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "Gender:";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(246, 212);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(69, 13);
            this.lblDateOfBirth.TabIndex = 6;
            this.lblDateOfBirth.Text = "Date of Birth:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(280, 248);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email:";
            // 
            // txtCompetitorID
            // 
            this.txtCompetitorID.Location = new System.Drawing.Point(321, 24);
            this.txtCompetitorID.Name = "txtCompetitorID";
            this.txtCompetitorID.ReadOnly = true;
            this.txtCompetitorID.Size = new System.Drawing.Size(75, 20);
            this.txtCompetitorID.TabIndex = 8;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(321, 61);
            this.txtUserName.MaxLength = 30;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(169, 20);
            this.txtUserName.TabIndex = 9;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(321, 98);
            this.txtFirstName.MaxLength = 255;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(169, 20);
            this.txtFirstName.TabIndex = 10;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(321, 135);
            this.txtLastName.MaxLength = 255;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(169, 20);
            this.txtLastName.TabIndex = 11;
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(321, 172);
            this.txtGender.MaxLength = 7;
            this.txtGender.Name = "txtGender";
            this.txtGender.ReadOnly = true;
            this.txtGender.Size = new System.Drawing.Size(100, 20);
            this.txtGender.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(321, 245);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(247, 20);
            this.txtEmail.TabIndex = 14;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(24, 292);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(112, 23);
            this.btnPrevious.TabIndex = 15;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(142, 292);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(112, 23);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnAddCompetitor
            // 
            this.btnAddCompetitor.Location = new System.Drawing.Point(260, 292);
            this.btnAddCompetitor.Name = "btnAddCompetitor";
            this.btnAddCompetitor.Size = new System.Drawing.Size(112, 23);
            this.btnAddCompetitor.TabIndex = 17;
            this.btnAddCompetitor.Text = "Add Competitor";
            this.btnAddCompetitor.UseVisualStyleBackColor = true;
            this.btnAddCompetitor.Click += new System.EventHandler(this.btnAddCompetitor_Click);
            // 
            // btnUpdateCompetitor
            // 
            this.btnUpdateCompetitor.Location = new System.Drawing.Point(378, 292);
            this.btnUpdateCompetitor.Name = "btnUpdateCompetitor";
            this.btnUpdateCompetitor.Size = new System.Drawing.Size(112, 23);
            this.btnUpdateCompetitor.TabIndex = 18;
            this.btnUpdateCompetitor.Text = "Update Competitor";
            this.btnUpdateCompetitor.UseVisualStyleBackColor = true;
            this.btnUpdateCompetitor.Click += new System.EventHandler(this.btnUpdateCompetitor_Click);
            // 
            // btnDeleteCompetitor
            // 
            this.btnDeleteCompetitor.Location = new System.Drawing.Point(496, 293);
            this.btnDeleteCompetitor.Name = "btnDeleteCompetitor";
            this.btnDeleteCompetitor.Size = new System.Drawing.Size(112, 23);
            this.btnDeleteCompetitor.TabIndex = 19;
            this.btnDeleteCompetitor.Text = "Delete Competitor";
            this.btnDeleteCompetitor.UseVisualStyleBackColor = true;
            this.btnDeleteCompetitor.Click += new System.EventHandler(this.btnDeleteCompetitor_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(496, 335);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(112, 23);
            this.btnReturn.TabIndex = 20;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pnlAddCompetitor
            // 
            this.pnlAddCompetitor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddCompetitor.Controls.Add(this.comAddGender);
            this.pnlAddCompetitor.Controls.Add(this.datAddDateOfBirth);
            this.pnlAddCompetitor.Controls.Add(this.btnCancelAddCompetitor);
            this.pnlAddCompetitor.Controls.Add(this.btnSaveAddCompetitor);
            this.pnlAddCompetitor.Controls.Add(this.txtAddEmail);
            this.pnlAddCompetitor.Controls.Add(this.txtAddLastName);
            this.pnlAddCompetitor.Controls.Add(this.txtAddFirstName);
            this.pnlAddCompetitor.Controls.Add(this.txtAddUserName);
            this.pnlAddCompetitor.Controls.Add(this.lblAddEmail);
            this.pnlAddCompetitor.Controls.Add(this.lblAddDateOfBirth);
            this.pnlAddCompetitor.Controls.Add(this.lblAddGender);
            this.pnlAddCompetitor.Controls.Add(this.lblAddLastName);
            this.pnlAddCompetitor.Controls.Add(this.lblAddFirstName);
            this.pnlAddCompetitor.Controls.Add(this.lblAddUserName);
            this.pnlAddCompetitor.Location = new System.Drawing.Point(235, 24);
            this.pnlAddCompetitor.Name = "pnlAddCompetitor";
            this.pnlAddCompetitor.Size = new System.Drawing.Size(373, 241);
            this.pnlAddCompetitor.TabIndex = 21;
            this.pnlAddCompetitor.Visible = false;
            // 
            // pnlUpdateCompetitor
            // 
            this.pnlUpdateCompetitor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdateCompetitor.Controls.Add(this.comUpdateGender);
            this.pnlUpdateCompetitor.Controls.Add(this.datUpdateDateOfBirth);
            this.pnlUpdateCompetitor.Controls.Add(this.btnCancelUpdateCompetitor);
            this.pnlUpdateCompetitor.Controls.Add(this.btnSaveUpdateCompetitor);
            this.pnlUpdateCompetitor.Controls.Add(this.txtUpdateEmail);
            this.pnlUpdateCompetitor.Controls.Add(this.txtUpdateLastName);
            this.pnlUpdateCompetitor.Controls.Add(this.txtUpdateFirstName);
            this.pnlUpdateCompetitor.Controls.Add(this.txtUpdateUserName);
            this.pnlUpdateCompetitor.Controls.Add(this.lblUpdateEmail);
            this.pnlUpdateCompetitor.Controls.Add(this.lblUpdateDateOfBirth);
            this.pnlUpdateCompetitor.Controls.Add(this.lblUpdateGender);
            this.pnlUpdateCompetitor.Controls.Add(this.lblUpdateLastName);
            this.pnlUpdateCompetitor.Controls.Add(this.lblUpdateFirstName);
            this.pnlUpdateCompetitor.Controls.Add(this.lblUpdateUserName);
            this.pnlUpdateCompetitor.Location = new System.Drawing.Point(235, 24);
            this.pnlUpdateCompetitor.Name = "pnlUpdateCompetitor";
            this.pnlUpdateCompetitor.Size = new System.Drawing.Size(373, 241);
            this.pnlUpdateCompetitor.TabIndex = 22;
            this.pnlUpdateCompetitor.Visible = false;
            // 
            // datUpdateDateOfBirth
            // 
            this.datUpdateDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datUpdateDateOfBirth.Location = new System.Drawing.Point(111, 139);
            this.datUpdateDateOfBirth.Name = "datUpdateDateOfBirth";
            this.datUpdateDateOfBirth.Size = new System.Drawing.Size(90, 20);
            this.datUpdateDateOfBirth.TabIndex = 16;
            this.datUpdateDateOfBirth.Value = new System.DateTime(2020, 8, 18, 21, 30, 13, 0);
            // 
            // btnCancelUpdateCompetitor
            // 
            this.btnCancelUpdateCompetitor.Location = new System.Drawing.Point(240, 201);
            this.btnCancelUpdateCompetitor.Name = "btnCancelUpdateCompetitor";
            this.btnCancelUpdateCompetitor.Size = new System.Drawing.Size(112, 23);
            this.btnCancelUpdateCompetitor.TabIndex = 15;
            this.btnCancelUpdateCompetitor.Text = "Cancel";
            this.btnCancelUpdateCompetitor.UseVisualStyleBackColor = true;
            this.btnCancelUpdateCompetitor.Click += new System.EventHandler(this.btnCancelUpdateCompetitor_Click);
            // 
            // btnSaveUpdateCompetitor
            // 
            this.btnSaveUpdateCompetitor.Location = new System.Drawing.Point(17, 201);
            this.btnSaveUpdateCompetitor.Name = "btnSaveUpdateCompetitor";
            this.btnSaveUpdateCompetitor.Size = new System.Drawing.Size(112, 23);
            this.btnSaveUpdateCompetitor.TabIndex = 14;
            this.btnSaveUpdateCompetitor.Text = "Save Changes";
            this.btnSaveUpdateCompetitor.UseVisualStyleBackColor = true;
            this.btnSaveUpdateCompetitor.Click += new System.EventHandler(this.btnSaveUpdateCompetitor_Click);
            // 
            // txtUpdateEmail
            // 
            this.txtUpdateEmail.Location = new System.Drawing.Point(111, 170);
            this.txtUpdateEmail.Name = "txtUpdateEmail";
            this.txtUpdateEmail.Size = new System.Drawing.Size(221, 20);
            this.txtUpdateEmail.TabIndex = 9;
            // 
            // txtUpdateLastName
            // 
            this.txtUpdateLastName.Location = new System.Drawing.Point(111, 79);
            this.txtUpdateLastName.MaxLength = 255;
            this.txtUpdateLastName.Name = "txtUpdateLastName";
            this.txtUpdateLastName.Size = new System.Drawing.Size(171, 20);
            this.txtUpdateLastName.TabIndex = 8;
            // 
            // txtUpdateFirstName
            // 
            this.txtUpdateFirstName.Location = new System.Drawing.Point(111, 48);
            this.txtUpdateFirstName.MaxLength = 255;
            this.txtUpdateFirstName.Name = "txtUpdateFirstName";
            this.txtUpdateFirstName.Size = new System.Drawing.Size(171, 20);
            this.txtUpdateFirstName.TabIndex = 7;
            // 
            // txtUpdateUserName
            // 
            this.txtUpdateUserName.Location = new System.Drawing.Point(111, 16);
            this.txtUpdateUserName.MaxLength = 30;
            this.txtUpdateUserName.Name = "txtUpdateUserName";
            this.txtUpdateUserName.Size = new System.Drawing.Size(171, 20);
            this.txtUpdateUserName.TabIndex = 6;
            // 
            // lblUpdateEmail
            // 
            this.lblUpdateEmail.AutoSize = true;
            this.lblUpdateEmail.Location = new System.Drawing.Point(70, 173);
            this.lblUpdateEmail.Name = "lblUpdateEmail";
            this.lblUpdateEmail.Size = new System.Drawing.Size(35, 13);
            this.lblUpdateEmail.TabIndex = 5;
            this.lblUpdateEmail.Text = "Email:";
            // 
            // lblUpdateDateOfBirth
            // 
            this.lblUpdateDateOfBirth.AutoSize = true;
            this.lblUpdateDateOfBirth.Location = new System.Drawing.Point(34, 142);
            this.lblUpdateDateOfBirth.Name = "lblUpdateDateOfBirth";
            this.lblUpdateDateOfBirth.Size = new System.Drawing.Size(71, 13);
            this.lblUpdateDateOfBirth.TabIndex = 4;
            this.lblUpdateDateOfBirth.Text = "Date Of Birth:";
            // 
            // lblUpdateGender
            // 
            this.lblUpdateGender.AutoSize = true;
            this.lblUpdateGender.Location = new System.Drawing.Point(60, 110);
            this.lblUpdateGender.Name = "lblUpdateGender";
            this.lblUpdateGender.Size = new System.Drawing.Size(45, 13);
            this.lblUpdateGender.TabIndex = 3;
            this.lblUpdateGender.Text = "Gender:";
            // 
            // lblUpdateLastName
            // 
            this.lblUpdateLastName.AutoSize = true;
            this.lblUpdateLastName.Location = new System.Drawing.Point(45, 80);
            this.lblUpdateLastName.Name = "lblUpdateLastName";
            this.lblUpdateLastName.Size = new System.Drawing.Size(61, 13);
            this.lblUpdateLastName.TabIndex = 2;
            this.lblUpdateLastName.Text = "Last Name:";
            // 
            // lblUpdateFirstName
            // 
            this.lblUpdateFirstName.AutoSize = true;
            this.lblUpdateFirstName.Location = new System.Drawing.Point(45, 51);
            this.lblUpdateFirstName.Name = "lblUpdateFirstName";
            this.lblUpdateFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblUpdateFirstName.TabIndex = 1;
            this.lblUpdateFirstName.Text = "First Name:";
            // 
            // lblUpdateUserName
            // 
            this.lblUpdateUserName.AutoSize = true;
            this.lblUpdateUserName.Location = new System.Drawing.Point(47, 19);
            this.lblUpdateUserName.Name = "lblUpdateUserName";
            this.lblUpdateUserName.Size = new System.Drawing.Size(58, 13);
            this.lblUpdateUserName.TabIndex = 0;
            this.lblUpdateUserName.Text = "Username:";
            // 
            // datAddDateOfBirth
            // 
            this.datAddDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datAddDateOfBirth.Location = new System.Drawing.Point(111, 139);
            this.datAddDateOfBirth.Name = "datAddDateOfBirth";
            this.datAddDateOfBirth.Size = new System.Drawing.Size(90, 20);
            this.datAddDateOfBirth.TabIndex = 23;
            // 
            // btnCancelAddCompetitor
            // 
            this.btnCancelAddCompetitor.Location = new System.Drawing.Point(240, 201);
            this.btnCancelAddCompetitor.Name = "btnCancelAddCompetitor";
            this.btnCancelAddCompetitor.Size = new System.Drawing.Size(112, 23);
            this.btnCancelAddCompetitor.TabIndex = 15;
            this.btnCancelAddCompetitor.Text = "Cancel";
            this.btnCancelAddCompetitor.UseVisualStyleBackColor = true;
            this.btnCancelAddCompetitor.Click += new System.EventHandler(this.btnCancelAddCompetitor_Click);
            // 
            // btnSaveAddCompetitor
            // 
            this.btnSaveAddCompetitor.Location = new System.Drawing.Point(17, 201);
            this.btnSaveAddCompetitor.Name = "btnSaveAddCompetitor";
            this.btnSaveAddCompetitor.Size = new System.Drawing.Size(112, 23);
            this.btnSaveAddCompetitor.TabIndex = 14;
            this.btnSaveAddCompetitor.Text = "Save Competitor";
            this.btnSaveAddCompetitor.UseVisualStyleBackColor = true;
            this.btnSaveAddCompetitor.Click += new System.EventHandler(this.btnSaveAddCompetitor_Click);
            // 
            // txtAddEmail
            // 
            this.txtAddEmail.Location = new System.Drawing.Point(111, 170);
            this.txtAddEmail.Name = "txtAddEmail";
            this.txtAddEmail.Size = new System.Drawing.Size(221, 20);
            this.txtAddEmail.TabIndex = 9;
            // 
            // txtAddLastName
            // 
            this.txtAddLastName.Location = new System.Drawing.Point(111, 79);
            this.txtAddLastName.MaxLength = 255;
            this.txtAddLastName.Name = "txtAddLastName";
            this.txtAddLastName.Size = new System.Drawing.Size(171, 20);
            this.txtAddLastName.TabIndex = 8;
            // 
            // txtAddFirstName
            // 
            this.txtAddFirstName.Location = new System.Drawing.Point(111, 48);
            this.txtAddFirstName.MaxLength = 255;
            this.txtAddFirstName.Name = "txtAddFirstName";
            this.txtAddFirstName.Size = new System.Drawing.Size(171, 20);
            this.txtAddFirstName.TabIndex = 7;
            // 
            // txtAddUserName
            // 
            this.txtAddUserName.Location = new System.Drawing.Point(111, 16);
            this.txtAddUserName.MaxLength = 30;
            this.txtAddUserName.Name = "txtAddUserName";
            this.txtAddUserName.Size = new System.Drawing.Size(171, 20);
            this.txtAddUserName.TabIndex = 6;
            // 
            // lblAddEmail
            // 
            this.lblAddEmail.AutoSize = true;
            this.lblAddEmail.Location = new System.Drawing.Point(70, 173);
            this.lblAddEmail.Name = "lblAddEmail";
            this.lblAddEmail.Size = new System.Drawing.Size(35, 13);
            this.lblAddEmail.TabIndex = 5;
            this.lblAddEmail.Text = "Email:";
            // 
            // lblAddDateOfBirth
            // 
            this.lblAddDateOfBirth.AutoSize = true;
            this.lblAddDateOfBirth.Location = new System.Drawing.Point(35, 142);
            this.lblAddDateOfBirth.Name = "lblAddDateOfBirth";
            this.lblAddDateOfBirth.Size = new System.Drawing.Size(71, 13);
            this.lblAddDateOfBirth.TabIndex = 4;
            this.lblAddDateOfBirth.Text = "Date Of Birth:";
            // 
            // lblAddGender
            // 
            this.lblAddGender.AutoSize = true;
            this.lblAddGender.Location = new System.Drawing.Point(60, 112);
            this.lblAddGender.Name = "lblAddGender";
            this.lblAddGender.Size = new System.Drawing.Size(45, 13);
            this.lblAddGender.TabIndex = 3;
            this.lblAddGender.Text = "Gender:";
            // 
            // lblAddLastName
            // 
            this.lblAddLastName.AutoSize = true;
            this.lblAddLastName.Location = new System.Drawing.Point(45, 82);
            this.lblAddLastName.Name = "lblAddLastName";
            this.lblAddLastName.Size = new System.Drawing.Size(61, 13);
            this.lblAddLastName.TabIndex = 2;
            this.lblAddLastName.Text = "Last Name:";
            // 
            // lblAddFirstName
            // 
            this.lblAddFirstName.AutoSize = true;
            this.lblAddFirstName.Location = new System.Drawing.Point(45, 51);
            this.lblAddFirstName.Name = "lblAddFirstName";
            this.lblAddFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblAddFirstName.TabIndex = 1;
            this.lblAddFirstName.Text = "First Name:";
            // 
            // lblAddUserName
            // 
            this.lblAddUserName.AutoSize = true;
            this.lblAddUserName.Location = new System.Drawing.Point(47, 19);
            this.lblAddUserName.Name = "lblAddUserName";
            this.lblAddUserName.Size = new System.Drawing.Size(58, 13);
            this.lblAddUserName.TabIndex = 0;
            this.lblAddUserName.Text = "Username:";
            // 
            // datDateOfBirth
            // 
            this.datDateOfBirth.Enabled = false;
            this.datDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datDateOfBirth.Location = new System.Drawing.Point(321, 209);
            this.datDateOfBirth.Name = "datDateOfBirth";
            this.datDateOfBirth.Size = new System.Drawing.Size(86, 20);
            this.datDateOfBirth.TabIndex = 22;
            // 
            // comAddGender
            // 
            this.comAddGender.FormattingEnabled = true;
            this.comAddGender.Items.AddRange(new object[] {
            "Female",
            "Male",
            "Other"});
            this.comAddGender.Location = new System.Drawing.Point(111, 109);
            this.comAddGender.MaxLength = 7;
            this.comAddGender.Name = "comAddGender";
            this.comAddGender.Size = new System.Drawing.Size(105, 21);
            this.comAddGender.TabIndex = 25;
            // 
            // comUpdateGender
            // 
            this.comUpdateGender.FormattingEnabled = true;
            this.comUpdateGender.Items.AddRange(new object[] {
            "Female",
            "Male",
            "Other"});
            this.comUpdateGender.Location = new System.Drawing.Point(111, 107);
            this.comUpdateGender.MaxLength = 7;
            this.comUpdateGender.Name = "comUpdateGender";
            this.comUpdateGender.Size = new System.Drawing.Size(100, 21);
            this.comUpdateGender.TabIndex = 18;
            // 
            // CompetitorMaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 380);
            this.Controls.Add(this.pnlUpdateCompetitor);
            this.Controls.Add(this.pnlAddCompetitor);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnDeleteCompetitor);
            this.Controls.Add(this.btnUpdateCompetitor);
            this.Controls.Add(this.btnAddCompetitor);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtCompetitorID);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblCompetitorID);
            this.Controls.Add(this.lstUserName);
            this.Controls.Add(this.datDateOfBirth);
            this.Name = "CompetitorMaintenanceForm";
            this.Text = "Competitor Maintenance";
            this.pnlAddCompetitor.ResumeLayout(false);
            this.pnlAddCompetitor.PerformLayout();
            this.pnlUpdateCompetitor.ResumeLayout(false);
            this.pnlUpdateCompetitor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUserName;
        private System.Windows.Forms.Label lblCompetitorID;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtCompetitorID;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAddCompetitor;
        private System.Windows.Forms.Button btnUpdateCompetitor;
        private System.Windows.Forms.Button btnDeleteCompetitor;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Panel pnlAddCompetitor;
        private System.Windows.Forms.TextBox txtAddEmail;
        private System.Windows.Forms.TextBox txtAddLastName;
        private System.Windows.Forms.TextBox txtAddFirstName;
        private System.Windows.Forms.TextBox txtAddUserName;
        private System.Windows.Forms.Label lblAddEmail;
        private System.Windows.Forms.Label lblAddDateOfBirth;
        private System.Windows.Forms.Label lblAddGender;
        private System.Windows.Forms.Label lblAddLastName;
        private System.Windows.Forms.Label lblAddFirstName;
        private System.Windows.Forms.Label lblAddUserName;
        private System.Windows.Forms.Button btnCancelAddCompetitor;
        private System.Windows.Forms.Button btnSaveAddCompetitor;
        private System.Windows.Forms.Panel pnlUpdateCompetitor;
        private System.Windows.Forms.Button btnCancelUpdateCompetitor;
        private System.Windows.Forms.Button btnSaveUpdateCompetitor;
        private System.Windows.Forms.TextBox txtUpdateEmail;
        private System.Windows.Forms.TextBox txtUpdateLastName;
        private System.Windows.Forms.TextBox txtUpdateFirstName;
        private System.Windows.Forms.TextBox txtUpdateUserName;
        private System.Windows.Forms.Label lblUpdateEmail;
        private System.Windows.Forms.Label lblUpdateDateOfBirth;
        private System.Windows.Forms.Label lblUpdateGender;
        private System.Windows.Forms.Label lblUpdateLastName;
        private System.Windows.Forms.Label lblUpdateFirstName;
        private System.Windows.Forms.Label lblUpdateUserName;
        private System.Windows.Forms.DateTimePicker datAddDateOfBirth;
        private System.Windows.Forms.DateTimePicker datUpdateDateOfBirth;
        private System.Windows.Forms.DateTimePicker datDateOfBirth;
        private System.Windows.Forms.ComboBox comUpdateGender;
        private System.Windows.Forms.ComboBox comAddGender;
    }
}