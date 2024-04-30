using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P5LongestPalindromicSubstring : IProblemSolver<P5LongestPalindromicSubstring.LongestPalindromeTestCase, string>
    {
        public LongestPalindromeTestCase[] TestCases => [
                new("babad", "bab"),
                new("cbbd", "bb"),
                new("a", "a"),
                new("bb", "bb"),
            ];

        public string Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<string> longestPalindromeInput)
                throw new ArgumentException(null, nameof(testCaseInput));

            return LongestPalindrome(longestPalindromeInput);
        }

        public static string LongestPalindrome(string s)
        {
            if (s.Length < 2)
                return s;

            int length = s.Length;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    var subString = s[j..(j + length)];
                    if (IsPalindrome(subString))
                        return subString;
                }
                length--;
            }

            return "";
        }

        public static bool IsPalindrome(string s)
        {
            if (s.Length < 2)
                return true;

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }
            return true;
        }

        public record LongestPalindromeTestCase(InputWrapper<string> Input, string ExpectedOutput) : ITestCase<InputWrapper<string>, string>;

    }
}
