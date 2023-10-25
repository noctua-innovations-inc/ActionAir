using System.Text.RegularExpressions;

namespace ActionAir;

public static partial class StringExtensions
{
    [GeneratedRegex("([a-z])([A-Z])", RegexOptions.Compiled)]
    private static partial Regex SplitPropertyNameGeneratedRegex();

    public static string CreateLabelFromPropertyName(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        // Split words on underscore.
        value = value.Replace('_', ' ');

        // Split words on letter case change.
        value = SplitPropertyNameGeneratedRegex().Replace(value, "$1 $2").Trim();
        if (value.Length > 0 )
        {
            // Ensure first character is in upper-case.
            return $"{char.ToUpper(value[0])}{value[1..]}";
        }
        return value;
    }
}