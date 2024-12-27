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
            if (string.IsNullOrEmpty(input) || n <= 0)
                return string.Empty;

            return n >= input.Length ? input : input[..n];
        }

        /// <summary>
        /// Reverses the characters in the specified string.
        /// </summary>
        /// <param name="str">The input string to reverse. If null or empty, the original string is returned.</param>
        /// <returns>
        /// A new string with the characters in reverse order, or the original string if it is null or empty.
        /// </returns>
        public static string? Reverse(this string? str)
        {
            // Return the original string if it is null or empty.
            if (string.IsNullOrEmpty(str)) return str;

            // Reverse the string using a character array.
            var charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
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

        /// <summary>
        /// Encodes the specified string into its Base64 representation using UTF-8 encoding.
        /// </summary>
        /// <param name="str">The input string to encode. If null, an empty string is used.</param>
        /// <returns>A Base64 encoded string representation of the input.</returns>
        /// <remarks>
        /// This method is useful for encoding text data into Base64 format, 
        /// commonly used for safe transmission or storage.
        /// </remarks>
        public static string ToBase64(this string? str)
        {
            // Handle null input by defaulting to an empty string.
            str ??= string.Empty;

            // Convert the string into a UTF-8 encoded byte array.
            var byteArray = Encoding.UTF8.GetBytes(str);

            // Convert the byte array to a Base64 encoded string.
            return Convert.ToBase64String(byteArray);
        }

        /// <summary>
        /// Decodes a Base64 encoded string into its original string representation.
        /// </summary>
        /// <param name="base64String">The Base64 encoded string to decode.</param>
        /// <returns>
        /// The decoded string from the Base64 input, or an empty string if the input is null or empty.
        /// </returns>
        /// <remarks>
        /// The decoding assumes UTF-8 encoding for the resulting string.
        /// If the input is not valid Base64, an exception is thrown.
        /// </remarks>
        public static string FromBase64(this string? base64String)
        {
            // Return an empty string for null or empty input.
            if (string.IsNullOrWhiteSpace(base64String))
                return string.Empty;

            try
            {
                // Decode the Base64 string and convert to a UTF-8 string.
                return Encoding.UTF8.GetString(Convert.FromBase64String(base64String));
            }
            catch (FormatException ex)
            {
                // Throw a descriptive exception for invalid Base64 input.
                throw new ArgumentException("Invalid Base64 string.", nameof(base64String), ex);
            }
        }
    }
}
