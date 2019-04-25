using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 124. Binary Tree Maximum Path Sum(hard)
 * 
 * For this problem, a path is defined as any sequence of nodes from some starting node to 
 * any node in the tree along the parent-child connections. The path must contain at least 
 * one node and does not need to go through the root.
 * 
 * Node can have negative value
 */
namespace LearningNotes.leetcode.Tree.PathSum
{
    public class MaxPathSum
    {
        /*
         * 1. we will have a global tracker for max
         * 
         * 2. When think about this, think bottom up
         * Start from a leaf node, instead of thinking starting from the root
         * 
         * 3.
         *     -1
         *     / \
         *   -2   3
         *  
         *  
         *  (1) Before we get to root, we already compare left and right leaf node and get max out of them.
         *  (2) if max < 0, we should offer 0 as the max for this path
         *  (3) Assume max path will pass through root -> we compare current max  vs. node.val + max from both side.
         *  (4) Continue from 2: Assumption in 3 might not be right, when offering max value of the path including root, have to pick either left or right
         */

        private int max = 0;
        public int Solution(TreeNode root)
        {
            Dfs(root);
            return max;
        }

        private int Dfs(TreeNode node)
        {
            if (node == null) return 0;

            int leftMax = Dfs(node.left);
            int rightMax = Dfs(node.right);

            // think of leaf node, before we hit parent, we already compare left and right leaf node and get max out of them
            max = Math.Max(max, leftMax + node.val + rightMax);

            // current node should be in the path to make result path continue, so add it no matter what
            return Math.Max(0, Math.Max(leftMax, rightMax) + node.val);
        }


        // This is wrong because the path returned each time may not include current node, which will result in disconnected path

        //public int MaxPathSumS(TreeNode root)
        //{
        //    return Dfs(root);
        //}

        //private int Dfs(TreeNode node)
        //{
        //    if (node == null) return 0;
        //    if (node.left == null && node.right == null) return node.val;

        //    int leftMax = Dfs(node.left);
        //    int rightMax = Dfs(node.right);

        //    if (node.left != null && node.right != null)
        //    {
        //        int includeNode = node.val + Math.Max(0, leftMax) + Math.Max(0, rightMax);
        //        return Math.Max(includeNode, Math.Max(leftMax, rightMax));
        //    }
        //    else if (node.left != null)
        //    {
        //        int includeNode = node.val + Math.Max(0, leftMax);
        //        return Math.Max(includeNode, leftMax);
        //    }
        //    else
        //    {
        //        int includeNode = node.val + Math.Max(0, rightMax);
        //        return Math.Max(includeNode, rightMax);
        //    }

        //}
    }
}
