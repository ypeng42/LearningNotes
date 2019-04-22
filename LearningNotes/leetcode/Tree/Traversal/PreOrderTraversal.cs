using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 144. Binary Tree Preorder Traversal(medium)
 * Similar problem: 94. Binary Tree Inorder Traversal
 */
namespace LearningNotes.leetcode.Tree
{
    class PreOrderTraversal
    {
        /* recursive solution is too easy.
         * Iterative solution is easier than Inorder Traversal
         * Use a stack and everything just makes sense...
         */
        public IList<int> PreorderTraversal(TreeNode root)
        {
            var rst = new List<int>();
            var stack = new Stack<TreeNode>();

            if (root != null) stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                rst.Add(node.val);

                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);
            }

            return rst;
        }
    }
}
