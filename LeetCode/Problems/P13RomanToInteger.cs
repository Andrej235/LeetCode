using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P13RomanToInteger : IProblemSolver<TestCaseWrapper<InputWrapper<string>, Wrapper<int>>, Wrapper<int>>
    {
        public TestCaseWrapper<InputWrapper<string>, Wrapper<int>>[] TestCases => [
                new("III", 3),
                new("LVIII", 58),
                new("MCMXCIV", 1994)
            ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<string> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return RomanToInteger(input);
        }

        private readonly Dictionary<char, int> map = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        private int RomanToInteger(string input)
        {
            int result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 < input.Length && map[input[i]] < map[input[i + 1]])
                    result -= map[input[i]];
                else
                    result += map[input[i]];
            }

            return result;
        }
    }
}
