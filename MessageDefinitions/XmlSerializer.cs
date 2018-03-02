using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using MavLink4Net.MessageDefinitions.Xml;

namespace MavLink4Net.MessageDefinitions
{
    public class XmlSerializer
    {
        public static MavLink Deserialize(TextReader textReader)
        {
            XDocument mavLinkDocument = XDocument.Load(textReader);
            MavLink mavLink = Deserialize(mavLinkDocument);
            return mavLink;
        }

        public static MavLink Deserialize(string path)
        {
            XDocument mavLinkDocument = XDocument.Load(path);
            MavLink mavLink = Deserialize(mavLinkDocument);
            return mavLink;
        }

        private static MavLink Deserialize(XDocument mavLinkDocument)
        {
            XElement mavLinkElement = mavLinkDocument.Element(XName.Get("mavlink"));
            Xml.MavLink mavLink = ToMavLink(mavLinkElement);
            return mavLink;
        }

        private static MavLink ToMavLink(XElement mavLinkElement)
        {
            Xml.MavLink mavLink = new Xml.MavLink();

            mavLink.Version = Int32.Parse(mavLinkElement.Element(XName.Get("version")).Value);
            mavLink.Dialect = mavLinkElement.Element(XName.Get("dialect"))?.Value;

            // enums
            XElement enumsElement = mavLinkElement.Element(XName.Get("enums"));
            IEnumerable<XElement> enumElements = enumsElement.Elements(XName.Get("enum"));
            mavLink.Enums = ToEnums(enumElements);

            // messages
            XElement messagesElement = mavLinkElement.Element(XName.Get("messages"));
            IEnumerable<XElement> messageElements = messagesElement.Elements(XName.Get("message"));
            mavLink.Messages = ToMessages(messageElements);

            return mavLink;
        }

        #region Enum

        private static IEnumerable<Xml.Enum> ToEnums(IEnumerable<XElement> xElements)
        {
            IList<Xml.Enum> enums = new List<Xml.Enum>();
            foreach (XElement enumElement in xElements)
            {
                Xml.Enum mEnum = ToEnum(enumElement);
                enums.Add(mEnum);
            }

            return enums;
        }

        private static Xml.Enum ToEnum(XElement xElement)
        {
            Xml.Enum mEnum = new Xml.Enum();
            mEnum.Name = xElement.Attribute("name")?.Value;

            XElement descriptionElement = xElement.Element(XName.Get("description"));
            mEnum.Description = descriptionElement?.Value;

            IEnumerable<XElement> entryElements = xElement.Elements(XName.Get("entry"));
            mEnum.Entries = ToEnumEntries(entryElements);

            return mEnum;
        }

        #endregion

        #region EnumEntry

        private static IEnumerable<Xml.EnumEntry> ToEnumEntries(IEnumerable<XElement> xElements)
        {
            return xElements.Select(m => ToEnumEntry(m)).ToList();
        }

        private static Xml.EnumEntry ToEnumEntry(XElement xElement)
        {
            Xml.EnumEntry enumEntry = new Xml.EnumEntry();

            enumEntry.Name = xElement.Attribute("name")?.Value;

            enumEntry.Value = xElement.Attribute("value")?.Value;

            XElement descriptionElement = xElement.Element(XName.Get("description"));
            enumEntry.Description = descriptionElement?.Value;

            IEnumerable<XElement> paramElements = xElement.Elements(XName.Get("param"));
            enumEntry.Parameters = ToParameters(paramElements);

            return enumEntry;
        }

        #endregion

        #region EnumEntryParameter

        private static IEnumerable<Xml.EnumEntryParameter> ToParameters(IEnumerable<XElement> xElements)
        {
            return xElements.Select(m => ToParameter(m));
        }

        private static EnumEntryParameter ToParameter(XElement xElement)
        {
            EnumEntryParameter entryParameter = new EnumEntryParameter();
            entryParameter.Index = Int32.Parse(xElement.Attribute("index").Value);
            entryParameter.Description = xElement.Value;
            return entryParameter;
        }

        #endregion

        #region Message

        private static IEnumerable<Xml.Message> ToMessages(IEnumerable<XElement> xElements)
        {
            return xElements.Select(m => ToMessage(m));
        }

        private static Xml.Message ToMessage(XElement xElement)
        {
            Xml.Message message = new Xml.Message();
            message.Id = Int32.Parse(xElement.Attribute("id").Value);
            message.Name = xElement.Attribute("name")?.Value;
            message.Description = xElement.Element(XName.Get("description"))?.Value;

            IEnumerable<XElement> fieldElements = xElement.Elements(XName.Get("field"));
            message.Fields = ToFields(fieldElements);

            return message;
        }

        #endregion

        #region MessageField

        private static IEnumerable<Xml.MessageField> ToFields(IEnumerable<XElement> xElements)
        {
            IList<Xml.MessageField> messageFields = new List<MessageField>();
            Int32 index = 0;
            foreach (XElement messageFieldXElement in xElements)
            {
                Xml.MessageField dMessageField = ToField(messageFieldXElement, index);
                messageFields.Add(dMessageField);
                index++;
            }

            return messageFields;
        }

        private static Xml.MessageField ToField(XElement xElement, Int32 index)
        {
            Xml.MessageField dMessageField = new Xml.MessageField();
            dMessageField.Index = index;
            dMessageField.Type = xElement.Attribute("type").Value;
            dMessageField.Name = xElement.Attribute("name").Value;
            dMessageField.Enum = xElement.Attribute("enum")?.Value;
            dMessageField.Units = xElement.Attribute("units")?.Value;
            dMessageField.Display = xElement.Attribute("display")?.Value;
            dMessageField.Text = xElement.Value;
            return dMessageField;
        }

        #endregion
    }
}
