using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P20ValidParantheses : IProblemSolver<TestCaseWrapper<InputWrapper<string>, Wrapper<bool>>, Wrapper<bool>>
    {
        public TestCaseWrapper<InputWrapper<string>, Wrapper<bool>>[] TestCases => [
                new("()", true),
                new("()[]{}", true),
                new("(]", false),
                new("([)]", false),
            ];

        public Wrapper<bool> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<string> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return IsValid(input);
        }

        private readonly Dictionary<char, char> map = new() { { '(', ')' }, { '[', ']' }, { '{', '}' } };
        public bool IsValid(string input)
        {
            if (input.Length % 2 == 1)
                return false;

            Stack<char> stack = [];
            foreach (char c in input)
            {
                if (map.ContainsKey(c))
                    stack.Push(c);
                else if (stack.Count == 0 || map[stack.Pop()] != c)
                    return false;
            }

            return stack.Count == 0;
        }
    }
}
