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
            @"^(?!.*\.\.)[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*" +   // Local part (ASCII)
            @"(@)[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*\.[A-Za-z]{2,}$" + // Domain part (ASCII)
            @"|^([A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*)" +   // Local part (Unicode)
            @"(@)[A-Za-z0-9\u4e00-\u9fa5A-Za-z0-9-]+(\.[A-Za-z0-9\u4e00-\u9fa5A-Za-z0-9-]+)*\.[A-Za-z]{2,}$",  // Domain part (Unicode)
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
    }
}
