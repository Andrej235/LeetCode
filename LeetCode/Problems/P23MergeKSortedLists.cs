using LeetCode.DataStructures;
using LeetCode.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P23MergeKSortedLists : IProblemSolver<TestCaseWrapper<InputWrapper<ListNode?[]>, ListNode?>, ListNode?>
    {
        public TestCaseWrapper<InputWrapper<ListNode?[]>, ListNode?>[] TestCases => [
                new(new([ListNode.From([1, 4, 5]), ListNode.From([1, 3, 4]), ListNode.From([2, 6])]), ListNode.From([1, 1, 2, 3, 4, 4, 5, 6])),
                new(new([]), null),
                new(new([ListNode.From([])]), null)
            ];

        public ListNode? Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<ListNode?[]> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return MergeKLists(input);
        }

        public ListNode? MergeKLists(ListNode?[] lists)
        {
            if (lists.Length < 1)
                return null;

            if (lists.Length == 1)
                return lists[0];

            ListNode result = new();
            ListNode current = result;
            while (true)
            {
                int minI = 0;

                for (int i = 1; i < lists.Length; i++)
                {
                    if (lists[i]?.Value < (lists[minI]?.Value ?? int.MaxValue))
                        minI = i;
                }

                if (lists[minI] is null)
                    break;

                current!.Next = lists[minI];    
                current = current.Next!;
                lists[minI] = lists[minI]!.Next;
            }

            return result.Next;
        }
    }
}
