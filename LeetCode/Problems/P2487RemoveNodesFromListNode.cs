using LeetCode.DataStructures;
using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P2487RemoveNodesFromListNode : IProblemSolver<TestCaseWrapper<InputWrapper<ListNode?>, ListNode?>, ListNode?>
    {
        public TestCaseWrapper<InputWrapper<ListNode?>, ListNode?>[] TestCases => [
                new(ListNode.From([5,2,13,3,8]), ListNode.From([13,8])),
                new(ListNode.From([1, 1, 1, 1]), ListNode.From([1, 1, 1, 1])),
            ];

        public ListNode? Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<ListNode?> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return RemoveNodesFromList(input);
        }

        public ListNode? RemoveNodesFromList(ListNode? root)
        {
            if (root is null)
                return null;

            ListNode? prev = null;
            ListNode? current = root;

            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            current = prev!;

            int max = current.Value;
            while (current.Next != null)
            {
                if (current.Next.Value >= max)
                {
                    max = current.Next.Value;
                    current = current.Next!;
                }
                else
                    current.Next = current.Next?.Next;
            }

            current = prev;
            prev = null;

            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }
    }
}
