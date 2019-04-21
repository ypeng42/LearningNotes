using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    /*
     * Problem(HARD):
     * 1028. Recover a Tree From Preorder Traversal
     * We run a preorder depth first search on the root of a binary tree.

        At each node in this traversal, we output D dashes (where D is the depth of this node), then we output the value of this node.  (If the depth of a node is D, the depth of its immediate child is D+1.  The depth of the root node is 0.)

        If a node has only one child, that child is guaranteed to be the left child.

        Given the output S of this traversal, recover the tree and return its root.

        Input: "1-2--3--4-5--6--7"
        Output: [1,2,5,3,4,6,7]

        Thought:
        The idea is fairly simple, since pre-order is root, left, right
        We first get the value for root
        then process the whole left branch
        then process the whole right branch
     */
    public class RecoverFromPreorder
    {
        public TreeNode Solution(string s)
        {
            int i = 0;
            return Parse(s, ref i, 0);
        }

        /// <summary>
        /// the helper method to parse the string
        /// </summary>
        /// <param name="s">the string to be parsed</param>
        /// <param name="i">the current index in the string being processed</param>
        /// <param name="dep">the depth of the tree, the current parsed node should be added to</param>
        /// <returns></returns>
        public TreeNode Parse(string s, ref int i, int dep)
        {
            //Console.WriteLine(i + " " + dep);

            int rootVal = 0;
            for (; i < s.Length && s[i] != '-'; ++i)
            {
                rootVal = rootVal * 10 + (s[i] - '0');
            }
            TreeNode root = new TreeNode(rootVal);
            int c = 0, j;

            // Here is the tricky part
            // Ex. 1-2--3, and we are at 2 now.
            // We don't want to blindly proceed and increment i. 
            // Use a placeholder j to do the "exploring"
            for (j = i; j < s.Length && s[j] == '-'; ++j) ++c;
            if (c == dep + 1)
            {
                // Only after sure to proceed to parse, we increment i
                i = j;
                root.left = Parse(s, ref i, dep + 1);
            }

            c = 0;
            for (j = i; j < s.Length && s[j] == '-'; ++j) ++c;
            if (c == dep + 1)
            {
                i = j;
                root.right = Parse(s, ref i, dep + 1);
            }

            return root;
        }
    }
}
