using System.Xml.Serialization;

namespace MavLink4Net.MessageDefinitions.Xml
{
    public class MessageField
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("enum")]
        public string Enum { get; set; }

        [XmlAttribute("units")]
        public string Units { get; set; }

        [XmlAttribute("display")]
        public string Display { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
