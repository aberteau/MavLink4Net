using System;
using System.Collections.Generic;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class EnumEntry
    {
        public Xml.EnumEntry XmlDefinition { get; set; }

        public string Name { get; set; }

        public Nullable<int> Value { get; set; }

        public string Description { get; set; }

        public IEnumerable<EnumEntryParameter> Parameters { get; set; }

        public bool IsNameTransformed => !XmlDefinition.Name.Equals(Name);
    }
}
