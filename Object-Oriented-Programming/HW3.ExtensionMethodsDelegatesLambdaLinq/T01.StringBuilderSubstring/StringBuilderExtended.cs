namespace T01.StringBuilderSubstring
{
    using System;
    using System.Text;

    public static class StringBuilderExtended
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            string input = sb.ToString();
            input = input.Substring(index, length);

            StringBuilder newSb = new StringBuilder(input);
            return newSb;
        }
    }
}
