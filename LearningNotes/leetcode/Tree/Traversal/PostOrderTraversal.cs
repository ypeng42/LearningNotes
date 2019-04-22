using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    /*
     * 145. Binary Tree Postorder Traversal(hard)
     */
    class PostOrderTraversal
    {
        /*
         * This is the hardest iterative solution of all 3 traversal
         * To start, first draw a tree and see how is the order of the result
         */
        public IList<int> PostorderTraversal(TreeNode root)
        {
            var rst = new List<int>();
            var stack = new Stack<TreeNode>();
            TreeNode currNode = root;

            while (currNode != null || stack.Count != 0)
            {
                // the idea of this logic is similar to pre-order
                while (currNode != null)
                {
                    stack.Push(currNode);
                    if (currNode.left != null)
                    {
                        currNode = currNode.left;
                    } else
                    {
                        currNode = currNode.right;
                    }
                }

                // don't use currNode here. We are only getting the val of this node, and then it's no more use.
                // currNode is used to add stuff to stack
                TreeNode node = stack.Pop();
                rst.Add(node.val);

                // after left, we go right. This is how
                if (stack.Count != 0 && stack.Peek().left == node)
                {
                    // we don't want to Pop() here, since after left, we do right. and then pop will take care of root
                    currNode = stack.Peek().right;
                }

            }

            return rst;
        }
    }
}
