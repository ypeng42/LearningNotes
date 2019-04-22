using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    /*
     * 1031. Maximum Sum of Two Non-Overlapping Subarrays (medium)
     */
    class MaxSumTwoArray
    {
        public int MaxSumTwoNoOverlap(int[] A, int L, int M)
        {
            // calculate sum at each point
            // value of subarray length L = A[i] - A[i - L]
            for (int i = 1; i < A.Length; ++i)
                A[i] += A[i - 1];

            /* initially the result is the first L + M items 
             * 
             * ex.
             * 0, 6, 5, 2, 2, 5, 1, 9, 4
             * 
             * There are 2 possibilities for answer:
             * 1. Max value for "L" subarry + value for "M" (Note: the value for M may not be its max)
             * it doesn't make sense to Not use max value for L
             * 
             * 2. Max value for "M" subarry + value for "L"
             * 
             * As we loop over, we will cover all cases.
             */
            int res = A[L + M - 1], Lmax = A[L - 1], Mmax = A[M - 1];

            for (int i = L + M; i < A.Length; ++i)
            {
                Lmax = Math.Max(Lmax, A[i - M] - A[i - L - M]);
                Mmax = Math.Max(Mmax, A[i - L] - A[i - L - M]);
                res = Math.Max(res, Math.Max(Lmax + A[i] - A[i - M], Mmax + A[i] - A[i - L]));
            }
            return res;
        }
    }
}
