using LeetCode.DataStructures;
using LeetCode.Utility;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using static System.Net.Mime.MediaTypeNames;

namespace LeetCode.Problems
{
    public class P25ReverseNodesInKGroup : IProblemSolver<TestCaseWrapper<P25ReverseNodesInKGroup.ReverseNodesInKGroupInput, ListNode?>, ListNode?>
    {
        public record ReverseNodesInKGroupInput(ListNode? Head, int K) : ITestCaseInput;
        public TestCaseWrapper<ReverseNodesInKGroupInput, ListNode?>[] TestCases => [
                new(new(ListNode.From([1,2,3,4,5]), 2), ListNode.From([2,1,4,3,5])),
                new(new(ListNode.From([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]), 3), ListNode.From([3, 2, 1, 6, 5, 4, 9, 8, 7, 10])),
            ];

        public ListNode? Solve(object testCaseInput)
        {
            if (testCaseInput is not ReverseNodesInKGroupInput input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return ReverseKGroup(input.Head, input.K);
        }

        public ListNode? ReverseKGroup(ListNode? head, int k)
        {
            ListNode? current = head;
            ListNode? result = null;
            ListNode? resultCurrent = null;

            while (true)
            {
                ListNode? prev = null;
                ListNode? reversalCurrent = current;
                ListNode? next;

                for (int j = 0; j < k; j++)
                {
                    if (reversalCurrent is not null)
                    {
                        next = reversalCurrent!.Next;
                        reversalCurrent.Next = prev;
                        prev = reversalCurrent;
                        reversalCurrent = next;
                        continue;
                    }

                    if (result is null)
                        return null;

                    reversalCurrent = prev;
                    prev = null;

                    while (reversalCurrent != null)
                    {
                        next = reversalCurrent.Next;
                        reversalCurrent.Next = prev;
                        prev = reversalCurrent;
                        reversalCurrent = next;
                    }

                    resultCurrent!.Next = prev;
                    return result;
                }

                current = reversalCurrent;
                if (result is null)
                {
                    result = prev;
                    resultCurrent = result;
                }
                else
                    resultCurrent!.Next = prev;

                while (resultCurrent!.Next != null)
                    resultCurrent = resultCurrent.Next;
            }
        }
    }
}
