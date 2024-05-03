using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P27RemoveElement : IProblemSolver<TestCaseWrapper<P27RemoveElement.RemoveElementInput, Wrapper<int>>, Wrapper<int>>
    {
        public record RemoveElementInput(int[] Nums, int Val) : ITestCaseInput;

        public TestCaseWrapper<RemoveElementInput, Wrapper<int>>[] TestCases => [
                new(new([3,2,2,3], 3), 2),
                new(new([0,1,2,2,3,0,4,2], 2), 5),
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not RemoveElementInput input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return RemoveElement(input.Nums, input.Val);
        }

        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            foreach (var x in nums)
                if(x != val)
                    nums[i++] = x;

            return i;
        }
    }
}
