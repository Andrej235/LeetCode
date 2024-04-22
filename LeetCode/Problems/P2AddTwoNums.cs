using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class P2AddTwoNums : IProblemSolver<P2AddTwoNums.AddTwoNumsTestCase, ListNode>
    {
        public AddTwoNumsTestCase[] TestCases => [
                new(ListNode.Create(2,4,3), ListNode.Create(5,6,4), ListNode.Create(7,0,8)),
                new(ListNode.Create(0), ListNode.Create(0), ListNode.Create(0)),
                new(ListNode.Create(9,9,9,9,9,9,9), ListNode.Create(9,9,9,9), ListNode.Create(8,9,9,9,0,0,0,1)),
            ];

        public ListNode Solve(object testCaseInput)
        {
            if (testCaseInput is not AddTwoNumsTestCaseInput addTwoNumsTestCase)
                throw new ArgumentException(null, nameof(testCaseInput));

            return AddTwoLinkedLists(addTwoNumsTestCase.ListRoot1, addTwoNumsTestCase.ListRoot2);
        }

        public static ListNode AddTwoLinkedLists(ListNode listRoot1, ListNode listRoot2)
        {
            ListNode? current1 = listRoot1;
            ListNode? current2 = listRoot2;
            int carry = 0;

            while (current1 != null || current2 != null)
            {
                int newValue;

                if (current2 == null && current1 != null)
                {
                    newValue = current1.Value + carry;
                    if (newValue > 9)
                    {
                        carry = newValue / 10;
                        newValue %= 10;
                    }
                    else
                        carry = 0;
                    current1.Value = newValue;

                    if (current1.Next == null && carry > 0)
                    {
                        current1.Next = new(carry, null);
                        break;
                    }

                    current1 = current1.Next;
                }
                else if (current1 != null && current2 != null)
                {
                    newValue = current1.Value + current2.Value + carry;
                    if (newValue > 9)
                    {
                        carry = newValue / 10;
                        newValue %= 10;
                    }
                    else
                        carry = 0;
                    current1.Value = newValue;

                    if (current1.Next == null)
                    {
                        if (current2.Next != null)
                            current1.Next = new();
                        else if (carry > 0)
                        {
                            current1.Next = new(carry, null);
                            break;
                        }
                    }

                    current1 = current1.Next;
                    current2 = current2.Next;
                }
            }

            return listRoot1;
        }

        public record AddTwoNumsTestCaseInput(ListNode ListRoot1, ListNode ListRoot2) : ITestCaseInput;
        public record AddTwoNumsTestCase : ITestCase<AddTwoNumsTestCaseInput, ListNode>
        {
            public AddTwoNumsTestCaseInput Input { get; }
            public ListNode ExpectedOutput { get; }

            public AddTwoNumsTestCase(ListNode listRoot1, ListNode listRoot2, ListNode expectedOutput)
            {
                Input = new AddTwoNumsTestCaseInput(listRoot1, listRoot2);
                ExpectedOutput = expectedOutput;
            }
        }
    }
}
