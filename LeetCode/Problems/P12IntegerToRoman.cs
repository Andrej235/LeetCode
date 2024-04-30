using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P12IntegerToRoman : IProblemSolver<TestCaseWrapper<InputWrapper<int>, string>, string>
    {
        public TestCaseWrapper<InputWrapper<int>, string>[] TestCases { get; } = [
                new(3, "III"),
                new(58, "LVIII"),
                new(1994, "MCMXCIV")
            ];

        public string Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<int> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return IntToRoman(input);
        }

        private readonly Dictionary<int, string> map = new()
        {
            { 1, "I" },
            { 5, "V" },
            { 10, "X" },
            { 50, "L" },
            { 100, "C" },
            { 500, "D" },
            { 1000, "M" }
        };

        public string IntToRoman(int input)
        {
            string roman = "";
            int i = 0;
            while (input > 0)
            {
                var digit = input % 10;
                input /= 10;

                var power = (int)Math.Pow(10, i++);

                if (digit % 5 == 4)
                {
                    roman = map[power] + map[(digit + 1) * power] + roman;
                }
                else
                {
                    if (digit % 5 != 0 && digit % 5 < 4)
                        for (int j = 0; j < digit % 5; j++)
                            roman = map[power] + roman;

                    if (digit / 5 == 1)
                        roman = map[power * 5] + roman;
                }
            }

            return roman;
        }
    }
}