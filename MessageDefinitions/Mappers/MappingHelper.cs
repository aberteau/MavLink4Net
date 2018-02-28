using System;
using System.Collections.Generic;
using System.Linq;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.MessageDefinitions.Mappers
{
    class MappingHelper
    {
        #region MavLink

        public static Data.MavLink ToModel(Xml.MavLink xMavLink, EnumValuePrefixRemovalStrategy strategy)
        {
            Data.MavLink dMavLink = new Data.MavLink();
            dMavLink.Version = xMavLink.Version;
            dMavLink.Dialect = xMavLink.Dialect;
            dMavLink.Enums = ToModels(xMavLink.Enums, strategy);
            
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

        private static IEnumerable<Data.Enum> ToModels(IEnumerable<Xml.Enum> xEnums, EnumValuePrefixRemovalStrategy strategy)
        {
            return xEnums.Select(m => ToModel(m, strategy));
        }

        private static Data.Enum ToModel(Xml.Enum xEnum, EnumValuePrefixRemovalStrategy strategy)
        {
            Data.Enum dEnum = new Data.Enum();
            string xEnumName = xEnum.Name;
            dEnum.OriginalName = xEnumName;
            dEnum.Name = NamingConventionHelper.GetEnumName(xEnumName);
            dEnum.Description = StringHelper.TrimAndNormalizeCarriageReturn(xEnum.Description);
            dEnum.Entries = ToModels(xEnum.Entries, xEnumName, strategy);
            return dEnum;
        }

        #endregion

        #region MessageField

        private static IEnumerable<Data.MessageField> ToModels(IEnumerable<Xml.MessageField> xMessageFields)
        {
            IList<Data.MessageField> fields = new List<MessageField>();
            int definitionIndex = 0;
            foreach (Xml.MessageField xMessageField in xMessageFields)
            {
                MessageField messageField = ToModel(xMessageField, definitionIndex);
                fields.Add(messageField);
                definitionIndex++;
            }

            return fields;
        }

        private static Data.MessageField ToModel(Xml.MessageField xMessageField, Int32 definitionIndex)
        {
            Data.MessageField dMessageField = new Data.MessageField();
            dMessageField.DefinitionIndex = definitionIndex;
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
            fieldType.ArrayLength = GetArraySize(xMessageField.Type);
            MessageFieldPrimitiveType primitiveType = ToFieldPrimitiveType(xMessageField.Type);
            fieldType.PrimitiveType = primitiveType;
            fieldType.TypeLength = TypeLengthHelper.GetTypeLength(primitiveType);
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

        private static MessageFieldPrimitiveType ToFieldPrimitiveType(string type)
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

        private static string GetEnumValuePrefix(IEnumerable<Xml.EnumEntry> xEnumEntries, String xEnumName, EnumValuePrefixRemovalStrategy strategy)
        {
            switch (strategy)
            {
                case EnumValuePrefixRemovalStrategy.None:
                    return null;

                case EnumValuePrefixRemovalStrategy.RemoveEnumName:
                    if (!String.IsNullOrWhiteSpace(xEnumName))
                        return xEnumName;

                    return null;

                case EnumValuePrefixRemovalStrategy.RemoveLongestCommonString:
                    if (xEnumEntries.Count() > 1)
                    {
                        IEnumerable<String> xEnumValues = xEnumEntries.Select(e => e.Name);
                        string longestStartSubstring = StringHelper.GetLongestCommonStartSubstring(xEnumValues);

                        if (String.IsNullOrWhiteSpace(longestStartSubstring))
                            return null;

                        return longestStartSubstring;
                    }

                    if (!String.IsNullOrWhiteSpace(xEnumName))
                        return xEnumName;

                    return null;
            }

            return null;
        }

        private static IEnumerable<Data.EnumEntry> ToModels(IEnumerable<Xml.EnumEntry> xEnumEntries, string xEnumName, EnumValuePrefixRemovalStrategy strategy)
        {
            string enumValuePrefix = GetEnumValuePrefix(xEnumEntries, xEnumName, strategy);
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
