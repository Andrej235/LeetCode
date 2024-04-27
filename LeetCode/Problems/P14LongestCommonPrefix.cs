using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P14LongestCommonPrefix : IProblemSolver<TestCaseWrapper<InputWrapper<string[]>, string>, string>
    {
        public TestCaseWrapper<InputWrapper<string[]>, string>[] TestCases => [
                new(new(["flower","flow","flight"]), "fl"),
                new(new(["dog","racecar","car"]), ""),
                new(new(["ab", "a"]), "a"),
            ];

        public string Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<string[]> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return LongestCommonPrefix(input);
        }

        public string LongestCommonPrefix(string[] strs)
        {
            string first = strs[0];

            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length || first[i] != strs[j][i])
                        return first[..i];
                }
            }

            return first;
        }
    }
}
