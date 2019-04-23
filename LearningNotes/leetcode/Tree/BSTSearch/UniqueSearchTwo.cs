using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.BSTSearch
{
    /*
     * 95. Unique Binary Search Trees II(medium)
     */
    public class UniqueSearchTwo
    {
        /*
         * The process is similar to unique BST
         * 
         * 1. think about how "null" should be generated
         * 
         * 1 2 3 4 5
         * if 1 is the root, it's left branch should be null, how do you know that?
         * 
         * 2. same example above, if 3 is the root
         * left node has 2 possibilities
         * right node has 2 possibilities
         * 
         * it should add all combination to result
         * 
         * 3. [1, 2] and [3, 4] are different now, since we care about node
         * 
         * 4. make a key out of start and end and use memo to save time
         */
        public int cacheHit = 0;
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0) return new List<TreeNode>();
            var memo = new Dictionary<int, IList<TreeNode>>();
            var rst = GenTreeHelper(1, n, memo);
            Console.WriteLine(cacheHit);

            return rst;
        }

        public IList<TreeNode> GenTreeHelper(int start, int end, Dictionary<int, IList<TreeNode>> memo)
        {
            var rst = new List<TreeNode>();
            int hash = GetHash(start, end);

            if (memo.TryGetValue(hash, out IList<TreeNode> cached))
            {
                cacheHit++;
                return cached;
            }

            if (start > end)
            {
                rst.Add(null);
                memo.Add(hash, rst);
                return rst;
            }

            for (int i = start; i <= end; i++)
            {
                var leftNodes = GenTreeHelper(start, i - 1, memo);
                var rightNodes = GenTreeHelper(i + 1, end, memo);
                foreach (TreeNode leftNode in leftNodes)
                {
                    foreach (TreeNode rightNode in rightNodes)
                    {
                        TreeNode node = new TreeNode(i);
                        node.left = leftNode;
                        node.right = rightNode;
                        rst.Add(node);
                    }
                }
            }

            memo.Add(hash, rst);
            return rst;
        }

        private int GetHash(int start, int end)
        {
            // use a really large weight to distinguish start and end
            return start * 1000 + end;
        }
    }
}
