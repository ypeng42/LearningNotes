using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.Traversal
{
    /*
     * 230. Kth Smallest Element in a BST(medium)
     */
    class KthSmallestInBST
    {
        // talking about smallest, in-order traversal immediately pops in mind, do it iteratively.
        // Same idea as 94. Binary Tree Inorder Traversal(medium)
        public int KthSmallest(TreeNode root, int k)
        {
            var stack = new Stack<TreeNode>();
            while(root != null)
            {
                stack.Push(root);
                root = root.left;
            }

            int c = 1;
            while(stack.Count > 0)
            {
                var node = stack.Pop();
                if (c == k)
                {
                    return node.val;
                }

                c++;
                node = node.right;
                while(node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
            }

            return 0;
        }

        // ########### Solution No.2
        private int rst = 0;
        private int countdown;
        public int DfsSolution(TreeNode root, int k)
        {
            countdown = k;
            Dfs(root);
            return rst;
        }

        private void Dfs(TreeNode node)
        {
            if (node == null || countdown == 0) return;

            // we are doing in-order traversal here
            Dfs(node.left);

            // action start
            countdown -= 1;

            if (countdown == 0)
            {
                rst = node.val;
            }
            // action end

            Dfs(node.right);
        }
    }
}
