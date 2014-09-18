using System.Collections.Generic;

namespace aNyoNe.GetInfoFrom12306
{
    public static class ExtensionMethods
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static string JoinAsString(this IEnumerable<string> value, string separator)
        {
            return string.Join(separator, value);
        }

        public static string JoinAsString(this object[] value, string separator)
        {
            return string.Join(separator, value);
        }

        public static string JoinAsString(this string[] value, string separator)
        {
            return string.Join(separator, value);
        }

        public static string JoinAsString(this IEnumerable<char> value, string separator)
        {
            return string.Join(separator, value);
        }
    }
}
