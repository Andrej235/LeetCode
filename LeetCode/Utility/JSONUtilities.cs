using System.Text.Json;

namespace LeetCode.Utility
{
    public static class JSONUtilities
    {
        public static string ToJSON<T>(this T obj) => JsonSerializer.Serialize(obj);
        public static bool JSONEquals<T>(this T obj1, T obj2) => JsonSerializer.Serialize(obj1) == JsonSerializer.Serialize(obj2);
    }
}
