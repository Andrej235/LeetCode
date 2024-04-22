namespace LeetCode.Problems
{
    public interface IProblemSolver<out TestCase, out Output> where TestCase : ITestCase<ITestCaseInput, Output>
    {
        TestCase[] TestCases { get; }
        Output Solve(object testCaseInput);
    }
}
