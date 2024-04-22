namespace LeetCode
{
    public interface ITestCaseInput { }

    public interface ITestCase<out TInput, out TOutput> where TInput : ITestCaseInput
    {
        TInput Input { get; }
        public TOutput ExpectedOutput { get; }
    }
}
