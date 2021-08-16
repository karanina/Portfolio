using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Towers_of_Hanoi
{
    public class Disk
    {
        /// <summary> class variables
        /// Variables for data to identify and track position of disks
        /// </summary>
        private int   diskID,
                      disk_Diam,                        
                      disk_PegNum;

        private Color disk_Colour;


        /// <summary>
        /// Default Constructor
        /// </summary>
        public Disk()
        {

        }

        /// <summary> constructor:  Disk
        /// Constructs Disk objects based on supplied data
        /// </summary>
        /// <param name="aDiskNum"></param>
        /// <param name="aDiameter"></param>
        /// <param name="aColour"></param>
        /// <param name="aPeg"></param>
        public Disk(int aDiskID, int aDiameter, Color aColour,int aPeg)
        {
            diskID = aDiskID;
            disk_Diam = aDiameter;
            disk_Colour = aColour;
            disk_PegNum = aPeg;
        }


        /// <summary> method: setPegNum
        /// updates which peg the disk is on
        /// </summary>
        /// <param name="newPeg"></param>
        public void setPegNum(int newPeg)
        {
            disk_PegNum = newPeg;
        }

        /// <summary> method: getDiskID
        /// provides access to DiskID
        /// </summary>
        /// <returns></returns>
        public int getDiskID()
        {
            
            return diskID;
        }

        /// <summary>method: getDiskColour
        /// provides access to Disk colour
        /// </summary>
        /// <returns></returns>
        public Color getDiskColour()
        {
            return disk_Colour;
        }

        /// <summary>method: getDiameter
        /// provides access to Disk diameter
        /// </summary>
        /// <returns></returns>
        public int getDiameter()
        {
            return disk_Diam;
        }

        /// <summary>method:  getPegNum
        /// provides access to number of the Peg the disk is currently on
        /// </summary>
        /// <returns></returns>
        public int getPegNum()
        {
            return disk_PegNum;
        }

    }
}
