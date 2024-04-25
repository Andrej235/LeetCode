using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P8ATOI : IProblemSolver<TestCaseWrapper<InputWrapper<string>, Wrapper<int>>, Wrapper<int>>
    {
        public TestCaseWrapper<InputWrapper<string>, Wrapper<int>>[] TestCases => [
            //new("42", 42),
            //new("   -42", -42),
            //new("4193 with words", 4193),
            //new("-2147483647", -2147483647),
            new("-91283472332", -2147483648),
        ];

        public Wrapper<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<string> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return ATOI(input);
        }

        public static int ATOI(string input)
        {
            if (input.Length == 0)
                return 0;

            int sign = 1;
            int result = 0;
            bool foundNumber = false;

            for (int i = 0; i < input.Length; i++)
            {
                int charCode = input[i];

                if (charCode >= 48 && charCode <= 57)
                {
                    try
                    {
                        result = checked(result * 10 + (charCode - 48));
                    }
                    catch (OverflowException)
                    {
                        return sign < 0 ? int.MinValue : int.MaxValue;
                    }
                    foundNumber = true;
                    continue;
                }
                else if (foundNumber)
                    return sign * result;

                if (charCode == 32)
                    continue;
                //Plus
                else if (charCode == 43)
                    foundNumber = true;
                //Minus
                else if (charCode == 45)
                {
                    sign = -1;
                    foundNumber = true;
                }
                else
                    return 0;
            }

            return sign * result;
        }
    }
}
