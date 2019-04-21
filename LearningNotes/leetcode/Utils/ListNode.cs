using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Utils
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public static ListNode Convert(int[] source)
        {
            ListNode l, head;
            head = l = new ListNode(source[0]);
            for (int i = 1; i < source.Length; i++)
            {
                l.next = new ListNode(source[i]);
                l = l.next;
            }

            return head;
        }

        public static ListNode PrependZero(ListNode head, int n)
        {
            for (int i = 0; i < n; i++)
            {
                ListNode padding = new ListNode(0)
                {
                    next = head
                };
                head = padding;
            }

            return head;
        }

        public static void AppendZero(ListNode head, int n)
        {
            while (head.next != null)
            {
                head = head.next;
            }

            for (int i = 0; i < n; i++)
            {
                head.next = new ListNode(0);
                head = head.next;
            }
        }

        // the node's address is passed in, no need to create a copy
        public static int Len(ListNode node)
        {
            int l = 0;
            while (node != null)
            {
                l++;
                node = node.next;
            }

            return l;
        }
    }
}
