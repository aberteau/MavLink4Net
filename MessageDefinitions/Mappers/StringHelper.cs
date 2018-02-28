using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MavLink4Net.MessageDefinitions.Mappers
{
    class StringHelper
    {
        public static string RemoveAtStart(string str, string toRemove)
        {
            if (String.IsNullOrWhiteSpace(toRemove))
                return str;

            if (!str.StartsWith(toRemove))
                return str;

            string resultStr = str.Substring(toRemove.Length);
            return resultStr;
        }

        private static string NormalizeCarriageReturn(string rawStr)
        {
            if (String.IsNullOrWhiteSpace(rawStr))
                return null;

            string str = rawStr.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
            return str;
        }

        public static string TrimAndNormalizeCarriageReturn(string rawDescription)
        {
            if (String.IsNullOrWhiteSpace(rawDescription))
                return null;

            string trimStr = rawDescription.Trim();
            string str = NormalizeCarriageReturn(trimStr);
            return str;
        }

        public static IEnumerable<string> GetLongestCommonStartSubstrings(IEnumerable<string> strings)
        {
            if (strings == null)
                throw new ArgumentNullException("strings");

            IEnumerable<string> stringEnumerable = strings as string[] ?? strings.ToArray();

            if (!stringEnumerable.Any() || stringEnumerable.Any(s => string.IsNullOrWhiteSpace(s)))
                throw new ArgumentException("None string must be empty", "strings");

            List<List<string>> allSubstrings = new List<List<string>>();

            foreach (string t in stringEnumerable)
            {
                var substrings = new List<string>();
                string str = t;

                for (int l = 1; l <= str.Length; l++)
                {
                    string substring = str.Substring(0, l);
                    if (allSubstrings.Count < 1 || allSubstrings.Last().Contains(substring))
                        substrings.Add(substring);
                }
                allSubstrings.Add(substrings);
            }
            if (allSubstrings.Last().Any())
            {
                var mostCommon = allSubstrings.Last()
                    .GroupBy(str => str)
                    .OrderByDescending(g => g.Key.Length)
                    .ThenByDescending(g => g.Count())
                    .Select(g => g.Key);
                return mostCommon;
            }
            return Enumerable.Empty<string>();
        }

        public static string GetLongestCommonStartSubstring(IEnumerable<string> strings)
        {
            IEnumerable<string> mostCommonSubstrings = GetLongestCommonStartSubstrings(strings);
            string mostCommonSubstring = mostCommonSubstrings.FirstOrDefault();
            return mostCommonSubstring;
        }
    }
}
