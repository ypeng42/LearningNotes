from typing import List


"""
https://leetcode.com/problems/trapping-rain-water/ (hard)

Given n non-negative integers representing an elevation map where the width of each bar is 1, 
compute how much water it is able to trap after raining.
"""


class Solution:
    def trap(self, height: List[int]) -> int:
        leftMax = []
        rightMax = []
        left = 0
        for h in height:
            left = max(left, h)
            leftMax += [left]

        right = 0
        for i in range(len(height) - 1, -1, -1):
            right = max(right, height[i])
            rightMax.insert(0, right)

        sum = 0
        for ind, val in enumerate(height):
            sum += min(leftMax[ind], rightMax[ind]) - val

        return sum