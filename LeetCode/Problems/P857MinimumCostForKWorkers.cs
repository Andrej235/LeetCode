using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P857MinimumCostForKWorkers : IProblemSolver<TestCaseWrapper<P857MinimumCostForKWorkers.P857Input, Wrapper<double>>, Wrapper<double>>
    {
        public record P857Input(int[] Quality, int[] Wage, int K) : ITestCaseInput;

        public TestCaseWrapper<P857Input, Wrapper<double>>[] TestCases => [
                //new(new([10,20,5], [70,50,30], 2), 105),
                //new(new([3, 1, 10, 10, 1], [4, 8, 2, 2, 7], 3), 30.66667),
                new(new([14,56,59,89,39,26,86,76,3,36], [90,217,301,202,294,445,473,245,415,487], 2), 399.53846)
            ];

        public Wrapper<double> Solve(object testCaseInput)
        {
            if (testCaseInput is not P857Input input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return MincostToHireWorkers(input.Quality, input.Wage, input.K);
        }

        public double MincostToHireWorkers(int[] quality, int[] wage, int k)
        {
            int n = quality.Length;
            double totalCost = double.MaxValue;

            var wageToQuality = new (double ratio, int quality)[n];
            for (int i = 0; i < n; i++)
                wageToQuality[i] = ((double)wage[i] / quality[i], quality[i]);

            Array.Sort(wageToQuality, (a, b) => -b.ratio.CompareTo(a.ratio));

            int totalQuality = 0;
            PriorityQueue<int, int> pq = new();
            for (int i = 0; i < n; i++)
            {
                pq.Enqueue(wageToQuality[i].quality, -wageToQuality[i].quality);
                totalQuality += wageToQuality[i].quality;

                if (pq.Count > k)
                    totalQuality -= pq.Dequeue();

                if (pq.Count == k)
                    totalCost = Math.Min(wageToQuality[i].ratio * totalQuality, totalCost);
            }

            return totalCost;
        }
    }
}
