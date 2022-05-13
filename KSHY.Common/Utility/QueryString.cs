using System.Collections.Generic;
using System.Linq;

namespace ISCommon.Utility
{
    public class QueryString
    {
        public static string Stringify(Dictionary<string, string> parameters)
        {
            return string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        }
    }
}
