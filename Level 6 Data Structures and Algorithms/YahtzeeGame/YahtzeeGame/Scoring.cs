using System;
using System.Collections.Generic;
using System.Text;

namespace YahtzeeGame
{
    /// <summary>
    /// These are the various scoring methods and conditions used for the Game.
    /// </summary>
    public static class Scoring
    {
        public static int roundTotal;
        public static int yahtzeeBonus = 100;
        public static int upperSectionBonusRequired = 63;
        public static int upperSectionBonus = 35;
        
      /// <summary>
      /// When the enum for Ones is selected, this will calculate the score.
      /// </summary>
      /// <param name="array"></param>
      /// <returns></returns>
        public static int NumberOnes(int[,] array)
        {
            roundTotal = 1 * array[0, 1];
            return roundTotal;
        }

        /// <summary>
        /// When the enum for Twos is selected, this will calculate the score.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int NumberTwos(int[,] array)
        {
            roundTotal = 2 * array[1, 1];
            return roundTotal;
        }

        /// <summary>
        /// When the enum for Threes is selected, this will calculate the score.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int NumberThrees(int[,] array)
        {
            roundTotal = 3 * array[2, 1];
            return roundTotal;
        }

        /// <summary>
        /// When the enum for Fours is selected, this will calculate the score.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int NumberFours(int[,] array)
        {
            roundTotal = 4 * array[3, 1];
            return roundTotal;
        }

        /// <summary>
        /// When the enum for Fives is selected, this will calculate the score.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int NumberFives(int[,] array)
        {
            roundTotal = 5 * array[4, 1];
            return roundTotal;
        }
        
        /// <summary>
        /// When the enum for Sixes is selected, this will calculate the score.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int NumberSixes(int[,] array)
        {
            roundTotal = 6 * array[5, 1];
            return roundTotal;
        }
        
        /// <summary>
        /// Used to calculate the score for Three of a Kind
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int ThreeOfAKind(int[,] array)
        {
            for (int i = 0; i < Dice.diceSides; i++)
            {
                if (array[i, 1] >= 3)
                {
                    return roundTotal = TotalDiceScore(array);
                }
            }
            return roundTotal = 0;
        }
        
        /// <summary>
        /// Used to calculate the score for Four of a Kind
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int FourOfAKind(int[,] array)
        {
            for (int i = 0; i < Dice.diceSides; i++)
            {
                if (array[i, 1] >= 4)
                {
                    return roundTotal = TotalDiceScore(array);
                }
            }
            return roundTotal = 0;
        }

        /// <summary>
        /// Used to calculate the score for a Full House
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int FullHouse(int[,] array)
        {
            for (int i = 0; i < Dice.diceSides; i++)
            {
                if (array[i, 1] == 3)
                {
                    for (int j = 1; j < Dice.diceSides; j++)
                    {
                        if (array[j, 1] == 2)
                        {
                            return roundTotal = 25;                    
                        }
                    }
                }
                else if (array[i, 1] == 2)
                {
                    for (int j = 1; j < Dice.diceSides; j++)
                    {
                        if (array[j, 1] == 3)
                        {
                            return roundTotal = 25;
                        }
                    }
                }
                else
                {
                    roundTotal = 0;
                }
            }
            return roundTotal;
        }

        /// <summary>
        /// Used to calculate the score for a Small Straight
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int SmallStraight(int[,] array)
        {
            if (IsStraight(array, 4))
            {
                return roundTotal = 30;
            }
            else
            {
                return roundTotal = 0;
            }
        }

        /// <summary>
        /// Used to calculate the score for a Large Straight
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int LargeStraight(int[,] array)
        {
            if (IsStraight(array, 5))
            {
                return roundTotal = 40;
            }
            else
            {
                return roundTotal = 0;
            }
        }

        /// <summary>
        /// Used to calculate the score for Yahtzee (ie five of a kind)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Yahtzee(int[,] array)
        {
            if (IsYahtzee(array))
            {
                roundTotal = 50;
            }
            else
            {
                roundTotal = 0;
            }
            return roundTotal;
        }

        /// <summary>
        /// Used to calculate the score for a roll which does not fit in any of the other categories
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Chance(int[,] array)
        {
            roundTotal = TotalDiceScore(array);
            return roundTotal;
        }

        /// <summary>
        /// Takes the two dimensional array of dice numbers and their totals and addes them together.
        /// </summary>
        /// <param name="array2d"></param>
        /// <returns></returns>
        public static int TotalDiceScore(int[,] array)
        {
            int totalRoundScore = 0;
            for (int i = 0; i < Dice.diceSides; i++)
            {
                totalRoundScore += (array[i, 0] * array[i, 1]);
            }
            return totalRoundScore;
        }

        /// <summary>
        /// Used to determine whether a set of dice contains a straight.
        /// </summary>
        /// <param name="array2d"></param>
        /// <param name="straightSize">How many dice should be consecutive to return a value of true</param>
        /// <returns></returns>
        public static bool IsStraight(int[,] array, int straightSize)
        {
            // creates a local array that will contain only the dice face numbers present in the int[,] array
            int[] straight = new int[Dice.maxDice];
            int j = 0;

            for (int i = 0; i < Dice.diceSides; i++)
            {
                if (array[i,1] != 0)
                {
                    straight[j] = i + 1;
                    j++;
                }
            }
            int straightDice = 1;
            for (int i = 1; i < straight.Length; i++)
            {
                if (straight[i] != 0)
                {
                    if (straight[i] - straight[i - 1] == 1)
                    {
                        straightDice += 1;
                    }
                    else
                    {
                        straightDice = 1;
                    }
                }
            }
            if (straightDice >= straightSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Determines whether the 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool IsYahtzee (int[,] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i, 1] == Dice.maxDice)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

        