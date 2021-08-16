namespace NZESportsLeagueV1
{
    partial class EnterCompetitorIntoChallengeForm
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
            this.dgvCompetitor = new System.Windows.Forms.DataGridView();
            this.dgvChallenge = new System.Windows.Forms.DataGridView();
            this.dgvEntry = new System.Windows.Forms.DataGridView();
            this.lblEntryEventName = new System.Windows.Forms.Label();
            this.lblEntryStatus = new System.Windows.Forms.Label();
            this.txtEntryEventName = new System.Windows.Forms.TextBox();
            this.comChallengeEventStatus = new System.Windows.Forms.ComboBox();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.btnRemoveEntry = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallenge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompetitor
            // 
            this.dgvCompetitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompetitor.Location = new System.Drawing.Point(28, 29);
            this.dgvCompetitor.Name = "dgvCompetitor";
            this.dgvCompetitor.Size = new System.Drawing.Size(390, 150);
            this.dgvCompetitor.TabIndex = 0;
            // 
            // dgvChallenge
            // 
            this.dgvChallenge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChallenge.Location = new System.Drawing.Point(28, 207);
            this.dgvChallenge.Name = "dgvChallenge";
            this.dgvChallenge.Size = new System.Drawing.Size(390, 150);
            this.dgvChallenge.TabIndex = 1;
            this.dgvChallenge.SelectionChanged += new System.EventHandler(this.lstEventName_SelectedIndexChanged);
            // 
            // dgvEntry
            // 
            this.dgvEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntry.Location = new System.Drawing.Point(453, 207);
            this.dgvEntry.Name = "dgvEntry";
            this.dgvEntry.Size = new System.Drawing.Size(240, 150);
            this.dgvEntry.TabIndex = 2;
            // 
            // lblEntryEventName
            // 
            this.lblEntryEventName.AutoSize = true;
            this.lblEntryEventName.Location = new System.Drawing.Point(450, 78);
            this.lblEntryEventName.Name = "lblEntryEventName";
            this.lblEntryEventName.Size = new System.Drawing.Size(69, 13);
            this.lblEntryEventName.TabIndex = 3;
            this.lblEntryEventName.Text = "Event Name:";
            // 
            // lblEntryStatus
            // 
            this.lblEntryStatus.AutoSize = true;
            this.lblEntryStatus.Location = new System.Drawing.Point(479, 117);
            this.lblEntryStatus.Name = "lblEntryStatus";
            this.lblEntryStatus.Size = new System.Drawing.Size(40, 13);
            this.lblEntryStatus.TabIndex = 4;
            this.lblEntryStatus.Text = "Status:";
            // 
            // txtEntryEventName
            // 
            this.txtEntryEventName.Location = new System.Drawing.Point(525, 75);
            this.txtEntryEventName.Name = "txtEntryEventName";
            this.txtEntryEventName.ReadOnly = true;
            this.txtEntryEventName.Size = new System.Drawing.Size(168, 20);
            this.txtEntryEventName.TabIndex = 5;
            // 
            // comChallengeEventStatus
            // 
            this.comChallengeEventStatus.Enabled = false;
            this.comChallengeEventStatus.FormattingEnabled = true;
            this.comChallengeEventStatus.Location = new System.Drawing.Point(525, 114);
            this.comChallengeEventStatus.Name = "comChallengeEventStatus";
            this.comChallengeEventStatus.Size = new System.Drawing.Size(121, 21);
            this.comChallengeEventStatus.TabIndex = 6;
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(28, 384);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(95, 23);
            this.btnAddEntry.TabIndex = 7;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // btnRemoveEntry
            // 
            this.btnRemoveEntry.Location = new System.Drawing.Point(314, 384);
            this.btnRemoveEntry.Name = "btnRemoveEntry";
            this.btnRemoveEntry.Size = new System.Drawing.Size(95, 23);
            this.btnRemoveEntry.TabIndex = 8;
            this.btnRemoveEntry.Text = "Remove Entry";
            this.btnRemoveEntry.UseVisualStyleBackColor = true;
            this.btnRemoveEntry.Click += new System.EventHandler(this.btnRemoveEntry_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(598, 384);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(95, 23);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // EnterCompetitorIntoChallengeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 431);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnRemoveEntry);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.comChallengeEventStatus);
            this.Controls.Add(this.txtEntryEventName);
            this.Controls.Add(this.lblEntryStatus);
            this.Controls.Add(this.lblEntryEventName);
            this.Controls.Add(this.dgvEntry);
            this.Controls.Add(this.dgvChallenge);
            this.Controls.Add(this.dgvCompetitor);
            this.Name = "EnterCompetitorIntoChallengeForm";
            this.Text = "Enter Competitor Into Challenge";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallenge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCompetitor;
        private System.Windows.Forms.DataGridView dgvChallenge;
        private System.Windows.Forms.DataGridView dgvEntry;
        private System.Windows.Forms.Label lblEntryEventName;
        private System.Windows.Forms.Label lblEntryStatus;
        private System.Windows.Forms.TextBox txtEntryEventName;
        private System.Windows.Forms.ComboBox comChallengeEventStatus;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.Button btnRemoveEntry;
        private System.Windows.Forms.Button btnReturn;
    }
}