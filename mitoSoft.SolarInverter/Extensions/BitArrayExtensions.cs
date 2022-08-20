using System;
using System.Collections;

namespace mitoSoft.SolarInverter.Extensions
{
    internal static class BitArrayExtensions
    {
        public static Int64 ToInt64(this BitArray value)
        {
            var array = new int[2];
            value.CopyTo(array, 0);
            return (uint)array[0] + ((long)(uint)array[1] << 32);
        }

        public static Int32 ToInt32(this BitArray value)
        {
            var array = new int[1];
            value.CopyTo(array, 0);
            return (int)array[0];
        }
    }
}