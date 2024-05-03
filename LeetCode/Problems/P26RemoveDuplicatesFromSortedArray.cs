using LeetCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P26RemoveDuplicatesFromSortedArray : IProblemSolver<TestCaseWrapper<InputWrapper<int[]>, Wrapper<int>>, Wrapper<int>>
    {
        public TestCaseWrapper<InputWrapper<int[]>, Wrapper<int>>[] TestCases => [
                new(new([1,1,2]), 2),
                new(new([0,0,1,1,1,2,2,3,3,4]), 5),
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int[]> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return RemoveDuplicates_Replacing(input);
        }

        public int RemoveDuplicates_Resorting(int[] input)
        {
            int skip = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + skip + 1; j < input.Length; j++)
                {
                    if (input[i] >= input[j])
                        skip++;
                    else
                    {
                        (input[j], input[j - skip]) = (input[j - skip], input[j]);
                        break;
                    }
                }
            }
            return input.Length - skip;
        }

        public int RemoveDuplicates_Replacing(int[] input)
        {
            int i = 0;
            int current = int.MinValue;
            foreach (var x in input)
            {
                if (x != current)
                {
                    input[i++] = x;
                    current = x;
                }
            }
            return i;
        }
    }
}
