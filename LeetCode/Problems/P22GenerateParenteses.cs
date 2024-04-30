using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P22GenerateParenteses : IProblemSolver<TestCaseWrapper<InputWrapper<int>, IList<string>>, IList<string>>
    {
        public TestCaseWrapper<InputWrapper<int>, IList<string>>[] TestCases => [
                new(3, ["((()))","(()())","(())()","()(())","()()()"]),
                new(1, ["()"])
            ];

        public IList<string> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return GenerateParenthesis(input);
        }

        public IList<string> GenerateParenthesis(int n) => GenerateParenthesis(n, 1, 0, "(");

        public IList<string> GenerateParenthesis(int n, int open, int closed, string s)
        {
            if (n == open && n == closed)
                return [s];

            if (open < closed || open > n || closed > n)
                return [];

            return [.. GenerateParenthesis(n, open, closed + 1, s + ")"), .. GenerateParenthesis(n, open + 1, closed, s + "(")];
        }
    }
}
