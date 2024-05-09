using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P1353MaximumNumberOfEvents : IProblemSolver<TestCaseWrapper<InputWrapper<int[][]>, Wrapper<int>>, Wrapper<int>>
    {
        public TestCaseWrapper<InputWrapper<int[][]>, Wrapper<int>>[] TestCases => [
                new(new([[1, 2], [2, 3], [3, 4]]), 3),
                new(new ( [[1, 2], [2, 3], [3, 4], [1, 2]]), 4),
                new(new([[1,4],[4,4],[2,2],[3,4],[1,1]]), 4)
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int[][]> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return MaxEvents(input);
        }

        public int MaxEvents(int[][] events)
        {
            Array.Sort(events, (x, y) => x[0] == y[0] ? x[1].CompareTo(y[1]) : x[0].CompareTo(y[0]));
            PriorityQueue<int, int> activeEvents = new();

            int currentDay = 0;
            int result = 0;
            int i = 0;

            while (true)
            {
                currentDay++;

                while (i < events.Length && events[i][0] == currentDay)
                {
                    activeEvents.Enqueue(events[i][1], events[i][1]);
                    i++;
                }

                while (activeEvents.Count > 0 && activeEvents.Peek() < currentDay)
                    activeEvents.Dequeue();

                if (activeEvents.Count > 0)
                {
                    activeEvents.Dequeue();
                    result++;
                }

                if (activeEvents.Count == 0 && i == events.Length)
                    break;
            }

            return result;
        }
    }
}
