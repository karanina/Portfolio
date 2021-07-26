using System;
using System.Collections.Generic;
using System.Text;

namespace YahtzeeGame
{
    public class ScoreCategoryNode
    {
        public ScoreCategoryBinaryTree.ScoringCategories name;
        public Delegate method;
        public ScoreCategoryNode parent;
        public ScoreCategoryNode left;
        public ScoreCategoryNode right;

        /// <summary>
        /// Constructor method
        /// </summary>
        public ScoreCategoryNode()
        {
            this.parent = null;
            this.left = null;
            this.right = null;
        }

        /// <summary>
        /// Alternate constructor method
        /// </summary>
        /// <param name="name"></param>
        /// <param name="method"></param>
        public ScoreCategoryNode(ScoreCategoryBinaryTree.ScoringCategories name, Delegate method):this()
        {
            this.name = name;
            this.method = method;
        }

        /// <summary>
        /// Alternate constructor method
        /// </summary>
        /// <param name="name"></param>
        /// <param name="method"></param>
        /// <param name="parent"></param>
        public ScoreCategoryNode(ScoreCategoryBinaryTree.ScoringCategories name, Delegate method, ScoreCategoryNode parent) : this(name, method)
        {
            this.parent = parent;
        }
    }
}
