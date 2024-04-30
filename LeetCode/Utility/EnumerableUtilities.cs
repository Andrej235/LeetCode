namespace LeetCode.Utility
{
    public static class EnumerableUtilities
    {
        public static string ToEnumeratedString<T>(this IEnumerable<T> collection) => $"[{string.Join(", ", collection)}]";
        public static bool CollectionFuzzyEquals<T>(this IEnumerable<T> collection1, IEnumerable<T> collection2) => collection1.Count() == collection2.Count() && collection1.All(x => collection2.Contains(x));
        public static bool CollectionFuzzyEqualsJSON<T>(this IEnumerable<T> collection1, IEnumerable<T> collection2) => collection1.Count() == collection2.Count() && collection1.All(x => collection2.Any(y => x.JSONEquals(y)));
    }
}
