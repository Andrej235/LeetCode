using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P35SearchInsertPosition : IProblemSolver<TestCaseWrapper<P35SearchInsertPosition.P35Input, Wrapper<int>>, Wrapper<int>>
    {
        public record P35Input(int[] Nums, int Target) : ITestCaseInput;

        public TestCaseWrapper<P35Input, Wrapper<int>>[] TestCases => [
                new(new([1,3,5,6], 5), 2),
                new(new([1,3,5,6], 2), 1),
                new(new([1,3,5,6], 7), 4),
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not P35Input input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return SearchInsert(input.Nums, input.Target);
        }

        public int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;

            while (left < right)
            {
                int middle = (left + right) / 2;

                if (nums[middle] == target)
                    return middle;
                if (target < nums[middle])
                    right = middle;
                else
                    left = middle + 1;
            }

            return left;
        }
    }
}
