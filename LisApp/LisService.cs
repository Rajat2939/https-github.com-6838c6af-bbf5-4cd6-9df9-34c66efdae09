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
                return "";

            var numbers = input.Trim().Split(' ').Select(int.Parse).ToArray();
            if (numbers.Length == 0)
                return "";

            List<int> bestSequence = new List<int>();
            int bestStartIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                List<int> currentSequence = new List<int> { numbers[i] };

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] > currentSequence.Last())
                    {
                        currentSequence.Add(numbers[j]);
                    }
                    else
                    {
                        // End of increasing sequence
                        break;
                    }
                }

                // Compare with best found
                if (currentSequence.Count > bestSequence.Count ||
                    (currentSequence.Count == bestSequence.Count && i < bestStartIndex))
                {
                    bestSequence = new List<int>(currentSequence);
                    bestStartIndex = i;
                }
            }

            return string.Join(" ", bestSequence);
        }
    }
}