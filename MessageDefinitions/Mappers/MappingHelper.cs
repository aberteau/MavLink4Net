using System;
using System.Collections.Generic;
using System.Linq;
using MavLink4Net.MessageDefinitions.Data;
using Enum = MavLink4Net.MessageDefinitions.Data.Enum;

namespace MavLink4Net.MessageDefinitions.Mappers
{
    class MappingHelper
    {
        #region MavLink

        public static Data.MavLink ToModel(Xml.MavLink xMavLink)
        {
            Data.MavLink dMavLink = new Data.MavLink();
            dMavLink.Version = xMavLink.Version;
            dMavLink.Dialect = xMavLink.Dialect;
            IEnumerable<Data.Enum> enums = ToModels(xMavLink.Enums);
            dMavLink.Enums = enums;

            IDictionary<String, Data.Enum> enumByName = enums.ToDictionary(e => e.Name, e => e);

            dMavLink.Messages = ToModels(xMavLink.Messages, enumByName);

            return dMavLink;
        }

        #endregion

        #region Message

        private static IEnumerable<Data.Message> ToModels(IEnumerable<Xml.Message> xMessages, IDictionary<String, Data.Enum> enumByName)
        {
            return xMessages.Select(m => ToModel(m, enumByName));
        }

        private static Data.Message ToModel(Xml.Message xMessage, IDictionary<String, Data.Enum> enumByName)
        {
            Data.Message dMessage = new Data.Message();
            dMessage.Id = xMessage.Id;
            dMessage.Name = xMessage.Name;
            dMessage.Description = StringHelper.TrimAndNormalizeCarriageReturn(xMessage.Description);
            dMessage.Fields = ToModels(xMessage.Fields, enumByName);
            dMessage.CrcExtra = CrcHelper.GetExtraCrc(dMessage);
            return dMessage;
        }

        #endregion

        #region Enum

        private static IEnumerable<Data.Enum> ToModels(IEnumerable<Xml.Enum> xEnums)
        {
            return xEnums.Select(m => ToModel(m));
        }

        private static Data.Enum ToModel(Xml.Enum xEnum)
        {
            Data.Enum dEnum = new Data.Enum();
            string xEnumName = xEnum.Name;
            dEnum.Name = xEnumName;
            dEnum.Description = StringHelper.TrimAndNormalizeCarriageReturn(xEnum.Description);
            dEnum.Entries = ToModels(xEnum.Entries);
            return dEnum;
        }

        #endregion

        #region MessageField

        private static IEnumerable<Data.MessageField> ToModels(IEnumerable<Xml.MessageField> xMessageFields, IDictionary<String, Data.Enum> enumByName)
        {
            IList<Data.MessageField> fields = new List<MessageField>();
            int definitionIndex = 0;
            foreach (Xml.MessageField xMessageField in xMessageFields)
            {
                MessageField messageField = ToModel(xMessageField, definitionIndex, enumByName);
                fields.Add(messageField);
                definitionIndex++;
            }

            return fields;
        }

        private static Data.MessageField ToModel(Xml.MessageField xMessageField, Int32 definitionIndex, IDictionary<String, Data.Enum> enumByName)
        {
            Data.MessageField dMessageField = new Data.MessageField();
            dMessageField.DefinitionIndex = definitionIndex;
            dMessageField.Type = GetFieldType(xMessageField, enumByName);
            dMessageField.Name = xMessageField.Name;
            dMessageField.Units = xMessageField.Units;
            dMessageField.Display = StringHelper.TrimAndNormalizeCarriageReturn(xMessageField.Display);
            dMessageField.Text = StringHelper.TrimAndNormalizeCarriageReturn(xMessageField.Text);
            return dMessageField;
        }

        private static Data.MessageFieldType GetFieldType(Xml.MessageField xMessageField, IDictionary<String, Data.Enum> enumByName)
        {
            Data.MessageFieldType fieldType = new Data.MessageFieldType();
            fieldType.ArrayLength = GetArraySize(xMessageField.Type);
            MessageFieldDataType dataType = MessageFieldTypeMapper.ToDataType(xMessageField.Type);
            fieldType.DataType = dataType;
            fieldType.TypeLength = TypeLengthHelper.GetTypeLength(dataType);
            fieldType.Enum = String.IsNullOrWhiteSpace(xMessageField.Enum) ? null : enumByName[xMessageField.Enum];
            return fieldType;
        }

        private static int GetArraySize(string t)
        {
            string[] tt = t.Split('[', ']');
            if (tt.Length > 1)
                return ParseToInt(tt[1]);

            return 0;
        }

        private static int ParseToInt(string str, int defaultValue = -1)
        {
            if (int.TryParse(str, out var result))
                return result;

            return defaultValue;
        }

        #endregion

        #region EnumEntry

        private static IEnumerable<Data.EnumEntry> ToModels(IEnumerable<Xml.EnumEntry> xEnumEntries)
        {
            return xEnumEntries.Select(m => ToModel(m)).ToList();
        }

        private static Data.EnumEntry ToModel(Xml.EnumEntry xEnumEntry)
        {
            Data.EnumEntry dEnumEntry = new Data.EnumEntry();
            dEnumEntry.Name = xEnumEntry.Name;
            dEnumEntry.Value = GetNullableInt(xEnumEntry.Value);
            dEnumEntry.Description = StringHelper.TrimAndNormalizeCarriageReturn(xEnumEntry.Description);
            dEnumEntry.Parameters = ToModels(xEnumEntry.Parameters);
            return dEnumEntry;
        }

        private static int? GetNullableInt(string valueStr)
        {
            int? nullableInt = String.IsNullOrWhiteSpace(valueStr) ? new Nullable<int>() : Int32.Parse(valueStr);
            return nullableInt;
        }

        #endregion

        #region EnumEntryParameter

        private static IEnumerable<EnumEntryParameter> ToModels(IEnumerable<Xml.EnumEntryParameter> xEnumEntries)
        {
            return xEnumEntries.Select(m => ToModel(m));
        }

        private static EnumEntryParameter ToModel(Xml.EnumEntryParameter xEnumEntry)
        {
            EnumEntryParameter entryParameter = new EnumEntryParameter();
            entryParameter.Index = xEnumEntry.Index;
            entryParameter.Description = StringHelper.TrimAndNormalizeCarriageReturn(xEnumEntry.Description);
            return entryParameter;
        }

        #endregion
    }
}
