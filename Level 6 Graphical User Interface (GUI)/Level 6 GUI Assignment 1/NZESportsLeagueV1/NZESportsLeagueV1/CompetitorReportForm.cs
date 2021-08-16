using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NZESportsLeagueV1
{
    public partial class CompetitorReportForm : Form
    {
        // This is the reference to the DataModule object.
        private DataModule DM;

        // This is the reference to the MainForm object.
        private MainForm frmMenu;

        // This is the reference to the CurrencyManager object.
        private CurrencyManager currencyManager;

        private int amountOfCompetitorsPrinted, pagesAmountExpected;
        private DataRow[] competitorsForPrint;

        // This is the constructor method which takes in the DataModule and MainForm objects as arguments
        // and binds the data in the Competitor table to the 
        public CompetitorReportForm(DataModule dm, MainForm mnu)
        {
            InitializeComponent();
            DM = dm;
            frmMenu = mnu;
        }

        private void btnPrintCompetitors_Click(object sender, EventArgs e)
        {
            amountOfCompetitorsPrinted = 0;
            string strFilter = " ";
            string strSort = "CompetitorID";
            competitorsForPrint = DM.dsNZESL.Tables["Entry"].Select(strFilter, strSort, DataViewRowState.CurrentRows);
            pagesAmountExpected = competitorsForPrint.Length;
            prvCompetitors.Show();
        }

        private void printCompetitors_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int linesSoFarHeading = 0;
            Font textFont = new Font("Arial", 10, FontStyle.Regular);
            Font headingFont = new Font("Arial", 10, FontStyle.Regular);
            DataRow drEntries = competitorsForPrint[amountOfCompetitorsPrinted];
            CurrencyManager cmCompetitor;
            CurrencyManager cmChallenge;
            CurrencyManager cmEntry;

            cmCompetitor = (CurrencyManager)this.BindingContext[DM.dsNZESL, "Competitor"];
            cmChallenge = (CurrencyManager)this.BindingContext[DM.dsNZESL, "Challenge"];
            cmEntry = (CurrencyManager)this.BindingContext[DM.dsNZESL, "Entry"];

            Brush brush = new SolidBrush(Color.Black);
            // sets the margins
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            int headingLeftMargin = 50;
            int topMarginDetails = topMargin + 70;
            int rightMargin = e.MarginBounds.Right;
            // gets the Competitor ID from the Entry table and uses it to find the matching data in the 
            // Competitor table
            int aCompetitorID = Convert.ToInt32(drEntries["CompetitorID"].ToString());
            cmCompetitor.Position = DM.competitorView.Find(aCompetitorID);
            DataRow drCompetitor = DM.dtCompetitor.Rows[cmCompetitor.Position];

            DataRow[] drCompetitorEntries = drCompetitor.GetChildRows(DM.dtCompetitor.ChildRelations["Competitor_Entry"]);

            if (drCompetitorEntries.Length > 0)
            {
                // heading
                g.DrawString("Competitor ID: " + drCompetitor["CompetitorID"], headingFont, brush, leftMargin + headingLeftMargin,
                    topMargin + (linesSoFarHeading * textFont.Height));
                linesSoFarHeading++;
                linesSoFarHeading++;
                g.DrawString("Username:\t" + drCompetitor["UserName"], headingFont, brush, leftMargin + headingLeftMargin,
                    topMargin + (linesSoFarHeading * textFont.Height));
                linesSoFarHeading++;
                g.DrawString("Name:\t\t" + drCompetitor["FirstName"] + " " + drCompetitor["LastName"], headingFont, brush, leftMargin + headingLeftMargin,
                    topMargin + (linesSoFarHeading * textFont.Height));
                linesSoFarHeading++;
                g.DrawString("Gender:\t\t" + drCompetitor["Gender"], headingFont, brush, leftMargin + headingLeftMargin,
                    topMargin + (linesSoFarHeading * textFont.Height));
                linesSoFarHeading++;
                g.DrawString("Date of Birth:\t" + drCompetitor["UserName"], headingFont, brush, leftMargin + headingLeftMargin,
                    topMargin + (linesSoFarHeading * textFont.Height));
                linesSoFarHeading++;
                g.DrawString("Email:\t\t" + drCompetitor["EmailAddress"], headingFont, brush, leftMargin + headingLeftMargin,
                    topMargin + (linesSoFarHeading * textFont.Height));
                linesSoFarHeading++;
                linesSoFarHeading++;
                g.DrawString("Entries:", headingFont, brush, leftMargin + headingLeftMargin,
                            topMargin + (linesSoFarHeading * textFont.Height));
                linesSoFarHeading++;
                linesSoFarHeading++;
                g.DrawString("Challenge ID\tChallenge Name\t\tStart Time", headingFont, brush, leftMargin + headingLeftMargin,
                    topMargin + (linesSoFarHeading * textFont.Height));
                linesSoFarHeading++;
                linesSoFarHeading++;
                foreach (DataRow competitor in drCompetitorEntries)
                {
                    DataRow[] drEntry = drCompetitor.GetChildRows("Competitor_Entry");

                    for (int i = 0; i < drEntry.Length; i++)
                    {
                        // gets the Challenge ID from the Entry table and uses it to find the matching data in the Challenge table
                        int aChallengeID = Convert.ToInt32(drEntry[i]["ChallengeID"].ToString());
                        cmChallenge.Position = DM.challengeView.Find(aChallengeID);
                        DataRow drChallenge = DM.dtChallenge.Rows[cmChallenge.Position];

                        g.DrawString(drChallenge["ChallengeID"] + "\t\t" + drChallenge["ChallengeName"] + "\t" + Convert.ToDateTime(
                            drChallenge["StartTime"]).ToShortTimeString(), textFont, brush, leftMargin + headingLeftMargin,
                        topMargin + (linesSoFarHeading * textFont.Height));
                        linesSoFarHeading++;
                    }


                }
                amountOfCompetitorsPrinted++;
                if (!(amountOfCompetitorsPrinted == pagesAmountExpected))
                {
                    e.HasMorePages = true;
                }
            }
        }

        // This is a button return method which closes the Competitor Report form and returns the user to the 
        // main form.
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
