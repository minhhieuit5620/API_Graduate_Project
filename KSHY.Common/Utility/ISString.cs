using System;
using System.Text.RegularExpressions;
using System.Text;

namespace ISCommon.Utility
{
    public static class ISString
    {
        ///// <summary>
        /////    Hàm chuyển đổi tiếng việt có dấu sang không dấu
        ///// </summary>
        ///// <param name="s">Chuỗi cần chuyển đổi</param>
        //public static string ToUnSign(this string s)
        //{
        //    Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        //    string temp = s.Normalize(NormalizationForm.FormD);
        //    return regex.Replace(temp, System.String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        //}

        ///// <summary>
        /////    Hàm chuyển đổi tiếng việt có dấu sang không dấu
        ///// </summary>
        ///// <param name="s">Chuỗi cần chuyển đổi</param>
        ///// limit legnth: 500
        //public static string ToUnSign2(this string s)
        //{
        //    var maxLength = 250;
        //    string temp = ToUnSign(s);
        //    temp = temp.Replace(' ', '-');
        //    if (temp.Length > maxLength)
        //    {
        //        return temp.Substring(temp.Length - (maxLength));
        //    }
        //    return temp.Replace(':', '-');
        //}

        public static string preg_replace(this string input, string[] pattern, string[] replacements)
        {
            if (replacements.Length != pattern.Length)
                throw new ArgumentException("Replacement and Pattern Arrays must be balanced");

            for (var i = 0; i < pattern.Length; i++)
            {
                input = Regex.Replace(input, pattern[i], replacements[i]);
            }

            return input;
        }

        public static string preg_replace(this string input, string[] pattern, string replacements)
        {

            for (var i = 0; i < pattern.Length; i++)
            {
                input = Regex.Replace(input, pattern[i], replacements);
            }

            return input;
        }

        public static string preg_replace(this string input, string[] pattern, string replacements, out int count)
        {
            int i = 0;
            for (; i < pattern.Length; i++)
            {
                input = Regex.Replace(input, pattern[i], replacements);
            }
            count = i;
            return input;
        }

        public static string preg_replace(this string input, string pattern, string replacement)
        {
            input = Regex.Replace(input, pattern, replacement);
            return input;
        }

        public static string strstr(this string hayStack, string needle, bool beforeNeedle)
        {
            if (beforeNeedle)
                return hayStack.Substring(0, hayStack.IndexOf(needle));
            else
                return hayStack.Substring(hayStack.IndexOf(needle));
        }
        public static string strstr(this string hayStack, string needle)
        {
            return strstr(hayStack, needle, false);
        }

        public static string stristr(this string hayStack, string needle, bool beforeNeedle)
        {
            if (beforeNeedle)
                return hayStack.Substring(0, hayStack.ToLower().IndexOf(needle.ToLower()));
            else
                return hayStack.Substring(hayStack.ToLower().IndexOf(needle.ToLower()));
        }

        public static string stristr(this string hayStack, string needle)
        {
            return stristr(hayStack, needle, false);
        }

        public static string strrchr(this string hayStack, string needle)
        {
            int i = hayStack.LastIndexOf(needle);
            return hayStack.Substring(i);
        }

        public static T[] ArraySlice<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static string Right(this string input, int length)
        {
            if (length >= input.Length)
            {
                return input;
            }
            else
            {
                return input.Substring(input.Length - length);
            }
        }

        public static string Left(this string input, int length)
        {
            if (length >= input.Length)
            {
                return input;
            }
            else
            {
                if (length < 0)
                {
                    length = input.Length + length;
                }
                return input.Substring(0, length);
            }
        }

        public static string ISTrim(this string input)
        {
            if (input == null)
            {
                return "";
            }
            else
            {
                return input.Trim();
            }
        }

        public static string Replace(this string input, string[] oldValues, string[] newValues)
        {
            if (oldValues.Length != newValues.Length)
                throw new ArgumentException("Replacement and Pattern Arrays must be balanced");
            for (var i = 0; i < oldValues.Length; i++)
            {
                input = input.Replace(oldValues[i], newValues[i]);
            }

            return input;
        }

        public static string RemoveInvisibleCharacters(this string input, bool url_encoded = true)
        {
            string[] non_displayables = new string[] { };

            // every control character except newline (dec 10)
            // carriage return (dec 13), and horizontal tab (dec 09)

            if (url_encoded)
            {
                non_displayables[0] = "$0[0-8bcef]";	// url encoded 00-08, 11, 12, 14, 15
                non_displayables[1] = "$1[0-9a-f]";	// url encoded 16-31
            }

            non_displayables[2] = "[\x00-\x08\x0B\x0C\x0E-\x1F\x7F]+";	// 00-08, 11, 12, 14-31, 127
            int count = 0;

            do
            {
                input = input.preg_replace(non_displayables, "", out count);
            }
            while (count > 0);

            return input;
        }

        /// <summary>
        /// Returns a string with backslashes before characters that need to be quoted
        /// </summary>
        /// <param name="InputTxt">Text string need to be escape with slashes</param>
        public static string AddSlashes(this string InputTxt)
        {
            // List of characters handled:
            // \000 null
            // \010 backspace
            // \011 horizontal tab
            // \012 new line
            // \015 carriage return
            // \032 substitute
            // \042 double quote
            // \047 single quote
            // \134 backslash
            // \140 grave accent

            string Result = InputTxt;

            try
            {
                Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"[\000\010\011\012\015\032\042\047\134\140]", "\\$0");
            }
            catch (Exception Ex)
            {
                // handle any exception here
                Console.WriteLine(Ex.Message);
            }

            return Result;
        }

        /// <summary>
        /// Un-quotes a quoted string
        /// </summary>
        /// <param name="InputTxt">Text string need to be escape with slashes</param>
        public static string StripSlashes(this string InputTxt)
        {
            // List of characters handled:
            // \000 null
            // \010 backspace
            // \011 horizontal tab
            // \012 new line
            // \015 carriage return
            // \032 substitute
            // \042 double quote
            // \047 single quote
            // \134 backslash
            // \140 grave accent

            string Result = InputTxt;

            try
            {
                Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"(\\)([\000\010\011\012\015\032\042\047\134\140])", "$2");
            }
            catch (Exception Ex)
            {
                // handle any exception here
                Console.WriteLine(Ex.Message);
            }

            return Result;
        }

        /* Conventer text full size to unicode */
        public static string  ConventFSToUni(this string str) { //０１２３４５６７８９
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

    }
}