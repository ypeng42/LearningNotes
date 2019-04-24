using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    class SymmetricTree
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return Helper(root.left, root.right);
        }

        private bool Helper(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;

            if (left.val != right.val)
            {
                return false;
            }

            return Helper(left.left, right.right) && Helper(left.right, right.left);
        }
    }
}
