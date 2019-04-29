using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.Traversal
{
    class NaryPostOrder
    {
        /*
         * 590. N-ary Tree Postorder Traversal
         * 
         * Idea:
         * 145. Binary Tree Postorder Traversal is left and right
         * this one uses a stack to store index
         */
        public IList<int> Postorder(Node root)
        {
            var rst = new List<int>();
            if (root == null) return rst;

            var stack = new Stack<Node>();
            var indexStack = new List<int>(); // it's a stack
            stack.Push(root);
            indexStack.Add(0);
            var currNode = root;

            while (stack.Count > 0)
            {
                while(indexStack[indexStack.Count - 1] < stack.Peek().children.Count)
                {
                    stack.Push(stack.Peek().children[indexStack[indexStack.Count - 1]]);
                    indexStack.Add(0);
                }

                // after while loop reach a leaf node here
                rst.Add(stack.Pop().val);
                indexStack.RemoveAt(indexStack.Count - 1); // pop the stack

                if (indexStack.Count > 0) indexStack[indexStack.Count - 1] += 1;
            }

            return rst;
        }
    }
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }
        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
