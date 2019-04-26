using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 129. Sum Root to Leaf Numbers (medium)
 */
namespace LearningNotes.leetcode.Tree
{
    class SumRootToLeaf
    {
        /*
         * Think top down, fairly simple
         */ 
        private int sum = 0;
        public int SumNumbers(TreeNode root)
        {
            Dfs(root, 0);
            return sum;
        }

        private void Dfs(TreeNode node, int val)
        {
            if (node == null) return;

            int currVal = val * 10 + node.val;

            if (node.left == null && node.right == null)
            {
                sum += currVal;
            }

            Dfs(node.left, currVal);
            Dfs(node.right, currVal);
        }
    }
}
