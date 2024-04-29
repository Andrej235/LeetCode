using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P18FourSum : IProblemSolver<TestCaseWrapper<P18FourSum.FourSumInput, IList<IList<int>>>, IList<IList<int>>>
    {
        public record FourSumInput(int[] Nums, int Target) : ITestCaseInput;
        public TestCaseWrapper<FourSumInput, IList<IList<int>>>[] TestCases => [
                new(new([1,0,-1,0,-2,2], 0), [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]),
                new(new([2,2,2,2,2], 8), [[2,2,2,2]]),
                new(new([-1000000000,-1000000000,1000000000,-1000000000,-1000000000], 294967296), [])
            ];

        public IList<IList<int>> Solve(object testCaseInput)
        {
            if (testCaseInput is not FourSumInput input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return FourSum(input.Nums, input.Target);
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            return KSum(nums, 0, 4, target);
        }

        public IList<IList<int>> KSum(int[] nums, int start, int k, long target)
        {
            IList<IList<int>> res = [];
            if (start == nums.Length || nums[start] > target / k || target / k > nums[^1])
                return res;

            if (k == 2)
                return TwoSum(nums, target, start);

            for (int i = start; i < nums.Length; i++)
            {
                if (i != start && nums[i - 1] == nums[i])
                    continue;

                var ksum = KSum(nums, i + 1, k - 1, target - nums[i]);
                foreach (var subset in ksum)
                    res.Add([nums[i], .. subset]);
            }

            return res;
        }

        public static IList<IList<int>> TwoSum(int[] nums, long target, int start)
        {
            IList<IList<int>> result = [];
            int i = start;
            int j = nums.Length - 1;
            while (i < j)
            {
                int curr = nums[i] + nums[j];
                if (curr < target || (i > start && nums[i] == nums[i - 1]))
                    i++;
                else if (curr > target || (j < nums.Length - 1 && nums[j] == nums[j + 1]))
                    j--;
                else
                {
                    result.Add([nums[i++], nums[j--]]);
                }
            }

            return result;
        }
    }
}
