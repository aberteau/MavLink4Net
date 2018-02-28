using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MavLink4Net.MessageDefinitions.Xml
{
    public class EnumEntry
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("value")]
        public String Value { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("param")]
        public List<EnumEntryParameter> Parameters { get; set; }
    }
}
