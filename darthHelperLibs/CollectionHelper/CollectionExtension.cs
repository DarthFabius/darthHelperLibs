using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darthHelperLibs.CollectionHelper
{
    public static class CollectionExtension
    {
        public static bool IsEmptyOrNull<T>(this IEnumerable<T> collection)
        {
            return collection?.Any() != true;
        }
    }
}
