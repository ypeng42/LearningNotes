from src.utils.ListNode import ListNode

# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None


class Solution:
    def addTwoNumbers(self, l1, l2):
        curr = dummy = ListNode(-1)
        c = 0

        while l1 != None or l2 != None:
            val1 = l1.val if l1 != None else 0
            val2 = l2.val if l2 != None else 0
            sum = val1 + val2 + c
            c = sum // 10

            curr.next = ListNode(sum % 10)
            curr = curr.next

            if l1 != None: l1 = l1.next
            if l2 != None: l2 = l2.next

        if c > 0:
            curr.next = ListNode(1)

        return dummy.next


