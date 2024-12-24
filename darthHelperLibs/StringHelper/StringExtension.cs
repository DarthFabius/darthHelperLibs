﻿using System.Text;

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
            if (string.IsNullOrEmpty(input) || n <= 0)
                return string.Empty;

            return n >= input.Length ? input : input[..n];
        }

        /// <summary>
        /// Returns the rightmost `n` characters from the given string.
        /// </summary>
        /// <param name="input">The input string from which to extract the rightmost characters.</param>
        /// <param name="n">The number of characters to extract from the right end of the string.</param>
        /// <returns>
        /// A string containing the rightmost `n` characters of the input string, or an empty string
        /// if the input is null, empty, or `n` is non-positive.
        /// If `n` is greater than or equal to the length of the string, the entire string is returned.
        /// </returns>
        public static string Right(this string? input, int n)
        {
            if (string.IsNullOrEmpty(input) || n <= 0)
                return string.Empty;

            return n >= input.Length ? input : input[^n..];
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
