using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P189RotateArray : IProblemSolver<TestCaseWrapper<P189RotateArray.P189Input, int[]>, int[]>
    {
        public record P189Input(int[] Nums, int K) : ITestCaseInput;

        public TestCaseWrapper<P189Input, int[]>[] TestCases => [
                new(new([1,2,3,4, 5,6,7], 3), [5,6,7, 1,2,3,4]),
                new(new([1,2,3,4,5, 6,7], 1), [7,1, 2, 3,4,5,6]),
                new(new([1,2,3,4], 3), [2,3,4,1]),
                new(new([1,2,3,4,5,6], 3), [4,5, 6, 1, 2,3]),
                new(new([1,2,3,4,5,6], 2), [5,6,1,2,3,4]),
                new(new([1,2,3,4,5,6], 1), [6,1,2,3,4, 5]),
                new(new([1,2], 3), [2,1]),
            ];

        public int[] Solve(object testCaseInput)
        {
            if (testCaseInput is not P189Input input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return RotateInPlace(input.Nums, input.K);
        }

        public int[] Rotate(int[] nums, int k)
        {
            int n = nums.Length;
            int[] result = new int[n];

            for (int i = n - 1; i >= n - k; i--)
                result[i - n + k] = nums[i];

            for (int i = 0; i < n - k; i++)
                result[k + i] = nums[i];

            return result;
        }

        public int[] RotateInPlace(int[] nums, int k)
        {
            if (k == 0 || nums.Length == 1 || nums.Length == k)
                return nums;

            int current = 0;
            int safety = 0;
            int t = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                current = (current + k) % nums.Length;
                (t, nums[current]) = (nums[current], t);

                if (current == safety && safety < nums.Length - 1)
                {
                    current++;
                    safety++;
                    t = nums[current];
                }
            }

            return nums;
        }
    }
}
