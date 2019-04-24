using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.constructTree
{
    /*
     * 106. Construct Binary Tree from Inorder and Postorder Traversal(medium)
     * 
     * Why a single array is not enough?
     * Ex. Inorder is left, root, right, but given an array. ex [2, 1, 3], you won't be able to know
     * whether 2 is left or root
     * 
     * 1.
     * The reason this kind of problem require either pre-order or post-order is in those 2 traversal we can
     * fix the position of root (one is 1st, one is last). And then use inorder to get the number of node in 
     * left/right branch
     * 
     * 
     * 2. Ex
     * inorder = [9,3,15,20,7]
     * postorder = [9,15,7,20,3]
     * 
     * "3" is the root, in inorder we know 9 is left, 15, 20, 7 is right.
     * The question is: how to find root for those 2 subtree?
     * 
     * Simple! from inorder, we know left tree has 1 node, right tree has 3 nodes.
     * Then we know in post-order
     * [0, 0] is the range of left
     * [1, 3] is the range of right
     * the last index is the root, and we repeat this process.
     * 
     * 3. have start, end to indicate the range of the tree in the array
     * 
     * 4. You may assume that duplicates DO NOT EXISTS in the tree!!!!!
     */
    public class ConstructBSTFromInorderPostorder
    {
        private Dictionary<int, int> inorderValToIndex = new Dictionary<int, int>();

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderValToIndex.Add(inorder[i], i);
            }

            return Helper(postorder, 0, postorder.Length - 1, inorder, 0, postorder.Length - 1);
        }

        private TreeNode Helper(int[] postorder, int ps, int pe, int[] inorder, int ins, int ine)
        {
            if (ps > pe || ins > ine) return null;

            var rootVal = postorder[pe];
            var node = new TreeNode(rootVal);

            var inorderRootIndex = inorderValToIndex[rootVal];
            var numLeftTreeNode = inorderRootIndex - ins;

            // ps + numLeftTreeNode - 1 because end - start + 1 should equal numLeftTreeNode
            var postOrderLeftEnd = ps + numLeftTreeNode - 1;
            node.left = Helper(postorder, ps, postOrderLeftEnd, inorder, ins, inorderRootIndex - 1);
            node.right = Helper(postorder, postOrderLeftEnd + 1, pe - 1, inorder, inorderRootIndex + 1, ine);

            return node;
        }
    }
}
