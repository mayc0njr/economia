using System;
using System.Globalization;

namespace economia.models
{
    public class Helper
    {
        private static IFormatProvider cultureUS = new CultureInfo("en-US");
        private Helper(){}

        public static decimal ParseDecimal(string s)
        {
            return Decimal.Parse(s, cultureUS);
        }
        public static string DecimalString(decimal d)
        {
            return d.ToString(cultureUS);
        }
    }
}