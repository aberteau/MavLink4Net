using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;
using MavLink4Net.MessageDefinitions.Mappers;

namespace MavLink4Net.MessageDefinitions
{
    public class DataProvider
    {
        public static Data.MavLink LoadMavLink(string path)
        {
            Xml.MavLink xMavLink = XmlSerializer.Deserialize(path);
            EnumValuePrefixRemovalStrategy enumValueNamePrefixRemovalStrategy = EnumValuePrefixRemovalStrategy.RemoveLongestCommonString;
            MavLink dMavLink = Mappers.MappingHelper.ToModel(xMavLink, enumValueNamePrefixRemovalStrategy);

            return dMavLink;
        }
    }
}
