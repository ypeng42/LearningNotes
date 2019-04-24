using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.PathSum
{
    /*
     * 112. Path Sum(easy)
     */
    class PathSum
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            return Helper(root, 0, sum);
        }

        private bool Helper(TreeNode node, int sum, int target)
        {
            if (node == null) return false; // you can't have something out of nothing!

            if (IsLeaf(node) && (node.val + sum == target)) return true;

            return Helper(node.left, node.val + sum, target) || Helper(node.right, node.val + sum, target);
        }

        private bool IsLeaf(TreeNode node)
        {
            return (node.left == null) && node.right == null;
        }
    }
}
