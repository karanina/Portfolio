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
    public partial class EnterCompetitorIntoChallengeForm : Form
    {
        // This is the reference to the DataModule object.
        private DataModule DM;

        // This is the reference to the MainForm object.
        private MainForm frmMenu;

        // This is the reference to the CurrencyManager object for the Competitor table.
        private CurrencyManager cmCompetitor;

        // This is the reference to the CurrencyManager object for the Challenge table.
        private CurrencyManager cmChallenge;

        // This is the reference to the CurrencyManager object for the Challenge_Entry relationship.
        private CurrencyManager cmChallengeEntry;

        // This is the reference to the CurrencyManager object for the Event_Challenge relationship.
        private CurrencyManager cmEventChallenge;

        // This is the reference to the CurrencyManager object for the Event table.
        private CurrencyManager cmEvent;

        // This is the reference to the CurrencyManager object for the Entry table.
        private CurrencyManager currencyManager;

        // This creates a new DataTable called dt.
        private DataTable dt = new DataTable();

        // This is the reference to the CurrencyManager object for the dt table.
        private CurrencyManager cmDt;

        // This is the constructor method which takes in the DataModule and MainForm objects as parameters
        // and enacts the BindControls method to bind the data in the Entry, Competitor, Challenge and Event tables
        // to the appropriate text boxes and list field.
        public EnterCompetitorIntoChallengeForm(DataModule dm, MainForm mnu)
        {
            InitializeComponent();
            DM = dm;
            frmMenu = mnu;
            BindControls();
        }
        // This method binds the data in the Entry, Competitor, Challenge and Event tables to the appropriate 
        // data grid views and text boxes.
        public void BindControls()
        {
            dgvChallenge.DataSource = DM.dsNZESL;
            dgvChallenge.DataMember = "Challenge";
            dgvCompetitor.DataSource = DM.dsNZESL;
            dgvCompetitor.DataMember = "Competitor";
            dgvEntry.DataSource = DM.dsNZESL;
            dgvEntry.DataMember = "Challenge.Challenge_Entry";
            txtEntryEventName.DataBindings.Add("Text", DM.dsNZESL, "Event.EventName");
            comChallengeEventStatus.DataBindings.Add("Text", DM.dsNZESL, "Event.Status");
            currencyManager = (CurrencyManager)this.BindingContext[DM.dsNZESL, "Entry"];
            cmCompetitor = (CurrencyManager)this.BindingContext[DM.dsNZESL, "Competitor"];
            cmChallenge = (CurrencyManager)this.BindingContext[DM.dsNZESL, "Challenge"];
            cmDt = (CurrencyManager)this.BindingContext[dt];
            cmChallengeEntry = (CurrencyManager)this.BindingContext[DM.dsNZESL, "Challenge.Challenge_Entry"];
            cmEventChallenge = (CurrencyManager)this.BindingContext[DM.dsNZESL, "Event.Event_Challenge"];
            cmEvent = (CurrencyManager)this.BindingContext[DM.dsNZESL, "Event"];
        }

        // This button click method combines a Challenge ID and a Competitor ID together to create a new record in
        // the Entry table, unless the competitor is already entered into that particular challenge.
        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            try
            {
                if (DM.dtChallenge.Rows[cmChallenge.Position]["Status"].ToString() == "Scheduled")
                {
                    DataRow newEntry = DM.dtEntry.NewRow();

                    newEntry["ChallengeID"] = dgvChallenge["ChallengeID", cmChallenge.Position].Value;
                    newEntry["CompetitorID"] = dgvCompetitor["CompetitorID", cmCompetitor.Position].Value;
                    newEntry["Status"] = comChallengeEventStatus.Text;

                    DM.dsNZESL.Tables["Entry"].Rows.Add(newEntry);
                    currencyManager.EndCurrentEdit();
                    DM.UpdateEntry();

                    MessageBox.Show("Entry added successfully", "Success");
                }

                else
                {
                    MessageBox.Show("Competitors can only be entered to scheduled challenges", "Error");
                }
            }
            catch (ConstraintException)
            {
                MessageBox.Show("This competitor has already been entered in this challenge", "Error");
            }
        }

        // This button click method deletes a record from the Entry table.
        private void btnRemoveEntry_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Are you sure you wish to delete this entry?", "Error", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) { 
                string challengeID = DM.dtChallenge.Rows[cmChallenge.Position]["ChallengeID"].ToString();
                string competitorID = DM.dtCompetitor.Rows[cmCompetitor.Position]["CompetitorID"].ToString();
                int row = 0;

                for (int i = 0; i < DM.dtEntry.Rows.Count; i++)
                {
                    string chID = DM.dtEntry.Rows[i]["ChallengeID"].ToString();
                    string coID = DM.dtEntry.Rows[i]["CompetitorID"].ToString();

                    if (challengeID == chID && competitorID == coID)
                    {
                        row = i;
                    }
                }
                DataRow dr = DM.dsNZESL.Tables["Entry"].Rows[row];
                dr.Delete();
                currencyManager.EndCurrentEdit();
                DM.UpdateEntry();
                MessageBox.Show("Entry removed successfully", "Success");
            }
        }


        // This is a button click method which closes the Enter Competitor into Challenge form and returns the 
        // user to the main form.
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        // This method changes the currency manager's position within the eventView as the EventID is changed within
        // the Challenge data table, so that any variable's in the Event table may be synced up to the appropriate 
        // value. See also method: lstChallengeID_SelectedIndexChange. If the user tries to manually arrow off the
        // table it catches an exception which stops them from going further.
        private void updateCM()
        {
            try
            { 
                cmEvent.Position = DM.eventView.Find(DM.dtChallenge.Rows[cmChallenge.Position]["EventID"]);
            }
            catch (IndexOutOfRangeException ex)
            {
                --currencyManager.Position;
            }
        }

        // This method updates the EventName variable as the value of the EventID changes within the form.
        private void lstEventName_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCM();
        }
    }
}
