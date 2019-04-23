using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    /*
     * 99. Recover Binary Search Tree(hard)
     * 
     * A solution using O(n) space is pretty straight forward.
     * 1. pre-order traverse the tree and turn it into array
     * 2. sort the array
     * 
     * 3. compare the 2 arry, find the 2 difference and correct them 
     * [4 20 15 8]
     * [4 8 15 20]
     * 
     * 
     * 
     * Could you devise a constant space solution?
     * 1. what we are trying to find are the 2 trouble maker. After we find them, we swap their value and done
     * 
     * 2. The first one is always the larger one, the second one is always the smaller one. Remember after swaping them, we should
     * get a sorted array
     * [4 20 15 8]
     * 
     * 3. So how to get them?
     * by comparing curr to prev, the first one > curr, and the second one < prev (read point No.2 more)
     */
    public class RecoverBST
    {
        private TreeNode first;
        private TreeNode second;
        private TreeNode prev;
        public TreeNode RecoverTree(TreeNode root)
        {
            Helper(root);
            int temp = first.val;
            first.val = second.val;
            second.val = temp;

            return root;
        }

        private void Helper(TreeNode node)
        {
            /*
             * early termination is not possible, because when find node.val < prev.val, we will set both first and second
             * and we won't be able to know whether the "second" is the correct "second"
             * 
             * ex. in [3,1,4,null,null,2], the array is [1, 3, 2, 4]
             * in this case, 3 and 2 are next to each other, and we get them in 1 pass
             * 
             * ex. array is [6, 3, 4, 5, 2]
             * in this case 6 and 2 are not next to each other. In first pass, first = 6 and second = 3, which is incorrect!
             * 
             * No way to tell
             */

            //if (node == null || (first != null && second != null)) return;

            if (node == null) return;
            Helper(node.left);

            // do work
            if (first == null && prev != null && node.val < prev.val)
            {
                first = prev;
            }

            if (first != null && node.val < prev.val)
            {
                second = node;
            }

            prev = node; // finish doing work for the current node, so curr turns into prev
            // end of do work

            Helper(node.right);
        }
    }
}
