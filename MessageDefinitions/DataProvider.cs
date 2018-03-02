using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using MavLink4Net.MessageDefinitions.Data;
using MavLink4Net.MessageDefinitions.Mappers;
using MavLink4Net.MessageDefinitions.Transformations.Interfaces;

namespace MavLink4Net.MessageDefinitions
{
    public class DataProvider
    {
        private readonly bool _includeExtensionFields;
        private readonly IMessageFilter _messageFilter;
        private readonly IMessageNameTransformation _messageNameTransformation;
        private readonly IMessageFieldNameTransformation _messageFieldNameTransformation;
        private readonly IEnumNameTransformation _enumNameTransformation;
        private readonly IEnumEntryNameTransformation _enumEntryNameTransformation;
        private readonly IDictionary<String, Data.Enum> _enumByXmlEnum;

        public DataProvider(bool includeExtensionFields, IMessageNameTransformation messageNameTransformation, IMessageFieldNameTransformation messageFieldNameTransformation, IEnumNameTransformation enumNameTransformation, IEnumEntryNameTransformation enumEntryNameTransformation, IMessageFilter messageFilter)
        {
            _includeExtensionFields = includeExtensionFields;
            _messageNameTransformation = messageNameTransformation;
            _messageFieldNameTransformation = messageFieldNameTransformation;
            _enumNameTransformation = enumNameTransformation;
            _enumEntryNameTransformation = enumEntryNameTransformation;
            _messageFilter = messageFilter;

            _enumByXmlEnum = new Dictionary<String, Data.Enum>();
        }

        #region Enum

        private IEnumerable<Data.Enum> ToModels(IEnumerable<Xml.Enum> xEnums)
        {
            IList<Data.Enum> dEnums = new List<Data.Enum>();
            foreach (Xml.Enum xEnum in xEnums)
            {
                Data.Enum dEnum = ToModel(xEnum);
                dEnums.Add(dEnum);

                _enumByXmlEnum.Add(xEnum.Name, dEnum);
            }

            return dEnums;
        }

        private Data.Enum ToModel(Xml.Enum xEnum)
        {
            Data.Enum dEnum = new Data.Enum();
            dEnum.XmlDefinition = xEnum;
            string xEnumName = GetName(xEnum);
            dEnum.Name = xEnumName;
            dEnum.Description = StringHelper.TrimAndNormalizeCarriageReturn(xEnum.Description);
            dEnum.Entries = ToModels(xEnum.Entries, xEnumName);

            return dEnum;
        }

        private string GetName(Xml.Enum xEnum)
        {
            if (_enumNameTransformation == null)
                return xEnum.Name;

            return _enumNameTransformation.Transform(xEnum);
        }

        #endregion

        #region EnumEntry

        private IEnumerable<Data.EnumEntry> ToModels(IEnumerable<Xml.EnumEntry> xEnumEntries, string xEnumName)
        {
            _enumEntryNameTransformation?.SetContext(xEnumEntries, xEnumName);
            return xEnumEntries.Select(m => ToModel(m)).ToList();
        }

        private Data.EnumEntry ToModel(Xml.EnumEntry xEnumEntry)
        {
            Data.EnumEntry dEnumEntry = new Data.EnumEntry();
            dEnumEntry.XmlDefinition = xEnumEntry;
            dEnumEntry.Name = GetName(xEnumEntry);
            dEnumEntry.Value = GetNullableInt(xEnumEntry.Value);
            dEnumEntry.Description = StringHelper.TrimAndNormalizeCarriageReturn(xEnumEntry.Description);
            dEnumEntry.Parameters = ToModels(xEnumEntry.Parameters);
            return dEnumEntry;
        }

        private int? GetNullableInt(string valueStr)
        {
            int? nullableInt = String.IsNullOrWhiteSpace(valueStr) ? new Nullable<int>() : Int32.Parse(valueStr);
            return nullableInt;
        }

        private string GetName(Xml.EnumEntry xEnumEntry)
        {
            if (_enumEntryNameTransformation == null)
                return xEnumEntry.Name;

            return _enumEntryNameTransformation.Transform(xEnumEntry);
        }

        #endregion

        #region EnumEntryParameter

        private static IEnumerable<EnumEntryParameter> ToModels(IEnumerable<Xml.EnumEntryParameter> xEnumEntries)
        {
            return xEnumEntries.Select(m => ToModel(m)).ToList();
        }

