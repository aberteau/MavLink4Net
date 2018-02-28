using System.Xml.Serialization;

namespace MavLink4Net.MessageDefinitions.Xml
{
    public class EnumEntryParameter
    {
        [XmlAttribute("index")]
        public int Index;

        [XmlText]
        public string Description;
    }
}