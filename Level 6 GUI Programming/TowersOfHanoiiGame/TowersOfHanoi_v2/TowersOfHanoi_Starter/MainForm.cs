using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Timers;


namespace Towers_of_Hanoi
{
    // This class controls the visual elements of the game.
    public partial class MainForm : Form
    {
        // string representing all moves to finish game in minimum number of moves
        string perfectGameStr = "122313321122124313211133122313";

        private Board board;
        private Disk selectedDiskObj;
        private int toPegNum;
        private bool gameSaved = true;
        private bool executeSelection = false;
        private bool isDemo = false;
        private Label[] lbl_Disks = new Label[4];
        int tmrCount = 0;
        int x = 0;

        public MainForm()
        {
            InitializeComponent();
            makeGame();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary> method: makeGame
        /// Generates game objects representing the components used in the game.
        /// </summary>
        public void makeGame()
        {
            Disk disk1 = new Disk(1, lbl_Disk1.Width, lbl_Disk1.BackColor, 1);
            Disk disk2 = new Disk(2, lbl_Disk2.Width, lbl_Disk2.BackColor, 1);
            Disk disk3 = new Disk(3, lbl_Disk3.Width, lbl_Disk3.BackColor, 1);
            Disk disk4 = new Disk(4, lbl_Disk4.Width, lbl_Disk4.BackColor, 1);
            board = new Board(disk1, disk2, disk3, disk4);

            lbl_Disks[0] = lbl_Disk1;
            lbl_Disks[1] = lbl_Disk2;
            lbl_Disks[2] = lbl_Disk3;
            lbl_Disks[3] = lbl_Disk4;
        }


        //--------------------------Drag and Drop procedures ------------------------------------

        /// <summary>event handler: anyDisk_MouseDown
        /// Captures user input to select disk to move. If selection valid initiates
        /// drag and drop procedure and when complete instructs program to adjust 
        /// data accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void anyDisk_MouseDown(object sender, MouseEventArgs e)
        {
            Label aLabel = (Label)sender as Label;
            if (board.canStartMove(board.FindDisk(aLabel)))
            {
                DragDropEffects result = aLabel.DoDragDrop(aLabel, DragDropEffects.Move);
            }
            else
            {
                MessageBox.Show("This is an illegal move. Please choose a disk at the top of the pile.", "Warning");
            }
        }


        /// <summary>event handler: peg_DragEnter
        /// Detects movement of cursor over peg and allows cursor to change 
        /// from blocked to active for a valid move. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void peg_DragEnter(object sender, DragEventArgs e)
        {
            Panel toPeg = (Panel)sender as Panel;
            Label aLabel = (Label)e.Data.GetData(typeof(Label));
            // If the move is valid, allow the disk/label to drop.
            if (board.CanDrop(board.FindDisk(aLabel), board.getPegID(toPeg)))
            {
                e.Effect = DragDropEffects.All;
            }
            // If the move is not valid a warning panel is displayed advising the user that the move is illegal.
            else
            {
                e.Effect = DragDropEffects.None;
                pnl_CanDropWarning.Show();
            }
        } 

        /// <summary>event handler: peg_DragDrop
        /// Detects mouse button up event and captures which peg disk moved to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void peg_DragDrop(object sender, DragEventArgs e)
        {
            Panel toPeg = (Panel)sender as Panel;
            Label aLabel = (Label)e.Data.GetData(typeof(Label));
            ExecuteMove(aLabel, toPeg);
        }

        /// <summary> method: ExecuteMove
        /// At completion of Drag and Drop sends data for new move to Board to update
        /// records and updates the game display showing disk in new position.  Checks
        /// if the move completes the game, and displays a message if it is.
        /// </summary>
        public void ExecuteMove(Label aLabel, Panel toPeg)
        {
            toPegNum = board.getPegID(toPeg);
            board.move(aLabel, toPegNum);
            aLabel.Location = board.Display(aLabel, toPeg);
            MoveOutput(aLabel, toPeg);
            setGameTheme(board.hasExceededTarget());
            if (board.isGameComplete())
            {
                if (Convert.ToInt32(txt_Count.Text) == 15)
                {
                    this.BackColor = Color.Gold;
                    MessageBox.Show("Congratulations! You have successfully completed the game with the minimum number of moves.",
                        "Success");
                }
                else
                {
                    this.BackColor = Color.Silver;
                    MessageBox.Show("Congratulations! You have successfully completed the game but not with the minimum number of moves.", "Success");
                }
            }
        }

        /// <summary>method: moveOutput
        /// Retrieves move count and moves made data from Board and 
        /// updates output textboxes after each move completed.
        /// </summary>
        public void MoveOutput(Label aLabel, Panel toPeg)
        {
            try
            {
                int newCount = Convert.ToInt32(txt_Count.Text) + 1;
                txt_Count.Text = Convert.ToString(newCount);
            }
            catch (FormatException)
            {
                int newCount = 0 + 1;
                txt_Count.Text = Convert.ToString(newCount);
            }
            int aLabelID = Convert.ToInt32(aLabel.Text);
            DiskMove newMove = new DiskMove(aLabelID, board.getPegID(toPeg));
            txt_Moves.Text += newMove.AsText();
        }

        // If the user has exceeded their target number of moves, the background color changes and a message appears to let them 
        // know.
        public void setGameTheme(bool hasExceededTarget)
        {

            if (hasExceededTarget)
            {
                this.BackColor = Color.BlueViolet;
                MessageBox.Show("You have now exceeded the number of moves you set as your target.", "Warning");
            }
        }

        // Sub-menu click method that exits the game.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }



        // Menu click method which opens the panel showing the game rules to the user.
        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Rules taken from https://en.wikipedia.org/wiki/Tower_of_Hanoi
            pnl_Rules.Show();
        }

