using System;

namespace mitoSoft.SolarInverter.Extensions
{
    internal static class CharExtensions
    {
        public static bool ToBoolean(this char value)
        {
            if (value == '0')
            {
                return false;
            }
            else if (value == '1')
            {
                return true;
            }
            else
            {
                throw new InvalidCastException($"Not a valid character to convert to Boolean: {value}");
            }
        }
    }
}