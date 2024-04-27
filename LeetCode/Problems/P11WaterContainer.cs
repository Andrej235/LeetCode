using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P11WaterContainer : IProblemSolver<TestCaseWrapper<InputWrapper<int[]>, Wrapper<int>>, Wrapper<int>>
    {
        public TestCaseWrapper<InputWrapper<int[]>, Wrapper<int>>[] TestCases { get; } = [
                new(new([1,8,6,2,5,4,8,3,7]), 49),
                new(new([1,1]), 1),
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int[]> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return MaxArea(input);
        }

        public static int MaxArea(int[] heights)
        {
            int i = 0;
            int j = heights.Length - 1;
            int max = 0;

            while (i < j)
            {
                var area = Math.Min(heights[i], heights[j]) * (j - i);
                if (area > max)
                    max = area;

                if (heights[i] < heights[j])
                    i++;
                else
                    j--;
            }

            return max;
        }
    }
}
