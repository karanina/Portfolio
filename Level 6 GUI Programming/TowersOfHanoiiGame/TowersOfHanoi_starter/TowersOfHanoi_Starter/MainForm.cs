using System;
using System.Collections.Generic;
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
    public partial class MainForm : Form
    {
        // string representing all moves to finish game in minimum number of moves
        string perfectGameStr = "122313321122124313211133122313";

        // Have private global references for a Board object, the Disk being dragged and the Peg that is the 
        // target of the drop.
        private Board board;
        private Disk selectedDiskObj;
        private int toPegNum;

        private bool gameSaved = true;
        private bool executeSelection = false;
        private bool isDemo = false;
        private Label[] lbl_Disks = new Label[4];
        int tmrCount = 0;
        
                     
        

        public MainForm()
        {
            InitializeComponent();
            makeGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary> method: makeGame
        /// generate game objects representing the components used in the game
        /// </summary>
        public void makeGame()
        {
            Disk disk1 = new Disk (1, lbl_Disk1.Width, lbl_Disk1.BackColor, 1);
            Disk disk2 = new Disk (2, lbl_Disk2.Width, lbl_Disk2.BackColor, 1);
            Disk disk3 = new Disk (3, lbl_Disk3.Width, lbl_Disk3.BackColor, 1);
            Disk disk4 = new Disk (4, lbl_Disk4.Width, lbl_Disk4.BackColor, 1);
            board = new Board(disk1, disk2, disk3, disk4);

            lbl_Disks[0] = lbl_Disk1;
            lbl_Disks[1] = lbl_Disk2;
            lbl_Disks[2] = lbl_Disk3;
            lbl_Disks[3] = lbl_Disk4;

            lbl_Disk1.MouseDown += new MouseEventHandler(anyDisk_MouseDown);
            lbl_Disk2.MouseDown += new MouseEventHandler(anyDisk_MouseDown);
            lbl_Disk3.MouseDown += new MouseEventHandler(anyDisk_MouseDown);
            lbl_Disk4.MouseDown += new MouseEventHandler(anyDisk_MouseDown);
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
            selectedDiskObj = (Disk)sender as Disk;
            DragDropEffects result = lbl_Disks[Convert.ToInt32(selectedDiskObj)].DoDragDrop(lbl_Disks, DragDropEffects.Move);
        }


        /// <summary>event handler: peg_DragEnter
        /// Detects movement of cursor over peg and allows cursor to change 
        /// from blocked to active for a valid move. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void peg_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        /// <summary>event handler: peg_DragDrop
        /// Detects mouse button up event and captures which peg disk moved to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void peg_DragDrop(object sender, DragEventArgs e)
        {
            Panel p = (Panel)sender as Panel;
            // selectedDiskObj.Parent = p;
        }


       /// <summary> method: ExecuteMove
        /// At completion of Drag and Drop sends data for new move to Board to update
        /// records and updates the game display showing disk in new position.  Checks
        /// if the move completes the game.
        /// </summary>
        /// <param name="alblDisk"></param>
        /// <param name="aDiskID"></param>
        public void ExecuteMove(Label alblDisk, int aDiskID)
        {
            
        }

        /// <summary>method: moveOutput
        /// Retrieves move count and moves made data from Board and 
        /// updates output textboxes after each move completed.
        /// </summary>
        public void MoveOutput()
        {
            // DiskMove.OutputAsText(int aDiskID, int aPegID);
        }

        // Have a [Reset] button that creates 4 Disk objects matching the 4 labels and a Board object, and then position 
        // the Disks in the starting position.
        private void btnReset_Click(object sender, EventArgs e)
        {
            makeGame();
        }
    }
}
