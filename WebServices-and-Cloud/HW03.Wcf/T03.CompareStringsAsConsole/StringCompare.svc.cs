using System.Text.RegularExpressions;

namespace T03.CompareStringsAsConsole
{
    /// <summary>
    /// This will help you to test Compare strings instead of configuring IIS
    /// </summary>
    public class StringCompare : IStringCompare
    {
        public int NumberOfContains(string first, string second)
        {
            int count = Regex.Matches(second, first).Count;
            return count;
        }
    }
}
