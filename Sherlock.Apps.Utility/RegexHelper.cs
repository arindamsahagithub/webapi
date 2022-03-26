using System;
using System.Text.RegularExpressions;

namespace Sherlock.Apps.Utility
{
    public class RegexHelper
    {
        public string GetRegexMatch(string text, string regexFormat, string variable)
        {
            var pattern = new Regex(regexFormat);
            var match = pattern.Match(text);
            return match.Groups[variable].Value;
        }

        public bool IsRegexMatch(string text, string regexFormat)
        {
            return new Regex(regexFormat).IsMatch(text);
        }
    }
}
