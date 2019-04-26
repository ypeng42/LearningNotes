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
         *  (2) For each node, we assume the max path will pass through the current node and not involve it's parent.
         *  The current max is: node.val + max from both side.  
         *  
         *  For leaf node, max from both sides are 0, so the max is itself.
         *  Then compare current max with max
         *  
         *  (3) Assume 2 is wrong, and we need to go up. We should offer max value of the path including the current node: node.val + max of left or right
         *  (4) In 3, if max < 0, we should offer 0 as the "max", aka, ignore it~
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

            // think of a leaf node, left and right max will both be 0
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


        //##################### iterative java solution
        // We just need to traverse the nodes in post-order (the same as the order of topological sorting, actually) 
        // storing the maximum root paths in a cache and updating the result value.

        //public Iterable<TreeNode> topSort(TreeNode root)
        //{
        //    Deque<TreeNode> result = new LinkedList<>();
        //    if (root != null)
        //    {
        //        Deque<TreeNode> stack = new LinkedList<>();
        //        stack.push(root);
        //        while (!stack.isEmpty())
        //        {
        //            TreeNode curr = stack.pop();
        //            result.push(curr);
        //            if (curr.right != null) stack.push(curr.right);
        //            if (curr.left != null) stack.push(curr.left);
        //        }
        //    }
        //    return result;
        //}

        //public int maxPathSum(TreeNode root)
        //{
        //    int result = Integer.MIN_VALUE;
        //    Map<TreeNode, Integer> maxRootPath = new HashMap<>(); // cache
        //    maxRootPath.put(null, 0); // for simplicity we want to handle null nodes
        //    for (TreeNode node : topSort(root))
        //    {
        //         as we process nodes in post - order their children are already cached
        //        int left = Math.max(maxRootPath.get(node.left), 0);
        //        int right = Math.max(maxRootPath.get(node.right), 0);
        //        maxRootPath.put(node, Math.max(left, right) + node.val);
        //        result = Math.max(left + right + node.val, result);
        //    }
        //    return result;
        //}
    }
}
