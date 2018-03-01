using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.Messages.Metadata
{
    public class MessageMetadataAttribute
        : Attribute
    {
        public MavMessageType Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
