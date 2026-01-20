using System;
using System.Collections.Generic;
using System.Linq;

namespace LisApp
{
    public class LisService
    {
        public string FindLongestIncreasingSubsequence(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            int[] nums = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = nums.Length;

            int[] dp = new int[n];
            int[] prev = new int[n];
            int[] start = new int[n];

            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                prev[i] = -1;
                start[i] = i;

                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        if (dp[j] + 1 > dp[i] ||
                           (dp[j] + 1 == dp[i] && start[j] < start[i]))
                        {
                            dp[i] = dp[j] + 1;
                            prev[i] = j;
                            start[i] = start[j];
                        }
                    }
                }
            }

            int maxLen = dp.Max();
            int endIndex = -1;

            for (int i = 0; i < n; i++)
            {
                if (dp[i] == maxLen)
                {
                    if (endIndex == -1 || start[i] < start[endIndex])
                        endIndex = i;
                }
            }

            var result = new Stack<int>();
            while (endIndex != -1)
            {
                result.Push(nums[endIndex]);
                endIndex = prev[endIndex];
            }

            return string.Join(" ", result);
        }
    }
}
