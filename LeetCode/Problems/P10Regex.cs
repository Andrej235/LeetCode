using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P10Regex : IProblemSolver<TestCaseWrapper<P10Regex.RegexInput, Wrapper<bool>>, Wrapper<bool>>
    {
        public TestCaseWrapper<RegexInput, Wrapper<bool>>[] TestCases { get; } = [
                //new(new("aa", "a"), false),
                //new(new("aa", "a*"), true),
                new(new("a", "a*a"), true),
                //new(new("aa", "a."), true),
                //new(new("ab", ".*"), true),
                //new(new("aab", "c*a*b"), true),
                //new(new("aabdjasijdi", ".*"), true),
                //new(new("aaaaaaaabbbbbbcccccj", ".*j"), true),
                //new(new("abcd", "d*"), false),
                //new(new("ab", ".*c"), false),
                //new(new("aaaa", "aaa*a*a*a*a*a*a*a*a*"), false),
                //new(new("aaa", "ab*a"), false),
                //new(new("aaa", "ab*a*c*a"), true),
                //new(new("a", "ab*"), true),
                //new(new("a", ".*"), true),
            ];

        public Wrapper<bool> Solve(object testCaseInput)
        {
            if (testCaseInput is not RegexInput input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return IsMatch(input.Input, input.Pattern);
        }

        public static bool IsMatch(string input, string pattern)
        {
            if (pattern.Length == 0) return input.Length == 0;

            bool firstMatch = (input.Length != 0) && (pattern[0] == input[0] || pattern[0] == '.');

            if (pattern.Length >= 2 && pattern[1] == '*')
                return IsMatch(input, pattern[2..]) || (firstMatch && IsMatch(input[1..], pattern));

            return firstMatch && IsMatch(input[1..], pattern[1..]);
        }

        public record RegexInput(string Input, string Pattern) : ITestCaseInput;
    }
}
