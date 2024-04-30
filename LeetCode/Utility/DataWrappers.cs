using LeetCode.Problems;

namespace LeetCode.Utility
{
    public class Wrapper<T>(T value) where T : unmanaged
    {
        public T Value { get; } = value;
        public static implicit operator Wrapper<T>(T value) => new(value);
        public static implicit operator T(Wrapper<T> value) => value.Value;
    }

    public class InputWrapper<T>(T value) : ITestCaseInput
    {
        public T Value { get; } = value;
        public static implicit operator InputWrapper<T>(T value) => new(value);
        public static implicit operator T(InputWrapper<T> value) => value.Value;
    }

    public class TestCaseWrapper<T, U>(T input, U expectedOutput) : ITestCase<T, U> where T : ITestCaseInput
    {
        public T Input { get; } = input;
        public U ExpectedOutput { get; } = expectedOutput;
    }
}
