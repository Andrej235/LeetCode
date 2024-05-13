using LeetCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P861ScoreAfterFlippingMatrix : IProblemSolver<TestCaseWrapper<InputWrapper<int[][]>, Wrapper<int>>, Wrapper<int>>
    {
        public TestCaseWrapper<InputWrapper<int[][]>, Wrapper<int>>[] TestCases => [
                new(new([[0,0,1,1],[1,0,1,0],[1,1,0,0]]), 39),
                new(new([[0]]), 1)
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int[][]> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return MatrixScore(input);
        }

        public int MatrixScore(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            for (int i = 0; i < m; i++)
            {
                if (grid[i][0] == 1)
                    continue;

                for (int j = 0; j < n; j++)
                    grid[i][j] = 1 - grid[i][j];
            }

            for (int j = 1; j < n; j++)
            {
                int zeroes = 0;
                for (int i = 0; i < m; i++)
                    if (grid[i][j] == 0)
                        zeroes++;

                if (zeroes > m - zeroes)
                {
                    for (int i = 0; i < m; i++)
                        grid[i][j] = 1 - grid[i][j];
                }
            }


            int result = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result += grid[i][j] << (n - j - 1);
                }
            }
            return result;
        }
    }
}
