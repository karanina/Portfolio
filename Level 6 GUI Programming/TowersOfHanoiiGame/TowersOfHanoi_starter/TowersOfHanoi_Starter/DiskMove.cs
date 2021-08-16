using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Towers_of_Hanoi
{
    public class DiskMove
    {
        private string diskIDStr, pegNumStr;



        /// <summary>
        /// constuctor receiving integer parameters
        /// </summary>
        /// <param name="aDisk"></param>
        /// <param name="aPeg"></param>
        public DiskMove(Int32 aDisk, Int32 aPeg)
        {
            diskIDStr = aDisk.ToString();
            pegNumStr = aPeg.ToString();        
        }


        /// <summary> method:  OutputAsText
        /// provides string for output textbox 
        /// </summary>
        /// <returns></returns>
        /// Have an AsText () method that gives this information as a string, e.g. “1,2” means that Disk 1 moved to peg 2.
        public string OutputAsText()
        {
            String moveAsText = diskIDStr + pegNumStr;
            return moveAsText;
        }

        /// <summary> method:  SaveAsText
        /// provides string for output textbox 
        /// </summary>
        /// <returns></returns>
        public string SaveAsText(Int32 aDisk, Int32 aPeg)
        {
            String moveDescription;
            moveDescription = $"Disk {aDisk} moved to peg {aPeg}";
            return moveDescription;
        }
    }
}
