using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P28FindIndexOfString : IProblemSolver<TestCaseWrapper<P28FindIndexOfString.FindIndexOfStringInput, Wrapper<int>>, Wrapper<int>>
    {
        public record FindIndexOfStringInput(string Haystack, string Needle) : ITestCaseInput;

        public TestCaseWrapper<FindIndexOfStringInput, Wrapper<int>>[] TestCases => [
                new(new("sadbutsad", "sad"), 0),
                new(new("leetcode", "leeto"), -1),
                new(new("hi", "hi"), 0),
                new(new("abc", "c"), 2),
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not FindIndexOfStringInput input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return FindIndexOfString(input.Haystack, input.Needle);
        }

        public int FindIndexOfString(string haystack, string needle)
        {
            if (haystack.Length < needle.Length)
                return -1;

            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    bool isMatch = true;
                    for (int j = 1; j < needle.Length; j++)
                    {
                        if (haystack[i + j] != needle[j])
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch)
                        return i;
                }
            }

            return -1;
        }
    }
}