        // This menu click method runs the demo game play on a timer.
        private void demoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            makeGame();
            for (int i = 0; i < lbl_Disks.Count(); i++)
            {
                Label aLabel = lbl_Disks[i];
                aLabel.Location = board.Display(aLabel, pnl_Peg1);
            }
            board.reset();
            txt_Count.Text = "";
            txt_Moves.Text = "";
            txt_TargetCount.Text = "";
            this.BackColor = Color.WhiteSmoke;
            timer1.Start();
        }

        // Menu click method which allows the user to save a game.
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string gameRecord = board.allMovesAsString();
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(gameRecord);
                sw.Close();
            }
            this.Cursor = Cursors.Default;
        }

        // Menu click method which allows the user to load a saved game.
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                string gameRecord = sr.ReadToEnd();
                sr.Close();
                board.reset();
                txt_Count.Text = "";
                txt_Moves.Text = "";
                this.BackColor = Color.WhiteSmoke;
                gameRecord = gameRecord.Replace("\r\n", ",");
                string[] savedGame = gameRecord.Split(',');
                for (int i = 0; i < (savedGame.Length - 1); i += 2)
                {
                    Label aLabel = FindLabel(Convert.ToInt32(savedGame[i]));
                    int targetPegID = Convert.ToInt32(savedGame[i + 1]);
                    ExecuteMove(aLabel, FindPanel(targetPegID));
                }
            }
            this.Cursor = Cursors.Default;
        }

        // Menu click method that resets the display. Returns the  disks to their original configuration, shows the Welcome panel 
        // allowing for the user to re-enter their target number of moves, empties the text boxes and re-populates the the 
        // TargetCount text box with a new figure.
        private void resetGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            makeGame();
            for (int i = 0; i < lbl_Disks.Count(); i++)
            {
                Label aLabel = lbl_Disks[i];
                aLabel.Location = board.Display(aLabel, pnl_Peg1);
            }
            board.reset();
            txt_Count.Text = "";
            txt_Moves.Text = "";
            txt_TargetCount.Text = "";
            this.BackColor = Color.WhiteSmoke;
            pnl_Welcome.Show();
        }

        // Menu click method that undoes the previous move.
        private void undoMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Finds the index of the last disk moved.
            int ind = board.movements.Count - 2;
            // Finds the ID of the last disk moved.
            int aLabelID = Convert.ToInt32(board.movements[ind]);
            // Finds the label of the disk moved.
            Label aLabel = FindLabel(aLabelID);
            // Gets the peg the label was moved to.
            int aPegID = Convert.ToInt32(board.movements[ind + 1]);
            // Removes the last move from the movements arraylist and returns the previous position of the Disk.
            int lastPeg = board.unDo(ind);
            // Deducts 1 from the move count.
            int Count = Convert.ToInt32(txt_Count.Text) - 1;
            txt_Count.Text = Convert.ToString(Count);
            // Resets the Moves text box to it's blank state and re-populates the moves made thus far.
            txt_Moves.Text = "";
            for (int i = 0; i < Count; i++)
            {
                DiskMove reDoMoves = new DiskMove(Convert.ToInt32(board.movements[i]), Convert.ToInt32(board.movements[i + 1]));
                txt_Moves.Text += reDoMoves.AsText();
            }
            // Finds the panel belonging to the last peg and moves the disk there.
            Panel aPanel = FindPanel(lastPeg);
            board.move(aLabel, lastPeg);
            aLabel.Location = board.Display(aLabel, aPanel);
        }

        // This button click method updates the Target Count text box and hides the Welcome panel when the user enters 
        // the moves target (on the Welcome panel).
        private void btn_TargetOK_Click(object sender, EventArgs e)
        {
            board.setMovesTarget(Convert.ToInt32(num_MovesTarget.Value));
            pnl_Welcome.Hide();
            txt_TargetCount.Text = Convert.ToString(num_MovesTarget.Value);
        }

        // Button click method that closes the panel warning that the move is illegal.
        private void btn_CanDropOk_Click(object sender, EventArgs e)
        {
            pnl_CanDropWarning.Hide();
        }

        // Button click method that returns the user to the game after viewing the rules.
        private void btn_RulesReturn_Click(object sender, EventArgs e)
        {
            pnl_Rules.Hide();
        }

        // Finds the panel object from a Peg ID.
        public Panel FindPanel(int aPegID)
        {
            Panel aPanel = new Panel();
            if (aPegID == 1)
            {
                aPanel = pnl_Peg1;
            }
            else if (aPegID == 2)
            {
                aPanel = pnl_Peg2;
            }
            else
            {
                aPanel = pnl_Peg3;
            }
            return aPanel;
        }

        // Finds the label object from a Label ID.
        public Label FindLabel(int aLabelID)
        {
            Label aLabel = new Label();
            if (aLabelID == 1)
            {
                aLabel = lbl_Disks[0];
            }
            else if (aLabelID == 2)
            {
                aLabel = lbl_Disks[1];
            }
            else if (aLabelID == 3)
            {
                aLabel = lbl_Disks[2];
            }
            else
            {
                aLabel = lbl_Disks[3];
            }
            return aLabel;
        }

        // This timer starts the second timer for the demo game play.
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            String[] gameRecord = getGameRecord(perfectGameStr);
            Label aLabel = FindLabel(Convert.ToInt32(gameRecord[x]));
            int toPegNum = Convert.ToInt32(gameRecord[x + 1]);
            Panel aPanel = FindPanel(toPegNum);
            board.move(aLabel, toPegNum);
            aLabel.Location = board.Display(aLabel, aPanel);
            MoveOutput(aLabel, aPanel);
            tmrCount += 1;
            x += 2;

            if (tmrCount != gameRecord.Count() / 2)
            {
                timer1.Start();
            }
            else
            {
                this.Cursor = Cursors.Default;
                tmrCount = 0;
                x = 0;
            }
        }

        // Transforms a string of game moves into a string array.
        private string[] getGameRecord(string gameMoves)
        {
            string[] gameRecord = new string[gameMoves.Length];
            for (int i = 0; i < gameMoves.Length; i++)
            {
                string ID = gameMoves.Substring(i, 1);
                gameRecord[i] = ID;
            }
            return gameRecord;
        }

        private void lbl_Disk1_Click(object sender, EventArgs e)
        {

        }
    }
}