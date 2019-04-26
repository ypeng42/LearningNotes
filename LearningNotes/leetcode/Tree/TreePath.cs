using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    /*
     * 257. Binary Tree Paths(easy)
     */
    class TreePath
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var path = new List<int>();
            var rst = new List<string>();
            Dsf(root, path, rst);

            return rst;
        }

        private void Dsf(TreeNode node, List<int> path, List<string> rst)
        {
            if (node == null) return;

            path.Add(node.val);

            if (node.left == null && node.right == null)
            {
                rst.Add(PrintList(path)); // add rst for leaf node
                path.RemoveAt(path.Count - 1);
                return;
            }

            // Backtracking here is that, we back track at leaf node and non-leaf node, instead of left and right
            Dsf(node.left, path, rst);
            Dsf(node.right, path, rst);
            path.RemoveAt(path.Count - 1);
        }

        public String PrintList(List<int> list)
        {
            if (list.Count == 0) return null;

            StringBuilder sb = new StringBuilder();
            sb.Append(list[0]);

            for (int i = 1; i < list.Count; i++)
            {
                sb.Append("->" + list[i].ToString());
            }

            return sb.ToString();
        }
    }
}
