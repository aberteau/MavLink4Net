using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MavLink4Net.CodeGenerator.Core.Translations.Interfaces;
using MavLink4Net.MessageDefinitions.Data;
using MavLink4Net.MessageDefinitions.Mappers;

namespace MavLink4Net.CodeGenerator.Core.Translations
{
    public class DefaultTranslation
        : IMessageNameTranslation, IMessageFieldNameTranslation, IEnumNameTranslation, IEnumEntryNameTranslation, IMessageFilter
    {
        private readonly EnumValuePrefixRemovalStrategy _strategy;
        private string _enumValuePrefix;

        public DefaultTranslation(EnumValuePrefixRemovalStrategy strategy)
        {
            _strategy = strategy;
        }

        public string TranslateName(Message pMessage)
        {
            string name = NamingConventionHelper.GetPascalStyleString(pMessage.Name);
            return name;
        }

        public string TranslateName(MessageField pMessageField)
        {
            string name = NamingConventionHelper.GetPascalStyleString(pMessageField.Name);
            return name;
        }

        public string TranslateName(MessageDefinitions.Data.Enum pEnum)
        {
            string name = NamingConventionHelper.GetEnumName(pEnum.Name);
            return name;
        }

        public void SetContext(IEnumerable<EnumEntry> xEnumEntries, string xEnumName)
        {
            _enumValuePrefix = EnumHelper.GetEnumValuePrefix(xEnumEntries, xEnumName, _strategy);
        }

        public string TranslateName(EnumEntry pEnumEntry)
        {
            String shortName = StringHelper.RemoveAtStart(pEnumEntry.Name, _enumValuePrefix);
            string name = NamingConventionHelper.GetPascalStyleString(shortName);
            return name;
        }

        public IEnumerable<Message> Filter(IEnumerable<Message> xMessages)
        {
            // discard anything beyond 255
            IEnumerable<Message> filteredMessages = xMessages.Where(m => m.Id < 256);
            return filteredMessages;
        }
    }
}
