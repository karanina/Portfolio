namespace NZESportsLeagueV1
{
    partial class MainForm
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
            this.grpMaintenance = new System.Windows.Forms.GroupBox();
            this.btnEnterCompetitorIntoChallenge = new System.Windows.Forms.Button();
            this.btnCompetitorMaintenance = new System.Windows.Forms.Button();
            this.btnChallengeMaintenance = new System.Windows.Forms.Button();
            this.btnEventMaintenance = new System.Windows.Forms.Button();
            this.btnArenaMaintenance = new System.Windows.Forms.Button();
            this.grpReporting = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCompetitorReport = new System.Windows.Forms.Button();
            this.btnEventsReport = new System.Windows.Forms.Button();
            this.grpMaintenance.SuspendLayout();
            this.grpReporting.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMaintenance
            // 
            this.grpMaintenance.Controls.Add(this.btnEnterCompetitorIntoChallenge);
            this.grpMaintenance.Controls.Add(this.btnCompetitorMaintenance);
            this.grpMaintenance.Controls.Add(this.btnChallengeMaintenance);
            this.grpMaintenance.Controls.Add(this.btnEventMaintenance);
            this.grpMaintenance.Controls.Add(this.btnArenaMaintenance);
            this.grpMaintenance.Location = new System.Drawing.Point(28, 29);
            this.grpMaintenance.Name = "grpMaintenance";
            this.grpMaintenance.Size = new System.Drawing.Size(200, 275);
            this.grpMaintenance.TabIndex = 0;
            this.grpMaintenance.TabStop = false;
            this.grpMaintenance.Text = "Maintenance";
            // 
            // btnEnterCompetitorIntoChallenge
            // 
            this.btnEnterCompetitorIntoChallenge.Location = new System.Drawing.Point(32, 221);
            this.btnEnterCompetitorIntoChallenge.Name = "btnEnterCompetitorIntoChallenge";
            this.btnEnterCompetitorIntoChallenge.Size = new System.Drawing.Size(135, 37);
            this.btnEnterCompetitorIntoChallenge.TabIndex = 4;
            this.btnEnterCompetitorIntoChallenge.Text = "Enter Competitor into Challenge";
            this.btnEnterCompetitorIntoChallenge.UseVisualStyleBackColor = true;
            this.btnEnterCompetitorIntoChallenge.Click += new System.EventHandler(this.btnEnterCompetitorIntoChallenge_Click);
            // 
            // btnCompetitorMaintenance
            // 
            this.btnCompetitorMaintenance.Location = new System.Drawing.Point(32, 170);
            this.btnCompetitorMaintenance.Name = "btnCompetitorMaintenance";
            this.btnCompetitorMaintenance.Size = new System.Drawing.Size(135, 23);
            this.btnCompetitorMaintenance.TabIndex = 3;
            this.btnCompetitorMaintenance.Text = "Competitor Maintenance";
            this.btnCompetitorMaintenance.UseVisualStyleBackColor = true;
            this.btnCompetitorMaintenance.Click += new System.EventHandler(this.btnCompetitorMaintenance_Click);
            // 
            // btnChallengeMaintenance
            // 
            this.btnChallengeMaintenance.Location = new System.Drawing.Point(32, 119);
            this.btnChallengeMaintenance.Name = "btnChallengeMaintenance";
            this.btnChallengeMaintenance.Size = new System.Drawing.Size(135, 23);
            this.btnChallengeMaintenance.TabIndex = 2;
            this.btnChallengeMaintenance.Text = "Challenge Maintenance";
            this.btnChallengeMaintenance.UseVisualStyleBackColor = true;
            this.btnChallengeMaintenance.Click += new System.EventHandler(this.btnChallengeMaintenance_Click);
            // 
            // btnEventMaintenance
            // 
            this.btnEventMaintenance.Location = new System.Drawing.Point(32, 69);
            this.btnEventMaintenance.Name = "btnEventMaintenance";
            this.btnEventMaintenance.Size = new System.Drawing.Size(135, 23);
            this.btnEventMaintenance.TabIndex = 1;
            this.btnEventMaintenance.Text = "Event Maintenance";
            this.btnEventMaintenance.UseVisualStyleBackColor = true;
            this.btnEventMaintenance.Click += new System.EventHandler(this.btnEventMaintenance_Click);
            // 
            // btnArenaMaintenance
            // 
            this.btnArenaMaintenance.Location = new System.Drawing.Point(32, 19);
            this.btnArenaMaintenance.Name = "btnArenaMaintenance";
            this.btnArenaMaintenance.Size = new System.Drawing.Size(135, 23);
            this.btnArenaMaintenance.TabIndex = 0;
            this.btnArenaMaintenance.Text = "Arena Maintenance";
            this.btnArenaMaintenance.UseVisualStyleBackColor = true;
            this.btnArenaMaintenance.Click += new System.EventHandler(this.btnArenaMaintenance_Click);
            // 
            // grpReporting
            // 
            this.grpReporting.Controls.Add(this.btnExit);
            this.grpReporting.Controls.Add(this.btnCompetitorReport);
            this.grpReporting.Controls.Add(this.btnEventsReport);
            this.grpReporting.Location = new System.Drawing.Point(291, 29);
            this.grpReporting.Name = "grpReporting";
            this.grpReporting.Size = new System.Drawing.Size(200, 275);
            this.grpReporting.TabIndex = 1;
            this.grpReporting.TabStop = false;
            this.grpReporting.Text = "Reporting";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(33, 235);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCompetitorReport
            // 
            this.btnCompetitorReport.Location = new System.Drawing.Point(33, 69);
            this.btnCompetitorReport.Name = "btnCompetitorReport";
            this.btnCompetitorReport.Size = new System.Drawing.Size(135, 23);
            this.btnCompetitorReport.TabIndex = 1;
            this.btnCompetitorReport.Text = "Competitor Report";
            this.btnCompetitorReport.UseVisualStyleBackColor = true;
            this.btnCompetitorReport.Click += new System.EventHandler(this.btnCompetitorReport_Click);
            // 
            // btnEventsReport
            // 
            this.btnEventsReport.Location = new System.Drawing.Point(33, 19);
            this.btnEventsReport.Name = "btnEventsReport";
            this.btnEventsReport.Size = new System.Drawing.Size(135, 23);
            this.btnEventsReport.TabIndex = 0;
            this.btnEventsReport.Text = "Events Report";
            this.btnEventsReport.UseVisualStyleBackColor = true;
            this.btnEventsReport.Click += new System.EventHandler(this.btnEventsReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 332);
            this.Controls.Add(this.grpReporting);
            this.Controls.Add(this.grpMaintenance);
            this.Name = "MainForm";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpMaintenance.ResumeLayout(false);
            this.grpReporting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMaintenance;
        private System.Windows.Forms.GroupBox grpReporting;
        private System.Windows.Forms.Button btnEnterCompetitorIntoChallenge;
        private System.Windows.Forms.Button btnCompetitorMaintenance;
        private System.Windows.Forms.Button btnChallengeMaintenance;
        private System.Windows.Forms.Button btnEventMaintenance;
        private System.Windows.Forms.Button btnArenaMaintenance;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCompetitorReport;
        private System.Windows.Forms.Button btnEventsReport;
    }
}

