using LeetCode.DataStructures;
using LeetCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P21Merge2Lists : IProblemSolver<TestCaseWrapper<P21Merge2Lists.Merge2ListsInput, ListNode?>, ListNode?>
    {
        public record Merge2ListsInput(ListNode? List1, ListNode? List2) : ITestCaseInput;
        public TestCaseWrapper<Merge2ListsInput, ListNode?>[] TestCases => [
                new(new(ListNode.From([1,2,4]), ListNode.From([1,3,4])), ListNode.From([1,1,2,3,4,4])),
                new(new(ListNode.From([]), ListNode.From([])), ListNode.From([])),
                new(new(ListNode.From([]), ListNode.From([0])), ListNode.From([0]))
            ];

        public ListNode? Solve(object testCaseInput)
        {
            if (testCaseInput is not Merge2ListsInput input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return MergeTwoLists(input.List1, input.List2);
        }

        public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
        {
            if (list1 is null)
                return list2;

            if (list2 is null)
                return list1;

            ListNode res = new();
            ListNode resCurrent = res;

            while (list1 != null && list2 != null)
            {
                if (list1.Value <= list2.Value)
                {
                    resCurrent.Next = list1;
                    list1 = list1.Next;
                }
                else
                {
                    resCurrent.Next = list2;
                    list2 = list2.Next;
                }
                resCurrent = resCurrent.Next;
            }

            if (list1 != null) resCurrent.Next = list1;
            if (list2 != null) resCurrent.Next = list2;

            return res.Next;
        }
    }
}
