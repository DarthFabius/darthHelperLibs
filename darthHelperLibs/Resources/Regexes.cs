using System.Text.RegularExpressions;

namespace darthHelperLibs.Resources
{
    /// <summary>
    /// A static class containing precompiled regular expressions.
    /// </summary>
    internal static class Regexes
    {
        /// <summary>
        /// A precompiled regular expression for validating email addresses.
        /// </summary>
        internal static readonly Regex EmailRegex = new Regex(
        @"^(?!.*\.\.)(?!.*-$)(?!-)[a-zA-Z0-9!#$%&'*+/=?^_`{|}~.-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }
}
