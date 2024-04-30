using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P16Closest3Sum : IProblemSolver<TestCaseWrapper<P16Closest3Sum.Closest3SumInput, Wrapper<int>>, Wrapper<int>>
    {
        public TestCaseWrapper<Closest3SumInput, Wrapper<int>>[] TestCases => [
                new(new([-1,2,1,-4], 1), 2),
                new(new([0,0,0], 1), 0)
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not Closest3SumInput input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return Closest3Sum(input.Nums, input.Target);
        }

        public int Closest3Sum(int[] nums, int target)
        {
            int closest = int.MaxValue;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (target == sum)
                        return target;
                    else
                    {
                        if (Math.Abs(sum - target) < Math.Abs(closest - target))
                            closest = sum;

                        if (sum > target)
                            k--;
                        else
                            j++;
                    }
                }
            }

            return closest;
        }

        public record Closest3SumInput(int[] Nums, int Target) : ITestCaseInput;
    }
}
