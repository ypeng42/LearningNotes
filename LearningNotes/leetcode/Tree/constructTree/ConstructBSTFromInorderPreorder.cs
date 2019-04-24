using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 105. Construct Binary Tree from Preorder and Inorder Traversal(medium)
 */
namespace LearningNotes.leetcode.Tree.constructTree
{
    class ConstructBSTFromInorderPreorder
    {
        private Dictionary<int, int> inorderValToIndex = new Dictionary<int, int>();
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderValToIndex.Add(inorder[i], i);
            }

            return Helper(preorder, 0, inorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        private TreeNode Helper(int[] preorder, int ps, int pe, int[] inorder, int ins, int ine)
        {
            if (pe < ps || ine < ins) return null;

            var rootVal = preorder[ps];
            var node = new TreeNode(rootVal);

            var inorderRootIndex = inorderValToIndex[rootVal];
            var numLeftTreeNode = inorderRootIndex - ins;

            // for post-order: end - (ps + 1) + 1 = numLeftTreeNode
            var postorderLeftEnd = ps + numLeftTreeNode;
            node.left = Helper(preorder, ps + 1, postorderLeftEnd, inorder, ins, inorderRootIndex - 1);
            node.right = Helper(preorder, postorderLeftEnd + 1, pe, inorder, inorderRootIndex + 1, ine);

            return node;
        }
    }
}
