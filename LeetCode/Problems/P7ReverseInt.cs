namespace LeetCode.Problems
{
    public class P7ReverseInt : IProblemSolver<TestCaseWrapper<InputWrapper<int>, Wrapper<int>>, Wrapper<int>>
    {
        public TestCaseWrapper<InputWrapper<int>, Wrapper<int>>[] TestCases { get; } = [
                new(123, 321),
                new(-123, -321),
                new(120, 21),
                new(1534236469, 0),
                new(-2147483648, 0),
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return Reverse(input);
        }

        public static int Reverse(int x)
        {
            int sign = Math.Sign(x);
            long y = Math.Abs((long)x);
            long res = 0;

            int digits = y.ToString().Length;
            for (int i = 0; i < digits; i++)
            {
                res += (y % 10) * (long)Math.Pow(10, digits - i - 1);
                y /= 10;
            }

            if (res > int.MaxValue)
                return 0;

            return (int)res * sign;
        }
    }
}
