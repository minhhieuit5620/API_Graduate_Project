using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ISWeb.Extensions
{
    public static class UrlExtension
    {
        public static string BaseUrl(this HttpContext httpContext)
        {
            return httpContext.Request.Scheme + "://" + httpContext.Request.Host + httpContext.Request.PathBase;
        }

        public static string BaseUrl(this ViewContext ViewContext)
        {
            return ViewContext.HttpContext.BaseUrl();
        }
    }
}
