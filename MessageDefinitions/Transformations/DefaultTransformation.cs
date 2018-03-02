using System;
using System.Collections.Generic;
using System.Linq;
using MavLink4Net.MessageDefinitions.Mappers;
using MavLink4Net.MessageDefinitions.Transformations.Interfaces;

namespace MavLink4Net.MessageDefinitions.Transformations
{
    public class DefaultTransformation
        : IMessageNameTransformation, IMessageFieldNameTransformation, IEnumNameTransformation, IEnumEntryNameTransformation
    {
        private readonly EnumValuePrefixRemovalStrategy _strategy;
        private string _enumValuePrefix;

        public DefaultTransformation(EnumValuePrefixRemovalStrategy strategy)
        {
            _strategy = strategy;
        }

        public string Transform(Xml.Message pMessage)
        {
            string name = NamingConventionHelper.GetPascalStyleString(pMessage.Name);
            return name;
        }

        public string Transform(Xml.MessageField pMessageField)
        {
            string name = NamingConventionHelper.GetPascalStyleString(pMessageField.Name);
            return name;
        }

        public string Transform(Xml.Enum pEnum)
        {
            string name = NamingConventionHelper.GetEnumName(pEnum.Name);
            return name;
        }

        public void SetContext(IEnumerable<Xml.EnumEntry> xEnumEntries, string xEnumName)
        {
            _enumValuePrefix = EnumHelper.GetEnumValuePrefix(xEnumEntries, xEnumName, _strategy);
        }

        public string Transform(Xml.EnumEntry pEnumEntry)
        {
            String shortName = StringHelper.RemoveAtStart(pEnumEntry.Name, _enumValuePrefix);
            string name = NamingConventionHelper.GetPascalStyleString(shortName);
            return name;
        }
    }
}
