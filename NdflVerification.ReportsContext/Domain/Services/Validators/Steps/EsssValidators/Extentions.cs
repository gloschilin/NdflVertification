using System;
using System.ComponentModel;
using System.Globalization;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public static class Extentions
    {
        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static decimal ToDecimal(this string value)
        {
            return ConvertValue<decimal>(value);
        }

        private static T ConvertValue<T>(object obj)
        {

            if (obj == null || obj == DBNull.Value)
                return default(T);
            if (obj.GetType() == typeof(T))
                return (T)obj;

            if (typeof(decimal) == typeof(T))
            {
                return (T)(object)decimal.Parse(obj.ToString(), new NumberFormatInfo() { NumberDecimalSeparator = "." });
            }

            var type = typeof(T);
            type = Nullable.GetUnderlyingType(type) ?? type; // шобы Nullable работала


            if (obj.GetType() == type)
                return (T)obj;

            return (T)TypeDescriptor.GetConverter(type).ConvertFrom(obj);

        }
    }
}