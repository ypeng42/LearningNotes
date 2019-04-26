using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    /*
     * 173. Binary Search Tree Iterator(medium)
     * 
     * Note:
        next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.
        You may assume that next() call will always be valid, that is, there will be at least a next smallest number 
        in the BST when next() is called.

     */
    public class BSTIterator
    {
        // Similar idea as 94. Binary Tree Inorder Traversal(medium)
        private Stack<TreeNode> stack = new Stack<TreeNode>();
        public BSTIterator(TreeNode root)
        {
            var node = root;
            while(node != null)
            {
                stack.Push(node);
                node = node.left;
            }
        }

        /** @return the next smallest number */
        public int Next()
        {
            var node = stack.Pop();
            var rst = node.val;
            node = node.right;
            while (node != null)
            {
                stack.Push(node);
                node = node.left;
            }
            return rst;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return stack.Count > 0;
        }
    }
}
