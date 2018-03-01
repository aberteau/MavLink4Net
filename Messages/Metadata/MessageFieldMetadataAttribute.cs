using System;

namespace MavLink4Net.Messages.Metadata
{
    public class MessageFieldMetadataAttribute
        : Attribute
    {
        public String Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Units { get; set; }

        public string Display { get; set; }
    }
}