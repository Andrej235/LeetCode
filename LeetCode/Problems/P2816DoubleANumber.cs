using LeetCode.DataStructures;
using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P2816DoubleANumber : IProblemSolver<TestCaseWrapper<InputWrapper<ListNode>, ListNode>, ListNode>
    {
        public TestCaseWrapper<InputWrapper<ListNode>, ListNode>[] TestCases => [
                new(ListNode.From([1,8,9])!, ListNode.From([3,7,8])!),
                new(ListNode.From([9,9,9])!, ListNode.From([1,9,9,8])!),
                new(ListNode.From([1])!, ListNode.From([2])!)
            ];

        public ListNode Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<ListNode> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return DoubleIt_OnePass(input);
        }

        public ListNode DoubleIt_Reverse_TwoPasses(ListNode root)
        {
            int carry = 0;
            ListNode? prev = null;
            ListNode? current = root;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            current = prev;
            prev = null;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;

                prev.Value = prev.Value * 2 + carry;
                carry = prev.Value / 10;
                prev.Value %= 10;
            }

            return carry != 0 ? new(carry, prev) : prev!;
        }

        public ListNode DoubleIt_OnePass(ListNode root)
        {
            root = new(0, root);
            ListNode? prev = root;
            ListNode? current = root.Next;
            while (current != null)
            {
                int newValue = current.Value * 2;
                if (newValue > 9)
                {
                    newValue %= 10;
                    prev.Value += 1;
                }

                current.Value = newValue;
                prev = current;
                current = current.Next;
            }

            return root.Value == 0 ? root.Next! : root;
        }
    }
}
