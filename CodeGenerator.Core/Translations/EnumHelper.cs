using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;
using MavLink4Net.MessageDefinitions.Mappers;

namespace MavLink4Net.CodeGenerator.Core.Translations
{
    class EnumHelper
    {
        public static string GetEnumValuePrefix(IEnumerable<EnumEntry> xEnumEntries, String xEnumName, EnumValuePrefixRemovalStrategy strategy)
        {
            switch (strategy)
            {
                case EnumValuePrefixRemovalStrategy.None:
                    return null;

                case EnumValuePrefixRemovalStrategy.RemoveEnumName:
                    if (!String.IsNullOrWhiteSpace(xEnumName))
                        return xEnumName;

                    return null;

                case EnumValuePrefixRemovalStrategy.RemoveLongestCommonString:
                    if (xEnumEntries.Count() > 1)
                    {
                        IEnumerable<String> xEnumValues = xEnumEntries.Select(e => e.Name);
                        string longestStartSubstring = StringHelper.GetLongestCommonStartSubstring(xEnumValues);

                        if (String.IsNullOrWhiteSpace(longestStartSubstring))
                            return null;

                        return longestStartSubstring;
                    }

                    if (!String.IsNullOrWhiteSpace(xEnumName))
                        return xEnumName;

                    return null;
            }

            return null;
        }
    }
}
