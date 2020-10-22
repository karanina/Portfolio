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
    public partial class CompetitorMaintenanceForm : Form
    {
        // This is the reference to the DataModule object.
        private DataModule DM;

        // This is the reference to the MainForm object.
        private MainForm frmMenu;

        // This is the reference to the CurrencyManager object.
        private CurrencyManager currencyManager;

        // This is the constructor method which takes in the DataModule and MainForm objects as parameters
        // and enacts the BindControls method to bind the data in the Competitor table to the appropriate text boxes
        // and list field.
        public CompetitorMaintenanceForm(DataModule dm, MainForm mnu)
        {
            InitializeComponent();
            DM = dm;
            frmMenu = mnu;
            BindControls();
        }

        // This method binds the data in the Competitor table to the appropriate text boxes and the list field.
        public void BindControls()
        {
            txtCompetitorID.DataBindings.Add("Text", DM.dsNZESL, "Competitor.CompetitorID");
            txtUserName.DataBindings.Add("Text", DM.dsNZESL, "Competitor.UserName");
            txtFirstName.DataBindings.Add("Text", DM.dsNZESL, "Competitor.FirstName");
            txtLastName.DataBindings.Add("Text", DM.dsNZESL, "Competitor.LastName");
            txtGender.DataBindings.Add("Text", DM.dsNZESL, "Competitor.Gender");
            datDateOfBirth.DataBindings.Add("Text", DM.dsNZESL, "Competitor.DateOfBirth");
            txtEmail.DataBindings.Add("Text", DM.dsNZESL, "Competitor.EmailAddress");
            txtUpdateUserName.DataBindings.Add("Text", DM.dsNZESL, "Competitor.UserName");
            txtUpdateFirstName.DataBindings.Add("Text", DM.dsNZESL, "Competitor.FirstName");
            txtUpdateLastName.DataBindings.Add("Text", DM.dsNZESL, "Competitor.LastName");
            comUpdateGender.DataBindings.Add("Text", DM.dsNZESL, "Competitor.Gender");
            datUpdateDateOfBirth.DataBindings.Add("Text", DM.dsNZESL, "Competitor.DateOfBirth");
            txtUpdateEmail.DataBindings.Add("Text", DM.dsNZESL, "Competitor.EmailAddress");
            lstUserName.DataSource = DM.dsNZESL;
            lstUserName.DisplayMember = "Competitor.UserName";
            lstUserName.ValueMember = "Competitor.UserName";
            currencyManager = (CurrencyManager)this.BindingContext[DM.dsNZESL, "COMPETITOR"];
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

        // This button click method disables all buttons except the Add Competitor button, hides the UserName list, 
        // labels and text boxes next to it, and opens the panel for adding a competitor.
        private void btnAddCompetitor_Click(object sender, EventArgs e)
        {
            lstUserName.Hide();
            lblCompetitorID.Hide();
            lblUserName.Hide();
            lblFirstName.Hide();
            lblLastName.Hide();
            lblGender.Hide();
            lblDateOfBirth.Hide();
            lblEmail.Hide();
            txtCompetitorID.Hide();
            txtUserName.Hide();
            txtFirstName.Hide();
            txtLastName.Hide();
            txtGender.Hide();
            datDateOfBirth.Hide();
            txtEmail.Hide();
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnUpdateCompetitor.Enabled = false;
            btnDeleteCompetitor.Enabled = false;
            btnReturn.Enabled = false;
            pnlAddCompetitor.Show();
        }

        // This is a button click method that validates and saves the new competitor details, entered into the Add  
        // Competitor panel, into the database. If the data is invalid, it gives an error message. It then hides the 
        // Add Competitor panel, and shows the previously hidden text boxes, labels and the list box, and re-enables the
        // buttons. Finally, it removes the information from the Add Competitor panel's text fields so that if the user 
        // wishes to add another new competitor, they won't need to erase the previous data from the text fields.
        private void btnSaveAddCompetitor_Click(object sender, EventArgs e)
        {
            DataRow newCompetitorRow = DM.dtCompetitor.NewRow();
            if ((txtAddUserName.Text == "") || (txtAddFirstName.Text == "") || (txtAddLastName.Text == "") ||
               (txtAddEmail.Text == ""))
            {
                MessageBox.Show("Please fill in all fields", "Error");
            }
            else
            {
                    newCompetitorRow["UserName"] = txtAddUserName.Text;
                    newCompetitorRow["FirstName"] = txtAddFirstName.Text;
                    newCompetitorRow["LastName"] = txtAddLastName.Text;
                    newCompetitorRow["Gender"] = comAddGender.Text;
                    newCompetitorRow["DateOfBirth"] = datAddDateOfBirth.Text;
                    newCompetitorRow["EmailAddress"] = txtAddEmail.Text;
                    DM.dtCompetitor.Rows.Add(newCompetitorRow);
                    DM.UpdateCompetitor();
                    currencyManager.EndCurrentEdit();
                    MessageBox.Show("Competitor added successfully", "Success");
                    lstUserName.Show();
                    lblCompetitorID.Show();
                    lblUserName.Show();
                    lblFirstName.Show();
                    lblLastName.Show();
                    lblGender.Show();
                    lblDateOfBirth.Show();
                    lblEmail.Show();
                    txtCompetitorID.Show();
                    txtUserName.Show();
                    txtFirstName.Show();
                    txtLastName.Show();
                    txtGender.Show();
                    datDateOfBirth.Show();
                    txtEmail.Show();
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    btnUpdateCompetitor.Enabled = true;
                    btnDeleteCompetitor.Enabled = true;
                    btnReturn.Enabled = true;
                    pnlAddCompetitor.Hide();
                    txtAddUserName.Text = "";
                    txtAddFirstName.Text = "";
                    txtAddLastName.Text = "";
                    txtAddEmail.Text = "";
            }
        }

        // This button click method returns the user to the Competitor Maintenance form without saving any inputed 
        // data into the database. It hides the Add Competitor panel, shows the previously hidden labels, text fields 
        // and list box and re-enables the buttons. It also removes the information from the Add Competitor panel's 
        // input fields so that if the user wishes to add another new competitor, they won't need to erase the previous 
        // data from the input fields.
        private void btnCancelAddCompetitor_Click(object sender, EventArgs e)
        {
            lstUserName.Show();
            lblCompetitorID.Show();
            lblUserName.Show();
            lblFirstName.Show();
            lblLastName.Show();
            lblGender.Show();
            lblDateOfBirth.Show();
            lblEmail.Show();
            txtCompetitorID.Show();
            txtUserName.Show();
            txtFirstName.Show();
            txtLastName.Show();
            txtGender.Show();
            datDateOfBirth.Show();
            txtEmail.Show();
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnUpdateCompetitor.Enabled = true;
            btnDeleteCompetitor.Enabled = true;
            btnReturn.Enabled = true;
            pnlAddCompetitor.Hide();
            txtAddUserName.Text = "";
            txtAddFirstName.Text = "";
            txtAddLastName.Text = "";
            txtAddEmail.Text = "";
        }

        // This button click method disables all buttons except the Update Competitor button, hides the UserName 
        // list, and labels and text boxes next to it, and opens the panel for updating a competitor.
        private void btnUpdateCompetitor_Click(object sender, EventArgs e)
        {
            lstUserName.Hide();
            lblCompetitorID.Hide();
            lblUserName.Hide();
            lblFirstName.Hide();
            lblLastName.Hide();
            lblGender.Hide();
            lblDateOfBirth.Hide();
            lblEmail.Hide();
            txtCompetitorID.Hide();
            txtUserName.Hide();
            txtFirstName.Hide();
            txtLastName.Hide();
            txtGender.Hide();
            datDateOfBirth.Hide();
            txtEmail.Hide();
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnAddCompetitor.Enabled = false;
            btnDeleteCompetitor.Enabled = false;
            btnReturn.Enabled = false;
            pnlUpdateCompetitor.Show();
        }

        // This is a button click method that validates and saves the any changes to the competitor details, into the 
        // database. If the data is invalid, it gives an error message. It then hides the Update Competitor panel, and 
        // shows the previously hidden text boxes, labels and the list box, and re-enables the buttons.
        private void btnSaveUpdateCompetitor_Click(object sender, EventArgs e)
        {
            DataRow updateCompetitorRow = DM.dtCompetitor.Rows[currencyManager.Position];

            {
                if ((txtUpdateUserName.Text == "") || (txtUpdateFirstName.Text == "") || (txtUpdateLastName.Text == "")
                   || (txtUpdateEmail.Text == ""))
                {
                    MessageBox.Show("Please fill in all fields", "Error");
                }
                else
                {
                    updateCompetitorRow["UserName"] = txtUpdateUserName.Text;
                    updateCompetitorRow["FirstName"] = txtUpdateFirstName.Text;
                    updateCompetitorRow["LastName"] = txtUpdateLastName.Text;
                    updateCompetitorRow["Gender"] = comUpdateGender.Text;
                    updateCompetitorRow["DateOfBirth"] = datUpdateDateOfBirth.Text;
                    updateCompetitorRow["EmailAddress"] = txtUpdateEmail.Text;
                    MessageBox.Show("Competitor updated successfully", "Success");
                    DM.UpdateCompetitor();
                    currencyManager.EndCurrentEdit();
                    lstUserName.Show();
                    lblCompetitorID.Show();
                    lblUserName.Show();
                    lblFirstName.Show();
                    lblLastName.Show();
                    lblGender.Show();
                    lblDateOfBirth.Show();
                    lblEmail.Show();
                    txtCompetitorID.Show();
                    txtUserName.Show();
                    txtFirstName.Show();
                    txtLastName.Show();
                    txtGender.Show();
                    datDateOfBirth.Show();
                    txtEmail.Show();
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    btnAddCompetitor.Enabled = true;
                    btnDeleteCompetitor.Enabled = true;
                    btnReturn.Enabled = true;
                    pnlUpdateCompetitor.Hide();
                }
            }
        }

        // This button click method returns the user to the Competitor Maintenance form without saving any inputed 
        // data into the database. It hides the Update Competitor panel, shows the previously hidden labels, text 
        // fields and list box and re-enables the buttons.
        private void btnCancelUpdateCompetitor_Click(object sender, EventArgs e)
        {
            lstUserName.Show();
            lblCompetitorID.Show();
            lblUserName.Show();
            lblFirstName.Show();
            lblLastName.Show();
            lblGender.Show();
            lblDateOfBirth.Show();
            lblEmail.Show();
            txtCompetitorID.Show();
            txtUserName.Show();
            txtFirstName.Show();
            txtLastName.Show();
            txtGender.Show();
            datDateOfBirth.Show();
            txtEmail.Show();
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnAddCompetitor.Enabled = true;
            btnDeleteCompetitor.Enabled = true;
            btnReturn.Enabled = true;
            pnlUpdateCompetitor.Hide();         
        }
        // This button click method deletes a competitor that has no entries, from the database.
        private void btnDeleteCompetitor_Click(object sender, EventArgs e)
        {
            DataRow deleteCompetitorRow = DM.dtCompetitor.Rows[currencyManager.Position];
            DataRow[] entryRow = DM.dtEntry.Select("CompetitorID = " + txtCompetitorID.Text);
            if (entryRow.Length != 0)
            {
                MessageBox.Show("You may only delete competitors that have no entries", "Error");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this competitor record?", "Warning",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    deleteCompetitorRow.Delete();
                    MessageBox.Show("Competitor deleted successfully", "Success");
                    DM.UpdateCompetitor();
                    currencyManager.EndCurrentEdit();
                }
            }
        }

            // This is a button click method which closes the Competitor Maintenance form and returns the user to the 
            // main form.
            private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }      
    }
}
