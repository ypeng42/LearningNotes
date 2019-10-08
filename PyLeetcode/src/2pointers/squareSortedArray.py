from typing import List
import collections
"""
https://leetcode.com/problems/squares-of-a-sorted-array/
977. Squares of a Sorted Array (easy)


Input: [-7,-3,2,3,11]
Output: [4,9,9,49,121]
"""


class Solution:
    def sorted_squares(self, A: List[int]) -> List[int]:
        if A[0] >= 0:
            return [i * i for i in A]
        else:
            rst = collections.deque()
            l, r = 0, len(A) - 1
            # equal sign is needed
            while l <= r:
                lv, rv = abs(A[l]), abs(A[r])
                if lv > rv:
                    rst.appendleft(lv * lv)
                    l += 1
                else:
                    rst.appendleft(rv * rv)
                    r -= 1

            return list(rst)


