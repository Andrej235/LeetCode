using LeetCode.Problems;

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
                ShowMenu(0, search.Length == 1 || keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control) ? "" : search[..^1]);
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

            foreach (var testCase in problemSolver.TestCases)
            {
                var result = problemSolver.Solve(testCase.Input);

                Console.WriteLine("Got: " + result.ToJSON());
                Console.WriteLine("Expected: " + testCase.ExpectedOutput.ToJSON());

                Console.WriteLine(result.JSONEquals(testCase.ExpectedOutput) ? "OK" : "Failed");
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
