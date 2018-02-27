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
            dMessage.Name = NamingConventionHelper.GetPascalStyleString(xMessage.Name);
            dMessage.Description = xMessage.Description;
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
            dEnum.Name = NamingConventionHelper.GetPascalStyleString(xEnumName);
            dEnum.Description = xEnum.Description;
            dEnum.Entries = ToModels(xEnum.Entries, xEnumName);
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
            dMessageField.Type = ToFieldType(xMessageField.Type);
            dMessageField.Name = NamingConventionHelper.GetPascalStyleString(xMessageField.Name);
            dMessageField.Enum = GetEnumName(xMessageField);
            dMessageField.Units = xMessageField.Units;
            dMessageField.Display = xMessageField.Display;
            dMessageField.Text = xMessageField.Text;
            return dMessageField;
        }

        private static string GetEnumName(Xml.MessageField xMessageField)
        {
            string enumName = String.IsNullOrWhiteSpace(xMessageField.Enum) ? null : NamingConventionHelper.GetPascalStyleString(xMessageField.Enum);
            return enumName;
        }

        private static MessageFieldType ToFieldType(string type)
        {
            string basicType = GetBasicFieldTypeFromString(type);

            switch (basicType)
            {
                case "float":
                    return MessageFieldType.Float32;
                case "int8_t":
                    return MessageFieldType.Int8;
                case "uint8_t":
                case "uint8_t_mavlink_version":
                    return MessageFieldType.UInt8;
                case "int16_t":
                    return MessageFieldType.Int16;
                case "uint16_t":
                    return MessageFieldType.UInt16;
                case "int32_t":
                    return MessageFieldType.Int32;
                case "uint32_t":
                    return MessageFieldType.UInt32;
                case "int64_t":
                    return MessageFieldType.Int64;
                case "uint64_t":
                    return MessageFieldType.UInt64;
                case "char":
                    return MessageFieldType.Char;
                case "double":
                    return MessageFieldType.Double;
                default:
                    return MessageFieldType.None;
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

        private static IEnumerable<Data.EnumEntry> ToModels(IEnumerable<Xml.EnumEntry> xEnumEntries, string xEnumName)
        {
            return xEnumEntries.Select(m => ToModel(m, xEnumName));
        }

        private static Data.EnumEntry ToModel(Xml.EnumEntry xEnumEntry, string xEnumName)
        {
            Data.EnumEntry dEnumEntry = new Data.EnumEntry();
            string shortEntryName = GetShortEnumEntryName(xEnumName, xEnumEntry.Name);
            string entryName = NamingConventionHelper.GetPascalStyleString(shortEntryName);
            dEnumEntry.Name = entryName;
            dEnumEntry.Value = xEnumEntry.Value;
            dEnumEntry.Description = xEnumEntry.Description;
            return dEnumEntry;
        }


        private static string GetShortEnumEntryName(string enumName, string entryName)
        {
            if (!entryName.StartsWith(enumName))
                return entryName;

            return entryName.Substring(enumName.Length + 1);
        }

        #endregion
    }
}
