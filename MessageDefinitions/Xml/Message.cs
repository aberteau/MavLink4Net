using System.Collections.Generic;
using System.Xml.Serialization;

namespace MavLink4Net.MessageDefinitions.Xml
{
    public class Message
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("field")]
        public List<MessageField> Fields { get; set; }
    }
}
