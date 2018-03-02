using System.Collections.Generic;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class Enum
    {
        public Xml.Enum XmlDefinition { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<EnumEntry> Entries { get; set; }

        public bool IsNameTransformed => !XmlDefinition.Name.Equals(Name);
    }
}
