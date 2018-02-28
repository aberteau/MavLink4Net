using System;
using System.Collections.Generic;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class EnumEntry
    {
        public string Name { get; set; }

        public Nullable<int> Value { get; set; }

        public string Description { get; set; }

        public IEnumerable<EnumEntryParameter> Parameters { get; set; }
    }
}
