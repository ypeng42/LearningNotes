using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    /*
        --Problem(MEDIUM):
        1026. Maximum Difference Between Node and Ancestor
        Given the root of a binary tree, find the maximum value V for which there exists different nodes A and B where 
        V = |A.val - B.val| and A is an ancestor of B.

        (A node A is an ancestor of B if either: any child of A is equal to B, or any child of A is an ancestor of B.)

        --Thought:
        1. Read the problem CLEARLY!! It's binary tree not BST!!
        2. One approach is top down
           Ex.
                  20
                 /  \
               left  right

           For right branch, left branch can be ignored, since they don't share an ancestor.
           Each branch (include 20, the root) will yield a result. The larger one wins.
           
           How to get result for a sub-node?
           The max value could happen:
           (1) between current node and it's parent (not considering current node's children)
                      1
                       \
                        3 - curr
                       / \
                      2   2
           (2) somewhere in current node's left branch (update min, max)
                      1
                       \
                        3 - curr
                       / \
                      4   2
                       \
                       100
           (3) somewhere in current node's right branch (update min, max)
                      1
                       \
                        3 - curr
                       / \
                      1   12
                           \
                           100

           The reulst if the max of 3 situations

         3. For bottom up, see comments below

     */
    class MaxAncestorDiff
    {
        // ##################################### Solution 1: top down approach
        public int Solution1(TreeNode root)
        {
            return Dfs(root, root.val, root.val);
        }

        public int Dfs(TreeNode root, int max, int min)
        {
            if (root == null) return 0;

            // 1. It's FINE this line is meaningless running the first time
            // 2. Potential value 1: at current node
            int res = Math.Max(max - root.val, root.val - min);

            max = Math.Max(max, root.val);
            min = Math.Min(min, root.val);

            res = Math.Max(res, Dfs(root.left, max, min));
            res = Math.Max(res, Dfs(root.right, max, min));

            return res;
        }

        // ##################################### Solution 2: bottom up approach
        /*
         *      a
         *     / \
         *  left  right
         *    
         * For a sub node "a"
         * there are 5 possibilities for max value: 
         * "a" vs.
         * 1-2 min/max from left branch 
         * 3-4 min/max from right branch
         * 5 existing global max value (1-4 are local max)
         * 
         * Find_min_and_max() returns the current node's min/max pair so it's parent can use.
         * 
         * Also, make max_dist a global variable, otherwise the comparsion logic will be more complicated.
         * 
         */
        public int max_dist = 0;
        public int Solution2(TreeNode root)
        {
            Find_min_and_max(root);
            return max_dist;
        }
        public int[] Find_min_and_max(TreeNode node)
        {
            if (node == null) return null;

            // 0 -> min, 1 -> max
            int[] left = Find_min_and_max(node.left);
            int[] right = Find_min_and_max(node.right);
            int left_max = 0, right_max = 0, min = node.val, max = node.val;

            if (left != null)
            {
                left_max = Math.Max(node.val - left[0], left[1] - node.val);
                min = Math.Min(min, left[0]);
                max = Math.Max(max, left[1]);
            }

            if (right != null)
            {
                right_max = Math.Max(node.val - right[0], right[1] - node.val);
                min = Math.Min(min, right[0]);
                max = Math.Max(max, right[1]);
            }

            max_dist = Math.Max(max_dist, Math.Max(left_max, right_max));
            return new int[] { min, max };
        }
    }
}
