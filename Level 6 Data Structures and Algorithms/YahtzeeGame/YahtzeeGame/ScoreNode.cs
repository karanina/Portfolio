using System;
using System.Collections.Generic;
using System.Text;

namespace YahtzeeGame
{
    public class ScoreNode
    {
        public ScoreNode next;
        public int roundScore;
        public int[,] roundDiceTotals;
        public ScoreCategoryBinaryTree.ScoringCategories roundCategory;

        /// <summary>
        /// Constructor method
        /// </summary>
        public ScoreNode()
        {
            this.next = null;
            this.roundScore = 0;
        }
        /// <summary>
        /// Alternate constructor method
        /// </summary>
        /// <param name="roundDiceTotals"></param>
        /// <param name="category"></param>
        public ScoreNode(int[,] roundDiceTotals, ScoreCategoryBinaryTree.ScoringCategories category):this()
        {
            this.roundDiceTotals = roundDiceTotals;
            this.roundCategory = category;
        }
    }
}
