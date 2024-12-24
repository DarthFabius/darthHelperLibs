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

        /// <summary>
        /// Concatenates a collection of strings into a single string, treating null values as empty.
        /// </summary>
        /// <param name="values">The collection of strings to concatenate. Can include null values.</param>
        /// <returns>
        /// A single concatenated string, or an empty string if the collection is null or empty.
        /// </returns>
        public static string BuildString(this IEnumerable<string?>? values)
        {
            if (values == null || !values.Any())
                return string.Empty;

            // Calculate estimated capacity using Aggregate for better readability
            var estimatedCapacity = values.Aggregate(0, (sum, value) => sum + (value?.Length ?? 0));

            var strBuilder = new StringBuilder(estimatedCapacity);

            // Use StringBuilder.Append directly while iterating
            foreach (var value in values)
            {
                strBuilder.Append(value ?? string.Empty);
            }

            return strBuilder.ToString();
        }
    }
}
