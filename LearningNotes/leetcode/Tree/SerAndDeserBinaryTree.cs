using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree
{
    /*
     * 297. Serialize and Deserialize Binary Tree(hard)
     * 
     * Design an algorithm to serialize and deserialize a binary tree. 
     * There is no restriction on how your serialization/deserialization algorithm should work. 
     * You just need to ensure that a binary tree can be serialized to a string and this string 
     * can be deserialized to the original tree structure.
     * 
     * Note: Do not use class member/global/static variables to store states. 
     * Your serialize and deserialize algorithms should be stateless.
     * 
     * 449. Serialize and Deserialize BST 
     * for bst, adding "null" is not necessary since can use max min to determine end of a branch
     */
    class SerAndDeserBinaryTree
    {
        /*
         * preorder or postorder could work, since position of root is defined.
         * Key point: null node should also be added to disambiguate
         */ 
        public string serialize(TreeNode root)
        {
            var rst = new StringBuilder();
            Dfs(root, rst);
            return string.Join(",", rst); 
        }

        private void Dfs(TreeNode node, StringBuilder rst)
        {
            if (node == null)
            {
                rst.Append("null ");
                return;
            }
            rst.Append(node.val.ToString());
            rst.Append(" ");
            Dfs(node.left, rst);
            Dfs(node.right, rst);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            var list = data.Split(' ');
            return ArrayToTree(list, new int[] {0});
        }

        private TreeNode ArrayToTree(string[] list, int[] index)
        {
            if (index[0] >= list.Length) return null;

            if (list[index[0]].Equals("null"))
            {
                index[0]++;
                return null;
            }

            var node = new TreeNode(Convert.ToInt32(list[index[0]]));
            index[0]++;
            node.left = ArrayToTree(list, index);
            node.right = ArrayToTree(list, index);

            return node;
        }
    }
}
