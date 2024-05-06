using LeetCode.DataStructures;
using LeetCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P206ReverseLinkedList : IProblemSolver<TestCaseWrapper<InputWrapper<ListNode?>, ListNode?>, ListNode?>
    {
        public TestCaseWrapper<InputWrapper<ListNode?>, ListNode?>[] TestCases => [
                new(ListNode.From([1,2,3,4,5]), ListNode.From([5,4,3,2,1])),
                new(ListNode.From(1, 2), ListNode.From(2, 1)),
                new(ListNode.From(), ListNode.From()),
            ];

        public ListNode? Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<ListNode?> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return ReverseList(input);
        }

        private ListNode? ReverseList(ListNode? root)
        {
            if (root is null)
                return null;

            ListNode? result = null;
            ListNode? current = root;
            while (current != null)
            {
                var next = current.Next;
                current.Next = result;
                result = current;
                current = next;
            }

            return result;
        }
    }
}
