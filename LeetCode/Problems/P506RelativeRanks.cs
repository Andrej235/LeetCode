using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P506RelativeRanks : IProblemSolver<TestCaseWrapper<InputWrapper<int[]>, string[]>, string[]>
    {
        public TestCaseWrapper<InputWrapper<int[]>, string[]>[] TestCases => [
                new(new([5,4,3,2,1]), ["Gold Medal", "Silver Medal", "Bronze Medal", "4", "5"]),
                new(new([10,3,8,9,4]), ["Gold Medal", "5", "Bronze Medal", "Silver Medal", "4"]),
            ];

        public string[] Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int[]> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return FindRelativeRanks(input);
        }

        public string[] FindRelativeRanks(int[] score)
        {
            PriorityQueue<int, int> priorityQueue = new();
            string[] ranks = new string[score.Length];

            for (int i = 0; i < score.Length; i++)
                priorityQueue.Enqueue(i, score[i]);

            int place = score.Length - 1;
            while (priorityQueue.TryDequeue(out int index, out _))
            {
                ranks[index] = (place) switch
                {
                    0 => "Gold Medal",
                    1 => "Silver Medal",
                    2 => "Bronze Medal",
                    _ => (place + 1).ToString(),
                };
                place--;
            }

            return ranks;
        }
    }
}
