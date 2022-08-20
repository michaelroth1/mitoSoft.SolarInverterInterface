namespace mitoSoft.SolarInverter.Extensions
{
    internal static class IntExtensions
    {
        public static string ToWordString(this int input) => input.ToBitString(16);

        public static string ToBitString(this int input, int numberOfBits)
        {
            var bools = ToBooleanArray(input, numberOfBits);

            int[] bits = bools.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();

            var result = "";
            for (int i = 0; i < numberOfBits; i++)
            {
                result = $"{bits[i]}{result}";
            }

            return result;
        }

        private static bool[] ToBooleanArray(int input, int numberOfBits)
        {
            return Enumerable.Range(0, numberOfBits)
            .Select(bitIndex => 1 << bitIndex)
            .Select(bitMask => (input & bitMask) == bitMask)
            .ToArray();
        }
    }
}