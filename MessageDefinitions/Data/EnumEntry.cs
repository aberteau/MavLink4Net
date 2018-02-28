using System;

namespace MavLink4Net.MessageDefinitions.Data
{
    public class EnumEntry
    {
        public string OriginalName { get; set; }

        public string Name { get; set; }

        public Nullable<int> Value { get; set; }

        public string Description { get; set; }
    }
}
