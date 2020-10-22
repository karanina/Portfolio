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
    public partial class EventMaintenanceForm : Form
    {
        // This is the reference to the DataModule object.
        private DataModule DM;

        // This is the reference to the MainForm object.
        private MainForm frmMenu;

        // This is the reference to the CurrencyManager object for the Event table.
        private CurrencyManager currencyManager;

        // This is the reference to the CurrencyManager object for the Arena table.
        private CurrencyManager cmArena;

        // This is the constructor method which takes in the DataModule and MainForm objects as parameters
        // and enacts the BindControls method to bind the data in the Event table to the appropriate text boxes
        // and list field.
        public EventMaintenanceForm(DataModule dm, MainForm mnu)
        {
            InitializeComponent();
            DM = dm;
            frmMenu = mnu;
            BindControls();
        }

        // This method binds the data in the Event and Arena tables to the appropriate text boxes and the list field.
        public void BindControls()
        {            
            txtEventID.DataBindings.Add("Text", DM.dsNZESL, "Event.EventID");
            txtEventName.DataBindings.Add("Text", DM.dsNZESL, "Event.EventName");
            txtEventArenaID.DataBindings.Add("Text", DM.dsNZESL, "Event.ArenaID");
            txtEventArenaName.DataBindings.Add("Text", DM.dsNZESL, "Arena.ArenaName");
            txtEventStatus.DataBindings.Add("Text", DM.dsNZESL, "Event.Status");
            txtEventCapacity.DataBindings.Add("Text", DM.dsNZESL, "Event.Capacity");
            datEventDate.DataBindings.Add("Text", DM.dsNZESL, "Event.EventDate");
            comAddEventArenaID.DataSource = DM.dsNZESL;
            comAddEventArenaID.DisplayMember = "Arena.ArenaID";
            comAddEventArenaName.DataSource = DM.dsNZESL;
            comAddEventArenaName.DisplayMember = "Arena.ArenaName";
            txtUpdateEventID.DataBindings.Add("Text", DM.dsNZESL, "Event.EventID");
            txtUpdateEventName.DataBindings.Add("Text", DM.dsNZESL, "Event.EventName");
            txtUpdateEventArenaID.DataBindings.Add("Text", DM.dsNZESL, "Event.ArenaID");
            txtUpdateEventArenaName.DataBindings.Add("Text", DM.dsNZESL, "Arena.ArenaName");
            numUpdateEventCapacity.DataBindings.Add("Value", DM.dsNZESL, "Event.Capacity");
            comUpdateEventStatus.DataBindings.Add("Text", DM.dsNZESL, "Event.Status");
            datUpdateEventDate.DataBindings.Add("Text", DM.dsNZESL, "Event.EventDate");
            lstEventName.DataSource = DM.dsNZESL;
            lstEventName.DisplayMember = "Event.EventName";
            lstEventName.ValueMember = "Event.EventName";
            currencyManager = (CurrencyManager)this.BindingContext[DM.dsNZESL, "EVENT"];
            cmArena = (CurrencyManager)this.BindingContext[DM.dsNZESL, "ARENA"];            
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
        // This is a button click method that displays the Add Event panel and hides the Event Name list box, 
        // and the labels and text boxes next to it. It disables the Previous, Next, Update Event, Delete Event, 
        // and Return buttons.
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            lblEventID.Hide();
            lstEventName.Hide();
            lblEventName.Hide();
            lblEventArenaID.Hide();
            lblEventArenaName.Hide();
            lblEventStatus.Hide();
            lblEventCapacity.Hide();
            lblEventDate.Hide();
            txtEventID.Hide();
            txtEventName.Hide();
            txtEventArenaID.Hide();
            txtEventArenaName.Hide();
            txtEventStatus.Hide();
            txtEventCapacity.Hide();
            datEventDate.Hide();
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnUpdateEvent.Enabled = false;
            btnDeleteEvent.Enabled = false;
            btnReturn.Enabled = false;
            pnlAddEvent.Show();
            datAddEventDate.Value = DateTime.Now;

        }

        // This is a button click method that validates and saves the new Event details, entered into the Add Event 
        // panel, into the database. If the data is invalid, it gives an error message. It then hides the Add Event 
        // panel, and shows the previously hidden text boxes, labels and the list box, and re-enables the buttons.
        private void btnSaveMeeting_Click(object sender, EventArgs e)
        {
            DataRow newEventRow = DM.dtEvent.NewRow();
            if ((txtAddEventName.Text == "") || (comAddEventArenaID.Text == "") || (comAddEventStatus.Text == "")
                || (datAddEventDate.Text == ""))
            {
                MessageBox.Show("Please fill in all fields", "Error");
            }
            else if (numAddEventCapacity.Value < 100)
            {
                MessageBox.Show("The minimum capacity for an event is 100 people.", "Error");
            }
            else
            {
                newEventRow["EventName"] = txtAddEventName.Text;
                newEventRow["ArenaID"] = comAddEventArenaID.Text;
                newEventRow["Status"] = comAddEventStatus.Text;
                newEventRow["Capacity"] = numAddEventCapacity.Text;
                newEventRow["EventDate"] = datAddEventDate.Text;
                DM.dtEvent.Rows.Add(newEventRow);
                DM.UpdateEvent();
                currencyManager.EndCurrentEdit();
                MessageBox.Show("Event added successfully", "Success");
                lstEventName.Show();
                lblEventID.Show();
                lblEventName.Show();
                lblEventArenaID.Show();
                lblEventArenaName.Show();
                lblEventStatus.Show();
                lblEventCapacity.Show();
                lblEventDate.Show();
                txtEventID.Show();
                txtEventName.Show();
                txtEventArenaID.Show();
                txtEventArenaName.Show();
                txtEventStatus.Show();
                txtEventCapacity.Show();
                datEventDate.Show();
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnUpdateEvent.Enabled = true;
                btnDeleteEvent.Enabled = true;
                btnReturn.Enabled = true;
                pnlAddEvent.Hide();
                txtAddEventName.Text = "";
                comAddEventArenaID.Text = "";
                comAddEventStatus.Text = "";
            }
        }

        // This button method returns the user to the Event form without saving any inputed data into the database.
        // It hides the Add Event panel, shows the previously hidden labels, text fields and list box and re-enables
        // the buttons.
        private void btnCancelAddEvent_Click(object sender, EventArgs e)
        {
            lblEventID.Show();
            lstEventName.Show();
            lblEventName.Show();
            lblEventArenaID.Show();
            lblEventArenaName.Show();
            lblEventStatus.Show();
            lblEventCapacity.Show();
            lblEventDate.Show();
            txtEventID.Show();
            txtEventName.Show();
            txtEventArenaID.Show();
            txtEventArenaName.Show();
            txtEventStatus.Show();
            txtEventCapacity.Show();
            datEventDate.Show();
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnUpdateEvent.Enabled = true;
            btnDeleteEvent.Enabled = true;
            btnReturn.Enabled = true;
            pnlAddEvent.Hide();
            txtAddEventName.Text = "";
            comAddEventArenaID.Text = "";
            comAddEventArenaName.Text = "";
            comAddEventStatus.Text = "";
        }

        // This button click method displays the Update Event panel and hides the Event Name list box, and the 
        // labels and text boxes next to it. It disables the Previous, Next, Add Event, Delete Event, and Return 
        // buttons.
        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            lstEventName.Hide();
            lblEventID.Hide();
            lblEventName.Hide();
            lblEventArenaID.Hide();
            lblEventArenaName.Hide(); ;
            lblEventStatus.Hide();
            lblEventCapacity.Hide();
            lblEventDate.Hide();
            txtEventID.Hide();
            txtEventName.Hide();
            txtEventArenaID.Hide();
            txtEventArenaName.Hide();
            txtEventStatus.Hide();
            txtEventCapacity.Hide();
            datEventDate.Hide();
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnAddEvent.Enabled = false;
            btnDeleteEvent.Enabled = false;
            btnReturn.Enabled = false;
            pnlUpdateEvent.Show();
        }

        // This button click method validates and saves the new Event details, entered into the Updat Event 
        // panel, into the database. If the data is invalid, it gives an error message. It then hides the Update Event 
        // panel, and shows the previously hidden text boxes, labels and the list box, and re-enables the buttons.
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            DataRow updateEventRow = DM.dtEvent.Rows[currencyManager.Position];
            if ((txtUpdateEventName.Text == "") || (comUpdateEventStatus.Text == "") || (datUpdateEventDate.Text == ""))
            {
                MessageBox.Show("Please fill in all fields", "Error");
            }
            else if (numUpdateEventCapacity.Value < 100)
            {
                MessageBox.Show("The minimum capacity for an event is 100 people.", "Error");
            }
            else
            {
                updateEventRow["EventName"] = txtUpdateEventName.Text;
                updateEventRow["Status"] = comUpdateEventStatus.Text;
                updateEventRow["Capacity"] = numUpdateEventCapacity.Value;
                updateEventRow["EventDate"] = datUpdateEventDate.Text;
                DM.UpdateEvent();
                currencyManager.EndCurrentEdit();
                MessageBox.Show("Event updated successfully", "Success");
                lstEventName.Show();
                lblEventID.Show();
                lblEventName.Show();
                lblEventArenaID.Show();
                lblEventArenaName.Show();
                lblEventStatus.Show();
                lblEventCapacity.Show();
                lblEventDate.Show();
                txtEventID.Show();
                txtEventName.Show();
                txtEventArenaID.Show();
                txtEventArenaName.Show();
                txtEventStatus.Show();
                txtEventCapacity.Show();
                datEventDate.Show();
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnAddEvent.Enabled = true;
                btnDeleteEvent.Enabled = true;
                btnReturn.Enabled = true;
                pnlUpdateEvent.Hide();
            }
        }
        // This button click method returns the user to the Event form without saving any inputed data into the database.
        // It hides the Update Event panel, shows the previously hidden labels, text fields and list box and re-enables
        // the buttons.
        private void btnCancelUpdateEvent_Click(object sender, EventArgs e)
        {
            lstEventName.Show();
            lblEventID.Show();
            lblEventName.Show();
            lblEventArenaID.Show();
            lblEventArenaName.Show();
            lblEventStatus.Show();
            lblEventCapacity.Show();
            lblEventDate.Show();
            txtEventID.Show();
            txtEventName.Show();
            txtEventArenaID.Show();
            txtEventArenaName.Show();
            txtEventStatus.Show();
            txtEventCapacity.Show();
            datEventDate.Show();
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnAddEvent.Enabled = true;
            btnDeleteEvent.Enabled = true;
            btnReturn.Enabled = true;
            pnlUpdateEvent.Hide();
        }
        // This button click method deletes an event from the database if it does not have any challenges associated
        // with it.
        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            DataRow deleteEventRow = DM.dtEvent.Rows[currencyManager.Position];
            DataRow[] challengeRow = DM.dtChallenge.Select("EventID = " + txtEventID.Text);
            if (challengeRow.Length != 0)
            {
                MessageBox.Show("You may only delete events that have no challenges", "Error");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this event?", "Warning",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    deleteEventRow.Delete();
                    MessageBox.Show("Event deleted successfully", "Success");
                    DM.UpdateEvent();
                    currencyManager.EndCurrentEdit();
                }
            }
        }

        // This is a button click method which closes the Event Maintenance form and returns the user to the 
        // main form.
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        // This method changes the currency manager's position within the arenaView as the ArenaID is changed within
        // the Event data table, so that any variable in the Event table may be synced up to the appropriate 
        // value. See also method: lstEventName_SelectedIndexChange.
        private void updateCM()
        {
            cmArena.Position = DM.arenaView.Find(DM.dtEvent.Rows[currencyManager.Position]["ArenaID"]);
        }

        // This method updates the ArenaName variable as the value of the ArenaID changes within the form.
        private void lstEventName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currencyManager != null && cmArena != null)
            {
                updateCM();
            }
        }              
    }
}
