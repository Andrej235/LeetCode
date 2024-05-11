using LeetCode.Utility;
using System.Diagnostics.CodeAnalysis;

namespace LeetCode.Problems
{
    public class P1089DuplicateZeros : IProblemSolver<TestCaseWrapper<InputWrapper<int[]>, int[]>, int[]>
    {
        public TestCaseWrapper<InputWrapper<int[]>, int[]>[] TestCases => [
                //new(new([1,0,2,3,0,4,5,0]), [1,0,0,2,3,0,0,4]),
                //new(new([1,2,3]), [1,2,3]),
                new(new([1,5,2,0,6,8,0,6,0]), [1,5,2,0,0,6,8,0,0])
            ];

        public int[] Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int[]> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return DuplicateZeros(input);
        }

        public int[] DuplicateZeros(int[] arr)
        {
            Queue<int> extras = [];

            for (int i = 0; i < arr.Length; i++)
            {
                while (extras.TryDequeue(out int x))
                {
                    extras.Enqueue(arr[i]);
                    arr[i] = x;

                    if (x == 0 && i + 1 < arr.Length)
                    {
                        extras.Enqueue(arr[i + 1]);
                        arr[i + 1] = 0;
                        i++;
                    }

                    i++;
                    if (i >= arr.Length)
                        return arr;
                }

                if (arr[i] == 0 && i + 1 < arr.Length)
                {
                    extras.Enqueue(arr[i + 1]);
                    arr[i + 1] = 0;
                    i++;
                }
            }
            return arr;
        }
    }
}
