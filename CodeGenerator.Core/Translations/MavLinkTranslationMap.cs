using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.CodeGenerator.Core.Translations
{
    public class MavLinkTranslationMap
    {
        public IDictionary<MessageDefinitions.Data.Enum, MessageDefinitions.Data.Enum> EnumMap { get; set; }

        public IDictionary<MessageDefinitions.Data.EnumEntry, MessageDefinitions.Data.EnumEntry> EnumEntryMap { get; set; }

        public IDictionary<MessageDefinitions.Data.Message, MessageDefinitions.Data.Message> MessageMap { get; set; }

        public IDictionary<MessageDefinitions.Data.MessageField, MessageDefinitions.Data.MessageField> MessageFieldMap { get; set; }
    }
}
