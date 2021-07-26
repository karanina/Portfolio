using System;
using System.Collections.Generic;
using System.Text;

namespace YahtzeeGame
{
    public class Dice
    {
        public const int maxRolls = 3;
        public const int maxDice = 5;
        public const int diceSides = 6;
        public int numberRolls;
        public int[,] roundTotals;
        public int[] currentRound;
        public int[] diceToKeep;

        /// <summary>
        /// Constructor method
        /// </summary>
        public Dice()
        {
            numberRolls = 0;
            roundTotals = new int[diceSides, 2];
            currentRound = new int[maxDice];
            diceToKeep = new int[maxDice];
    }

        /// <summary>
        /// Returns a new round of dice rolls
        /// </summary>
        /// <returns></returns>
        public int[] Round()
        {
            if (this.numberRolls < maxRolls)
            {
                if (this.numberRolls == 0)
                {
                    currentRound = this.Roll();
                    this.numberRolls++;
                }
                else if (this.numberRolls == 1)
                {
                    currentRound = this.Roll(GameDisplay.diceToKeep);
                    this.numberRolls++;
                    ClearArray(GameDisplay.diceToKeep);
                }
                else
                {
                    currentRound = this.Roll(GameDisplay.diceToKeep);
                    this.numberRolls++;
                    ClearArray(GameDisplay.diceToKeep);
                }
            }
            return currentRound;
        }

        /// <summary>
        /// Starter Method: returns an array of 5 dice values that will be saved on the score card.
        /// </summary>
        /// <returns></returns>
        public int[] Roll()
        {
            int[] roundDice = new int[maxDice];
                for (int i = 0; i < roundDice.Length; i++)
                {
                    if (roundDice[i] == 0)
                    {
                        roundDice[i] = DiceRoll();
                    }
                }
            return roundDice;
        }

        /// <summary>
        /// Overloaded Method: used for re-rolls and returns an array of 5 dice values that will be saved on the score card. 
        /// </summary>
        /// <param name="currentRound"></param>
        /// <returns></returns>
        public int[] Roll(int[] currentRound)
        {
            int[] reRoll = new int[maxDice];
            for (int i = 0; i < maxDice; i++)
            {
                if (currentRound[i] == 0)
                {
                    reRoll[i] = DiceRoll();
                }
                else
                {
                    reRoll[i] = currentRound[i];
                }
            }
            return reRoll;
        }

        /// <summary>
        /// Takes the roundDice array and totals the number of each dice rolled compared to the possible values (ie 
        /// how many sixes were rolled, how many fives etc).
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int[,] DiceTotals(int[] array)
        {
            int[,] roundTotals = new int[diceSides,2];
            for (int i = 1; i <= diceSides; i++)
            {
                roundTotals[i - 1, 0] = i;
                int numberDice = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (i == array[j])
                    {
                        numberDice += 1;
                    }        
                }
                roundTotals[i - 1, 1] = numberDice;
            }
            return roundTotals;
        }

        /// <summary>
        /// Places the selected dice into the toKeep array at the same position as in the currentRoll array. 
        /// </summary>
        /// <param name="currentRoll"></param>
        /// <param name="toKeep"></param>
        /// <param name="diceNumber"></param>
        /// <returns></returns>
        public int[] DiceToKeep(int[] currentRoll, int[] toKeep, int diceNumber)
        {          
            toKeep[diceNumber] = currentRoll[diceNumber];
            return toKeep;
        }

        /// <summary>
        /// Simulates an individual dice roll by returning a random integer from 1 to 6 (or however many sides the dice
        /// has.
        /// </summary>
        /// <returns></returns>
        public int DiceRoll()
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, diceSides + 1);
            return dice;
        }

        /// <summary>
        /// Clears an array when it needs to have its values removed for its next use.
        /// </summary>
        /// <param name="array"></param>
        public void ClearArray(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = 0;
            }
        }
    }
}


