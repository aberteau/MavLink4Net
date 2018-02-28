using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.MessageDefinitions.Mappers
{
    public enum EnumValuePrefixRemovalStrategy
    {
        None,
        RemoveEnumName,
        RemoveLongestCommonString
    }
}
