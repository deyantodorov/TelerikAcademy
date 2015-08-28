namespace Helper
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Helper class for numerical systems
    /// </summary>
    public class NumSys
    {
        /// <summary>
        /// Shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format
        /// </summary>
        public static string ConvertFloatToBinary(float value)
        {
            // Find sign: 1 bit for sign
            string sign;

            if (value < 0)
            {
                sign = "1";
                // Convert to positive for easy calculations
                value *= -1;
            }
            else
            {
                sign = "0";
            }

            // Find exponent: 8 bits for exponent
            string exponent;

            int power = 0;
            float fraction = 0.0f;

            if (value < 1)
            {
                while (value < 1.0f)
                {
                    float remainder = value * 2;
                    value = remainder;
                    power++;

                    fraction = value;
                }

                power *= -1;
            }
            else
            {
                while (value > 2.0f)
                {
                    float remainder = value / 2;
                    value = remainder;
                    power++;

                    fraction = value;
                }
            }

            exponent = NumSys.DecToBinExact(127 + power).PadLeft(8, '0');

            // Find mantissa:
            StringBuilder sb = new StringBuilder();

            if (fraction > 1.0f)
            {
                fraction -= 1;
            }

            for (int i = 0; i < 23; i++)
            {
                fraction *= 2;

                if (fraction >= 1.0f)
                {
                    sb.Append("1");
                    fraction -= 1;
                }
                else
                {
                    sb.Append("0");
                }
            }

            string mantissa = sb.ToString();

            return sign + exponent + mantissa;
        }

        /// <summary>
        /// Create string with zero or ones. Detect automatically number and choose 8, 16, 32, 64 digits.
        /// </summary>
        public static string DecToBin(long input)
        {
            // Define number of zeros and ones
            int digits = 0;

            if (input > sbyte.MaxValue || input < sbyte.MinValue)
            {
                digits = 15;
            }
            else if (input > short.MaxValue || input < short.MinValue)
            {
                digits = 31;
            }
            else if (input > int.MaxValue || input < int.MinValue)
            {
                digits = 63;
            }
            else
            {
                digits = 7;
            }

            string inputToBin = string.Empty;

            for (int bitPosition = digits; bitPosition >= 0; bitPosition--)
            {
                long bitValue = (input >> bitPosition) & 1;
                inputToBin += bitValue;
            }

            return inputToBin;
        }

        /// <summary>
        /// Create string with ones and zeros. Limitted to exact number of digits.
        /// </summary>
        public static string DecToBinExact(long input)
        {
            bool negative = false;

            // If number is negative +1 and convert to positive and continue with conversion
            if (input < 0)
            {
                input += 1;
                input *= -1;
                negative = true;
            }
            StringBuilder sb = new StringBuilder();

            while (input != 0)
            {
                long remainder = input & 1;
                input /= 2;
                sb.Append(remainder);
            }

            // If number is negative reverse 1 to 0 and 0 to 1
            if (negative)
            {
                return ReplacerZeroAndOnes(Reverser(sb.ToString()));
            }
            else
            {
                return Reverser(sb.ToString());
            }
        }

        /// <summary>
        /// Binary to unsigned decimal
        /// </summary>
        public static long BinToUDec(string input)
        {
            long result = 0;
            byte[] binValue = new byte[input.Length];
            int pow = input.Length - 1;

            // Fill array with 0 and 1
            for (int i = 0; i < input.Length; i++)
            {
                binValue[i] = byte.Parse(input[i].ToString());
            }

            for (int pos = 0; pos < binValue.Length; pos++)
            {
                result += binValue[pos] * Numbers.NumberToPower(2, pow);
                pow--;
            }

            return result;
        }

        /// <summary>
        /// Binary to signed decimal
        /// </summary>
        public static long BinToSDec(string input)
        {
            bool negative = false;

            if (input[0] == '1')
            {
                negative = true;
            }

            long result = 0;
            byte[] binValue = new byte[input.Length];
            int pow = input.Length - 1;

            // Fill array with 0 and 1
            for (int i = 0; i < input.Length; i++)
            {
                binValue[i] = byte.Parse(input[i].ToString());
            }

            for (int pos = 0; pos < binValue.Length; pos++)
            {
                if (pos == 0 && negative)
                {
                    result += binValue[pos] * (Numbers.NumberToPower(2, pow) * (-1));
                }
                else
                {
                    result += binValue[pos] * Numbers.NumberToPower(2, pow);
                }

                pow--;
            }

            return result;
        }

        /// <summary>
        /// Binary to hexadecimal converter
        /// </summary>
        public static string BinToHex(string value)
        {
            // Adding leading zeros
            if (value.Length % 4 != 0)
            {
                int repetitions = 4 - (value.Length % 4);
                string add = new string('0', repetitions);
                value = add + value;
            }

            List<string> bytes = new List<string>();

            for (int start = 0, end = 4; start < value.Length; start += 4)
            {
                bytes.Add(value.Substring(start, end));
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bytes.Count; i++)
            {
                switch (bytes[i])
                {
                    case "0000": sb.Append("0"); break;
                    case "0001": sb.Append("1"); break;
                    case "0010": sb.Append("2"); break;
                    case "0011": sb.Append("3"); break;
                    case "0100": sb.Append("4"); break;
                    case "0101": sb.Append("5"); break;
                    case "0110": sb.Append("6"); break;
                    case "0111": sb.Append("7"); break;
                    case "1000": sb.Append("8"); break;
                    case "1001": sb.Append("9"); break;
                    case "1010": sb.Append("A"); break;
                    case "1011": sb.Append("B"); break;
                    case "1100": sb.Append("C"); break;
                    case "1101": sb.Append("D"); break;
                    case "1110": sb.Append("E"); break;
                    case "1111": sb.Append("F"); break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Hexadecimal to binary converter
        /// </summary>
        public static string HexToBin(string value)
        {
            char[] digits = value.ToCharArray();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < digits.Length; i++)
            {
                switch (digits[i])
                {
                    case '0': sb.Append("0000"); break;
                    case '1': sb.Append("0001"); break;
                    case '2': sb.Append("0010"); break;
                    case '3': sb.Append("0011"); break;
                    case '4': sb.Append("0100"); break;
                    case '5': sb.Append("0101"); break;
                    case '6': sb.Append("0110"); break;
                    case '7': sb.Append("0111"); break;
                    case '8': sb.Append("1000"); break;
                    case '9': sb.Append("1001"); break;
                    case 'A': sb.Append("1010"); break;
                    case 'B': sb.Append("1011"); break;
                    case 'C': sb.Append("1100"); break;
                    case 'D': sb.Append("1101"); break;
                    case 'E': sb.Append("1110"); break;
                    case 'F': sb.Append("1111"); break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Convert any positive number from base 2 till 16 to 10 base number
        /// </summary>
        public static long FromAnyTo10(string number, int baseFrom)
        {
            if (number[0] == '-')
            {
                throw new ArgumentException("I can't work with negative numbers!");
            }
            else if (baseFrom < 2 || baseFrom > 16)
            {
                throw new ArgumentException("I can't work with numbers with base smaller than 2 and greater than 16!");
            }

            int[] digits = new int[number.Length];

            for (int i = 0; i < digits.Length; i++)
            {
                int temp = 0;

                switch (number[i])
                {
                    case 'A': temp = 10; break;
                    case 'B': temp = 11; break;
                    case 'C': temp = 12; break;
                    case 'D': temp = 13; break;
                    case 'E': temp = 14; break;
                    case 'F': temp = 15; break;
                    default: temp = int.Parse(number[i].ToString()); break;
                }

                digits[i] = temp;
            }

            long result = 0;
            int power = number.Length - 1;

            for (int i = 0; i < digits.Length; i++)
            {
                result += digits[i] * Numbers.NumberToPower(baseFrom, power);
                power--;
            }

            return result;
        }

        /// <summary>
        /// Convert positive 10 base number to any number from base 2 to 16
        /// </summary>
        public static string From10ToAny(long num, int baseTo)
        {
            if (baseTo < 2 || baseTo > 16)
            {
                throw new ArgumentException("I can't work with numbers with base smaller than 2 and greater than 16!");
            }

            StringBuilder sb = new StringBuilder();

            long remainder = 0;

            while (num != 0)
            {
                remainder = num % baseTo;
                num /= baseTo;

                switch (remainder)
                {
                    case 10: sb.Append("A"); break;
                    case 11: sb.Append("B"); break;
                    case 12: sb.Append("C"); break;
                    case 13: sb.Append("D"); break;
                    case 14: sb.Append("E"); break;
                    case 15: sb.Append("F"); break;
                    default: sb.Append(remainder); break;
                }
            }

            return Reverser(sb.ToString());
        }

        /// <summary>
        /// Reverse input string
        /// </summary>
        private static string Reverser(string text)
        {
            char[] array = text.ToCharArray();

            Array.Reverse(array);

            return new string(array);
        }

        /// <summary>
        /// Replace zero to one and opposite. Used for negative decimals to binary conversion.
        /// </summary>
        private static string ReplacerZeroAndOnes(string input)
        {
            char[] replaced = input.ToCharArray();

            for (int i = 0; i < replaced.Length; i++)
            {
                if (replaced[i] == '0')
                {
                    replaced[i] = '1';
                }
                else
                {
                    replaced[i] = '0';
                }
            }

            // Define number of zeros and ones
            int digits = 0;

            if (input.Length > 16)
            {
                digits = 32 - input.Length;
            }
            else if (input.Length > 32)
            {
                digits = 64 - input.Length;
            }
            else
            {
                digits = 16 - input.Length;
            }

            return new string('1', digits) + new string(replaced);
        }
    }
}