using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Utils
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }


        public static int?[] TreeToArray(TreeNode root)
        {
            int depth = GetDepth(root);
            var rst = new int?[(int)Math.Pow(2, depth)];

            PopulateArray(root, 0, rst);
            
            return rst;
        }

        private static void PopulateArray(TreeNode root, int i, int?[] rst)
        {
            if (root == null || i >= rst.Length) return;

            rst[i] = root.val;
            PopulateArray(root.left, i * 2 + 1, rst);
            PopulateArray(root.right, i * 2 + 2, rst);
        }

        public static int GetDepth(TreeNode root)
        {
            if (root == null) return 0;

            return Math.Max(GetDepth(root.left), GetDepth(root.right)) + 1;
        }

        /* ex. [2, 1, 3]
         * 
         *       2
         *      / \
         *     1   3
         *     
         * ex [1, 3, null, null, 2]
         *    1
         *   /
         *  3
         *   \
         *    2
         */
        public static TreeNode ArrayToTree(int?[] input)
        {
            return ArrayToTreeHelper(0, input);
        }
        private static TreeNode ArrayToTreeHelper(int n, int?[] input)
        {
            if (n >= input.Length || input[n] == null) return null;

            var node = new TreeNode((int) input[n]);
            node.left = ArrayToTreeHelper(n * 2 + 1, input);
            node.right = ArrayToTreeHelper(n * 2 + 2, input);

            return node;
        }
    }
}
