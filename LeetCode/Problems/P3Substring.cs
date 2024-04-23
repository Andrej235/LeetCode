using static LeetCode.Problems.P3Substring;

namespace LeetCode.Problems
{
    public class P3Substring : IProblemSolver<SubstringTestCase, Wrapper<int>>
    {
        public SubstringTestCase[] TestCases => [
                new("abcabcbb", 3),
                new("bbbbb" , 1),
                new("pwwkew", 3)
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<string> substringTestCase)
                throw new ArgumentException(null, nameof(testCaseInput));

            return LengthOfLongestSubstring(substringTestCase);
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length <= 1)
                return s.Length;

            int max = 0;
            HashSet<char> set = [];

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if (set.Contains(s[j]))
                    {
                        if (max < set.Count)
                            max = set.Count;
                        break;
                    }

                    set.Add(s[j]);
                }
                set = [];
            }
            return max;
        }

        public record SubstringTestCase(InputWrapper<string> Input, Wrapper<int> ExpectedOutput) : ITestCase<InputWrapper<string>, Wrapper<int>>;
    }
}
