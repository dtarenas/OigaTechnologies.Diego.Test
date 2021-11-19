using System.Text.RegularExpressions;

namespace Core.Extentions
{
    public static class StringExtentions
    {
        public static string RemoveEspecialCharacters(this string value)
        {
            var cleanValue = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return cleanValue.Replace(value, string.Empty);

        }

    }
}
