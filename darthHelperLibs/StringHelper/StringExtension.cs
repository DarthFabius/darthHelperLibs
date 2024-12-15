using System.Text;

namespace darthHelperLibs.StringHelper
{
    public static class StringExtension
    {
        public static string BuildString(this IEnumerable<string>? values)
        {
            if (values == null) return string.Empty;
            var valueList = values.ToList();
            if(valueList.Any()) return string.Empty;

            var estimatedCapacity = valueList.Sum(v => v.Length);
            var strBuilder = new StringBuilder(estimatedCapacity);

            foreach (var value in valueList)
            {
                strBuilder.Append(value);
            }

            return strBuilder.ToString();
        }
    }
}
