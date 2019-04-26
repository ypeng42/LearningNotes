using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    /*
     * 404. Sum of Left Leaves(easy)
     */
    class SumOfLeftLeaf
    {
        public int SumOfLeftLeaves(TreeNode root)
        {
            return Dfs(root);
        }

        private int Dfs(TreeNode node)
        {
            if (node == null) return 0;

            if (IsLeaf(node.left))
            {
                return node.left.val + Dfs(node.right);
            }

            var left = Dfs(node.left);
            var right = IsLeaf(node.right) ? 0 : Dfs(node.right);

            return left + right;
        }

        private bool IsLeaf(TreeNode node)
        {
            return node != null && node.left == null && node.right == null;
        }
    }
}
