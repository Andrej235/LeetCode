using LeetCode.DataStructures;
using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P237DeleteANodeInLinkedList : IProblemSolver<TestCaseWrapper<InputWrapper<ListNode?>, ListNode?>, ListNode?>
    {
        public TestCaseWrapper<InputWrapper<ListNode?>, ListNode?>[] TestCases => [
                new(ListNode.From([5,1,9]), ListNode.From([1,9])),
                new(ListNode.From([1,9]), ListNode.From([9])),
            ];

        public ListNode? Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<ListNode?> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return DeleteNode(input!);
        }

        public ListNode DeleteNode(ListNode node)
        {
            node.Value = node.Next!.Value;
            node.Next = node.Next!.Next;

            return node;
        }
    }
}
