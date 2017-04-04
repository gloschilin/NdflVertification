using System;

namespace NdflVerification.ReportsContext.Extensions
{
    public static class TextExtensions
    {
        public static int ToInt(this string text)
        {
            return int.Parse(text);
        }

        public static DateTime ToDateTime(this string text)
        {
            return DateTime.Parse(text);
        }
    }
}
