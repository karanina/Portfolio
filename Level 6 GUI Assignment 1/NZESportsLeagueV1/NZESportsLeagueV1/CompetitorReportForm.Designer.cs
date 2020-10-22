namespace NZESportsLeagueV1
{
    partial class CompetitorReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompetitorReportForm));
            this.btnPrintCompetitors = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.printCompetitors = new System.Drawing.Printing.PrintDocument();
            this.prvCompetitors = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // btnPrintCompetitors
            // 
            this.btnPrintCompetitors.Location = new System.Drawing.Point(28, 33);
            this.btnPrintCompetitors.Name = "btnPrintCompetitors";
            this.btnPrintCompetitors.Size = new System.Drawing.Size(107, 23);
            this.btnPrintCompetitors.TabIndex = 0;
            this.btnPrintCompetitors.Text = "Print Competitors";
            this.btnPrintCompetitors.UseVisualStyleBackColor = true;
            this.btnPrintCompetitors.Click += new System.EventHandler(this.btnPrintCompetitors_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(190, 33);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(107, 23);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // printCompetitors
            // 
            this.printCompetitors.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printCompetitors_PrintPage);
            // 
            // prvCompetitors
            // 
            this.prvCompetitors.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prvCompetitors.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prvCompetitors.ClientSize = new System.Drawing.Size(400, 300);
            this.prvCompetitors.Document = this.printCompetitors;
            this.prvCompetitors.Enabled = true;
            this.prvCompetitors.Icon = ((System.Drawing.Icon)(resources.GetObject("prvCompetitors.Icon")));
            this.prvCompetitors.Name = "prvCompetitors";
            this.prvCompetitors.Visible = false;
            // 
            // CompetitorReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 84);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnPrintCompetitors);
            this.Name = "CompetitorReportForm";
            this.Text = "Competitor Report";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrintCompetitors;
        private System.Windows.Forms.Button btnReturn;
        private System.Drawing.Printing.PrintDocument printCompetitors;
        private System.Windows.Forms.PrintPreviewDialog prvCompetitors;
    }
}