using System.Text;

namespace darthHelperLibs.StringHelper
{
    public static class StringExtension
    {
        /// <summary>
        /// Returns the leftmost n characters of a given string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="n">The number of characters to extract.</param>
        /// <returns>
        /// The leftmost n characters of the input string, or an empty string if the input is null, empty, or n is less than or equal to zero.
        /// </returns>
        public static string Left(this string? input, int n)
        {
            if (n <= 0 || string.IsNullOrEmpty(input))
                return string.Empty;

            return n >= input.Length ? input : input[..n];
        }

        public static string BuildString(this IEnumerable<string>? values)
        {
            if (values == null || !values.Any()) return string.Empty;

            // Calculate estimated capacity, handling null values safely
            var estimatedCapacity = values.Sum(v => v?.Length ?? 0);

            var strBuilder = new StringBuilder(estimatedCapacity);

            // Append each string, treating null values as empty
            foreach (var value in values)
            {
                strBuilder.Append(value ?? string.Empty);
            }

            return strBuilder.ToString();
        }
    }
}
