using LeetCode.DataStructures;
using LeetCode.Problems;
using LeetCode.Utility;
using System.Text.RegularExpressions;

namespace LeetCode
{
    internal class Program
    {
        static void Main() => ShowMenu();
        private static readonly IEnumerable<Type> problemSolvers = GetAllProblemSolvers();

        static void ShowMenu(int choice = 0, string search = "")
        {
            Console.Clear();
            if (search != "")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Search: {search}");
            }

            var searchResults = problemSolvers.Where(x => x.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase));
            for (int i = 0; i < searchResults.Count(); i++)
            {
                Console.ForegroundColor = i == choice ? ConsoleColor.Green : ConsoleColor.White;
                Console.WriteLine(searchResults.ElementAt(i).Name);
            }

            var keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.DownArrow)
                ShowMenu(choice + 1 >= searchResults.Count() ? 0 : choice + 1, search);
            else if (keyInfo.Key == ConsoleKey.UpArrow)
                ShowMenu(choice - 1 < 0 ? searchResults.Count() - 1 : choice - 1, search);
            else if (keyInfo.Key == ConsoleKey.Enter)
                StartTest(searchResults.ElementAt(choice));
            else if (keyInfo.Key == ConsoleKey.Backspace)
                ShowMenu(0, search.Length == 1 || keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control) ? "" : (search.Length > 0 ? search[..^1] : ""));
            else
                ShowMenu(choice, search + keyInfo.KeyChar);
        }

        static void StartTest(Type problemSolverType)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(problemSolverType.Name);

            var constructor = problemSolverType.GetConstructor([]);
            if (constructor is null)
            {
                Console.WriteLine("Constructor not found");
                return;
            }

            if (constructor.Invoke([]) is not IProblemSolver<ITestCase<ITestCaseInput, object>, object> problemSolver)
            {
                Console.WriteLine("Problem solver not found");
                return;
            }

            if (problemSolver.TestCases.Length == 0)
            {
                Console.WriteLine("Test cases not found");
                return;
            }

            var iProblemSolverTypeTypeArguments = problemSolverType.GetInterfaces().First(x => x.IsAssignableTo(typeof(IProblemSolver<ITestCase<ITestCaseInput, object>, object>))).GetGenericArguments();
            if (iProblemSolverTypeTypeArguments.Length != 2)
            {
                Console.WriteLine($"Problem solver not created correctly, contains {iProblemSolverTypeTypeArguments.Length} type arguments instead of 2 (ITestCase<> and output)");
                return;
            }

            Type outputType = iProblemSolverTypeTypeArguments[1];
            if (outputType == typeof(ListNode))
            {
                foreach (var testCase in problemSolver.TestCases)
                {
                    var result = problemSolver.Solve(testCase.Input);
                    if (result is not ListNode resultListNode || testCase.ExpectedOutput is not ListNode expectedListNode)
                        continue;

                    Console.WriteLine($"Got: {resultListNode}");
                    Console.WriteLine($"Expected: {expectedListNode}");

                    Console.WriteLine(result.JSONEquals(testCase.ExpectedOutput) ? "OK" : "Failed");
                    Console.WriteLine();
                }
                return;
            }

            foreach (var testCase in problemSolver.TestCases)
            {
                var result = problemSolver.Solve(testCase.Input);

                Console.WriteLine("Got: " + result.ToJSON());
                Console.WriteLine("Expected: " + testCase.ExpectedOutput.ToJSON());

                bool success = result is IEnumerable<object> resultEnumerable && testCase.ExpectedOutput is IEnumerable<object> expectedEnumerable
                    ? resultEnumerable.CollectionFuzzyEquals(expectedEnumerable)
                    : result.JSONEquals(testCase.ExpectedOutput);

                Console.WriteLine(success ? "OK" : "Failed");
                Console.WriteLine();
            }
        }

        static IEnumerable<Type> GetAllProblemSolvers()
        {
            Type iProbleSolverType = typeof(IProblemSolver<,>);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => !x.IsInterface && !x.IsAbstract && x.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == iProbleSolverType));
        }
    }
}
