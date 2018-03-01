using System;
using System.Collections.Generic;
using System.Linq;
using MavLink4Net.CodeGenerator.Core.Translations.Interfaces;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core.Translations
{
    public class Translator
    {
        private readonly IMessageFilter _messageFilter;
        private readonly IMessageNameTranslation _messageNameTranslation;
        private readonly IMessageFieldNameTranslation _messageFieldNameTranslation;
        private readonly IEnumNameTranslation _enumNameTranslation;
        private readonly IEnumEntryNameTranslation _enumEntryNameTranslation;

        private readonly TranslationMap _translationMap = new TranslationMap();

        public Translator(IMessageNameTranslation messageNameTranslation, IMessageFieldNameTranslation messageFieldNameTranslation, IEnumNameTranslation enumNameTranslation, IEnumEntryNameTranslation enumEntryNameTranslation, IMessageFilter messageFilter)
        {
            _messageNameTranslation = messageNameTranslation;
            _messageFieldNameTranslation = messageFieldNameTranslation;
            _enumNameTranslation = enumNameTranslation;
            _enumEntryNameTranslation = enumEntryNameTranslation;
            _messageFilter = messageFilter;
        }

        public TranslationResult Translate(MavLink xMavLink)
        {
            TranslationResult result = new TranslationResult();
            result.MavLink = TranslateMavLink(xMavLink);
            result.TranslationMap = _translationMap;
            return result;
        }

        private MavLink TranslateMavLink(MavLink xMavLink)
        {
            MavLink dMavLink = new MavLink();
            dMavLink.Version = xMavLink.Version;
            dMavLink.Dialect = xMavLink.Dialect;

            dMavLink.Enums = Translate(xMavLink.Enums);

            IEnumerable<Message> xMessages = _messageFilter != null ? _messageFilter.Filter(xMavLink.Messages).ToList() : xMavLink.Messages;
            dMavLink.Messages = Translate(xMessages);
            return dMavLink;
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
            dMessage.CrcExtra = xMessage.CrcExtra;

            _translationMap.MessageMap.Add(dMessage, xMessage);

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

            _translationMap.EnumMap.Add(dEnum, xEnum);

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

            _translationMap.MessageFieldMap.Add(dMessageField, xMessageField);

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

            IEnumerable<KeyValuePair<MessageDefinitions.Data.Enum, MessageDefinitions.Data.Enum>> keyValuePairs = _translationMap.EnumMap.Where(kvp => kvp.Value.Name.Equals(pEnum.Name));
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

            _translationMap.EnumEntryMap.Add(dEnumEntry, xEnumEntry);

            return dEnumEntry;
        }

        #endregion
    }
}
