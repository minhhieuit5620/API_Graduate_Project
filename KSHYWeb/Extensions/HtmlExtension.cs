using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
//using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using System.Web;
using System.Collections.Generic;
using ISWeb.Extensions;

namespace KSHYWeb.Extensions
{
    public static class HtmlExtension
    {
        /// <summary>
        /// Convert IHtmlContent to string
        /// </summary>
        /// <param name="tag">Tag</param>
        /// <returns>String</returns>
        public static string ToHtmlString(this IHtmlContent tag)
        {
            using (var writer = new StringWriter())
            {
                tag.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }

        /// <summary>
        /// Convert IHtmlContent to string
        /// </summary>
        /// <param name="tag">Tag</param>
        /// <returns>String</returns>
        public static string ToRawString(this IHtmlContent tag)
        {
            return System.Net.WebUtility.HtmlDecode(tag.ToHtmlString());
        }

        /// <summary>
        /// Conventer text full size to unicode
        /// </summary>
        /// <param name="tag">Tag</param>
        /// <returns>String</returns>
        public static string ConventFSToUni(this IHtmlContent tag, string str)
        {
            return str.ConventFSToUni();
        }


        public static string ISSubstr(this IHtmlContent tag, string str, int length)
        {
            return str.ISSubstr(length);
        }

        public static string[] ISStrSplit(this IHtmlContent tag, string str)
        {
            return str.ISStrSplit();
        }

        /// <summary>
        /// Conventer text full size to unicode
        /// </summary>
        /// <param name="tag">Tag</param>
        /// <returns>String</returns>
        public static string ConventFSToUni(this IHtmlHelper tag, string str)
        {
            return str.ConventFSToUni();
        }


        public static string ISSubstr(this IHtmlHelper tag, string str, int length)
        {
            return str.ISSubstr(length);
        }

        public static string[] ISStrSplit(this IHtmlHelper tag, string str)
        {
            return str.ISStrSplit();
        }

        public static IHtmlContent BreakLine(this IHtmlHelper helper, string input)
        {
            if (string.IsNullOrEmpty(input)) return null;
            return helper.Raw(input.Replace("\r\n", "<br/>").Replace("\n", "<br/>"));
        }
       
    }
}
