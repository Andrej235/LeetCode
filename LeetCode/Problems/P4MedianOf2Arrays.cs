using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class P4MedianOf2Arrays : IProblemSolver<P4MedianOf2Arrays.MedianOf2ArraysTestCase, Wrapper<double>>
    {
        public MedianOf2ArraysTestCase[] TestCases => [
                new([1,2], [3], 2.0),
                new([1,2], [3,4], 2.5),
                new([], [1], 1.0),
            ];

        public Wrapper<double> Solve(object testCaseInput)
        {
            if (testCaseInput is not MedianOf2ArraysTestCaseInput medianOf2ArraysTestCase)
                throw new ArgumentException(null, nameof(testCaseInput));

            return MedianOf2Arrays(medianOf2ArraysTestCase.Nums1, medianOf2ArraysTestCase.Nums2);
        }

        public static Wrapper<double> MedianOf2Arrays(int[] nums1, int[] nums2)
        {
            int iterations = nums1.Length + nums2.Length;
            bool even = iterations % 2 == 0;
            iterations = iterations / 2 + 1;
            int[] result = new int[iterations];
            int i = 0;
            int j = 0;
            while (i + j < iterations)
            {
                int num1 = i < nums1.Length ? nums1[i] : int.MaxValue;
                int num2 = j < nums2.Length ? nums2[j] : int.MaxValue;
                if (num1 <= num2)
                {
                    result[i + j] = num1;
                    i++;
                }
                else
                {
                    result[i + j] = num2;
                    j++;
                }
            }

            return even ? (result[^1] + result[^2]) / 2.0 : result[^1];
        }

        public record MedianOf2ArraysTestCaseInput(int[] Nums1, int[] Nums2) : ITestCaseInput;
        public record MedianOf2ArraysTestCase : ITestCase<MedianOf2ArraysTestCaseInput, Wrapper<double>>
        {
            public MedianOf2ArraysTestCase(int[] nums1, int[] nums2, Wrapper<double> expectedOutput)
            {
                Input = new(nums1, nums2);
                ExpectedOutput = expectedOutput;
            }

            public MedianOf2ArraysTestCaseInput Input { get; }

            public Wrapper<double> ExpectedOutput { get; }
        }
    }
}
