using System.Collections.Generic;
using System.ComponentModel;

namespace ISCommon.Utility
{
    public static class ISObject
    {
        public static string ISObjectToQueryString(this object routeValues)
        {
            string queryString = "";

            Dictionary<string, object> routeValue = ISAnonymousObjectToKeyValue(routeValues);
            foreach (string key in routeValue.Keys)
            {
                string value = string.Format("{0}={1}", key, routeValue[key]);
                string value2 = string.Format("{0}=", key);
                if (value2 != value)
                {
                    if (queryString.Length > 0) queryString += "&";
                    queryString += value;
                }
            }

            return (queryString.Length > 0) ? "?" + queryString : "";
        }

        public static Dictionary<string, object> ISAnonymousObjectToKeyValue(this object anonymousObject)
        {
            var dictionary = new Dictionary<string, object>();
            if (anonymousObject != null)
            {
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(anonymousObject))
                {
                    dictionary.Add(propertyDescriptor.Name, propertyDescriptor.GetValue(anonymousObject));
                }
            }
            return dictionary;
        }
    }
}
