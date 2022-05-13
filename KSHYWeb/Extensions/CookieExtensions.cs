using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace KSHYWeb.Extensions
{
    public static class CookieExtensions
    {
        public static IDictionary<string, string> FromCookieString(this string Cookie)
        {
            return Cookie.Split('&').Select(s => s.Split('=')).ToDictionary(kvp => kvp[0], kvp => kvp[1]);
        }

        public static string ToCookieString(this IDictionary<string, string> dict)
        {
            return string.Join("&", dict.Select(kvp => string.Join("=", kvp.Key, kvp.Value)));
        }
       
        public static Dictionary<string, string> ToDictionary(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return dictionary;
        }
        public static List<Dictionary<string, string>> ToListDictionary(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            return dictionary;
        }
    }
}
