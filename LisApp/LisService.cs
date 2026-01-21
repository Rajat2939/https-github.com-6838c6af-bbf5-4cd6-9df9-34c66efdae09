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

            int[] numbers = input.Trim()
                                 .Split(' ')
                                 .Select(int.Parse)
                                 .ToArray();

            if (numbers.Length == 0)
                return string.Empty;

            List<int> best = new();
            List<int> current = new() { numbers[0] };

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    current.Add(numbers[i]);
                }
                else
                {
                    if (current.Count > best.Count)
                        best = new List<int>(current);

                    current.Clear();
                    current.Add(numbers[i]);
                }
            }

            if (current.Count > best.Count)
                best = current;

            return string.Join(" ", best);
        }
    }
}