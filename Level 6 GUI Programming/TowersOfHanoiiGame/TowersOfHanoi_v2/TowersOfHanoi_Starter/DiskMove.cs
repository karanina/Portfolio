using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Towers_of_Hanoi
{
    // The DiskMove class is used to save moves and output them as text.
    public class DiskMove
    {
        private string diskIDStr, pegNumStr;


        /// <summary>
        /// Constuctor receiving integer parameters
        /// </summary>
        /// <param name="aDisk"></param>
        /// <param name="aPeg"></param>
        public DiskMove(Int32 aDisk, Int32 aPeg)
        {
            diskIDStr = aDisk.ToString();
            pegNumStr = aPeg.ToString();        
        }

        // An alternate constructor taking in a disk and peg combination separated by a comma. For example "1,2".
        public DiskMove(string diskPeg)
        {
            diskIDStr = diskPeg.Substring(1);
            pegNumStr = diskPeg.Substring(3);
        }

        /// <summary> method:  AsText
        /// Provides a string for the Moves textbox. 
        /// </summary>
        /// <returns></returns>
        public string AsText()
        {
            string outputRecord = $"Disk {diskIDStr} has been moved to peg {pegNumStr}\r\n";
            return outputRecord;
        }

        /// <summary> method:  SaveAsText
        /// Provides a string for adding the Disk number as text in the ArrayList. 
        /// </summary>
        /// <returns></returns>
        public string SaveDiskAsText()
        {
            string arrayAddition = $"{diskIDStr}";
            return arrayAddition;
        }

        // Provides a string for adding the peg number as text in the ArrayList.
        public string savePegAsText()
        {
            string arrayAddition = $"{pegNumStr}";
            return arrayAddition;
        }
    }
}
