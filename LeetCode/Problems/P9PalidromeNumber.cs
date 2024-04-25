namespace LeetCode.Problems
{
    public class P9PalidromeNumber : IProblemSolver<TestCaseWrapper<InputWrapper<int>, Wrapper<bool>>, Wrapper<bool>>
    {
        public TestCaseWrapper<InputWrapper<int>, Wrapper<bool>>[] TestCases { get; } = [
                new(121, true),
                new(-121, false),
                new(10, false)
            ];

        public Wrapper<bool> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return IsPalindromeNoString(input);
        }

        public static bool IsPalindrome(int input)
        {
            if (input < 0)
                return false;

            if (input < 10)
                return true;

            var inputString = input.ToString();
            for (int i = 0; i < inputString.Length / 2; i++)
            {
                if (inputString[i] != inputString[^(i + 1)])
                    return false;
            }

            return true;
        }

        public static bool IsPalindromeNoString(int input)
        {
            if (input < 0)
                return false;

            if (input < 10)
                return true;

            int t = input;
            int reverse = 0;
            while (t > 0)
            {
                reverse = reverse * 10 + t % 10;
                t /= 10;
            }

            return reverse == input;
        }
    }
}
