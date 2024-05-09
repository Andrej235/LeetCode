using LeetCode.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P3075Happiness : IProblemSolver<TestCaseWrapper<P3075Happiness.P3075Input, Wrapper<long>>, Wrapper<long>>
    {
        public record P3075Input(int[] Happiness, int K) : ITestCaseInput;

        public TestCaseWrapper<P3075Input, Wrapper<long>>[] TestCases => [
                new(new([1,2,3], 2), 4),
                new(new([1,1,1,1], 1), 1),
                new(new([2,3,4,5], 1), 5),
            ];

        public Wrapper<long> Solve(object testCaseInput)
        {
            if (testCaseInput is not P3075Input input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return MaximizeHappiness(input.Happiness, input.K);
        }

        public long MaximizeHappiness(int[] happiness, int k)
        {
            Array.Sort(happiness);
            long sum = 0;
            for (int i = 0; i < k; i++)
                sum += Math.Max(happiness[^(i + 1)] - i, 0);

            return sum;
        }
    }
}
