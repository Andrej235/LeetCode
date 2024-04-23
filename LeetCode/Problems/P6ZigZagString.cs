using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static LeetCode.Problems.P6ZigZagString;

namespace LeetCode.Problems
{
    public class P6ZigZagString : IProblemSolver<ZigZagTC, string>
    {
        public ZigZagTC[] TestCases { get; } = [
                new("ABCDEFGHI", 3, "AEIBDFHCG"),
                new("PAYPALISHIRING", 4, "PINALSIGYAHRPI"),
            ];

        public string Solve(object testCaseInput)
        {
            if (testCaseInput is not ZigZagTCInput zigZagTCInput)
                throw new ArgumentException(null, nameof(testCaseInput));

            return ZigZag(zigZagTCInput.S, zigZagTCInput.NumRows);
        }

        public static string ZigZag(string s, int numRows)
        {
            if (numRows == 1 || s.Length <= numRows)
                return s;

            string result = "";

            int cycle = 2 * numRows - 2;
            for (int i = 0; i < numRows; i++)
            {
                int j = i;
                while (j < s.Length)
                {
                    if (i != 0 && i != numRows - 1 && j - i * 2 > 0)
                        result += s[j - i * 2];

                    result += s[j];
                    j += cycle;
                }

                if (i != 0 && i != numRows - 1 && j - i * 2 > 0 && j - i * 2 < s.Length)
                    result += s[j - i * 2];
            }

            return result;
        }

        public record ZigZagTCInput(string S, int NumRows) : ITestCaseInput;
        public record ZigZagTC : ITestCase<ZigZagTCInput, string>
        {
            public ZigZagTCInput Input { get; }

            public string ExpectedOutput { get; }

            public ZigZagTC(string s, int numRows, string expectedOutput)
            {
                Input = new(s, numRows);
                ExpectedOutput = expectedOutput;
            }
        }
    }
}
