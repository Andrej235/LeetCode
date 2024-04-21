using LeetCode.Problems;

namespace LeetCode
{
    internal class Program
    {
        static void Main()
        {
            foreach (var ps in GetAllProblemSolvers())
            {
                Console.WriteLine(ps.Name);
            }
        }

        static IEnumerable<Type> GetAllProblemSolvers()
        {
            Type iProbleSolverType = typeof(IProblemSolver<,,>);

            return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => !x.IsInterface && !x.IsAbstract && x.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == iProbleSolverType));
        }
    }
}
