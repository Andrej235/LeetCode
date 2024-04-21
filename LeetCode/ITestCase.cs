using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public interface ITestCaseInput { }

    public interface ITestCase<TInput, TOutput> where TInput : ITestCaseInput
    {
        TInput Input { get; }
        public TOutput ExpectedOutput { get; }
    }
}
