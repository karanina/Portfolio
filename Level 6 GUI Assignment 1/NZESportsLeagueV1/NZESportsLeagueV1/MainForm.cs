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
    public partial class MainForm : Form
    {
        // This is the reference to the Data Module form which holds the data components.
        private DataModule DM;

        // This is the reference to the Arena Maintenance form.
        private ArenaMaintenanceForm frmArenaMaintenance;

        // This is the reference to the Event Maintenance form.
        private EventMaintenanceForm frmEventMaintenance;

        // This is the reference to the Challenge Maintenance form.
        private ChallengeMaintenanceForm frmChallengeMaintenance;

        // This is the reference to the Competitor Maintenance form.
        private CompetitorMaintenanceForm frmCompetitorMaintenance;

        // This is the reference to the Enter Competitor Into Challenge Form.
        private EnterCompetitorIntoChallengeForm frmEnterCompetitorIntoChallenge;

        // This is the reference to the Events Report form.
        private EventsReportForm frmEventsReport;

        // This is the reference to the Competitor Report form.
        private CompetitorReportForm frmCompetitorReport;

        // This creates the data module and loads the dataset.
        private void MainForm_Load (object sender, EventArgs e)
        {
            DM = new DataModule();
        }

        // This is the constructor method.
        public MainForm()
        {
            InitializeComponent();
        }

        // This is a button click method which creates an ArenaMaintenanceForm object, if none exists, and
        // passes it references to the DataModule and MainForm. 
        private void btnArenaMaintenance_Click (object sender, EventArgs e)
        {
            if (frmArenaMaintenance == null)
            {
                frmArenaMaintenance = new ArenaMaintenanceForm(DM, this);
            }
            frmArenaMaintenance.ShowDialog();
        }

        // This is a button click method which creates an EventMaintenanceForm object, if none exists, and
        // passes it references to the DataModule and MainForm. 
        private void btnEventMaintenance_Click(object sender, EventArgs e)
        {
            if (frmEventMaintenance == null)
            {
                frmEventMaintenance = new EventMaintenanceForm(DM, this);
            }
            frmEventMaintenance.ShowDialog();
        }

        // This is a button click method which creates a ChallengeMaintenanceForm object, if none exists, and
        // passes it references to the DataModule and MainForm. 
        private void btnChallengeMaintenance_Click(object sender, EventArgs e)
        {
            if (frmChallengeMaintenance == null)
            {
                frmChallengeMaintenance = new ChallengeMaintenanceForm(DM, this);
            }
            frmChallengeMaintenance.ShowDialog();
        }

        // This is a button click method which creates a CompetitorMaintenanceForm object, if none exists, and
        // passes it references to the DataModule and MainForm. 
        private void btnCompetitorMaintenance_Click(object sender, EventArgs e)
        {
            if (frmCompetitorMaintenance == null)
            {
                frmCompetitorMaintenance = new CompetitorMaintenanceForm(DM, this);
            }
            frmCompetitorMaintenance.ShowDialog();
        }

        // This is a button click method which creates an EnterCompetitorIntoChallengeForm object, if none exists, and
        // passes it references to the DataModule and MainForm. 
        private void btnEnterCompetitorIntoChallenge_Click(object sender, EventArgs e)
        {
            if (frmEnterCompetitorIntoChallenge == null)
            {
                frmEnterCompetitorIntoChallenge = new EnterCompetitorIntoChallengeForm(DM, this);
            }
            frmEnterCompetitorIntoChallenge.ShowDialog();
        }

        // This is a button click method which creates an EventsReportForm object, if none exists, and
        // passes it references to the DataModule and MainForm. 
        private void btnEventsReport_Click(object sender, EventArgs e)
        {
            if (frmEventsReport == null)
            {
                frmEventsReport = new EventsReportForm(DM, this);
            }
            frmEventsReport.ShowDialog();
        }

        // This is a button click method which creates a CompetitorReportForm object, if none exists, and
        // passes it references to the DataModule and MainForm. 
        private void btnCompetitorReport_Click(object sender, EventArgs e)
        {
            if (frmCompetitorReport == null)
            {
                frmCompetitorReport = new CompetitorReportForm(DM, this);
            }
            frmCompetitorReport.ShowDialog();
        }

        // This is a button click method which closes the program when the user presses the Exit button.
        private void btnExit_Click (object sender, EventArgs e)
        {
            Close();
        }
    }
}
