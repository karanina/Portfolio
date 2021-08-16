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
    public partial class EventsReportForm : Form
    {
        // This is the reference to the DataModule object.
        private DataModule DM;

        // This is the reference to the MainForm object.
        private MainForm frmMenu;

        // This is the reference to the CurrencyManager object.
        private CurrencyManager currencyManager;

        private int amountOfEventsPrinted;
        private int pagesAmountExpected;
        private DataRow[] eventsForPrint;

        public EventsReportForm(DataModule dm, MainForm mnu)
        {
            InitializeComponent();
            DM = dm;
            frmMenu = mnu;
        }

        private void btnPrintEvents_Click(object sender, EventArgs e)
        {
            amountOfEventsPrinted = 0;
            string strFilter = "EventID NOT IN (0)";
            string strSort = "EventID";
            eventsForPrint = DM.dsNZESL.Tables["Event"].Select(strFilter, strSort, DataViewRowState.CurrentRows);
            pagesAmountExpected = eventsForPrint.Length;
            prvEvents.Show();
        }

        private void printEvents_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int linesSoFarHeading = 0;
            Font textFont = new Font("Arial", 10, FontStyle.Regular);
            Font headingFont = new Font("Arial", 10, FontStyle.Regular);
            DataRow drEvent = eventsForPrint[amountOfEventsPrinted];
            CurrencyManager cmEvent;
            CurrencyManager cmArena;
            CurrencyManager cmChallenge;

            cmEvent = (CurrencyManager)this.BindingContext[DM.dsNZESL, "EVENT"];
            cmArena = (CurrencyManager)this.BindingContext[DM.dsNZESL, "ARENA"];
            cmChallenge = (CurrencyManager)this.BindingContext[DM.dsNZESL, "CHALLENGE"];

            Brush brush = new SolidBrush(Color.Black);

            // sets the margins

            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            int headingLeftMargin = 50;
            int topMarginBounds = topMargin + 70;
            int rightMargin = e.MarginBounds.Right;

            // gets the Arena record matching the ArenaID in the Event record
            int anArenaID = Convert.ToInt32(drEvent["ArenaID"].ToString());
            cmArena.Position = DM.arenaView.Find(anArenaID);
            DataRow drArena = DM.dtArena.Rows[cmArena.Position];

            // heading
            g.DrawString("Event ID: " + drEvent["EventID"], headingFont, brush, leftMargin + headingLeftMargin, 
                topMargin + (linesSoFarHeading * textFont.Height));
            linesSoFarHeading++;
            linesSoFarHeading++;
            g.DrawString("" + drEvent["EventName"], headingFont, brush, leftMargin + headingLeftMargin, 
                topMargin + (linesSoFarHeading * textFont.Height));
            linesSoFarHeading++;
            g.DrawString("" + drArena["ArenaName"], headingFont, brush, leftMargin + headingLeftMargin,
                topMargin + (linesSoFarHeading * textFont.Height));
            linesSoFarHeading++;
            g.DrawString("" + drArena["StreetAddress"], headingFont, brush, leftMargin + headingLeftMargin,
               topMargin + (linesSoFarHeading * textFont.Height));
            linesSoFarHeading++;
            g.DrawString("" + drArena["Suburb"], headingFont, brush, leftMargin + headingLeftMargin,
               topMargin + (linesSoFarHeading * textFont.Height));
            linesSoFarHeading++;
            g.DrawString("" + drArena["City"], headingFont, brush, leftMargin + headingLeftMargin,
               topMargin + (linesSoFarHeading * textFont.Height));
            linesSoFarHeading++;
            linesSoFarHeading++;
            g.DrawString("Event Date: " + Convert.ToDateTime(drEvent["EventDate"]).ToShortDateString(), headingFont, 
                brush, leftMargin + headingLeftMargin, topMargin + (linesSoFarHeading * textFont.Height));
            linesSoFarHeading++;
            linesSoFarHeading++;
            g.DrawString("Challenges:", headingFont, brush, leftMargin + headingLeftMargin,
               topMargin + (linesSoFarHeading * textFont.Height));
            linesSoFarHeading++;
            linesSoFarHeading++;
            g.DrawString("ID\tName\t\tTime", headingFont, brush, leftMargin + headingLeftMargin,
              topMargin + (linesSoFarHeading * textFont.Height));
            linesSoFarHeading++;
            linesSoFarHeading++;

            DataRow[] drChallenges = drEvent.GetChildRows(DM.dtEvent.ChildRelations["EVENT_CHALLENGE"]);

            if (drChallenges.Length == 0)
            {
                g.DrawString("This event has no challenges scheduled.", headingFont, brush, leftMargin + headingLeftMargin,
               topMargin + (linesSoFarHeading * textFont.Height));
                linesSoFarHeading++;
            }  
            else
            {
                for (int i = 0; i<drChallenges.Length; i++)
                {
                    // gets the challenge record with a matching EventID 
                    int aChallengeID = Convert.ToInt32(drChallenges[i]["EventID"].ToString());
                    cmChallenge.Position = DM.challengeView.Find(aChallengeID);
                    DataRow drChallenge = DM.dtChallenge.Rows[cmChallenge.Position];

                    g.DrawString("" + drChallenge["ChallengeID"] + "\t" + drChallenge["ChallengeName"] + "\t" +
                        Convert.ToDateTime(drChallenge["StartTime"]).ToShortTimeString(), textFont, brush, leftMargin 
                        + headingLeftMargin, topMargin + (linesSoFarHeading * textFont.Height));
                    linesSoFarHeading++;
                }
            }
            amountOfEventsPrinted++;
            if(!(amountOfEventsPrinted == pagesAmountExpected))
            {
                e.HasMorePages = true;
            }
        }
        // This is a button return method which closes the Events Report form and returns the user to the main form.
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
