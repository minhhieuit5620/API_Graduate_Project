namespace ISCommon.Utility
{
    public static class ISMath
    {
        /// <summary>
        ///    Ham kiem tra co phai la so hay khong
        /// </summary>
        /// <param name="s">Chuoi can kiem tra</param>
        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

    }
}