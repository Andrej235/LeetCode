using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class P19RemoveNthNode : IProblemSolver<TestCaseWrapper<P19RemoveNthNode.RemoveNthNodeInput, ListNode?>, ListNode?>
    {
        public record RemoveNthNodeInput(ListNode? Root, int N) : ITestCaseInput;

        public TestCaseWrapper<RemoveNthNodeInput, ListNode?>[] TestCases => [
                new(new(ListNode.Create([1,2,3,4,5]), 2), ListNode.Create([1,2,3,5])),
                new(new(ListNode.Create([1]), 1), ListNode.Create([])),
                new(new(ListNode.Create([1, 2]), 1), ListNode.Create([1]))
            ];

        public ListNode? Solve(object testCaseInput)
        {
            if (testCaseInput is not RemoveNthNodeInput input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return RemoveNthFromEnd(input.Root, input.N);
        }

        public ListNode? RemoveNthFromEnd(ListNode? head, int n)
        {
            if (head is null)
                return head;

            ListNode? current = head;
            ListNode nthNode = head;

            for (int i = 0; i < n; i++)
                current = current.Next!;

            if (current == null)
                return head.Next;

            while (current != null)
            {
                current = current.Next;

                if (current == null)
                {
                    nthNode.Next = nthNode.Next?.Next;
                    return head;
                }

                nthNode = nthNode.Next!;
            }

            return head;
        }
    }
}
