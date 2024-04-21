namespace LeetCode.Problems
{
    public interface IProblemSolver<TestCase, Input, Output> where TestCase : ITestCase<Input, Output> where Input : ITestCaseInput
    {
        List<TestCase> TestCases { get; }
        Output Solve(Input testCase);
    }
}
