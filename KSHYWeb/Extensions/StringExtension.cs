using System.Text;
using System.Text.RegularExpressions;

namespace KSHYWeb.Extensions
{
    public static class StringExtension
    {
        
        /// <summary>
        ///    Hàm chuyển đổi tiếng việt có dấu sang không dấu
        /// </summary>
        /// <param name="s">Chuỗi cần chuyển đổi</param>
        public static string ToUnSign(this string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, System.String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        /// <summary>
        ///    Hàm chuyển đổi tiếng việt có dấu sang không dấu
        /// </summary>
        /// <param name="s">Chuỗi cần chuyển đổi</param>
        /// limit legnth: 500
        public static string ToUnSign2(this string s)
        {
            var maxLength = 250;
            string temp = ToUnSign(s);
            temp = temp.Replace(' ', '-');
            if (temp.Length > maxLength)
            {
                return temp.Substring(temp.Length - (maxLength));
            }
            return temp.Replace(':', '-');
        }
        
        /* Conventer text full size to unicode */
        public static string ConventFSToUni(this string str)
        { //０１２３４５６７８９
            //var str;
            str = str.Replace("０", "0");
            str = str.Replace("１", "1");
            str = str.Replace("２", "2");
            str = str.Replace("３", "3");
            str = str.Replace("４", "4");
            str = str.Replace("５", "5");
            str = str.Replace("６", "6");
            str = str.Replace("７", "7");
            str = str.Replace("８", "8");
            str = str.Replace("９", "9");
            return str;
        }


        public static string ISSubstr(this string str, int length)
        {
            string[] sss = ISStrSplit(str);
            int i = 0;
            string s = "";
            foreach (string ss in sss)
            {
                i += ASCIIEncoding.UTF8.GetByteCount(ss);
                s += ss;
                //string n = mb_detect_encoding($char);
                // i += n == 'UTF-8' ? 2 : 1;
                if (i >= length)
                   break;

            }
            return s;
        }

        public static string[] ISStrSplit(this string str)
        {
            //return preg_split('/(?<!^)(?!$)/u', $string);
            //string my_string = "test 1  2   3";
            return Regex.Split(str, @"(?<!^)(?!$)");
        }
        public static string EncodeHtml(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            return value.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&#39;").Replace("/", "&#x2F;");
        }
        public static string DecodeHtml(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            //
            return value.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("&#39;", "'").Replace("&#x2F;", "/");
        }
    }
}
