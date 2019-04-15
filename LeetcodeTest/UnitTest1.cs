using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearningNotes.leetcode;

namespace LeetcodeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTwoSum()
        {
            var input = new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887,
                755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400,
                136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930,
                282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370,
                527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809,
                896, 370, 789 };
            int target = 542;

            _2Sum.TwoSum(input, target);
            Assert.AreEqual(_2Sum.TwoSum(input, target), new int[] { 23, 22});
        }

        [TestMethod]
        public void TestLongestArithSeqLength()
        {
            //Assert.AreEqual(LongestArithSeqLength.Solution(new[] {9, 4, 7, 2, 10}), 3);


            // 23 (23), 27 (26), 31 (31), 35 (33), 39 (34), 43 (60)
            Assert.AreEqual(LongestArithSeqLength.Solution2(new[] {22, 8, 57, 41, 36, 46, 42, 28, 42, 14, 9, 43, 27,
                51, 0, 0, 38, 50, 31, 60, 29, 31, 20, 23, 37, 53, 27, 1, 47, 42, 28, 31, 10, 35, 39, 12, 15, 6, 35,
                31, 45, 21, 30, 19, 5, 5, 4, 18, 38, 51, 10, 7, 20, 38, 28, 53, 15, 55, 60, 56, 43, 48, 34, 53, 54,
                55, 14, 9, 56, 52 }), 6);
        }

    }
}
