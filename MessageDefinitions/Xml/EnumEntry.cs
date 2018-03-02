using System;
using System.Collections.Generic;

namespace MavLink4Net.MessageDefinitions.Xml
{
    public class EnumEntry
    {
        public string Name { get; set; }

        public String Value { get; set; }

        public string Description { get; set; }

        public IEnumerable<EnumEntryParameter> Parameters { get; set; }
    }
}
