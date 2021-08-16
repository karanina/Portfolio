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
    public partial class ChallengeMaintenanceForm : Form
    {
        // This is the reference to the DataModule object.
        private DataModule DM;

        // This is the reference to the MainForm object.
        private MainForm frmMenu;

        // This is the reference to the CurrencyManager object.
        private CurrencyManager currencyManager;

        // This creates a Currency Manager object to point to data in the Event table as it relates to entries in the
        // Challenge table. 
        CurrencyManager cmEvent;

        // This creates a Currency Manager object to point to data in the Entry table as it relates to entries in the
        // Challenge table. 
        CurrencyManager cmEntry;

        // This is the constructor method which takes in the DataModule and MainForm objects as arguments
        // and enacts the BindControls method to bind the data in the Challenge table to the appropriate text boxes
        // and list field.
        public ChallengeMaintenanceForm(DataModule dm, MainForm mnu)
        {
            InitializeComponent();
            DM = dm;
            frmMenu = mnu;
            BindControls();
        }

        // This method binds the data in the Challenge and Event tables to the appropriate text boxes and the list 
        // field.
        public void BindControls()
        {
            txtChallengeID.DataBindings.Add("Text", DM.dsNZESL, "Challenge.ChallengeID");
            txtChallengeName.DataBindings.Add("Text", DM.dsNZESL, "Challenge.ChallengeName");
            txtEventID.DataBindings.Add("Text", DM.dsNZESL, "Challenge.EventID");
            txtEventName.DataBindings.Add("Text", DM.dsNZESL, "Event.EventName");
            datStartTime.DataBindings.Add("Text", DM.dsNZESL, "Challenge.StartTime");
            txtStatus.DataBindings.Add("Text", DM.dsNZESL, "Challenge.Status");
            txtCapacity.DataBindings.Add("Text", DM.dsNZESL, "Challenge.Capacity");
            txtUpdateChallengeID.DataBindings.Add("Text", DM.dsNZESL, "Challenge.ChallengeID");
            txtUpdateChallengeName.DataBindings.Add("Text", DM.dsNZESL, "Challenge.ChallengeName");
            comAddEventID.DataSource = DM.dsNZESL;
            comAddEventID.DisplayMember = "Event.EventID";
            comAddEventName.DataSource = DM.dsNZESL;
            comAddEventName.DisplayMember = "Event.EventName";
            txtUpdateEventName.DataBindings.Add("Text", DM.dsNZESL, "Event.EventName");
            datUpdateStartTime.DataBindings.Add("Text", DM.dsNZESL, "Challenge.StartTime");
            comUpdateStatus.DataBindings.Add("Text", DM.dsNZESL, "Challenge.Status");
            numUpdateCapacity.DataBindings.Add("Value", DM.dsNZESL, "Challenge.Capacity");
            lstChallengeID.DataSource = DM.dsNZESL;
            lstChallengeID.DisplayMember = "Challenge.ChallengeID";
            lstChallengeID.ValueMember = "Challenge.ChallengeID";
            currencyManager = (CurrencyManager)this.BindingContext[DM.dsNZESL, "CHALLENGE"];
            cmEvent = (CurrencyManager)this.BindingContext[DM.dsNZESL, "EVENT"];
            cmEntry = (CurrencyManager)this.BindingContext[DM.dsNZESL, "ENTRY"];
        }
               
        // This is a button click method which selects the previous entry in the list box.
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currencyManager.Position > 0)
            {
                --currencyManager.Position;
            }
        }

        // This is a button click method which selects the next entry in the list box.
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currencyManager.Position < currencyManager.Count - 1)
            {
                ++currencyManager.Position;
            }
        }

        // This button click method disables all buttons except the Add Challenge button, hides the Challenge ID list, 
        // and labels and text boxes next to it, and opens the panel for adding a challenge.
        private void btnAddChallenge_Click(object sender, EventArgs e)
        {
            lstChallengeID.Hide();
            lblChallengeID.Hide();
            lblChallengeName.Hide();
            lblEventID.Hide();
            lblEventName.Hide();
            lblStartTime.Hide();
            lblStatus.Hide();
            lblCapacity.Hide();
            txtChallengeID.Hide();
            txtChallengeName.Hide();
            txtEventID.Hide();
            txtEventName.Hide();
            datStartTime.Hide();
            txtStatus.Hide();
            txtCapacity.Hide();
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnUpdateChallenge.Enabled = false;
            btnDeleteChallenge.Enabled = false;
            btnChallengeFinished.Enabled = false;
            btnChallengeComplete.Enabled = false;
            btnReturn.Enabled = false;
            pnlAddChallenge.Show();
        }

        // This is a button click method that validates and saves the new challenge details, entered into the Add  
        // Challenge panel, into the database. If the data is invalid, it gives an error message. It then hides the Add
        // Challenge panel, and shows the previously hidden text boxes, labels and the list box, and re-enables the
        // buttons. Finally, it removes the information from the Add Challenge panel's text fields so that if the user 
        // wishes to add another new challenge, they won't need to erase the previous data from the text fields.
        private void btnSaveAddChallenge_Click(object sender, EventArgs e)
        {
            DataRow newChallengeRow = DM.dtChallenge.NewRow();

            {
                if ((txtAddChallengeName.Text == "") || (comAddEventID.Text == "") || (comAddEventName.Text == "") ||
                    (datAddStartTime.Text == "") || (comAddEventStatus.Text == "") || (numAddCapacity.Value == 0))
                {
                    MessageBox.Show("Please fill in all fields", "Error");
                }
                else
                {
                    newChallengeRow["ChallengeName"] = txtAddChallengeName.Text;
                    newChallengeRow["StartTime"] = datAddStartTime.Text;
                    newChallengeRow["EventID"] = comAddEventID.Text;
                    newChallengeRow["Status"] = comAddEventStatus.Text;
                    newChallengeRow["Capacity"] = Convert.ToInt32(numAddCapacity.Value);
                    DM.dtChallenge.Rows.Add(newChallengeRow);
                    DM.UpdateChallenge();
                    currencyManager.EndCurrentEdit();
                    MessageBox.Show("Challenge added successfully", "Success");
                    lstChallengeID.Show();
                    lblChallengeID.Show();
                    lblChallengeName.Show();
                    lblEventID.Show();
                    lblEventName.Show();
                    lblStartTime.Show();
                    lblStatus.Show();
                    lblCapacity.Show();
                    txtChallengeID.Show();
                    txtChallengeName.Show();
                    txtEventID.Show();
                    txtEventName.Show();
                    datStartTime.Show();
                    txtStatus.Show();
                    txtCapacity.Show();
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    btnUpdateChallenge.Enabled = true;
                    btnDeleteChallenge.Enabled = true;
                    btnChallengeFinished.Enabled = true;
                    btnChallengeComplete.Enabled = true;
                    btnReturn.Enabled = true;
                    pnlAddChallenge.Hide();
                    txtAddChallengeName.Text = "";
                    numAddCapacity.Value = 1;
                }
            }
        }

        // This button click method returns the user to the Challenge Maintenance form without saving any inputed 
        // data into the database. It hides the Add Challenge panel, shows the previously hidden labels, text fields 
        // and list box and re-enables the buttons. It also removes the information from the Add Challenge panel's 
        // input fields so that if the user wishes to add another new challenge, they won't need to erase the previous 
        // data from the input fields.
        private void btnCancelAddChallenge_Click(object sender, EventArgs e)
        {
            lstChallengeID.Show();
            lblChallengeID.Show();
            lblChallengeName.Show();
            lblEventID.Show();
            lblEventName.Show();
            lblStartTime.Show();
            lblStatus.Show();
            lblCapacity.Show();
            txtChallengeID.Show();
            txtChallengeName.Show();
            txtEventID.Show();
            txtEventName.Show();
            datStartTime.Show();
            txtStatus.Show();
            txtCapacity.Show();
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnUpdateChallenge.Enabled = true;
            btnDeleteChallenge.Enabled = true;
            btnChallengeFinished.Enabled = true;
            btnChallengeComplete.Enabled = true;
            btnReturn.Enabled = true;
            pnlAddChallenge.Hide();
        }

        // This button click method disables all buttons except the Update Challenge button, hides the Challenge ID 
        // list, and labels and text boxes next to it, and opens the panel for updating a challenge.
        private void btnUpdateChallenge_Click(object sender, EventArgs e)
        {
            lstChallengeID.Hide();
            lblChallengeID.Hide();
            lblChallengeName.Hide();
            lblEventID.Hide();
            lblEventName.Hide();
            lblStartTime.Hide();
            lblStatus.Hide();
            lblCapacity.Hide();
            txtChallengeID.Hide();
            txtChallengeName.Hide();
            txtEventID.Hide();
            txtEventName.Hide();
            datStartTime.Hide();
            txtStatus.Hide();
            txtCapacity.Hide();
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnAddChallenge.Enabled = false;
            btnDeleteChallenge.Enabled = false;
            btnChallengeFinished.Enabled = false;
            btnChallengeComplete.Enabled = false;
            btnReturn.Enabled = false;
            pnlUpdateChallenge.Show();
        }

        // This is a button click method that validates and saves the any changes to the challenge details, into the 
        // database. If the data is invalid, it gives an error message. It then hides the Update Challenge panel, and 
        // shows the previously hidden text boxes, labels and the list box, and re-enables the buttons.
        private void btnSaveUpdateChallenge_Click(object sender, EventArgs e)
        {
            DataRow updateChallengeRow = DM.dtChallenge.Rows[currencyManager.Position];
            if ((txtUpdateChallengeName.Text == "") || (datUpdateStartTime.Text == "") || (numUpdateCapacity.Text == ""))
            {
                MessageBox.Show("Please fill in all fields", "Error");
            }
            else
            {
                updateChallengeRow["ChallengeName"] = txtUpdateChallengeName.Text;
                updateChallengeRow["StartTime"] = datUpdateStartTime.Text;
                updateChallengeRow["Capacity"] = Convert.ToInt32(numUpdateCapacity.Value);
                currencyManager.EndCurrentEdit();
                DM.UpdateChallenge();
                MessageBox.Show("Challenge updated successfully", "Success");
                lstChallengeID.Show();
                lblChallengeID.Show();
                lblChallengeName.Show();
                lblEventID.Show();
                lblEventName.Show();
                lblStartTime.Show();
                lblStatus.Show();
                lblCapacity.Show();
                txtChallengeID.Show();
                txtChallengeName.Show();
                txtEventID.Show();
                txtEventName.Show();
                datStartTime.Show();
                txtStatus.Show();
                txtCapacity.Show();
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnAddChallenge.Enabled = true;
                btnDeleteChallenge.Enabled = true;
                btnChallengeFinished.Enabled = true;
                btnChallengeComplete.Enabled = true;
                btnReturn.Enabled = true;
                pnlUpdateChallenge.Hide();
            }
        }

        // This button click method returns the user to the Challenge Maintenance form without saving any inputed 
        // data into the database. It hides the Update Challenge panel, shows the previously hidden labels, text 
        // fields and list box and re-enables the buttons.
        private void btnCancelUpdateChallenge_Click(object sender, EventArgs e)
        {
            lstChallengeID.Show();
            lblChallengeID.Show();
            lblChallengeName.Show();
            lblEventID.Show();
            lblEventName.Show();
            lblStartTime.Show();
            lblStatus.Show();
            lblCapacity.Show();
            txtChallengeID.Show();
            txtChallengeName.Show();
            txtEventID.Show();
            txtEventName.Show();
            datStartTime.Show();
            txtStatus.Show();
            txtCapacity.Show();
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnAddChallenge.Enabled = true;
            btnDeleteChallenge.Enabled = true;
            btnChallengeFinished.Enabled = true;
            btnChallengeComplete.Enabled = true;
            btnReturn.Enabled = true;
            pnlUpdateChallenge.Hide();
        }

        // This button click method deletes a challenge from the database if it does not have any entries.
        private void btnDeleteChallenge_Click(object sender, EventArgs e)
        {
            DataRow deleteChallengeRow = DM.dtChallenge.Rows[currencyManager.Position];
            DataRow[] entryRow = DM.dtEntry.Select("ChallengeID = " + txtChallengeID.Text);
            if (entryRow.Length != 0)
            {
                MessageBox.Show("You may only delete a challenge that has no entries", "Error");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this challenge record?", "Warning",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    deleteChallengeRow.Delete();
                    MessageBox.Show("Challenge deleted successfully", "Success");
                    DM.UpdateChallenge();
                    currencyManager.EndCurrentEdit();
                }
            }
        }
        
        // This button click method changes a challenge status to "Finished" if it was previously "Scheduled".
        private void btnMarkChallengeFinished_Click(object sender, EventArgs e)
        {
            DataRow updateChallengeRow = DM.dtChallenge.Rows[currencyManager.Position];
            if (txtStatus.Text == "Scheduled")
            {
                updateChallengeRow["Status"] = "Finished";
                DM.UpdateChallenge();
                currencyManager.EndCurrentEdit();
                MessageBox.Show("Challenge marked as finished", "Success");
            }
            else
            { 
                MessageBox.Show("Only scheduled challenges can be marked as finished", "Error");
            }
       }

        // This button click method changes a challenge status to "Completed" if it was previously "Finished" and 
        // deletes any entries it may have from the Entry table.
        private void btnMarkChallengeCompleted_Click(object sender, EventArgs e)
        {
            DataRow updateChallengeRow = DM.dtChallenge.Rows[currencyManager.Position];
            if (txtStatus.Text == "Finished")
            {
                updateChallengeRow["Status"] = "Completed";
                DataRow[] drChallengeEntries = DM.dtEntry.Select("ChallengeID = " + txtChallengeID.Text);
                
                // Deletes any entries for the challenge from the Entry table.
                foreach (DataRow competitorEntry in drChallengeEntries)
                {
                    competitorEntry.Delete();
                    DM.UpdateEntry();
                    cmEntry.EndCurrentEdit();
                }
                DM.UpdateChallenge();
                currencyManager.EndCurrentEdit();
                MessageBox.Show("Challenge marked as complete", "Success");
            }
            else
            {
                MessageBox.Show("Only finished challenges can be marked as completed", "Error");
            }
        }
        
        // This is a button click method which closes the Challenge Maintenance form and returns the user to the 
        // main form.
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        // This method changes the currency manager's position within the eventView as the EventID is changed within
        // the Challenge data table, so that any variable in the Event table may be synced up to the appropriate 
        // value. See also method: lstChallengeID_SelectedIndexChange.
        private void updateCM()
        {
            cmEvent.Position = DM.eventView.Find(DM.dtChallenge.Rows[currencyManager.Position]["EventID"]);
        }

        // This method updates the EventName variable as the value of the EventID changes within the form.
        private void lstChallengeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currencyManager != null && cmEvent != null)
            {
                updateCM();
            }
        }             
    }
}
