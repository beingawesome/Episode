using System;

namespace Episode.Utilities
{
    public static class StringExtensions
    {
        public static string SafeTrim(this string source)
        {
            return String.IsNullOrWhiteSpace(source)
                        ? null
                        : source.Trim();
        }
    }
}
