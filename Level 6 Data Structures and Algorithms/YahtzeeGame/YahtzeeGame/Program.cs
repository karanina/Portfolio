using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace YahtzeeGame
{
    /// <summary>
    /// Created by Anna McColl
    /// Student ID 1527037
    /// UNITEC
    /// Semester 1 2021
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            GameDisplay myGameDisplay = new GameDisplay();
            myGameDisplay.Run();       
        }
    }
}
