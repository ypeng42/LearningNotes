namespace LearningNotes.leetcode
{
    class Solution
    {
        public void ReverseString(char[] s)
        {
            var start = 0;
            var end = s.Length - 1;

            while (start < end)
            {
                Swap(s, start, end);
                start++;
                end--;
            }
        }

        public static void Swap(char[] input, int a, int b)
        {
            char temp = input[a];
            input[a] = input[b];
            input[b] = temp;
        }
    }
}
