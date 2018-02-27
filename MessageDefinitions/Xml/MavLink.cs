using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MavLink4Net.MessageDefinitions.Xml
{
    [XmlRoot("mavlink", Namespace = "")]
    public class MavLink
    {
        [XmlElement("version")]
        public int Version { get; set; }

        [XmlElement("dialect")]
        public string Dialect { get; set; }

        [XmlArray("enums")]
        [XmlArrayItem("enum")]
        public List<Enum> Enums { get; set; }

        [XmlArray("messages")]
        [XmlArrayItem("message")]
        public List<Message> Messages { get; set; }
    }
}
