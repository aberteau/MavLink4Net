using System.Collections.Generic;

namespace MavLink4Net.MessageDefinitions.Xml
{
    public class Enum
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<EnumEntry> Entries { get; set; }
    }
}
