using System;
using LearningNotes.leetcode.Utils;

namespace LearningNotes.leetcode
{
    /*
     * 2. Add Two Numbers (Medium)
     * 
     * Example:
     *  Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        Output: 7 -> 0 -> 8
        Explanation: 342 + 465 = 807.
     */
    public class ListAddTwoNumbers
    {
        // the idea is really simple, solve it as how a human would do it
        // Becareful: 
        // 1. don't need to append 0 since the order is lower bit to higher bit  
        // 2. don't forget the left over carry 
        // 3. use a trash node to initialize to make code less verbose

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = null;
            ListNode tracker = null;
            int carry = 0;

            while (l1 != null || l2 != null)
            {
                int val1 = l1 == null ? 0 : l1.val;
                int val2 = l2 == null ? 0 : l2.val;
                int sum = val1 + val2 + carry;
                carry = sum / 10;
                int val = sum - carry * 10;

                if (tracker == null)
                {
                    tracker = new ListNode(val);
                    head = tracker;
                } else
                {
                    tracker.next = new ListNode(val);
                    tracker = tracker.next;
                }

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            // really to easy to forget that, ex. 5 + 5 = 10, don't forget the left over carry
            if (carry != 0)
            {
                tracker.next = new ListNode(1);
            }

            return head;
        }

        // A little less verbose compared to above
        public ListNode Solution(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(-1), tracker = head; // this is the trick to make it less verbose, this node will be ignored later
            int carry = 0;

            while (l1 != null || l2 != null)
            {
                int val1 = l1 == null ? 0 : l1.val;
                int val2 = l2 == null ? 0 : l2.val;
                int sum = val1 + val2 + carry;
                carry = sum / 10;
                int val = sum - carry * 10;

                tracker.next = new ListNode(val); // the if else block to initialize null tracker can be removed here
                tracker = tracker.next;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            // really to easy to forget that, ex. 5 + 5 = 10, don't forget the left over carry
            if (carry != 0)
            {
                tracker.next = new ListNode(1);
            }

            return head.next; // ignore the trash node
        }
    }
}
