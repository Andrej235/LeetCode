using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P2373LargestLocalValuesInMatrix : IProblemSolver<TestCaseWrapper<InputWrapper<int[][]>, int[][]>, int[][]>
    {
        public TestCaseWrapper<InputWrapper<int[][]>, int[][]>[] TestCases => [
                new(new([[9,9,8,1],[5,6,2,6],[8,2,6,4],[6,2,2,2]]), [[9,9],[8,6]]),
                new(new([[1,1,1,1,1],[1,1,1,1,1],[1,1,2,1,1],[1,1,1,1,1],[1,1,1,1,1]]), [[2,2,2],[2,2,2],[2,2,2]])
            ];

        public int[][] Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int[][]> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return LargestLocal(input);
        }

        public int[][] LargestLocal(int[][] grid)
        {
            int n = grid.Length;
            int[][] result = new int[n - 2][];
            for (int i = 0; i < n - 2; i++)
            {
                result[i] = new int[n - 2];

                for (int j = 0; j < n - 2; j++)
                {
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                            if (grid[k][l] > result[i][j])
                                result[i][j] = grid[k][l];
                }
            }

            return result;
        }
    }
}
