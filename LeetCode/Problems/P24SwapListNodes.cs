using LeetCode.DataStructures;
using LeetCode.Utility;
using System.Security;

namespace LeetCode.Problems
{
    public class P24SwapListNodes : IProblemSolver<TestCaseWrapper<InputWrapper<ListNode?>, ListNode?>, ListNode?>
    {
        public TestCaseWrapper<InputWrapper<ListNode?>, ListNode?>[] TestCases => [
                new(ListNode.From([1,2,3,4,5]), ListNode.From([2,1,4,3,5])),
                new(new(null), null),
                new(ListNode.From([1]), ListNode.From([1]))
            ];

        public ListNode? Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<ListNode?> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return SwapPairs(input);
        }

        public ListNode? SwapPairs(ListNode? head)
        {
            if (head is null)
                return null;

            if (head.Next is null)
                return head;

            head = new(0, head);
            ListNode current = head;

            while (current != null)
            {
                if (current.Next != null && current.Next.Next != null)
                {
                    var t = current.Next;
                    current.Next = current.Next.Next;
                    current = current.Next;
                    var t2 = current.Next;

                    t.Next = t2;
                    current.Next = t;

                    current = current.Next;
                }
                else break;
            }

            return head.Next;
        }
    }
}
