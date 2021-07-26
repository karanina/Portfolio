using System;
using System.Collections.Generic;
using System.Text;

namespace YahtzeeGame
{
    public static class ScoreCategoryBinaryTree
    {
        public static ScoreCategoryNode root = null;
        public const int maxNodes = 13;
        public static int totalNodes = 0;
        public static List<Delegate> ScoringFunctions = new List<Delegate>();

        
        //Creates Enum data type ScoringCategories
        public enum ScoringCategories
        {
            Ones,
            Twos,
            Threes,
            Fours,
            Fives,
            Sixes,
            ThreeOfAKind,
            FourOfAKind,
            FullHouse,
            SmallStraight,
            LargeStraight,
            Yahtzee,
            Chance
        }

        // Creates a list of ScoringCategory Enums.
        public static ScoringCategories[] scoringCategories = { ScoringCategories.Ones,
            ScoringCategories.Twos,
            ScoringCategories.Threes,
            ScoringCategories.Fours,
            ScoringCategories.Fives,
            ScoringCategories.Sixes,
            ScoringCategories.ThreeOfAKind,
            ScoringCategories.FourOfAKind,
            ScoringCategories.FullHouse,
            ScoringCategories.SmallStraight,
            ScoringCategories.LargeStraight,
            ScoringCategories.Yahtzee,
            ScoringCategories.Chance };

        // Defines the ScoringDelegate and it's signature
        public delegate int ScoringDelegate(int[,] array);

        // Creates the ScoringDelegates
        public static ScoringDelegate numberOnes;
        public static ScoringDelegate numberTwos;
        public static ScoringDelegate numberThrees;
        public static ScoringDelegate numberFours;
        public static ScoringDelegate numberFives;
        public static ScoringDelegate numberSixes;
        public static ScoringDelegate threeOfAKind;
        public static ScoringDelegate fourOfAKind;
        public static ScoringDelegate fullHouse;
        public static ScoringDelegate smallStraight;
        public static ScoringDelegate largeStraight;
        public static ScoringDelegate yahtzee;
        public static ScoringDelegate chance;
        public static ScoringDelegate calculationMethod;


        /// <summary>
        /// Passes in the reference to the scoring method defined in the Scoring class to it's delegate and adds it to 
        /// a list of delegates.
        /// </summary>
        public static void PopulateScoringMethods()
        {
            numberOnes = Scoring.NumberOnes;
            numberTwos = Scoring.NumberTwos;
            numberThrees = Scoring.NumberThrees;
            numberFours = Scoring.NumberFours;
            numberFives = Scoring.NumberFives;
            numberSixes = Scoring.NumberSixes;
            threeOfAKind = Scoring.ThreeOfAKind;
            fourOfAKind = Scoring.FourOfAKind;
            fullHouse = Scoring.FullHouse;
            smallStraight = Scoring.SmallStraight;
            largeStraight = Scoring.LargeStraight;
            yahtzee = Scoring.Yahtzee;
            chance = Scoring.Chance;
            ScoringFunctions.Add(numberOnes);
            ScoringFunctions.Add(numberTwos);
            ScoringFunctions.Add(numberThrees);
            ScoringFunctions.Add(numberFours);
            ScoringFunctions.Add(numberFives);
            ScoringFunctions.Add(numberSixes);
            ScoringFunctions.Add(threeOfAKind);
            ScoringFunctions.Add(fourOfAKind);
            ScoringFunctions.Add(fullHouse);
            ScoringFunctions.Add(smallStraight);
            ScoringFunctions.Add(largeStraight);
            ScoringFunctions.Add(yahtzee);
            ScoringFunctions.Add(chance);
        }

        /// <summary>
        /// A starter method for creating the Binary Search Tree
        /// </summary>
        public static void PopulateNodes()
        {
            PopulateScoringMethods();
            CreateRoot(scoringCategories, 0, maxNodes - 1);
        }

        /// <summary>
        /// Creates the root of the Binary Search Tree and uses a Divide and Conquer, recursive algorithm to create 
        /// the rest of the Tree in a balanced manner.
        /// </summary>
        /// <param name="scoringCategories"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static void CreateRoot(ScoringCategories[] scoringCategories, int min, int max)
        {
            int mid = ((min + max) / 2);

            root = new ScoreCategoryNode(scoringCategories[mid], ScoringFunctions[mid]);
            root.left = InsertNode(scoringCategories, min, mid - 1, root);
            root.right = InsertNode(scoringCategories, mid + 1, max, root);
        }
        
        /// <summary>
        /// A recursive, divide and conquer algorithm to insert nodes into the Binary Search Tree in a balanced fashion.
        /// </summary>
        /// <param name="scoringCategories"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        public static ScoreCategoryNode InsertNode(ScoringCategories[] scoringCategories, int min, int max, 
            ScoreCategoryNode currentNode)
        {
            if (min > max)
            {
                return null;
            }
            int mid = ((min + max) / 2);

            ScoreCategoryNode newNode = new ScoreCategoryNode(scoringCategories[mid], ScoringFunctions[mid], currentNode);
            newNode.left = InsertNode(scoringCategories, min, mid - 1, newNode);
            newNode.right = InsertNode(scoringCategories, mid + 1, max, newNode);
            newNode.parent = currentNode;
            return newNode;
        }
      
        /// <summary>
        /// Conducts a recursive, pre-order search of the Binary Search Tree for the ScoringCategories enum passed in 
        /// and retrieves the associated ScoringDelegate.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        public static ScoringDelegate SearchScoringDelegates(ScoringCategories category, ScoreCategoryNode currentNode)
        {
            ScoreCategoryNode traversalNode;
            if (root == null)
            {
                throw new ArgumentException();
            }
            else
            {
                if ((int)currentNode.name == (int)category)
                {
                    calculationMethod = (ScoringDelegate)currentNode.method;
                }
                else if ((int)currentNode.name > (int)category)
                {
                    traversalNode = currentNode.left;
                    SearchScoringDelegates(category, traversalNode);
                }
                else if ((int)currentNode.name < (int)category)
                {
                    traversalNode = currentNode.right;
                    SearchScoringDelegates(category, traversalNode);
                }
            }
            return calculationMethod;
        }
    } 
} 