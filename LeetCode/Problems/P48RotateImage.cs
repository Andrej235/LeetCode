using LeetCode.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P48RotateImage : IProblemSolver<TestCaseWrapper<InputWrapper<int[][]>, int[][]>, int[][]>
    {
        public TestCaseWrapper<InputWrapper<int[][]>, int[][]>[] TestCases => [
                new(new([[1,2,3],[4,5,6],[7,8,9]]), [[7,4,1],[8,5,2],[9,6,3]]),
                new(new([[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]), [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]])
            ];

        public int[][] Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int[][]> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return Rotate(input);
        }

        public int[][] Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);

                for (int j = 0; j < n / 2; j++)
                    (matrix[i][j], matrix[i][n - j - 1]) = (matrix[i][n - j - 1], matrix[i][j]);
            }

            return matrix;
        }
    }
}
