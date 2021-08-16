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
    public partial class ArenaMaintenanceForm : Form
    {
        // This is the reference to the DataModule object.
        private DataModule DM;

        // This is the reference to the MainForm object.
        private MainForm frmMenu;

        // This is the reference to a CurrencyManager object.
        private CurrencyManager currencyManager;

        // This is the constructor method which takes in the DataModule and MainForm objects as parameters
        // and enacts the BindControls method to bind the data in the Arena table to the appropriate text boxes
        // and list field.
        public ArenaMaintenanceForm(DataModule dm, MainForm mnu)
        {
            InitializeComponent();
            DM = dm;
            frmMenu = mnu;
            BindControls();
        }

        // This method binds the data in the Arena table to the appropriate text boxes and the list field.
        public void BindControls()
        {
            txtArenaID.DataBindings.Add("Text", DM.dsNZESL, "Arena.ArenaID");
            txtArenaName.DataBindings.Add("Text", DM.dsNZESL, "Arena.ArenaName");
            txtStreetAddress.DataBindings.Add("Text", DM.dsNZESL, "Arena.StreetAddress");
            txtSuburb.DataBindings.Add("Text", DM.dsNZESL, "Arena.Suburb");
            txtCity.DataBindings.Add("Text", DM.dsNZESL, "Arena.City");
            txtPhoneNumber.DataBindings.Add("Text", DM.dsNZESL, "Arena.PhoneNumber");
            txtUpdateArenaName.DataBindings.Add("Text", DM.dsNZESL, "Arena.ArenaName");
            txtUpdateStreetAddress.DataBindings.Add("Text", DM.dsNZESL, "Arena.StreetAddress");
            txtUpdateSuburb.DataBindings.Add("Text", DM.dsNZESL, "Arena.Suburb");
            comUpdateCity.DataBindings.Add("Text", DM.dsNZESL, "Arena.City");
            txtUpdatePhoneNumber.DataBindings.Add("Text", DM.dsNZESL, "Arena.PhoneNumber");
            lstArenaName.DataSource = DM.dsNZESL;
            lstArenaName.DisplayMember = "Arena.ArenaName";
            lstArenaName.ValueMember = "Arena.ArenaName";
            currencyManager = (CurrencyManager)this.BindingContext[DM.dsNZESL, "ARENA"];
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
        // This is a button click method that displays the Add Arena panel and hides the Arena Name list box, 
        // and the labels and text boxes next to it. It disables the Previous, Next, Update Arena, Delete Arena, 
        // and Return buttons.
        private void btnAddArena_Click(object sender, EventArgs e)
        {
            lstArenaName.Hide();
            lblArenaID.Hide();
            lblArenaName.Hide();
            lblStreetAddress.Hide(); ;
            lblSuburb.Hide();
            lblCity.Hide();
            lblPhoneNumber.Hide();
            txtArenaID.Hide();
            txtArenaName.Hide();
            txtStreetAddress.Hide();
            txtSuburb.Hide();
            txtCity.Hide();
            txtPhoneNumber.Hide();
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnUpdateArena.Enabled = false;
            btnDeleteArena.Enabled = false;
            btnReturn.Enabled = false;
            pnlAddArena.Show();
        }

        // This is a button click method that validates and saves the new arena details, entered into the Add Arena 
        // panel, into the database. If the data is invalid, it gives an error message. It then hides the Add Arena 
        // panel, and shows the previously hidden text boxes, labels and the list box, and re-enables the buttons.
        // Finally, it removes the information from the Add Arena panel's text fields so that if the user 
        // wishes to add another new arena, they won't need to erase the previous data from the text fields.
        private void btnSaveArena_Click(object sender, EventArgs e)
        {
            DataRow newArenaRow = DM.dtArena.NewRow();
            if ((txtAddArenaName.Text == "") || (txtAddStreetAddress.Text == "") || (txtAddSuburb.Text == "")
                || (comAddCity.Text == "") || (txtAddPhoneNumber.Text == ""))
            {
                MessageBox.Show("Please fill in all fields", "Error");
            }
            else
            { 
                newArenaRow["ArenaName"] = txtAddArenaName.Text;
                newArenaRow["StreetAddress"] = txtAddStreetAddress.Text;
                newArenaRow["Suburb"] = txtAddSuburb.Text;
                newArenaRow["City"] = comAddCity.Text;
                newArenaRow["PhoneNumber"] = txtAddPhoneNumber.Text;              
                DM.dtArena.Rows.Add(newArenaRow);
                MessageBox.Show("Arena added successfully", "Success");
                DM.UpdateArena();
                currencyManager.EndCurrentEdit();
                lstArenaName.Show();
                lblArenaID.Show();
                lblArenaName.Show();
                lblStreetAddress.Show();
                lblSuburb.Show();
                lblCity.Show();
                lblPhoneNumber.Show();
                txtArenaID.Show();
                txtArenaName.Show();
                txtStreetAddress.Show();
                txtSuburb.Show();
                txtCity.Show();
                txtPhoneNumber.Show();
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnUpdateArena.Enabled = true;
                btnDeleteArena.Enabled = true;
                btnReturn.Enabled = true;
                pnlAddArena.Hide();
                txtAddArenaName.Text = "";
                txtAddStreetAddress.Text = "";
                txtAddSuburb.Text = "";
                txtAddPhoneNumber.Text = "";
            }
        }

        // This button click method returns the user to the Add Arena form without saving any inputed data into the 
        // database. It hides the Add Arena panel, shows the previously hidden labels, text fields and list box and 
        // re-enables the buttons. It also removes the information from the Add Arena panel's text fields so that if  
        // the user wishes to add another new arena, they won't need to erase the previous data from the text fields.
        private void btnCancelAddArena_Click(object sender, EventArgs e)
        {
            lstArenaName.Show();
            lblArenaID.Show();
            lblArenaName.Show();
            lblStreetAddress.Show();
            lblSuburb.Show();
            lblCity.Show();
            lblPhoneNumber.Show();
            txtArenaID.Show();
            txtArenaName.Show();
            txtStreetAddress.Show();
            txtSuburb.Show();
            txtCity.Show();
            txtPhoneNumber.Show();
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnUpdateArena.Enabled = true;
            btnDeleteArena.Enabled = true;
            btnReturn.Enabled = true;
            pnlAddArena.Hide();
            txtAddArenaName.Text = "";
            txtAddStreetAddress.Text = "";
            txtAddSuburb.Text = "";
            txtAddPhoneNumber.Text = "";
        }

        // This is a button click method that displays the Update Arena panel and hides the Arena Name list box, and 
        // the labels and text boxes next to it. It disables the Previous, Next, Add Arena, Delete Arena, and Return 
        // buttons.
        private void btnUpdateArena_Click(object sender, EventArgs e)
        {
            lstArenaName.Hide();
            lblArenaID.Hide();
            lblArenaName.Hide();
            lblStreetAddress.Hide(); ;
            lblSuburb.Hide();
            lblCity.Hide();
            lblPhoneNumber.Hide();
            txtArenaID.Hide();
            txtArenaName.Hide();
            txtStreetAddress.Hide();
            txtSuburb.Hide();
            txtCity.Hide();
            txtPhoneNumber.Hide();
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnAddArena.Enabled = false;
            btnDeleteArena.Enabled = false;
            btnReturn.Enabled = false;
            pnlUpdateArena.Show();
        }

        // This is a button click method that validates and updates the Arena details, entered into the Update Arena 
        // panel, into the database. If the data is invalid, it gives an error message. It then hides the Update 
        // panel, and shows the previously hidden text boxes, labels and the list box, and re-enables the buttons.
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            DataRow updateArenaRow = DM.dtArena.Rows[currencyManager.Position];
            if ((txtUpdateArenaName.Text == "") || (txtUpdateStreetAddress.Text == "") || (txtUpdateSuburb.Text == "")
                || (comUpdateCity.Text == "") || (txtUpdatePhoneNumber.Text == ""))
            {
                MessageBox.Show("Please fill in all fields", "Error");
            }
            else
            {
                updateArenaRow["ArenaName"] = txtUpdateArenaName.Text;
                updateArenaRow["StreetAddress"] = txtUpdateStreetAddress.Text;
                updateArenaRow["Suburb"] = txtUpdateSuburb.Text;
                updateArenaRow["City"] = comUpdateCity.Text;
                updateArenaRow["PhoneNumber"] = txtUpdatePhoneNumber.Text;
                MessageBox.Show("Arena updated successfully", "Success");
                DM.UpdateArena();
                currencyManager.EndCurrentEdit();
                lstArenaName.Show();
                lblArenaID.Show();
                lblArenaName.Show();
                lblStreetAddress.Show();
                lblSuburb.Show();
                lblCity.Show();
                lblPhoneNumber.Show();
                txtArenaID.Show();
                txtArenaName.Show();
                txtStreetAddress.Show();
                txtSuburb.Show();
                txtCity.Show();
                txtPhoneNumber.Show();
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnAddArena.Enabled = true;
                btnDeleteArena.Enabled = true;
                btnReturn.Enabled = true;
                pnlUpdateArena.Hide();             
            }
        }

        // This button click method returns the user to the Add Arena form without saving any updated data into the 
        // database. It hides the Update Arena panel, shows the previously hidden labels, text fields and list box and 
        // re-enables the buttons.
        private void btnCancelUpdateArena_Click(object sender, EventArgs e)
        {
            lstArenaName.Show();
            lblArenaID.Show();
            lblArenaName.Show();
            lblStreetAddress.Show();
            lblSuburb.Show();
            lblCity.Show();
            lblPhoneNumber.Show();
            txtArenaID.Show();
            txtArenaName.Show();
            txtStreetAddress.Show();
            txtSuburb.Show();
            txtCity.Show();
            txtPhoneNumber.Show();
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnAddArena.Enabled = true;
            btnDeleteArena.Enabled = true;
            btnReturn.Enabled = true;
            pnlUpdateArena.Hide();
        }

        // This is a button click method that deletes an Arena from the database if it does not host any events.
        private void btnDeleteArena_Click (object sender, EventArgs e)
        {
            DataRow deleteArenaRow = DM.dtArena.Rows[currencyManager.Position];
            DataRow[] eventRow = DM.dtEvent.Select("ArenaID = " + txtArenaID.Text);
            if (eventRow.Length != 0)
            {
                MessageBox.Show("You may only delete arenas that have no events", "Error");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this arena record?", "Warning",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    deleteArenaRow.Delete();
                    DM.UpdateArena();
                    currencyManager.EndCurrentEdit();
                    MessageBox.Show("Arena deleted successfully", "Success");
                }
            }
        }

        // This is a button click method which closes the Arena Maintenance form and returns the user to the 
        // Main form.
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
