using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core.Translations
{
    public class TranslationMap
    {
        public TranslationMap()
        {
            EnumMap = new Dictionary<MessageDefinitions.Data.Enum, MessageDefinitions.Data.Enum>();
            EnumEntryMap = new Dictionary<MessageDefinitions.Data.EnumEntry, MessageDefinitions.Data.EnumEntry>();
            MessageMap = new Dictionary<MessageDefinitions.Data.Message, MessageDefinitions.Data.Message>();
            MessageFieldMap = new Dictionary<MessageDefinitions.Data.MessageField, MessageDefinitions.Data.MessageField>();
        }

        public IDictionary<MessageDefinitions.Data.Enum, MessageDefinitions.Data.Enum> EnumMap { get; }

        public IDictionary<EnumEntry, EnumEntry> EnumEntryMap { get; }

        public IDictionary<Message, Message> MessageMap { get; }

        public IDictionary<MessageField, MessageField> MessageFieldMap { get; }
    }
}
