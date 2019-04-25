using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.InPlaceOperation
{
    /*
     * 116. Populating Next Right Pointers in Each Node(medium)
     * 
     * Input is perfect binary tree
     * Note:
        You may only use constant extra space.
        Recursive approach is fine, implicit stack space does not count as extra space for this problem.
     */
    class PopulateNextRightPointer
    {
        /*
         * Since it wants node.left.next = node.right
         * we create a helper function to do exact that
         * 
         *       1
         *      / \
         *     2   3
         *    / \ / \
         *   4  5 6  7
         * 
         * When we are at 2, the tricky part is to recognize to connect  5.next = 6 
         * 5 is curr.right
         * 6 is curr.next.left
         * 
         * the rest is simple
         */ 
        public Node Connect(Node root)
        {
            Helper(root, null);
            return root;
        }

        private void Helper(Node curr, Node nextNode)
        {
            if (curr == null) return;

            curr.next = nextNode;

            Helper(curr.left, curr.right);
            Helper(curr.right, nextNode == null ? null : nextNode.left);
        }
    }
}
