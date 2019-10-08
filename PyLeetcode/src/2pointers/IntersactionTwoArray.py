from typing import List
"""
https://leetcode.com/problems/intersection-of-two-arrays/
349. Intersection of Two Arrays(easy)

ex.
Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
Output: [9,4]

Each element in the result must be unique.
The result can be in any order.
"""


class Solution:
    # The trick is use 1/0 to indicate whether entry "exist", doesn't matter how many
    def intersection(self, nums1: List[int], nums2: List[int]) -> List[int]:
        dict1 = {}
        rst = []
        for num in nums1:
            if num not in dict1:
                dict1[num] = 1

        for num2 in nums2:
            if num2 in dict1 and dict1[num2] != 0:
                rst.append(num2)
                nums2[num2] = 0

        return rst



