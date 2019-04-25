using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 117. Populating Next Right Pointers in Each Node II(medium)
 * 
 * Unlike 116, input is not perfect binary tree
 * 
 * Note:
    You may only use constant extra space.
    Recursive approach is fine, implicit stack space does not count as extra space for this problem.
 */
namespace LearningNotes.leetcode.Tree.InPlaceOperation
{
    class PopulateNextRightPointerTwo
    {
        /*
         * Last one's approach won't work
         * 
         *       1
         *      / \
         *     2   3
         *    /   / \
         *   4   5   6
         *  /         \
         * 7           8
         *  
         *  Long distance between 7 and 8!!
         *  
         *  When we are at 4, what should be the next for 7 if 4 doesn't have a right node?
         *  remember 4 -> 5 -> 6
         *  the answer is: the first child (left before right) of the chain 4 -> 5 -> 6
         */ 
        public Node Connect(Node root)
        {
            if (root == null) return null;
            
            if (root.left != null)
            {
                if (root.right != null)
                {
                    // have both child, easy case
                    root.left.next = root.right;
                } else
                {
                    // the case we mentioned above
                    root.left.next = FindNext(root.next);
                }
            }

            if (root.right != null)
            {
                root.right.next = FindNext(root.next);
            }

            // need to do right first. Consider the above case, to know 7 points to 8, when we get to 7, we need to have the chain 4 -> 5 -> 6 
            // ready. Only do right side first can make sure we have all the necessary "next" info
            Connect(root.right); 
            Connect(root.left);
            return root;
        }

        private Node FindNext(Node node)
        {
            if (node == null) return null;
            if (node.left != null) return node.left;
            if (node.right != null) return node.right;

            return FindNext(node.next);
        }
    }
}
