using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Towers_of_Hanoi
{
    class Board
    {
        Disk[,] board; //condition says 2 dimentional array            
        ArrayList movements;
        Disk[] disks; //Array of disks
        int movesTarget;

        private const int NUM_DISKS = 4;
        private const int NUM_PEGS = 3;

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

            //Storing disk object into board array(this is a 2 dimensional arrray) 
            board = new Disk[NUM_PEGS, NUM_DISKS]; // condition says 2 dimentional array  

            board[0, 3] = new Disk();
            board[0, 2] = new Disk();
            board[0, 1] = new Disk();
            board[0, 0] = new Disk();

            //Creating arraylist of movement 
            movements = new ArrayList();
        }

        //Alterntative constructor
        public Board(Disk d1, Disk d2, Disk d3, Disk d4, int movesTarget = 25)
        {
            //Storing into disks array
            disks = new Disk[NUM_DISKS];
            disks[0] = d1;
            disks[1] = d2;
            disks[2] = d3;
            disks[3] = d4;

            //Storing disk object into board array(This is a two dimensional arrray) 
            board = new Disk[NUM_PEGS, NUM_DISKS]; //condition says TWO dimentional array  
            board[0, 3] = d1;
            board[0, 2] = d2;
            board[0, 1] = d3;
            board[0, 0] = d4;

            this.movesTarget = movesTarget;

            //Arraylist of movement.
            movements = new ArrayList();
        }


        public void reset()
        {
            new Board();
        }

        // Check if it is valid to begin a move with a particular Disk (only the top Disk on a peg can move). 
        public bool canStartMove(Disk aDisk)
        {
            
                return true;
            
        }

        // Check if it is valid to drop a particular disk on a Peg (drops are only allowed for a Disk that is 
        // smaller than the top Disk on a peg or for an empty peg).
        public bool canDrop(Disk aDisk, int aPeg)
        {
            // if disk1 < disk2 || peg is empty
            return true;
        }

        // Move a disk to a new Peg.
        // Save a DiskMove object representing the latest move to the ArrayList of moves. 
        public void move(Disk aDisk, int newLevel)
        {
            
        }

        // Return a string giving the moves so far, one move per line.
        public string allMovesAsString()
        {
            return "dummy";  // Dummy return to avoid syntax error - must be changed
            // string to go into listbox saying move disk1 onto peg2 (or something to that effect)
        }

        // Display the current position of the disks. This is done by changing the Top and Left properties of 
        // the disks which in turn changes where the labels show on the screen.
        public void Display()
        {

        }

        // Get a reference to the disk that matches a label. This is to be used to find which disk object is being 
        // dragged on the form.
        public Disk FindDisk(Label aLabel)
        {
            Disk dummy = null;
            return dummy;  // Dummy return to avoid syntax error - must be changed
            
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


        public int getPegInd(int ind)
        {
            return 1;    // Dummy return to avoid syntax error - must be changed
        }


        public int getLevel(int ind)
        {
            return 1;    // Dummy return to avoid syntax error - must be changed
        }


        public void unDo()
        {

        }


        public void loadData(ArrayList dm)
        {

        }

        // Check if the number of moves a user has made exceeds the set target. The program should change the 
        // colour scheme of the User Interface and show a (friendly) message.
        public void setGameTheme(bool hasExceededTarget)
        {

        }
    }
}