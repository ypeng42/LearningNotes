using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    /*
     * 450. Delete Node in a BST(medium)
     */
    public class DeleteNodeBST
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;

            if (root.val > key)
            {
                root.left = DeleteNode(root.left, key); // don't forget to set the root
            }
            else if (root.val < key)
            {
                root.right = DeleteNode(root.right, key);
            } else
            {
                if (root.left == null && root.right == null)
                {
                    root = null; // leaf node will be replaced by null
                } else if (root.right != null)
                {
                    root.val = GetSuccessor(root);
                    root.right = DeleteNode(root.right, root.val); // don't forget to set the root
                } else if (root.left != null)
                {
                    root.val = GetPredecessor(root);
                    root.left = DeleteNode(root.left, root.val);
                }
            }

            return root;
        }

        private int GetPredecessor(TreeNode root)
        {
            var node = root.left;
            while(node.right != null)
            {
                node = node.right;
            }
            return node.val;
        }

        // leaf check is done, assume input will not be leaf
        private int GetSuccessor(TreeNode root)
        {
            var node = root.right;
            while (node.left != null)
            {
                node = node.left;
            }
            return node.val;
        }
    }
}
