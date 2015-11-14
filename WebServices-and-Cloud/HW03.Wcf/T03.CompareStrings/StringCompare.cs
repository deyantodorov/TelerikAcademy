using System.Text.RegularExpressions;

namespace T03.CompareStrings
{
    /// <summary>
    /// 3. Create a Web service library which accepts two string as parameters. 
    ///    It should return the number of times the second string contains the first string.
    ///    Test it with the integrated WCF client.
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