        private static EnumEntryParameter ToModel(Xml.EnumEntryParameter xEnumEntry)
        {
            EnumEntryParameter entryParameter = new EnumEntryParameter();
            entryParameter.Index = xEnumEntry.Index;
            entryParameter.Description = StringHelper.TrimAndNormalizeCarriageReturn(xEnumEntry.Description);
            return entryParameter;
        }

        #endregion

        #region Message

        private IEnumerable<Data.Message> ToModels(IEnumerable<Xml.Message> xMessages)
        {
            IEnumerable<Xml.Message> filteredMessages = _messageFilter != null ? _messageFilter.Filter(xMessages).ToList() : xMessages;
            return filteredMessages.Select(m => ToModel(m));
        }

        private Data.Message ToModel(Xml.Message xMessage)
        {
            Data.Message dMessage = new Data.Message();
            dMessage.XmlDefinition = xMessage;
            dMessage.Id = xMessage.Id;
            dMessage.Name = GetName(xMessage);
            dMessage.Description = StringHelper.TrimAndNormalizeCarriageReturn(xMessage.Description);

            IEnumerable<Xml.MessageField> filteredMessageFields = _includeExtensionFields ? xMessage.Fields : xMessage.Fields.Where(f => !f.IsExtension);

            dMessage.Fields = ToModels(filteredMessageFields);
            dMessage.CrcExtra = CrcHelper.GetExtraCrc(xMessage.Name, filteredMessageFields);
            return dMessage;
        }

        private string GetName(Xml.Message xMessage)
        {
            if (_messageNameTransformation == null)
                return xMessage.Name;

            return _messageNameTransformation.Transform(xMessage);
        }

        #endregion

        #region MessageField

        private string GetName(Xml.MessageField xMessageField)
        {
            if (_messageFieldNameTransformation == null)
                return xMessageField.Name;

            return _messageFieldNameTransformation.Transform(xMessageField);
        }

        private IEnumerable<Data.MessageField> ToModels(IEnumerable<Xml.MessageField> xMessageFields)
        {
            IList<Data.MessageField> messageFields = new List<MessageField>();
            Int32 definitionIndex = 0;

            foreach (Xml.MessageField xMessageField in xMessageFields)
            {
                Data.MessageField dMessageField = ToModel(xMessageField, definitionIndex);
                messageFields.Add(dMessageField);
                definitionIndex++;
            }

            return messageFields;
        }

        private Data.MessageField ToModel(Xml.MessageField xMessageField, Int32 definitionIndex)
        {
            Data.MessageField dMessageField = new Data.MessageField();
            dMessageField.XmlDefinition = xMessageField;
            dMessageField.DefinitionIndex = definitionIndex;
            dMessageField.Type = GetFieldType(xMessageField);
            dMessageField.Name = GetName(xMessageField);
            dMessageField.Units = xMessageField.Units;
            dMessageField.Display = StringHelper.TrimAndNormalizeCarriageReturn(xMessageField.Display);
            dMessageField.Text = StringHelper.TrimAndNormalizeCarriageReturn(xMessageField.Text);
            return dMessageField;
        }

        private Data.MessageFieldType GetFieldType(Xml.MessageField xMessageField)
        {
            MessageFieldDataType dataType = TypeHelper.ToDataType(xMessageField.Type);
            int typeLength = TypeHelper.GetTypeLength(dataType);

            bool isArray = TypeHelper.IsArray(xMessageField.Type);
            if (isArray)
            {
                Int32 arrayLength = TypeHelper.GetArraySize(xMessageField.Type);
                return new Data.MessageFieldType(dataType, typeLength, arrayLength);
            }

            bool isNotNullEnum = !String.IsNullOrWhiteSpace(xMessageField.Enum);
            if (isNotNullEnum)
            {
                Data.Enum vEnum = _enumByXmlEnum[xMessageField.Enum];
                return new Data.MessageFieldType(dataType, typeLength, vEnum);
            }

            return new Data.MessageFieldType(dataType, typeLength);
        }

        #endregion

        public Data.MavLink GetMavLink(string path)
        {
            Xml.MavLink xMavLink = XmlSerializer.Deserialize(path);

            Data.MavLink dMavLink = new Data.MavLink();
            dMavLink.Version = xMavLink.Version;
            dMavLink.Dialect = xMavLink.Dialect;
            IEnumerable<Data.Enum> enums = ToModels(xMavLink.Enums).ToList();
            dMavLink.Enums = enums;

            dMavLink.Messages = ToModels(xMavLink.Messages).ToList();

            return dMavLink;
        }
    }
}
