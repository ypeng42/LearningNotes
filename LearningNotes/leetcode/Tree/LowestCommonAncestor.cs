using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    class LowestCommonAnce
    {
        /*
         * 236. Lowest Common Ancestor of a Binary Tree(medium)
         */
        public TreeNode LowestCommonAncestor(TreeNode node, TreeNode p, TreeNode q)
        {
            // Coming up the termination condition is 50% of the solution
            // The goal is not find both but find "either"
            if (node == null || node == p || node == q) return node;

            // This is clearly a bottom up question
            var left = LowestCommonAncestor(node.left, p, q);
            var right = LowestCommonAncestor(node.right, p, q);

            if (left != null && right != null) return node;

            if (left != null) return left;
            if (right != null) return right;

            return null;
        }
    }
}
