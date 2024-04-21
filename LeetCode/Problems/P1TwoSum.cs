﻿namespace LeetCode.Problems
{
    public class P1TwoSum : IProblemSolver<P1TwoSum.TwoSumTestCase, P1TwoSum.TwoSumTestCaseInput, int[]>
    {
        public record TwoSumTestCaseInput(int[] Nums, int Target) : ITestCaseInput;
        public record TwoSumTestCase : ITestCase<TwoSumTestCaseInput, int[]>
        {
            public TwoSumTestCaseInput Input { get; }
            public int[] ExpectedOutput { get; }
            public TwoSumTestCase(int[] nums, int target, int[] expectedOutput)
            {
                Input = new(nums, target);
                ExpectedOutput = expectedOutput;
            }
        }

        public List<TwoSumTestCase> TestCases => [
            new([2, 7, 11, 15], 9, [0, 1]),
            new([3, 2, 4], 6, [1, 2]),
            new([3, 3], 6, [0, 1]),
        ];

        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return [nums[i], nums[j]];
                }
            }
            return [];
        }

        public int[] Solve(TwoSumTestCaseInput testCase) => TwoSum(testCase.Nums, testCase.Target);
    }
}
