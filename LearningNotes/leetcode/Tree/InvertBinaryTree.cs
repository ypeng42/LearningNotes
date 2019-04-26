using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    /*
     * 226. Invert Binary Tree(easy)
     */
    class InvertBinaryTree
    {
        // This is clearly what I called "bottom up" question. So action comes after recursion, besides this, piece of cake
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;

            var left = root.left;
            var right = root.right;
            InvertTree(left);
            InvertTree(right);

            root.left = right;
            root.right = left;

            return root;
        }
    }
}
