using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.MessageDefinitions.Mappers
{
    class StringHelper
    {
        public static string RemoveAtStart(string str, string toRemove)
        {
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
    }
}
