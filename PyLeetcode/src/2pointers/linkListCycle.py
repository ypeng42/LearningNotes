from typing import List
from src.utils import ListNode

"""
https://leetcode.com/problems/linked-list-cycle/  (easy)

Input: head = [3,2,0,-4], pos = 1
Output: true
Explanation: There is a cycle in the linked list, where tail connects to the second node.

Can you solve it using O(1) (i.e. constant) memory?
"""

class Solution:
    def has_cycle(self, head: ListNode) -> bool:
        runner = head
        catcher = head
        while runner is not None and runner.next is not None:
            runner = runner.next.next
            catcher = catcher.next
            if runner == catcher:
                return True

        return False


