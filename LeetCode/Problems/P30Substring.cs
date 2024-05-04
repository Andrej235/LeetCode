using LeetCode.Utility;

namespace LeetCode.Problems
{
    //Basically just copied a solution from https://leetcode.com/problems/substring-with-concatenation-of-all-words/solutions/3680493/c-sliding-window-approach-with-explanation/
    public class P30Substring : IProblemSolver<TestCaseWrapper<P30Substring.Input, IList<int>>, IList<int>>
    {
        public record Input(string S, string[] Words) : ITestCaseInput;

        public TestCaseWrapper<Input, IList<int>>[] TestCases => [
                new(new("barfoothefoobarman", ["foo","bar"]), [0, 9]),
                new(new("wordgoodgoodgoodbestword", ["word","good","best","word"]), []),
                new(new("barfoofoobarthefoobarman", ["bar","foo","the"]), [6,9,12]),
            ];

        public IList<int> Solve(object testCaseInput)
        {
            if (testCaseInput is not Input input)
                return [];

            return FindSubstring(input.S, input.Words);
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> result = [];

            int wordLength = words[0].Length;
            int totalWords = words.Length;
            int substringLength = wordLength * totalWords;

            if (s.Length < substringLength)
                return result;

            Dictionary<string, int> wordCount = [];
            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                    wordCount[word]++;
                else
                    wordCount[word] = 1;
            }

            for (int i = 0; i < wordLength; i++)
            {
                Dictionary<string, int> currentWordCount = [];
                int wordsFound = 0;
                int left = i;

                for (int j = i; j <= s.Length - wordLength; j += wordLength)
                {
                    string currentWord = s.Substring(j, wordLength);

                    if (wordCount.ContainsKey(currentWord))
                    {
                        if (currentWordCount.ContainsKey(currentWord))
                            currentWordCount[currentWord]++;
                        else
                            currentWordCount[currentWord] = 1;

                        wordsFound++;

                        while (currentWordCount[currentWord] > wordCount[currentWord])
                        {
                            string leftWord = s.Substring(left, wordLength);
                            currentWordCount[leftWord]--;
                            wordsFound--;
                            left += wordLength;
                        }

                        if (wordsFound == totalWords)
                        {
                            result.Add(left);
                            string leftWord = s.Substring(left, wordLength);
                            currentWordCount[leftWord]--;
                            wordsFound--;
                            left += wordLength;
                        }
                    }
                    else
                    {
                        currentWordCount.Clear();
                        wordsFound = 0;
                        left = j + wordLength;
                    }
                }
            }
            return result;
        }
    }
}
