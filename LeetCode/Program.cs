using LeetCode.Problems;
using System.Collections;

namespace LeetCode
{
    internal class Program
    {
        private static readonly IEnumerable<Type> problemSolvers = GetAllProblemSolvers();

        static void Main()
        {
            ShowMenu();
        }

        static void ShowMenu(int choice = 0)
        {
            Console.Clear();
            for (int i = 0; i < problemSolvers.Count(); i++)
            {
                Console.ForegroundColor = i == choice ? ConsoleColor.Green : ConsoleColor.White;
                Console.WriteLine(problemSolvers.ElementAt(i));
            }

            var keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.DownArrow)
                ShowMenu(choice + 1 >= problemSolvers.Count() ? 0 : choice + 1);
            else if (keyInfo.Key == ConsoleKey.UpArrow)
                ShowMenu(choice - 1 < 0 ? problemSolvers.Count() - 1 : choice - 1);
            else if (keyInfo.Key == ConsoleKey.Enter)
                StartTest(problemSolvers.ElementAt(choice));
            else
                ShowMenu(choice);
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

            var outputType = problemSolver.TestCases.First().ExpectedOutput.GetType();
            if (outputType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(outputType))
            {
                Console.WriteLine("array-like");
                foreach (var testCase in problemSolver.TestCases)
                {
                    var result = problemSolver.Solve(testCase.Input);
                    if (result is null)
                    {
                        if (testCase.ExpectedOutput is null)
                            Console.WriteLine("OK");
                        else
                            Console.WriteLine("Failed");
                    }

                    if (testCase.ExpectedOutput is null)
                    {
                        Console.WriteLine("Failed");
                        return;
                    }

                    var expectedOutput = (testCase.ExpectedOutput as IEnumerable)?.Cast<object>();
                    var actualOutput = (result as IEnumerable)?.Cast<object>();

                    if (expectedOutput is null || actualOutput is null || expectedOutput.Count() != actualOutput.Count())
                    {
                        Console.WriteLine("Failed");
                        continue;
                    }

                    for (int i = 0; i < actualOutput.Count(); i++)
                    {
                        if (!actualOutput.JSONEquals(expectedOutput))
                        {
                            Console.WriteLine("Failed");
                            return;
                        }
                    }

                    Console.WriteLine("OK");
                }

                return;
            }

            foreach (var testCase in problemSolver.TestCases)
            {
                var result = problemSolver.Solve(testCase.Input);

                Console.WriteLine("Got: " + result.ToJSON());
                Console.WriteLine("Expected: " + testCase.ExpectedOutput.ToJSON());

                if (result.JSONEquals(testCase.ExpectedOutput))
                    Console.WriteLine("OK");
                else
                    Console.WriteLine("Failed");

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
