using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Towers_of_Hanoi
{
    // This class contains information about the Disks.
    public class Disk
    {
        /// <summary> class variables
        /// Variables for data to identify and track the position of the disks.
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
        /// Constructs the Disk objects based on supplied data.
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
        /// Updates which peg the disk is on.
        /// </summary>
        /// <param name="newPeg"></param>
        public void setPegNum(int newPeg)
        {
           disk_PegNum = newPeg;
        }

        /// <summary> method: getDiskID
        /// Provides access to the DiskID.
        /// </summary>
        /// <returns></returns>
        public int getDiskID(Disk aDisk)
        {
            int diskID = aDisk.diskID;
            return diskID;
        }

        /// <summary>method: getDiskColour
        /// Provides access to the Disk colour.
        /// </summary>
        /// <returns></returns>
        public Color getDiskColour(Disk aDisk)
        {
            Color disk_Colour = aDisk.disk_Colour;
            return disk_Colour;
        }

        /// <summary>method: getDiameter
        /// Provides access to the Disk diameter.
        /// </summary>
        /// <returns></returns>
        public int getDiameter(Disk aDisk)
        {
            int disk_Diam = aDisk.disk_Diam;
            return disk_Diam;
        }

        /// <summary>method:  getPegNum
        /// Provides access to number of the Peg the disk is currently sitting on.
        /// </summary>
        /// <returns></returns>
        public int getPegNum(Disk aDisk)
        {
            int disk_PegNum = aDisk.disk_PegNum;
            return disk_PegNum;
        }
    }
}
