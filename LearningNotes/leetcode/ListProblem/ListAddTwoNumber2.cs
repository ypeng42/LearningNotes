using System;
using LearningNotes.leetcode.Utils;

namespace LearningNotes.leetcode.ListProblem
{
    /*
     * 445. Add Two Numbers II (Medium)
     * 
     * You are given two NON-empty linked lists representing two non-negative integers. 
     * The most significant digit comes first and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

        You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        Follow up:
        What if you CANNOT Modify the input lists? In other words, reversing the lists is not allowed.

     *  Example:
     *  Input: (7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
        Output: 7 -> 8 -> 0 -> 7
     */
    class ListAddTwoNumber2
    {
        // Similar to Add Two Number, add a recursive step
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int len1 = ListNode.Len(l1);
            int len2 = ListNode.Len(l2);
            if (len1 > len2)
            {
                l2 = ListNode.PrependZero(l2, len1 - len2);
            } else
            {
                l1 = ListNode.PrependZero(l1, len2 - len1);
            }

            var tuple = Calculate(l1, l2);
            var rst = tuple.Item1;
            if (tuple.Item2 != 0)
            {
                var node = new ListNode(1);
                node.next = rst;
                rst = node;
            }

            return rst;
        }

        private Tuple<ListNode, int> Calculate(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null) return null;

            var tuple = Calculate(l1.next, l2.next);

            int sum = l1.val + l2.val + (tuple == null ? 0 : tuple.Item2);
            int carry = sum / 10;
            int val = sum - carry * 10;

            ListNode node = new ListNode(val);
            node.next = tuple?.Item1;

            return Tuple.Create(node, carry);
        }
    }
}
