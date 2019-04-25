using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    /*
     * 114. Flatten Binary Tree to Linked List(medium)
     * 
     * Given a binary tree, flatten it to a linked list like tree in-place.
     * If you notice carefully in the flattened tree, each node's right child points to the next node of a pre-order traversal.
     * 
     * Input : 
          1
        /   \
       2     5
      / \     \
     3   4     6

        Output :
            1
             \
              2
               \
                3
                 \
                  4
                   \
                    5
                     \
                      6

        Input :
                1
               / \
              3   4
                 /
                2
                 \
                  5
        Output :
             1
              \
               3
                \
                 4
                  \
                   2
                    \ 
                     5
     */
    public class BinaryTreeToLinkedList
    {
        TreeNode prev = null;
        public void Flatten(TreeNode root)
        {
            Helper(root);
        }

        // Simple in-place operation, the trick is don't forget to save the node reference before it's updated
        private void Helper(TreeNode node)
        {
            if (node == null) return;

            TreeNode leftNode = node.left; // a few lines later, left will set to null, save it here
            TreeNode rightNode = node.right; // after call Helper(leftNode), right node will be updated before Helper(rightNode), save it here.

            if (prev != null)
            {
                prev.right = node;
            }

            node.left = null;
            prev = node;

            Helper(leftNode);
            Helper(rightNode);
        }
    }
}
