using System.Net.Mail;
using System.Text;

namespace darthHelperLibs.StringHelper
{
    public static class StringExtension
    {
        /// <summary>
        /// Determines whether the specified string is a valid email address.
        /// </summary>
        /// <param name="email">The input string to validate as an email address.</param>
        /// <returns>
        /// <c>true</c> if the string is a valid email address; otherwise, <c>false</c>.
        /// Returns <c>false</c> for null, empty, or whitespace-only strings.
        /// </returns>
        public static bool IsValidEmail(this string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // Check that the domain part does not end with a hyphen or contain consecutive dots
            var atIndex = email.LastIndexOf('@');
            if (atIndex == -1 || atIndex == email.Length - 1)
            {
                return false; // No domain or domain is empty
            }

            var domain = email.Substring(atIndex + 1);

            // Check for consecutive dots in domain
            if (domain.Contains(".."))
            {
                return false; // Domain cannot contain consecutive dots
            }

            // Check that domain does not end with a hyphen
            if (domain.EndsWith("-"))
            {
                return false; // Domain cannot end with a hyphen
            }

            // Check that domain does not start with a hyphen
            if (domain.StartsWith("-"))
            {
                return false; // Domain cannot start with a hyphen
            }

            // Check that the domain part contains at least one period (.) and is followed by valid characters (TLD)
            if (!domain.Contains(".") || domain.IndexOf('.') == domain.Length - 1)
            {
                return false; // Domain must contain at least one period and not end with it
            }

            // Check for TLD length: TLD must be at least 2 characters long
            var tld = domain[(domain.LastIndexOf('.') + 1)..];
            if (tld.Length < 2)
            {
                return false; // TLD must be at least 2 characters
            }

            // Validate using the MailAddress class
            try
            {
                _ = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

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
        /// Repeats the specified string a given number of times and returns the concatenated result.
        /// </summary>
        /// <param name="str">The string to repeat. Can be null or empty.</param>
        /// <param name="count">The number of times to repeat the string. Must be non-negative.</param>
        /// <returns>
        /// A new string consisting of the input string repeated <paramref name="count"/> times.
        /// If <paramref name="count"/> is 0 or less, returns an empty string.
        /// </returns>
        public static string Repeat(this string? str, int count)
        {
            // Return an empty string if string is null o blanck
            if(string.IsNullOrEmpty(str)) return string.Empty;

            // Return an empty string if count is zero or negative.
            if (count <= 0) return string.Empty;

            // Use Enumerable.Repeat to generate a sequence of the string repeated 'count' times,
            // then concatenate the sequence into a single string.
            return string.Concat(Enumerable.Repeat(str, count));
        }

        /// <summary>
        /// Concatenates a collection of strings into a single string, treating null values as empty.
        /// </summary>
        /// <param name="values">The collection of strings to concatenate. Can include null values.</param>
        /// <returns>
        /// A single concatenated string, or an empty string if the collection is null or empty.
        /// </returns>
        public static string ToString(this IEnumerable<string?>? values)
        {
            if (values == null)
                return string.Empty;

            // Avoid multiple iteration
            var enumerable = values.ToList();

            // Calculate estimated capacity using Aggregate for better readability
            var estimatedCapacity = enumerable.Aggregate(0, (sum, value) => sum + (value?.Length ?? 0));

            var strBuilder = new StringBuilder(estimatedCapacity);

            // Use StringBuilder.Append directly while iterating
            foreach (var value in enumerable)
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
