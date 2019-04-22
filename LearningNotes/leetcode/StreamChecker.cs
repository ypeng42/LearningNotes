using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    class TrieNode
    {
        public Dictionary<char, TrieNode> Children { set; get; }
        public bool IsWord { set; get; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            IsWord = false;
        }

    }
    class StreamChecker
    {
        private TrieNode root;

        /* 
         * The tricky part of this problem is, read the problem Carefully:
         * init: ["ab","ba","aaab","abab","baa"]
         * query:
         * aaaaabababb
         *       ^
         * ba is one of the target
         * At previous b, aaab is also target.
         * 
         * Notice we check from Left to Right! The current pointer is the End of the word.
         * We want to initiate the checking from the current pointer. 
         * Otherwise we won't know where to start, aaab could be right, aaaaaaaab could be right, how far left we should go? we don't know.
         * 
         * Therefore, when construct the trie, we insert the word in Reverse order, so we can use current point to initiate checking.
         */

        //private TrieNode pointer; forward thinking won't work here
        private List<char> window;
        private int maxWordLen;

        public StreamChecker(string[] words)
        {
            root = new TrieNode();
            window = new List<char>();

            for (int i = 0; i < words.Length; i++)
            {
                maxWordLen = Math.Max(maxWordLen, words.Length);
                TrieNode currNode = root;
                string word = words[i];

                for (int j = word.Length - 1; j >= 0; j--)
                {
                    char c = word[j];
                    if (currNode.Children.TryGetValue(c, out TrieNode next))
                    {
                        currNode = next;
                    } 
                    else
                    {
                        var newNode = new TrieNode();
                        currNode.Children.Add(c, newNode);
                        currNode = newNode;
                    }
                }

                currNode.IsWord = true;
            }
        }

        public bool Query(char letter)
        {
            window.Insert(0, letter);
            if (window.Count > maxWordLen) window.RemoveAt(window.Count - 1); // sliding window shouldn't be larger than the longest word

            TrieNode node = root;
            foreach (char c in window)
            {
                if(node.Children.TryGetValue(c, out TrieNode next))
                {
                    node = next;
                    // stop once we find a result
                    if (node.IsWord)
                    {
                        return true;
                    }
                } else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
