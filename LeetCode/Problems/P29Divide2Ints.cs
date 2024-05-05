using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P29Divide2Ints : IProblemSolver<TestCaseWrapper<P29Divide2Ints.Divide2IntsInput, Wrapper<int>>, Wrapper<int>>
    {
        public record Divide2IntsInput(int Dividend, int Divisor) : ITestCaseInput;

        public TestCaseWrapper<Divide2IntsInput, Wrapper<int>>[] TestCases => [
                new(new(10, 3), 3),
                new(new(7, -3), -2),
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not Divide2IntsInput input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return Divide(input.Dividend, input.Divisor);
        }

        public int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
                return int.MaxValue;

            long result = 0;
            bool isPositive = (dividend < 0 == divisor < 0);

            long longDividend = Math.Abs((long)dividend);
            long longDivisor = Math.Abs((long)divisor);

            while (longDividend >= longDivisor)
            {
                int i = 0;
                long divisorTemp = longDivisor;

                while (longDividend >= (divisorTemp << 1))
                {
                    divisorTemp <<= 1;
                    i++;
                }

                result |= 1L << i;
                longDividend -= divisorTemp;
            }

            if (!isPositive)
                result = -result;

            if (result > int.MaxValue || result < int.MinValue)
                return int.MaxValue;

            return (int)result;
        }
    }
}
