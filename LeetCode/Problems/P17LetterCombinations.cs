using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P17LetterCombinations : IProblemSolver<TestCaseWrapper<InputWrapper<string>, IList<string>>, IList<string>>
    {
        public TestCaseWrapper<InputWrapper<string>, IList<string>>[] TestCases => [
                new("23", ["ad","ae","af","bd","be","bf","cd","ce","cf"]),
                new("", []),
                new("2", ["a","b","c"])
            ];

        public IList<string> Solve(object testCaseInput)
        {
            if (testCaseInput is not InputWrapper<string> input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return LetterCombinations(input);
        }

        private readonly Dictionary<char, string> map = new() {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };

        public IList<string> LetterCombinations(string input)
        {
            if (input.Length < 1)
                return [];

            IList<string> combinations = [];
            AddCombinations(combinations, "", input);
            return combinations;
        }

        public void AddCombinations(IList<string> combinations, string currentCombination, string input)
        {
            bool add = input[1..].Length == 0;
            foreach (char letter in map[input[0]])
            {
                if (add)
                    combinations.Add(currentCombination + letter);
                else
                    AddCombinations(combinations, currentCombination + letter, input[1..]);
            }
        }
    }
}
