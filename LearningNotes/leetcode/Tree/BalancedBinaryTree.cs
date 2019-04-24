using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    /*
     * 110. Balanced Binary Tree(easy)
     */
    class BalancedBinaryTree
    {
        // the trick is to use negative number to indicate something special happened
        public bool IsBalanced(TreeNode root)
        {
            return GetHeight(root) != -1;
        }

        private int GetHeight(TreeNode root)
        {
            if (root == null) return 0;

            var leftHeight = GetHeight(root.left);
            if (leftHeight == -1) return -1;

            var rightHeight = GetHeight(root.right);
            if (rightHeight == -1) return -1;

            if (Math.Abs(leftHeight - rightHeight) > 1) return -1;

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
