using System;
using System.Linq;
using System.Text;
using MavLink4Net.MessageDefinitions.Mappers;

namespace MavLink4Net.CodeGenerator.Core
{
    class NamingConventionHelper
    {
        public static string GetEnumName(string enumName)
        {
            if (String.IsNullOrWhiteSpace(enumName))
                return null;

            var enumNamePrefix = "MAV_";
            string shortEnumName = StringHelper.RemoveAtStart(enumName, enumNamePrefix);
            string pascalStyleString = GetPascalStyleString(shortEnumName);
            return pascalStyleString;
        }

        public static string GetPascalStyleString(string str)
        {
            // MAV_AUTOPILOT -> MavAutopilot

            string[] parts = str.Split('_', '-');
            if (parts.Length == 0)
                return String.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (string s in parts)
                sb.Append(GetPascalStyleWord(s));

            string escapedItemName = GetEscapedItemName(sb.ToString());
            return escapedItemName;
        }

        private static string GetPascalStyleWord(string word)
        {
            if (String.IsNullOrWhiteSpace(word))
                return null;

            String firstChar = word.First().ToString().ToUpper();
            String otherChars = word.ToLower().Substring(1);

            string pascalStyleWord = $"{firstChar}{otherChars}";
            return pascalStyleWord;
        }

        public static string GetEscapedItemName(string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            if (s[0] >= '0' && s[0] <= '9')
                s = '_' + s;

            s = s.Trim();
            s = s.Replace(' ', '_');
            s = s.Replace('+', '_');
            s = s.Replace('.', '_');
            s = s.Replace('(', '_');
            s = s.Replace(')', '_');
            s = s.Replace('-', '_');

            return s;
        }
    }
}
