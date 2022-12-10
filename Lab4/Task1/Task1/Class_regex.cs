using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    internal class Class_regex
    {
        private string myRegex = @"\[(o.|f)\][^d-k]{2}..\b";
        Regex regex;
        MatchCollection matches;

        public Class_regex() { }

        public bool isRegexMatches(string pattern, string word, string extension = "")
        {
            string pattern2 = string.Format(@"\b{0}{1}", pattern, extension);
            return Regex.IsMatch(word, pattern2, RegexOptions.IgnoreCase);
        }

        public bool isMyRegexMatches(string word)
        {
            return Regex.IsMatch(word, myRegex, RegexOptions.IgnoreCase);
        }

        public string[] getRegexMatches(string text, string regPattern)
        {
            List<string> matchedWords = new List<string>();
            regex = new Regex(regPattern);
            matches = regex.Matches(text);
            
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    matchedWords.Add(match.ToString());
                }
            }
            return matchedWords.ToArray();
        }
    }
}
