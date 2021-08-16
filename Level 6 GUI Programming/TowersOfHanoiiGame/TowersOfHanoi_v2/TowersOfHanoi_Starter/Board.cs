using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Towers_of_Hanoi
{

    // The Board class is responsible for updating and storing the game moves, and ensuring the rules of the game are followed.
    class Board
    {
        Disk[,] board; // A 2 dimentional array that represents the game board.            
        public ArrayList movements; // This stores the disk number and peg number of each of the movements made.
        Disk[] disks; // This stores references to the disk objects used in the game.
        int movesTarget; // The number of moves a user wishes to solve the puzzle in.

        private const int NUM_DISKS = 4; // The number of disks (represented by labels on the MainForm).
        private const int NUM_PEGS = 3; // The number of pegs (represented by panels on the MainForm).

        // This is the default constructor of the Board class.
        public Board()
        {
            board = new Disk[NUM_PEGS, NUM_DISKS];
            movements = new ArrayList();

            //Array of disk objects
            disks = new Disk[NUM_DISKS];
            disks[0] = null;
            disks[1] = null;
            disks[2] = null;
            disks[3] = null;

            // Storing disk object into board array(this is a 2 dimensional arrray) 
            board = new Disk[NUM_PEGS, NUM_DISKS]; // condition says 2 dimentional array  

            board[0, 3] = new Disk();
            board[0, 2] = new Disk();
            board[0, 1] = new Disk();
            board[0, 0] = new Disk();

            // Creating arraylist of movement 
            movements = new ArrayList();
        }

        // Alterntative constructor creating the board using the 4 disk objects and sets thedefault movesTarget value is 15 moves.
        public Board(Disk d1, Disk d2, Disk d3, Disk d4, int movesTarget = 15)
        {
            // Storing into disks array
            disks = new Disk[NUM_DISKS];
            disks[0] = d1;
            disks[1] = d2;
            disks[2] = d3;
            disks[3] = d4;

            // Storing disk object into board array(This is a two dimensional arrray) 
            board = new Disk[NUM_PEGS, NUM_DISKS]; // condition says TWO dimentional array  
            board[0, 3] = d4;
            board[0, 2] = d3;
            board[0, 1] = d2;
            board[0, 0] = d1;

            this.movesTarget = movesTarget;

            // The arraylist of movements.
            movements = new ArrayList();
        }

        // Clears the movements ArrayList.
        public void reset()
        {
            movements.Clear();
        }

        // Changes the value of the moveTarget variable as set by the user. 
        public int setMovesTarget(int movesTarget)
        {
            this.movesTarget = movesTarget;
            return movesTarget;
        }

        // Checks to see if the disk is the top disk on the peg.
        public bool canStartMove(Disk aDisk)
        {
            int aPegIndex = getPegIndex(aDisk);
            for (int i = 0; i < NUM_DISKS; i++)
            {
                if (board[aPegIndex, i] != null)
                {
                    if(board[aPegIndex, i] == aDisk)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    continue;
                }                            
            }
            return true;
        }

        // Checks that the disk being dropped is smaller than the disk it is being dropped on (if any).
        public bool CanDrop(Disk aDisk, int aPeg)
        {
            int aPegIndex = getPegIndex(aPeg);
            if (board[aPegIndex, NUM_DISKS - 1] == null)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < NUM_DISKS; i++)
                {

                    if (board[aPegIndex, i] != null)
                    {
                        Disk topDisk = board[aPegIndex, i];
                        if (topDisk.getDiskID(topDisk) > aDisk.getDiskID(aDisk))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                return true;
            }
        }
        // Finds the selected Disk in the 2 dimensional board array, sets that position to null and adds selected disk to it's
        // new position in the 2 dimensional board array.
        public void move(Label aDisk, int newLevel)
        {
            Disk selectedDisk = FindDisk(aDisk);
            int currentPegIndex = getPegIndex(selectedDisk);
            int toPegNumIndex = getPegIndex(newLevel);

            for (int i = 0; i < NUM_DISKS; i++)
            {
                if (board[currentPegIndex, i] == selectedDisk)
                {
                    board[currentPegIndex, i] = null;
                    for (int j = NUM_DISKS - 1; j >= 0; j--)
                    {
                        if (board[toPegNumIndex, j] == null)
                        {
                            board[toPegNumIndex, j] = selectedDisk;
                            selectedDisk.setPegNum(newLevel);
                            // Creates a DiskMove object representing the latest move to the movements ArrayList.
                            DiskMove diskMove = new DiskMove(Convert.ToInt32(aDisk.Text), newLevel);
                            movements.Add(diskMove.SaveDiskAsText());
                            movements.Add(diskMove.savePegAsText());
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            
        }

        // Returns a string giving the moves so far when saving the game, with one move per line.
        public string allMovesAsString()
        {
            int totalMoves = movements.Count;
            string outputRecord = "";
            StringBuilder sb = new StringBuilder(totalMoves);
            for (int i = 0; i < totalMoves; i += 2)
            {
                sb.Append(movements[i]);
                sb.Append(",");
                sb.Append(movements[i + 1]);
                sb.Append("\r\n");
            }
            outputRecord = sb.ToString();
            return outputRecord;
            }

        // Sets the X and Y co-ordinates of the label representing the disk being dropped onto the peg.
        public Point Display(Label aLabel, Panel targetPeg)
        {
            int targetPegIndex = getPegIndex(targetPeg);
            int diskLevel = getLevel(aLabel, targetPeg);
            Point targetPoint = targetPeg.Location;
            targetPoint.X -= (aLabel.Width / 2) - (targetPeg.Width / 2);
            targetPoint.Y += (targetPeg.Height - (aLabel.Height * diskLevel));
            return targetPoint;
        }

        // Finds the Disk ID number from the selected label.
        public Disk FindDisk(Label aLabel)
        {
            Disk aDisk;
            if (aLabel.Text == "1")
            {
                aDisk = disks[0];
            }
            else if (aLabel.Text == "2")
            {
                aDisk = disks[1];
            }
            else if (aLabel.Text == "3")
            {
                aDisk = disks[2];
            }
            else
            {
                aDisk = disks[3];
            }
            return aDisk;
        }


        public int newLevInPeg(int pegNum)
        {
            return 1;    // Dummy return to avoid syntax error - must be changed
        }


        public String getText(int cnt)
        {
            return "1";    // Dummy return to avoid syntax error - must be changed
        }


        public void backToSelected(int ind)
        {

        }

        // Finds the ID number of the target peg.
        public int getPegID(Panel aPeg)
        {
            int aPegID = Convert.ToInt32(aPeg.Name.Substring(7));
            return aPegID; 
        }

        // Gets the level at which the disk should be dropped on the target peg, so that the Y co-ordinate may be set.
        public int getLevel(Label aDisk, Panel toPegNum)
        {
            Disk selectedDisk = FindDisk(aDisk);
            int toPegNumIndex = getPegIndex(selectedDisk);

            for (int i = 0; i < NUM_DISKS; i++)
            {
                if (board[toPegNumIndex, i] == selectedDisk)
                {
                    return NUM_DISKS - i;
                }
                else
                {
                    continue;
                }
                
            }
            return 1;
        }

        // Removes the last label and peg entries in the movements ArrayList and returns the previous peg number so that the
        // disk may be returned to it.
        public int unDo(int ind)
        {
            int aLabelID = Convert.ToInt32(movements[ind]);
            movements.RemoveRange(ind, 2);
            int lastLabel = movements.LastIndexOf(aLabelID);
            int lastPeg = Convert.ToInt32(movements[lastLabel + 1]);
            return lastPeg;
        }


        public void loadData(ArrayList dm)
        {

        }
        
        // A method for getting the current peg index number from a Disk object.        
        private int getPegIndex (Disk aDisk)
        {
            int PegIndex = aDisk.getPegNum(aDisk) - 1;
            return PegIndex;
        }
        
        // An alternate method for getting a Peg Index number from a Peg ID (such as a toPegNum).
        private int getPegIndex (int aPegID)
        {
            int PegIndex = aPegID - 1;
            return PegIndex;
        }
    
        // An alternate method for getting a Peg Index number from a Panel.
        private int getPegIndex(Panel aPanel)
        {
            int PegIndex = getPegID(aPanel) - 1;
            return PegIndex;
        }
    
        // Checks if the game is complete.
        public bool isGameComplete()
        {
            if (board[2, 3] == disks[3])
            {
                if (board[2, 2] == disks[2])
                {
                    if (board[2, 1] == disks[1])
                    {
                        if (board[2, 0] == disks[0])
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Gives access to the movesTarget number from the constructor.
        public int getMovesTarget()
        {
            int movesTarget = this.movesTarget;
            return movesTarget;
        }

        // Checks if the user has exceeded the number of moves they set their target to.
        public bool hasExceededTarget()
        {
            if ((movements.Count / 2) > movesTarget)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}      
    
