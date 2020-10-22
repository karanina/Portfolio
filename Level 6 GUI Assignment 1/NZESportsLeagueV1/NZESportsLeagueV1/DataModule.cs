using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace NZESportsLeagueV1
{
    public partial class DataModule : Form
    {
        public DataTable dtArena;
        public DataTable dtEvent;
        public DataTable dtCompetitor;
        public DataTable dtChallenge;
        public DataTable dtEntry;
        public DataView arenaView;
        public DataView eventView;
        public DataView competitorView;
        public DataView challengeView;


        public DataModule()
        {
            InitializeComponent();
            dsNZESL.EnforceConstraints = false;
            daArena.Fill(dsNZESL);
            daEvent.Fill(dsNZESL);
            daCompetitor.Fill(dsNZESL);
            daChallenge.Fill(dsNZESL);
            daEntry.Fill(dsNZESL);
            dtArena = dsNZESL.Tables["Arena"];
            dtEvent = dsNZESL.Tables["Event"];
            dtCompetitor = dsNZESL.Tables["Competitor"];
            dtChallenge = dsNZESL.Tables["Challenge"];
            dtEntry = dsNZESL.Tables["Entry"];
            arenaView = new DataView(dtArena);
            arenaView.Sort = "ArenaID";
            eventView = new DataView(dtEvent);
            eventView.Sort = "EventID";
            competitorView = new DataView(dtCompetitor);
            competitorView.Sort = "CompetitorID";
            challengeView = new DataView(dtChallenge);
            challengeView.Sort = "ChallengeID";
            dsNZESL.EnforceConstraints = true;
        }

        public void UpdateArena()
        {
            daArena.Update(dtArena);
        }

        private void daArena_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            int newID = 0;
            OleDbCommand idCMD = new OleDbCommand("SELECT @@IDENTITY", ctnNZESL);

            if (e.StatementType == StatementType.Insert)
            {
                newID = (int)idCMD.ExecuteScalar();
                e.Row["ArenaID"] = newID;
            }
        }

        public void UpdateEvent()
        {
            daEvent.Update(dtEvent);
        }

        private void daEvent_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            int newID = 0;
            OleDbCommand idCMD = new OleDbCommand("SELECT @@IDENTITY", ctnNZESL);

            if (e.StatementType == StatementType.Insert)
            {
                newID = (int)idCMD.ExecuteScalar();
                e.Row["EventID"] = newID;
            }
        }
        public void UpdateChallenge()
        {
            daChallenge.Update(dtChallenge);
        }

        private void daChallenge_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            int newID = 0;
            OleDbCommand idCMD = new OleDbCommand("SELECT @@IDENTITY", ctnNZESL);

            if (e.StatementType == StatementType.Insert)
            {
                newID = (int)idCMD.ExecuteScalar();
                e.Row["ChallengeID"] = newID;
            }    
        }

        public void UpdateCompetitor()
        {
            daCompetitor.Update(dtCompetitor);
        }

        private void daCompetitor_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            int newID = 0;
            OleDbCommand idCMD = new OleDbCommand("SELECT @@IDENTITY", ctnNZESL);

            if (e.StatementType == StatementType.Insert)
            {
                newID = (int)idCMD.ExecuteScalar();
                e.Row["CompetitorID"] = newID;
            }
        }

        public void UpdateEntry()
        {
            daEntry.Update(dtEntry);
        }

       
 
    }
}