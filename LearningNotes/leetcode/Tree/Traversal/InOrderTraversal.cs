using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    /*
     * 94. Binary Tree Inorder Traversal(medium)
     * Follow up: Recursive solution is trivial, could you do it iteratively?
     */
    class InOrderTraversal
    {
        /*
         * The harder part...
         */
        public IList<int> IterativeSolution(TreeNode root)
        {
            var rst = new List<int>();
            var stack = new Stack<TreeNode>();
            TreeNode curr = root;

            while (curr != null || stack.Count != 0)
            {
                /* How to do this using pen and paper?
                 * First, we go furtherest left, add it; go to it's parent, add it; go right, and then repeat
                 */
                while (curr != null)
                {
                    stack.Push(curr); // 'root' goes bottom, left on top
                    curr = curr.left;
                }

                curr = stack.Pop();
                rst.Add(curr.val); // treat curr like 'root', left is already added. After root, it's 'right' turn
                curr = curr.right;
            }

            return rst;
        }

        // The easy recursive solution
        public IList<int> InorderTraversal(TreeNode root)
        {
            var rst = new List<int>();
            Helper(root, rst);
            return rst;
        }

        private void Helper(TreeNode root, List<int> rst)
        {
            if (root == null) return;

            Helper(root.left, rst);
            rst.Add(root.val);
            Helper(root.right, rst);
        }
    }
}
