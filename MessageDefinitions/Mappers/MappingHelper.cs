using System;
using System.Collections.Generic;
using System.Linq;
using MavLink4Net.MessageDefinitions.Data;

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
            dMavLink.Enums = ToModels(xMavLink.Enums);
            
            IEnumerable<Xml.Message> xMessages = Filter(xMavLink.Messages).ToList();
            dMavLink.Messages = ToModels(xMessages);
            return dMavLink;
        }

        private static IEnumerable<Xml.Message> Filter(IEnumerable<Xml.Message> xMessages)
        {
            // discard anything beyond 255
            IEnumerable<Xml.Message> filteredMessages = xMessages.Where(m => m.Id < 256);
            return filteredMessages;
        }

        #endregion

        #region Message

        private static IEnumerable<Data.Message> ToModels(IEnumerable<Xml.Message> xMessages)
        {
            return xMessages.Select(m => ToModel(m));
        }

        private static Data.Message ToModel(Xml.Message xMessage)
        {
            Data.Message dMessage = new Data.Message();
            dMessage.Id = xMessage.Id;
            dMessage.OriginalName = xMessage.Name;
            dMessage.Name = NamingConventionHelper.GetPascalStyleString(xMessage.Name);
            dMessage.Description = StringHelper.TrimAndNormalizeCarriageReturn(xMessage.Description);
            dMessage.Fields = ToModels(xMessage.Fields);
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
            dEnum.OriginalName = xEnumName;
            dEnum.Name = NamingConventionHelper.GetEnumName(xEnumName);
            dEnum.Description = StringHelper.TrimAndNormalizeCarriageReturn(xEnum.Description);
            String enumValuePrefix = $"{xEnumName}_";
            dEnum.Entries = ToModels(xEnum.Entries, enumValuePrefix);
            return dEnum;
        }

        #endregion

        #region MessageField

        private static IEnumerable<Data.MessageField> ToModels(IEnumerable<Xml.MessageField> xMessageFields)
        {
            return xMessageFields.Select(m => ToModel(m));
        }

        private static Data.MessageField ToModel(Xml.MessageField xMessageField)
        {
            Data.MessageField dMessageField = new Data.MessageField();
            dMessageField.Type = GetFieldType(xMessageField);
            dMessageField.OriginalName = xMessageField.Name;
            dMessageField.Name = NamingConventionHelper.GetPascalStyleString(xMessageField.Name);
            dMessageField.Units = xMessageField.Units;
            dMessageField.Display = StringHelper.TrimAndNormalizeCarriageReturn(xMessageField.Display);
            dMessageField.Text = StringHelper.TrimAndNormalizeCarriageReturn(xMessageField.Text);
            return dMessageField;
        }

        private static Data.MessageFieldType GetFieldType(Xml.MessageField xMessageField)
        {
            Data.MessageFieldType fieldType = new Data.MessageFieldType();
            fieldType.ArraySize = GetArraySize(xMessageField.Type);
            fieldType.PrimitiveType = ToFieldType(xMessageField.Type);
            fieldType.Enum = NamingConventionHelper.GetEnumName(xMessageField.Enum);
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

        private static MessageFieldPrimitiveType ToFieldType(string type)
        {
            string basicType = GetBasicFieldTypeFromString(type);

            switch (basicType)
            {
                case "float":
                    return MessageFieldPrimitiveType.Float32;
                case "int8_t":
                    return MessageFieldPrimitiveType.Int8;
                case "uint8_t":
                case "uint8_t_mavlink_version":
                    return MessageFieldPrimitiveType.UInt8;
                case "int16_t":
                    return MessageFieldPrimitiveType.Int16;
                case "uint16_t":
                    return MessageFieldPrimitiveType.UInt16;
                case "int32_t":
                    return MessageFieldPrimitiveType.Int32;
                case "uint32_t":
                    return MessageFieldPrimitiveType.UInt32;
                case "int64_t":
                    return MessageFieldPrimitiveType.Int64;
                case "uint64_t":
                    return MessageFieldPrimitiveType.UInt64;
                case "char":
                    return MessageFieldPrimitiveType.Char;
                case "double":
                    return MessageFieldPrimitiveType.Double;
                default:
                    return MessageFieldPrimitiveType.None;
            }
        }

        public static string GetBasicFieldTypeFromString(string t)
        {
            string[] tt = t.Split('[', ']');

            if (tt.Length == 0)
                return "";

            string result = tt[0];
            return result;
        }

        #endregion

        #region EnumEntry

        private static IEnumerable<Data.EnumEntry> ToModels(IEnumerable<Xml.EnumEntry> xEnumEntries, string enumValuePrefix)
        {
            return xEnumEntries.Select(m => ToModel(m, enumValuePrefix));
        }

        private static Data.EnumEntry ToModel(Xml.EnumEntry xEnumEntry, string enumValuePrefix)
        {
            Data.EnumEntry dEnumEntry = new Data.EnumEntry();
            string shortEntryName = StringHelper.RemoveAtStart(xEnumEntry.Name, enumValuePrefix);
            string entryName = NamingConventionHelper.GetPascalStyleString(shortEntryName);
            dEnumEntry.OriginalName = xEnumEntry.Name;
            dEnumEntry.Name = entryName;
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
