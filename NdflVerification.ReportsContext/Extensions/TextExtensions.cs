using System;
using System.Globalization;

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
            return DateTime.ParseExact(text, "dd.MM.yyyy", null, DateTimeStyles.None);
        }
    }
}
