using System.Collections.Generic;
using System.Xml.Serialization;

namespace MavLink4Net.MessageDefinitions.Xml
{
    public class Enum
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("entry")]
        public List<EnumEntry> Entries { get; set; }
    }
}
