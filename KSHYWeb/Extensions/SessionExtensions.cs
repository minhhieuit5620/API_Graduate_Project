using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace KSHYWeb.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
        public static object GetObject(this ISession session, string key)
        {
            return session.GetString(key);
        }
        public static DateTime? GetDateTime(this ISession session, string key)
        {
            object value = session.GetObject(key);
            if (value == null || value == "null")
                return null;
            try
            {                
                return DateTime.ParseExact(JsonConvert.DeserializeObject<string>(value.ToString()), "yyyy/MM/dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                return null;
            }
        }
    }
}
