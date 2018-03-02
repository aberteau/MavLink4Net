using System.Collections.Generic;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class Enum
    {
        public Xml.Enum XmlItem { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<EnumEntry> Entries { get; set; }

        public bool IsNameTransformed => !XmlItem.Name.Equals(Name);
    }
}
