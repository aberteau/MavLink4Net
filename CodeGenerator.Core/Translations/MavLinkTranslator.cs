using System;
using System.Collections.Generic;
using System.Linq;
using MavLink4Net.CodeGenerator.Core.Translations.Interfaces;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core.Translations
{
    public class MavLinkTranslator
    {
        private readonly IMessageNameTranslation _messageNameTranslation;
        private readonly IMessageFieldNameTranslation _messageFieldNameTranslation;
        private readonly IEnumNameTranslation _enumNameTranslation;
        private readonly IEnumEntryNameTranslation _enumEntryNameTranslation;

        private readonly IDictionary<MessageDefinitions.Data.Enum, MessageDefinitions.Data.Enum> _enumMap;
        private readonly IDictionary<MessageDefinitions.Data.EnumEntry, MessageDefinitions.Data.EnumEntry> _enumEntryMap;
        private readonly IDictionary<MessageDefinitions.Data.Message, MessageDefinitions.Data.Message> _messageMap;
        private readonly IDictionary<MessageDefinitions.Data.MessageField, MessageDefinitions.Data.MessageField> _messageFieldMap;

        public MavLinkTranslator(IMessageNameTranslation messageNameTranslation, IMessageFieldNameTranslation messageFieldNameTranslation, IEnumNameTranslation enumNameTranslation, IEnumEntryNameTranslation enumEntryNameTranslation)
        {
            _messageNameTranslation = messageNameTranslation;
            _messageFieldNameTranslation = messageFieldNameTranslation;
            _enumNameTranslation = enumNameTranslation;
            _enumEntryNameTranslation = enumEntryNameTranslation;
            _enumMap = new Dictionary<MessageDefinitions.Data.Enum, MessageDefinitions.Data.Enum>();
            _enumEntryMap = new Dictionary<MessageDefinitions.Data.EnumEntry, MessageDefinitions.Data.EnumEntry>();
            _messageMap = new Dictionary<MessageDefinitions.Data.Message, MessageDefinitions.Data.Message> ();
            _messageFieldMap = new Dictionary<MessageDefinitions.Data.MessageField, MessageDefinitions.Data.MessageField>();
        }

        public MavLinkTranslationResult Translate(MavLink xMavLink)
        {
            MavLinkTranslationResult result = new MavLinkTranslationResult();
            result.MavLink = TranslateMavLink(xMavLink);
            result.TranslationMap = GetTranslationMap();
            return result;
        }

        private MavLinkTranslationMap GetTranslationMap()
        {
            MavLinkTranslationMap translationMap = new MavLinkTranslationMap();
            translationMap.EnumMap = _enumMap;
            translationMap.EnumEntryMap = _enumEntryMap;
            translationMap.MessageMap = _messageMap;
            translationMap.MessageFieldMap = _messageFieldMap;
            return translationMap;
        }

        private MavLink TranslateMavLink(MavLink xMavLink)
        {
            MavLink dMavLink = new MavLink();
            dMavLink.Version = xMavLink.Version;
            dMavLink.Dialect = xMavLink.Dialect;

            dMavLink.Enums = Translate(xMavLink.Enums);

            IEnumerable<Message> xMessages = Filter(xMavLink.Messages).ToList();
            dMavLink.Messages = Translate(xMessages);
            return dMavLink;
        }

        private IEnumerable<Message> Filter(IEnumerable<Message> xMessages)
        {
            // discard anything beyond 255
            IEnumerable<Message> filteredMessages = xMessages.Where(m => m.Id < 256);
            return filteredMessages;
        }

        #region Message

        private IEnumerable<Message> Translate(IEnumerable<Message> xMessages)
        {
            return xMessages.Select(m => Translate(m)).ToList();
        }

        private Message Translate(Message xMessage)
        {
            Message dMessage = new Message();
            dMessage.Id = xMessage.Id;
            dMessage.Name = _messageNameTranslation.TranslateName(xMessage);
            dMessage.Description = xMessage.Description;
            dMessage.Fields = Translate(xMessage.Fields);

            _messageMap.Add(dMessage, xMessage);

            return dMessage;
        }

        #endregion

        #region Enum

        private IEnumerable<MessageDefinitions.Data.Enum> Translate(IEnumerable<MessageDefinitions.Data.Enum> xEnums)
        {
            return xEnums.Select(m => Translate(m)).ToList();
        }

        private MessageDefinitions.Data.Enum Translate(MessageDefinitions.Data.Enum xEnum)
        {
            MessageDefinitions.Data.Enum dEnum = new MessageDefinitions.Data.Enum();
            string enumName = _enumNameTranslation.TranslateName(xEnum);
            dEnum.Name = enumName;
            dEnum.Description = xEnum.Description;
            dEnum.Entries = Translate(xEnum.Entries, enumName);

            _enumMap.Add(dEnum, xEnum);

            return dEnum;
        }

        #endregion

        #region MessageField

        private IEnumerable<MessageField> Translate(IEnumerable<MessageField> xMessageFields)
        {
            return xMessageFields.Select(m => Translate(m)).ToList();
        }

        private MessageField Translate(MessageField xMessageField)
        {
            MessageField dMessageField = new MessageField();
            dMessageField.DefinitionIndex = xMessageField.DefinitionIndex;
            dMessageField.Type = Translate(xMessageField.Type);
            dMessageField.Name = _messageFieldNameTranslation.TranslateName(xMessageField);
            dMessageField.Units = xMessageField.Units;
            dMessageField.Display = xMessageField.Display;
            dMessageField.Text = xMessageField.Text;

            _messageFieldMap.Add(dMessageField, xMessageField);

            return dMessageField;
        }

        private MessageFieldType Translate(MessageFieldType xMessageField)
        {
            MessageFieldType fieldType = new MessageFieldType();
            fieldType.ArrayLength = xMessageField.ArrayLength;
            fieldType.PrimitiveType = xMessageField.PrimitiveType;
            fieldType.TypeLength = xMessageField.TypeLength;
            fieldType.Enum = GetTranslatedEnum(xMessageField.Enum);
            return fieldType;
        }

        private MessageDefinitions.Data.Enum GetTranslatedEnum(MessageDefinitions.Data.Enum pEnum)
        {
            if (pEnum == null)
                return null;

            IEnumerable<KeyValuePair<MessageDefinitions.Data.Enum, MessageDefinitions.Data.Enum>> keyValuePairs = _enumMap.Where(kvp => kvp.Value.Name.Equals(pEnum.Name));
            MessageDefinitions.Data.Enum translatedEnum = keyValuePairs.Select(kvp => kvp.Key).FirstOrDefault();
            return translatedEnum;
        }

        #endregion

        #region EnumEntry

        private IEnumerable<EnumEntry> Translate(IEnumerable<EnumEntry> xEnumEntries, string xEnumName)
        {
            _enumEntryNameTranslation.SetContext(xEnumEntries, xEnumName);
            return xEnumEntries.Select(m => Translate(m)).ToList();
        }

        private EnumEntry Translate(EnumEntry xEnumEntry)
        {
            EnumEntry dEnumEntry = new EnumEntry();
            dEnumEntry.Name = _enumEntryNameTranslation.TranslateName(xEnumEntry);
            dEnumEntry.Value = xEnumEntry.Value;
            dEnumEntry.Description = xEnumEntry.Description;
            dEnumEntry.Parameters = xEnumEntry.Parameters;

            _enumEntryMap.Add(dEnumEntry, xEnumEntry);

            return dEnumEntry;
        }

        #endregion
    }
}
