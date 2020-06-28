namespace GTSharp.Domain.Utils
{
    public static class StringExtensionUtil
    {
        public static string ToFormat(this string str, params string[] strs)
        {
            return string.Format(str, strs);
        }

        public static int Length0IfNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str) ? 0 : str.Length;
        }
    }
}