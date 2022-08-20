using System.Collections;

namespace mitoSoft.SolarInverter.Extensions
{
    internal static class StringExtensions
    {
        public static BitArray ToBitArray(this string bits)
        {
            var length = bits.Length;

            var boolArray = new List<bool>();
            for (int i = length - 1; i > 0; i--)
            {
                var s = char.Parse(bits.Substring(i, 1));
                boolArray.Add(s.ToBoolean());
            }

            return new BitArray(boolArray.ToArray());
        }
    }
}