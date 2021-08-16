namespace NZESportsLeagueV1
{
    partial class EventsReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventsReportForm));
            this.btnPrintEvents = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.printEvents = new System.Drawing.Printing.PrintDocument();
            this.prvEvents = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // btnPrintEvents
            // 
            this.btnPrintEvents.Location = new System.Drawing.Point(29, 32);
            this.btnPrintEvents.Name = "btnPrintEvents";
            this.btnPrintEvents.Size = new System.Drawing.Size(93, 23);
            this.btnPrintEvents.TabIndex = 0;
            this.btnPrintEvents.Text = "Print Events";
            this.btnPrintEvents.UseVisualStyleBackColor = true;
            this.btnPrintEvents.Click += new System.EventHandler(this.btnPrintEvents_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(155, 32);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(93, 23);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // printEvents
            // 
            this.printEvents.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printEvents_PrintPage);
            // 
            // prvEvents
            // 
            this.prvEvents.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prvEvents.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prvEvents.ClientSize = new System.Drawing.Size(400, 300);
            this.prvEvents.Document = this.printEvents;
            this.prvEvents.Enabled = true;
            this.prvEvents.Icon = ((System.Drawing.Icon)(resources.GetObject("prvEvents.Icon")));
            this.prvEvents.Name = "prvEvents";
            this.prvEvents.Visible = false;
            // 
            // EventsReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 85);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnPrintEvents);
            this.Name = "EventsReportForm";
            this.Text = "Events Report";
            this.Click += new System.EventHandler(this.btnReturn_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrintEvents;
        private System.Windows.Forms.Button btnReturn;
        private System.Drawing.Printing.PrintDocument printEvents;
        private System.Windows.Forms.PrintPreviewDialog prvEvents;
    }
}