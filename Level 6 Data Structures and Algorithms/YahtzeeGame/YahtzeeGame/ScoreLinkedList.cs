using System;
using System.Collections.Generic;
using System.Text;

namespace YahtzeeGame
{
    public class ScoreLinkedList
    {
        public int numberOfRounds;
        public const int maxRounds = 13;
        public int upperSectionScore;
        public int lowerSectionScore;
        public int totalScore;
        public bool hasYahtzee = false;
        public bool hasUpperSectionBonus = false;
        
        public ScoreNode head;

        public ScoreLinkedList()
        {
            this.numberOfRounds = 0;
            this.upperSectionScore = 0;
            this.lowerSectionScore = 0;
            this.totalScore = 0;
            this.head = null;
        }
        /// <summary>
        /// Adds a new ScoreNode to the ScoreLinkedList as long as the chosen category has not already recorded a score. 
        /// Also checks if the player is eligable for the Upper Section Bonus and the Yahtzee Bonus.
        /// Returns a bool to confirm that the node was able to be created.
        /// </summary>
        /// <param name="roundDiceTotals"></param>
        /// <param name="roundCategory"></param>
        public bool AddNode(int[,] roundDiceTotals, ScoreCategoryBinaryTree.ScoringCategories roundCategory)
        {
            if (ContainsNode(roundCategory))
            {
                return false;
            }
            else 
            { 
                ScoreNode newNode = new ScoreNode(roundDiceTotals, roundCategory);
                newNode.next = this.head;
                this.head = newNode;
                numberOfRounds++;

                ScoreCategoryBinaryTree.ScoringDelegate CalculationMethod 
                    = ScoreCategoryBinaryTree.SearchScoringDelegates(roundCategory, ScoreCategoryBinaryTree.root);
                newNode.roundScore = CalculationMethod(roundDiceTotals);
                if (hasYahtzee == true && Scoring.IsYahtzee(newNode.roundDiceTotals) == true)
                {
                    newNode.roundScore += Scoring.yahtzeeBonus;
                }
                if (newNode.roundCategory == ScoreCategoryBinaryTree.ScoringCategories.Yahtzee && newNode.roundScore > 0)
                {
                    hasYahtzee = true;
                }

                if ((int)roundCategory < Dice.diceSides)
                {
                    this.upperSectionScore += newNode.roundScore;
                    if (this.upperSectionScore >= Scoring.upperSectionBonusRequired)
                    {
                        this.hasUpperSectionBonus = true;
                        this.upperSectionScore += Scoring.upperSectionBonus;
                    }
                }
                else
                {
                    this.lowerSectionScore += newNode.roundScore;
                }
                this.totalScore = this.lowerSectionScore + this.upperSectionScore;
            }
            return true;
        }

        /// <summary>
        /// Searches the Linked List to see if a score has already been entered into the chosen category for this round.
        /// Returns true if it is found, false if it is not, and is therefore available for scoring.
        /// </summary>
        /// <param name="roundCategory"></param>
        /// <returns></returns>
        public bool ContainsNode (ScoreCategoryBinaryTree.ScoringCategories roundCategory)
        {
            ScoreNode traversalNode = this.head;
            while (traversalNode != null)
            {
                if (traversalNode.roundCategory == roundCategory)
                {
                    return true;
                }
                else
                {
                    traversalNode = traversalNode.next;
                }
            }
            return false;
        }
       
        /// <summary>
        /// Traverses through the list to retrieve the score that belongs to the specified category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int RetrieveScore(ScoreCategoryBinaryTree.ScoringCategories category)
        {
            ScoreNode traversalNode = this.head;
            while (traversalNode != null)
            {
                if (traversalNode.roundCategory == category)
                {
                    return traversalNode.roundScore;
                }
                else
                {
                    traversalNode = traversalNode.next;
                }
            }
            return 0;
        }

        /// <summary>
        /// Severs the memory address of the head and reverts the Number of Rounds and Scores to 0 when a new ScoreLinkedList
        /// is required.
        /// </summary>
        public void EmptyList()
        {
            this.numberOfRounds = 0;
            this.upperSectionScore = 0;
            this.lowerSectionScore = 0;
            this.totalScore = 0;
            this.head = null;
        }
    }
}
