using System;
using System.Collections.Generic;
using System.Linq;

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
            dMavLink.Messages = ToModels(xMavLink.Messages);
            return dMavLink;
        }

        #endregion

        #region Message

        private static IEnumerable<Data.Message> ToModels(List<Xml.Message> xMessages)
        {
            return xMessages.Select(m => ToModel(m));
        }

        private static Data.Message ToModel(Xml.Message xMessage)
        {
            Data.Message dMessage = new Data.Message();
            dMessage.Id = xMessage.Id;
            dMessage.Name = xMessage.Name;
            dMessage.Description = xMessage.Description;
            dMessage.Fields = ToModels(xMessage.Fields);
            return dMessage;
        }

        #endregion

        #region Enum

        private static IEnumerable<Data.Enum> ToModels(List<Xml.Enum> xEnums)
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

        private static IEnumerable<Data.MessageField> ToModels(List<Xml.MessageField> xMessageFields)
        {
            return xMessageFields.Select(m => ToModel(m));
        }

        private static Data.MessageField ToModel(Xml.MessageField xMessageField)
        {
            Data.MessageField dMessageField = new Data.MessageField();
            dMessageField.Type = xMessageField.Type;
            dMessageField.Name = xMessageField.Name;
            dMessageField.Enum = xMessageField.Enum;
            dMessageField.Units = xMessageField.Units;
            dMessageField.Display = xMessageField.Display;
            dMessageField.Text = xMessageField.Text;
            return dMessageField;
        }

        #endregion

        #region EnumEntry

        private static IEnumerable<Data.EnumEntry> ToModels(List<Xml.EnumEntry> xEnumEntries, string xEnumName)
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
