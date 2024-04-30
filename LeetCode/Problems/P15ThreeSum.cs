using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P15ThreeSum : IProblemSolver<TestCaseWrapper<InputWrapper<int[]>, IList<IList<int>>>, IList<IList<int>>>
    {
        public TestCaseWrapper<InputWrapper<int[]>, IList<IList<int>>>[] TestCases => [
                new(new([-1,0,1,2,-1,-4]), [[-1, -1, 2], [-1, 0, 1]]),
                new(new([0, 1, 1]), []),
                new(new([0, 0, 0]), [[0, 0, 0]]),
                new(new([1,2,-2,-1]), []),
                new(new([3,0,-2,-1,1,2]), [[-2,-1,3],[-2,0,2],[-1,0,1]]),
            ];

        public IList<IList<int>> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int[]> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return ThreeSum(input);
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> result = [];
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int j = i + 1;
                int k = nums.Length - 1;
                int target = -nums[i];
                while (j < k)
                {
                    if (target == nums[j] + nums[k])
                    {
                        IList<int> triplet = [nums[i], nums[j], nums[k]];
                        result.Add(triplet);

                        while (j < k && nums[j] == nums[j + 1])
                            j++;

                        j++;
                        k--;
                    }
                    else if (nums[j] + nums[k] > target)
                        k--;
                    else
                        j++;
                }
            }

            return result;
        }
    }
}
